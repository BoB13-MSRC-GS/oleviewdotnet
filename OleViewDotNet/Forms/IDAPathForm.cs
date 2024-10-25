using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OleViewDotNet.Forms
{
    public partial class IDAPathForm: Form
    {
        private Label label1;
        private TextBox textBox1;
        private Button button1;

        public IDAPathForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Failed to find idat64.exe. Please input idat64.exe absolute path directly.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(44, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(404, 21);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IDAPathForm
            // 
            this.ClientSize = new System.Drawing.Size(492, 158);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "IDAPathForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String path = textBox1.Text;
            if (path.EndsWith("idat64.exe") && File.Exists(path))
            {
                ResolveMethod.IDAPath = path;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid idat64.exe path. Please re-input.");
            }
        }
    }
}
