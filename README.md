‎=<p align="center">
‎  
‎    <img src="https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/logo2.png" width="130">
‎  </a>
‎  
‎  <h1 align="center"><strong>Desktop Incedence Management System</strong></h1>
‎  </a>
‎  <p align="center">
‎    <a href="">
‎      <img src="https://img.shields.io/badge/Join-Community-blue.svg" alt="MIT License">
‎    </a>
‎    <a href="https://wa.me/233505994829?text=*Ucam_From_Github_User_💬Message_:*%20">
‎      <img src="https://img.shields.io/badge/Contact-Engineers-red.svg" alt="Build Status">
‎    </a>
‎  </p>
‎</p>
‎
‎---

# 🚨 Desktop Incidence Management System (IMS)

**An MVP desktop application for digitalized campus security incident reporting, tracking, assignment, and response management across university campuses.**

---

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image1.png)


## 📋 Table of Contents

- [Vision & Overview](#vision--overview)
- [Features](#features)
- [System Requirements](#system-requirements)
- [Installation & Setup](#installation--setup)
- [Quick Start Guide](#quick-start-guide)
- [How It Works](#how-it-works)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [Configuration](#configuration)
- [User Roles & Workflows](#user-roles--workflows)
- [Incident Lifecycle](#incident-lifecycle)
- [Troubleshooting](#troubleshooting)
- [Contributing](#contributing)
- [License](#license)

---

## 🎯 Vision & Overview

### Vision Statement

To provide University campuses with the most modern digitalized management security alternative in scouting, analyzing, and applying real solutions to achieve the utmost safety and security on campuses.

### Purpose

The **Desktop Incidence Management System (IMS)** is a desktop-based security incident management application designed for university campuses. It enables students to report security incidents, administrators to manage incident assignments and workflows, and security patrol teams to investigate, respond to, and document incident resolutions—all in a centralized, auditable system.

### Key Goals

✅ **Digitize Incident Reporting** — Eliminate paper-based incident reports; enable instant digital reporting by students.

✅ **Centralized Incident Management** — Maintain a single source of truth for all incidents across multiple campuses.

✅ **Real-Time Visibility** — Admins and security teams track incident status in real-time from pending to closed.

✅ **Efficient Assignment & Coordination** — Admin assigns incidents to specific campus patrol teams with automatic notifications.

✅ **Improved Response Time** — Reduce delays in incident response through streamlined assignment workflow.

✅ **Complete Accountability** — Maintain full audit trail of all incident actions: reporting, assignment, responses, status changes.

✅ **Data-Driven Decision Making** — Generate analytical reports on incident trends, response times, and campus safety metrics.

✅ **Multi-Campus Support** — Manage security across multiple campus locations with role-based access per campus.

---

## ✨ Features

### 👨‍🎓 Student Features

| Feature | Description |
|---------|-------------|
| **Secure Registration** | Create account during first login with index number and password |
| **Complete Profile Setup** | Upload passport photo, enter full name, select campus, provide phone number |
| **Report Incident** | File security incident reports with title, description, category, location, and evidence |
| **Real-Time Reference Number** | Automatic incident reference number (e.g., INC-2026-10-0001) for tracking |
| **View Report History** | See all incidents reported by the student with current status |
| **Track Status** | Monitor incident status progression (Pending → Assigned → In Progress → Resolved → Closed) |
| **View Outcomes** | See final resolution details and actions taken by security team |
| **Attach Evidence** | Upload incident photos/evidence to support report |
| **Multi-Campus Support** | Report incidents on assigned campus with location details |

### 👮‍♂️ Security Patrol Team Features

| Feature | Description |
|---------|-------------|
| **Assigned Incidents Dashboard** | View all incidents assigned to their patrol team |
| **Investigate Incidents** | Review incident details, location, student reports, and evidence |
| **Investigation Updates** | Post investigation updates to incident (Investigation Update response type) |
| **Actions Taken Logging** | Document specific actions taken during incident investigation (Action Taken response type) |
| **Submit Final Reports** | Complete incident investigation with final report and evidence (Final Report response type) |
| **Evidence Documentation** | Upload photos/evidence for investigation and final report |
| **Status Updates** | Track incident status as they progress through investigation |
| **Campus Assignment** | Only view and respond to incidents on assigned campus |
| **Team Collaboration** | Coordinate with other team members on same incident assignments |

### 👨‍💼 Administrator Features

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image3.png)


| Feature | Description |
|---------|-------------|
| **System Dashboard** | View key metrics (total incidents, pending, assigned, resolved, response times) |
| **Incident Overview** | View all incidents across all campuses with filtering and search |
| **Bulk Student Import** | Import student lists from Excel file with automatic account creation |
| **Security Team Registration** | Create security patrol accounts and assign to campuses |
| **Incident Categories Management** | Define incident categories (theft, assault, fire, etc.) with default severity levels |
| **Campus Management** | Add and manage multiple university campuses |
| **Incident Assignment** | Review pending incidents and assign to appropriate patrol teams |
| **Assignment Workflow** | Reassign, cancel, or complete incident assignments |
| **Response Monitoring** | Review all patrol team responses and investigation updates |
| **Incident Closure** | Review completed investigations and formally close incidents |
| **Status Management** | Manually update incident status with change tracking and reasons |
| **Audit Trail** | View complete history of all incident status changes |
| **Analytics & Reports** | Generate reports on incident trends, response times, category distribution |
| **User Account Management** | Manage admin, security, and student accounts with activation/deactivation |
| **Notification System** | Send automated notifications to security teams on new assignments |

---

## 🖥️ System Requirements

### Minimum Requirements

- **Operating System**: Microsoft Windows 10 or Windows 11 (64-bit)
- **Framework**: .NET Framework 4.7.2 or higher
- **RAM**: 4 GB minimum (8 GB recommended for multi-campus systems)
- **Storage**: 2 GB free disk space
- **Display**: 1024 x 768 minimum screen resolution

### Database Requirements

- **Database System**: MySQL 5.7 or higher / MySQL 8.0 (recommended)
- **Database Port**: Default 3306 (or custom as configured)
- **User Permissions**: Full CREATE, ALTER, DROP, SELECT, INSERT, UPDATE, DELETE permissions

### Development Tools (for customization)

- **IDE**: Microsoft Visual Studio 2022 Community Edition Compatible
- **Language**: VB.NET
- **UI Framework**: Windows Forms (WinForms)
- **Database Driver**: MySQL Connector/NET

---

## ⚙️ Installation & Setup

### Step 1: Clone or Download the Project

```bash
# Clone the repository
git clone https://github.com/your-organization/DesktopIncidenceManagementSystem.git
cd DesktopIncidenceManagementSystem
```

### Step 2: Database Setup

1. **Open MySQL Command Line or MySQL Workbench**

2. **Create database:**
   ```sql
   CREATE DATABASE ims_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
   ```

3. **Import database schema:**
   - Navigate to `core/` folder
   - Run `DatabaseQuery.txt` in MySQL (fresh start with no data)
   - OR import `ims.sql` (pre-built with sample data)

4. **Verify database creation:**
   ```sql
   USE ims_db;
   SHOW TABLES;
   ```

   Expected tables: `users`, `campuses`, `incident_categories`, `incidents`, `incident_assignments`, `incident_responses`, `incident_status_history`

### Step 3: Configure Database Connection

1. **Open project in Visual Studio 2022**
   - File → Open → Incidence Management System.sln

2. **Edit connection string:**
   - Navigate to `Shared/Database.vb`
   - Update MySQL credentials:

   ```vb
   Public connectionString As String = "Server=localhost;Database=ims_db;Uid=root;Pwd=your_password;Port=3306"
   ```

   Update: `Server`, `Database`, `Uid`, `Pwd`, `Port`

3. **Save file**

### Step 4: Create Initial Admin Account

If using fresh database (DatabaseQuery.txt):

```sql
INSERT INTO users (
    username, 
    password_hash, 
    role, 
    full_name, 
    is_active
) VALUES (
    'admin', 
    'SHA2("admin", 256)', 
    'ADMIN', 
    'System Administrator', 
    TRUE
);
```

Login credentials:
- **Username**: `admin`
- **Password**: `admin123`


### Step 5: Create Initial Campuses

```sql
INSERT INTO campuses (campus_name, campus_code, campus_description)
VALUES 
('North Campus', 'NC', 'Northern campus location'),
('South Campus', 'SC', 'Southern campus location'),
('Central Campus', 'CC', 'Central campus location');
```

### Step 6: Create Incident Categories

```sql
INSERT INTO incident_categories (category_name, category_description, severity_default)
VALUES 
('Theft', 'Theft or stolen property', 'MEDIUM'),
('Assault', 'Physical assault or violence', 'HIGH'),
('Fight', 'Physical altercation between persons', 'HIGH'),
('Sexual Harassment', 'Sexual harassment or misconduct', 'CRITICAL'),
('Fire Outbreak', 'Fire or fire-related incident', 'CRITICAL'),
('Vandalism', 'Property damage or vandalism', 'MEDIUM'),
('Drug Abuse', 'Drug-related incident', 'HIGH'),
('Trespassing', 'Unauthorized presence', 'LOW'),
('Other', 'Other security incident', 'MEDIUM');
```

### Step 7: Build and Run

1. **Build solution:**
   - Build → Build Solution (Ctrl+Shift+B)
   - Verify no compilation errors

2. **Run application:**
   - Press F5 or Debug → Start Debugging
   - Login screen appears

3. **Test Login:**
   - **Admin**: Username: `admin`, Password: `admin123`

---

## 🚀 Quick Start Guide

### For Administrators (First-Time Setup)

#### Phase 1: System Initialization

1. **Login as Admin**
   - Username: `admin`
   - Password: `admin123` (default)

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image2.png)


3. **Setup Campuses**
   - Admin Dashboard → Campus Management
   - Add: North Campus, South Campus, Central Campus

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image3.png)


4. **Configure Incident Categories**
   - Admin Dashboard → Incident Categories
   - Add all category types (Theft, Assault, Fire, etc.)

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image4.png)


5. **Import Students** [found at Core/StudentData.xlxs]
   - Admin Dashboard → Student Import
   - Prepare and Upload Excel file with: Index Number, Full Name

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image6.png)


   - System auto-creates student accounts with Default Password `1234`

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image5.png)


6. **Register Security Teams**
   - Admin Dashboard → Security Team Management
   - Create patrol accounts: North Campus Patrol, South Campus Patrol, Central Campus Patrol
   - Assign each patrol team to their campus


![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image7.png)



#### Phase 2: System Ready for Operations

Students can now report incidents, security teams can investigate, admin can manage workflow.

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image8.png)

---

### For Students (First Login & Incident Report)

#### Phase 1: Account Setup

1. **Launch Application**
   - Login screen appears

2. **First Login**
   - Index Number: Student ID
   - Password: Default password from import

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image9.png)

3. **Complete Profile**
   - Upload passport photo
   - Enter full name
   - Select campus
   - Enter phone number

4. **Dashboard Access**
   - View incident reporting option
   - See incident history

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image10.png)


#### Phase 2: Report Incident

1. **Click: Report New Incident**

2. **Fill Incident Details**:
   - **Incident Title**: Brief summary (e.g., "Laptop Stolen from Dormitory")
   - **Description**: Detailed account of incident
   - **Campus**: Select campus where incident occurred
   - **Category**: Select category (Theft, Assault, etc.)
   - **Location**: Specific location on campus
   - **Evidence**: Upload photo/evidence (optional)

3. **Submit Report**
   - System generates Incident Reference Number (e.g., INC-2026-10-0001)
   - Status: PENDING
   - Student receives confirmation

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image11.png)



#### Phase 3: Track Incident

1. **View Incident History**
   - See all reported incidents
   - View current status

2. **Monitor Progress**
   - Status updates: PENDING → ASSIGNED → IN_PROGRESS → RESOLVED → CLOSED
   - View outcomes and actions taken

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image11.png)


---

### For Security Patrol Teams (Incident Response)

#### Phase 1: Receive Assignment

1. **Dashboard Shows Assigned Incidents**
   - List of incidents assigned to team

2. **Review Incident Details**
   - Student report
   - Location
   - Evidence
   - Category and priority


![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/image11.png)



#### Phase 2: Investigate Incident

1. **Post Investigation Update**
   - Describe investigation progress
   - Update status to IN_PROGRESS

2. **Document Actions Taken**
   - Specify actions taken
   - Add evidence photos
   - Include findings

3. **Submit Final Report**
   - Complete investigation findings
   - Upload evidence
   - Describe resolution

#### Phase 3: Incident Resolution

1. **Status Updates**
   - From IN_PROGRESS → RESOLVED → CLOSED

2. **Admin Reviews & Closes**
   - Admin reviews final report
   - Formally closes incident

---

## 🔄 How It Works

### End-to-End Workflow

```
STUDENT REPORTS INCIDENT
    ↓
System Creates Incident Record
    ├→ Generates unique reference number
    ├→ Sets status to PENDING
    └→ Stores evidence if provided
    ↓
ADMIN RECEIVES NOTIFICATION
    ├→ Reviews pending incidents
    ├→ Checks incident details and evidence
    └→ Determines severity
    ↓
ADMIN ASSIGNS TO PATROL TEAM
    ├→ Selects appropriate campus patrol
    ├→ Updates incident status to ASSIGNED
    └→ Security team receives notification
    ↓
PATROL TEAM INVESTIGATES
    ├→ Receives assignment
    ├→ Reviews student report
    ├→ Begins investigation
    └→ Updates status to IN_PROGRESS
    ↓
PATROL TEAM POSTS UPDATES
    ├→ Investigation Update responses
    ├→ Actions Taken documentation
    └→ Evidence photos uploaded
    ↓
PATROL TEAM SUBMITS FINAL REPORT
    ├→ Complete investigation findings
    ├→ Resolution details
    └→ Status moves to RESOLVED
    ↓
ADMIN REVIEWS & CLOSES
    ├→ Reviews final report
    ├→ Verifies actions taken
    └→ Closes incident (Status = CLOSED)
    ↓
STUDENT SEES OUTCOME
    ├→ Incident marked CLOSED
    ├→ Can view all updates and actions taken
    └→ Final report available
```

---

## 🛠️ Technology Stack

| Layer | Technology | Version |
|-------|-----------|---------|
| **IDE** | Microsoft Visual Studio | 2022 |
| **Language** | VB.NET | .NET Framework 4.7.2+ |
| **UI Framework** | Windows Forms (WinForms) | Built-in |
| **Database** | MySQL | 5.7 / 8.0 |
| **Database Driver** | MySQL Connector/NET | 
| **Password Security** | SHA-256 Hashing | Cryptographic Standard |
| **Application Type** | Desktop Incident Management | Single Solution |
| **Architecture** | Single-tier Monolithic | WinForms + MySQL |

---

## 📂 Project Structure

```
DesktopIncidenceManagementSystem/
├── bin/                                    # Compiled executable files
│
├── src/
│   ├── Core/
│   │   └── PasswordHasher.vb               # Password hashing utility
│   │   └── DatabaseQuery.txt
        └── StudentsData.xlxs

│   ├── Features/
│   │   ├── Authentication/
│   │   │   ├── LoginForm.vb                # Login screen
│   │   │   └── RegistrationForm.vb         # Student registration
│   │   │
│   │   ├── Users/
│   │   │   ├── Admin/
│   │   │   │   ├── AdminDashboard.vb       # Admin main screen
│   │   │   │   ├── IncidentManagement.vb   # Manage incidents
│   │   │   │   ├── StudentImport.vb        # Bulk student import
│   │   │   │   ├── SecurityTeamMgmt.vb     # Security account management
│   │   │   │   ├── CampusManagement.vb     # Add/manage campuses
│   │   │   │   ├── CategoryManagement.vb   # Incident categories
│   │   │   │   ├── Analytics.vb            # Reports and statistics
│   │   │   │   └── NotificationCenter.vb   # Manage notifications
│   │   │   │
│   │   │   ├── Security/
│   │   │   │   ├── SecurityDashboard.vb    # Patrol team dashboard
│   │   │   │   ├── AssignedIncidents.vb    # View assignments
│   │   │   │   ├── IncidentInvestigation.vb # Investigate incident
│   │   │   │   ├── ResponseSubmission.vb   # Submit response/final report
│   │   │   │   └── EvidenceUpload.vb       # Evidence management
│   │   │   │
│   │   │   └── Student/
│   │   │       ├── StudentDashboard.vb     # Student main screen
│   │   │       ├── ProfileSetup.vb         # Complete profile
│   │   │       ├── IncidentReporter.vb     # Report incident
│   │   │       ├── IncidentHistory.vb      # View incidents reported
│   │   │       └── TrackIncident.vb        # Monitor incident status
│   │   │
│   │   └── Shared/
│   │       ├── Database.vb                 # MySQL connection & queries
│   │       ├── Session.vb                  # User session management
│   │       ├── DataGridViewHelper.vb       # Data grid utilities
│   │       ├── NavButtonStyles.vb          # Navigation button styling
│   │       └── ShapeUtilities.vb           # UI shape utilities
│   │
│   └── Assets/                             # Images and resources
│       ├── Icons/
│       ├── Logos/
│       └── Evidence/                       # Incident evidence storage
│
├── .gitignore                              # Git exclusion rules
├── LICENSE                                 # License file
├── ApplicationEvents.vb                    # Application startup
└── Incidence Management System.sln         # Visual Studio Solution
```

---

## 🔧 Configuration

### Database Connection

**File**: `Shared/Database.vb`

```vb
Public connectionString As String = "Server=localhost;Database=ims_db;Uid=root;Pwd=password;Port=3306"
```

**Parameters**:
- `Server` — MySQL server (localhost for local)
- `Database` — Database name (ims_db)
- `Uid` — MySQL username (root)
- `Pwd` — MySQL password (your password)
- `Port` — MySQL port (3306)

### Notification Settings

Edit `ApplicationEvents.vb` to configure:
- Notification check interval
- Email settings (optional for production)
- Alert preferences

---

## 👥 User Roles & Workflows

### 1. Administrator Role

**Permissions**:
- Manage all incidents across all campuses
- Import students in bulk
- Create and manage security patrol accounts
- Create campuses and incident categories
- Assign incidents to patrol teams
- Close incidents after review
- Generate reports and analytics
- Manage user accounts

**Dashboard**:
- Key metrics (total incidents, pending, assigned, resolved)
- Pending incidents awaiting assignment
- All incidents with search/filter
- Security team assignments
- Notification center

---

### 2. Security Patrol Team Role

**Permissions**:
- View only incidents on assigned campus
- Review incident details and evidence
- Post investigation updates
- Submit final reports
- Upload evidence photos
- Update incident status during investigation

**Dashboard**:
- Assigned incidents (active)
- Investigation details
- Response history
- Team collaboration on same incident

---

### 3. Student Role

**Permissions**:
- Report incidents on own campus
- View own incident history
- Track incident status progression
- See final outcomes and actions taken
- Upload evidence for own reports

**Dashboard**:
- Report new incident
- View incident history
- Track status

---

## 📊 Incident Lifecycle

Every incident progresses through defined states:

```
PENDING
└─ Incident reported by student
└─ Awaiting admin review and assignment

ASSIGNED
└─ Admin assigned to patrol team
└─ Patrol team notified

IN_PROGRESS
└─ Patrol team actively investigating
└─ Updates and actions being documented

RESOLVED
└─ Patrol team submitted final report
└─ Investigation complete

CLOSED
└─ Admin reviewed and formally closed
└─ Incident archived

Alternative: REJECTED
└─ Admin rejected incident
└─ Incident not assigned to patrol team
```

---

## 🐛 Troubleshooting

### Database Connection Issues

**Problem**: "Cannot connect to database"
```
Solution:
1. Verify MySQL server is running
2. Check connection string in Database.vb
3. Verify username and password
4. Ensure database 'ims_db' exists
5. Test: mysql -h localhost -u root -p
```

### Login Issues

**Problem**: "Invalid username or password"
```
Solution:
1. Verify admin account exists: SELECT * FROM users WHERE username = 'admin';
2. Check account is active: account_status = 'ACTIVE'
3. Activate if needed: UPDATE users SET is_active = TRUE
4. Reset password in database
```

### Student Import Issues

**Problem**: "Excel file import failed"
```
Solution:
1. Verify Excel format is .xlsx
2. Check columns: [ Index Number, Student Name ] Only, default password 1234 is automatic for all
3. Verify campus names exist in system
4. No duplicate index numbers
```

### Incident Assignment Issues

**Problem**: "Cannot assign incident to patrol team"
```
Solution:
1. Verify patrol team exists and is assigned to campus
2. Check incident status is PENDING
3. Verify patrol team account role = SECURITY
4. Check campus of incident matches patrol team campus
```

---

## 👥 Contributing

### How to Contribute

1. **Report Bugs** — Open GitHub Issue with:
   - Steps to reproduce
   - Expected vs actual behavior
   - Screenshots if applicable

2. **Suggest Features** — Open Feature Request issue

3. **Submit Code**:
   ```bash
   # Fork, create feature branch
   git checkout -b feature/YourFeature
   # Commit and push
   git commit -m "Add feature"
   git push origin feature/YourFeature
   # Open Pull Request
   ```

4. **Code Standards**:
   - Follow VB.NET conventions
   - Add comments for complex logic
   - Test thoroughly
   - Update documentation

---

## 📄 License

See `LICENSE` file for licensing terms.

---

## 📞 Support

**Questions?** Review:
- [DATABASE.md](./DATABASE.md) — Schema and data structure
- [ARCHITECTURE.md](./ARCHITECTURE.md) — Technical design

---

## 🎯 Keywords for SEO

`incident management system`, `campus security`, `university security system`, `VB.NET incident tracking`, `incident reporting`, `security incident management`, `multi-campus incident system`, `incident assignment`, `response tracking`, `audit trail incident`, `security patrol management`, `campus safety system`

---

**Version**: 1.0 (MVP)  
**Built With**: Visual Studio 2022 | VB.NET | Windows Forms | MySQL

🚨 *Modernizing campus security through digitalized incident management.*
