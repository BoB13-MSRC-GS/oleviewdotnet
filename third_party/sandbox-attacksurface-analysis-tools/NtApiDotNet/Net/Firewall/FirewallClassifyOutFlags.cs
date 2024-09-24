﻿//  Copyright 2021 Google LLC. All Rights Reserved.
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

using NtApiDotNet.Utilities.Reflection;
using System;

namespace NtApiDotNet.Net.Firewall
{
    /// <summary>
    /// Flags for classify output.
    /// </summary>
    [Flags]
    public enum FirewallClassifyOutFlags
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        None = 0,
        [SDKName("FWPS_CLASSIFY_OUT_FLAG_ABSORB")]
        Absorb                      = 0x00000001,
        [SDKName("FWPS_CLASSIFY_OUT_FLAG_BUFFER_LIMIT_REACHED")]
        BufferLimitReached        = 0x00000002,
        [SDKName("FWPS_CLASSIFY_OUT_FLAG_NO_MORE_DATA")]
        NoMoreData                = 0x00000004,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
