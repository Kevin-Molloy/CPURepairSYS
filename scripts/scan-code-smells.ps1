param(
    [string]$Configuration = "Release",
    [string]$OutputPath = "code-smells.sarif"
)

$ErrorActionPreference = "Stop"

$project = Join-Path $PSScriptRoot "..\CPURepairSYS.csproj"
$resolvedOutputPath = [System.IO.Path]::GetFullPath((Join-Path (Get-Location) $OutputPath))

dotnet build $project `
    --configuration $Configuration `
    /p:ErrorLog="$resolvedOutputPath" `
    /p:ErrorLogVersion=2

if ($LASTEXITCODE -ne 0) {
    throw "The project build failed. The code-smell report may be incomplete."
}

Write-Host "Code-smell report written to $resolvedOutputPath"
#powershell.exe -NoProfile -ExecutionPolicy Bypass `-File .\scripts\scan-code-smells.ps1
