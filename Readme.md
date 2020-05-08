# AWS ASP.NET Core Web API HospitalService Lambda Function

This project is a Micro Service for project-data-public. Which is a software project in development by Helpful Engineering to match hospital's PPE demands with supply. This Web API gives CRUD functionality for a Hospital Repository around the Globe.

### Configuring Hospital Service ###

For Production deployment, paste the DB connection string in appsettings.json in the field below. This should be pointing to an AWS RDS.
```json
    "ConnectionStrings": {
    "HospitalDbConnection": ""
  }
```
Set Environment Variable to Production 

For Local deployment, paste the DB connection string in appsettings.Development.json in the field below. This can be used with a Local Maria Db.
```json   
    "HospitalDbConnection": ""  
```
Set Environment Variable to Development
