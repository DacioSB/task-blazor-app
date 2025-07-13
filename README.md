# Globomantics ToDo - Blazor Bug & Feature Tracker

A modern, full-featured bug tracking and feature management application built with Blazor Server, Entity Framework Core, and Azure Blob Storage integration.

## 🚀 Features

### Core Functionality
- **Bug Tracking**: Create, edit, and manage software bugs with detailed information
- **Feature Management**: Track feature requests and development tasks
- **Task Organization**: Separate views for unfinished and completed items
- **Search & Filter**: Real-time search across bugs and features
- **Status Management**: Mark items as completed/incomplete with visual feedback

### Bug Management
- **Severity Levels**: Critical, High, Medium, Low priority classification
- **Version Tracking**: Track affected software versions
- **User Impact**: Record number of affected users
- **Screenshot Support**: Upload and attach screenshots via Azure Blob Storage
- **Bug Relationships**: Link bugs to parent bugs for hierarchical organization

### Feature Management
- **Due Date Tracking**: Set and monitor feature delivery dates
- **Feature Relationships**: Link features to parent features
- **Priority Management**: Organize features by importance

### Technical Features
- **Modern UI**: Dark theme with responsive design using Radzen Blazor components
- **Real-time Updates**: Interactive server-side rendering
- **Cloud Storage**: Azure Blob Storage integration for file uploads
- **Database**: SQLite with Entity Framework Core
- **Clean Architecture**: Repository pattern with service layer abstraction

## 🛠️ Technology Stack

- **Framework**: .NET 8.0 / Blazor Server
- **Database**: SQLite with Entity Framework Core 8.0
- **UI Components**: Radzen Blazor 6.5.2
- **Cloud Storage**: Azure Blob Storage
- **Architecture**: Repository Pattern, Dependency Injection
- **Code Analysis**: Microsoft.CodeAnalysis.CSharp.Workspaces

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- Azure Storage Account (for screenshot uploads)

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone <repository-url>
cd blazor_complete_project
```

### 2. Configure Azure Blob Storage
Update `appsettings.json` and `appsettings.Development.json` with your Azure Blob Storage connection string:

```json
{
  "AzureBlob": {
    "ConnectionString": "your-azure-storage-connection-string",
    "ContainerName": "screenshots"
  }
}
```

### 3. Database Setup
The application uses SQLite with Entity Framework Core. The database will be created automatically on first run.

To manually run migrations:
```bash
cd CompleteProject
dotnet ef database update
```

### 4. Install Dependencies
```bash
cd CompleteProject
dotnet restore
```

### 5. Run the Application
```bash
dotnet run
```

The application will be available at:
- HTTP: `http://localhost:5036`
- HTTPS: `https://localhost:7284`

## 📁 Project Structure

```
CompleteProject/
├── Components/
│   ├── Layout/
│   │   └── MainLayout.razor          # Main application layout
│   └── Pages/
│       ├── Home.razor                # Home page
│       ├── Hello.razor               # Hello page
│       └── TodoList.razor            # Main todo/bug tracker interface
├── Data/
│   ├── ApplicationDbContext.cs       # Entity Framework context
│   ├── BugRepository.cs              # Bug data access
│   ├── FeatureRepository.cs          # Feature data access
│   ├── IBugRepository.cs             # Bug repository interface
│   ├── IFeatureRepository.cs         # Feature repository interface
│   └── todo.db                       # SQLite database file
├── Migrations/                       # Entity Framework migrations
├── Models/
│   └── TodoItem.cs                   # Data models (TodoItem, Bug, Feature)
├── Services/
│   ├── AzurePhotoService.cs          # Azure Blob Storage service
│   ├── BugService.cs                 # Bug business logic
│   ├── FeatureService.cs             # Feature business logic
│   ├── IBugService.cs                # Bug service interface
│   └── IFeatureService.cs            # Feature service interface
├── ViewModels/
│   ├── BugListViewModel.cs           # Bug list view model
│   └── FeatureListViewModel.cs       # Feature list view model
├── wwwroot/                          # Static web assets
├── Properties/
│   └── launchSettings.json           # Launch configuration
├── Program.cs                        # Application entry point
└── CompleteProject.csproj            # Project file
```

## 🎨 User Interface

The application features a modern dark theme with:
- **Color Palette**: Custom color scheme with licorice, midnight green, icterine, and pumpkin colors
- **Responsive Design**: Works on desktop and mobile devices
- **Interactive Components**: Real-time search, drag-and-drop functionality
- **Visual Feedback**: Status indicators, severity badges, and completion states

### Main Features:
1. **Header Section**: Quick access to create new bugs and features
2. **Search Bar**: Real-time filtering of items
3. **Task Lists**: Separate sections for unfinished bugs, features, and completed items
4. **Sidebar**: Detailed editing panel for selected items
5. **File Upload**: Screenshot attachment for bugs

## 🔧 Configuration

### Database Configuration
The SQLite database path is configured in `Program.cs`:
```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=/path/to/todo.db"));
```

### Azure Blob Storage
Configure in `appsettings.json`:
```json
{
  "AzureBlob": {
    "ConnectionString": "DefaultEndpointsProtocol=https;AccountName=...",
    "ContainerName": "screenshots"
  }
}
```

## 🏗️ Architecture

The application follows clean architecture principles:

- **Presentation Layer**: Blazor components and pages
- **Business Logic Layer**: Services with interfaces
- **Data Access Layer**: Repositories with Entity Framework
- **Models**: Domain entities and data transfer objects

### Key Patterns:
- **Repository Pattern**: Abstracted data access
- **Dependency Injection**: Loose coupling between components
- **MVVM**: ViewModels for complex UI logic
- **Service Layer**: Business logic separation

## 🧪 Development

### Adding New Features
1. Create model in `Models/`
2. Add DbSet to `ApplicationDbContext`
3. Create migration: `dotnet ef migrations add <MigrationName>`
4. Implement repository interface and class
5. Create service interface and implementation
6. Register services in `Program.cs`
7. Create Blazor components

### Database Migrations
```bash
# Add new migration
dotnet ef migrations add <MigrationName>

# Update database
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

## 📦 Dependencies

### Core Dependencies
- **Microsoft.EntityFrameworkCore.Sqlite** (8.0.0) - Database ORM
- **Microsoft.EntityFrameworkCore.Design** (8.0.0) - EF Core tools
- **Azure.Storage.Blobs** (12.24.1) - Azure Blob Storage client
- **Radzen.Blazor** (6.5.2) - UI component library
- **Microsoft.CodeAnalysis.CSharp.Workspaces** (4.8.0) - Code analysis tools

## 🚀 Deployment

### Local Development
```bash
dotnet run --project CompleteProject
```

### Production Build
```bash
dotnet publish -c Release -o ./publish
```

### Docker (Optional)
Create a `Dockerfile` in the project root:
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CompleteProject/CompleteProject.csproj", "CompleteProject/"]
RUN dotnet restore "CompleteProject/CompleteProject.csproj"
COPY . .
WORKDIR "/src/CompleteProject"
RUN dotnet build "CompleteProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompleteProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompleteProject.dll"]
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🐛 Known Issues

- Screenshot upload requires Azure Blob Storage configuration
- Database path is hardcoded in Program.cs (should be configurable)
- No user authentication/authorization implemented

## 🔮 Future Enhancements

- [ ] User authentication and authorization
- [ ] Email notifications for bug assignments
- [ ] Advanced reporting and analytics
- [ ] REST API for mobile app integration
- [ ] Real-time collaboration features
- [ ] Export functionality (PDF, Excel)
- [ ] Advanced search and filtering options
- [ ] Bulk operations for bugs and features

## 📞 Support

For support and questions, please open an issue in the GitHub repository.

---

**Built with ❤️ using Blazor Server and .NET 8**
