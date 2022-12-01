param (
    [Parameter(Mandatory=$true)]
    [int]
    $day
)

$day00 = $day.ToString("00")

$targetFolder = "..\Day$($day00)\"

if(-not(Test-Path $targetFolder)) {
    New-Item $targetFolder -ItemType Directory
}

dotnet run `
    --project "D:\VRM\Projects\FearchAndFeplace\FearchAndFeplace\FearchAndFeplace.fsproj" `
    -- `
    --sourceFolder ".\Vincent" `
    --targetFolder "$($targetFolder)" `
    --pattern "{{{Project}}}" `
    --replace "Day$($day00)"

dotnet sln add "$($targetFolder)\Vincent\AdventOfCode2022.Day$($day00).fsproj"
