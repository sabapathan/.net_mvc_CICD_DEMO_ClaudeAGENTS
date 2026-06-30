# Quick Start Guide - Enterprise E-Commerce API

## 🚀 5 Minutes to Running Locally

### Prerequisites
- .NET 8 SDK installed
- Docker Desktop installed
- Git installed

---

## Step 1: Clone & Setup (1 min)

```bash
git clone https://github.com/YOUR_USERNAME/ecommerce-api.git
cd ecommerce-api
```

---

## Step 2: Start Database (1 min)

```bash
docker-compose up -d postgres
```

Verify PostgreSQL is running:
```bash
docker ps
```

---

## Step 3: Run the API (1 min)

```bash
dotnet run --project src/EcommerceApi.Api
```

You should see:
```
info: Starting E-Commerce API application...
info: Application started at https://localhost:5001
```

---

## Step 4: Test the API (1 min)

Open your browser or Postman:
```
https://localhost:5001/swagger
```

---

## Step 5: Run Tests (1 min)

```bash
# Unit tests
dotnet test tests/EcommerceApi.Tests.Unit

# All tests
dotnet test
```

---

## 📂 Key Files to Edit

| File | Purpose |
|------|---------|
| `src/EcommerceApi.Api/appsettings.Development.json` | Database connection, JWT settings |
| `docker-compose.yml` | PostgreSQL password, ports |
| `EcommerceApi.sln` | Solution file - open in Visual Studio |

---

## 🔧 Common Commands

```bash
# View logs
docker logs ecommerce-db

# Stop everything
docker-compose down

# Rebuild and restart
docker-compose up -d --build

# Access database admin
http://localhost:8080  (Adminer)
```

---

## 🌍 Environment Setup

Create `.env` file (optional):
```env
DATABASE_PASSWORD=yourpassword
JWT_KEY=your-secret-key
```

---

## 📊 Verify Setup

Check health:
```bash
curl https://localhost:5001/health
```

Check Swagger:
```
https://localhost:5001/swagger/v1/swagger.json
```

---

## 🎯 Next Steps

1. **Explore the API**: Try endpoints in Swagger UI
2. **Read the Architecture**: Check `README.md`
3. **Run Tests**: See test coverage with `dotnet test`
4. **Create a Feature**: Branch with `git checkout -b feature/your-feature`
5. **Push & Create PR**: GitHub Actions will validate everything

---

## ❌ Troubleshooting

**Port 5000 already in use?**
```bash
lsof -i :5000
kill -9 <PID>
```

**PostgreSQL won't start?**
```bash
docker-compose down -v
docker-compose up -d postgres
```

**Swagger not loading?**
- Check if API is running: `dotnet run --project src/EcommerceApi.Api`
- Make sure using HTTPS: `https://localhost:5001/swagger`

---

## 📞 Need Help?

Check `README.md` for detailed documentation or file an issue on GitHub.

Happy coding! 🎉
