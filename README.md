# _Hair Salon_

#### _A program that allows the user to add their stylist employees and their clients, May 17, 2019._

#### By _**Reese Lee**_

## Description

_A program for a hair salon owner to add their stylists, and those stylist's clients. An employee of that hair salon will be able to see the other employees, and each employee's clients._

## Setup/Installation Requirements

_To set up the database in MySQL:

* _> CREATE DATABASE reese_lee;
* _> USE reese_lee;
* _> CREATE TABLE clients (id serial PRIMARY KEY, clientName VARCHAR(255), stylist_id INT);
* _> CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), specialty VARCHAR(255));
* _> CREATE TABLE assignments (id serial PRIMARY KEY, stylist_id INT, specialty_id INT)

_To download and import the database:_

* _Start MAMP or WAMP and click Open WebStart page in the MAMP/WAMP window._
* _In the page that opens, select phpMyAdmin._
* _Select the Import tab._
* _Create a new database with the same name._
* _Select your database file, and click Go._

_To clone and launch the application:_

* _Clone from GitHub
* _$cd HairSalon.Solution/HairSalon_
* _$git checkout specialty
* _$dotnet restore to install packages from the .csproj file_
* _$dotnet run to start the application_
* _Launch [http://localhost:5000/](http://localhost:5000/) in your browser_

## Known Bugs

_ 

## Support and contact details

_Please contact reese.lee.cy@gmail.com if you run into any issues or have questions, ideas or feedback._

## Technologies Used

_C#_

### License

*MIT license.*

Copyright (c) 2019 **_Reese Lee_**
