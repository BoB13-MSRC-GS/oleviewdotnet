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

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NtApiDotNet.Net.Firewall
{
    /// <summary>
    /// Base class for a firewall network event.
    /// </summary>
    public class FirewallNetEvent
    {
        /// <summary>
        /// Type of network event.
        /// </summary>
        public FirewallNetEventType Type { get; }

        /// <summary>
        /// Flags for values set.
        /// </summary>
        public FirewallNetEventFlags Flags { get; }

        /// <summary>
        /// Timestamp of the event.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Type of protocol.
        /// </summary>
        public ProtocolType IPProtocol { get; }

        /// <summary>
        /// Local endpoint.
        /// </summary>
        public IPEndPoint LocalEndpoint { get; }

        /// <summary>
        /// Remote endpoint.
        /// </summary>
        public IPEndPoint RemoteEndpoint { get; }

        /// <summary>
        /// IPv6 Scope ID.
        /// </summary>
        public uint ScopeId { get; }

        /// <summary>
        /// Connection AppID.
        /// </summary>
        public string AppId { get; }

        /// <summary>
        /// Connection user ID.
        /// </summary>
        public Sid UserId { get; }

        /// <summary>
        /// Address family.
        /// </summary>
        public FirewallAddressFamily AddressFamily { get; }

        /// <summary>
        /// Package SID.
        /// </summary>
        public Sid PackageSid { get; }

        private protected FirewallNetEvent(IFwNetEvent net_event)
        {
            Type = net_event.Type;
            var header = net_event.Header;
            Flags = header.flags;
            Timestamp = new LargeInteger(header.timeStamp.ToInt64()).ToDateTime();
            IPProtocol = (ProtocolType)header.ipProtocol;
            LocalEndpoint = FirewallUtils.GetEndpoint(header.ipVersion, header.localAddrV4, header.localAddrV6, header.localPort);
            RemoteEndpoint = FirewallUtils.GetEndpoint(header.ipVersion, header.remoteAddrV4, header.remoteAddrV6, header.remotePort);
            ScopeId = header.scopeId;
            AppId = Encoding.Unicode.GetString(header.appId.ToArray()).TrimEnd('\0');
            UserId = Sid.Parse(header.userId, false).GetResultOrDefault();
            AddressFamily = header.addressFamily;
            PackageSid = Sid.Parse(header.packageSid, false).GetResultOrDefault();
        }

        internal static FirewallNetEvent Create(IFwNetEvent net_event)
        {
            switch (net_event.Type)
            {
                case FirewallNetEventType.IPsecKernelDrop:
                    return new FirewallNetEventIPsecKernelDrop(net_event);
                case FirewallNetEventType.ClassifyDrop:
                    return new FirewallNetEventClassifyDrop(net_event);
                case FirewallNetEventType.ClassifyAllow:
                    return new FirewallNetEventClassifyAllow(net_event);
                case FirewallNetEventType.CapabilityDrop:
                    return new FirewallNetEventCapabilityDrop(net_event);
                case FirewallNetEventType.CapabilityAllow:
                    return new FirewallNetEventCapabilityAllow(net_event);
                case FirewallNetEventType.IkeExtMmFailure:
                    return new FirewallNetEventIkeExtMmFailure(net_event);
                case FirewallNetEventType.IkeExtEmFailure:
                    return new FirewallNetEventIkeExtEmFailure(net_event);
                case FirewallNetEventType.IkeExtQmFailure:
                    return new FirewallNetEventIkeExtQmFailure(net_event);
            }

            return new FirewallNetEvent(net_event);
        }
    }
}
