# CarDealership-Vue-Dotnet
Light web application demoing a car dealership with a dotnet core backend and vue.js front end app

# Usage
In visual studio 2022, simply open the .sln file, then start debugging with f5, both the backend API browsing tool and the web app itself should open
![i](https://i.imgur.com/nEoQrgd.png)

#!!!Must be run on Visual Studio 2022 (Made using net 6.0)
#If compiling complains about bootstrap, run "npm i bootstrap jquery popper.js" on the package manager console.

NOTICE! INCASE OF ZERO CARS, OR IN CASE OF THE BACKEND NOT SIMPLY GETTING ANY DATA:
The database in appsettings might already be offline, so to run, you might have to insert some other database there yourself.
Create a mysql database in a destination of your choosing and add the migrations from the project to this database. Only table needed is the car model
with brand, model and year information. then replace the database information in appsettings.


