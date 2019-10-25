# _Shawn Luc Pierre's Treat and FLavor Tracking System_

#### _Create and track all Treats and Flavors for Shawn Luc Pierre's Bakery, {10/25/2019}_

#### By _**Devin Cooley**_

## Description

_The purpose of this application is to give Shawn Luc Pierre the ability to manage all of his Treats and Flavors. This application will allow him to enter new Treats/Flavors, Delete Treats/Flavors, and keep track of the relationships between the two._

## Specifications

| Spec                      |Input          | Output |
|:---------------------------|:-------------|:------|
|Allows user to creat profile and only allows access when logged in| username: bill, password: bill| access denied|
|Creates a Treat object|"name"|Treat:name|
|Creates a Flavor object|"name"|Flavor:name|
|Creates a list of all Treat objects|"Treat, Treat, Treat"|
|Creates a list of all Flavor objects|"flavor","flavor2"|orders: order,order2|
|Allows user to delete a Treat/Flavor| "delete flavor"| Flavor is Deleted|
Allows user to Update Treat/Flavor|Flavor Name = bill, not ralph| Flavor name = bill|
|Allows user to Select a Treat to associate to a FLavor or vis versa|"Treat"=> "Flavor"| Treat has flavor Flavor|

## Setup/Installation Requirements

_Make sure you have the neccessary software installed to run C# and .NET from your console. Clone the project repository and navigate into the root directory with your console. Nagigate to both the "PierreAuthen" directory and run command "dotnet restore" from your console in those directories. Navigate to directory and run command "dotnet run" from your console in that directory. Click the link in your console to open the application in default web browser.

## Known Bugs

_There are no known bugs at this time._

## Support and contact details

_Send any questions or comments to Devin Cooley at dcooley1350@gmail.com._

## Technologies Used

_This program was written using HTML, C# and the .NET Framework. Microsoft .NET TestTools were implemented. MySql Entity and Identity were implemented. The application is viewed in a web browser of other client._

### License

*This software is licensed under the MIT license.*

Copyright (c) 2019 **_Devin Cooley_**