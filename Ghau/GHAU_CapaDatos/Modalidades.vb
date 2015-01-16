Imports System.Data.SqlClient
Imports System
Imports System.Collections
Imports System.Globalization
Public Class Modalidades

    Sub IngresarModalidades(ByVal Modalidades As String)

        'preguntar si el datatable es nullo


        Dim insertar As String = "insert into Modalidades values( 'ACTIVO', '" & Replace(Modalidades.ToUpper, " ", "") & "')"
        Try
            cnn.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)

        Catch ex As Exception

        Finally
            cnn.Close()
        End Try
    End Sub
    Function ConsultaModalidades()
        Dim consulta As String = "select * from Modalidades"

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
    Function consultaModalidades(ByVal valor As String, ByVal columnaAConsultar As String, ByVal columnaRespuesta As String) As DataTable
        Dim consulta = "select " & columnaRespuesta & " from Modalidades where " & columnaAConsultar & "='" & valor & "'"
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


            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)
            dt = Nothing
        Finally
            cnn.Close()
        End Try
        Return dt
    End Function


End Class
