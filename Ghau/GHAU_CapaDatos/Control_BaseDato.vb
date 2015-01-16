Imports System.Data.SqlClient
Imports System
Imports System.Collections
Public Class Control_BaseDato


    Dim _NombreServidor_, _NombreUsuario_, _Pass_ As String
    'Funcion para rescatar el nombre del servidor, el nombre del usuario y pass  para la coneccion
    Public Function Parametros() As String
        Dim fichero = Environment.GetEnvironmentVariable("windir") 'Busca en que disco esta a carpeta de windows
        fichero = fichero & "/ghau/Coneccion.bat"
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fichero) 'lee texto coneccion.bat
        texto = sr.ReadToEnd()
        sr.Close()
        Dim parametro() As String = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
        _NombreServidor_ = parametro(0)
        _NombreUsuario_ = parametro(1)
        _Pass_ = parametro(2)
        Return texto
    End Function

    Public cnn As New SqlConnection
    'inicia coneccion con la base de dato
    Public Function conectado()
        Parametros() 'rescata parametros desde el archivo .bat
        Try
            cnn = New SqlConnection("Server=" & _NombreServidor_ & ";uid=" & _NombreUsuario_ & ";pwd=" & _Pass_) 'inicia coneccion
            'cnn.Open() 'abre coneccion
            Return True
        Catch ex As Exception
            MsgBox("Conectado " + ex.Message) 'mensaje si la coneccion falla
            Return False
        End Try
    End Function

    Public Function desconectado()
        Try
            If cnn.State = ConnectionState.Open Then
                cnn.Close() 'cierra coneccion
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function coneccion(ByVal texto As String) As Boolean
        Try
            Dim cmd As New SqlCommand

            Dim parametro() As String = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
            Dim cnn As New SqlConnection
            cnn = New SqlConnection("Server=" & parametro(0) & ";uid=" & parametro(1) & ";pwd=" & parametro(2))
            cnn.Open()

            cmd = New SqlCommand("select TABLE_NAME from INFORMATION_SCHEMA.TABLES")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn
            Dim respuesta As Boolean = False
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim a = Replace(dt.Rows(i).Item(0).ToString, " ", "")
                    If Replace(dt.Rows(i).Item(0).ToString, " ", "") = "salas" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Campus" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Bloques" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Periodos" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Modalidades" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Materias" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Jornadas" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Unidades_Academicas" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "tipos_actividades" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Salas_Edificios" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Horarios" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Recursos" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Salas" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "horarios_errores" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Horarios_Historicos" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Edificios" _
                       Or Replace(dt.Rows(i).Item(0).ToString, " ", "") = "Docentes" Then
                        respuesta = True
                    End If
                Next
            Else
                Return Nothing
            End If
           
            If respuesta Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function salas(ByVal texto As String) As Boolean
        Try
            Dim cmd As New SqlCommand
            Dim parametro() As String = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
            Dim cnn As New SqlConnection
            cnn = New SqlConnection("Server=" & parametro(0) & ";uid=" & parametro(1) & ";pwd=" & parametro(2))
            cnn.Open()
            cmd = New SqlCommand("select * from salas   ")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn
            Dim respuesta As Boolean = False
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return True
                End If
            Else
                Return Nothing
            End If
            If respuesta Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Horario(ByVal texto As String) As Boolean
        Try
            Dim cmd As New SqlCommand
            Dim parametro() As String = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
            Dim cnn As New SqlConnection
            cnn = New SqlConnection("Server=" & parametro(0) & ";uid=" & parametro(1) & ";pwd=" & parametro(2))
            cnn.Open()
            cmd = New SqlCommand("select * from HorarioS")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn
            Dim respuesta As Boolean = False
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Return True
                End If
            Else
                Return Nothing
            End If
            If respuesta Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
