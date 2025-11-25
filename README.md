# 🚀 Freedom – Service Marketplace (ASP.NET Core MVC)

<p align="center">
  <strong>A custom service marketplace built with ASP.NET Core MVC</strong><br/>
  Listings, workers, admin approval workflow & clean architecture.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/stack-ASP.NET%20Core%20MVC-blue" />
  <img src="https://img.shields.io/badge/database-SQL%20Server-success" />
  <img src="https://img.shields.io/badge/style-Bootstrap%205-informational" />
  <img src="https://img.shields.io/badge/status-Work%20in%20Progress-yellow" />
</p>

---

## 🧠 Project Idea

**Freedom** is a service marketplace where users can create job listings (tasks, gigs, work requests) and connect with workers.

The goals:

- Build a **realistic, production-style** ASP.NET Core MVC app  
- Practice **clean architecture**, role-based access, and workflows  
- Use it as a **portfolio project** to land a remote C#/.NET developer position  
- Provide a foundation for future extensions (AI meal planner app, advanced worker features, etc.)

---

## ✨ Current Features

### 👤 Public Users

- Register / log in via ASP.NET Core Identity
- Create new listings with:
  - Title, description, budget, category, location address
- View:
  - **All approved & active** listings
  - **My Listings**: your own listings, including pending and rejected
- Edit or delete your own listings

### 🛠 Listings Workflow

Each listing has:

- `ListingStatus`:
  - `Pending` → waiting for admin review  
  - `Active` → visible to everyone  
  - `Rejected` → archived by admin  
- `IsApproved`:
  - Controls whether the listing is available publicly

Creation flow right now:

1. User creates a listing → `Status = Pending`, `IsApproved = false`
2. Admin approves → `Status = Active`, `IsApproved = true`
3. Admin rejects → `Status = Rejected`, `IsApproved = false` (hidden from public, but still stored)

---

## 🛡 Admin Area

The app includes a dedicated **Admin Area** under `/Admin`, with its own controllers and views.

### 🔐 Security

- Admin area uses:
  - `AdminBaseController` with:
    - `[Area("Admin")]`
    - `[Authorize(Roles = "Admin")]`
- Only users in the **Admin** role can access it
- Admin actions that change data use `[ValidateAntiForgeryToken]`

### 📋 Admin Features

- Admin dashboard at:

  ```
  /Admin
  ```

- Pending listings management:

  ```
  /Admin/ListingApproval/Pending
  ```

Admins can:

- **Approve** a listing → it becomes public  
- **Reject** a listing → set to `Rejected` and archived

- - **Approve** a worker → can take listings that have not already been taken  
- **Reject** a worker → set to `Rejected` and will essentially be kept as a normal user  

---

## 🧱 Domain Snapshot

### Listing

Represents a service request.

Properties:

- Id, Title, Description, LocationAddress  
- Budget, ListingStatus, IsApproved  
- WorkerTypeCategoryId, UploaderId  
- WorkerId (optional)

### Worker

Represents a worker who can claim listings.
Must be approved by an admin in order to take listings.

### WorkerTypeCategory

Categories for listings/workers.

---

## 🧪 Tech Stack

- ASP.NET Core 10 MVC  
- Entity Framework Core 10  
- SQL Server  
- Identity  
- Bootstrap 5  
- Repository + Service layer architecture  

---

## ▶️ Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/stefanzcu/freedom.git
cd freedom
```

### 2. Set up the database

Edit `appsettings.json` or `secrets.json` with your SQL connection.

Run migrations:

```bash
dotnet ef database update
```

### 3. Run the app

```bash
dotnet run
```

### Guest Login

```
Email: guest@gmail.com
Password: guest123
Role: Normal User
```


### Admin Login

```
Email: admin@freedom.bg
Password: Admin123!
Role: Admin
```

---

## 🧭 Roadmap

- √ Listing approval workflow  
- √ Worker approval workflow  
- → Worker profiles 
- → Improved public UI  
- → AI-powered meal planning app (separate project)

---

## 🎯 Why this project matters

Freedom demonstrates:

- Real **ASP.NET Core MVC** experience  
- Proper use of Identity, Areas, Auth, Anti-forgery  
- Clean architecture and real workflows  
- Bootstrap-based UI  
- A portfolio-ready foundation for applying to .NET developer jobs  
