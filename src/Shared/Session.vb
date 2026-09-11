Option Strict On
Option Explicit On

Public Module Session

    ' ---------------------------------------------------------
    ' 1. Global State Variables
    ' ---------------------------------------------------------
    Public Property CurrentUserId As Integer = 0
    Public Property CurrentUsername As String = String.Empty
    Public Property CurrentFullName As String = String.Empty
    Public Property CurrentRole As String = String.Empty
    Public Property CurrentCampusId As Integer? = Nothing

    ' ---------------------------------------------------------
    ' 2. The Gatekeeper Functions (RBAC)
    ' ---------------------------------------------------------

    ''' <summary>
    ''' Returns True if the current user is an Administrator.
    ''' </summary>
    Public Function IsAdmin() As Boolean
        Return CurrentRole.ToUpper() = "ADMIN"
    End Function

    ''' <summary>
    ''' Returns True if the current user is Campus Security.
    ''' </summary>
    Public Function IsSecurity() As Boolean
        Return CurrentRole.ToUpper() = "SECURITY"
    End Function

    ''' <summary>
    ''' Returns True if the current user is a Student.
    ''' </summary>
    Public Function IsStudent() As Boolean
        Return CurrentRole.ToUpper() = "STUDENT"
    End Function

    ''' <summary>
    ''' Ensures the user is logged in. Returns False if the session is empty.
    ''' </summary>
    Public Function IsAuthenticated() As Boolean
        Return CurrentUserId > 0
    End Function

    ' ---------------------------------------------------------
    ' 3. Session Lifecycle Management
    ' ---------------------------------------------------------

    ''' <summary>
    ''' Populates the global session. Call this ONLY after successfully verifying the password hash in the database.
    ''' </summary>
    Public Sub StartSession(id As Integer, username As String, fullName As String, role As String, campusId As Integer?)
        CurrentUserId = id
        CurrentUsername = username
        CurrentFullName = fullName
        CurrentRole = role
        CurrentCampusId = campusId
    End Sub

    ''' <summary>
    ''' Clears all session data. Call this on Logout.
    ''' </summary>
    Public Sub EndSession()
        CurrentUserId = 0
        CurrentUsername = String.Empty
        CurrentFullName = String.Empty
        CurrentRole = String.Empty
        CurrentCampusId = Nothing
    End Sub

End Module