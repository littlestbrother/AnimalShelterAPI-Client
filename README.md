# Animal Shelter

### ***A C# API with a web-pack front end that handles full CRUD functionality for an Animal Shelter***

### **By *Aaron Kauffman***

## **Description**

*This web application helps a hypothetical Animal Shelter manage what animals are in the shelter.* 

# Instructions

### API Setup:

1. Clone the repository.
2. Add the file `appsettings.json` to the `AnimalAPI` folder. ***It's contents also include other MVC files and folders.***
3. Here's what `appsettings.json` should contain for this specific project. Replace your [DATABASE] and [PASSWORD] appropriately.

```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE];uid=root;pwd=[PASSWORD];"
  }
}
```

1. Create a schema in MySQL Workbench- the name of the database ***must*** match the database name from your `appsettings.json`.
2. From within the `AnimalAPI` directory; build the database with:

```bash
dotnet ef database update
```

1. From the uppermost directory of your project run:

```bash
cd AnimalAPI && dotnet run
```

### Client Setup:

Navigate to the `AnimalClient` directory and from within run:

```bash
npm i && npm run start
```

### API Documentation:
While the API is up and running- naviagte to `localhost:5050` for documentation.

## **Technologies Used**

- C#, MVC, [Asp.Net](http://asp.net/) Core, EF Core, MySQL.
- HTML, JS, CSS, Bootstrap, git, npm, webpack, jquery

## **Known Bugs**

- None found so far. Go ahead and break it i guess.

## **License**

[MIT](https://choosealicense.com/licenses/mit/)

## **Contact Information**

*If you run into any issues, remember: Stop, Drop, and Roll. Or, Contact Aaron at: [Aaron.Christian.Kauffman@gmail.com](mailto:Aaron.Christian.Kauffman@gmail.com)*
