Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports GHAU_CapaNegocio.Excel
Imports GHAU_CapaDatos.BaseDato


Public Class ImportarHorario
    Dim dt As New GHAU_CapaNegocio.Excel
    Dim dt2 As New GHAU_CapaNegocio.ImportarHorario
    Dim _GRILLA_ As DataTable

    Private Sub BTNAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        abrir()

    End Sub
    Sub abrir()
        Dim openFileDialog1 As New OpenFileDialog
        Grilla_Ex.DataSource = Nothing
        Dim fichero = Environment.GetEnvironmentVariable("windir") 'Busca en que disco esta a carpeta de windows
        'Abre Directorio Predeterminado
        openFileDialog1.InitialDirectory = fichero
        'Filtramos solo archivos con extension *.xls
        openFileDialog1.Filter = "Archivos de Microsoft Office Excel (*.xls)|*.xls"
        'Si se presiona abrir entonces...
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Txt_Ruta.Text = openFileDialog1.FileName
            _GRILLA_ = dt.LLENADOgrilla(Txt_Ruta.Text)



            If Not _GRILLA_ Is Nothing Then
                If _GRILLA_.Columns.Count > 4 Then
                    Grilla_Excel.DataSource = _GRILLA_
                    BTN_Save.Enabled = True
                    BTN_Validar.Enabled = True
                Else
                    Grilla_Excel.DataSource = _GRILLA_
                    Grilla_Excel.Columns(0).Width = 800
                    MsgBox("Las siguientes  unidades a pagar faltan" & vbNewLine & "Por favor ingresar lo antes posible")
                    BTN_Save.Enabled = False
                    BTN_Validar.Enabled = False
                End If

            Else
                MsgBox("Excel No correspondiente verifique previamente")
                Grilla_Ex.Columns.Clear()
                Txt_Ruta.Text = ""
                BTN_Save.Enabled = False
            End If

        End If
    End Sub
    Private Sub BTN_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click

        Dim dterrores As DataTable = dt2.Ingreso(_GRILLA_)
        Form3.Show()
        Me.Close()

    End Sub

    Private Sub ImportarHorario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BTN_Save.Enabled = False
        BTN_Validar.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub BTN_Validar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Validar.Click
        Try
            Dim validar As New GHAU_CapaNegocio.Excel
            Dim dtvalidar = validar.ValidarChoquesExcel(_GRILLA_)
            If dtvalidar.Rows.Count > 0 Then

                Grilla_Excel.Size = New System.Drawing.Size(612, 388)
                Grilla_error.Visible = True
                Grilla_error.DataSource = dtvalidar
                Grilla_error.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
                Dim dterrores As DataTable = dt2.Ingreso(_GRILLA_)
            End If
        Catch
        End Try
    End Sub


   
End Class
