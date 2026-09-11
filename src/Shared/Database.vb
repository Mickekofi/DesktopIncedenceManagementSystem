Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Database
    ' =======================================================
    ' DATABASE CONFIGURATION 
    ' Change these values here for easy development setup.
    ' =======================================================
    Private Shared ReadOnly dbServer As String = "127.0.0.1"
    Private Shared ReadOnly dbUser As String = "root"
    Private Shared ReadOnly dbPassword As String = ""
    Private Shared ReadOnly dbName As String = "ims_db"

    ' Use the builder to safely construct the string without syntax errors
    Private Shared ReadOnly Property ConnectionString As String
        Get
            Dim builder As New MySqlConnectionStringBuilder() With {
                .Server = dbServer,
                .UserID = dbUser,
                .Password = dbPassword,
                .Database = dbName,
                .Pooling = True,
                .MinimumPoolSize = 0,
                .MaximumPoolSize = 50
            }
            Return builder.ConnectionString
        End Get
    End Property
    ' =======================================================

    ''' <summary>
    ''' Instantiates and returns a brand-new, freshly opened connection object.
    ''' Wrap this inside a "Using" block in your forms to ensure it closes automatically.
    ''' </summary>
    Public Shared Function CreateOpenConnection() As MySqlConnection
        Dim conn As New MySqlConnection(ConnectionString)
        Try
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If
            Return conn
        Catch ex As MySqlException
            MessageBox.Show($"Database Connection Failure: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        End Try
    End Function











    '    '==================================================================
    '    CREATE TABLE If Not EXISTS users (

    '    user_id INT AUTO_INCREMENT PRIMARY KEY,

    '    username VARCHAR(50) Not NULL UNIQUE,

    '    password_hash VARCHAR(255) Not NULL,

    '    role Enum(
    '        'ADMIN',
    '        'STUDENT',
    '        'SECURITY'
    '    ) Not NULL,

    '    full_name VARCHAR(150) Not NULL,

    '    campus_id INT NULL,

    '    phone_number VARCHAR(20) NULL,

    '    profile_photo_path VARCHAR(255) NULL,

    '    first_login_completed BOOLEAN Not NULL DEFAULT FALSE,

    '    is_active BOOLEAN Not NULL DEFAULT TRUE,

    '    created_at DATETIME Not NULL Default CURRENT_TIMESTAMP,

    '    updated_at DATETIME Not NULL Default CURRENT_TIMESTAMP
    '        On UPDATE CURRENT_TIMESTAMP

    ') ENGINE=InnoDB;



    'CREATE TABLE If Not EXISTS campuses (

    '    campus_id INT AUTO_INCREMENT PRIMARY KEY,

    '    campus_name VARCHAR(100) Not NULL UNIQUE,

    '    campus_code VARCHAR(20) Not NULL UNIQUE,

    '    campus_description VARCHAR(255) NULL,

    '    is_active BOOLEAN Not NULL DEFAULT TRUE,

    '    created_at DATETIME Not NULL Default CURRENT_TIMESTAMP,

    '    updated_at DATETIME Not NULL Default CURRENT_TIMESTAMP
    '        On UPDATE CURRENT_TIMESTAMP

    ') ENGINE=InnoDB;




    'CREATE TABLE If Not EXISTS incident_categories (

    '    category_id INT AUTO_INCREMENT PRIMARY KEY,

    '    category_name VARCHAR(100) Not NULL UNIQUE,

    '    category_description VARCHAR(500) NULL,

    '    severity_default Enum(
    '        'LOW',
    '        'MEDIUM',
    '        'HIGH',
    '        'CRITICAL'
    '    ) Not NULL DEFAULT 'MEDIUM',

    '    is_active BOOLEAN Not NULL DEFAULT TRUE,

    '    created_at DATETIME Not NULL Default CURRENT_TIMESTAMP,

    '    updated_at DATETIME Not NULL Default CURRENT_TIMESTAMP
    '        On UPDATE CURRENT_TIMESTAMP

    ') ENGINE=InnoDB;



    'CREATE TABLE If Not EXISTS incidents (

    '    incident_id INT AUTO_INCREMENT PRIMARY KEY,

    '    incident_reference VARCHAR(30) Not NULL UNIQUE,

    '    reported_by_user_id INT Not NULL,

    '    campus_id INT Not NULL,

    '    category_id INT Not NULL,

    '    incident_title VARCHAR(200) Not NULL,

    '    incident_description TEXT Not NULL,

    '    incident_location VARCHAR(255) Not NULL,

    '    priority_level Enum(
    '        'LOW',
    '        'MEDIUM',
    '        'HIGH',
    '        'CRITICAL'
    '    ) Not NULL DEFAULT 'MEDIUM',

    '    evidence_image_path VARCHAR(255) NULL,

    '    current_status Enum(
    '        'PENDING',
    '        'ASSIGNED',
    '        'IN_PROGRESS',
    '        'RESOLVED',
    '        'CLOSED',
    '        'REJECTED'
    '    ) Not NULL DEFAULT 'PENDING',

    '    reported_at DATETIME Not NULL Default CURRENT_TIMESTAMP,

    '    closed_at DATETIME NULL,

    '    CONSTRAINT fk_incident_reporter
    '        FOREIGN KEY(reported_by_user_id)
    '        REFERENCES users(user_id),

    '    CONSTRAINT fk_incident_campus
    '        FOREIGN KEY(campus_id)
    '        REFERENCES campuses(campus_id),

    '    CONSTRAINT fk_incident_category
    '        FOREIGN KEY(category_id)
    '        REFERENCES incident_categories(category_id)

    ') ENGINE=InnoDB;



    'CREATE TABLE If Not EXISTS incident_assignments (

    '    assignment_id INT AUTO_INCREMENT PRIMARY KEY,

    '    incident_id INT Not NULL,

    '    assigned_by_user_id INT Not NULL,

    '    assigned_to_user_id INT Not NULL,

    '    assignment_notes TEXT NULL,

    '    assignment_status Enum(
    '        'ACTIVE',
    '        'REASSIGNED',
    '        'COMPLETED',
    '        'CANCELLED'
    '    ) Not NULL DEFAULT 'ACTIVE',

    '    assigned_at DATETIME Not NULL Default CURRENT_TIMESTAMP,

    '    completed_at DATETIME NULL,

    '    CONSTRAINT fk_assignment_incident
    '        FOREIGN KEY(incident_id)
    '        REFERENCES incidents(incident_id),

    '    CONSTRAINT fk_assignment_admin
    '        FOREIGN KEY(assigned_by_user_id)
    '        REFERENCES users(user_id),

    '    CONSTRAINT fk_assignment_security
    '        FOREIGN KEY(assigned_to_user_id)
    '        REFERENCES users(user_id)

    ') ENGINE=InnoDB;



    'CREATE TABLE If Not EXISTS incident_responses (

    '    response_id INT AUTO_INCREMENT PRIMARY KEY,

    '    incident_id INT Not NULL,

    '    responded_by_user_id INT Not NULL,

    '    response_type Enum(
    '        'INVESTIGATION_UPDATE',
    '        'ACTION_TAKEN',
    '        'FINAL_REPORT'
    '    ) Not NULL,

    '    response_details TEXT Not NULL,

    '    evidence_image_path VARCHAR(255) NULL,

    '    response_date DATETIME Not NULL Default CURRENT_TIMESTAMP,

    '    CONSTRAINT fk_response_incident
    '        FOREIGN KEY(incident_id)
    '        REFERENCES incidents(incident_id),

    '    CONSTRAINT fk_response_security
    '        FOREIGN KEY(responded_by_user_id)
    '        REFERENCES users(user_id)

    ') ENGINE=InnoDB;



    'CREATE TABLE If Not EXISTS incident_status_history (

    '    status_history_id INT AUTO_INCREMENT PRIMARY KEY,

    '    incident_id INT Not NULL,

    '    changed_by_user_id INT Not NULL,

    '    previous_status Enum(
    '        'PENDING',
    '        'ASSIGNED',
    '        'IN_PROGRESS',
    '        'RESOLVED',
    '        'CLOSED',
    '        'REJECTED'
    '    ) Not NULL,

    '    new_status Enum(
    '        'PENDING',
    '        'ASSIGNED',
    '        'IN_PROGRESS',
    '        'RESOLVED',
    '        'CLOSED',
    '        'REJECTED'
    '    ) Not NULL,

    '    change_reason VARCHAR(255) NULL,

    '    changed_at DATETIME Not NULL Default CURRENT_TIMESTAMP,

    '    CONSTRAINT fk_status_incident
    '        FOREIGN KEY(incident_id)
    '        REFERENCES incidents(incident_id),

    '    CONSTRAINT fk_status_user
    '        FOREIGN KEY(changed_by_user_id)
    '        REFERENCES users(user_id)

    ') ENGINE=InnoDB;


    'Insertion Of 1st Admin
    '===========================================================

    '    INSERT INTO users (
    '    username, 
    '    password_hash, 
    '    role, 
    '    full_name, 
    '    campus_id, 
    '    phone_number, 
    '    first_login_completed, 
    '    is_active
    ') VALUES (
    '    'Admin', 
    '    '', 
    '    'ADMIN', 
    '    'System Administrator', 
    '    NULL, 
    '    '0200000000', 
    '    TRUE, 
    '    TRUE
    ');













End Class