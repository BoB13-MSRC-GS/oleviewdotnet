//  Copyright 2021 Google LLC. All Rights Reserved.
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

namespace NtApiDotNet.Net.Firewall
{
    /// <summary>
    /// Guids for pre-defined firewall conditions.
    /// </summary>
    public static class FirewallConditionGuids
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        // f6e63dce-1f4b-4c6b-b6ef-1165e71f8ee7
        public static Guid FWPM_CONDITION_INTERFACE_MAC_ADDRESS = new Guid(0xf6e63dce, 0x1f4b, 0x4c6b, 0xb6, 0xef, 0x11, 0x65, 0xe7, 0x1f, 0x8e, 0xe7);
        // d999e981-7948-4c83-b742-c84e3b678f8f
        public static Guid FWPM_CONDITION_MAC_LOCAL_ADDRESS = new Guid(0xd999e981, 0x7948, 0x4c83, 0xb7, 0x42, 0xc8, 0x4e, 0x3b, 0x67, 0x8f, 0x8f);
        // 408f2ed4-3a70-4b4d-92a6-415ac20e2f12
        public static Guid FWPM_CONDITION_MAC_REMOTE_ADDRESS = new Guid(0x408f2ed4, 0x3a70, 0x4b4d, 0x92, 0xa6, 0x41, 0x5a, 0xc2, 0x0e, 0x2f, 0x12);
        // fd08948d-a219-4d52-bb98-1a5540ee7b4e
        public static Guid FWPM_CONDITION_ETHER_TYPE = new Guid(0xfd08948d, 0xa219, 0x4d52, 0xbb, 0x98, 0x1a, 0x55, 0x40, 0xee, 0x7b, 0x4e);
        // 938eab21-3618-4e64-9ca5-2141ebda1ca2
        public static Guid FWPM_CONDITION_VLAN_ID = new Guid(0x938eab21, 0x3618, 0x4e64, 0x9c, 0xa5, 0x21, 0x41, 0xeb, 0xda, 0x1c, 0xa2);
        // dc04843c-79e6-4e44-a025-65b9bb0f9f94
        public static Guid FWPM_CONDITION_VSWITCH_TENANT_NETWORK_ID = new Guid(0xdc04843c, 0x79e6, 0x4e44, 0xa0, 0x25, 0x65, 0xb9, 0xbb, 0x0f, 0x9f, 0x94);
        // db7bb42b-2dac-4cd4-a59a-e0bdce1e6834
        public static Guid FWPM_CONDITION_NDIS_PORT = new Guid(0xdb7bb42b, 0x2dac, 0x4cd4, 0xa5, 0x9a, 0xe0, 0xbd, 0xce, 0x1e, 0x68, 0x34);
        // cb31cef1-791d-473b-89d1-61c5984304a0
        public static Guid FWPM_CONDITION_NDIS_MEDIA_TYPE = new Guid(0xcb31cef1, 0x791d, 0x473b, 0x89, 0xd1, 0x61, 0xc5, 0x98, 0x43, 0x04, 0xa0);
        // 34c79823-c229-44f2-b83c-74020882ae77
        public static Guid FWPM_CONDITION_NDIS_PHYSICAL_MEDIA_TYPE = new Guid(0x34c79823, 0xc229, 0x44f2, 0xb8, 0x3c, 0x74, 0x02, 0x08, 0x82, 0xae, 0x77);
        // 7bc43cbf-37ba-45f1-b74a-82ff518eeb10
        public static Guid FWPM_CONDITION_L2_FLAGS = new Guid(0x7bc43cbf, 0x37ba, 0x45f1, 0xb7, 0x4a, 0x82, 0xff, 0x51, 0x8e, 0xeb, 0x10);
        // cc31355c-3073-4ffb-a14f-79415cb1ead1
        public static Guid FWPM_CONDITION_MAC_LOCAL_ADDRESS_TYPE = new Guid(0xcc31355c, 0x3073, 0x4ffb, 0xa1, 0x4f, 0x79, 0x41, 0x5c, 0xb1, 0xea, 0xd1);
        // 027fedb4-f1c1-4030-b564-ee777fd867ea
        public static Guid FWPM_CONDITION_MAC_REMOTE_ADDRESS_TYPE = new Guid(0x027fedb4, 0xf1c1, 0x4030, 0xb5, 0x64, 0xee, 0x77, 0x7f, 0xd8, 0x67, 0xea);
        // 71bc78fa-f17c-4997-a602-6abb261f351c
        public static Guid FWPM_CONDITION_ALE_PACKAGE_ID = new Guid(0x71bc78fa, 0xf17c, 0x4997, 0xa6, 0x02, 0x6a, 0xbb, 0x26, 0x1f, 0x35, 0x1c);
        // 7b795451-f1f6-4d05-b7cb-21779d802336
        public static Guid FWPM_CONDITION_MAC_SOURCE_ADDRESS = new Guid(0x7b795451, 0xf1f6, 0x4d05, 0xb7, 0xcb, 0x21, 0x77, 0x9d, 0x80, 0x23, 0x36);
        // 04ea2a93-858c-4027-b613-b43180c7859e
        public static Guid FWPM_CONDITION_MAC_DESTINATION_ADDRESS = new Guid(0x04ea2a93, 0x858c, 0x4027, 0xb6, 0x13, 0xb4, 0x31, 0x80, 0xc7, 0x85, 0x9e);
        // 5c1b72e4-299e-4437-a298-bc3f014b3dc2
        public static Guid FWPM_CONDITION_MAC_SOURCE_ADDRESS_TYPE = new Guid(0x5c1b72e4, 0x299e, 0x4437, 0xa2, 0x98, 0xbc, 0x3f, 0x01, 0x4b, 0x3d, 0xc2);
        // ae052932-ef42-4e99-b129-f3b3139e34f7
        public static Guid FWPM_CONDITION_MAC_DESTINATION_ADDRESS_TYPE = new Guid(0xae052932, 0xef42, 0x4e99, 0xb1, 0x29, 0xf3, 0xb3, 0x13, 0x9e, 0x34, 0xf7);
        // a6afef91-3df4-4730-a214-f5426aebf821
        public static Guid FWPM_CONDITION_IP_SOURCE_PORT = new Guid(0xa6afef91, 0x3df4, 0x4730, 0xa2, 0x14, 0xf5, 0x42, 0x6a, 0xeb, 0xf8, 0x21);
        // ce6def45-60fb-4a7b-a304-af30a117000e
        public static Guid FWPM_CONDITION_IP_DESTINATION_PORT = new Guid(0xce6def45, 0x60fb, 0x4a7b, 0xa3, 0x04, 0xaf, 0x30, 0xa1, 0x17, 0x00, 0x0e);
        // c4a414ba-437b-4de6-9946-d99c1b95b312
        public static Guid FWPM_CONDITION_VSWITCH_ID = new Guid(0xc4a414ba, 0x437b, 0x4de6, 0x99, 0x46, 0xd9, 0x9c, 0x1b, 0x95, 0xb3, 0x12);
        // 11d48b4b-e77a-40b4-9155-392c906c2608
        public static Guid FWPM_CONDITION_VSWITCH_NETWORK_TYPE = new Guid(0x11d48b4b, 0xe77a, 0x40b4, 0x91, 0x55, 0x39, 0x2c, 0x90, 0x6c, 0x26, 0x08);
        // 7f4ef24b-b2c1-4938-ba33-a1ecbed512ba
        public static Guid FWPM_CONDITION_VSWITCH_SOURCE_INTERFACE_ID = new Guid(0x7f4ef24b, 0xb2c1, 0x4938, 0xba, 0x33, 0xa1, 0xec, 0xbe, 0xd5, 0x12, 0xba);
        // 8ed48be4-c926-49f6-a4f6-ef3030e3fc16
        public static Guid FWPM_CONDITION_VSWITCH_DESTINATION_INTERFACE_ID = new Guid(0x8ed48be4, 0xc926, 0x49f6, 0xa4, 0xf6, 0xef, 0x30, 0x30, 0xe3, 0xfc, 0x16);
        // 9c2a9ec2-9fc6-42bc-bdd8-406d4da0be64
        public static Guid FWPM_CONDITION_VSWITCH_SOURCE_VM_ID = new Guid(0x9c2a9ec2, 0x9fc6, 0x42bc, 0xbd, 0xd8, 0x40, 0x6d, 0x4d, 0xa0, 0xbe, 0x64);
        // 6106aace-4de1-4c84-9671-3637f8bcf731
        public static Guid FWPM_CONDITION_VSWITCH_DESTINATION_VM_ID = new Guid(0x6106aace, 0x4de1, 0x4c84, 0x96, 0x71, 0x36, 0x37, 0xf8, 0xbc, 0xf7, 0x31);
        // e6b040a2-edaf-4c36-908b-f2f58ae43807
        public static Guid FWPM_CONDITION_VSWITCH_SOURCE_INTERFACE_TYPE = new Guid(0xe6b040a2, 0xedaf, 0x4c36, 0x90, 0x8b, 0xf2, 0xf5, 0x8a, 0xe4, 0x38, 0x07);
        // fa9b3f06-2f1a-4c57-9e68-a7098b28dbfe
        public static Guid FWPM_CONDITION_VSWITCH_DESTINATION_INTERFACE_TYPE = new Guid(0xfa9b3f06, 0x2f1a, 0x4c57, 0x9e, 0x68, 0xa7, 0x09, 0x8b, 0x28, 0xdb, 0xfe);
        // 37a57699-5883-4963-92b8-3e704688b0ad
        public static Guid FWPM_CONDITION_ALE_SECURITY_ATTRIBUTE_FQBN_VALUE = new Guid(0x37a57699, 0x5883, 0x4963, 0x92, 0xb8, 0x3e, 0x70, 0x46, 0x88, 0xb0, 0xad);
        // 37a57700-5884-4964-92b8-3e704688b0ad
        public static Guid FWPM_CONDITION_IPSEC_SECURITY_REALM_ID = new Guid(0x37a57700, 0x5884, 0x4964, 0x92, 0xb8, 0x3e, 0x70, 0x46, 0x88, 0xb0, 0xad);
        // b1277b9a-b781-40fc-9671-e5f1b989f34e
        public static Guid FWPM_CONDITION_ALE_EFFECTIVE_NAME = new Guid(0xb1277b9a, 0xb781, 0x40fc, 0x96, 0x71, 0xe5, 0xf1, 0xb9, 0x89, 0xf3, 0x4e);
        // d9ee00de-c1ef-4617-bfe3-ffd8f5a08957
        public static Guid FWPM_CONDITION_IP_LOCAL_ADDRESS = new Guid(0xd9ee00de, 0xc1ef, 0x4617, 0xbf, 0xe3, 0xff, 0xd8, 0xf5, 0xa0, 0x89, 0x57);
        // b235ae9a-1d64-49b8-a44c-5ff3d9095045
        public static Guid FWPM_CONDITION_IP_REMOTE_ADDRESS = new Guid(0xb235ae9a, 0x1d64, 0x49b8, 0xa4, 0x4c, 0x5f, 0xf3, 0xd9, 0x09, 0x50, 0x45);
        // ae96897e-2e94-4bc9-b313-b27ee80e574d
        public static Guid FWPM_CONDITION_IP_SOURCE_ADDRESS = new Guid(0xae96897e, 0x2e94, 0x4bc9, 0xb3, 0x13, 0xb2, 0x7e, 0xe8, 0x0e, 0x57, 0x4d);
        // 2d79133b-b390-45c6-8699-acaceaafed33
        public static Guid FWPM_CONDITION_IP_DESTINATION_ADDRESS = new Guid(0x2d79133b, 0xb390, 0x45c6, 0x86, 0x99, 0xac, 0xac, 0xea, 0xaf, 0xed, 0x33);
        // 6ec7f6c4-376b-45d7-9e9c-d337cedcd237
        public static Guid FWPM_CONDITION_IP_LOCAL_ADDRESS_TYPE = new Guid(0x6ec7f6c4, 0x376b, 0x45d7, 0x9e, 0x9c, 0xd3, 0x37, 0xce, 0xdc, 0xd2, 0x37);
        // 1ec1b7c9-4eea-4f5e-b9ef-76beaaaf17ee
        public static Guid FWPM_CONDITION_IP_DESTINATION_ADDRESS_TYPE = new Guid(0x1ec1b7c9, 0x4eea, 0x4f5e, 0xb9, 0xef, 0x76, 0xbe, 0xaa, 0xaf, 0x17, 0xee);
        // 16ebc3df-957a-452e-a1fc-3d2ff6a730ba
        public static Guid FWPM_CONDITION_BITMAP_IP_LOCAL_ADDRESS = new Guid(0x16ebc3df, 0x957a, 0x452e, 0xa1, 0xfc, 0x3d, 0x2f, 0xf6, 0xa7, 0x30, 0xba);
        // 9f90a920-c3b5-4569-ba31-8bd3910dc656
        public static Guid FWPM_CONDITION_BITMAP_IP_LOCAL_PORT = new Guid(0x9f90a920, 0xc3b5, 0x4569, 0xba, 0x31, 0x8b, 0xd3, 0x91, 0x0d, 0xc6, 0x56);
        // 33f00e25-8eec-4531-a005-41b911f62452
        public static Guid FWPM_CONDITION_BITMAP_IP_REMOTE_ADDRESS = new Guid(0x33f00e25, 0x8eec, 0x4531, 0xa0, 0x05, 0x41, 0xb9, 0x11, 0xf6, 0x24, 0x52);
        // 2663d549-aaf2-46a2-8666-1e7667f86985
        public static Guid FWPM_CONDITION_BITMAP_IP_REMOTE_PORT = new Guid(0x2663d549, 0xaaf2, 0x46a2, 0x86, 0x66, 0x1e, 0x76, 0x67, 0xf8, 0x69, 0x85);
        // eabe448a-a711-4d64-85b7-3f76b65299c7
        public static Guid FWPM_CONDITION_IP_NEXTHOP_ADDRESS = new Guid(0xeabe448a, 0xa711, 0x4d64, 0x85, 0xb7, 0x3f, 0x76, 0xb6, 0x52, 0x99, 0xc7);
        // 0f36514c-3226-4a81-a214-2d518b04d08a
        public static Guid FWPM_CONDITION_BITMAP_INDEX_KEY = new Guid(0x0f36514c, 0x3226, 0x4a81, 0xa2, 0x14, 0x2d, 0x51, 0x8b, 0x04, 0xd0, 0x8a);
        // 4cd62a49-59c3-4969-b7f3-bda5d32890a4
        public static Guid FWPM_CONDITION_IP_LOCAL_INTERFACE = new Guid(0x4cd62a49, 0x59c3, 0x4969, 0xb7, 0xf3, 0xbd, 0xa5, 0xd3, 0x28, 0x90, 0xa4);
        // 618a9b6d-386b-4136-ad6e-b51587cfb1cd
        public static Guid FWPM_CONDITION_IP_ARRIVAL_INTERFACE = new Guid(0x618a9b6d, 0x386b, 0x4136, 0xad, 0x6e, 0xb5, 0x15, 0x87, 0xcf, 0xb1, 0xcd);
        // 89f990de-e798-4e6d-ab76-7c9558292e6f
        public static Guid FWPM_CONDITION_ARRIVAL_INTERFACE_TYPE = new Guid(0x89f990de, 0xe798, 0x4e6d, 0xab, 0x76, 0x7c, 0x95, 0x58, 0x29, 0x2e, 0x6f);
        // 511166dc-7a8c-4aa7-b533-95ab59fb0340
        public static Guid FWPM_CONDITION_ARRIVAL_TUNNEL_TYPE = new Guid(0x511166dc, 0x7a8c, 0x4aa7, 0xb5, 0x33, 0x95, 0xab, 0x59, 0xfb, 0x03, 0x40);
        // cc088db3-1792-4a71-b0f9-037d21cd828b
        public static Guid FWPM_CONDITION_ARRIVAL_INTERFACE_INDEX = new Guid(0xcc088db3, 0x1792, 0x4a71, 0xb0, 0xf9, 0x03, 0x7d, 0x21, 0xcd, 0x82, 0x8b);
        // ef8a6122-0577-45a7-9aaf-825fbeb4fb95
        public static Guid FWPM_CONDITION_NEXTHOP_SUB_INTERFACE_INDEX = new Guid(0xef8a6122, 0x0577, 0x45a7, 0x9a, 0xaf, 0x82, 0x5f, 0xbe, 0xb4, 0xfb, 0x95);
        // 93ae8f5b-7f6f-4719-98c8-14e97429ef04
        public static Guid FWPM_CONDITION_IP_NEXTHOP_INTERFACE = new Guid(0x93ae8f5b, 0x7f6f, 0x4719, 0x98, 0xc8, 0x14, 0xe9, 0x74, 0x29, 0xef, 0x04);
        // 97537c6c-d9a3-4767-a381-e942675cd920
        public static Guid FWPM_CONDITION_NEXTHOP_INTERFACE_TYPE = new Guid(0x97537c6c, 0xd9a3, 0x4767, 0xa3, 0x81, 0xe9, 0x42, 0x67, 0x5c, 0xd9, 0x20);
        // 72b1a111-987b-4720-99dd-c7c576fa2d4c
        public static Guid FWPM_CONDITION_NEXTHOP_TUNNEL_TYPE = new Guid(0x72b1a111, 0x987b, 0x4720, 0x99, 0xdd, 0xc7, 0xc5, 0x76, 0xfa, 0x2d, 0x4c);
        // 138e6888-7ab8-4d65-9ee8-0591bcf6a494
        public static Guid FWPM_CONDITION_NEXTHOP_INTERFACE_INDEX = new Guid(0x138e6888, 0x7ab8, 0x4d65, 0x9e, 0xe8, 0x05, 0x91, 0xbc, 0xf6, 0xa4, 0x94);
        // 46ea1551-2255-492b-8019-aabeee349f40
        public static Guid FWPM_CONDITION_ORIGINAL_PROFILE_ID = new Guid(0x46ea1551, 0x2255, 0x492b, 0x80, 0x19, 0xaa, 0xbe, 0xee, 0x34, 0x9f, 0x40);
        // ab3033c9-c0e3-4759-937d-5758c65d4ae3
        public static Guid FWPM_CONDITION_CURRENT_PROFILE_ID = new Guid(0xab3033c9, 0xc0e3, 0x4759, 0x93, 0x7d, 0x57, 0x58, 0xc6, 0x5d, 0x4a, 0xe3);
        // 4ebf7562-9f18-4d06-9941-a7a625744d71
        public static Guid FWPM_CONDITION_LOCAL_INTERFACE_PROFILE_ID = new Guid(0x4ebf7562, 0x9f18, 0x4d06, 0x99, 0x41, 0xa7, 0xa6, 0x25, 0x74, 0x4d, 0x71);
        // cdfe6aab-c083-4142-8679-c08f95329c61
        public static Guid FWPM_CONDITION_ARRIVAL_INTERFACE_PROFILE_ID = new Guid(0xcdfe6aab, 0xc083, 0x4142, 0x86, 0x79, 0xc0, 0x8f, 0x95, 0x32, 0x9c, 0x61);
        // d7ff9a56-cdaa-472b-84db-d23963c1d1bf
        public static Guid FWPM_CONDITION_NEXTHOP_INTERFACE_PROFILE_ID = new Guid(0xd7ff9a56, 0xcdaa, 0x472b, 0x84, 0xdb, 0xd2, 0x39, 0x63, 0xc1, 0xd1, 0xbf);
        // 11205e8c-11ae-457a-8a44-477026dd764a
        public static Guid FWPM_CONDITION_REAUTHORIZE_REASON = new Guid(0x11205e8c, 0x11ae, 0x457a, 0x8a, 0x44, 0x47, 0x70, 0x26, 0xdd, 0x76, 0x4a);
        // 076dfdbe-c56c-4f72-ae8a-2cfe7e5c8286
        public static Guid FWPM_CONDITION_ORIGINAL_ICMP_TYPE = new Guid(0x076dfdbe, 0xc56c, 0x4f72, 0xae, 0x8a, 0x2c, 0xfe, 0x7e, 0x5c, 0x82, 0x86);
        // da50d5c8-fa0d-4c89-b032-6e62136d1e96
        public static Guid FWPM_CONDITION_IP_PHYSICAL_ARRIVAL_INTERFACE = new Guid(0xda50d5c8, 0xfa0d, 0x4c89, 0xb0, 0x32, 0x6e, 0x62, 0x13, 0x6d, 0x1e, 0x96);
        // f09bd5ce-5150-48be-b098-c25152fb1f92
        public static Guid FWPM_CONDITION_IP_PHYSICAL_NEXTHOP_INTERFACE = new Guid(0xf09bd5ce, 0x5150, 0x48be, 0xb0, 0x98, 0xc2, 0x51, 0x52, 0xfb, 0x1f, 0x92);
        // cce68d5e-053b-43a8-9a6f-33384c28e4f6
        public static Guid FWPM_CONDITION_INTERFACE_QUARANTINE_EPOCH = new Guid(0xcce68d5e, 0x053b, 0x43a8, 0x9a, 0x6f, 0x33, 0x38, 0x4c, 0x28, 0xe4, 0xf6);
        // daf8cd14-e09e-4c93-a5ae-c5c13b73ffca
        public static Guid FWPM_CONDITION_LOCAL_INTERFACE_TYPE = new Guid(0xdaf8cd14, 0xe09e, 0x4c93, 0xa5, 0xae, 0xc5, 0xc1, 0x3b, 0x73, 0xff, 0xca);
        // 77a40437-8779-4868-a261-f5a902f1c0cd
        public static Guid FWPM_LOCAL_CONDITION_TUNNEL_TYPE = new Guid(0x77a40437, 0x8779, 0x4868, 0xa2, 0x61, 0xf5, 0xa9, 0x02, 0xf1, 0xc0, 0xcd);
        // 1076b8a5-6323-4c5e-9810-e8d3fc9e6136
        public static Guid FWPM_CONDITION_IP_FORWARD_INTERFACE = new Guid(0x1076b8a5, 0x6323, 0x4c5e, 0x98, 0x10, 0xe8, 0xd3, 0xfc, 0x9e, 0x61, 0x36);
        // 3971ef2b-623e-4f9a-8cb1-6e79b806b9a7
        public static Guid FWPM_CONDITION_IP_PROTOCOL = new Guid(0x3971ef2b, 0x623e, 0x4f9a, 0x8c, 0xb1, 0x6e, 0x79, 0xb8, 0x06, 0xb9, 0xa7);
        // 0c1ba1af-5765-453f-af22-a8f791ac775b
        public static Guid FWPM_CONDITION_IP_LOCAL_PORT = new Guid(0x0c1ba1af, 0x5765, 0x453f, 0xaf, 0x22, 0xa8, 0xf7, 0x91, 0xac, 0x77, 0x5b);
        // c35a604d-d22b-4e1a-91b4-68f674ee674b
        public static Guid FWPM_CONDITION_IP_REMOTE_PORT = new Guid(0xc35a604d, 0xd22b, 0x4e1a, 0x91, 0xb4, 0x68, 0xf6, 0x74, 0xee, 0x67, 0x4b);
        // 4672a468-8a0a-4202-abb4-849e92e66809
        public static Guid FWPM_CONDITION_EMBEDDED_LOCAL_ADDRESS_TYPE = new Guid(0x4672a468, 0x8a0a, 0x4202, 0xab, 0xb4, 0x84, 0x9e, 0x92, 0xe6, 0x68, 0x09);
        // 77ee4b39-3273-4671-b63b-ab6feb66eeb6
        public static Guid FWPM_CONDITION_EMBEDDED_REMOTE_ADDRESS = new Guid(0x77ee4b39, 0x3273, 0x4671, 0xb6, 0x3b, 0xab, 0x6f, 0xeb, 0x66, 0xee, 0xb6);
        // 07784107-a29e-4c7b-9ec7-29c44afafdbc
        public static Guid FWPM_CONDITION_EMBEDDED_PROTOCOL = new Guid(0x07784107, 0xa29e, 0x4c7b, 0x9e, 0xc7, 0x29, 0xc4, 0x4a, 0xfa, 0xfd, 0xbc);
        // bfca394d-acdb-484e-b8e6-2aff79757345
        public static Guid FWPM_CONDITION_EMBEDDED_LOCAL_PORT = new Guid(0xbfca394d, 0xacdb, 0x484e, 0xb8, 0xe6, 0x2a, 0xff, 0x79, 0x75, 0x73, 0x45);
        // cae4d6a1-2968-40ed-a4ce-547160dda88d
        public static Guid FWPM_CONDITION_EMBEDDED_REMOTE_PORT = new Guid(0xcae4d6a1, 0x2968, 0x40ed, 0xa4, 0xce, 0x54, 0x71, 0x60, 0xdd, 0xa8, 0x8d);
        // 632ce23b-5167-435c-86d7-e903684aa80c
        public static Guid FWPM_CONDITION_FLAGS = new Guid(0x632ce23b, 0x5167, 0x435c, 0x86, 0xd7, 0xe9, 0x03, 0x68, 0x4a, 0xa8, 0x0c);
        // 8784c146-ca97-44d6-9fd1-19fb1840cbf7
        public static Guid FWPM_CONDITION_DIRECTION = new Guid(0x8784c146, 0xca97, 0x44d6, 0x9f, 0xd1, 0x19, 0xfb, 0x18, 0x40, 0xcb, 0xf7);
        // 667fd755-d695-434a-8af5-d3835a1259bc
        public static Guid FWPM_CONDITION_INTERFACE_INDEX = new Guid(0x667fd755, 0xd695, 0x434a, 0x8a, 0xf5, 0xd3, 0x83, 0x5a, 0x12, 0x59, 0xbc);
        // 0cd42473-d621-4be3-ae8c-72a348d283e1
        public static Guid FWPM_CONDITION_SUB_INTERFACE_INDEX = new Guid(0x0cd42473, 0xd621, 0x4be3, 0xae, 0x8c, 0x72, 0xa3, 0x48, 0xd2, 0x83, 0xe1);
        // 2311334d-c92d-45bf-9496-edf447820e2d
        public static Guid FWPM_CONDITION_SOURCE_INTERFACE_INDEX = new Guid(0x2311334d, 0xc92d, 0x45bf, 0x94, 0x96, 0xed, 0xf4, 0x47, 0x82, 0x0e, 0x2d);
        // 055edd9d-acd2-4361-8dab-f9525d97662f
        public static Guid FWPM_CONDITION_SOURCE_SUB_INTERFACE_INDEX = new Guid(0x055edd9d, 0xacd2, 0x4361, 0x8d, 0xab, 0xf9, 0x52, 0x5d, 0x97, 0x66, 0x2f);
        // 35cf6522-4139-45ee-a0d5-67b80949d879
        public static Guid FWPM_CONDITION_DESTINATION_INTERFACE_INDEX = new Guid(0x35cf6522, 0x4139, 0x45ee, 0xa0, 0xd5, 0x67, 0xb8, 0x09, 0x49, 0xd8, 0x79);
        // 2b7d4399-d4c7-4738-a2f5-e994b43da388
        public static Guid FWPM_CONDITION_DESTINATION_SUB_INTERFACE_INDEX = new Guid(0x2b7d4399, 0xd4c7, 0x4738, 0xa2, 0xf5, 0xe9, 0x94, 0xb4, 0x3d, 0xa3, 0x88);
        // d78e1e87-8644-4ea5-9437-d809ecefc971
        public static Guid FWPM_CONDITION_ALE_APP_ID = new Guid(0xd78e1e87, 0x8644, 0x4ea5, 0x94, 0x37, 0xd8, 0x09, 0xec, 0xef, 0xc9, 0x71);
        // 0e6cd086-e1fb-4212-842f-8a9f993fb3f6
        public static Guid FWPM_CONDITION_ALE_ORIGINAL_APP_ID = new Guid(0x0e6cd086, 0xe1fb, 0x4212, 0x84, 0x2f, 0x8a, 0x9f, 0x99, 0x3f, 0xb3, 0xf6);
        // af043a0a-b34d-4f86-979c-c90371af6e66
        public static Guid FWPM_CONDITION_ALE_USER_ID = new Guid(0xaf043a0a, 0xb34d, 0x4f86, 0x97, 0x9c, 0xc9, 0x03, 0x71, 0xaf, 0x6e, 0x66);
        // f63073b7-0189-4ab0-95a4-6123cbfab862
        public static Guid FWPM_CONDITION_ALE_REMOTE_USER_ID = new Guid(0xf63073b7, 0x0189, 0x4ab0, 0x95, 0xa4, 0x61, 0x23, 0xcb, 0xfa, 0xb8, 0x62);
        // 1aa47f51-7f93-4508-a271-81abb00c9cab
        public static Guid FWPM_CONDITION_ALE_REMOTE_MACHINE_ID = new Guid(0x1aa47f51, 0x7f93, 0x4508, 0xa2, 0x71, 0x81, 0xab, 0xb0, 0x0c, 0x9c, 0xab);
        // 1c974776-7182-46e9-afd3-b02910e30334
        public static Guid FWPM_CONDITION_ALE_PROMISCUOUS_MODE = new Guid(0x1c974776, 0x7182, 0x46e9, 0xaf, 0xd3, 0xb0, 0x29, 0x10, 0xe3, 0x03, 0x34);
        // b9f4e088-cb98-4efb-a2c7-ad07332643db
        public static Guid FWPM_CONDITION_ALE_SIO_FIREWALL_SYSTEM_PORT = new Guid(0xb9f4e088, 0xcb98, 0x4efb, 0xa2, 0xc7, 0xad, 0x07, 0x33, 0x26, 0x43, 0xdb);
        // b482d227-1979-4a98-8044-18bbe6237542
        public static Guid FWPM_CONDITION_ALE_REAUTH_REASON = new Guid(0xb482d227, 0x1979, 0x4a98, 0x80, 0x44, 0x18, 0xbb, 0xe6, 0x23, 0x75, 0x42);
        // 46275a9d-c03f-4d77-b784-1c57f4d02753
        public static Guid FWPM_CONDITION_ALE_NAP_CONTEXT = new Guid(0x46275a9d, 0xc03f, 0x4d77, 0xb7, 0x84, 0x1c, 0x57, 0xf4, 0xd0, 0x27, 0x53);
        // 35d0ea0e-15ca-492b-900e-97fd46352cce
        public static Guid FWPM_CONDITION_KM_AUTH_NAP_CONTEXT = new Guid(0x35d0ea0e, 0x15ca, 0x492b, 0x90, 0x0e, 0x97, 0xfd, 0x46, 0x35, 0x2c, 0xce);
        // 9bf0ee66-06c9-41b9-84da-288cb43af51f
        public static Guid FWPM_CONDITION_REMOTE_USER_TOKEN = new Guid(0x9bf0ee66, 0x06c9, 0x41b9, 0x84, 0xda, 0x28, 0x8c, 0xb4, 0x3a, 0xf5, 0x1f);
        // 7c9c7d9f-0075-4d35-a0d1-8311c4cf6af1
        public static Guid FWPM_CONDITION_RPC_IF_UUID = new Guid(0x7c9c7d9f, 0x0075, 0x4d35, 0xa0, 0xd1, 0x83, 0x11, 0xc4, 0xcf, 0x6a, 0xf1);
        // eabfd9b7-1262-4a2e-adaa-5f96f6fe326d
        public static Guid FWPM_CONDITION_RPC_IF_VERSION = new Guid(0xeabfd9b7, 0x1262, 0x4a2e, 0xad, 0xaa, 0x5f, 0x96, 0xf6, 0xfe, 0x32, 0x6d);
        // 238a8a32-3199-467d-871c-272621ab3896
        public static Guid FWPM_CONDITION_RPC_IF_FLAG = new Guid(0x238a8a32, 0x3199, 0x467d, 0x87, 0x1c, 0x27, 0x26, 0x21, 0xab, 0x38, 0x96);
        // ff2e7b4d-3112-4770-b636-4d24ae3a6af2
        public static Guid FWPM_CONDITION_DCOM_APP_ID = new Guid(0xff2e7b4d, 0x3112, 0x4770, 0xb6, 0x36, 0x4d, 0x24, 0xae, 0x3a, 0x6a, 0xf2);
        // d024de4d-deaa-4317-9c85-e40ef6e140c3
        public static Guid FWPM_CONDITION_IMAGE_NAME = new Guid(0xd024de4d, 0xdeaa, 0x4317, 0x9c, 0x85, 0xe4, 0x0e, 0xf6, 0xe1, 0x40, 0xc3);
        // 2717bc74-3a35-4ce7-b7ef-c838fabdec45
        public static Guid FWPM_CONDITION_RPC_PROTOCOL = new Guid(0x2717bc74, 0x3a35, 0x4ce7, 0xb7, 0xef, 0xc8, 0x38, 0xfa, 0xbd, 0xec, 0x45);
        // daba74ab-0d67-43e7-986e-75b84f82f594
        public static Guid FWPM_CONDITION_RPC_AUTH_TYPE = new Guid(0xdaba74ab, 0x0d67, 0x43e7, 0x98, 0x6e, 0x75, 0xb8, 0x4f, 0x82, 0xf5, 0x94);
        // e5a0aed5-59ac-46ea-be05-a5f05ecf446e
        public static Guid FWPM_CONDITION_RPC_AUTH_LEVEL = new Guid(0xe5a0aed5, 0x59ac, 0x46ea, 0xbe, 0x05, 0xa5, 0xf0, 0x5e, 0xcf, 0x44, 0x6e);
        // 0d306ef0-e974-4f74-b5c7-591b0da7d562
        public static Guid FWPM_CONDITION_SEC_ENCRYPT_ALGORITHM = new Guid(0x0d306ef0, 0xe974, 0x4f74, 0xb5, 0xc7, 0x59, 0x1b, 0x0d, 0xa7, 0xd5, 0x62);
        // 4772183b-ccf8-4aeb-bce1-c6c6161c8fe4
        public static Guid FWPM_CONDITION_SEC_KEY_SIZE = new Guid(0x4772183b, 0xccf8, 0x4aeb, 0xbc, 0xe1, 0xc6, 0xc6, 0x16, 0x1c, 0x8f, 0xe4);
        // 03a629cb-6e52-49f8-9c41-5709633c09cf
        public static Guid FWPM_CONDITION_IP_LOCAL_ADDRESS_V4 = new Guid(0x03a629cb, 0x6e52, 0x49f8, 0x9c, 0x41, 0x57, 0x09, 0x63, 0x3c, 0x09, 0xcf);
        // 2381be84-7524-45b3-a05b-1e637d9c7a6a
        public static Guid FWPM_CONDITION_IP_LOCAL_ADDRESS_V6 = new Guid(0x2381be84, 0x7524, 0x45b3, 0xa0, 0x5b, 0x1e, 0x63, 0x7d, 0x9c, 0x7a, 0x6a);
        // 1bd0741d-e3df-4e24-8634-762046eef6eb
        public static Guid FWPM_CONDITION_PIPE = new Guid(0x1bd0741d, 0xe3df, 0x4e24, 0x86, 0x34, 0x76, 0x20, 0x46, 0xee, 0xf6, 0xeb);
        // 1febb610-3bcc-45e1-bc36-2e067e2cb186
        public static Guid FWPM_CONDITION_IP_REMOTE_ADDRESS_V4 = new Guid(0x1febb610, 0x3bcc, 0x45e1, 0xbc, 0x36, 0x2e, 0x06, 0x7e, 0x2c, 0xb1, 0x86);
        // 246e1d8c-8bee-4018-9b98-31d4582f3361
        public static Guid FWPM_CONDITION_IP_REMOTE_ADDRESS_V6 = new Guid(0x246e1d8c, 0x8bee, 0x4018, 0x9b, 0x98, 0x31, 0xd4, 0x58, 0x2f, 0x33, 0x61);
        // e31180a8-bbbd-4d14-a65e-7157b06233bb
        public static Guid FWPM_CONDITION_PROCESS_WITH_RPC_IF_UUID = new Guid(0xe31180a8, 0xbbbd, 0x4d14, 0xa6, 0x5e, 0x71, 0x57, 0xb0, 0x62, 0x33, 0xbb);
        // dccea0b9-0886-4360-9c6a-ab043a24fba9
        public static Guid FWPM_CONDITION_RPC_EP_VALUE = new Guid(0xdccea0b9, 0x0886, 0x4360, 0x9c, 0x6a, 0xab, 0x04, 0x3a, 0x24, 0xfb, 0xa9);
        // 218b814a-0a39-49b8-8e71-c20c39c7dd2e
        public static Guid FWPM_CONDITION_RPC_EP_FLAGS = new Guid(0x218b814a, 0x0a39, 0x49b8, 0x8e, 0x71, 0xc2, 0x0c, 0x39, 0xc7, 0xdd, 0x2e);
        // c228fc1e-403a-4478-be05-c9baa4c05ace
        public static Guid FWPM_CONDITION_CLIENT_TOKEN = new Guid(0xc228fc1e, 0x403a, 0x4478, 0xbe, 0x05, 0xc9, 0xba, 0xa4, 0xc0, 0x5a, 0xce);
        // b605a225-c3b3-48c7-9833-7aefa9527546
        public static Guid FWPM_CONDITION_RPC_SERVER_NAME = new Guid(0xb605a225, 0xc3b3, 0x48c7, 0x98, 0x33, 0x7a, 0xef, 0xa9, 0x52, 0x75, 0x46);
        // 8090f645-9ad5-4e3b-9f9f-8023ca097909
        public static Guid FWPM_CONDITION_RPC_SERVER_PORT = new Guid(0x8090f645, 0x9ad5, 0x4e3b, 0x9f, 0x9f, 0x80, 0x23, 0xca, 0x09, 0x79, 0x09);
        // 40953fe2-8565-4759-8488-1771b4b4b5db
        public static Guid FWPM_CONDITION_RPC_PROXY_AUTH_TYPE = new Guid(0x40953fe2, 0x8565, 0x4759, 0x84, 0x88, 0x17, 0x71, 0xb4, 0xb4, 0xb5, 0xdb);
        // a3ec00c7-05f4-4df7-91f2-5f60d91ff443
        public static Guid FWPM_CONDITION_CLIENT_CERT_KEY_LENGTH = new Guid(0xa3ec00c7, 0x05f4, 0x4df7, 0x91, 0xf2, 0x5f, 0x60, 0xd9, 0x1f, 0xf4, 0x43);
        // c491ad5e-f882-4283-b916-436b103ff4ad
        public static Guid FWPM_CONDITION_CLIENT_CERT_OID = new Guid(0xc491ad5e, 0xf882, 0x4283, 0xb9, 0x16, 0x43, 0x6b, 0x10, 0x3f, 0xf4, 0xad);
        // 206e9996-490e-40cf-b831-b38641eb6fcb
        public static Guid FWPM_CONDITION_NET_EVENT_TYPE = new Guid(0x206e9996, 0x490e, 0x40cf, 0xb8, 0x31, 0xb3, 0x86, 0x41, 0xeb, 0x6f, 0xcb);
        // 9b539082-eb90-4186-a6cc-de5b63235016
        public static Guid FWPM_CONDITION_PEER_NAME = new Guid(0x9b539082, 0xeb90, 0x4186, 0xa6, 0xcc, 0xde, 0x5b, 0x63, 0x23, 0x50, 0x16);
        // f68166fd-0682-4c89-b8f5-86436c7ef9b7
        public static Guid FWPM_CONDITION_REMOTE_ID = new Guid(0xf68166fd, 0x0682, 0x4c89, 0xb8, 0xf5, 0x86, 0x43, 0x6c, 0x7e, 0xf9, 0xb7);
        // eb458cd5-da7b-4ef9-8d43-7b0a840332f2
        public static Guid FWPM_CONDITION_AUTHENTICATION_TYPE = new Guid(0xeb458cd5, 0xda7b, 0x4ef9, 0x8d, 0x43, 0x7b, 0x0a, 0x84, 0x03, 0x32, 0xf2);
        // ff0f5f49-0ceb-481b-8638-1479791f3f2c
        public static Guid FWPM_CONDITION_KM_TYPE = new Guid(0xff0f5f49, 0x0ceb, 0x481b, 0x86, 0x38, 0x14, 0x79, 0x79, 0x1f, 0x3f, 0x2c);
        // feef4582-ef8f-4f7b-858b-9077d122de47
        public static Guid FWPM_CONDITION_KM_MODE = new Guid(0xfeef4582, 0xef8f, 0x4f7b, 0x85, 0x8b, 0x90, 0x77, 0xd1, 0x22, 0xde, 0x47);
        // ad37dee3-722f-45cc-a4e3-068048124452
        public static Guid FWPM_CONDITION_IPSEC_POLICY_KEY = new Guid(0xad37dee3, 0x722f, 0x45cc, 0xa4, 0xe3, 0x06, 0x80, 0x48, 0x12, 0x44, 0x52);
        // f64fc6d1-f9cb-43d2-8a5f-e13bc894f265
        public static Guid FWPM_CONDITION_QM_MODE = new Guid(0xf64fc6d1, 0xf9cb, 0x43d2, 0x8a, 0x5f, 0xe1, 0x3b, 0xc8, 0x94, 0xf2, 0x65);
        // 35a791ab-04ac-4ff2-a6bb-da6cfac71806
        public static Guid FWPM_CONDITION_COMPARTMENT_ID = new Guid(0x35a791ab, 0x04ac, 0x4ff2, 0xa6, 0xbb, 0xda, 0x6c, 0xfa, 0xc7, 0x18, 0x06);
        // 678f4deb-45af-4882-93fe-19d4729d9834
        public static Guid FWPM_CONDITION_RESERVED0 = new Guid(0x678f4deb, 0x45af, 0x4882, 0x93, 0xfe, 0x19, 0xd4, 0x72, 0x9d, 0x98, 0x34);
        // d818f827-5c69-48eb-bf80-d86b17755f97
        public static Guid FWPM_CONDITION_RESERVED1 = new Guid(0xd818f827, 0x5c69, 0x48eb, 0xbf, 0x80, 0xd8, 0x6b, 0x17, 0x75, 0x5f, 0x97);
        // 53d4123d-e15b-4e84-b7a8-dce16f7b62d9
        public static Guid FWPM_CONDITION_RESERVED2 = new Guid(0x53d4123d, 0xe15b, 0x4e84, 0xb7, 0xa8, 0xdc, 0xe1, 0x6f, 0x7b, 0x62, 0xd9);
        // 7f6e8ca3-6606-4932-97c7-e1f20710af3b
        public static Guid FWPM_CONDITION_RESERVED3 = new Guid(0x7f6e8ca3, 0x6606, 0x4932, 0x97, 0xc7, 0xe1, 0xf2, 0x07, 0x10, 0xaf, 0x3b);
        // 5f58e642-b937-495e-a94b-f6b051a49250
        public static Guid FWPM_CONDITION_RESERVED4 = new Guid(0x5f58e642, 0xb937, 0x495e, 0xa9, 0x4b, 0xf6, 0xb0, 0x51, 0xa4, 0x92, 0x50);
        // 9ba8f6cd-f77c-43e6-8847-11939dc5db5a
        public static Guid FWPM_CONDITION_RESERVED5 = new Guid(0x9ba8f6cd, 0xf77c, 0x43e6, 0x88, 0x47, 0x11, 0x93, 0x9d, 0xc5, 0xdb, 0x5a);
        // f13d84bd-59d5-44c4-8817-5ecdae1805bd
        public static Guid FWPM_CONDITION_RESERVED6 = new Guid(0xf13d84bd, 0x59d5, 0x44c4, 0x88, 0x17, 0x5e, 0xcd, 0xae, 0x18, 0x05, 0xbd);
        // 65a0f930-45dd-4983-aa33-efc7b611af08
        public static Guid FWPM_CONDITION_RESERVED7 = new Guid(0x65a0f930, 0x45dd, 0x4983, 0xaa, 0x33, 0xef, 0xc7, 0xb6, 0x11, 0xaf, 0x08);
        // 4f424974-0c12-4816-9b47-9a547db39a32
        public static Guid FWPM_CONDITION_RESERVED8 = new Guid(0x4f424974, 0x0c12, 0x4816, 0x9b, 0x47, 0x9a, 0x54, 0x7d, 0xb3, 0x9a, 0x32);
        // ce78e10f-13ff-4c70-8643-36ad1879afa3
        public static Guid FWPM_CONDITION_RESERVED9 = new Guid(0xce78e10f, 0x13ff, 0x4c70, 0x86, 0x43, 0x36, 0xad, 0x18, 0x79, 0xaf, 0xa3);
        // b979e282-d621-4c8c-b184-b105a61c36ce
        public static Guid FWPM_CONDITION_RESERVED10 = new Guid(0xb979e282, 0xd621, 0x4c8c, 0xb1, 0x84, 0xb1, 0x05, 0xa6, 0x1c, 0x36, 0xce);
        // 2d62ee4d-023d-411f-9582-43acbb795975
        public static Guid FWPM_CONDITION_RESERVED11 = new Guid(0x2d62ee4d, 0x023d, 0x411f, 0x95, 0x82, 0x43, 0xac, 0xbb, 0x79, 0x59, 0x75);
        // a3677c32-7e35-4ddc-93da-e8c33fc923c7
        public static Guid FWPM_CONDITION_RESERVED12 = new Guid(0xa3677c32, 0x7e35, 0x4ddc, 0x93, 0xda, 0xe8, 0xc3, 0x3f, 0xc9, 0x23, 0xc7);
        // 335a3e90-84aa-42f5-9e6f-59309536a44c
        public static Guid FWPM_CONDITION_RESERVED13 = new Guid(0x335a3e90, 0x84aa, 0x42f5, 0x9e, 0x6f, 0x59, 0x30, 0x95, 0x36, 0xa4, 0x4c);
        // 30e44da2-2f1a-4116-a559-f907de83604a
        public static Guid FWPM_CONDITION_RESERVED14 = new Guid(0x30e44da2, 0x2f1a, 0x4116, 0xa5, 0x59, 0xf9, 0x07, 0xde, 0x83, 0x60, 0x4a);
        // bab8340f-afe0-43d1-80d8-5ca456962de3
        public static Guid FWPM_CONDITION_RESERVED15 = new Guid(0xbab8340f, 0xafe0, 0x43d1, 0x80, 0xd8, 0x5c, 0xa4, 0x56, 0x96, 0x2d, 0xe3);

        public static bool IsIpAddressCondition(Guid condition_key)
        {
            return condition_key == FWPM_CONDITION_IP_DESTINATION_ADDRESS ||
                condition_key == FWPM_CONDITION_IP_LOCAL_ADDRESS ||
                condition_key == FWPM_CONDITION_IP_LOCAL_ADDRESS_V4 ||
                condition_key == FWPM_CONDITION_IP_LOCAL_ADDRESS_V6 ||
                condition_key == FWPM_CONDITION_IP_REMOTE_ADDRESS ||
                condition_key == FWPM_CONDITION_IP_REMOTE_ADDRESS_V4 ||
                condition_key == FWPM_CONDITION_IP_REMOTE_ADDRESS_V6;
        }

        public static bool IsMacAddressCondition(Guid condition_key)
        {
            return condition_key == FWPM_CONDITION_INTERFACE_MAC_ADDRESS ||
                condition_key == FWPM_CONDITION_MAC_DESTINATION_ADDRESS ||
                condition_key == FWPM_CONDITION_MAC_LOCAL_ADDRESS ||
                condition_key == FWPM_CONDITION_MAC_SOURCE_ADDRESS ||
                condition_key == FWPM_CONDITION_MAC_REMOTE_ADDRESS;
        }

        public static bool IsAppId(Guid condition_key)
        {
            return condition_key == FWPM_CONDITION_ALE_APP_ID ||
                condition_key == FWPM_CONDITION_ALE_ORIGINAL_APP_ID;
        }

        public static bool IsGuid(Guid condition_key)
        {
            return condition_key == FWPM_CONDITION_DCOM_APP_ID ||
                condition_key == FWPM_CONDITION_RPC_IF_UUID;
        }

        public static bool IsProfileId(Guid condition_key)
        {
            return condition_key == FWPM_CONDITION_CURRENT_PROFILE_ID ||
                condition_key == FWPM_CONDITION_ORIGINAL_PROFILE_ID ||
                condition_key == FWPM_CONDITION_ARRIVAL_INTERFACE_PROFILE_ID ||
                condition_key == FWPM_CONDITION_LOCAL_INTERFACE_PROFILE_ID ||
                condition_key == FWPM_CONDITION_NEXTHOP_INTERFACE_PROFILE_ID;
        }

        public static bool IsDataLink(Guid condition_key)
        {
            return condition_key == FWPM_CONDITION_MAC_LOCAL_ADDRESS_TYPE ||
                condition_key == FWPM_CONDITION_MAC_REMOTE_ADDRESS_TYPE ||
                condition_key == FWPM_CONDITION_MAC_SOURCE_ADDRESS_TYPE ||
                condition_key == FWPM_CONDITION_MAC_DESTINATION_ADDRESS_TYPE;
        }

        public static bool IsNetworkLayer(Guid condition_key)
        {
            return condition_key == FWPM_CONDITION_IP_LOCAL_ADDRESS_TYPE ||
                condition_key == FWPM_CONDITION_IP_DESTINATION_ADDRESS_TYPE ||
                condition_key == FWPM_CONDITION_EMBEDDED_LOCAL_ADDRESS_TYPE;
        }

        public static bool IsTunnelType(Guid condition_key)
        {
            return condition_key == FWPM_CONDITION_ARRIVAL_TUNNEL_TYPE ||
                condition_key == FWPM_LOCAL_CONDITION_TUNNEL_TYPE || 
                condition_key == FWPM_CONDITION_NEXTHOP_TUNNEL_TYPE;
        }

        public static bool IsInterfaceType(Guid condition_key)
        {
            return condition_key == FWPM_CONDITION_LOCAL_INTERFACE_TYPE ||
                condition_key == FWPM_CONDITION_NEXTHOP_INTERFACE_TYPE ||
                condition_key == FWPM_CONDITION_ARRIVAL_INTERFACE_TYPE;
        }

        public static bool IsUserId(Guid condition_key)
        {
            return condition_key == FWPM_CONDITION_ALE_USER_ID ||
                condition_key == FWPM_CONDITION_ALE_REMOTE_USER_ID ||
                condition_key == FWPM_CONDITION_ALE_REMOTE_MACHINE_ID;
        }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}