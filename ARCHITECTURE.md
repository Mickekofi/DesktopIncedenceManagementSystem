# 🏗️ System Architecture & Design



**Desktop Incidence Management System (IMS) — Technical Architecture Reference**

Complete documentation of the system architecture, component design, data flows, design patterns, and technical implementation.

---

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/architecture_image.png)


## 📋 Table of Contents

- [Architecture Overview](#architecture-overview)
- [System Architecture Diagram](#system-architecture-diagram)
- [Technology Stack](#technology-stack)
- [Application Layers](#application-layers)
- [Core Modules & Components](#core-modules--components)
- [Data Flow & Workflows](#data-flow--workflows)
- [Design Patterns](#design-patterns)
- [Authentication & Authorization](#authentication--authorization)
- [Security Architecture](#security-architecture)
- [File Storage & Evidence Management](#file-storage--evidence-management)
- [Notification System](#notification-system)
- [Error Handling & Logging](#error-handling--logging)
- [Performance Optimization](#performance-optimization)
- [Scalability & Future Enhancements](#scalability--future-enhancements)
- [Development Standards](#development-standards)

---

## 🎯 Architecture Overview

### System Type

**Single-Tier Desktop Incident Management System**

- **Deployment Model**: Monolithic Windows Desktop Application
- **Architecture Pattern**: Single Solution (one .sln file)
- **Execution Model**: Single-threaded WinForms UI with database backend
- **Scalability**: Designed for university campuses; handles 5K+ students, 1K+ incidents

### Core Principles

✅ **Centralized** — All data flows through single MySQL database
✅ **Role-Based** — Three separate interfaces (Admin, Security, Student)
✅ **Multi-Campus** — Support multiple university campuses in one system
✅ **Auditable** — Complete tracking of every action with timestamps
✅ **Workflow-Driven** — Incident lifecycle with defined state transitions

### Key Architectural Decisions

| Decision | Rationale | Trade-Off |
|----------|-----------|-----------|
| **Single Solution** | Simple deployment, unified codebase | Limited horizontal scalability |
| **Windows Desktop** | Direct institutional control, no hosting costs | Windows-only (no cloud/mobile) |
| **Monolithic** | Rapid development, tight integration | Difficult to split services later |
| **MySQL Backend** | Industry-standard, easy setup, affordable | Not ideal for massive analytics |

---

## 🔀 System Architecture Diagram

### High-Level Component Architecture

```
┌──────────────────────────────────────────────────────┐
│   DESKTOP INCIDENCE MANAGEMENT SYSTEM (IMS)           │
│          Windows Desktop Application                 │
└──────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────────┐
│              PRESENTATION LAYER (WinForms UI)                │
├──────────────────┬──────────────────┬──────────────────────┤
│                  │                  │                      │
│  ADMIN INTERFACE │ SECURITY PATROL  │  STUDENT INTERFACE  │
│  ────────────    │ ───────────────  │  ─────────────────  │
│  • Dashboard     │ • Dashboard      │  • Report Incident  │
│  • Incidents     │ • Assignments    │  • View History     │
│  • Assignment    │ • Investigation  │  • Track Status     │
│  • Student Mgmt  │ • Responses      │  • Profile Setup    │
│  • Categories    │ • Evidence Upload│                     │
│  • Campuses      │                  │                     │
│  • Reports       │                  │                     │
│                  │                  │                     │
└──────────────────┴──────────────────┴──────────────────────┘

┌──────────────────────────────────────────────────────────────┐
│            SHARED SERVICES LAYER (Common Logic)              │
├──────────────────────────────────────────────────────────────┤
│                                                               │
│  ┌────────────────────┐  ┌────────────────────┐             │
│  │ Database Manager   │  │ Session Manager    │             │
│  │ (MySQL Queries)    │  │ (User Context)     │             │
│  └────────────────────┘  └────────────────────┘             │
│                                                               │
│  ┌────────────────────┐  ┌────────────────────┐             │
│  │ Password Hasher    │  │ Notification Mgr   │             │
│  │ (SHA-256)          │  │ (Status Updates)   │             │
│  └────────────────────┘  └────────────────────┘             │
│                                                               │
│  ┌────────────────────┐  ┌────────────────────┐             │
│  │ UI Utilities       │  │ Data Grid Helper   │             │
│  │ (Shapes, Styles)   │  │ (Formatting)       │             │
│  └────────────────────┘  └────────────────────┘             │
│                                                               │
└──────────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────────┐
│         BUSINESS LOGIC LAYER (Incident Workflows)            │
├──────────────────────────────────────────────────────────────┤
│                                                               │
│  ┌───────────────────────────────────────────────────────┐  │
│  │ INCIDENT REPORTING ENGINE                            │  │
│  │ • Create incident from student report                │  │
│  │ • Generate unique reference number                   │  │
│  │ • Store evidence images                              │  │
│  │ • Set initial status = PENDING                       │  │
│  └───────────────────────────────────────────────────────┘  │
│                                                               │
│  ┌───────────────────────────────────────────────────────┐  │
│  │ INCIDENT ASSIGNMENT ENGINE                           │  │
│  │ • Validate incident before assignment                │  │
│  │ • Check patrol team campus match                     │  │
│  │ • Create assignment record                           │  │
│  │ • Update incident status = ASSIGNED                  │  │
│  │ • Send notification to patrol team                   │  │
│  └───────────────────────────────────────────────────────┘  │
│                                                               │
│  ┌───────────────────────────────────────────────────────┐  │
│  │ INCIDENT RESPONSE ENGINE                             │  │
│  │ • Accept investigation updates                       │  │
│  │ • Log actions taken                                  │  │
│  │ • Process final reports                              │  │
│  │ • Update status = IN_PROGRESS, RESOLVED              │  │
│  └───────────────────────────────────────────────────────┘  │
│                                                               │
│  ┌───────────────────────────────────────────────────────┐  │
│  │ INCIDENT CLOSURE ENGINE                              │  │
│  │ • Admin review of final report                       │  │
│  │ • Status verification (IN_PROGRESS → RESOLVED)       │  │
│  │ • Formal closure (RESOLVED → CLOSED)                 │  │
│  │ • Audit logging with change reason                   │  │
│  └───────────────────────────────────────────────────────┘  │
│                                                               │
└──────────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────────┐
│                DATA ACCESS LAYER (Repository)                │
├──────────────────────────────────────────────────────────────┤
│                                                               │
│  • MySQL Connector/NET (Database Driver)                    │
│  • Connection String: Shared/Database.vb                    │
│  • Query Execution: Parameterized SQL (SQL Injection Prevent)
│  • Data Mapping: DataSet/DataTable → Domain Objects         │
│                                                               │
└──────────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────────┐
│              PERSISTENCE LAYER (MySQL Database)              │
├──────────────────────────────────────────────────────────────┤
│                                                               │
│  ┌────────────────────┐  ┌────────────────────┐             │
│  │ User Management    │  │ Campus & Config    │             │
│  │ • users            │  │ • campuses         │             │
│  │ • roles            │  │ • categories       │             │
│  └────────────────────┘  └────────────────────┘             │
│                                                               │
│  ┌─────────────────────────────────────────────────────┐   │
│  │ Incident Tracking & Workflow                        │   │
│  │ • incidents                                         │   │
│  │ • incident_assignments                              │   │
│  │ • incident_responses                                │   │
│  │ • incident_status_history                           │   │
│  └─────────────────────────────────────────────────────┘   │
│                                                               │
│  MySQL 5.7 / 8.0 Database (ims_db)                           │
│  Character Set: UTF8MB4 | Engine: InnoDB | ACID Compliant   │
│                                                               │
└──────────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────────┐
│            EXTERNAL RESOURCES (File System)                   │
├──────────────────────────────────────────────────────────────┤
│                                                               │
│  • Assets/Evidence/ — Incident evidence photos               │
│  • Core/ — Database initialization scripts                   │
│  • Configuration files                                       │
│                                                               │
└──────────────────────────────────────────────────────────────┘
```

---

## 🛠️ Technology Stack

| Layer | Technology | Version | Purpose |
|-------|-----------|---------|---------|
| **IDE** | Microsoft Visual Studio | 2022 | Development environment |
| **Language** | VB.NET | .NET Framework 4.7.2+ | Business logic |
| **UI Framework** | Windows Forms (WinForms) | Built-in | Desktop UI |
| **Database** | MySQL | 5.7 / 8.0 | Data persistence |
| **Database Driver** | MySQL Connector/NET | Latest | Database connectivity |
| **Security** | SHA-256 Hashing | Cryptographic Std | Password security |
| **Architecture** | Single-tier Monolithic | Desktop App | System design |

---

## 📚 Application Layers

### Layer 1: Presentation Layer

**Location**: `Features/` folder (Authentication, Users/Admin/Security/Student)

**Responsibility**: Render UI components, capture input, display data

**Components**:
- **Authentication Module** — Login and registration forms
- **Admin Module** — Dashboard, incident management, assignments, categories
- **Security Module** — Assigned incidents, investigation, responses
- **Student Module** — Report incident, track status, view history

---

### Layer 2: Shared Services Layer

**Location**: `Shared/` folder

**Responsibility**: Provide common utilities and infrastructure

**Components**:
- **Database.vb** — MySQL connection, query execution
- **Session.vb** — Current user context (who is logged in)
- **PasswordHasher.vb** — SHA-256 password hashing
- **DataGridViewHelper.vb** — Data grid formatting
- **NavButtonStyles.vb** — Navigation button styling
- **ShapeUtilities.vb** — UI shape utilities

---

### Layer 3: Business Logic Layer

**Location**: Embedded in form event handlers

**Responsibility**: Implement core incident workflows

**Key Logic**:

```vb
' Incident Reporting
Public Function ReportIncident(title, description, category, location, imageFile) As Integer
    ' Validate: All required fields present
    ' Generate unique incident reference (INC-2026-10-0001)
    ' INSERT INTO incidents (status=PENDING)
    ' Copy evidence image to Assets/Evidence/
    ' Return incident_id
End Function

' Incident Assignment
Public Function AssignIncident(incidentId, patrolTeamId, adminId) As Boolean
    ' Validate: Incident status = PENDING
    ' Validate: Patrol team campus matches incident campus
    ' INSERT INTO incident_assignments
    ' UPDATE incidents SET status=ASSIGNED
    ' Send notification to patrol team
    ' Return success
End Function

' Investigation Update
Public Function PostInvestigationUpdate(incidentId, responseDetails, responseType) As Boolean
    ' Validate: Assignment is ACTIVE
    ' INSERT INTO incident_responses
    ' Update incident status if needed
    ' Return success
End Function

' Incident Closure
Public Function CloseIncident(incidentId, adminId, reason) As Boolean
    ' Validate: Status = RESOLVED
    ' UPDATE incidents SET status=CLOSED, closed_at=NOW
    ' INSERT INTO incident_status_history
    ' Return success
End Function
```

---

### Layer 4: Data Access Layer

**Location**: `Shared/Database.vb`

**Pattern**: Parameterized SQL queries (no ORM)

---

### Layer 5: Persistence Layer

**Location**: MySQL database (ims_db)

**Features**: ACID compliance, referential integrity, audit trail

---

## 🔄 Data Flow & Workflows

### Workflow 1: Student Registration & First Login

```
Student First Login
    ↓ (Index Number + Default Password)
Verify Credentials
    ├→ Query: users WHERE username = index_number
    ├→ Check: first_login_completed = FALSE
    └→ Session initialization
    ↓
Complete Profile Form
    ├→ Upload passport photo → Assets/ProfilePhotos/
    ├→ Enter full name
    ├→ Select campus
    └─→ Enter phone number
    ↓
UPDATE users SET first_login_completed = TRUE
    ↓
Student Dashboard
```

---

### Workflow 2: Report Incident

```
Student Clicks: Report New Incident
    ↓
Incident Form
    ├→ Title: "Laptop Stolen"
    ├→ Description: Detailed account
    ├→ Campus: Selected by student
    ├→ Category: Theft
    ├→ Location: Building A, Room 201
    └→ Evidence: Optional photo upload
    ↓
ReportIncident()
    ├→ Generate Reference: INC-2026-10-0001
    ├→ INSERT INTO incidents (status=PENDING)
    ├→ Save evidence → Assets/Evidence/
    └→ Return incident_id
    ↓
Confirmation to Student
    ├→ Display incident reference number
    ├→ Redirect to View History
    └→ Student can track status
```

---

### Workflow 3: Admin Assigns Incident

```
Admin Dashboard
    ↓
View Pending Incidents
    ├→ Query: incidents WHERE status=PENDING
    ├→ Sort by priority_level
    └→ Display in grid
    ↓
Admin Reviews Incident
    ├→ Read student report
    ├→ View evidence photo
    ├→ Check category & priority
    └→ Determine patrol team
    ↓
Admin Assigns to Patrol
    ├→ Select North Campus Patrol
    ├→ Add assignment notes (optional)
    └→ Click: Assign
    ↓
AssignIncident()
    ├→ Validate: Status = PENDING
    ├→ Validate: Campus match
    ├→ INSERT incident_assignments (status=ACTIVE)
    ├→ UPDATE incidents SET status=ASSIGNED
    └→ Notify patrol team
    ↓
Patrol Team Receives Notification
    ├→ New incident assigned
    └→ Updates dashboard automatically
```

---

### Workflow 4: Security Team Investigates

```
Patrol Team Dashboard
    ↓
View Assigned Incidents
    ├→ Query: incident_assignments WHERE assigned_to_user_id = current_user
    ├→ Query linked incident details
    └→ Display in grid
    ↓
Click Incident to Investigate
    ├→ View full report from student
    ├→ View evidence photo
    ├→ See assignment notes from admin
    └→ Update status → IN_PROGRESS
    ↓
Post Investigation Update
    ├→ Enter investigation findings
    ├→ Select response_type = INVESTIGATION_UPDATE
    ├→ Upload evidence photo (optional)
    └→ Click: Post Update
    ↓
PostResponse()
    ├→ INSERT incident_responses
    ├→ Store evidence → Assets/Evidence/
    └→ Log action in audit trail
    ↓
Take Actions
    ├→ Further investigation
    ├→ Interviews conducted
    ├→ Evidence collected
    └→ Post more updates
    ↓
Submit Final Report
    ├→ Enter final investigation findings
    ├→ Select response_type = FINAL_REPORT
    ├→ Upload final evidence
    └→ Click: Submit
    ↓
CloseAssignment()
    ├→ INSERT final response
    ├→ UPDATE status = RESOLVED
    └→ Admin can now review & close
```

---

### Workflow 5: Admin Closes Incident

```
Admin Reviews Resolved Incidents
    ↓
Query: incidents WHERE status=RESOLVED
    ├→ Patrol team final report ready
    ├→ Display for admin review
    └→ Show all responses & evidence
    ↓
Admin Reviews Final Report
    ├→ Read investigation findings
    ├→ View evidence and actions taken
    └→ Verify completeness
    ↓
Admin Closes Incident
    ├→ Click: Close Incident
    ├→ Add closure reason (optional)
    └→ Confirm
    ↓
CloseIncident()
    ├→ Validate: Status = RESOLVED
    ├→ UPDATE incidents SET status=CLOSED, closed_at=NOW
    ├→ INSERT incident_status_history (RESOLVED → CLOSED)
    └→ Log admin who closed
    ↓
Incident Archived
    ├→ Student can view final outcome
    ├→ All details available
    └→ Incident closed to changes
```

---

## 🎨 Design Patterns

### 1. Repository Pattern (Data Access)

```vb
Public Class IncidentRepository
    Public Shared Function GetPendingIncidents() As DataTable
        Dim sql = "SELECT * FROM incidents WHERE current_status = 'PENDING'"
        Return DatabaseManager.ExecuteQuery(sql, New Dictionary)
    End Function
    
    Public Function CreateIncident(title, description, campus, category) As Integer
        Dim sql = "INSERT INTO incidents (...) VALUES (...)"
        Return DatabaseManager.ExecuteNonQuery(sql, params)
    End Function
End Class
```

---

### 2. Session Management Pattern

```vb
Public Class SessionManager
    Public Shared CurrentUserId As Integer
    Public Shared CurrentUsername As String
    Public Shared CurrentRole As String ' ADMIN, STUDENT, SECURITY
    Public Shared CurrentCampusId As Integer
    
    Public Shared Sub Login(userId, username, role, campusId)
        CurrentUserId = userId
        CurrentUsername = username
        CurrentRole = role
        CurrentCampusId = campusId
    End Sub
End Class
```

---

### 3. Workflow State Pattern

```vb
Public Interface IIncidentWorkflow
    Function CanTransitionTo(newStatus As String) As Boolean
    Sub TransitionTo(newStatus As String)
End Interface

Public Class PendingIncident
    Implements IIncidentWorkflow
    
    Public Function CanTransitionTo(newStatus) As Boolean
        ' From PENDING, can only go to ASSIGNED or REJECTED
        Return newStatus = "ASSIGNED" Or newStatus = "REJECTED"
    End Function
End Class
```

---

## 🔐 Authentication & Authorization

### Authentication (SHA-256)

```vb
Private Sub LoginButton_Click()
    Dim username = txtUsername.Text
    Dim password = txtPassword.Text
    
    ' Query user
    Dim user = UserRepository.GetByUsername(username)
    
    If user Is Nothing Then
        MessageBox.Show("User not found")
        Return
    End If
    
    ' Hash input password and compare
    Dim inputHash = PasswordHasher.HashPassword(password)
    
    If inputHash = user.PasswordHash Then
        SessionManager.Login(user.UserId, user.Username, user.Role, user.CampusId)
        OpenDashboard(user.Role)
    Else
        MessageBox.Show("Invalid password")
    End If
End Sub
```

### Authorization (Role-Based)

```vb
' Hide/show features based on role
Public Sub ApplyRoleBasedUI()
    Select Case SessionManager.CurrentRole
        Case "ADMIN"
            ' Show admin features
            btnManageUsers.Visible = True
            btnAssignIncidents.Visible = True
            btnGenerateReports.Visible = True
            
        Case "SECURITY"
            ' Show security features
            btnAssignIncidents.Visible = False
            btnManageUsers.Visible = False
            btnInvestigate.Visible = True
            btnSubmitReport.Visible = True
            
        Case "STUDENT"
            ' Show student features
            btnReportIncident.Visible = True
            btnViewHistory.Visible = True
            btnInvestigate.Visible = False
    End Select
End Sub
```

---

## 🛡️ Security Architecture

### Input Validation

✅ **Parameterized Queries** (prevent SQL injection)

### Password Security

✅ **SHA-256 Hashing** (one-way cryptography)

### Session Security

✅ **In-Memory Sessions** (lost on application exit)
✅ **Role-Based Authorization** (check permissions before operations)

### Data Access Control

✅ **Row-Level Security** (students see own incidents, patrol teams see assigned incidents)

---

## 📁 File Storage & Evidence Management

### Evidence Storage Structure

```
Assets/
├── Evidence/
│   ├── INC-2026-10-0001_evidence_1.jpg
│   ├── INC-2026-10-0001_evidence_2.jpg
│   └── INC-2026-10-0002_evidence_1.jpg
```

### Evidence Upload Process

```vb
Private Sub UploadEvidenceImage(incidentReference, imagePath)
    ' Create Evidence folder if not exists
    Dim evidenceFolder = Path.Combine(AppPath, "Assets", "Evidence")
    
    If Not Directory.Exists(evidenceFolder) Then
        Directory.CreateDirectory(evidenceFolder)
    End If
    
    ' Save with incident reference and timestamp
    Dim fileName = $"{incidentReference}_evidence_{DateTime.Now:yyyyMMddHHmmss}.jpg"
    Dim destPath = Path.Combine(evidenceFolder, fileName)
    
    File.Copy(imagePath, destPath, overwrite:=True)
    
    ' Update database with path
    UpdateIncidentEvidencePath(incidentId, $"Assets/Evidence/{fileName}")
End Sub
```

---

## 🔔 Notification System

### Notification Types

```vb
Public NotificationQueue As List(Of Notification)

Public Sub NotifyPatrolTeam(patrolTeamId, message)
    ' Create notification record
    Dim notification = New Notification With {
        .RecipientId = patrolTeamId,
        .Message = message,
        .CreatedAt = DateTime.Now
    }
    
    ' Add to queue
    NotificationQueue.Add(notification)
    
    ' In production: Send via email/SMS
    SendEmailNotification(patrolTeamId, message)
End Sub

' Notification check on dashboard load
Private Sub Dashboard_Load()
    Dim notifications = GetUnreadNotifications(SessionManager.CurrentUserId)
    
    ' Update last_notification_check
    UpdateLastNotificationCheck(SessionManager.CurrentUserId, DateTime.Now)
    
    ' Display notifications in UI
    DisplayNotifications(notifications)
End Sub
```

---

## ⚠️ Error Handling & Logging

```vb
Public Function ProcessIncidentAssignment(incidentId, patrolTeamId) As Boolean
    Try
        ' Validation
        Dim incident = IncidentRepository.GetById(incidentId)
        If incident Is Nothing Then
            Throw New ArgumentException("Incident not found")
        End If
        
        ' Assignment logic
        AssignIncident(incident, patrolTeamId)
        Return True
        
    Catch ex As ArgumentException
        MessageBox.Show("Error: " & ex.Message, "Validation Error")
        LogError(ex, "Incident assignment validation failed")
        Return False
        
    Catch ex As SqlException
        MessageBox.Show("Database error: Check connection", "Error")
        LogError(ex, "Database error during assignment")
        Return False
        
    Catch ex As Exception
        MessageBox.Show("Unexpected error occurred", "Error")
        LogError(ex, "Unexpected error in ProcessIncidentAssignment")
        Return False
    End Try
End Function
```

---

## ⚡ Performance Optimization

### Database Indexing

```sql
-- Most critical indexes for incident searches
CREATE INDEX idx_incidents_status ON incidents(current_status);
CREATE INDEX idx_incidents_campus ON incidents(campus_id);
CREATE INDEX idx_incidents_reported_at ON incidents(reported_at);
CREATE INDEX idx_assignments_assigned_to ON incident_assignments(assigned_to_user_id);
```

### Query Caching

```vb
' Cache incident categories (rarely change)
Private Shared _cachedCategories As DataTable
Private Shared _cachedCategoriesTime As DateTime

Public Shared Function GetIncidentCategories() As DataTable
    ' Return cached if within 1 hour
    If _cachedCategories IsNot Nothing AndAlso _
       (DateTime.Now - _cachedCategoriesTime).TotalHours < 1 Then
        Return _cachedCategories
    End If
    
    ' Fetch from database
    _cachedCategories = DatabaseManager.ExecuteQuery(
        "SELECT * FROM incident_categories WHERE is_active = TRUE", 
        New Dictionary
    )
    _cachedCategoriesTime = DateTime.Now
    
    Return _cachedCategories
End Function
```

---

## 🚀 Scalability & Future Enhancements

### Phase 2 Enhancements

- [ ] Real email/SMS notifications to security teams
- [ ] Mobile app for patrol teams (real-time incident updates)
- [ ] Advanced analytics dashboard with charts
- [ ] Automated SOS alerts for critical incidents
- [ ] Integration with campus CCTV systems

### Phase 3+ Enhancements

- [ ] Web portal for 24/7 access
- [ ] Mobile app for students to report incidents
- [ ] Microservices architecture
- [ ] Cloud deployment (AWS, Azure)
- [ ] AI-powered incident analysis and pattern detection
- [ ] Integration with emergency response systems

---

## 📝 Development Standards

### Naming Conventions

```vb
' Classes
Public Class IncidentManagement
Public Class PatrolTeamAssignment

' Methods
Public Function ReportIncident()
Public Sub AssignToPatrol()

' Variables
Dim incidentId As Integer
Dim patrolTeamId As Integer

' Form controls
Private btnSubmit As Button
Private txtIncidentTitle As TextBox
Private dgvIncidents As DataGridView
```

---

## 🔗 Related Documentation

- **README.md** — Project overview and setup
- **DATABASE.md** — Complete database schema
- `Core/DatabaseQuery.txt` — SQL initialization
- `Core/ims.sql` — Pre-built database

---

**Version**: 1.0 (MVP)  
**Architecture Type**: Single-Tier Monolithic Desktop IMS  


🏗️ *Streamlined incident management for campus security.*
