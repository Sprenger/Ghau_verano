Imports System.Data.SqlClient
Imports System
Imports System.Collections

Module Mod_Coneccion

    Dim _NombreServidor_, _NombreUsuario_, _Pass_ As String

    'Funcion para rescatar el nombre del servidor, el nombre del usuario y pass  para la coneccion
    Public Function Parametros()
        Dim fichero = Environment.GetEnvironmentVariable("windir") 'Busca en que disco esta a carpeta de windows
        fichero = fichero & "/ghau/Coneccion.bat"
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fichero) 'lee texto coneccion.bat
        texto = sr.ReadToEnd()
        sr.Close()
        Dim parametro() As String = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
        '_NombreServidor_ = parametro(0)
        '_NombreUsuario_ = parametro(1)
        '_Pass_ = parametro(2)
        Return "Server=" & parametro(0) & ";uid=" & parametro(1) & ";pwd=" & parametro(2)
    End Function

    Public cnn As New SqlConnection
    'inicia coneccion con la base de dato
    'Public Function conectado()
    '    Dim cadena = Parametros() 'rescata parametros desde el archivo .bat
    '    Try
    '        cnn = New SqlConnection(cadena) 'inicia coneccion
    '        cnn.Open() 'abre coneccion
    '        Return True
    '    Catch ex As Exception
    '        MsgBox("Conectado " + ex.Message) 'mensaje si la coneccion falla
    '        Return False
    '    End Try
    'End Function

    'Public Function desconectado()
    '    Try
    '        If cnn.State = ConnectionState.Open Then
    '            cnn.Close() 'cierra coneccion
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try
    'End Function



    '***************************************************************************************************


    Public Function conectado()
        Dim cadena = Parametros()
        Try

            cnn = New SqlConnection(cadena)
            cnn.Open()
            Return True
        Catch ex As Exception
            MsgBox("Conectado " + ex.Message)
            Return False
        End Try
    End Function

    Public Function desconectado()
        Try
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function



End Module