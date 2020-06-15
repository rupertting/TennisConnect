# Project Variables

PROJECT_NAME ?= TennisConnect

.PHONY: migrations db hello

migrations:
	cd .\TennisConnect.Data && dotnet ef --startup-project ..\TennisConnect.Web\ migrations add $(mname) && cd ..

db:
	cd .\TennisConnect.Data && dotnet rf --startup-project ..\TennisConnect.Web\ database update && cd ..

hello:
	echo 'hello!'
