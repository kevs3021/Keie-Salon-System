# 💇 KEIE Beauty & Hair Salon Management System

<div align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)

**A comprehensive software solution for efficient salon management and walk-in operations**

[Features](#-features) · [Technologies](#-technologies-used) · [Installation](#-installation) · [Usage](#-usage) · [Team](#-team)

</div>

---

## 📋 Table of Contents
- [About the Project](#-about-the-project)
- [Key Features](#-key-features)
- [System Objectives](#-system-objectives)
- [Technologies Used](#-technologies-used)
- [System Architecture](#-system-architecture)
- [User Roles](#-user-roles)
- [Core Functionalities](#-core-functionalities)
- [Installation & Setup](#-installation--setup)
- [Usage Guide](#-usage-guide)
- [Database Schema](#-database-schema)
- [Screenshots](#-screenshots)
- [Future Enhancements](#-future-enhancements)
- [Contributors](#-contributors)
- [License](#-license)

---

## 🎯 About the Project

**KEIE Beauty & Hair Salon** is a desktop-based salon management system developed as part of a Software Design course project. The name "KEIE" is derived from the combination of team members' names, representing a collaborative effort to streamline salon operations.

Built with **C# Windows Forms** and **MySQL**, this system provides a comprehensive solution for managing walk-in transactions, customer records, appointments, billing, inventory, and performance analytics in beauty and hair salons.

### 🎓 Academic Context
- **Course:** Software Design
- **Institution:** Rizal Technological University
- **Year:** 2024
- **Project Type:** Team-based Software Development

---

## ✨ Key Features

### 👥 **Customer Management**
- Add and manage customer records
- Unique ID assignment for each customer
- Customer information tracking (name, contact, email)
- Queue management system
- Appointment scheduling and tracking

### 💰 **Billing & Payment Processing**
- Real-time service selection and pricing
- Product usage tracking
- Discount application system
- Automated receipt generation
- Payment recording and verification

### 📊 **Reports & Analytics**
- **Daily Query:** Daily sales, services, and products used
- **Monthly Comparison:** Month-over-month performance analysis
- **Service Analytics:** Most frequently requested services
- Visual data representation through charts and diagrams
- Performance metrics for decision-making

### 📦 **Inventory Management**
- Real-time stock tracking
- Product addition and deduction
- Low-stock alerts
- Product information database
- Multi-user inventory updates

### 🔐 **Role-Based Access Control**
- Admin/Manager account with full system access
- Receptionist account for front-desk operations
- Secure login authentication
- User account management

### 🎨 **Staff Management**
- Staff/stylist profile management
- Service assignment tracking
- Availability monitoring
- Performance tracking per staff member

---

## 🎯 System Objectives

### 1. **Facilitate Smooth Walk-in Transactions**
Enable seamless walk-in transactions, providing customers with a hassle-free experience when availing salon services.

### 2. **Design Hassle-free Accounting & Inventory Management**
Comprehensive accounting and inventory management system featuring real-time inventory tracking and automated financial reporting capabilities.

### 3. **Provide User-friendly Interface**
User-friendly interface accessible to salon management and staff, allowing easy navigation and access to essential functions such as appointment scheduling, customer management, and service customization.

### 4. **Enhance Search Functionality**
Advanced search functionality enabling both salon management and customers to quickly access information related to salon services, staff availability, and product details.

### 5. **Ensure Organization & Security**
Prioritize organization and security of salon records through meticulous database implementation and design, safeguarding sensitive information and promoting data integrity.

---

## 🛠️ Technologies Used

### Development Stack
| Technology | Purpose |
|------------|---------|
| **C# (.NET Framework)** | Primary programming language |
| **Windows Forms** | Desktop application UI framework |
| **MySQL** | Database management system |
| **MySQL Connector/NET** | Database connectivity |
| **Visual Studio** | Integrated Development Environment |

### Key Libraries & Components
- **System.Windows.Forms** - UI components
- **MySql.Data** - Database operations
- **System.Drawing** - Graphics and visual elements
- **System.Data** - Data manipulation

---

## 🏗️ System Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                        │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐     │
│  │  Login Form  │  │  Admin Form  │  │Receptionist  │     │
│  │              │  │              │  │    Form      │     │
│  └──────────────┘  └──────────────┘  └──────────────┘     │
└────────────────────────┬────────────────────────────────────┘
                         │
┌────────────────────────▼────────────────────────────────────┐
│                   BUSINESS LOGIC LAYER                       │
│  ┌───────────────────────────────────────────────────────┐ │
│  │  • Customer Management     • Queue Management         │ │
│  │  • Service Processing      • Inventory Control        │ │
│  │  • Billing & Payment       • Report Generation        │ │
│  │  • Staff Management        • Authentication           │ │
│  └───────────────────────────────────────────────────────┘ │
└────────────────────────┬────────────────────────────────────┘
                         │
┌────────────────────────▼────────────────────────────────────┐
│                      DATA ACCESS LAYER                       │
│  ┌───────────────────────────────────────────────────────┐ │
│  │         MySQL Database Connection & Queries           │ │
│  │  • CRUD Operations      • Transaction Management      │ │
│  │  • Stored Procedures    • Data Validation             │ │
│  └───────────────────────────────────────────────────────┘ │
└────────────────────────┬────────────────────────────────────┘
                         │
┌────────────────────────▼────────────────────────────────────┐
│                       DATABASE LAYER                         │
│  ┌───────────────────────────────────────────────────────┐ │
│  │                    MySQL Database                      │ │
│  │  Tables: Customers, Services, Staff, Inventory,       │ │
│  │          Appointments, Transactions, Users            │ │
│  └───────────────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
```

---

## 👥 User Roles

### 🔑 **Admin/Manager**
**Responsibilities:**
- Oversee overall salon operations
- Manage user accounts (add, edit, deactivate)
- Monitor performance metrics and analytics
- Manage inventory and stock levels
- Generate comprehensive reports
- Strategic planning for business growth
- Staff account management

**Permissions:**
- Full system access
- User management capabilities
- Inventory management
- Advanced reporting and analytics
- System configuration

### 📝 **Receptionist**
**Responsibilities:**
- Manage customer interactions and check-ins
- Handle appointment scheduling and coordination
- Process service selections and payments
- Maintain customer records
- Assist with product selection
- Monitor daily appointments and queues
- Basic inventory updates

**Permissions:**
- Customer management
- Service processing
- Payment handling
- Basic reporting
- Queue management
- Limited inventory access

---

## 🔧 Core Functionalities

### 1️⃣ **Login System**
```
┌─────────────────────────┐
│     Login Form          │
├─────────────────────────┤
│  Username: [________]   │
│  Password: [________]   │
│                         │
│  Role:                  │
│  ○ Admin/Manager        │
│  ○ Receptionist         │
│                         │
│      [Login Button]     │
└─────────────────────────┘
```

**Features:**
- Secure authentication
- Role-based access control
- Password protection
- Session management

---

### 2️⃣ **Customer Management**

**Adding New Customers:**
1. Enter customer details (name, contact, email)
2. System auto-generates unique Customer ID
3. Record saved to database
4. Customer becomes available for service booking

**Customer Information Tracked:**
- Full Name (First Name + Last Name)
- Contact Number
- Email Address
- Unique Customer ID
- Service History
- Appointment Records

**Benefits:**
- Efficient appointment tracking
- Personalized customer service
- Historical data for loyalty programs
- Easy customer lookup and retrieval

---

### 3️⃣ **Service Processing Workflow**

**Step 1: Customer Selection**
```
Search Customer: [______] 🔍
└─> Quick search by name or ID
```

**Step 2: Service Selection**
```
Service Categories:
├─ Hair Services
│  └─ Haircut, Coloring, Treatment, Styling
├─ Beauty Services
│  └─ Facial, Makeup, Manicure, Pedicure
└─ Special Services
   └─ Bridal, Event Styling
```

**Step 3: Staff Assignment**
```
Available Staff:
☑ Select preferred stylist
☐ Auto-assign based on availability
```

**Step 4: Queue Management**
```
Customer added to queue → Service begins → Completion → Billing
```

---

### 4️⃣ **Billing & Payment System**

**Payment Interface Displays:**
- Customer Name
- Assigned Staff Member
- List of Services Availed
- Products Used
- Subtotal
- Applicable Discounts
- Final Total Amount

**Discount Types:**
- Senior Citizen Discount
- PWD Discount
- Promotional Offers
- Loyalty Rewards
- Custom Discounts

**Payment Process:**
1. Confirm services completed
2. Add products used (auto-deducts from inventory)
3. Calculate subtotal
4. Apply discounts
5. Customer provides payment
6. Record amount tendered
7. Calculate change
8. Generate and print receipt

---

### 5️⃣ **Receipt Generation**

**Receipt Contents:**
```
═══════════════════════════════════════
     KEIE BEAUTY & HAIR SALON
═══════════════════════════════════════
Date: [DD/MM/YYYY]          Time: [HH:MM]
Receipt #: [RECEIPT_NUMBER]
Customer: [CUSTOMER_NAME]
Served by: [STAFF_NAME]

SERVICES:
─────────────────────────────────────
Haircut                     ₱ 150.00
Hair Color                  ₱ 500.00
─────────────────────────────────────

PRODUCTS:
─────────────────────────────────────
Shampoo                     ₱  80.00
Conditioner                 ₱  80.00
─────────────────────────────────────

Subtotal:                   ₱ 810.00
Discount (10%):             ₱  81.00
─────────────────────────────────────
TOTAL:                      ₱ 729.00

Amount Paid:                ₱ 800.00
Change:                     ₱  71.00
─────────────────────────────────────

Thank you for your patronage!
═══════════════════════════════════════
```

---

### 6️⃣ **Inventory Management**

**Features:**
- Add new products to inventory
- Track stock levels in real-time
- Automatic deduction when products used
- Low-stock alerts
- Product information database

**Inventory Data Tracked:**
- Product Name
- Product Category
- Current Stock Quantity
- Unit Price
- Supplier Information
- Date Added/Updated
- Stock Movement History

**Access Control:**
- Admin: Full inventory control
- Receptionist: Can add stocks and record usage

---

### 7️⃣ **Reports & Analytics**

#### **Daily Query Report**
```
┌──────────────────────────────────┐
│     DAILY PERFORMANCE REPORT     │
├──────────────────────────────────┤
│ Date: January 28, 2024           │
│                                  │
│ Total Services: 25               │
│ Total Products Used: 48          │
│ Total Sales: ₱ 12,450.00         │
│                                  │
│ [Bar Chart Visualization]        │
└──────────────────────────────────┘
```

#### **Monthly Comparison Report**
```
┌──────────────────────────────────┐
│   MONTHLY COMPARISON ANALYSIS    │
├──────────────────────────────────┤
│ Current Month vs Previous Month  │
│                                  │
│ Services:     350  (+15%)        │
│ Products:     680  (+22%)        │
│ Revenue:  ₱125K    (+18%)        │
│                                  │
│ [Line Graph Visualization]       │
└──────────────────────────────────┘
```

#### **Service Popularity Report**
```
┌──────────────────────────────────┐
│   TOP SERVICES OF THE DAY        │
├──────────────────────────────────┤
│ 1. Haircut            (12 times) │
│ 2. Hair Treatment     (8 times)  │
│ 3. Manicure          (6 times)  │
│ 4. Hair Coloring     (5 times)  │
│                                  │
│ [Pie Chart Visualization]        │
└──────────────────────────────────┘
```

---

## 📥 Installation & Setup

### Prerequisites
- Windows OS (Windows 7 or higher)
- .NET Framework 4.5 or higher
- MySQL Server 5.7 or higher
- Visual Studio 2017 or higher (for development)
- MySQL Workbench (optional, for database management)

### Step 1: Clone/Download the Repository
```bash
git clone https://github.com/yourusername/keie-salon-system.git
cd keie-salon-system
```

### Step 2: Database Setup

1. **Install MySQL Server** if not already installed
2. **Create Database:**
   ```sql
   CREATE DATABASE keie_salon_db;
   USE keie_salon_db;
   ```

3. **Import Database Schema:**
   - Locate the SQL file in `/database/schema.sql`
   - Import using MySQL Workbench or command line:
   ```bash
   mysql -u root -p keie_salon_db < database/schema.sql
   ```

4. **Create Default Admin Account:**
   ```sql
   INSERT INTO users (username, password, role, status) 
   VALUES ('admin', 'admin123', 'Admin', 'Active');
   ```

### Step 3: Configure Database Connection

Edit the connection string in `App.config`:
```xml
<connectionStrings>
  <add name="SalonDB" 
       connectionString="Server=localhost;Database=keie_salon_db;Uid=root;Pwd=yourpassword;" 
       providerName="MySql.Data.MySqlClient" />
</connectionStrings>
```

### Step 4: Build and Run

**Using Visual Studio:**
1. Open `SalonProj.sln` in Visual Studio
2. Restore NuGet packages (right-click solution → Restore NuGet Packages)
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

**Using Command Line:**
```bash
msbuild SalonProj.sln
cd bin\Debug
SalonProj.exe
```

---

## 📖 Usage Guide

### For Administrators

#### **1. Login**
- Username: `admin`
- Password: `admin123` (change after first login)
- Select role: Admin/Manager

#### **2. Managing Staff Accounts**
1. Navigate to Staff Management
2. Click "Add New Staff"
3. Enter staff details
4. Assign role (Admin/Receptionist)
5. Save changes

#### **3. Viewing Reports**
1. Go to Reports section
2. Select report type (Daily/Monthly/Service Analytics)
3. Choose date range
4. View charts and export if needed

#### **4. Inventory Management**
1. Access Inventory module
2. View current stock levels
3. Add new products
4. Update stock quantities
5. Monitor low-stock items

---

### For Receptionists

#### **1. Adding a Customer**
1. Login with receptionist credentials
2. Click "Add Customer"
3. Fill in customer details
4. System generates Customer ID
5. Customer ready for service booking

#### **2. Processing a Service**
1. Search and select customer
2. Choose desired services
3. Select staff member (or auto-assign)
4. Add customer to queue
5. Monitor queue status

#### **3. Completing Service & Billing**
1. Input customer Queue ID
2. Confirm services completed
3. Add products used (auto-deducts from inventory)
4. Apply applicable discounts
5. Enter payment amount
6. Generate receipt
7. Complete transaction

---

## 💾 Database Schema

### Key Tables

**Users Table**
```sql
CREATE TABLE users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    full_name VARCHAR(100),
    role ENUM('Admin', 'Receptionist') NOT NULL,
    status ENUM('Active', 'Inactive') DEFAULT 'Active',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

**Customers Table**
```sql
CREATE TABLE customers (
    customer_id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    contact_number VARCHAR(20),
    email VARCHAR(100),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

**Services Table**
```sql
CREATE TABLE services (
    service_id INT PRIMARY KEY AUTO_INCREMENT,
    service_name VARCHAR(100) NOT NULL,
    category VARCHAR(50),
    price DECIMAL(10,2) NOT NULL,
    duration_minutes INT,
    status ENUM('Active', 'Inactive') DEFAULT 'Active'
);
```

**Staff Table**
```sql
CREATE TABLE staff (
    staff_id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    specialization VARCHAR(100),
    contact_number VARCHAR(20),
    status ENUM('Available', 'Busy', 'Offline') DEFAULT 'Available'
);
```

**Appointments/Queue Table**
```sql
CREATE TABLE appointments (
    appointment_id INT PRIMARY KEY AUTO_INCREMENT,
    queue_id VARCHAR(20) UNIQUE,
    customer_id INT NOT NULL,
    staff_id INT,
    appointment_date DATE,
    status ENUM('Waiting', 'In Progress', 'Completed', 'Cancelled'),
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (staff_id) REFERENCES staff(staff_id)
);
```

**Inventory Table**
```sql
CREATE TABLE inventory (
    product_id INT PRIMARY KEY AUTO_INCREMENT,
    product_name VARCHAR(100) NOT NULL,
    category VARCHAR(50),
    quantity INT NOT NULL DEFAULT 0,
    unit_price DECIMAL(10,2),
    supplier VARCHAR(100),
    last_updated TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
```

**Transactions Table**
```sql
CREATE TABLE transactions (
    transaction_id INT PRIMARY KEY AUTO_INCREMENT,
    customer_id INT NOT NULL,
    staff_id INT NOT NULL,
    total_amount DECIMAL(10,2) NOT NULL,
    discount_amount DECIMAL(10,2) DEFAULT 0,
    final_amount DECIMAL(10,2) NOT NULL,
    payment_received DECIMAL(10,2),
    change_amount DECIMAL(10,2),
    transaction_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (staff_id) REFERENCES staff(staff_id)
);
```

---

## 📸 Screenshots

### Login Interface
![Login Screen](screenshots/login.png)
*Secure role-based authentication system*

### Admin Dashboard
![Admin Dashboard](screenshots/admin-dashboard.png)
*Comprehensive overview of salon operations with analytics*

### Receptionist Interface
![Receptionist Dashboard](screenshots/receptionist-dashboard.png)
*Streamlined customer management and service processing*

### Customer Management
![Customer Management](screenshots/customer-management.png)
*Easy-to-use customer information system*

### Service Selection
![Service Selection](screenshots/service-selection.png)
*Intuitive service catalog with pricing*

### Queue Management
![Queue System](screenshots/queue-management.png)
*Real-time queue tracking and status updates*

### Billing Interface
![Billing Screen](screenshots/billing.png)
*Comprehensive billing with discount application*

### Receipt Generation
![Receipt](screenshots/receipt.png)
*Professional receipt with complete transaction details*

### Inventory Management
![Inventory](screenshots/inventory.png)
*Real-time stock tracking and management*

### Reports & Analytics
![Reports](screenshots/reports-analytics.png)
*Visual reports with charts and performance metrics*

---

## 🔮 Future Enhancements

### Planned Features
- [ ] **Online Appointment Booking** - Customer portal for booking appointments
- [ ] **SMS/Email Notifications** - Automated reminders for appointments
- [ ] **Mobile Application** - Android/iOS app for on-the-go management
- [ ] **Cloud Integration** - Cloud backup and multi-branch support
- [ ] **Customer Loyalty Program** - Points and rewards system
- [ ] **Advanced Analytics** - AI-powered insights and predictions
- [ ] **Payment Gateway Integration** - Credit card and digital wallet support
- [ ] **Staff Performance Dashboard** - Individual performance tracking
- [ ] **Product E-commerce** - Online product sales integration
- [ ] **Multi-language Support** - Localization for different regions

### Technical Improvements
- [ ] Migrate to modern .NET Core/.NET 6+
- [ ] Implement API for third-party integrations
- [ ] Add automated backup system
- [ ] Enhance security with encryption
- [ ] Implement unit testing
- [ ] Add comprehensive logging system
- [ ] Cloud deployment option (Azure/AWS)

---

## 👨‍💻 Contributors

### Team KEIE - Software Design Project

**Project Leader:**
- **Kevin Christopher C. Gallego** - [GitHub](https://github.com/kevs3021) | [LinkedIn](https://linkedin.com/in/kevin-christopher-gallego-119475330)
  - System architecture design
  - Database design and implementation
  - Core functionality development
  - Project coordination

**Team Members:**
- **Rose Bie Delos Reyes**
  - UI/UX design
  - Report generation features
  - Documentation

- **Ella Kates Inocencio**
  - Customer management module
  - Billing system implementation
  - Testing and quality assurance

---

## 📝 Project Details

**Course:** Software Design  
**Institution:** Rizal Technological University  
**Academic Year:** 2024  
**Project Type:** Team-based software development  
**Development Duration:** 1 semester  

---

## 📄 License

This project was developed for educational purposes as part of a Software Design course. 

**For Academic/Educational Use:**
- Feel free to use this project as a reference for learning
- Please provide appropriate attribution when using any part of this code

**For Commercial Use:**
- Please contact the contributors for permission

---

## 🙏 Acknowledgments

- **Rizal Technological University** - For providing the opportunity to develop this project
- **Software Design Course Instructor** - For guidance and mentorship throughout development
- **MySQL Community** - For excellent database documentation
- **Stack Overflow Community** - For technical support and solutions
- **Microsoft Documentation** - For comprehensive .NET Framework resources

---

## 📧 Contact

**Kevin Christopher C. Gallego**
- 📧 Email: kevin.gallego1024@gmail.com
- 💼 LinkedIn: [Kevin Christopher Gallego](https://linkedin.com/in/kevin-christopher-gallego-119475330)
- 🐙 GitHub: [@kevs3021](https://github.com/kevs3021)
- 📱 Phone: +63-966-863-4543

**Project Link:** [https://github.com/kevs3021/keie-salon-system](https://github.com/kevs3021/keie-salon-system)

---

<div align="center">

**⭐ If you found this project helpful, please consider giving it a star!**

Made with ❤️ by Team KEIE

*Developed for educational purposes | Rizal Technological University | 2024*

</div>
