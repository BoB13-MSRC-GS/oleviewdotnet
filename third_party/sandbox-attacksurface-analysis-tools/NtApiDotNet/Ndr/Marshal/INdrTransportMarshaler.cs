﻿//  Copyright 2019 Google Inc. All Rights Reserved.
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

namespace NtApiDotNet.Ndr.Marshal
{
    /// <summary>
    /// Interface to implement additional transport specific marshaling.
    /// </summary>
    public interface INdrTransportMarshaler
    {
        /// <summary>
        /// Marshal a COM object.
        /// </summary>
        /// <param name="obj">The object to marshal.</param>
        /// <param name="iid">The IID specified by the call.</param>
        /// <returns>The marshaled COM object.</returns>
        NdrInterfacePointer MarshalComObject(INdrComObject obj, Guid iid);

        /// <summary>
        /// Unmarshal a COM object.
        /// </summary>
        /// <param name="intf">The interface pointer to unmarshal.</param>
        /// <returns>The unmarshaled COM object.</returns>
        INdrComObject UnmarshalComObject(NdrInterfacePointer intf);

        /// <summary>
        /// Implements a method to query for another COM interface.
        /// </summary>
        /// <param name="obj">The NDR COM object.</param>
        /// <param name="iid">The IID for the interface.</param>
        /// <returns>The queried COM interface.</returns>
        INdrComObject QueryComObject(INdrComObject obj, Guid iid);
    }
}
