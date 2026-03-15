# Schedule Service API

ASP.NET Core 8 Web API cho ứng dụng đặt lịch và quản lý dịch vụ tại gia (Nail, Skincare, v.v.)

## 🎯 Tính Năng

- ✅ Quản lý dịch vụ
- ✅ Đặt lịch hẹn
- ✅ Quản lý khách hàng & nhân viên
- ✅ Thanh toán & đánh giá
- ✅ Thống kê & báo cáo

## 🔧 Tech Stack

- **Framework**: ASP.NET Core 8 Web API
- **Database**: SQL Server
- **ORM**: Entity Framework Core 8.0
- **Architecture**: Repository Pattern + Dependency Injection

## 📋 Requirements

- .NET 8.0 SDK
- SQL Server 2019+
- Visual Studio 2022 / VS Code

## 🚀 Setup & Run

### 1. Clone Repository
```bash
git clone https://github.com/hoanghung16/ScheduleService-API.git
cd ScheduleService-API/ScheduleService.API
```

### 2. Restore NuGet Packages
```bash
dotnet restore
```

### 3. Update Database
```bash
dotnet ef database update
```

### 4. Run API
```bash
dotnet run
```

API sẽ chạy tại: `https://localhost:5001`

## 📚 API Documentation

Swagger UI: `https://localhost:5001/swagger`

## 🛢️ Database

**Connection String:**
```
Data Source=HoangHung;Initial Catalog=doanthuctapDB;Integrated Security=True;Encrypt=False
```

**Tables:**
- Users
- Services
- ServiceCategories
- Staff
- Bookings
- Reviews
- Payments

## 📁 Project Structure

```
ScheduleService.API/
├── Controllers/         (API Endpoints)
├── Models/             (Database Models)
├── Services/           (Business Logic)
├── Repositories/       (Data Access)
├── Data/               (DbContext)
├── Migrations/         (EF Core Migrations)
├── Program.cs          (Startup Configuration)
├── appsettings.json    (Configuration)
└── ScheduleService.API.csproj
```

## 🔌 Endpoints

### Users
- `POST /api/users/register` - Đăng ký
- `POST /api/users/login` - Đăng nhập
- `GET /api/users/{id}` - Lấy thông tin
- `PUT /api/users/{id}` - Cập nhật

### Services
- `GET /api/services` - Lấy danh sách
- `GET /api/services/{id}` - Lấy chi tiết
- `POST /api/services` - Tạo (Admin)
- `PUT /api/services/{id}` - Cập nhật (Admin)
- `DELETE /api/services/{id}` - Xóa (Admin)

### Bookings
- `POST /api/bookings` - Đặt lịch
- `GET /api/bookings/user/{userId}` - Lịch của user
- `PUT /api/bookings/{id}/status` - Cập nhật trạng thái
- `DELETE /api/bookings/{id}` - Hủy lịch

## 📝 Environment Variables

Tạo file `appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=HoangHung;Initial Catalog=doanthuctapDB;Integrated Security=True;Encrypt=False"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft": "Information"
    }
  }
}
```

## 🤝 Contributing

1. Fork repository
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open Pull Request

## 📄 License

This project is licensed under the MIT License.

## 📧 Contact

- Email: weew3426@gmail.com
- GitHub: [@hoanghung16](https://github.com/hoanghung16)
