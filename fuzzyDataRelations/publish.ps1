       
		Add-Type -Path Program.cs, Sanitizer.cs, FileFaker.cs  
		[fuzzyDataRelations.Program]::Main()  
		git add -A  
		git commit -a -m "trying again ParamVoid" 
		git push origin master 
       
		$time = Get-Random -Minimum 100 -Maximum 8000 
		Write-Host $time + " seconds" 
