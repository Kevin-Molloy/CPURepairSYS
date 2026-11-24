param(
    [string]$Configuration = "Release",
    [string]$OutputPath = "code-smells.sarif"
)

$ErrorActionPreference = "Stop"

$solution = Join-Path $PSScriptRoot "..\CPURepairSYS.sln"
$resolvedOutputPath = [System.IO.Path]::GetFullPath((Join-Path (Get-Location) $OutputPath))

dotnet build $solution `
    --configuration $Configuration `
    /p:ErrorLog="$resolvedOutputPath" `
    /p:ErrorLogVersion=2

if ($LASTEXITCODE -ne 0) {
    throw "The project build failed. The code-smell report may be incomplete."
}

Write-Host "Code-smell report written to $resolvedOutputPath"
#powershell.exe -NoProfile -ExecutionPolicy Bypass `-File .\scripts\scan-code-smells.ps1
