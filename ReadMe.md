MINI PROJECT
SURESUCCESS INTERNATIONAL COLLEGE MANAGEMENT SYSTEM
The project consists of some micro services
The CreateService, ReadService, UpdateService, DeleteService and AuthenticationService sit on the same Data Base (MySQL) but all of them are independent of each other. The API Gateway is responsible for sending request to the services and return the response to the caller. Ocelot API Gateway is the library used for the API Gateway.
The Registration portal(UI) or any other API Client can only send request to the Services through the API Gateway.


To run the project, you will have to change the connection string user and password in the appsetting development.json file.
And the services must be running for the API Gateway to make request accrose to them.


API Gateway Endpoints

When request is sent to API Gateway endpoint, it will send the request to appropriate servive.

Login to get authentication token - https://localhost:5041/api/v1/login

Student registration - https://localhost:5041/api/v1/create

Get all registered students - https://localhost:/api/v1/read

Edit Student Registration - https://localhost:5041/api/v1/update/{id}

Detail - https://localhost:5041/api/v1/read/{id}

Delete Record - https://localhost:5041/api/v1/delete/{id}