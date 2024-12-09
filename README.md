# lasarohlink-backend

This is an API developed in ASP.NET Core with .NET 6.0, designed to manage and respond to requests for **lasarohlink-frontend**. The choice of .NET 6.0 allows for seamless and straightforward deployment on **Railway**

### API Detail

- **Swagger Documentation**: [https://api.lasaroh.link/Swagger/index.html](https://api.lasaroh.link/Swagger/index.html)

### Database Connection

The API connects to a **PostgreSQL** database also deployed on Railway, ensuring efficient and scalable data handling.

## Local Deployment

To run the API in your local environment, follow these steps:

1. **Create the PostgreSQL database**:
   - Install PostgreSQL on your machine if you haven't already.
   - Create a local database named `lasarohlink` (or your preferred name).

2. **Configure the environment variables**:
   - Make sure the following environment variables are set in your system or your development configuration file:
  
   - `BACKEND_URL`: The base URL of the API on your local machine (e.g. `https://localhost:7273/`).
   - `FRONTEND_URL`: The URL of your frontend locally (e.g. `http://localhost:4321`).
   - `LASAROHLINK_DATABASE`: Connection string for the PostgreSQL database (e.g. `Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=lasarohlink;`).

3. **Run the API**:
   - The API can be started directly from your IDE or from the terminal with the `dotnet run` command.
