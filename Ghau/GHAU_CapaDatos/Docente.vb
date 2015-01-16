Imports System.Data.SqlClient
Imports System
Imports System.Collections
Imports System.Globalization
Public Class Docente
    Sub IngresarDocentes(ByVal rut As String, ByVal nombre As String, ByVal cargo As String)
        Dim insertar As String = "insert into docentes values('" & Replace(rut.ToUpper, " ", "") & "', '" & nombre.ToUpper & "', '" & cargo.ToUpper & "')"
        Try
            cnn.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)

        Catch ex As Exception
            MsgBox("No se pudo ingresar Docente por:" & vbNewLine & ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Function ConsultarDocentes() As DataTable
        Dim consulta = "select * from Docentes"
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        Try
            cnn.Open()
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)
            Return Nothing
        Finally
            cnn.Close()
        End Try


    End Function
    Function ConsultarDocentes(ByVal parametros As String, ByVal Tipoconsulta As String, ByVal columnaRespuesta As String) As DataTable
        Dim consulta = "select " & columnaRespuesta & " from Docentes where " & Tipoconsulta & "='" & parametros & "'"
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        Try
            cnn.Open()
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt

            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)
            Return Nothing
        Finally
            cnn.Close()
        End Try


    End Function

End Class
