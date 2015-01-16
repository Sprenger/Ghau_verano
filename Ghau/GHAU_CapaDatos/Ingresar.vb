Imports System.Data.SqlClient
Imports System
Imports System.Collections

Public Class Ingresar
    Public cantidad As Integer
    Sub IngresarEvento(ByVal fechainicio As String, ByVal fechafin As String, ByVal dia As String, ByVal NombreActividad As String, ByVal Responsable As String, ByVal sala As String, ByVal stringconeccion As String, ByVal Jornada As String, ByVal modulo As String)
        Dim insertar As String = ""
        sala = Replace(sala, vbCrLf, "")
        sala = "VM-" & Replace(sala, " ", "")
        'sala = "VM-SAL102"
        Dim dias = Split(Replace(dia.ToUpper, " ", ""), "+")
        Dim dtrutdocente As DataTable = ConsultarRutDocente(Responsable, stringconeccion)
        Dim dtperiodo As DataTable = ConsultarPeriodos(stringconeccion)


        If dias.Length > 0 Then
            Dim bloque As New GHAU_CapaDatos.BaseDato
            bloque.IngresarBloques(modulo)

            '  Dim dt_temp_tpact As DataTable = mostrar("select * from tipos_actividades where descripcion = '" & Replace(tipo_actividad, " ", "") & "'")
            Dim coneccion = Split(stringconeccion, "++")

            Dim _nombreservidor_ = coneccion(0).ToString
            Dim _nombreusuario_ = coneccion(1).ToString
            Dim _pass_ = coneccion(2).ToString
            Dim cnn As New SqlConnection
            cnn = New SqlConnection("Server=" & _nombreservidor_ & ";uid=" & _nombreusuario_ & ";pwd=" & _pass_) 'inicia coneccion
            cnn.Open()
            Dim dtEventos = ConsultarEvento(stringconeccion)


            insertar = "insert into horarios values(@fechacarga,'" & dias(0) & "',10,'EV-" & (dtEventos.rows.count + 1) & _
     "',300,' ',' ',' ','" & Replace(sala, vbNewLine, "") & "','" & _
            Jornada & "','EVENTO', 'EVENTO','VIÑADELMAR','" & modulo.ToString & "','" & dtrutdocente.Rows(0).Item(0).ToString & "','PRESENCIAL',' ',@fechainicio, @fechafin,'" & NombreActividad & "','M',' ',' '," & dtperiodo.Rows(0).Item(0).ToString & ", 'UNAB00000')"

            'Dim asd = ''Fecha_carga', 'Dia', 'Cantidad', 'NRC', 'seccion', 'Lista_cruzada', 'NRC_Ligado', 'ID_Listas_Cruzadas', 'sala_codigo', 'Jornada', 'curso_materia', 'numero_periodo ', 'tipo_actividad', 'campus_codigo ', 'bloque_codigo ', 'rut_docente ', 'modalidad_codigo ', 'Unid_aca_cod', 'Fecha_inicio ', 'fecha_fin', 'nombre_curso ', 'tipo_carga', 'Programa', 'nivel_curso ''
            Try
                conectado()
                'Dim ds As New DataSet
                'insertar = insertar.ToUpper
                'Dim da As New SqlDataAdapter(insertar, cnn)
                Dim cmd As New SqlCommand
                cmd = New SqlCommand(Replace(insertar.ToUpper, vbNewLine, ""), cnn)
                'Dim cc = fechainicio.ToString
                cmd.Parameters.AddWithValue("@fechacarga", Convert.ToDateTime(fechainicio.ToString))
                cmd.Parameters.AddWithValue("@fechainicio", Convert.ToDateTime(fechainicio))
                cmd.Parameters.AddWithValue("@fechafin", Convert.ToDateTime(fechafin))
                cmd.ExecuteNonQuery()


                ' da.Fill(ds)
            Catch ex As Exception

            Finally
                cnn.Close()
            End Try





        End If

    End Sub
    Function eventoscount(ByVal stringconeccion As String) As Integer
        Dim dt = ConsultarEvento(stringconeccion)
        Return (dt.rows.count)
    End Function
    Sub IngresarPeriodo(ByVal periodo As String, ByVal stringconeccion As String)
        Dim coneccion = Split(stringconeccion, "++")
        Dim _nombreservidor_ = coneccion(0).ToString
        Dim _nombreusuario_ = coneccion(1).ToString
        Dim _pass_ = coneccion(2).ToString
        Dim cnn As New SqlConnection
        cnn = New SqlConnection("Server=" & _nombreservidor_ & ";uid=" & _nombreusuario_ & ";pwd=" & _pass_) 'inicia coneccion
        cnn.Open()
        ConsultarPeriodo(periodo, stringconeccion)

        'preguntar si el datatable es nullo


        Dim insertar As String = "insert into Periodos values( 'ACTIVO', '" & Replace(periodo.ToUpper, " ", "") & "')"
        Try
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
        Catch
        End Try
        cnn.Close()

    End Sub
    Private Function ConsultarPeriodos(ByVal stringconeccion As String) As DataTable
        Dim dt As New DataTable
        Dim coneccion = Split(stringconeccion, "++")
        Dim _nombreservidor_ = coneccion(0).ToString
        Dim _nombreusuario_ = coneccion(1).ToString
        Dim _pass_ = coneccion(2).ToString
        Dim cmd As New SqlCommand
        'Dim cnn As New SqlConnection
        cnn = New SqlConnection("Server=" & _nombreservidor_ & ";uid=" & _nombreusuario_ & ";pwd=" & _pass_) 'inicia coneccion
        'cnn.Open()
        Dim consulta = "select Periodo from Periodos where estado = 'ACTIVO' order by periodo desc"
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

        End Try
        cnn.Close()

    End Function
    Private Function ConsultarRutDocente(ByVal docente As String, ByVal stringconeccion As String) As DataTable
        Dim dt As New DataTable
        Dim coneccion = Split(stringconeccion, "++")
        Dim _nombreservidor_ = coneccion(0).ToString
        Dim _nombreusuario_ = coneccion(1).ToString
        Dim _pass_ = coneccion(2).ToString
        Dim cmd As New SqlCommand
        'Dim cnn As New SqlConnection
        cnn = New SqlConnection("Server=" & _nombreservidor_ & ";uid=" & _nombreusuario_ & ";pwd=" & _pass_) 'inicia coneccion
        'cnn.Open()
        Dim consulta = "select rut_docente from docentes where nombre='" & docente & "'"
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

        End Try
        cnn.Close()
    End Function
    Private Sub ConsultarPeriodo(ByVal periodo As String, ByVal stringconeccion As String)
        Dim dt As New DataTable
        Dim coneccion = Split(stringconeccion, "++")
        Dim _nombreservidor_ = coneccion(0).ToString
        Dim _nombreusuario_ = coneccion(1).ToString
        Dim _pass_ = coneccion(2).ToString
        Dim cmd As New SqlCommand
        'Dim cnn As New SqlConnection
        cnn = New SqlConnection("Server=" & _nombreservidor_ & ";uid=" & _nombreusuario_ & ";pwd=" & _pass_) 'inicia coneccion
        'cnn.Open()
        Dim consulta = "select * from periodos where periodo=" & periodo
        Try
            cnn.Open()
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim insertar As String = "INSERT INTO Horarios_Historicos SELECT * FROM horarios where periodo =" & periodo & " and Tipo_Carga='D'  delete Horarios where Periodo=" & periodo & " and  Tipo_Carga='D'"
                    Dim ds As New DataSet
                    insertar = insertar.ToUpper
                    Dim dataadapterIngresoPeriodo As New SqlDataAdapter(insertar, cnn)
                    dataadapterIngresoPeriodo.Fill(ds)

                End If

            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)

        End Try

        cnn.Close()

    End Sub



    Private Function ConsultarEvento(ByVal stringconeccion As String)
        Dim dt As New DataTable
        Dim coneccion = Split(stringconeccion, "++")
        Dim _nombreservidor_ = coneccion(0).ToString
        Dim _nombreusuario_ = coneccion(1).ToString
        Dim _pass_ = coneccion(2).ToString
        Dim cmd As New SqlCommand
        'Dim cnn As New SqlConnection
        cnn = New SqlConnection("Server=" & _nombreservidor_ & ";uid=" & _nombreusuario_ & ";pwd=" & _pass_) 'inicia coneccion
        'cnn.Open()
        Dim consulta = "select * from tipos_actividades where descripcion = 'EVENTO'"
        Try
            cnn.Open()
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then

                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    Dim insertar As String = "INSERT INTO Materias values ('EVENTO','EVENTO')"
                    Dim ds As New DataSet
                    Dim dataadapterIngresoPeriodo As New SqlDataAdapter(insertar.ToUpper, cnn)
                    dataadapterIngresoPeriodo.Fill(ds)

                    insertar = "INSERT INTO Unidades_Academicas values ('EVENTO','EVENTO')"
                    Dim dsacademicas As New DataSet
                    Dim dataadapterUacademicas As New SqlDataAdapter(insertar.ToUpper, cnn)
                    dataadapterUacademicas.Fill(dsacademicas)

                    insertar = "INSERT INTO tipos_actividades values ('EVENTO','EVENTO')"
                    Dim dsacactividad As New DataSet
                    Dim dataadapteractividad As New SqlDataAdapter(insertar.ToUpper, cnn)
                    dataadapteractividad.Fill(dsacactividad)
                    GoTo 2
                Else
2:
                    consulta = "select h.nrc from horarios h, tipos_actividades t where t.descripcion like '%evento%' and h.tipo_actividad=t.tipo_actividad"


                    cmd = New SqlCommand(consulta.ToUpper)
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = cnn
                    Dim dt2 As New DataTable

                    If cmd.ExecuteNonQuery Then
                        Dim da2 As New SqlDataAdapter(cmd)
                        da2.Fill(dt2)

                    End If
                    Return dt2
                End If
            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)

        End Try
        cnn.Close()


    End Function



End Class
