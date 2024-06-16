Write-Host "Cleaning Bin and Obj"
Get-ChildItem .\ -include bin,obj -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse }
Write-Host "Removing Zip"
remove-item  -path "Hylaine.zip"