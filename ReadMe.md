MINI PROJECT
SURESUCCESS INTERNATIONAL COLLEGE MANAGEMENT SYSTEM
The project consists of some micro services
The CreateService, ReadService, UpdateService, DeleteService and AuthenticationService sit on the same Data Base (MySQL) but all of them are independent of each other. The API Gateway is responsible for sending request to the services and return the response to the caller. Ocelot API Gateway is the library used for the API Gateway.


