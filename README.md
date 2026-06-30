# Enterprise E-Commerce API

A production-ready ASP.NET Core REST API for an e-commerce platform, demonstrating enterprise-level architecture patterns, comprehensive CI/CD pipeline, security practices, and code quality standards.

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![License](https://img.shields.io/badge/License-MIT-green)
[![Build Status](https://github.com/YOUR_USERNAME/ecommerce-api/actions/workflows/dotnet-enterprise-cicd.yml/badge.svg)](https://github.com/YOUR_USERNAME/ecommerce-api/actions)

---

## 📋 Project Overview

This is a **real-world enterprise application** that showcases:

- ✅ **Clean Architecture** - Separation of concerns across layers
- ✅ **Domain-Driven Design** - Rich domain models with business logic
- ✅ **SOLID Principles** - Maintainable, scalable code
- ✅ **Enterprise CI/CD Pipeline** - 9 stages including security scanning
- ✅ **Comprehensive Testing** - Unit & integration tests with high coverage
- ✅ **Security First** - Code scanning, dependency checks, SAST analysis
- ✅ **Docker Containerization** - Production-ready container image
- ✅ **API Documentation** - Swagger/OpenAPI integration
- ✅ **Database Migrations** - Entity Framework Core with migrations
- ✅ **Structured Logging** - Serilog for enterprise logging

---

## 🏗️ Architecture

```
┌─────────────────────────────────────────────────────────┐
│                   API Layer                              │
│  (EcommerceApi.Api - Controllers, Endpoints)            │
└─────────────────────────────────────────────────────────┘
                         ↓
┌─────────────────────────────────────────────────────────┐
│               Application Layer                         │
│  (Services, DTOs, Validation, AutoMapper)              │
└─────────────────────────────────────────────────────────┘
                         ↓
┌─────────────────────────────────────────────────────────┐
│               Domain Layer                              │
│  (Entities, Aggregates, Value Objects, Repositories)   │
└─────────────────────────────────────────────────────────┘
                         ↓
┌─────────────────────────────────────────────────────────┐
│            Infrastructure Layer                         │
│  (EF Core, Database, Logging, External Services)       │
└─────────────────────────────────────────────────────────┘
```

---

## 📁 Project Structure

```
ecommerce-api/
├── src/
│   ├── EcommerceApi.Api/              ← REST API endpoints, controllers
│   ├── EcommerceApi.Domain/           ← Domain entities, business rules
│   ├── EcommerceApi.Application/      ← Services, DTOs, validation
│   └── EcommerceApi.Infrastructure/   ← Data access, logging, migrations
├── tests/
│   ├── EcommerceApi.Tests.Unit/       ← Unit tests (Domain & Application)
│   └── EcommerceApi.Tests.Integration/ ← Integration tests with database
├── .github/
│   └── workflows/
│       └── dotnet-enterprise-cicd.yml  ← 9-stage CI/CD pipeline
├── Dockerfile                          ← Container image definition
├── docker-compose.yml                  ← Local development environment
└── EcommerceApi.sln                    ← Solution file
```

---

## 🚀 CI/CD Pipeline Stages

The comprehensive GitHub Actions pipeline includes:

| Stage | Purpose | Triggers |
|-------|---------|----------|
| **1. Build** | Restore & compile code | All pushes & PRs |
| **2. Security Scan** | CodeQL + Dependency check | All pushes & PRs |
| **3. Unit Tests** | Domain & Application tests | All pushes & PRs |
| **4. Integration Tests** | API tests with PostgreSQL | All pushes & PRs |
| **5. Code Quality** | SonarQube analysis | All pushes & PRs |
| **6. Docker Build** | Container image creation | All pushes & PRs |
| **7. Publish** | Create deployment artifacts | All pushes & PRs |
| **8. Deploy Staging** | Deploy to staging | Merge to develop |
| **9. Deploy Production** | Deploy to production | Merge to main |

---

## 🔒 Security Features

- ✅ **CodeQL Static Analysis** - Automated code scanning for vulnerabilities
- ✅ **Dependency Vulnerability Scanning** - Check NuGet packages for known issues
- ✅ **Code Coverage Reports** - Track test coverage with Coverlet
- ✅ **JWT Authentication** - Secure API token-based authentication
- ✅ **HTTPS Enforced** - TLS/SSL in production
- ✅ **Docker Non-Root User** - Container runs as unprivileged user
- ✅ **Input Validation** - FluentValidation on all endpoints
- ✅ **Health Checks** - Liveness & readiness probes

---

## 🧪 Testing Strategy

### Unit Tests
- Domain entity business logic
- Application service validation
- Test coverage: >80%

### Integration Tests
- API endpoint functionality
- Database operations (PostgreSQL)
- Authentication flows
- Error handling scenarios

Run tests locally:
```bash
# Unit tests
dotnet test tests/EcommerceApi.Tests.Unit

# Integration tests (requires Docker for PostgreSQL)
dotnet test tests/EcommerceApi.Tests.Integration

# All tests with coverage
dotnet test EcommerceApi.sln --collect:"XPlat Code Coverage"
```

---

## 📦 Key Technologies

| Component | Technology | Version |
|-----------|-----------|---------|
| Runtime | .NET | 8.0 |
| Web Framework | ASP.NET Core | 8.0 |
| ORM | Entity Framework Core | 8.0 |
| Database | PostgreSQL | 15+ |
| Testing | xUnit + Moq | 2.6+ |
| Validation | FluentValidation | 11.9+ |
| Logging | Serilog | 3.1+ |
| API Docs | Swagger/OpenAPI | 6.4+ |
| Containerization | Docker | Latest |
| CI/CD | GitHub Actions | Native |

---

## 🏃 Running Locally

### Prerequisites
- .NET 8 SDK
- Docker Desktop (for PostgreSQL)
- Git

### Setup

1. **Clone repository**
   ```bash
   git clone https://github.com/YOUR_USERNAME/ecommerce-api.git
   cd ecommerce-api
   ```

2. **Start PostgreSQL**
   ```bash
   docker-compose up -d postgres
   ```

3. **Run database migrations**
   ```bash
   dotnet ef database update --project src/EcommerceApi.Infrastructure
   ```

4. **Run the API**
   ```bash
   dotnet run --project src/EcommerceApi.Api
   ```

5. **Access Swagger UI**
   ```
   https://localhost:5001/swagger
   ```

---

## 🔄 Git Workflow

```
main                 [Production - fully tested]
  ↑
  └─ Pull Request ← develop
       (Pipeline validates)
                     [Staging - integration ready]
                          ↑
                          └─ feature/xyz
                             [Development - work in progress]
```

### Creating a feature:
```bash
git checkout develop
git pull origin develop
git checkout -b feature/add-payment-integration
# Make changes...
git add .
git commit -m "feat: add payment processing"
git push origin feature/add-payment-integration
# Create Pull Request on GitHub
```

---

## 📊 API Endpoints

### Products
```
GET    /api/products              # List all products
GET    /api/products/{id}         # Get product details
POST   /api/products              # Create product
PUT    /api/products/{id}         # Update product
DELETE /api/products/{id}         # Delete product
```

### Categories
```
GET    /api/categories            # List categories
POST   /api/categories            # Create category
PUT    /api/categories/{id}       # Update category
```

---

## 🐳 Docker Deployment

Build and run with Docker:

```bash
# Build image
docker build -t ecommerce-api:latest .

# Run container
docker run -p 5000:5000 \
  -e ConnectionStrings__DefaultConnection="..." \
  ecommerce-api:latest
```

---

## 📈 Code Quality Metrics

| Metric | Target |
|--------|--------|
| Code Coverage | >80% |
| Cyclomatic Complexity | <10 |
| CodeQL Warnings | 0 |
| Vulnerabilities (NuGet) | 0 |
| Test Pass Rate | 100% |

---

## 🤝 Contributing

1. **Branch Naming**: `feature/`, `bugfix/`, `hotfix/` prefixes
2. **Commit Messages**: Conventional commits (`feat:`, `fix:`, `docs:`)
3. **Code Style**: Follow .NET conventions, enforced by EditorConfig
4. **Tests**: Add tests for new features, maintain >80% coverage
5. **Documentation**: Update README and API docs

---

## 📝 Environment Variables

```env
# Database
ConnectionStrings__DefaultConnection=Server=localhost;Database=ecommerce;User Id=postgres;Password=postgres;

# JWT
Jwt__Key=your-secret-key-here
Jwt__Issuer=ecommerce-api
Jwt__Audience=ecommerce-web

# Logging
Serilog__MinimumLevel=Information
Serilog__WriteTo__Console=true

# Database
DatabaseProvider=PostgreSQL
```

---

## 🐛 Troubleshooting

### Connection to PostgreSQL fails
```bash
# Check if container is running
docker ps

# View logs
docker-compose logs postgres

# Restart
docker-compose restart postgres
```

### Tests fail
```bash
# Clean build
dotnet clean

# Restore packages
dotnet restore

# Run tests with verbose output
dotnet test -v normal
```

### Port already in use
```bash
# Find and kill process on port 5000
lsof -i :5000
kill -9 <PID>
```

---

## 📞 Support

- **Issues**: Report on GitHub Issues
- **Discussions**: Use GitHub Discussions
- **Security**: Report security vulnerabilities to security@example.com

---

## 📄 License

This project is licensed under MIT License - see LICENSE file for details.

---

## 🙌 Acknowledgments

- Built with .NET 8
- Inspired by Clean Architecture & DDD principles
- Community contributions welcome!

---

## 📚 Related Resources

- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Domain-Driven Design](https://www.domainlanguage.com/ddd/)
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)
- [GitHub Actions](https://github.com/features/actions)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
