Imports System.Data.SqlClient
Imports System
Imports System.Collections
Imports System.Globalization
Public Class MantenedorBD
    Dim cnn As New SqlConnection
    Sub New(ByVal _nombreservidor_ As String, ByVal _nombreusuario_ As String, ByVal _pass_ As String)
        cnn = New SqlConnection("Server=" & _nombreservidor_ & ";uid=" & _nombreusuario_ & ";pwd=" & _pass_) 'inicia coneccion
    End Sub

    Sub IngresarDocentes(ByVal rut As String, ByVal nombre As String, ByVal cargo As String)
        Dim insertar As String = "insert into docentes values('" & Replace(rut.ToUpper, " ", "") & "', '" & nombre.ToUpper & "', '" & cargo.ToUpper & "')"
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





    Function consultarJornada_programa(ByVal programas As String) As DataTable
        Dim consulta As String = "select Jornada_codigo from horarios where Codigo_Programa = '" & programas & "'"
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




    'Function consultarProgramas() As DataTable 'ByVal codigo As String, ByVal descripcion As String) As DataTable
    '    Dim consulta As String = "select * from PROGRAMAS")
    '    Try
    '        cnn.Open()
    '        'Dim ds As New DataSet
    '        'insertar = insertar.ToUpper
    '        'Dim da As New SqlDataAdapter(insertar, cnn)
    '        Dim cmd As New SqlCommand
    '        cmd = New SqlCommand(consulta, cnn)
    '        cmd.ExecuteNonQuery()

    '        Return True
    '        ' da.Fill(ds)
    '    Catch ex As Exception
    '        Return False
    '    Finally
    '        cnn.Close()
    '    End Try

    'End Function



    Function ingresaruacademicas(ByVal Codigo As String, ByVal Descripcion As String) As Boolean
        Dim insertar As String = "insert into Unidades_Academicas values('" & Codigo.ToUpper & "','" & Descripcion.ToUpper & "')"


        '       insertar = "insert into horarios values(@fechacarga,'" & dias(0) & "',10,'" & (dt.rows.count + 1) & _
        '"'," & dt.rows.count & ",' ',' ',' ','" & Replace(Sala, vbNewLine, "") & "','" & _
        '       Jornada & "','EVENTO', 'EVENTO','VIÑADELMAR','" & modulo.ToString & "','" & dtrutdocente.Rows(0).Item(0).ToString & "','PRESENCIAL','Evento',@fechainicio, @fechafin,'" & NombreActividad & "','M',' ',' '," & dtperiodo.Rows(0).Item(0).ToString & ")"

        'Dim asd = ''Fecha_carga', 'Dia', 'Cantidad', 'NRC', 'seccion', 'Lista_cruzada', 'NRC_Ligado', 'ID_Listas_Cruzadas', 'sala_codigo', 'Jornada', 'curso_materia', 'numero_periodo ', 'tipo_actividad', 'campus_codigo ', 'bloque_codigo ', 'rut_docente ', 'modalidad_codigo ', 'Unid_aca_cod', 'Fecha_inicio ', 'fecha_fin', 'nombre_curso ', 'tipo_carga', 'Programa', 'nivel_curso ''
        Try
            cnn.Open()
            'Dim ds As New DataSet
            'insertar = insertar.ToUpper
            'Dim da As New SqlDataAdapter(insertar, cnn)
            Dim cmd As New SqlCommand
            cmd = New SqlCommand(insertar, cnn)
            cmd.ExecuteNonQuery()

            Return True
            ' da.Fill(ds)
        Catch ex As Exception
            Return False
        Finally
            cnn.Close()
        End Try

    End Function

    Function IngresarPrograma(ByVal Codigo As String, ByVal Descripcion As String) As Boolean
        Dim insertar As String = "insert into PROGRAMAS values('" & Codigo.ToUpper & "','" & Descripcion.ToUpper & "')"


        '       insertar = "insert into horarios values(@fechacarga,'" & dias(0) & "',10,'" & (dt.rows.count + 1) & _
        '"'," & dt.rows.count & ",' ',' ',' ','" & Replace(Sala, vbNewLine, "") & "','" & _
        '       Jornada & "','EVENTO', 'EVENTO','VIÑADELMAR','" & modulo.ToString & "','" & dtrutdocente.Rows(0).Item(0).ToString & "','PRESENCIAL','Evento',@fechainicio, @fechafin,'" & NombreActividad & "','M',' ',' '," & dtperiodo.Rows(0).Item(0).ToString & ")"

        'Dim asd = ''Fecha_carga', 'Dia', 'Cantidad', 'NRC', 'seccion', 'Lista_cruzada', 'NRC_Ligado', 'ID_Listas_Cruzadas', 'sala_codigo', 'Jornada', 'curso_materia', 'numero_periodo ', 'tipo_actividad', 'campus_codigo ', 'bloque_codigo ', 'rut_docente ', 'modalidad_codigo ', 'Unid_aca_cod', 'Fecha_inicio ', 'fecha_fin', 'nombre_curso ', 'tipo_carga', 'Programa', 'nivel_curso ''
        Try
            cnn.Open()
            'Dim ds As New DataSet
            'insertar = insertar.ToUpper
            'Dim da As New SqlDataAdapter(insertar, cnn)
            Dim cmd As New SqlCommand
            cmd = New SqlCommand(insertar, cnn)
            cmd.ExecuteNonQuery()

            Return True
            ' da.Fill(ds)
        Catch ex As Exception
            Return False
        Finally
            cnn.Close()
        End Try

    End Function



    Function modificaruacademicas(ByVal Codigonuevo As String, ByVal Descripcionnuevo As String, ByVal Codigoviejo As String, ByVal DescripcionViejo As String) As Boolean
        Dim insertar As String = "update Unidades_Academicas set codigo='" & Codigonuevo & "', descripcion='" & Descripcionnuevo & "' WHERE CODIGO='" & Codigoviejo & "' and  descripcion ='" & DescripcionViejo & "'"

        '       insertar = "insert into horarios values(@fechacarga,'" & dias(0) & "',10,'" & (dt.rows.count + 1) & _
        '"'," & dt.rows.count & ",' ',' ',' ','" & Replace(Sala, vbNewLine, "") & "','" & _
        '       Jornada & "','EVENTO', 'EVENTO','VIÑADELMAR','" & modulo.ToString & "','" & dtrutdocente.Rows(0).Item(0).ToString & "','PRESENCIAL','Evento',@fechainicio, @fechafin,'" & NombreActividad & "','M',' ',' '," & dtperiodo.Rows(0).Item(0).ToString & ")"

        'Dim asd = ''Fecha_carga', 'Dia', 'Cantidad', 'NRC', 'seccion', 'Lista_cruzada', 'NRC_Ligado', 'ID_Listas_Cruzadas', 'sala_codigo', 'Jornada', 'curso_materia', 'numero_periodo ', 'tipo_actividad', 'campus_codigo ', 'bloque_codigo ', 'rut_docente ', 'modalidad_codigo ', 'Unid_aca_cod', 'Fecha_inicio ', 'fecha_fin', 'nombre_curso ', 'tipo_carga', 'Programa', 'nivel_curso ''
        Try
            cnn.Open()
            'Dim ds As New DataSet
            'insertar = insertar.ToUpper
            'Dim da As New SqlDataAdapter(insertar, cnn)
            Dim cmd As New SqlCommand
            cmd = New SqlCommand(insertar.ToUpper, cnn)
            cmd.ExecuteNonQuery()

            Return True
            ' da.Fill(ds)
        Catch ex As Exception
            Return False
        Finally
            cnn.Close()
        End Try

    End Function

    Function modificarPrograma(ByVal Codigonuevo As String, ByVal Descripcionnuevo As String, ByVal Codigoviejo As String, ByVal DescripcionViejo As String) As Boolean
        Dim insertar As String = "update programaS set codigo='" & Codigonuevo & "', descripcion='" & Descripcionnuevo & "' WHERE CODIGO='" & Codigoviejo & "' and  descripcion ='" & DescripcionViejo & "'"

        '       insertar = "insert into horarios values(@fechacarga,'" & dias(0) & "',10,'" & (dt.rows.count + 1) & _
        '"'," & dt.rows.count & ",' ',' ',' ','" & Replace(Sala, vbNewLine, "") & "','" & _
        '       Jornada & "','EVENTO', 'EVENTO','VIÑADELMAR','" & modulo.ToString & "','" & dtrutdocente.Rows(0).Item(0).ToString & "','PRESENCIAL','Evento',@fechainicio, @fechafin,'" & NombreActividad & "','M',' ',' '," & dtperiodo.Rows(0).Item(0).ToString & ")"

        'Dim asd = ''Fecha_carga', 'Dia', 'Cantidad', 'NRC', 'seccion', 'Lista_cruzada', 'NRC_Ligado', 'ID_Listas_Cruzadas', 'sala_codigo', 'Jornada', 'curso_materia', 'numero_periodo ', 'tipo_actividad', 'campus_codigo ', 'bloque_codigo ', 'rut_docente ', 'modalidad_codigo ', 'Unid_aca_cod', 'Fecha_inicio ', 'fecha_fin', 'nombre_curso ', 'tipo_carga', 'Programa', 'nivel_curso ''
        Try
            cnn.Open()
            'Dim ds As New DataSet
            'insertar = insertar.ToUpper
            'Dim da As New SqlDataAdapter(insertar, cnn)
            Dim cmd As New SqlCommand
            cmd = New SqlCommand(insertar, cnn)
            cmd.ExecuteNonQuery()

            Return True
            ' da.Fill(ds)
        Catch ex As Exception
            Return False
        Finally
            cnn.Close()
        End Try

    End Function



    Sub ModificarEvento(ByVal inicio As String, ByVal fin As String, ByVal dia As String, ByVal Nombre_evento As String, ByVal nrc As String, ByVal Sala_codigo As String)
        Dim insertar As String = "update horarios set nombre_curso='" & Nombre_evento.ToUpper & "', dia=" & dia & ", fecha_inicio = @fechainicio, fecha_fin = @fechafin, sala_codigo= 'VM-" & Sala_codigo & "' where   nrc=" & nrc



        '       insertar = "insert into horarios values(@fechacarga,'" & dias(0) & "',10,'" & (dt.rows.count + 1) & _
        '"'," & dt.rows.count & ",' ',' ',' ','" & Replace(Sala, vbNewLine, "") & "','" & _
        '       Jornada & "','EVENTO', 'EVENTO','VIÑADELMAR','" & modulo.ToString & "','" & dtrutdocente.Rows(0).Item(0).ToString & "','PRESENCIAL','Evento',@fechainicio, @fechafin,'" & NombreActividad & "','M',' ',' '," & dtperiodo.Rows(0).Item(0).ToString & ")"

        'Dim asd = ''Fecha_carga', 'Dia', 'Cantidad', 'NRC', 'seccion', 'Lista_cruzada', 'NRC_Ligado', 'ID_Listas_Cruzadas', 'sala_codigo', 'Jornada', 'curso_materia', 'numero_periodo ', 'tipo_actividad', 'campus_codigo ', 'bloque_codigo ', 'rut_docente ', 'modalidad_codigo ', 'Unid_aca_cod', 'Fecha_inicio ', 'fecha_fin', 'nombre_curso ', 'tipo_carga', 'Programa', 'nivel_curso ''
        Try
            cnn.Open()
            'Dim ds As New DataSet
            'insertar = insertar.ToUpper
            'Dim da As New SqlDataAdapter(insertar, cnn)
            Dim cmd As New SqlCommand
            cmd = New SqlCommand(Replace(insertar, vbNewLine, ""), cnn)

            cmd.Parameters.AddWithValue("@fechainicio", Convert.ToDateTime(inicio))
            cmd.Parameters.AddWithValue("@fechafin", Convert.ToDateTime(fin))
            cmd.ExecuteNonQuery()


            ' da.Fill(ds)
        Catch ex As Exception

        Finally
            cnn.Close()
        End Try

    End Sub


    Sub eliminarEvento(ByVal nrc As String)
        Dim insertar As String = "delete from horarios where nrc='" & nrc & "'"


        '       insertar = "insert into horarios values(@fechacarga,'" & dias(0) & "',10,'" & (dt.rows.count + 1) & _
        '"'," & dt.rows.count & ",' ',' ',' ','" & Replace(Sala, vbNewLine, "") & "','" & _
        '       Jornada & "','EVENTO', 'EVENTO','VIÑADELMAR','" & modulo.ToString & "','" & dtrutdocente.Rows(0).Item(0).ToString & "','PRESENCIAL','Evento',@fechainicio, @fechafin,'" & NombreActividad & "','M',' ',' '," & dtperiodo.Rows(0).Item(0).ToString & ")"

        'Dim asd = ''Fecha_carga', 'Dia', 'Cantidad', 'NRC', 'seccion', 'Lista_cruzada', 'NRC_Ligado', 'ID_Listas_Cruzadas', 'sala_codigo', 'Jornada', 'curso_materia', 'numero_periodo ', 'tipo_actividad', 'campus_codigo ', 'bloque_codigo ', 'rut_docente ', 'modalidad_codigo ', 'Unid_aca_cod', 'Fecha_inicio ', 'fecha_fin', 'nombre_curso ', 'tipo_carga', 'Programa', 'nivel_curso ''
        Try
            cnn.Open()
            'Dim ds As New DataSet
            'insertar = insertar.ToUpper
            'Dim da As New SqlDataAdapter(insertar, cnn)
            Dim cmd As New SqlCommand
            cmd = New SqlCommand(Replace(insertar, vbNewLine, ""), cnn)

            cmd.ExecuteNonQuery()


            ' da.Fill(ds)
        Catch ex As Exception

        Finally
            cnn.Close()
        End Try

    End Sub




    Sub IngresarBloques(ByVal Bloque As String, ByVal Descripcion As String)


        Dim insertar As String = "insert into Bloques values ('" & Replace(Bloque.ToUpper, " ", "") & "','" & Descripcion & "')"
        Try
            cnn.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)

        Catch

        Finally
            cnn.Close()
        End Try

    End Sub
    Sub IngresarCampus(ByVal codigo As String, ByVal descripcion As String)
        Dim insertar As String = "insert into campus values('" & Replace(codigo.ToUpper, " ", "") & "', '" & Replace(descripcion.ToUpper, " ", "") & "')"
        Try
            cnn.Open()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)
        Catch ex As Exception
        Finally
            cnn.Close()
        End Try
    End Sub

    Sub IngresarERROR_EXCEL(ByVal Facultad As String, ByVal Campus As String, ByVal Unidad_Académica As String, ByVal Periodo As String, ByVal Materia As String, ByVal Curso As String, ByVal Sección As String, ByVal Jornada As String, ByVal NRC As String, ByVal Listas_Cruzadas As String, ByVal NRC_Ligados As String, ByVal Id_Listas_Cruzadas As String, ByVal Calificable As String, ByVal Minor As String, ByVal Rut_Profesor As String, ByVal Nombre_Profesor As String, ByVal Nombre_Asignatura As String, ByVal Horas_a_Pagar As String, ByVal Tipo_Actividad As String, ByVal Modalidad As String, ByVal Horario As String, ByVal Vacantes As String, ByVal Inscritos As String, ByVal Edificio As String, ByVal Sala As String, ByVal Capacidad_Sala As String, ByVal Restric_Cod_Programa As String, ByVal Restric_Desc_Programa As String, ByVal Restricciones_Campus As String, ByVal Nivel_del_Curso As String, ByVal Unidad_que_Paga As String, ByVal Semestre_que_Paga As String, ByVal Nivel_del_Programa As String, ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal TipoError As String)

        Dim insertar As String = "insert into Error_Excel values ('" & Facultad & "','" & Campus & "','" & Unidad_Académica & "','" & Periodo & "','" & Materia & "','" & Curso & "','" & Sección & "','" & Jornada & "','" & NRC & "','" & Listas_Cruzadas & "','" & NRC_Ligados & "','" & Id_Listas_Cruzadas & "','" & Calificable & "','" & Minor & "','" & Rut_Profesor & "','" & Nombre_Profesor & "','" & Nombre_Asignatura & "','" & Horas_a_Pagar & "','" & Tipo_Actividad & "','" & Modalidad & "','" & Horario & "','" & Vacantes & "','" & Inscritos & "','" & Edificio & "','" & Sala & "','" & Capacidad_Sala & "','" & Restric_Cod_Programa & "','" & Restric_Desc_Programa & "','" & Restricciones_Campus & "','" & Nivel_del_Curso & "','" & Unidad_que_Paga & "','" & Semestre_que_Paga & "','" & Nivel_del_Programa & "','" & Fecha_Inicio & "','" & Fecha_Fin & "','" & TipoError & "')"
        Try
            cnn.Open()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        cnn.Close()
    End Sub
    Sub IngresarJornadas(ByVal codigo As String, ByVal descripcion As String)
        Dim insertar As String = "insert into Jornadas values('" & Replace(codigo.ToUpper, " ", "") & "', '" & Replace(descripcion.ToUpper, " ", "") & "')"
        Try
            cnn.Open()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        cnn.Close()
    End Sub

    Sub IngresarMaterias(ByVal curso As String, ByVal descripcion As String)

        Dim insertar As String = "insert into Materias values('" & Replace(curso.ToUpper, " ", "") & "', '" & Replace(descripcion.ToUpper, " ", "") & "')"
        Try
            cnn.Open()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        cnn.Close()
    End Sub
    Sub IngresarModalidad(ByVal Modalidad As String)
        Dim insertar As String = "insert into modalidades values ('" & Replace(Modalidad.ToUpper, " ", "") & "',' ')"
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
    Sub Ingresarecursos(ByVal recursocodigo As String, ByVal descripcion As String) '

        Dim insertar = ("INSERT INTO recursos VALUES ( '" & recursocodigo & "' ,'" & descripcion & "')")

        Try
            cnn.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)

        Catch ex As Exception

        End Try
        cnn.Close()

    End Sub
    Sub IngresarEdificio(ByVal edificiocodigo As String, ByVal descripcion As String) 'sirve para ingresar datos a campus


        'inserta los campus a la base de dato

        Dim insertar = ("INSERT INTO Edificios VALUES ('" & Replace(edificiocodigo, " ", "") & "','" & descripcion & "')")

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
    Sub IngresarSalas_Edificios(ByVal salacodigo As String, ByVal edificiocodigo As String) 'sirve para ingresar datos a campus


        'inserta los campus a la base de dato

        Dim insertar = ("INSERT INTO Salas_Edificios VALUES ('" & Replace(salacodigo, " ", "") & "','" & edificiocodigo & "')")

        Try
            cnn.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)

        Catch ex As Exception


        End Try
        cnn.Close()
    End Sub
    Sub IngresarSalas(ByVal sala_codigo As String, ByVal sala As String, ByVal Cod_inventario As String, ByVal Descripcion_sala As String, ByVal capacidad As Integer, ByVal area As String, ByVal ancho As String, ByVal largo As String, ByVal Cod_escuela As String, ByVal tipo_salon As String, ByVal recursos_codigo As String, ByVal ubicacion As Integer) 'ingresa salas

        'inserta los campus a la base de dato
        cnn.Open()
        Dim dtrecursos As DataTable = ConsultarRecursos(recursos_codigo)
        recursos_codigo = dtrecursos.Rows(0).Item(0).ToString.Trim
        Dim insertar As String = ("INSERT INTO SALAS VALUES ('" & sala_codigo & "','" & sala & "','" & Cod_inventario & "','" & Descripcion_sala & "'," & capacidad & ",'" & area & "','" & ancho & "','" & largo & "','" & Cod_escuela & "','" & tipo_salon & "','" & recursos_codigo & "', " & ubicacion & ")")

        Try
            cnn.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)

        Catch ex As Exception


        End Try
        cnn.Close()
    End Sub
    Sub IngresarTipoActividad(ByVal actividad As String)
        Dim insertar As String = "insert into tipos_actividades values('" & Replace(actividad.ToUpper, " ", "") & "','" & Replace(actividad.ToUpper, " ", "") & "')"
        Try
            cnn.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)

        Catch ex As Exception

        Finally
            cnn.Close()
        End Try
    End Sub
    Sub IngresarUnidadAcademica(ByVal Unidad_academica As String)
        Dim insertar As String = "insert into Unidades_Academicas values ('" & Replace(Unidad_academica.ToUpper, " ", "") & "','" & Unidad_academica.ToUpper & "')"
        Try
            cnn.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)

        Catch ex As Exception

        Finally
            cnn.Close()
        End Try
    End Sub

    Sub IngresarHorario(ByVal Fecha_carga As String, ByVal Dia As String, ByVal Cantidad As String, ByVal NRC As String, ByVal seccion As String, ByVal Lista_cruzada As String, ByVal NRC_Ligado As String, ByVal ID_Listas_Cruzadas As String, ByVal sala_codigo As String, ByVal Jornada As String, ByVal curso_materia As String, ByVal numero_periodo As String, ByVal tipo_actividad As String, ByVal campus_codigo As String, ByVal bloque_codigo As String, ByVal rut_docente As String, ByVal modalidad_codigo As String, ByVal Unid_aca_cod As String, ByVal Fecha_inicio As String, ByVal fecha_fin As String, ByVal nombre_curso As String, ByVal tipo_carga As String, ByVal Programa As String, ByVal nivel_curso As String, ByVal Docente As String)
        IngresarBloques(bloque_codigo, bloque_codigo)
        Dim cmd As New SqlCommand
        Dim insertar As String = ""
        'Try
        'Dim FECHA = DateTime.ParseExact(Mid(Fecha_carga, 1, 10), "yyyyMMddhhmm", Nothing)
        Dim dt_temp_tpact As DataTable = ConsultarTipoActividad(tipo_actividad) '("select * from tipos_actividades where descripcion = '" & Replace(tipo_actividad, " ", "") & "'")
        ' Dim asda = "select * from tipos_actividades where descripcion = '" & Replace(tipo_actividad, " ", "") & "'"
        If dt_temp_tpact.Rows.Count = 0 Then
            tipo_actividad = Replace(tipo_actividad, " ", "")
            IngresarTipoActividad(tipo_actividad)

        Else
            tipo_actividad = dt_temp_tpact.Rows(0).Item(0).ToString

        End If

        Dim dt_temp_campcod As DataTable = ConsultarCampus(campus_codigo) 'mostrar("select campus_codigo from campus where descripcion='" & Replace(campus_codigo, " ", "") & "'")

        If dt_temp_campcod.Rows.Count = 0 Then
            IngresarCampus(campus_codigo, campus_codigo)
            campus_codigo = Replace(campus_codigo, " ", "")
        Else
            campus_codigo = dt_temp_campcod.Rows(0).Item(0)
        End If



        Dim dt_temp_jornada As DataTable = ConsultarJornada(Jornada) 'mostrar("select * from Jornadas where descipcion ='" & Jornada & "'")
        If dt_temp_jornada.Rows.Count = 0 Then
            IngresarJornadas(Jornada.Trim, Jornada.Trim)
            Jornada = Replace(Jornada, " ", "")
        Else
            Jornada = dt_temp_jornada.Rows(0).Item(0).ToString

        End If
        Dim dt_temp_Unid_acade As DataTable = ConsultarUnidadesAcademicas(Unid_aca_cod.ToUpper) 'mostrar("select * from  Unidades_Academicas where descripcion='" & Unid_aca_cod.ToUpper & "'")
        'Dim aaa = "select * from  Unidades_Academicas where descripcion='" & Unid_aca_cod.ToUpper & "'"
        If dt_temp_Unid_acade.Rows.Count = 0 Then

            IngresarUnidadAcademica(Unid_aca_cod.ToUpper)
            Unid_aca_cod = Replace(Unid_aca_cod, " ", "")
        Else
            Unid_aca_cod = dt_temp_Unid_acade.Rows(0).Item(0).ToString
        End If


        Dim dt_temp_modalidad As DataTable = ConsultarModalidades(modalidad_codigo) 'mostrar("select * from Modalidades where descripcion='" & modalidad_codigo & "'")
        ' Dim ccc = "select * from Modalidades where descripcion='" & modalidad_codigo & "'"
        'modalidad_codigo = dt_temp_modalidad.Rows(0).Item(0).ToString
        If dt_temp_modalidad.Rows.Count = 0 Then

            IngresarModalidad(modalidad_codigo.ToUpper)
            modalidad_codigo = Replace(modalidad_codigo, " ", "")
        Else
            modalidad_codigo = dt_temp_modalidad.Rows(0).Item(0).ToString
        End If

        Dim dt_temp_curso_materia As DataTable = ConsultarCursoMateria(curso_materia) 'mostrar("select * from Materias where curso_materia = '" & curso_materia & "'")
        If dt_temp_curso_materia.Rows.Count = 0 Then
            IngresarMaterias(curso_materia.ToUpper, curso_materia.ToUpper)
            curso_materia = Replace(modalidad_codigo, " ", "")
        Else
            curso_materia = dt_temp_curso_materia.Rows(0).Item(0).ToString
        End If


        Dim dt_temp_Docentes As DataTable = ConsultarDocentes(rut_docente) 'mostrar("select * from  docentes  where rut_docente='" & rut_docente & "'")
        'Dim aaa = "select * from  Unidades_Academicas where descripcion='" & Unid_aca_cod.ToUpper & "'"
        If dt_temp_Docentes.Rows.Count = 0 Then

            IngresarDocentes(Replace(rut_docente, " ", ""), Docente.ToUpper, "Docente")
            rut_docente = Replace(rut_docente, " ", "")
        Else
            rut_docente = Replace(rut_docente, " ", "")
        End If

        Dim Fecha_inicios As Date = Fecha_inicio
        Dim temp_fecha_I = Fecha_inicios.ToString("dd-MMM-yyy", _
                  CultureInfo.InvariantCulture)
        Dim fecha_fins As Date = fecha_fin
        Dim temp_fecha_F = fecha_fins.ToString("dd-MMM-yyy", _
                  CultureInfo.InvariantCulture)
        Dim F_carga As Date = Fecha_carga
        Dim temp_carga = F_carga.ToString("dd-MMM-yyy hh:mm", _
                  CultureInfo.InvariantCulture)

        'Dim insertar As String = "insert into horarios values('" & temp_carga & "','" & Dia & "'," & Cantidad & ",'" & NRC & _
        '"'," & seccion & ",'" & Lista_cruzada & "','" & NRC_Ligado & "','" & ID_Listas_Cruzadas & "','" & Replace(sala_codigo, " ", "") & "','" & _
        'Jornada & "','" & curso_materia & "', '" & Replace(tipo_actividad, " ", "") & "','" & campus_codigo & _
        '"','" & bloque_codigo & "','" & Replace(rut_docente, " ", "") & "','" & Replace(modalidad_codigo, " ", "") & _
        '"','" & Unid_aca_cod & "','" & temp_fecha_I & "','" & temp_fecha_F & "','" & nombre_curso & "','" & tipo_carga & "','" & _
        'Replace(Programa, " ", "") & "','" & nivel_curso & "'," & numero_periodo & ")"

        insertar = "insert into horarios values(@fechacarga,'" & Dia & "'," & Cantidad & ",'" & NRC & _
     "'," & seccion & ",'" & Lista_cruzada & "','" & NRC_Ligado & "','" & ID_Listas_Cruzadas & "','" & Replace(sala_codigo, " ", "") & "','" & _
     Jornada & "','" & curso_materia & "', '" & Replace(tipo_actividad, " ", "") & "','" & campus_codigo & _
     "','" & bloque_codigo & "','" & Replace(rut_docente, " ", "") & "','" & Replace(modalidad_codigo, " ", "") & _
     "','" & Unid_aca_cod & "',@fechainicio, @fechafin,'" & nombre_curso & "','" & tipo_carga & "','" & _
     Replace(Programa, " ", "") & "','" & nivel_curso & "'," & numero_periodo & ")"

        'Dim asd = ''Fecha_carga', 'Dia', 'Cantidad', 'NRC', 'seccion', 'Lista_cruzada', 'NRC_Ligado', 'ID_Listas_Cruzadas', 'sala_codigo', 'Jornada', 'curso_materia', 'numero_periodo ', 'tipo_actividad', 'campus_codigo ', 'bloque_codigo ', 'rut_docente ', 'modalidad_codigo ', 'Unid_aca_cod', 'Fecha_inicio ', 'fecha_fin', 'nombre_curso ', 'tipo_carga', 'Programa', 'nivel_curso ''
        Try
            cnn.Open()
            'Dim ds As New DataSet
            'insertar = insertar.ToUpper
            'Dim da As New SqlDataAdapter(insertar, cnn)

            cmd = New SqlCommand(insertar, cnn)
            cmd.Parameters.AddWithValue("@fechacarga", Convert.ToDateTime(Fecha_carga))
            cmd.Parameters.AddWithValue("@fechainicio", Convert.ToDateTime(Fecha_inicio))
            cmd.Parameters.AddWithValue("@fechafin", Convert.ToDateTime(fecha_fin))
            cmd.ExecuteNonQuery()


            ' da.Fill(ds)
        Catch ex As Exception

        End Try


        cnn.Close()
    End Sub


    Function ConsultarRecursos(ByVal recursos_codigo As String) As DataTable
        Dim consulta = ("select * from recursos where recurso_codigo = '" & recursos_codigo.ToUpper & "'")
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



    Function GraficosHorario(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal programa As String, ByVal jornada As String) As DataTable
        Dim consulta = "select DISTINCT nrc , bloque_codigo, dia, jornada_codigo from horarios where Codigo_Programa='" & programa & "' and Fecha_inicio between @fechaInicio and @fechaFin"
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        Try
            cnn.Open()

            'conectado()
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn
            'cmd = New SqlCommand(insertar, cnn)
            cmd.Parameters.AddWithValue("@fechaInicio", Convert.ToDateTime(FechaInicio))
            cmd.Parameters.AddWithValue("@fechaFin", Convert.ToDateTime(FechaFin))


            cmd.ExecuteNonQuery()


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
            cnn.Close()
        End Try


    End Function




    Function GraficosHorario(ByVal periodo As String, ByVal programa As String, ByVal jornada As String) As DataTable
        Dim consulta = "select DISTINCT nrc , bloque_codigo, dia, jornada_codigo  from horarios where Codigo_Programa='" & programa & "' and Periodo=" & periodo & " and jornada_codigo like '%" & jornada & "%'  order by dia"
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


    Function ConsultarRecursos() As DataTable
        Dim consulta = "select * from recursos"
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

    Function ConsultarTipoActividad() As DataTable
        Dim consulta = "select * from tipos_actividades"
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
    Function consultarcantidadSoloSala() As DataTable
        Dim consulta = "SELECT count(se.sala_codigo)  FROM Salas S, Salas_Edificios SE WHERE S.sala_codigo=SE.sala_codigo AND s.Descripcion_sala<> 'NO DISPONIBLE' and s.sala like 'sal%'"
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


    Function consultarcantidadSala() As DataTable
        Dim consulta = "select COUNT(*) from Salas where sala_codigo like 'VM-SAL%' AND Descripcion_sala <>'NO DISPONIBLE'"
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

    Function ConsultarTipoActividad(ByVal tipo_actividad As String) As DataTable
        Dim consulta = "select * from tipos_actividades where descripcion = '" & Replace(tipo_actividad, " ", "") & "'"
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

    Function ConsultarCampus(ByVal Campus_codigo As String) As DataTable
        Dim consulta = "select campus_codigo from campus where descripcion='" & Replace(Campus_codigo, " ", "") & "'"
        Dim cmd As New SqlCommand
        Dim dt As DataTable
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
    Function ConsultarAllCampus() As DataTable
        ' mostrar("select campus_codigo from campus where descripcion='" & Replace(campus_codigo, " ", "") & "'")
        Dim consulta = "select * from campus"
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

    Function ConsultarJornada(ByVal Jornada As String) As DataTable
        Dim consulta As String = "select * from Jornadas where descipcion ='" & Jornada & "'"
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
    Function ConsultarJornada() As DataTable
        ' mostrar("select campus_codigo from campus where descripcion='" & Replace(campus_codigo, " ", "") & "'")
        Dim consulta = "select * from Jornadas"
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

    Function ConsultarUnidadesAcademicas(ByVal Unid_aca_cod As String) As DataTable
        Dim consulta As String = "select * from  Unidades_Academicas where descripcion='" & Unid_aca_cod.ToUpper & "'"
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
    Function ConsultarUnidadesAcademicas() As DataTable
        ' mostrar("select campus_codigo from campus where descripcion='" & Replace(campus_codigo, " ", "") & "'")
        Dim consulta = "select * from Unidades_Academicas"
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

    Function ConsultarModalidades() As DataTable
        Dim consulta = "select * from Modalidades"
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
    Function ConsultarModalidades(ByVal modalidad_codigo As String) As DataTable
        Dim consulta = "select * from Modalidades where descripcion='" & modalidad_codigo & "'"
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



    Function ConsultarCursoMateria() As DataTable
        Dim consulta = "select * from curso_materia"
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
    Function ConsultarCursoMateria(ByVal curso_materia As String) As DataTable
        Dim consulta = "select * from Materias where curso_materia = '" & curso_materia & "'"
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

    Function ConsultarProgramas_Descripcion() As DataTable
        Dim consulta = "select DESCRIPCION from programas"
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



    Function Consultarperiodos() As DataTable
        Dim consulta = "select periodo from periodos "
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




    Function consultarjornadascodigo() As DataTable
        Dim consulta = "select jornada_codigo from Jornadas"

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

    Function consultarDescPeriodo() As DataTable
        Dim consulta = "select periodo from Periodos"
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





    Function ConsultarcodigoPrograma() As DataTable
        Dim consulta = "select CODIGO from PROGRAMAS order by codigo"
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
    Function ConsultarProgramas_unab() As DataTable
        Dim consulta = "select * from programas order by codigo"
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


    Function ConsultarDocentes(ByVal rut_docente As String) As DataTable
        Dim consulta = "select * from  docentes  where rut_docente='" & rut_docente & "'"
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




    Public Function ConsultaPeriodo() As DataTable
        Dim consulta = ("select periodo from periodos where estado='ACTIVO'")
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
    Public Function consultarCampus() As DataTable
        Dim consulta As String = "select campus_codigo from Campus"
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
    Public Function consultarSalas(ByVal sede As String) As DataTable
        Dim consulta = ("select * from salas where sala_codigo like  '" & sede & "%' and Descripcion_sala<> 'NO DISPONIBLE'")
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
    Public Function consultaRescuelas() As DataTable
        Dim consulta = ("select unidad_academica_codigo from Unidades_Academicas")
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

    Public Function consultarErrore() As DataTable
        Dim consulta = ("SELECT * FROM error_excel")
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

    Public Function consultarHorarioFecha(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal programa As String) As DataTable
        Dim consulta = ("")
        Dim cmd As New SqlCommand
        Try


            cnn.Open()

            'conectado()
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn
            'cmd = New SqlCommand(insertar, cnn)
            cmd.Parameters.AddWithValue("@fechaInicio", Convert.ToDateTime(FechaInicio))
            cmd.Parameters.AddWithValue("@fechaFin", Convert.ToDateTime(FechaFin))


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
            cnn.Close()
        End Try

    End Function

    Public Function consultarHorario(ByVal nrc As String) As DataTable
        Dim consulta = ("select  h.fecha_carga, h.dia, h.cantidad, h.nrc , h.seccion , h.lista_cruzada, h.nrc_ligado, h.id_listas_cruzadas, " & _
                        "h.sala_codigo, h.jornada_codigo, h.curso_materia, h.tipo_actividad, h.campus_codigo, h.bloque_codigo, h.Rut_docente," & _
        "h.modalidad_codigo, h.unidad_academica_codigo, h.Fecha_inicio, h.Fecha_fin, h.Nombre_curso, h.Tipo_Carga, h.Programa, h.Nivel_Curso, h.Periodo, h.Codigo_Programa, d.nombre " & _
       "from Horarios h, Docentes D where nrc='" & nrc & "' and d.rut_docente=h.Rut_docente")

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

    Public Function consultarProgramas() As DataTable
        Dim consulta = ("select distinct(programa) from Horarios")
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


    Function Sala() As DataTable
        Dim consulta As String = "select sala,capacidad,recursos_codigo, Descripcion_sala from Salas where sala_codigo like 'VM%'and descripcion_sala <> 'NO DISPONIBLE' order by ubicacion"
        Dim cmd As New SqlCommand

        Try
            cnn.Open()
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
            cnn.Close()
        End Try
    End Function



    Function horario(ByVal dia As String, ByVal fecha As String)

        'Dim consulta = ("select sala_codigo,nrc, bloque_codigo, Nombre_curso, Tipo_Carga, rut_docente, jornada_codigo, cantidad from Horarios where sala_codigo like 'VM%' and dia='" & dia & "' and @fecha between fecha_inicio and fecha_fin order by sala_codigo")
        Dim consulta = ("select h.sala_codigo, h.nrc, h.bloque_codigo, h.Nombre_curso, h.Tipo_Carga, d.nombre, h.jornada_codigo, h.cantidad, s.ubicacion, h.nrc_ligado,h.curso_materia, h.tipo_actividad from Horarios h, Salas s, Docentes d where h.sala_codigo like 'VM%' and h.dia =" & dia & " and @fecha between h.fecha_inicio and h.fecha_fin and s.sala_codigo= h.sala_codigo and d.rut_docente=h.Rut_docente order by h.sala_codigo ")
        Dim cmd As New SqlCommand
        Try


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
            cnn.Close()
        End Try
        'cnn.Close()

    End Function
    Function consultarHorario(ByVal fechaInicio As String, ByVal fechafin As String, ByVal jornada As String, ByVal evento As Boolean, ByVal dia As String, ByVal tipo_actividad_codigo As String, ByVal countsala As Integer) As DataTable
        Dim consulta As String
        If jornada.ToUpper = "TODOS" Then

            If evento Then
                consulta = "select sum(b.rango)*100/" & countsala & " from Horarios h, Bloques b where dia=" & dia & "  and (@fecha between h.fecha_inicio and h.fecha_fin) and b.bloque_codigo = h.bloque_codigo and b.rango<20 and h.sala_codigo like 'VM-SAL%' "

            Else
                consulta = "select sum(b.rango)*100/" & countsala & "  from Horarios h, Bloques b where dia=" & dia & "  and (@fecha between h.fecha_inicio and h.fecha_fin ) AND tipo_actividad <> '" & tipo_actividad_codigo.ToUpper & "' and b.bloque_codigo = h.bloque_codigo and b.rango<20 and h.sala_codigo like 'VM-SAL%' "

            End If
        Else

            If evento Then
                consulta = "select sum(b.rango)*100/" & countsala & "  from Horarios h, Bloques b where dia=" & dia & " and   jornada_codigo='" & jornada & "' and (@fecha between h.fecha_inicio and h.fecha_fin) and b.bloque_codigo = h.bloque_codigo and b.rango<20 and h.sala_codigo like 'VM-SAL%' "

            Else
                consulta = "select sum(b.rango)*100/" & countsala & "  from Horarios h, Bloques b where dia=" & dia & " and   jornada_codigo='" & jornada & "' and (@fecha between h.fecha_inicio and h.fecha_fin) AND tipo_actividad <> '" & tipo_actividad_codigo.ToUpper & "' and b.bloque_codigo = h.bloque_codigo and b.rango<20 and h.sala_codigo like 'VM-SAL%' "

            End If
        End If
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        Try
            cnn.Open()
            cmd = New SqlCommand(consulta.ToUpper)
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            cmd.Parameters.AddWithValue("@fecha ", Convert.ToDateTime(fechaInicio))
            cmd.Parameters.AddWithValue("@fechafin", Convert.ToDateTime(fechafin))
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




    Function consultarbloques() As DataTable
        Dim consulta As String = "select * from Bloques"
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



    Function consultarHorario() As DataTable
        Dim consulta As String = "select * from Horarios"
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


    Function consultareventos(ByVal nrc As String) As DataTable
        Dim consulta As String = "select * from horarios where nrc=" & nrc


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
    Function ConsultarEventos(ByVal DIA As String, ByVal PROFESOR As String, ByVal NRC As String, ByVal NOMBRE As String) As DataTable
        Dim consulta As String = "select H.bloque_codigo, H.dia, H.cantidad, H.nrc, s.sala, H.Fecha_inicio, H.Fecha_fin, H.Nombre_curso , D.nombre from horarios H, Docentes D , salas s " & _
        "WHERE H.nrc = '" & NRC & "'  AND D.rut_docente = H.Rut_docente and s.sala_codigo = h.sala_codigo"


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




    Private Sub ConsultarPeriodo(ByVal periodo As String, ByVal stringconeccion As String)
        Dim dt As New DataTable

        Dim cmd As New SqlCommand
        'Dim cnn As New SqlConnection

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
                    Dim insertar As String = "INSERT INTO Horarios_Historicos SELECT * FROM horarios where periodo =" & periodo & "delete Horarios where Periodo=" & periodo
                    Dim ds As New DataSet
                    insertar = insertar.ToUpper
                    Dim dataadapterIngresoPeriodo As New SqlDataAdapter(insertar, cnn)
                    dataadapterIngresoPeriodo.Fill(ds)

                End If

            End If
        Catch ex As Exception
            'MsgBox("Error al mostrar " + ex.Message)
        Finally
            cnn.Close()
        End Try



    End Sub
End Class
