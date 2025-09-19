
# Mini Project - Master Dashboard

Aplikasi web untuk mengelola data master "research" dibangun dengan **Next.js** sebagai frontend dan **.NET Web API** sebagai backend.

-----

### **Fitur Utama** 🚀

  * **Pengelolaan Data Master**: Fitur CRUD (Create, Read, Update, Delete) untuk data *sample type*.
  * **Pencarian**: Pencarian data secara *real-time* untuk memudahkan navigasi.
  * **Pagination**: Tampilan data yang terorganisir per halaman.
  * **Tampilan Responsif**: Antarmuka pengguna yang adaptif di berbagai ukuran layar.
  * **Sidebar Navigasi**: Menu navigasi yang jelas untuk akses cepat ke fitur-fitur lain.

-----

# 🧪 Master Lab Management System

Laboratory management system built with **Next.js 14** and **.NET 8 Web API** for managing analyses, parameters, sample types, and methods.

## 📋 About

This application provides CRUD operations for laboratory data management with the following entities:
- **Analyses** - Laboratory analysis records with method relationships
- **Parameters** - Laboratory parameter definitions  
- **Sample Types** - Sample type classifications
- **Methods** - Testing method documentation

## 🏗️ Tech Stack

**Frontend:** Next.js 14, JavaScript, Tailwind CSS, Shadcn/ui  
**Backend:** .NET 8 Web API, Entity Framework Core, MySQL  
**Database:** MySQL 8.0

## 📁 Project Structure

```
ca-lab-management/
├── 📂 frontend/                    # Next.js Application
│   ├── 📂 app/                     # App Router Pages
│   │   |        
│   │   │── 📂 analyses/        
│   │   │── 📂 parameters/      
│   │   │── 📂 sample-types/    
│   │   │── 📂 methods/         
│   │   ├── 📂 layout.tsx           
│   │   └── 📂 page.tsx             
│   ├── 📂 components/              # UI Components
│   │   ├── 📂 ui/                  # Shadcn/ui components
│   │   └── 📂 forms/               # Form components
│    
├── 📂 backend/                     # .NET Web API
│   ├── 📂 Controllers/             # API Controllers
│   ├── 📂 Data/                    # DbContext
│   ├── 📂 Models/                  # Entity Models
│   ├── 📂 Services/                # Business Logic
│   ├── 📂 Program.cs               
│   └── 📂 appsettings.json         
└── 📂 logic_Test/                    # logic test
    └── 📄 Answer file               
```

## 🚀 Getting Started

### Prerequisites
- Node.js 18+ 
- .NET 9 SDK
- MySQL 8.0+

### 1. Database Setup

```sql
-- Create database first
Database Schema
Entity Relationship Diagram
mermaiderDiagram
    m_ca_parameters {
        int id PK
        varchar created_by
        datetime created_on
        varchar last_updated_by
        datetime last_updated_on
        tinyint is_active
        varchar code
        varchar description
    }
    
    m_ca_methods {
        int id PK
        varchar created_by
        datetime created_on
        varchar last_updated_by
        datetime last_updated_on
        tinyint is_active
        varchar code
        varchar description
    }
    
    m_ca_sample_types {
        int id PK
        varchar created_by
        datetime created_on
        varchar last_updated_by
        datetime last_updated_on
        tinyint is_active
        varchar code
        varchar description
    }
    
    m_ca_analyses {
        int id PK
        varchar created_by
        datetime created_on
        varchar last_updated_by
        datetime last_updated_on
        tinyint is_active
        varchar code
        varchar description
        int parameter_id FK
        int method_id FK
        int sample_type_id FK
        varchar lead_time
    }
    
    m_ca_parameters ||--o{ m_ca_analyses : "parameter_id"
    m_ca_methods ||--o{ m_ca_analyses : "method_id"
    m_ca_sample_types ||--o{ m_ca_analyses : "sample_type_id"
```

### 2. Backend Setup (.NET API)

```bash
cd backend

# Install packages
dotnet restore

# Update connection string in appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=db_kalbe;User=root;Password=yourpassword;"
  }
}

# Run the application
dotnet run
```

Backend will run on: `https://localhost:5227`  
Swagger documentation: `https://localhost:5227/swagger`

### 3. Frontend Setup (Next.js)

```bash
cd frontend

# Install dependencies
npm install

# Create environment file
echo "NEXT_PUBLIC_API_URL=https://localhost:5227" > .env.local

# Run development server
npm run dev
```

Frontend will run on: `http://localhost:3000`

## 🌐 API Endpoints

Base URL: `https://localhost:5227/api`

### Available Endpoints
| Entity | GET All | GET by ID | POST | PUT | DELETE |
|--------|---------|-----------|------|-----|--------|
| Analyses | `/analyses` | `/analyses/{id}` | `/analyses` | `/analyses/{id}` | `/analyses/{id}` |
| Parameters | `/parameters` | `/parameters/{id}` | `/parameters` | `/parameters/{id}` | `/parameters/{id}` |
| Sample Types | `/sampletypes` | `/sampletypes/{id}` | `/sampletypes` | `/sampletypes/{id}` | `/sampletypes/{id}` |
| Methods | `/methods` | `/methods/{id}` | `/methods` | `/methods/{id}` | `/methods/{id}` |

### Query Parameters (GET All)
- `pageNumber` - Page number (default: 1)
- `pageSize` - Items per page (default: 10) 
- `search` - Search term

Example: `/api/analyses?pageNumber=1&pageSize=10&search=test`

### Response Format
```json
{
  "data": [...],
  "totalRecords": 100,
  "pageNumber": 1, 
  "pageSize": 10,
  "totalPages": 10,
  "hasPreviousPage": false,
  "hasNextPage": true
}
```

## 📚 Swagger Documentation

Access the interactive API documentation at:
`https://localhost:5227/swagger`

The Swagger UI provides:
- Complete API endpoint documentation
- Request/response schemas
- Interactive testing interface

## 🔧 Development

### Frontend Development
```bash
cd frontend
npm run dev     # Start development server
npm run build   # Build for production  
npm run start   # Start production server
```

### Backend Development
```bash
cd backend
dotnet run              # Start development server
dotnet build           # Build project
dotnet publish         # Publish for production
```
