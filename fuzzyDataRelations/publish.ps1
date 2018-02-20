Add-Type -Path Program.cs -Path Sanitizer.cs 
[fuzzyDataRelations.Program]::Main() 
git add -A 
git commit -a -m "some tests + new SummaryTextUsing class" 
git push origin master 

pause
