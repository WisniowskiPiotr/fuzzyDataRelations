$runToday = Get-Random -Minimum 0 -Maximum 4 
If( $runToday -gt 1) { 
	$number = Get-Random -Minimum 1 -Maximum 8 
	Write-Host $number " times" 
	for($i=0 
     $i -le $number 
     $i++){ 
		$time = Get-Random -Minimum 1 -Maximum 8000 
		Write-Host $time + " seconds" 
		Start-Sleep -s $time 
		Add-Type -Path Program.cs, Sanitizer.cs  
		[fuzzyDataRelations.Program]::Main()  
		git add -A  
		git commit -a -m "PublicStringEndregion gui" 
		git push origin master 
	}  
} 
