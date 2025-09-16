Tentu, berikut adalah draf untuk file `README.md` yang lengkap dan profesional untuk proyek Anda. File ini dirancang agar informatif dan mudah dipahami, sehingga siapa pun, termasuk pengembang lain, dapat dengan cepat memahami dan menjalankan proyek ini.

-----

# Mini Project - Master Dashboard

Aplikasi web untuk mengelola data master "Sample Type," dibangun dengan **Next.js** sebagai frontend dan **.NET Web API** sebagai backend.

-----

### **Fitur Utama** 🚀

  * **Pengelolaan Data Master**: Fitur CRUD (Create, Read, Update, Delete) untuk data *sample type*.
  * **Pencarian**: Pencarian data secara *real-time* untuk memudahkan navigasi.
  * **Pagination**: Tampilan data yang terorganisir per halaman.
  * **Tampilan Responsif**: Antarmuka pengguna yang adaptif di berbagai ukuran layar.
  * **Sidebar Navigasi**: Menu navigasi yang jelas untuk akses cepat ke fitur-fitur lain.

-----

### **Teknologi yang Digunakan** 🛠️

#### **Frontend**

  * **Next.js**: Framework React untuk pengembangan aplikasi web.
  * **Shadcn/ui**: Koleksi komponen UI yang dapat diakses dan dikustomisasi, dibangun di atas Tailwind CSS.
  * **JavaScript**: Bahasa pemrograman untuk sisi client
  * **Tailwind CSS**: Framework CSS yang efisien untuk styling.
  * **Axios**: Library untuk melakukan HTTP request ke backend.

#### **Backend**

  * **.NET 8 Web API**: Framework untuk membangun API yang kuat dan *scalable*.
  * **C\#**: Bahasa pemrograman utama yang digunakan.
  * **Entity Framework Core**: ORM (Object-Relational Mapper) untuk interaksi dengan database.
  * **mySQL**: Sistem manajemen database relasional.

-----

### **Struktur Proyek** 📂

```
Technical-Test/
├── frontend/
│   ├── components/
│   ├── app/
│   │   ├── (dashboard)/
│   │   │   ├── layout.tsx
│   │   │   ├── page.tsx
│   │   │   └── master-sample-type/
│   │   │       ├── page.tsx
│   │   │       ├── [id]/
│   │   │       │   └── page.tsx
│   │   └── ...
│   └── public/
├── backend/
│   ├── Controllers/
│   │   └── MasterSampleTypeController.cs
│   ├── Models/
│   │   └── MasterSampleType.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── appsettings.json
│   └── ...
└── README.md
```

-----

### **Cara Menjalankan Proyek** ⚙️

#### **Prasyarat**

Pastikan Anda sudah menginstal:

  * **Node.js & npm**
  * **.NET SDK 8** atau versi terbaru
  * **mySQL** atau database lain yang kompatibel
  * **Visual Studio Code** atau IDE pilihan Anda

#### **Langkah 1: Konfigurasi Database (Backend)**

1.  Buka folder `backend/` di IDE Anda.
2.  Buka file `appsettings.json` dan ubah `DefaultConnection` string ke koneksi database Anda.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YourDbName;..."
    }
    ```
3.  Jalankan migrasi database dari terminal di folder `backend/` untuk membuat tabel:
    ```bash
    dotnet ef database update
    ```
4.  Jalankan backend API:
    ```bash
    dotnet run
    ```
    API akan berjalan di `https://localhost:5001` secara default.

#### **Langkah 2: Menjalankan Frontend**

1.  Buka terminal baru dan masuk ke folder `frontend/`:
    ```bash
    cd frontend
    ```
2.  Instal dependensi:
    ```bash
    npm install
    ```
3.  Jalankan aplikasi Next.js:
    ```bash
    npm run dev
    ```
    Aplikasi akan berjalan di `http://localhost:3000`.

-----