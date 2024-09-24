﻿#  Copyright 2021 Google Inc. All Rights Reserved.
#
#  Licensed under the Apache License, Version 2.0 (the "License");
#  you may not use this file except in compliance with the License.
#  You may obtain a copy of the License at
#
#  http://www.apache.org/licenses/LICENSE-2.0
#
#  Unless required by applicable law or agreed to in writing, software
#  distributed under the License is distributed on an "AS IS" BASIS,
#  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
#  See the License for the specific language governing permissions and
#  limitations under the License.

<#
.SYNOPSIS
Create a kernel crash dump.
.DESCRIPTION
This cmdlet will use the NtSystemDebugControl API to create a system kernel crash dump with specified options.
.PARAMETER Path
The NT native path to the crash dump file to create
.PARAMETER Flags
Optional flags to control what to dump
.PARAMETER PageFlags
Optional flags to control what additional pages to dump
.INPUTS
None
.EXAMPLE
New-NtKernelCrashDump \??\C:\memory.dmp
Create a new crash dump at c:\memory.dmp
.EXAMPLE
New-NtKernelCrashDump \??\C:\memory.dmp -Flags IncludeUserSpaceMemoryPages
Create a new crash dump at c:\memory.dmp including user memory pages.
#>
function New-NtKernelCrashDump {
    Param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$Path,
        [NtApiDotNet.SystemDebugKernelDumpControlFlags]$Flags = 0,
        [NtApiDotNet.SystemDebugKernelDumpPageControlFlags]$PageFlags = 0
    )
    [NtApiDotNet.NtSystemInfo]::CreateKernelDump($Path, $Flags, $PageFlags)
}

<#
.SYNOPSIS
Get a range of system information values.
.DESCRIPTION
This cmdlet gets a range of system information values.
.PARAMETER IsolatedUserMode
Return isolated usermode flags.
.PARAMETER ProcessorInformation
Return processor information.
.PARAMETER MultiSession
Return whether this system is a multi-session SKU.
.PARAMETER MultiSession
Return the system's elevation flags.
.INPUTS
None
.OUTPUTS
Depends on parameters.
.EXAMPLE
Get-NtSystemInformation -IsolatedUserMode
Get isolated user mode information.
#>
function Get-NtSystemInformation {
    param(
        [Parameter(Mandatory, ParameterSetName="IsolatedUserMode")]
        [switch]$IsolatedUserMode,
        [Parameter(Mandatory, ParameterSetName="ProcessorInformation")]
        [switch]$ProcessorInformation,
        [Parameter(Mandatory, ParameterSetName="MultiSession")]
        [switch]$MultiSession,
        [Parameter(Mandatory, ParameterSetName="Elevation")]
        [switch]$ElevationFlags
    )
    if ($IsolatedUserMode) {
        [NtApiDotNet.NtSystemInfo]::IsolatedUserModeFlags
    } elseif ($ProcessorInformation) {
        [NtApiDotNet.NtSystemInfo]::ProcessorInformation
    } elseif ($MultiSession) {
        [NtApiDotNet.NtSystemInfo]::IsMultiSession
    } elseif ($ElevationFlags) {
        [NtApiDotNet.NtSystemInfo]::ElevationFlags
    }
}

<#
.SYNOPSIS
Get list of loaded kernel modules.
.DESCRIPTION
This cmdlet gets the list of loaded kernel modules.
.INPUTS
None
.OUTPUTS
NtApiDotNet.ProcessModule[]
#>
function Get-NtKernelModule {
    [NtApiDotNet.NtSystemInfo]::GetKernelModules() | Write-Output
}

<#
.SYNOPSIS
Get logon sessions for current system.
.DESCRIPTION
This cmdlet gets the active logon sessions for the current system.
.PARAMETER LogonId
Specify the Logon ID for the session.
.PARAMETER Token
Specify a Token to get the session for.
.PARAMETER IdOnly
Specify to only get the Logon ID rather than full details.
.INPUTS
None
.OUTPUTS
NtApiDotNet.Win32.Security.Authentication.LogonSession
NtApiDotNet.Luid
.EXAMPLE
Get-NtLogonSession
Get all accessible logon sessions.
.EXAMPLE
Get-NtLogonSession -LogonId 123456
Get logon session with ID 123456
.EXAMPLE
Get-NtLogonSession -Token $token
Get logon session from Token Authentication ID.
.EXAMPLE
Get-NtLogonSession -IdOnly
Get all logon sesion IDs only.
#>
function Get-NtLogonSession {
    [CmdletBinding(DefaultParameterSetName = "All")]
    param (
        [parameter(Mandatory, ParameterSetName = "FromLogonId")]
        [NtApiDotNet.Luid]$LogonId,
        [parameter(Mandatory, Position = 0, ParameterSetName = "FromToken")]
        [NtApiDotNet.NtToken]$Token,
        [parameter(ParameterSetName = "All")]
        [switch]$IdOnly
    )
    switch($PSCmdlet.ParameterSetName) {
        "All" {
            if ($IdOnly) {
                [NtApiDotNet.Win32.LogonUtils]::GetLogonSessionIds() | Write-Output
            } else {
                [NtApiDotNet.Win32.LogonUtils]::GetLogonSessions() | Write-Output
            }
        }
        "FromLogonId" {
            [NtApiDotNet.Win32.LogonUtils]::GetLogonSession($LogonId) | Write-Output
        }
        "FromToken" {
            [NtApiDotNet.Win32.LogonUtils]::GetLogonSession($Token.AuthenticationId) | Write-Output
        }
    }
}

<#
.SYNOPSIS
Get current console sessions for the system.
.DESCRIPTION
This cmdlet gets current console sessions for the system.
.INPUTS
None
.OUTPUTS
NtApiDotNet.Win32.ConsoleSession
.EXAMPLE
Get-NtConsoleSession
Get all Console Sesssions.
#>
function Get-NtConsoleSession {
    [NtApiDotNet.Win32.Win32Utils]::GetConsoleSessions() | Write-Output
}

<#
.SYNOPSIS
Gets a new Locally Unique ID (LUID)
.DESCRIPTION
This cmdlet requests a new LUID value.
.INPUTS
None
.OUTPUTS
NtApiDotNet.Luid
.EXAMPLE
Get-NtLocallyUniqueId
Get a new locally unique ID.
#>
function Get-NtLocallyUniqueId {
    [NtApiDotNet.NtSystemInfo]::AllocateLocallyUniqueId() | Write-Output
}

<#
.SYNOPSIS
Gets the access masks for a type.
.DESCRIPTION
This cmdlet gets the access masks for a type.
.PARAMETER Type
The NT type.
.PARAMETER Read
Show only read access.
.PARAMETER Write
Show only write access.
.PARAMETER Execute
Show only execute access.
.PARAMETER Mandatory
Show only default mandatory access.
.PARAMETER SpecificOnly
Show only type specific access.
.INPUTS
None
.OUTPUTS
AccessMask entries.
#>
function Get-NtTypeAccess {
    [CmdletBinding(DefaultParameterSetName = "All")]
    Param(
        [Parameter(Mandatory, Position = 0)]
        [NtApiDotNet.NtType]$Type,
        [Parameter(ParameterSetName = "Read")]
        [switch]$Read,
        [Parameter(ParameterSetName = "Write")]
        [switch]$Write,
        [Parameter(ParameterSetName = "Execute")]
        [switch]$Execute,
        [Parameter(ParameterSetName = "Mandatory")]
        [switch]$Mandatory,
        [switch]$SpecificOnly
    )

    $access = switch ($PSCmdlet.ParameterSetName) {
        "All" { $Type.AccessRights }
        "Read" { $Type.ReadAccessRights }
        "Write" { $Type.WriteAccessRights }
        "Execute" { $Type.ExecuteAccessRights }
        "Mandatory" { $Type.MandatoryAccessRights }
    }

    if ($SpecificOnly) {
        $access | Where-Object {$_.Mask.HasSpecificAccess} | Write-Output
    } else {
        $access | Write-Output
    }
}

<#
.SYNOPSIS
Creates a new "fake" NT type object.
.DESCRIPTION
This cmdlet creates a new "fake" NT type object which can be used to do access checking for objects which aren't real NT types.
.PARAMETER Name
The name of the "fake" type.
.PARAMETER GenericRead
The value of GenericRead for the GENERIC_MAPPING.
.PARAMETER GenericWrite
The value of GenericWrite for the GENERIC_MAPPING.
.PARAMETER GenericExecute
The value of GenericExecute for the GENERIC_MAPPING.
.PARAMETER GenericAll
The value of GenericAll for the GENERIC_MAPPING.
.PARAMETER AccessRightsType
The enumerated type.
.INPUTS
None
.OUTPUTS
NtApiDotNet.NtType
#>
function New-NtType {
    Param(
        [parameter(Position = 0, Mandatory)]
        [string]$Name,
        [System.Type]$AccessRightsType = [NtApiDotNet.GenericAccessRights],
        [NtApiDotNet.AccessMask]$GenericRead = 0,
        [NtApiDotNet.AccessMask]$GenericWrite = 0,
        [NtApiDotNet.AccessMask]$GenericExecute = 0,
        [NtApiDotNet.AccessMask]$GenericAll = 0
    )

    [NtApiDotNet.NtType]::GetFakeType($Name, $GenericRead, $GenericWrite, $GenericExecute, $GenericAll, $AccessRightsType)
}
