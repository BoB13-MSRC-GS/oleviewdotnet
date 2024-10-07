//    This file is part of OleViewDotNet.
//    Copyright (C) James Forshaw 2014
//
//    OleViewDotNet is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    OleViewDotNet is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with OleViewDotNet.  If not, see <http://www.gnu.org/licenses/>.

using NtApiDotNet;
using OleViewDotNet.Database;
using OleViewDotNet.Utilities.Format;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OleViewDotNet.Forms;

internal partial class SourceCodeViewerControl : UserControl
{
    private COMRegistry m_registry;
    private object m_selected_obj;
    private ICOMSourceCodeFormattable m_formattable_obj;
    private ICOMSourceCodeEditable m_editable_obj;
    private COMSourceCodeBuilderType m_output_type;
    private bool m_hide_comments;
    private bool m_interfaces_only;
    private bool m_hide_parsing_options;
    public bool m_isReally = true;

    public SourceCodeViewerControl()
    {
        InitializeComponent();
        textEditor.SetHighlighting("C#");
        textEditor.IsReadOnly = true;
        m_hide_comments = true;
        toolStripMenuItemHideComments.Checked = true;
        m_interfaces_only = true;
        toolStripMenuItemInterfacesOnly.Checked = true;
        toolStripMenuItemIDLOutputType.Checked = true;
        m_output_type = COMSourceCodeBuilderType.Idl;
        SetText(string.Empty);
    }

    private void SetText(string text)
    {
        textEditor.Text = text.TrimEnd();
        textEditor.Refresh();
    }

    internal void SetRegistry(COMRegistry registry)
    {
        m_registry = registry;
    }

    private static bool IsParsed(ICOMSourceCodeFormattable obj)
    {
        if (obj is ICOMSourceCodeParsable parsable)
        {
            return parsable.IsSourceCodeParsed;
        }
        return true;
    }

    internal void Format(COMSourceCodeBuilder builder, ICOMSourceCodeFormattable formattable)
    {
        if (!IsParsed(formattable))
        {
            builder.AppendLine($"'{m_selected_obj}' needs to be parsed before it can be shown.");
        }
        else
        {
            formattable.Format(builder);
        }
    }

    /* KWAKMU18 ADDED 20240905 - Change Return Type */
    internal String Format()
    /* KWAKMU18 ADDED 20240905 - Change Return Type */
    {
        COMSourceCodeBuilder builder = new(m_registry)
        {
            InterfacesOnly = m_interfaces_only,
            HideComments = m_hide_comments,
            OutputType = m_output_type
        };

        if (m_formattable_obj?.IsFormattable == true)
        {
            Format(builder, m_formattable_obj);
        }
        else
        {
            builder.AppendLine(m_selected_obj is null ?
                "No formattable object selected"
                : $"'{m_selected_obj}' is not formattable.");
            return builder.ToString();
        }
        if (!m_isReally) return builder.ToString();
        if (!Directory.Exists("interfaces\\idls")) Directory.CreateDirectory("interfaces\\idls");
        String fileName = "interfaces\\idls\\";
        if (builder.ToString().StartsWith("struct") ||
            builder.ToString().StartsWith("\nstruct") || builder.ToString().StartsWith("[switch_type") ||
            builder.ToString().StartsWith("\nunion") || builder.ToString().StartsWith("union"))
        {
            SetText(builder.ToString());
            return builder.ToString();
        }
        String content;
        using (StreamWriter writer = new StreamWriter(fileName+"before.interface"))
        {
            content = builder.ToString().TrimEnd('\n');
            content = content.TrimEnd('\n');
            writer.Write(content);
        }
        Form popup = new Form();
        popup.Text = "Please Wait...";
        popup.StartPosition = FormStartPosition.CenterScreen;
        popup.Width = 300;
        popup.Height = 150;

        Label label = new Label();
        label.Text = "Resolving Methods...";
        label.Dock = DockStyle.Fill;
        label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        popup.Controls.Add(label);

        popup.Show();
        Process process = new Process();
        process.StartInfo.FileName = "method.exe";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.Verb = "runas";
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        try
        {
            process.Start();
            process.WaitForExit();
        }
        catch
        {
            popup.Close();
            MessageBox.Show("Failed to resolve interfaces.");
            SetText(builder.ToString());
            return builder.ToString();
        }
        popup.Close();
        int exitCode = process.ExitCode;
        if (exitCode != 0)
        {
            SetText(builder.ToString());
            return builder.ToString();
        }
        process.Dispose();
        using (StreamReader reader = new StreamReader(fileName + "after.interface"))
        {
            content = reader.ReadToEnd();
        }
        SetText(content);
        return content;
        /* KWAKMU18 ADDED 20241001 - TEST*/
        SetText(builder.ToString());
        /* KWAKMU18 ADDED 20241001 - TEST*/
        /* KWAKMU18 ADDED 20240905 - Add Return Value */
        return builder.ToString();
        /* KWAKMU18 ADDED 20240905 - Add Return Value */
    }

    internal String GetIid()
    {
        COMSourceCodeBuilder builder = new(m_registry)
        {
            InterfacesOnly = m_interfaces_only,
            HideComments = m_hide_comments,
            OutputType = m_output_type
        };

        if (m_formattable_obj?.IsFormattable == true)
        {
            Format(builder, m_formattable_obj);
        }
        else
        {
            return null;
        }

        String now = builder.ToString();
        if (now[0] == '[') {
            String[] nows = now.Split('\n');
            for(int i=0;i<nows.Length;i++)
            {
                if (nows[i].Contains("uuid"))
                {
                    return nows[i].Split('(')[1].Split(')')[0];
                }
            }
        }
        else
        {
            String[] nows = now.Split('\n');
            return nows[0].Split('(')[2].Trim('"');
        }
        return null;
    }

    internal object SelectedObject
    {
        get => m_selected_obj;
        set
        {
            m_selected_obj = value;
            if (value is IEnumerable<ICOMSourceCodeFormattable> list)
            {
                m_formattable_obj = new SourceCodeFormattableList(list);
            }
            else if (value is ICOMSourceCodeFormattable formattable)
            {
                m_formattable_obj = formattable;
            }
            else
            {
                m_formattable_obj = null;
            }

            m_editable_obj = value as ICOMSourceCodeEditable;

            if (!IsParsed(m_formattable_obj) && AutoParse)
            {
                ParseSourceCode();
            }

            parseSourceCodeToolStripMenuItem.Enabled = m_formattable_obj is not null && !IsParsed(m_formattable_obj);
            editNamesToolStripMenuItem.Enabled = m_editable_obj is not null;
            Format();
        }
    }

    private void OnHideParsingOptionsChanged()
    {
        parseSourceCodeToolStripMenuItem.Visible = !m_hide_parsing_options;
        autoParseToolStripMenuItem.Visible = !m_hide_parsing_options;
    }

    internal bool AutoParse
    {
        get => autoParseToolStripMenuItem.Checked;
        set => autoParseToolStripMenuItem.Checked = value;
    }

    internal bool HideParsingOptions
    {
        get => m_hide_parsing_options;
        set
        {
            m_hide_parsing_options = value;
            OnHideParsingOptionsChanged();
        }
    }

    private void toolStripMenuItemIDLOutputType_Click(object sender, EventArgs e)
    {
        m_output_type = COMSourceCodeBuilderType.Idl;
        toolStripMenuItemIDLOutputType.Checked = true;
        toolStripMenuItemCppOutputType.Checked = false;
        toolStripMenuItemGenericOutputType.Checked = false;
        Format();
    }

    private void toolStripMenuItemCppOutputType_Click(object sender, EventArgs e)
    {
        m_output_type = COMSourceCodeBuilderType.Cpp;
        toolStripMenuItemIDLOutputType.Checked = false;
        toolStripMenuItemCppOutputType.Checked = true;
        toolStripMenuItemGenericOutputType.Checked = false;
        Format();
    }

    private void toolStripMenuItemGenericOutputType_Click(object sender, EventArgs e)
    {
        m_output_type = COMSourceCodeBuilderType.Generic;
        toolStripMenuItemIDLOutputType.Checked = false;
        toolStripMenuItemCppOutputType.Checked = false;
        toolStripMenuItemGenericOutputType.Checked = true;
        Format();
    }

    private void toolStripMenuItemHideComments_Click(object sender, EventArgs e)
    {
        m_hide_comments = !m_hide_comments;
        toolStripMenuItemHideComments.Checked = m_hide_comments;
        Format();
    }

    private void toolStripMenuItemInterfacesOnly_Click(object sender, EventArgs e)
    {
        m_interfaces_only = !m_interfaces_only;
        toolStripMenuItemInterfacesOnly.Checked = m_interfaces_only;
        Format();
    }

    private void exportToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using SaveFileDialog dlg = new();
        dlg.Filter = "All Files (*.*)|*.*";
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                File.WriteAllText(dlg.FileName, textEditor.Text);
            }
            catch (Exception ex)
            {
                EntryPoint.ShowError(this, ex);
            }
        }
    }

    private void parseSourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ParseSourceCode();
        Format();
    }

    private void ParseSourceCode()
    {
        try
        {
            if (m_formattable_obj is ICOMSourceCodeParsable parsable && !parsable.IsSourceCodeParsed)
            {
                parsable.ParseSourceCode();
                parseSourceCodeToolStripMenuItem.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            m_formattable_obj = new SourceCodeFormattableText($"ERROR: {ex.Message}");
        }
    }

    private void autoParseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (AutoParse)
        {
            SelectedObject = m_selected_obj;
        }
    }

    private void editNamesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (m_editable_obj is not null)
        {
            using var form = new SourceCodeNameEditor(m_editable_obj);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Format();
            }
        }
    }
}
