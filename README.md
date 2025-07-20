# ESports Match Tracker Backend API

A .NET 9.0 Web API for tracking and managing ESports matches with real-time match data management capabilities.

## 🏗️ Architecture

This project follows a clean architecture pattern with:

- **Controllers**: HTTP endpoints for match operations
- **Services**: Business logic layer
- **Repositories**: Data access layer with caching
- **Entities**: Database models
- **DTOs/ViewModels**: Data transfer objects

## 🚀 Features

- **Match Management**: Create, read, update, and delete ESports matches
- **Multiple Game Support**: Track matches across different games
- **Match Status Tracking**: Live, scheduled, and ended match states
- **Caching**: Redis-style memory caching for improved performance
- **Database Migrations**: Entity Framework Core with SQL Server
- **Unit Testing**: Comprehensive test coverage
- **CORS Support**: Cross-origin resource sharing enabled
- **OpenAPI/Swagger**: API documentation and testing

## 🛠️ Tech Stack

- **.NET 9.0**: Latest .NET framework
- **ASP.NET Core Web API**: RESTful API framework
- **Entity Framework Core**: ORM for database operations
- **SQL Server**: Primary database
- **Memory Caching**: Built-in caching mechanism
- **xUnit**: Unit testing framework
- **Scrutor**: Decorator pattern implementation
- **Docker**: Containerization support

## 📋 Prerequisites

- .NET 9.0 SDK
- SQL Server (or SQL Server Express)
- Docker (optional, for containerized deployment)

## 🚀 Getting Started

### Local Development

1. **Clone the repository**

   ```bash
   git clone <repository-url>
   cd backend
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Update database connection string**

   Edit `appsettings.Development.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost,1433;Database=ESportsMatchTracker;User Id=sa;Password=P@ssW0rd;TrustServerCertificate=True;"
     }
   }
   ```

4. **Run database migrations**

   ```bash
   dotnet ef database update
   ```

5. **Run the application**

   ```bash
   dotnet run --project ESportsMatchTracker.API
   ```

The API will be available at `https://localhost:7000` and `http://localhost:5000`.

### Docker Development

1. **Start the SQL Server container**

   ```bash
   # From the root directory
   docker-compose up sqlserver -d
   ```

2. **Run migrations and start the API**

   ```bash
   dotnet ef database update
   dotnet run --project ESportsMatchTracker.API
   ```

## 📚 API Endpoints

### Match Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/match/all` | Get all matches |
| POST | `/api/v1/match` | Create a new match |
| PUT | `/api/v1/match` | Update an existing match |
| DELETE | `/api/v1/match/{id}` | Delete a match by ID |

### Sample Request/Response

**GET `/api/v1/match/all`**

```json
[
  {
    "id": 1,
    "game": "League of Legends",
    "teams": ["Team A", "Team B"],
    "status": "live",
    "stage": "semifinals",
    "tournament": "World Championship",
    "streamUrl": "https://twitch.tv/match1",
    "matchDetails": {
      "maps": [...],
      "scores": [...]
    }
  }
]
```

**POST `/api/v1/match`**

```json
{
  "game": "Counter-Strike 2",
  "teams": ["Fnatic", "Astralis"],
  "status": "scheduled",
  "stage": "group",
  "tournament": "Major Championship",
  "streamUrl": "https://twitch.tv/match2",
  "matchDetails": {
    "maps": ["de_dust2", "de_mirage"],
    "scores": []
  }
}
```

## 🗄️ Database Schema

The application uses a single `Matches` table with the following structure:

- `id` (Primary Key)
- `game` (Game name)
- `teams` (JSON array of team names)
- `status` (match status: live, scheduled, ended)
- `stage` (tournament stage)
- `tournament` (tournament name)
- `stream_url` (streaming URL)
- `match_details` (JSON object with maps and scores)
- `created_on` (creation timestamp)
- `modified_on` (last modification timestamp)

## 🧪 Testing

Run unit tests:

```bash
dotnet test
```

The test suite includes:

- Controller tests
- Service layer tests
- Repository tests

## 🔧 Configuration

### Environment Variables

- `ConnectionStrings__DefaultConnection`: Database connection string
- `ASPNETCORE_ENVIRONMENT`: Development/Production/Staging

### Application Settings

Key configuration files:

- `appsettings.json`: Production settings
- `appsettings.Development.json`: Development settings
- `launchSettings.json`: Launch profiles

## 📦 Docker Support

Build the Docker image:

```bash
docker build -t esports-api .
```

Run with Docker Compose:

```bash
# From root directory
docker-compose up
```

## 🚀 Deployment

### Production Deployment

1. **Build the application**

   ```bash
   dotnet publish -c Release -o ./publish
   ```

2. **Configure production settings**
   - Update connection strings
   - Set environment variables
   - Configure CORS policies

3. **Run database migrations**

   ```bash
   dotnet ef database update --environment Production
   ```

## 📈 Performance Features

- **Memory Caching**: Implements decorator pattern for repository caching
- **Async/Await**: All database operations are asynchronous
- **Connection Pooling**: Entity Framework connection management
- **Optimized Queries**: Efficient database queries

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Write tests for new functionality
4. Ensure all tests pass
5. Submit a pull request

## 📝 License

This project is licensed under the MIT License.

## 🐛 Troubleshooting

### Common Issues

1. **Database Connection Issues**
   - Verify SQL Server is running
   - Check connection string format
   - Ensure firewall allows connections

2. **Migration Issues**

   ```bash
   dotnet ef migrations add <MigrationName>
   dotnet ef database update
   ```

3. **CORS Issues**
   - Check CORS policy configuration
   - Verify allowed origins in production

## 📞 Support

For support and questions, please create an issue in the repository or contact the development team.
