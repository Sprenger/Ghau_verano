Imports System.Data.SqlClient
Imports System
Imports System.Collections
Imports System.Globalization

Public Class Horarios

    Function MostrarHorario() As DataTable
        Dim Consulta As String = "select * from Horarios"
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        conectado()
        Try

            cmd = New SqlCommand(Consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            desconectado()
        End Try

    End Function

    Function MostrarHorarioFechas(ByVal FechaInicio As String, ByVal FechaFin As String) As DataTable
        '1:      Dim Consulta As String = "select h.nrc, h.dia, s.Ubicacion, h.fecha_inicio, h.fecha_fin from Horarios h, Salas s where s.sala_codigo=h.sala_codigo and " & _
        '        "s.sala_codigo <>'EXTERNA' and  (h.Fecha_inicio>=@FechaInicio  and  h.Fecha_inicio<= @FechaInicio) or " & _
        '        "(h.Fecha_fin>= @FechaFin  and  h.Fecha_fin<=@FechaFin)"

        'Dim consulta = ("select h.sala_codigo, h.nrc, h.bloque_codigo, h.Nombre_curso, h.Tipo_Carga, d.nombre, h.jornada_codigo, h.cantidad," & _
        '                     "s.ubicacion, h.nrc_ligado,h.curso_materia, h.tipo_actividad from Horarios h, Salas s, Docentes d where h.sala_codigo like " & _
        '                     "'VM%' and h.dia =" & dia & " and @fecha between h.fecha_inicio and h.fecha_fin and s.sala_codigo= h.sala_codigo and d.rut_docente=h.Rut_docente order by h.sala_codigo ")

        Try
            Dim cmd As New SqlCommand

            cnn.Open()

            'conectado()
            cmd = New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.CommandText = "CONSULTAR_HORARIO_FECHAS"
            'cmd = New SqlCommand(insertar, cnn)
            With cmd.Parameters
                .Add("@FechaFin", SqlDbType.Date).Value = CDate(FechaFin)
                .Add("@FechaInicio", SqlDbType.Date).Value = CDate(FechaInicio)
            End With
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



End Class
