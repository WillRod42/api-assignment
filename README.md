# Hair Salon

#### By William Rodriguez

## Technologies Used

* HTML
* Bootstrap
* .NET Core
* ASP.NET MVC
* ASP.NET Identity
* JWT
* Entity Framework Core
* MySQL

## Description

An API that interfaces with a MySQL database that keeps track of an animal shelter's animals

## Setup/Installation Requirements

### Setup Repository
* Clone this repository to your desktop or any directory of your choice
  * Run the command below in a bash terminal with [git](https://github.com/git-guides/install-git) installed
```
git clone https://github.com/WillRod42/api-assignment.git
```
* Or download as a zip file
  * Click the green code button on the repository page
  * At the bottom of the popup window select `Download ZIP`
  * Extract the downloaded .zip folder
* Make sure you have the [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) installed and setup correctly for your OS
* Open the `Shelter` folder of the downloaded repsoitory
* Run these commands in a terminal
  ```
  dotnet restore
  dotnet build
  dotnet run
  ```
* This will open a live instance of the web-app at [http://localhost:5000](http://localhost:5000)

### Setup MySQL Server
* Download and install the version of [MySQL](https://dev.mysql.com/downloads/mysql/) for your OS
* Inside the `Shelter` folder, create a file named `appsettings.json`
  * Inside add these lines and save the file
  ```
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=<database name here>;uid=<username here>;pwd=<password here>;"
    }
  },
	"JWT": {
    "SecretKey": "<Your secret key here>",
    "ValidIssuer": "http://localhost:5000"
  }
  ```
* Run this command in a terminal at this location
  ```
  dotnet ef database update
  ```

<hr>

## API Endpoints
All endpoints, outside of GET requests and authentication requests, require a JWT for authentication

### Animals

#### /api/animals (GET)
* Returns all animals in the database

#### /api/animals/{id} (GET)
* Returns a specific animal in the database

#### /api/animals/type/{id} (GET)
* Returns all animals of a specific type

#### /api/animals (POST)
* Creates a new animal object in the database
```
{
	"Name": <varchar>,
	"Breed": <varchar>,
	"IsMale": <boolean>,
	"Age", <integer>,
	"TypeId", <foreign key>
}
```

#### /api/animals/{id} (PUT)
* Edits a specific animal in the database
```
{
	"AnimalId", <primary key>
	"Name": <varchar>,
	"Breed": <varchar>,
	"IsMale": <boolean>,
	"Age", <integer>,
	"TypeId", <foreign key>
}
```

#### /api/animals/{id} (DELETE)
* Deletes a specific animal in the database

### Animal Types

#### /api/animaltypes (GET)
* Returns all animals in the database

#### /api/animaltypes/{id} (GET)
* Returns a specific animal type in the database

#### /api/animaltypes (POST)
* Creates a new animal type object in the database
```
{
	"Name": <varchar>
}
```

#### /api/animaltypes/{id} (PUT)
* Edits a specific animal type in the database
```
{
	"AnimalTypeId", <primary key>
	"Name": <varchar>
}
```

#### /api/animaltypes/{id} (DELETE)
* Deletes a specific animal type in the database

### Authentication

#### /authenticate/register
* Registers a new user
```
{
	"Email": <varchar>,
	"Password": <varchar>,
	"ConfirmPassword: <varchar>
}
```

#### /authenticate/login
* Grants user a JWT for authentication
```
{
	"Email": <varchar>,
	"Password": <varchar>
}
```

<hr>

## Known Bugs

* API does not correctly validate authentication token

## License

MIT

Copyright (c) 2022 William Rodriguez