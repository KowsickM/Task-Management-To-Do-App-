# 🗂️ Task Management To-Do Application

A simple and efficient **Task Management System** built using **C#**, **ASP.NET Core MVC**, **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**.

---

## ✨ Features
- ✅ Full **CRUD** operations (Create, Read, Update, Delete) for tasks  
- 🔍 **Search** tasks by title (instant search)  
- 🎯 **Filter** tasks by status — *Pending*, *In Progress*, *Completed*  
- 🕒 **Track creation date** for each task  
- 💬 **SweetAlert2** for success/error popups  
- 🎨 **Responsive UI** using **Bootstrap 5.3**  

---

## 🧩 Project Structure

| Layer | Technology |
|-------|-------------|
| **Frontend (UI)** | ASP.NET Core MVC (Razor Views), Bootstrap 5.3, SweetAlert2 |
| **Backend (API)** | ASP.NET Core Web API |
| **Database** | Microsoft SQL Server |
| **ORM** | Entity Framework Core |
| **Language** | C# (.NET 8.0) |



## 🧱 Prerequisites

Make sure you have these installed before running the project:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [Microsoft SQL Server / SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/)
- **Entity Framework Core packages:**
  ```powershell
  Install-Package Microsoft.EntityFrameworkCore.SqlServer


## Connection String 

In appsettings.json of the API project, update the connection string:

"ConnectionStrings": {
  "DefaultConnection": "Data Source=YOUR_SERVER_NAME;Initial Catalog=TaskDb;User ID=sa;Password=yourpassword;TrustServerCertificate=True;"
}

![Create Task](./ScreenShots/Create.png)
![Task List](./ScreenShots/List.png)
![Edit Task](./ScreenShots/Edit.png)
![Delete Task](./ScreenShots/Delete.png)
