

Imports System.Data.SqlClient
Imports System
Imports System.Collections
Imports System.Globalization

Public Class LLenadoGrillaHorario
    Public data As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Public cnn As New SqlConnection
    Dim _NombreServidor_, _NombreUsuario_, _Pass_ As String
    Function Sala() As DataTable
        Dim consulta As String = "select sala,capacidad,recursos_codigo, Descripcion_sala from Salas where sala_codigo like 'VM%'and descripcion_sala <> 'NO DISPONIBLE' order by ubicacion"
        Dim fichero = Environment.GetEnvironmentVariable("windir") 'Busca en que disco esta a carpeta de windows
        fichero = fichero & "/ghau/Coneccion.bat"
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fichero) 'lee texto coneccion.bat
        texto = sr.ReadToEnd()
        sr.Close()
        Dim parametro() As String = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
        _NombreServidor_ = parametro(0)
        _NombreUsuario_ = parametro(1)
        _Pass_ = parametro(2) 'rescata parametros desde el archivo .bat
        Try
            cnn = New SqlConnection("Server=" & _NombreServidor_ & ";uid=" & _NombreUsuario_ & ";pwd=" & _Pass_) 'inicia coneccion
            cnn.Open() 'abre coneccion

        Catch ex As Exception

        End Try

        Try
       
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)
            Return Nothing
        Finally
            Try
                If cnn.State = ConnectionState.Open Then
                    cnn.Close() 'cierra coneccion

                End If
            Catch ex As Exception

            End Try
        End Try
    End Function

    Function horario(ByVal dia As String, ByVal fecha As String)

        'Dim consulta = ("select sala_codigo,nrc, bloque_codigo, Nombre_curso, Tipo_Carga, rut_docente, jornada_codigo, cantidad from Horarios where sala_codigo like 'VM%' and dia='" & dia & "' and @fecha between fecha_inicio and fecha_fin order by sala_codigo")
        Dim consulta = ("select h.sala_codigo, h.nrc, h.bloque_codigo, h.Nombre_curso, h.Tipo_Carga, d.nombre, h.jornada_codigo, h.cantidad, s.ubicacion, h.nrc_ligado,h.curso_materia, h.tipo_actividad from Horarios h, Salas s, Docentes d where h.sala_codigo like 'VM%' and h.dia =" & dia & " and @fecha between h.fecha_inicio and h.fecha_fin and s.sala_codigo= h.sala_codigo and d.rut_docente=h.Rut_docente order by h.sala_codigo ")
        
        Try
            Dim fichero = Environment.GetEnvironmentVariable("windir") 'Busca en que disco esta a carpeta de windows
            fichero = fichero & "/ghau/Coneccion.bat"
            Dim texto As String
            Dim sr As New System.IO.StreamReader(fichero) 'lee texto coneccion.bat
            texto = sr.ReadToEnd()
            sr.Close()
            Dim parametro() As String = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
            cnn = New SqlConnection("Server=" & parametro(0) & ";uid=" & parametro(1) & ";pwd=" & parametro(2)) 'inicia coneccion
            cnn.Open()

            'conectado()
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn
            'cmd = New SqlCommand(insertar, cnn)
            cmd.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecha))

            cmd.ExecuteNonQuery()


            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
        'cnn.Close()

    End Function

    Function consultarDocentes()
        Dim consulta As String = "select * from docentes "
        Dim fichero = Environment.GetEnvironmentVariable("windir") 'Busca en que disco esta a carpeta de windows
        fichero = fichero & "/ghau/Coneccion.bat"
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fichero) 'lee texto coneccion.bat
        texto = sr.ReadToEnd()
        sr.Close()
        Dim parametro() As String = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
        _NombreServidor_ = parametro(0)
        _NombreUsuario_ = parametro(1)
        _Pass_ = parametro(2) 'rescata parametros desde el archivo .bat
        Try
            cnn = New SqlConnection("Server=" & _NombreServidor_ & ";uid=" & _NombreUsuario_ & ";pwd=" & _Pass_) 'inicia coneccion
            cnn.Open() 'abre coneccion

        Catch ex As Exception

        End Try

        Try
            conectado()
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)
            Return Nothing
        Finally
            Try
                If cnn.State = ConnectionState.Open Then
                    cnn.Close() 'cierra coneccion

                End If
            Catch ex As Exception

            End Try
        End Try

    End Function
End Class
