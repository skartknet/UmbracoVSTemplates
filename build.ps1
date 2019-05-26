function ZipFiles( [string]$destfile, [string]$sourcedir ) {
    Add-Type -Assembly System.IO.Compression.FileSystem
    $compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal
    [System.IO.Compression.ZipFile]::CreateFromDirectory($sourcedir,
        $destfile, $compressionLevel, $false)
}

$projectDir = ".\"
$destDir = Join-Path $projectDir "Dist"
$templatesDir = Join-Path $projectDir "Templates"
$templates = Get-ChildItem $templatesDir

# delete all files in Dist folder
Get-ChildItem -Path $destDir -Include *.* -File -Recurse | foreach { $_.Delete() }

foreach ($subfolder in $templates) {
    $destZip = $destDir + "\" + $subfolder.Name + ".zip"
    ZipFiles $destZip  $subfolder.FullName
}