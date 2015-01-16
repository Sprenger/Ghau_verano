Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports GHAU_CapaNegocio.Excel
Imports GHAU_CapaDatos.BaseDato
Public Class HU21
    Dim dt As New GHAU_CapaNegocio.Excel
    Dim dt2 As New GHAU_CapaNegocio.Eventos

    Dim _GRILLA_ As DataTable

    Sub esconder()
        Cargar_Evento.Enabled = False
        LBL_Error.Hide()
        Grilla_dx.Hide()
    End Sub


    Private Sub BTN_Abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Abrir.Click
        HU_21_Abrir_Archivo()

    End Sub
    Private Sub HU_21_Abrir_Archivo()
        '************** volver a dejar vacio todo ********************
        esconder()
        TableLayoutPanel5.Size = New System.Drawing.Size(907, 427)
        Txt_Ruta.Text = " "
        Grilla_Ex.DataSource = Nothing
        Grilla_dx.DataSource = Nothing
        Cargar_Evento.Enabled = False
        '*************************************************************

        Dim openFileDialog1 As New OpenFileDialog
        Dim fichero = Environment.GetEnvironmentVariable("windir") 'Busca en que disco esta a carpeta de windows
        'Abre Directorio Predeterminado
        openFileDialog1.InitialDirectory = fichero
        'Filtramos solo archivos con extension *.xls
        openFileDialog1.Filter = "Archivos de Microsoft Office Excel (*.xls)|*.xls"
        'Si se presiona abrir entonces...
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Txt_Ruta.Text = openFileDialog1.FileName
            Cargar_Evento.Enabled = True
            _GRILLA_ = dt.LLENADOgrillaEventos(Txt_Ruta.Text)

            If Not _GRILLA_ Is Nothing Then
                Grilla_Ex.DataSource = _GRILLA_
                Me.Grilla_Ex.Columns(9).DefaultCellStyle.Format = "t"
                Me.Grilla_Ex.Columns(8).DefaultCellStyle.Format = "t"
                Cargar_Evento.Enabled = True
            Else
                MsgBox("Excel No correspondiente verifique previamente")
                Cargar_Evento.Enabled = False
            End If
        End If

    End Sub


    Private Sub HU21_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        esconder()
    End Sub

    Private Sub BTN_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Limpiar.Click
        esconder()
        TableLayoutPanel5.Size = New System.Drawing.Size(907, 427)
        Txt_Ruta.Text = " "
        Grilla_Ex.DataSource = Nothing
        Cargar_Evento.Enabled = False
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cargar_Evento.Click
        llamar()

    End Sub
    Public periodo As String
    Sub llamar()
        Dim dt3 As DataTable = dt2.ingreso_evento(_GRILLA_)
        Dim x As New GHAU_CapaDatos.Agregar_evento

        If Not dt3 Is Nothing Then

            TableLayoutPanel5.Size = New System.Drawing.Size(661, 427)
            LBL_Error.Show()
            Grilla_dx.Show()
            Grilla_dx.DataSource = dt3
            Grilla_dx.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Else
            GHAU_CapaPresenta.Form3.cargar((FormatDateTime(Form3.Mes.SelectionStart, DateFormat.LongDate)), True) 'CStr(Me.Mes.SelectionRange.Start))
            Me.Close()
        End If
    End Sub
    Private Sub TableLayoutPanel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel5.Paint

    End Sub
End Class