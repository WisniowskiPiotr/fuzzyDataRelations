Add-Type -Path Program.cs Sanitizer.cs 
[fuzzyDataRelations.Program]::Main() 
git add -A 
git commit -a -m "some tests + new TheFunctionsRulePublicValue class" 
git push origin master 
