CalculatorService
=======

# Introduction
This repository contains a full solution of a calculator service, a REST API and a console client app to test API.

Both applications has been build with .Net Core 3.1

# Architecture
Solution is based in Clean Architecture and some additional libraries has been used:

In source projects:
- MediatR
- FluentValidation
- AutoMapper
- Serilog
- Swashbuckle


In test projects:
- XUnit
- FluentAssertions

# How run CalculatorService

In order to testing purposes, use this docker commands

docker build -f .\api.Dockerfile -t calculatorserviceapi .
docker build -f .\console.Dockerfile -t consoleapiclient .

docker run -d -p 5000:80  calculatorserviceapi
docker run -i -e CalculatorApiAddres='http://host.docker.internal:5000' consoleapiclient

![alt text](https://i.ibb.co/SyBrHHT/clientapp.png)