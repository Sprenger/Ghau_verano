Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports GHAU_CapaNegocio.Excel
Imports GHAU_CapaDatos.BaseDato


Public Class ImportarHorario
    Dim dt As New GHAU_CapaNegocio.Excel
    Dim dt2 As New GHAU_CapaNegocio.ImportarHorario
    Dim _GRILLA_ As DataTable



    Private Sub BTNAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAbrir.Click, Button1.Click
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
                    Grilla_Ex.DataSource = _GRILLA_
                    BTN_Save.Enabled = True
                Else
                    Grilla_Ex.DataSource = _GRILLA_
                    Grilla_Ex.Columns(0).Width = 800
                    MsgBox("Las siguientes  unidades a pagar faltan" & vbNewLine & "Por favor ingresar lo antes posible")
                    BTN_Save.Enabled = False
                End If
                
            Else
                MsgBox("Excel No correspondiente verifique previamente")
                Grilla_Excel.Columns.Clear()
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
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub


    'Sub opt(ByVal dato As DataTable)
    '    Dim ingresar As String = ""

    '    Dim dtDuplicados = dato
    '    'elimina los campus repetidos
    '    Dim MyView As DataView = New DataView(dtDuplicados)
    '    Dim dtSinDuplicados As DataTable
    '    dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(30).ColumnName.ToString)
    '    'End If
    '    Dim pasados = ""
    '    Dim contador As String = 0
    '    For i = 0 To dtSinDuplicados.Rows.Count - 1
    '        'Dim a = Mid(Grilla_Ex.Rows(i).Cells(26).Value.ToString, 1, 9)
    '        '            Dim Periodo_codigo = i

    '        Dim programas_descripcion = Split(dtSinDuplicados.Rows(i).Item(0).ToString, "/")
    '        'For j = 0 To Periodo_codigo.Length - 1
    '        If InStr(pasados, Replace(programas_descripcion(0).ToUpper, " ", "")) = 0 Then
    '            pasados = pasados & Replace(programas_descripcion(0).ToUpper, " ", "") & "/"
    '            ingresar = ingresar & "insert into PROGRAMAS values('" & contador & "','" & programas_descripcion(0).ToUpper & "')" & vbNewLine
    '            contador = contador + 1
    '        End If
    '        'If Periodo_codigo(0) = "" Then
    '        'ingresar = ingresar & "insert into insert into PROGRAMAS values('UNAB00000',''"
    '        'Else

    '        'Next
    '    Next
    'End Sub

   
End Class
