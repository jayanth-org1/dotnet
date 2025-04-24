# Hotel/Restaurant Booking Backend

This is a .NET Web API backend for a hotel/restaurant booking application. It provides APIs for user management, restaurant management, and booking management.

## Features
- User Management: Login, Registration
- Restaurant Management: List, Add, Update, Delete
- Booking Management: Create, View, Cancel Bookings

## Prerequisites
- .NET SDK installed
- A database (e.g., SQL Server, PostgreSQL, etc.)

## Setup Instructions
1. Clone the repository.
2. Navigate to the project directory.
3. Add a `.env` file with the required environment variables (see `.env` section below).
4. Restore dependencies:
   ```
   dotnet restore
   ```
5. Run the application:
   ```
   dotnet run
   ```

## Environment Variables
Create a `.env` file in the project root with the following variables:
```
DB_CONNECTION_STRING=your_database_connection_string
JWT_SECRET=your_jwt_secret
```

## API Endpoints
- **User Management**
  - `POST /api/users/register`: Register a new user
  - `POST /api/users/login`: Login a user
- **Restaurant Management**
  - `GET /api/restaurants`: List all restaurants
  - `POST /api/restaurants`: Add a new restaurant
  - `PUT /api/restaurants/{id}`: Update a restaurant
  - `DELETE /api/restaurants/{id}`: Delete a restaurant
- **Booking Management**
  - `POST /api/bookings`: Create a new booking
  - `GET /api/bookings`: View all bookings
  - `DELETE /api/bookings/{id}`: Cancel a booking