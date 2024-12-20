﻿//    This file is part of OleViewDotNet.
//    Copyright (C) James Forshaw 2014, 2016
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

using OleViewDotNet.Interop;
using OleViewDotNet.TypeLib.Instance;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace OleViewDotNet.TypeLib;

/// <summary>
/// Class to represent a type library reference.
/// </summary>
public class COMTypeLibReference
{
    #region Private Members
    private protected readonly COMTypeDocumentation _doc;
    private protected readonly TYPELIBATTR _attr;
    private readonly Lazy<COMTypeLib> _parsed;
    #endregion

    #region Internal Members
    internal COMTypeLibReference(COMTypeDocumentation doc, TYPELIBATTR attr)
    {
        _doc = doc;
        _attr = attr;
        _parsed = new(() => COMTypeLib.FromRegistered(TypeLibId, Version, Locale));
    }
    #endregion

    #region Public Properties
    public string Name => _doc.Name ?? string.Empty;
    public string DocString => _doc.DocString ?? string.Empty;
    public int HelpContext => _doc.HelpContext;
    public string HelpFile => _doc.HelpFile ?? string.Empty;
    public Guid TypeLibId => _attr.guid;
    public COMVersion Version => new(_attr.wMajorVerNum, _attr.wMinorVerNum);
    public SYSKIND SysKind => _attr.syskind;
    public int Locale => _attr.lcid;
    public LIBFLAGS Flags => _attr.wLibFlags;
    #endregion

    #region Public Methods
    public COMTypeLib Parse()
    {
        if (this is COMTypeLib ret)
        {
            return ret;
        }
        return _parsed.Value;
    }

    public override string ToString()
    {
        return $"{Name} - {Version}";
    }
    #endregion
}
