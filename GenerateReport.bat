@echo off

set PROJECT_BUILD_PATH=..\..\GitLab\SeleniumCSharp
set OUTPUT_PATH=%USERPROFILE%\Downloads

echo Building .NET project...

cd PROJECT_BUILD_PATH

dotnet build

echo Generating SpecFlow Living Documentation report...

cd ..\..\GitHub\SeleniumCSharp_Master\AutomationSpecFlow\bin\Debug\net6.0\

livingdoc test-assembly AutomationSpecFlow.dll -t TestExecution.json --output C:\Users\jorge\Downloads\MyReportTest.html

echo Report generated successfully!
