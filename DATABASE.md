# 🗄️ Database Schema & Documentation

**Desktop Incidence Management System (IMS) — Database Design Reference**

Complete documentation of the MySQL database structure, relationships, constraints, and data dictionary.

---

![Preview](https://github.com/Mickekofi/DesktopIncedenceManagementSystem/blob/master/AppImages/db_image.png)


## 📋 Table of Contents

- [Database Overview](#database-overview)
- [Core Concepts](#core-concepts)
- [Entity Relationship Diagram](#entity-relationship-diagram)
- [Complete Schema Reference](#complete-schema-reference)
  - [User Management](#user-management)
  - [Campus Configuration](#campus-configuration)
  - [Incident Categories](#incident-categories)
  - [Incident Tracking](#incident-tracking)
  - [Assignment & Response](#assignment--response)
  - [Audit Trail](#audit-trail)
- [Data Dictionary](#data-dictionary)
- [Relationships & Constraints](#relationships--constraints)
- [Indexes & Performance](#indexes--performance)
- [Initialization & Sample Data](#initialization--sample-data)
- [SQL Scripts & Deployment](#sql-scripts--deployment)
- [Best Practices](#best-practices)

---

## 📊 Database Overview

### Database Name
```sql
ims_db
```

### Database Properties
- **Character Set**: UTF8MB4 (international character support)
- **Collation**: UTF8MB4_UNICODE_CI (case-insensitive)
- **Engine**: InnoDB (ACID transactions, foreign keys)
- **Total Tables**: 7 core tables with relationships

### Key Features
✅ **ACID Compliance** — Transaction integrity
✅ **Referential Integrity** — Foreign key constraints
✅ **Cascading Operations** — Automatic related record updates
✅ **Complete Audit Trail** — Status change tracking with timestamps
✅ **Role-Based Isolation** — Data access by user role and campus

---

## 🎯 Core Concepts

### 1. Incident Lifecycle Model

```
PENDING (Reported by student, awaiting assignment)
    ↓ [Admin assigns]
ASSIGNED (Assigned to patrol team)
    ↓ [Patrol acknowledges]
IN_PROGRESS (Active investigation)
    ↓ [Patrol submits final report]
RESOLVED (Investigation complete, awaiting admin closure)
    ↓ [Admin closes]
CLOSED (Incident archived)

Alternative outcomes:
REJECTED (Admin rejects incident)
```

### 2. Multi-Campus Architecture

System supports multiple university campuses:
```
University
├── North Campus
├── South Campus
└── Central Campus

Each campus has:
- Incident reports (students report on their campus)
- Security patrol teams (assigned to specific campus)
- Independent incident tracking (filter by campus)
```

### 3. Three-Tier User Model

```
Student (Reports incidents)
    └─ Can report on assigned campus
    └─ Can view own incident history

Security (Investigates & responds)
    └─ Assigned to specific campus
    └─ Can investigate assigned incidents
    └─ Post updates and final reports

Admin (Manages system)
    └─ Oversees all campuses
    └─ Assigns incidents to teams
    └─ Closes incidents
    └─ Generates reports
```

### 4. Incident Assignment Workflow

```
Student Reports Incident (Status: PENDING)
    ↓
Admin Reviews Incident
    └─ Checks: Category, Location, Evidence, Priority
    ↓
Admin Assigns to Patrol Team (Status: ASSIGNED)
    ├─ Selects patrol team for incident's campus
    ├─ Records assignment in incident_assignments
    └─ Sends notification to patrol team
    ↓
Patrol Team Investigates (Status: IN_PROGRESS)
    ├─ Posts investigation updates
    ├─ Takes actions and logs them
    └─ Collects evidence
    ↓
Patrol Team Submits Final Report (Status: RESOLVED)
    └─ Complete findings with evidence
    ↓
Admin Reviews & Closes (Status: CLOSED)
    └─ Formally closes incident
    └─ Archives for reporting
```

---

## 📐 Entity Relationship Diagram

```
┌──────────────────────────┐
│        users             │
├──────────────────────────┤
│ user_id (PK)             │
│ username (UNIQUE)        │◄──────────────┐
│ password_hash            │                │
│ role (ADMIN/STUDENT...)  │                │
│ full_name                │                │
│ campus_id (FK)           │                │
│ phone_number             │                │
│ profile_photo_path       │                │
│ first_login_completed    │                │
│ last_notification_check  │                │
│ is_active                │                │
│ created_at               │                │
│ updated_at               │                │
└────┬──────────────────┬──┘                │
     │ (1:M)           │ (reports)         │
     │              ┌──┘                   │
     │              │                      │
┌────▼──────────────▼──────┐    ┌──────────┤
│      incidents           │    │          │
├──────────────────────────┤    │          │
│ incident_id (PK)         │    │          │
│ incident_reference (U)   │    │          │
│ reported_by_user_id(FK)◄─┘    │          │
│ campus_id (FK) ──────────┐    │          │
│ category_id (FK)         │    │          │
│ incident_title           │    │          │
│ incident_description     │    │          │
│ incident_location        │    │          │
│ priority_level           │    │          │
│ evidence_image_path      │    │          │
│ current_status           │    │          │
│ reported_at              │    │          │
│ closed_at                │    │          │
└────┬──────────────┬──────┘    │          │
     │ (1:M)        │ (1:M)     │          │
     │              │           │          │
┌────▼──────────────────┐  ┌────▼────────┴───┐
│ incident_assignments  │  │  incident_      │
├───────────────────────┤  │  responses      │
│ assignment_id (PK)    │  ├────────────────┤
│ incident_id (FK)      │  │ response_id(PK)│
│ assigned_by_user_id   │  │ incident_id(FK)│
│ assigned_to_user_id   │  │ responded_by   │
│ assignment_notes      │  │ response_type  │
│ assignment_status     │  │ response_detls │
│ assigned_at           │  │ evidence_image │
│ completed_at          │  │ response_date  │
└───────────────────────┘  └────────────────┘

┌──────────────────────────┐
│   incident_status_       │
│       history            │
├──────────────────────────┤
│ status_history_id (PK)   │
│ incident_id (FK)         │
│ changed_by_user_id (FK)  │
│ previous_status          │
│ new_status               │
│ change_reason            │
│ changed_at               │
└──────────────────────────┘

┌──────────────────────────┐
│     campuses             │
├──────────────────────────┤
│ campus_id (PK)           │
│ campus_name (UNIQUE)     │
│ campus_code (UNIQUE)     │
│ campus_description       │
│ is_active                │
│ created_at               │
│ updated_at               │
└──────────────────────────┘

┌──────────────────────────┐
│ incident_categories      │
├──────────────────────────┤
│ category_id (PK)         │
│ category_name (UNIQUE)   │
│ category_description     │
│ severity_default         │
│ is_active                │
│ created_at               │
│ updated_at               │
└──────────────────────────┘
```

---

## 🔐 Complete Schema Reference

### TABLE 1: `users`

Represents all system users (Admin, Student, Security).

```sql
CREATE TABLE IF NOT EXISTS users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role ENUM('ADMIN','STUDENT','SECURITY') NOT NULL,
    full_name VARCHAR(150) NOT NULL,
    campus_id INT NULL,
    phone_number VARCHAR(20) NULL,
    profile_photo_path VARCHAR(255) NULL,
    first_login_completed BOOLEAN NOT NULL DEFAULT FALSE,
    last_notification_check DATETIME NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB;
```

**Column Details**:

| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `user_id` | INT | PK, AUTO_INCREMENT | Unique user identifier |
| `username` | VARCHAR(50) | NOT NULL, UNIQUE | Login username |
| `password_hash` | VARCHAR(255) | NOT NULL | SHA-256 hashed password |
| `role` | ENUM | NOT NULL | ADMIN, STUDENT, or SECURITY |
| `full_name` | VARCHAR(150) | NOT NULL | User's full name |
| `campus_id` | INT | NULLABLE, FK | References campuses (null for admin) |
| `phone_number` | VARCHAR(20) | NULLABLE | Contact phone |
| `profile_photo_path` | VARCHAR(255) | NULLABLE | Path to profile photo |
| `first_login_completed` | BOOLEAN | DEFAULT FALSE | First login flag |
| `last_notification_check` | DATETIME | NULLABLE | Last notification check time |
| `is_active` | BOOLEAN | DEFAULT TRUE | Account active/inactive |
| `created_at` | DATETIME | DEFAULT NOW | Creation timestamp |
| `updated_at` | DATETIME | AUTO-UPDATE | Modification timestamp |

**Example Data**:
```sql
-- Admin user
INSERT INTO users (username, password_hash, role, full_name, is_active)
VALUES ('admin', SHA2('admin', 256), 'ADMIN', 'System Administrator', TRUE);

-- Student
INSERT INTO users (username, password_hash, role, full_name, campus_id)
VALUES ('JohnDoe', SHA2('pass123', 256), 'STUDENT', 'John Doe', 1);

-- Security Patrol
INSERT INTO users (username, password_hash, role, full_name, campus_id)
VALUES ('NorthPatrol', SHA2('patrol123', 256), 'SECURITY', 'North Campus Patrol', 1);
```

---

### TABLE 2: `campuses`

Represents university campuses.

```sql
CREATE TABLE IF NOT EXISTS campuses (
    campus_id INT AUTO_INCREMENT PRIMARY KEY,
    campus_name VARCHAR(100) NOT NULL UNIQUE,
    campus_code VARCHAR(20) NOT NULL UNIQUE,
    campus_description VARCHAR(255) NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB;
```

**Column Details**:

| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `campus_id` | INT | PK, AUTO_INCREMENT | Unique campus identifier |
| `campus_name` | VARCHAR(100) | NOT NULL, UNIQUE | Campus name (e.g., "North Campus") |
| `campus_code` | VARCHAR(20) | NOT NULL, UNIQUE | Campus code (e.g., "NC") |
| `campus_description` | VARCHAR(255) | NULLABLE | Campus description |
| `is_active` | BOOLEAN | DEFAULT TRUE | Campus active/inactive |
| `created_at` | DATETIME | DEFAULT NOW | Creation timestamp |
| `updated_at` | DATETIME | AUTO-UPDATE | Modification timestamp |

**Example Data**:
```sql
INSERT INTO campuses (campus_name, campus_code, campus_description)
VALUES 
('North Campus', 'NC', 'Northern campus location'),
('South Campus', 'SC', 'Southern campus location'),
('Central Campus', 'CC', 'Central campus location');
```

---

### TABLE 3: `incident_categories`

Defines types of incidents that can be reported.

```sql
CREATE TABLE IF NOT EXISTS incident_categories (
    category_id INT AUTO_INCREMENT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL UNIQUE,
    category_description VARCHAR(500) NULL,
    severity_default ENUM('LOW','MEDIUM','HIGH','CRITICAL') NOT NULL DEFAULT 'MEDIUM',
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB;
```

**Column Details**:

| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `category_id` | INT | PK, AUTO_INCREMENT | Unique category identifier |
| `category_name` | VARCHAR(100) | NOT NULL, UNIQUE | Category name (e.g., "Theft") |
| `category_description` | VARCHAR(500) | NULLABLE | Detailed description |
| `severity_default` | ENUM | DEFAULT 'MEDIUM' | Default severity: LOW, MEDIUM, HIGH, CRITICAL |
| `is_active` | BOOLEAN | DEFAULT TRUE | Category active/inactive |
| `created_at` | DATETIME | DEFAULT NOW | Creation timestamp |
| `updated_at` | DATETIME | AUTO-UPDATE | Modification timestamp |

**Example Data**:
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

---

### TABLE 4: `incidents`

**CORE TABLE** — Stores all incident reports.

```sql
CREATE TABLE IF NOT EXISTS incidents (
    incident_id INT AUTO_INCREMENT PRIMARY KEY,
    incident_reference VARCHAR(30) NOT NULL UNIQUE,
    reported_by_user_id INT NOT NULL,
    campus_id INT NOT NULL,
    category_id INT NOT NULL,
    incident_title VARCHAR(200) NOT NULL,
    incident_description TEXT NOT NULL,
    incident_location VARCHAR(255) NOT NULL,
    priority_level ENUM('LOW','MEDIUM','HIGH','CRITICAL') NOT NULL DEFAULT 'MEDIUM',
    evidence_image_path VARCHAR(255) NULL,
    current_status ENUM('PENDING','ASSIGNED','IN_PROGRESS','RESOLVED','CLOSED','REJECTED') NOT NULL DEFAULT 'PENDING',
    reported_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    closed_at DATETIME NULL,
    CONSTRAINT fk_incident_reporter
        FOREIGN KEY (reported_by_user_id) REFERENCES users(user_id),
    CONSTRAINT fk_incident_campus
        FOREIGN KEY (campus_id) REFERENCES campuses(campus_id),
    CONSTRAINT fk_incident_category
        FOREIGN KEY (category_id) REFERENCES incident_categories(category_id)
) ENGINE=InnoDB;
```

**Column Details**:

| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `incident_id` | INT | PK, AUTO_INCREMENT | Unique incident identifier |
| `incident_reference` | VARCHAR(30) | NOT NULL, UNIQUE | Reference number (e.g., "INC-2026-10-0001") |
| `reported_by_user_id` | INT | NOT NULL, FK | Student who reported (references users.user_id) |
| `campus_id` | INT | NOT NULL, FK | Campus where incident occurred (references campuses.campus_id) |
| `category_id` | INT | NOT NULL, FK | Incident category (references incident_categories.category_id) |
| `incident_title` | VARCHAR(200) | NOT NULL | Brief incident title |
| `incident_description` | TEXT | NOT NULL | Detailed incident description |
| `incident_location` | VARCHAR(255) | NOT NULL | Specific location on campus |
| `priority_level` | ENUM | DEFAULT 'MEDIUM' | Severity: LOW, MEDIUM, HIGH, CRITICAL |
| `evidence_image_path` | VARCHAR(255) | NULLABLE | Path to evidence photo |
| `current_status` | ENUM | DEFAULT 'PENDING' | Current status in lifecycle |
| `reported_at` | DATETIME | DEFAULT NOW | When reported |
| `closed_at` | DATETIME | NULLABLE | When incident closed |

**Status Values**:
- **PENDING** — Just reported, awaiting admin assignment
- **ASSIGNED** — Assigned to patrol team
- **IN_PROGRESS** — Actively being investigated
- **RESOLVED** — Investigation complete, awaiting admin closure
- **CLOSED** — Formally closed by admin
- **REJECTED** — Admin rejected the incident

**Example**:
```sql
INSERT INTO incidents (
    incident_reference, reported_by_user_id, campus_id, category_id,
    incident_title, incident_description, incident_location, priority_level
) VALUES (
    'INC-2026-10-0001', 1, 1, 1,
    'Laptop Stolen from Dormitory',
    'Student reported laptop missing from dormitory room after weekend',
    'Building A, Room 201',
    'MEDIUM'
);
```

---

### TABLE 5: `incident_assignments`

Tracks which patrol team is assigned to each incident.

```sql
CREATE TABLE IF NOT EXISTS incident_assignments (
    assignment_id INT AUTO_INCREMENT PRIMARY KEY,
    incident_id INT NOT NULL,
    assigned_by_user_id INT NOT NULL,
    assigned_to_user_id INT NOT NULL,
    assignment_notes TEXT NULL,
    assignment_status ENUM('ACTIVE','REASSIGNED','COMPLETED','CANCELLED') NOT NULL DEFAULT 'ACTIVE',
    assigned_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    completed_at DATETIME NULL,
    CONSTRAINT fk_assignment_incident
        FOREIGN KEY (incident_id) REFERENCES incidents(incident_id),
    CONSTRAINT fk_assignment_admin
        FOREIGN KEY (assigned_by_user_id) REFERENCES users(user_id),
    CONSTRAINT fk_assignment_security
        FOREIGN KEY (assigned_to_user_id) REFERENCES users(user_id)
) ENGINE=InnoDB;
```

**Column Details**:

| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `assignment_id` | INT | PK, AUTO_INCREMENT | Unique assignment identifier |
| `incident_id` | INT | NOT NULL, FK | References incidents.incident_id |
| `assigned_by_user_id` | INT | NOT NULL, FK | Admin who assigned (references users.user_id) |
| `assigned_to_user_id` | INT | NOT NULL, FK | Patrol team assigned to (references users.user_id) |
| `assignment_notes` | TEXT | NULLABLE | Notes from admin |
| `assignment_status` | ENUM | DEFAULT 'ACTIVE' | ACTIVE, REASSIGNED, COMPLETED, CANCELLED |
| `assigned_at` | DATETIME | DEFAULT NOW | Assignment timestamp |
| `completed_at` | DATETIME | NULLABLE | When assignment completed |

---

### TABLE 6: `incident_responses`

Patrol team's investigation updates and final report.

```sql
CREATE TABLE IF NOT EXISTS incident_responses (
    response_id INT AUTO_INCREMENT PRIMARY KEY,
    incident_id INT NOT NULL,
    responded_by_user_id INT NOT NULL,
    response_type ENUM('INVESTIGATION_UPDATE','ACTION_TAKEN','FINAL_REPORT') NOT NULL,
    response_details TEXT NOT NULL,
    evidence_image_path VARCHAR(255) NULL,
    response_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_response_incident
        FOREIGN KEY (incident_id) REFERENCES incidents(incident_id),
    CONSTRAINT fk_response_security
        FOREIGN KEY (responded_by_user_id) REFERENCES users(user_id)
) ENGINE=InnoDB;
```

**Column Details**:

| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `response_id` | INT | PK, AUTO_INCREMENT | Unique response identifier |
| `incident_id` | INT | NOT NULL, FK | References incidents.incident_id |
| `responded_by_user_id` | INT | NOT NULL, FK | Security team member (references users.user_id) |
| `response_type` | ENUM | NOT NULL | INVESTIGATION_UPDATE, ACTION_TAKEN, FINAL_REPORT |
| `response_details` | TEXT | NOT NULL | Detailed response content |
| `evidence_image_path` | VARCHAR(255) | NULLABLE | Evidence photo path |
| `response_date` | DATETIME | DEFAULT NOW | Response timestamp |

**Response Types**:
- **INVESTIGATION_UPDATE** — Progress update on investigation
- **ACTION_TAKEN** — Specific action performed
- **FINAL_REPORT** — Complete investigation findings

---

### TABLE 7: `incident_status_history`

**AUDIT TABLE** — Complete history of all status changes.

```sql
CREATE TABLE IF NOT EXISTS incident_status_history (
    status_history_id INT AUTO_INCREMENT PRIMARY KEY,
    incident_id INT NOT NULL,
    changed_by_user_id INT NOT NULL,
    previous_status ENUM('PENDING','ASSIGNED','IN_PROGRESS','RESOLVED','CLOSED','REJECTED') NOT NULL,
    new_status ENUM('PENDING','ASSIGNED','IN_PROGRESS','RESOLVED','CLOSED','REJECTED') NOT NULL,
    change_reason VARCHAR(255) NULL,
    changed_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_status_incident
        FOREIGN KEY (incident_id) REFERENCES incidents(incident_id),
    CONSTRAINT fk_status_user
        FOREIGN KEY (changed_by_user_id) REFERENCES users(user_id)
) ENGINE=InnoDB;
```

**Column Details**:

| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `status_history_id` | INT | PK, AUTO_INCREMENT | Unique history record ID |
| `incident_id` | INT | NOT NULL, FK | References incidents.incident_id |
| `changed_by_user_id` | INT | NOT NULL, FK | User making change (references users.user_id) |
| `previous_status` | ENUM | NOT NULL | Status before change |
| `new_status` | ENUM | NOT NULL | Status after change |
| `change_reason` | VARCHAR(255) | NULLABLE | Reason for change |
| `changed_at` | DATETIME | DEFAULT NOW | Change timestamp |

---

## 📊 Data Dictionary

### Enumeration Values

| Table | Column | Values | Description |
|-------|--------|--------|-------------|
| `users` | `role` | ADMIN, STUDENT, SECURITY | User type |
| `incident_categories` | `severity_default` | LOW, MEDIUM, HIGH, CRITICAL | Default severity |
| `incidents` | `priority_level` | LOW, MEDIUM, HIGH, CRITICAL | Incident severity |
| `incidents` | `current_status` | PENDING, ASSIGNED, IN_PROGRESS, RESOLVED, CLOSED, REJECTED | Incident state |
| `incident_assignments` | `assignment_status` | ACTIVE, REASSIGNED, COMPLETED, CANCELLED | Assignment state |
| `incident_responses` | `response_type` | INVESTIGATION_UPDATE, ACTION_TAKEN, FINAL_REPORT | Response type |
| `incident_status_history` | `previous_status` | (same as incidents.current_status) | Previous state |
| `incident_status_history` | `new_status` | (same as incidents.current_status) | New state |

---

## 🔗 Relationships & Constraints

### Foreign Key Relationships

| Constraint | From Table | Column | To Table | Column | Action |
|-----------|-----------|--------|----------|--------|--------|
| `fk_incident_reporter` | `incidents` | `reported_by_user_id` | `users` | `user_id` | RESTRICT |
| `fk_incident_campus` | `incidents` | `campus_id` | `campuses` | `campus_id` | RESTRICT |
| `fk_incident_category` | `incidents` | `category_id` | `incident_categories` | `category_id` | RESTRICT |
| `fk_assignment_incident` | `incident_assignments` | `incident_id` | `incidents` | `incident_id` | RESTRICT |
| `fk_assignment_admin` | `incident_assignments` | `assigned_by_user_id` | `users` | `user_id` | RESTRICT |
| `fk_assignment_security` | `incident_assignments` | `assigned_to_user_id` | `users` | `user_id` | RESTRICT |
| `fk_response_incident` | `incident_responses` | `incident_id` | `incidents` | `incident_id` | RESTRICT |
| `fk_response_security` | `incident_responses` | `responded_by_user_id` | `users` | `user_id` | RESTRICT |
| `fk_status_incident` | `incident_status_history` | `incident_id` | `incidents` | `incident_id` | RESTRICT |
| `fk_status_user` | `incident_status_history` | `changed_by_user_id` | `users` | `user_id` | RESTRICT |

---

## 🚀 Indexes & Performance

### Recommended Indexes

```sql
-- Users table
CREATE INDEX idx_users_username ON users(username);
CREATE INDEX idx_users_role ON users(role);
CREATE INDEX idx_users_campus_id ON users(campus_id);

-- Campuses
CREATE INDEX idx_campuses_is_active ON campuses(is_active);

-- Incident Categories
CREATE INDEX idx_categories_is_active ON incident_categories(is_active);

-- Incidents (most critical)
CREATE INDEX idx_incidents_incident_reference ON incidents(incident_reference);
CREATE INDEX idx_incidents_reported_by ON incidents(reported_by_user_id);
CREATE INDEX idx_incidents_campus_id ON incidents(campus_id);
CREATE INDEX idx_incidents_category_id ON incidents(category_id);
CREATE INDEX idx_incidents_current_status ON incidents(current_status);
CREATE INDEX idx_incidents_priority_level ON incidents(priority_level);
CREATE INDEX idx_incidents_reported_at ON incidents(reported_at);

-- Incident Assignments
CREATE INDEX idx_assignments_incident_id ON incident_assignments(incident_id);
CREATE INDEX idx_assignments_assigned_to ON incident_assignments(assigned_to_user_id);
CREATE INDEX idx_assignments_status ON incident_assignments(assignment_status);

-- Incident Responses
CREATE INDEX idx_responses_incident_id ON incident_responses(incident_id);
CREATE INDEX idx_responses_response_type ON incident_responses(response_type);

-- Status History (audit trail)
CREATE INDEX idx_status_incident_id ON incident_status_history(incident_id);
CREATE INDEX idx_status_changed_by ON incident_status_history(changed_by_user_id);
```

---

## 🌱 Initialization & Sample Data

### Fresh Database Setup

```sql
CREATE DATABASE IF NOT EXISTS ims_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE ims_db;

-- Run all CREATE TABLE statements from DatabaseQuery.txt
```

### Create Admin User

```sql
INSERT INTO users (username, password_hash, role, full_name, is_active)
VALUES ('admin', SHA2('admin', 256), 'ADMIN', 'System Administrator', TRUE);
```

### Create Sample Campuses

```sql
INSERT INTO campuses (campus_name, campus_code, campus_description)
VALUES 
('North Campus', 'NC', 'Northern campus location'),
('South Campus', 'SC', 'Southern campus location'),
('Central Campus', 'CC', 'Central campus location');
```

### Create Incident Categories

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

---

## 🔧 SQL Scripts & Deployment

### Backup Database

```bash
mysqldump -u root -p ims_db > ims_db_backup_$(date +%Y%m%d_%H%M%S).sql
```

### Restore Database

```bash
mysql -u root -p ims_db < ims_db_backup_20261015_143022.sql
```

### Check Incident Count by Campus

```sql
SELECT 
    c.campus_name,
    COUNT(i.incident_id) as total_incidents,
    SUM(CASE WHEN i.current_status = 'CLOSED' THEN 1 ELSE 0 END) as closed,
    SUM(CASE WHEN i.current_status = 'PENDING' THEN 1 ELSE 0 END) as pending
FROM incidents i
INNER JOIN campuses c ON i.campus_id = c.campus_id
GROUP BY c.campus_id, c.campus_name;
```

---

## ✅ Best Practices

### Data Integrity

✅ **Always use parameterized queries** (prevent SQL injection)
✅ **Validate foreign key references** before inserting
✅ **Use transactions** for multi-step operations
✅ **Archive old data** rather than deleting

### Query Optimization

✅ **Index frequently-searched columns** (status, campus, user)
✅ **Use LIMIT clauses** when fetching lists
✅ **Avoid N+1 queries** — join tables instead
✅ **Cache incident categories and campuses** (rarely change)

### Security

✅ **Hash passwords** (SHA-256 or bcrypt)
✅ **Encrypt sensitive data** (evidence photos)
✅ **Restrict database user permissions** (no DROP privileges)
✅ **Use SSL/TLS** for database connections (production)

### Maintenance

✅ **Regular backups** (daily in production)
✅ **Monitor audit trail** for anomalies
✅ **Archive closed incidents** periodically
✅ **Clean up old responses** after 2 years

---

## 📚 Related Documentation

- **README.md** — System overview and setup
- **ARCHITECTURE.md** — System design and workflows
- **DatabaseQuery.txt** — Raw SQL for fresh setup
- **ims.sql** — Pre-built database with sample data

---

**Version**: 1.0  
**Database Engine**: MySQL 5.7 / 8.0  



🗄️ *Complete audit-ready incident tracking database.*
