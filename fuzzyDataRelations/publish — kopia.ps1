Add-Type -Path Program.cs Sanitizer.cs 
[fuzzyDataRelations.Program]::Main() 
git add -A 
git commit -a -m "some tests + new SummaryTextUsing class" 
git push origin master 
