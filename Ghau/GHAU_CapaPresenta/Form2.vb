Public Class Form2

    Dim dt As New DataTable



    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dt.Columns.Add("rut", Type.GetType("System.String"))
        dt.Columns.Add("nombre", Type.GetType("System.String"))
        dt.Columns.Add("cargo", Type.GetType("System.String"))
        GRILLA_xd.DataSource = dt
    End Sub

    Private Sub BTN_Insertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Insertar.Click
        Dim dx As New GHAU_CapaNegocio.Validado_Rut(TXT_Rut.Text.ToString)
        If TXT_Nombre.Text <> "" Then

            If TXT_Cargo.Text <> "" Then


                If dx.ValidarRut(TXT_Rut.Text.ToString) Then
                    dt.Rows.Add()
                    dt.Rows(dt.Rows.Count - 1).Item(0) = TXT_Rut.Text.ToString
                    dt.Rows(dt.Rows.Count - 1).Item(1) = TXT_Nombre.Text.ToString
                    dt.Rows(dt.Rows.Count - 1).Item(2) = TXT_Cargo.Text.ToString
                    GRILLA_xd.DataSource = dt
                    TXT_Rut.Text = ""
                    TXT_Nombre.Text = ""
                    TXT_Cargo.Text = ""
                Else
                    MsgBox("Rut Incorrecto")

                End If
            Else
                MsgBox("Ingrese un Cargo")
            End If
        Else
            MsgBox("Ingrese un Nombre")
        End If
        TXT_Rut.Focus()





    End Sub

    Private Sub TXT_Rut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_Rut.KeyPress



        If Char.IsNumber(e.KeyChar) Or e.KeyChar = "k"c Or e.KeyChar = ""c Then
            'If e.KeyChar = "-"c And TXT_Rut.Text.Length - 1 = 9 Then

        Else
            e.Handled = True
        End If


        'Else
        'e.Handled = True
        ' End If




    End Sub

    Private Sub TXT_Rut_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_Rut.KeyUp
        If TXT_Rut.Text.Length - 1 = 7 Then
            TXT_Rut.Text = TXT_Rut.Text & "-"
            TXT_Rut.SelectionStart = TXT_Rut.TextLength
        End If
    End Sub


    Public _nombreservidor_, _nombreusuario_, _pass_ As String
    Public Function Parametros() As String
        Dim fichero = Environment.GetEnvironmentVariable("windir") 'Busca en que disco esta a carpeta de windows
        fichero = fichero & "/ghau/Coneccion.bat"
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fichero) 'lee texto coneccion.bat
        texto = sr.ReadToEnd()
        sr.Close()
        Dim parametro() As String = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
        _nombreservidor_ = parametro(0)
        _nombreusuario_ = parametro(1)
        _pass_ = parametro(2)
        Dim datosconeccion As String = _nombreservidor_ & "/" & _nombreusuario_ & "/" & _pass_
        Return datosconeccion
    End Function
    Private Sub BTN_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim stringconeccion As String = Parametros()
        Dim dt2 As New GHAU_CapaNegocio.ImportarHorario
        dt2.ingreso_docentes(dt)
        dt.Clear()
        MsgBox("Guardado Exitoso", MsgBoxStyle.Information, )

    End Sub

   
  
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim dt As New GHAU_CapaDatos.BaseDato

        GRILLA_xd.DataSource = dt.mostrar("select * from docentes")
    End Sub
End Class