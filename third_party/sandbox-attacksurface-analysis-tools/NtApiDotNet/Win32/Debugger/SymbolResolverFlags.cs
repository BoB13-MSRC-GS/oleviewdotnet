﻿//  Copyright 2021 Google Inc. All Rights Reserved.
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

// NOTE: This file is a modified version of SymbolResolver.cs from OleViewDotNet
// https://github.com/tyranid/oleviewdotnet. It's been relicensed from GPLv3 by
// the original author James Forshaw to be used under the Apache License for this
// project.

using System;

namespace NtApiDotNet.Win32.Debugger
{
    /// <summary>
    /// Flags for the symbol resolver.
    /// </summary>
    [Flags]
    public enum SymbolResolverFlags
    {
        /// <summary>
        /// No flags.
        /// </summary>
        None = 0,
        /// <summary>
        /// Trace symbol file loading
        /// </summary>
        TraceSymbolLoading = 1,
        /// <summary>
        /// Disable resolving export symbols if no PDB can be found.
        /// </summary>
        DisableExportSymbols = 2,
        /// <summary>
        /// Enable a symbol server fallback. If the copy of dbghelp doesn't have a symsrv.dll
        /// then download from a public symbol URL to a local cache directory during symbol
        /// resolving.
        /// </summary>
        SymSrvFallback = 4,
    }
}
