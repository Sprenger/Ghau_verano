Imports System.Data.SqlClient
Imports System
Imports System.Collections
Imports System.Globalization

Public Class Agregar_evento
    Dim dx
    Dim insertar As String
    Dim borrar As String
    Dim dt As DataTable
    Public Function EliminarEventos(ByVal NRC As String)
        'Dim codigo = Mid(Replace(Unidad_academica.ToUpper, " ", ""), 1, 9)
        Dim Eliminar As String = "delete from horarios where nrc ='" & NRC & "'"
        Try
            conectado()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(Eliminar.ToUpper, cnn)
            da.Fill(ds)
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectado()
        End Try
    End Function
    Dim cmd As New SqlCommand
    Sub guardar_M_Evento(ByVal Fecha_inicio As String, ByVal fecha_fin As String, ByVal dia As String, ByVal nombre_curso As String, _
                               ByVal rut_docente As String, ByVal sala As String, ByVal Bloque As String, _
                               ByVal NRC As String, ByVal fecha_carga As String, ByVal modalidad_codigo As String, ByVal numero_periodo As String)
        sala = sala.Replace("VM-", "")
        sala = "VM-" & sala
        insertar = ""
        insertar = "insert into horarios values(@fechacarga,'" & dia & "',10,'" & NRC & _
     "','',' ','','','" & Replace(sala, " ", "") & "','DV','EVENTO', 'EVENTO','VIN','" & Bloque & "','" & rut_docente & "','" & _
     Replace(modalidad_codigo, " ", "") & "',' ',@fechainicio, @fechafin,'" & _
     nombre_curso & "','M','',' '," & numero_periodo & ", 'EVENTO')"

        'Dim asd = ''Fecha_carga', 'Dia', 'Cantidad', 'NRC', 'seccion', 'Lista_cruzada', 'NRC_Ligado', 'ID_Listas_Cruzadas', 'sala_codigo', 'Jornada', 'curso_materia', 'numero_periodo ', 'tipo_actividad', 'campus_codigo ', 'bloque_codigo ', 'rut_docente ', 'modalidad_codigo ', 'Unid_aca_cod', 'Fecha_inicio ', 'fecha_fin', 'nombre_curso ', 'tipo_carga', 'Programa', 'nivel_curso ''
        Try
            conectado()
            cmd = New SqlCommand(insertar, cnn)
            cmd.Parameters.AddWithValue("@fechacarga", Convert.ToDateTime(fecha_carga))
            cmd.Parameters.AddWithValue("@fechainicio", Convert.ToDateTime(Fecha_inicio))
            cmd.Parameters.AddWithValue("@fechafin", Convert.ToDateTime(fecha_fin))
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            '  MsgBox("Error Base de datos")

        End Try
        'acaIsrael
        cnn.Close()
    End Sub

    Sub eliminarEvento(ByVal periodo As String)
        Dim borrar As String = "delete from Horarios where tipo_actividad='EVENTO' and Tipo_Carga = 'D' and Periodo <= '" & periodo & "'"
        Try
            Dim ds As New DataSet
            borrar = borrar.ToUpper
            Dim da As New SqlDataAdapter(borrar, cnn)
            da.Fill(ds)
        Catch
        End Try
        cnn.Close()
    End Sub

  

    Sub guardar_A_Evento(ByVal Fecha_inicio As String, ByVal fecha_fin As String, ByVal dia As String, ByVal nombre_curso As String, _
                              ByVal rut_docente As String, ByVal sala As String, ByVal Bloque As String, _
                              ByVal NRC As String, ByVal fecha_carga As String, ByVal modalidad_codigo As String, ByVal numero_periodo As String)


        insertar = ""
        insertar = "insert into horarios values(@fechacarga,'" & dia & "',10,'" & NRC & _
     "','',' ','','','VM-" & Replace(sala, " ", "") & "','DV','EVENTO', 'EVENTO','VIN','" & Bloque & "','" & rut_docente & "','" & _
     Replace(modalidad_codigo, " ", "") & "',' ',@fechainicio, @fechafin,'" & _
     nombre_curso & "','D','',' '," & numero_periodo & ", 'EVENTO')"

        Try
            conectado()
            cmd = New SqlCommand(insertar, cnn)
            cmd.Parameters.AddWithValue("@fechacarga", Convert.ToDateTime(fecha_carga))
            cmd.Parameters.AddWithValue("@fechainicio", Convert.ToDateTime(Fecha_inicio))
            cmd.Parameters.AddWithValue("@fechafin", Convert.ToDateTime(fecha_fin))
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error Base de datos")
        End Try
        cnn.Close()
    End Sub

    Function recorrer(ByVal dia As Integer, ByVal fecha As String) As DataTable
        Dim consulta As String = "select l.nrc, l.dia,l.tipo_actividad,l.fecha_ini,l.fecha_fin,l.bloque_codigo,l.sala,s.Ubicacion" & _
                                  " from Liberar_sala l,Salas s" & _
                                  " where l.sala = s.sala_codigo" & _
                                  " and l.dia='" & dia & "'" & _
                                  " and @fecha_inicio between l.fecha_ini and l.fecha_fin"


        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        conectado()
        Try
            'cnn.Open()
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.Parameters.AddWithValue("@fecha_inicio", Convert.ToDateTime(fecha))
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
            'MsgBox("Error al mostrar " + ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
        Return dt
    End Function

    Sub guardar_evento(ByVal dato As DataTable)
        dt = dato


        Dim cnn As New SqlConnection
        cnn = New SqlConnection(Mod_Coneccion.Parametros) 'inicia coneccion
        cnn.Open()
        For i = 0 To dato.Rows.Count - 1
            insertar = ("INSERT INTO errores VALUES ('" & dt.Rows(i).Item(0).ToString & "', '" & dt.Rows(i).Item(1).ToString & "')")

            Try
                Dim ds As New DataSet
                insertar = insertar.ToUpper
                Dim da As New SqlDataAdapter(insertar, cnn)
                da.Fill(ds)
            Catch

            End Try
            cnn.Close()
        Next

    End Sub

    Public Function BuscarExiste(ByVal bloque As String, ByVal bloque2 As String, ByVal sala As String, ByVal dias As String) As DataTable
        sala = Replace(sala, "VM-", "")
        Dim consulta As String = "select * from horarios where (bloque_codigo like '" & bloque & "' or bloque_codigo like '" & bloque2 & "') and sala_codigo = 'VM-" & sala & "' and " & dias
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        conectado()
        Try
            'cnn.Open()
            cmd = New SqlCommand(consulta.ToUpper)
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
            'MsgBox("Error al mostrar " + ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
        '  Return dt
    End Function


    Sub eliminarEvento_nrc(ByVal NRC As String)
        'Dim codigo = Mid(Replace(Unidad_academica.ToUpper, " ", ""), 1, 9)
        Dim Consulta As String = "delete from horarios where tipo_actividad='EVENTO' AND NRC ='" & NRC & "'"
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        conectado()
        Try
            'cnn.Open()
            cmd = New SqlCommand(Consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

            Else

            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)

        Finally
            desconectado()
        End Try
        '  Return dt
    End Sub



    Public Function BuscarEventos(ByVal parametro As String, ByVal columnaconsulta As String, ByVal columnaretorno As String) As DataTable
        'Dim codigo = Mid(Replace(Unidad_academica.ToUpper, " ", ""), 1, 9)
        Dim Consulta As String = "select " & columnaretorno & " from horarios where " & columnaconsulta & "='" & parametro & "'"
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        conectado()
        Try
            'cnn.Open()
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
            'MsgBox("Error al mostrar " + ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
        '  Return dt
    End Function

End Class
