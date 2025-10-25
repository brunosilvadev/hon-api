# Homeowner Notebook API (hon-api)

A RESTful API built with ASP.NET Core 6.0 for managing homeowner tasks, reminders, and notes. This application helps homeowners organize maintenance tasks, categorize home-related information, and set reminders for recurring maintenance activities.

## Overview

The Homeowner Notebook API provides a backend service for tracking home maintenance cards with categorization and reminder capabilities. It uses Entity Framework Core with MySQL for data persistence and exposes a clean REST API with Swagger documentation.

## Technology Stack

- **Framework**: ASP.NET Core 9.0 (Minimal APIs)
- **Database**: MySQL 8.0
- **ORM**: Entity Framework Core 9.0
- **API Documentation**: Swagger/OpenAPI
- **CORS**: Configured for `http://localhost:4200` (Angular frontend)

## Architecture

### Data Models

The application uses the following domain models:

- **Card**: Main entity representing a homeowner task or note
  - Properties: `CardId`, `CardName`, `CardContent`, `CategoryId`, `ReminderId`
  - Related entities: `Category` (optional), `Reminder` (optional)

- **Category**: Organizes cards into groups (e.g., "Misc", "HVAC", "Plumbing")
  - Properties: `CategoryId`, `CategoryName`

- **Reminder**: Tracks time-based notifications for cards
  - Properties: `ReminderId`, `ReminderName`, `IsActive`, `DateTime`

- **SampleModel**: Demo/testing entity
  - Properties: `SampleId`, `SampleName`

### Database Layer

- **HonDbContext**: Entity Framework DbContext managing all entities with relationships
  - Cards have optional foreign keys to Categories and Reminders
  - Relationships configured with `SET NULL` on delete behavior
  - Auto-creates database schema on startup

- **HonDatabaseService**: Repository pattern implementation
  - Implements `IDatabaseService` interface
  - Handles all database operations with async/await pattern
  - Includes eager loading for related entities (Cards with Categories)

### Dependency Injection

Configured in `DependencyInitializer.cs`:
- Database context with hardcoded MySQL connection string
- Scoped database service
- Swagger/OpenAPI documentation generation

## API Endpoints

### Sample Endpoints (Demo/Testing)
- `GET /list` - Retrieve all samples
- `GET /get{id}` - Get a specific sample by ID
- `POST /create` - Create a new sample
- `PUT /update` - Update an existing sample
- `DELETE /delete{id}` - Delete a sample by ID

### Card Management
- `GET /cards` - List all cards with their categories
- `POST /add-card` - Add a new card

### Category Management
- `GET /categories` - List all categories

## Database Setup

The application connects to a MySQL database with the following configuration:
- **Server**: localhost
- **Port**: 3306
- **Database**: test_db
- **User**: root
- **Password**: Database01!

SQL scripts for table creation are provided in the `SQL/` directory:
- `card.sql` - Card table with foreign key constraints
- `category.sql` - Category table with initial "Misc" category
- `reminder.sql` - Reminder table
- `sample.sql` - Sample table for testing

## Running the Application

1. Ensure MySQL is running locally with the configured credentials
2. The database schema will be automatically created on first run
3. Launch the application - Swagger UI will be available at the root URL (`/`)
4. The API will be accessible on the configured port with CORS enabled for localhost:4200

## API Documentation

Swagger UI is configured as the default landing page, providing:
- Interactive API documentation
- Request/response schemas
- Testing capabilities for all endpoints

## Future Enhancements

See `ideas.md` for planned features:
- Card template system with user acceptance workflow
- Multi-user support with card-to-user mapping
- Enhanced reminder scheduling and notification system