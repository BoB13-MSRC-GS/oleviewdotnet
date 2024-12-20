﻿//  Copyright 2020 Google Inc. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NtApiDotNet.Win32.Security.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SecureStringMarshalBuffer : IDisposable
    {
        public IntPtr Ptr;

        public SecureStringMarshalBuffer(SecureString s)
        {
            Ptr = s != null ? Marshal.SecureStringToBSTR(s) : IntPtr.Zero;
        }

        public SecureStringMarshalBuffer(string s)
        {
            Ptr = s != null ? Marshal.StringToBSTR(s) : IntPtr.Zero;
        }

        public void Dispose()
        {
            if (Ptr != IntPtr.Zero)
            {
                Marshal.ZeroFreeBSTR(Ptr);
            }
        }
    }
}
