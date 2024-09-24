﻿//    This file is part of OleViewDotNet.
//    Copyright (C) James Forshaw 2014, 2017
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
using System;
using System.Runtime.InteropServices;

namespace OleViewDotNet.Processes.Types;

[StructLayout(LayoutKind.Sequential)]
internal struct CWinRTLocalSvrClassEntry32Win8 : IWinRTLocalSvrClassEntry
{
    [ChainOffset]
    public SActivatableClassIdHashNode32 _hashNode;
    public int _pNextLSvr; // CClassCache::CWinRTLocalSvrClassEntry*
    public int _pPrevLSvr; // CClassCache::CWinRTLocalSvrClassEntry* 
    public int _pRegChain; // CClassCache::CWinRTLocalSvrClassEntry* 
    public int _pActivationFactoryCallback;
    public uint _dwFlags;
    public int _dwScmReg;
    public int _hApt;
    public Guid _clsid;
    public uint _dwSig;
    public int _cLocks;
    public int _pObjServer; // CObjServer* 
    public int _cookie; // $F1BCC8D2ED72627AE3E1D14940DBB08E* 
    public bool _suspended;
    public int _ulServiceId;
    public int _activatableClassId; // const wchar_t*

    string IWinRTLocalSvrClassEntry.GetActivatableClassId(NtProcess process)
    {
        if (_activatableClassId == 0)
            return string.Empty;
        return process.ReadZString(_activatableClassId);
    }

    IntPtr IWinRTLocalSvrClassEntry.GetActivationFactoryCallback()
    {
        return new IntPtr(_pActivationFactoryCallback);
    }

    Guid IWinRTLocalSvrClassEntry.GetClsid()
    {
        return _clsid;
    }

    string IWinRTLocalSvrClassEntry.GetPackageFullName(NtProcess process)
    {
        return string.Empty;
    }
}
