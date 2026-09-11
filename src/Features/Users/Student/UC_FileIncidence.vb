Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class UC_FileIncidence

    Private errorProv As New ErrorProvider()
    Private generatedImageFilename As String = ""

    ' =================================================================
    ' 1. INITIALIZATION & UX SETUP
    ' =================================================================
    Private Sub UC_FileIncidence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        errorProv.BlinkStyle = ErrorBlinkStyle.NeverBlink
        pbxIncidentImage.SizeMode = PictureBoxSizeMode.Zoom

        ' Apply ToolTips for Guidance
        Dim incToolTip As New ToolTip() With {
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True,
            .AutoPopDelay = 5000,
            .InitialDelay = 500
        }
        incToolTip.SetToolTip(txtTitle, "Provide a short, clear title for the incident.")
        incToolTip.SetToolTip(txtDescription, "Describe what happened in detail.")
        incToolTip.SetToolTip(txtLocation, "Specify the exact physical location on campus.") ' ADD THIS TO YOUR UI
        incToolTip.SetToolTip(cmbCampuses, "Select the campus where this occurred.")
        incToolTip.SetToolTip(cmbIncidentCategory, "Categorize the nature of the incident.")
        incToolTip.SetToolTip(btnUploadIncidentPhoto, "Optional: Upload photographic evidence (JPG/PNG).")
        incToolTip.SetToolTip(btnCreateIncident, "Submit this incident to administration.")

        LoadCampuses()
        LoadCategories()
    End Sub

    ' =================================================================
    ' 2. DATABASE DATA BINDING
    ' =================================================================
    Private Sub LoadCampuses()
        Dim query As String = "SELECT campus_id, campus_name FROM campuses WHERE is_active = TRUE ORDER BY campus_name ASC"
        Dim dtCampuses As New DataTable()

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtCampuses)
                    End Using
                End Using
            End Using

            cmbCampuses.DataSource = dtCampuses
            cmbCampuses.DisplayMember = "campus_name"
            cmbCampuses.ValueMember = "campus_id"
            cmbCampuses.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show($"Failed to load campuses: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadCategories()
        Dim query As String = "SELECT category_id, category_name FROM incident_categories WHERE is_active = TRUE ORDER BY category_name ASC"
        Dim dtCategories As New DataTable()

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(query, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtCategories)
                    End Using
                End Using
            End Using

            cmbIncidentCategory.DataSource = dtCategories
            cmbIncidentCategory.DisplayMember = "category_name"
            cmbIncidentCategory.ValueMember = "category_id"
            cmbIncidentCategory.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show($"Failed to load categories: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =================================================================
    ' 3. FILE SYSTEM ARCHITECTURE (OPTIONAL EVIDENCE)
    ' =================================================================
    Private Sub btnUploadIncidentPhoto_Click(sender As Object, e As EventArgs) Handles btnUploadIncidentPhoto.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select Incident Evidence Photo"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png"

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    pbxIncidentImage.Image = Image.FromFile(ofd.FileName)

                    ' Isolate evidence photos in their own directory
                    Dim appStoragePath As String = Path.Combine(Application.StartupPath, "IncidentEvidence")
                    If Not Directory.Exists(appStoragePath) Then
                        Directory.CreateDirectory(appStoragePath)
                    End If

                    Dim fileExtension As String = Path.GetExtension(ofd.FileName)
                    ' Generate a unique name tying the file to the user and time
                    generatedImageFilename = $"evid_{Session.CurrentUserId}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{fileExtension}"
                    Dim targetFilePath As String = Path.Combine(appStoragePath, generatedImageFilename)

                    File.Copy(ofd.FileName, targetFilePath, True)

                Catch ex As Exception
                    MessageBox.Show($"Error processing image: {ex.Message}", "File System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    generatedImageFilename = ""
                    pbxIncidentImage.Image = Nothing
                End Try
            End If
        End Using
    End Sub

    ' =================================================================
    ' 4. KEYBOARD NAVIGATION
    ' =================================================================
    Private Sub InputControls_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTitle.KeyDown, txtLocation.KeyDown, cmbCampuses.KeyDown, cmbIncidentCategory.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub

    ' =================================================================
    ' 5. THE INSERT LOGIC & VALIDATION
    ' =================================================================
    Private Sub btnCreateIncident_Click(sender As Object, e As EventArgs) Handles btnCreateIncident.Click
        errorProv.Clear()
        Dim isValid As Boolean = True

        ' 1. Validate Title
        If String.IsNullOrWhiteSpace(txtTitle.Text) Then
            errorProv.SetError(txtTitle, "Title is required.")
            isValid = False
        End If

        ' 2. Validate Description
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            errorProv.SetError(txtDescription, "Description is required.")
            isValid = False
        End If

        ' 3. Validate Location (REQUIRED BY YOUR SCHEMA)
        If String.IsNullOrWhiteSpace(txtLocation.Text) Then
            errorProv.SetError(txtLocation, "Exact location is required.")
            isValid = False
        End If

        ' 4. Validate Campus
        If cmbCampuses.SelectedValue Is Nothing Then
            errorProv.SetError(cmbCampuses, "Please select a campus.")
            isValid = False
        End If

        ' 5. Validate Category
        If cmbIncidentCategory.SelectedValue Is Nothing Then
            errorProv.SetError(cmbIncidentCategory, "Please select an incident category.")
            isValid = False
        End If

        If Not isValid Then
            MessageBox.Show("Please correct the highlighted fields before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Prevent double submission
        btnCreateIncident.Enabled = False

        ' Generate unique reference ID (e.g., INC-20260726-ID)
        Dim incidentRef As String = $"INC-{DateTime.Now.ToString("yyyyMMddHHmmss")}-{Session.CurrentUserId}"
        Dim evidencePath As Object = If(String.IsNullOrEmpty(generatedImageFilename), DBNull.Value, generatedImageFilename)

        ' Fetch the default priority for the chosen category inside the query
        Dim insertQuery As String = "INSERT INTO incidents " &
            "(incident_reference, reported_by_user_id, campus_id, category_id, incident_title, incident_description, incident_location, priority_level, evidence_image_path, current_status) " &
            "VALUES " &
            "(@ref, @userId, @campusId, @categoryId, @title, @desc, @location, " &
            "(SELECT severity_default FROM incident_categories WHERE category_id = @categoryId), " &
            "@evidence, 'PENDING')"

        Try
            Using conn As MySqlConnection = Database.CreateOpenConnection()
                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@ref", incidentRef)
                    cmd.Parameters.AddWithValue("@userId", Session.CurrentUserId)
                    cmd.Parameters.AddWithValue("@campusId", Convert.ToInt32(cmbCampuses.SelectedValue))
                    cmd.Parameters.AddWithValue("@categoryId", Convert.ToInt32(cmbIncidentCategory.SelectedValue))
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim())
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim())
                    cmd.Parameters.AddWithValue("@location", txtLocation.Text.Trim())
                    cmd.Parameters.AddWithValue("@evidence", evidencePath)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show($"Incident reported successfully!" & vbCrLf & $"Your Reference ID is: {incidentRef}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear the form for the next entry
            ResetForm()

        Catch ex As Exception
            MessageBox.Show($"Failed to submit incident: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnCreateIncident.Enabled = True
        End Try
    End Sub

    Private Sub ResetForm()
        txtTitle.Clear()
        txtDescription.Clear()
        txtLocation.Clear()
        cmbCampuses.SelectedIndex = -1
        cmbIncidentCategory.SelectedIndex = -1
        pbxIncidentImage.Image = Nothing
        generatedImageFilename = ""
        errorProv.Clear()
        txtTitle.Focus()
    End Sub

    Private Sub PanelInputBundle_Paint(sender As Object, e As PaintEventArgs) Handles PanelInputBundle.Paint

    End Sub
End Class