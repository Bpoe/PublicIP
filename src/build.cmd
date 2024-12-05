@echo off

dotnet publish -c:Release -r:linux-x64 /t:PublishContainer
