Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports GHAU_CapaNegocio.Excel
Imports GHAU_CapaDatos.BaseDato
Public Class importar_sala
    Dim dt As New GHAU_CapaNegocio.Excel
    Dim dt2 As New GHAU_CapaNegocio.ImportarHorario
    Dim _GRILLA_ As DataTable
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim openFileDialog1 As New OpenFileDialog
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
                Grilla_Ex.DataSource = _GRILLA_
                BTN_Save.Enabled = True
            Else
                MsgBox("Excel No correspondiente verifique previamente")
                'Grilla_Ex.Columns.Clear()
                'Txt_Ruta.Text = ""
                '_GRILLA_.Clear()
                BTN_Save.Enabled = False
            End If
        End If
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        dt2.IngresoSala(_GRILLA_)
        Form3.Show()

    End Sub

    Private Sub importar_sala_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BTN_Save.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class