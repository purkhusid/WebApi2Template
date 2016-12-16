cls
nuget install FAKE -OutputDirectory tools -ExcludeVersion
nuget install NUnit.ConsoleRunner -OutputDirectory tools -ExcludeVersion
"tools\FAKE\tools\Fake.exe" build.fsx
pause