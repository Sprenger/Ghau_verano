Imports System.Data.SqlClient
Imports System
Imports System.Collections
Imports System.Globalization

Public Class BaseDato
    Public data As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Public coneccion As String
    Public Function docente(ByVal rut As String)
        Dim dt As DataTable = mostrar("select nombre from Docentes where rut_docente='" & rut & "'")
        Return dt
    End Function
    Public Function Consultar_Horarios() As DataTable
        Dim dt As DataTable

        Return dt
    End Function
    Public Function mostrar(ByVal consulta As String) As DataTable
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
            desconectado()
        End Try
    End Function
    Public Function EstadoSalas() As Boolean
        Dim dt As DataTable = mostrar("select * from salas")
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function EstadoHorario() As Boolean
        Dim dt As DataTable = mostrar("select * from salas")
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function insertBD(ByVal insertar As String)
        Try
            conectado()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)

        Catch ex As Exception

        End Try
        cnn.Close()
    End Function
    Public Function IngresarDocentes(ByVal rut As String, ByVal nombre As String, ByVal cargo As String)
        Dim insertar As String = "insert into docentes values('" & Replace(rut.ToUpper, " ", "") & "', '" & nombre.ToUpper & "', '" & cargo.ToUpper & "')"
        Try
            conectado()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function Ingresarecursos(ByVal recursocodigo As String, ByVal descripcion As String) 'sirve para ingresar datos a campus


        'inserta los campus a la base de dato

        Dim insertar = ("INSERT INTO recursos VALUES ( '" & recursocodigo & "' ,'" & descripcion & "')")

        Try
            conectado()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectado()
        End Try


    End Function

    Public Function IngresarEdificio(ByVal edificiocodigo As String, ByVal descripcion As String) 'sirve para ingresar datos a campus


        'inserta los campus a la base de dato

        Dim insertar = ("INSERT INTO Edificios VALUES ('" & Replace(edificiocodigo, " ", "") & "','" & descripcion & "')")

        Try
            conectado()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectado()
        End Try


    End Function
    Public Function IngresarSalas_Edificios(ByVal salacodigo As String, ByVal edificiocodigo As String) 'sirve para ingresar datos a campus


        'inserta los campus a la base de dato

        Dim insertar = ("INSERT INTO Salas_Edificios VALUES ('" & Replace(salacodigo, " ", "") & "','" & edificiocodigo & "')")

        Try
            conectado()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectado()
        End Try


    End Function
    Public Function IngresarSalas(ByVal sala_codigo As String, ByVal sala As String, ByVal Cod_inventario As String, ByVal Descripcion_sala As String, ByVal capacidad As Integer, ByVal area As String, ByVal ancho As String, ByVal largo As String, ByVal Cod_escuela As String, ByVal tipo_salon As String, ByVal recursos_codigo As String, ByVal ubicacion As Integer) 'ingresa salas

        'inserta los campus a la base de dato

        Dim dtrecursos As DataTable = mostrar("select * from recursos where recurso_codigo = '" & recursos_codigo.ToUpper & "'")
        recursos_codigo = dtrecursos.Rows(0).Item(0).ToString.Trim
        Dim insertar As String = ("INSERT INTO SALAS VALUES ('" & sala_codigo & "','" & sala & "','" & Cod_inventario & "','" & Descripcion_sala & "'," & capacidad & ",'" & area & "','" & ancho & "','" & largo & "','" & Cod_escuela & "','" & tipo_salon & "','" & recursos_codigo & "', " & ubicacion & ")")

        Try
            conectado()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar.ToUpper, cnn)
            da.Fill(ds)
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectado()
        End Try


    End Function


    Public Function IngresarCampus(ByVal codigo As String, ByVal descripcion As String)
        Dim insertar As String = "insert into campus values('" & Replace(codigo.ToUpper, " ", "") & "', '" & Replace(descripcion.ToUpper, " ", "") & "')"
        Try
            conectado()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        cnn.Close()
    End Function
    Public Function IngresarJornadas(ByVal codigo As String, ByVal descripcion As String)
        Dim insertar As String = "insert into Jornadas values('" & Replace(codigo.ToUpper, " ", "") & "', '" & Replace(descripcion.ToUpper, " ", "") & "')"
        Try
            conectado()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        cnn.Close()
    End Function
    Public Function IngresarHorarios_errores(ByVal Fecha_carga As String, ByVal Dia As String, ByVal Cantidad As String, ByVal NRC As String, ByVal seccion As String, ByVal Lista_cruzada As String, ByVal NRC_Ligado As String, ByVal ID_Listas_Cruzadas As String, ByVal sala_codigo As String, ByVal Jornada As String, ByVal curso_materia As String, ByVal numero_periodo As String, ByVal tipo_actividad As String, ByVal campus_codigo As String, ByVal bloque_codigo As String, ByVal rut_docente As String, ByVal modalidad_codigo As String, ByVal Unid_aca_cod As String, ByVal Fecha_inicio As String, ByVal fecha_fin As String, ByVal nombre_curso As String, ByVal tipo_carga As String, ByVal Programa As String, ByVal nivel_curso As String, ByVal err As String)
        Dim insertar = "insert into horarios_errores values('" & Fecha_carga & "','" & Dia & "','" & Cantidad & "','" & NRC & _
        "'," & seccion & ",'" & Lista_cruzada & "','" & NRC_Ligado & "','" & ID_Listas_Cruzadas & "','" & Replace(sala_codigo, " ", "") & "','" & _
        Jornada & "','" & curso_materia & "', '" & Replace(tipo_actividad, " ", "") & "','" & campus_codigo & _
        "','" & bloque_codigo & "','" & Replace(rut_docente, " ", "") & "','" & Replace(modalidad_codigo, " ", "") & _
        "','" & Unid_aca_cod & "','" & Fecha_inicio & "','" & fecha_fin & "','" & nombre_curso & "','" & tipo_carga & "','" & _
        Replace(Programa, " ", "") & "','" & nivel_curso & "','" & numero_periodo & "', '" & err & "')"

        Try
            conectado()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar, cnn)


            da.Fill(ds)
        Catch ex2 As Exception
            Dim c = 1 + 2
        End Try
    End Function
    Public Function IngresarERROR_EXCEL(ByVal Facultad As String, ByVal Campus As String, ByVal Unidad_Académica As String, ByVal Periodo As String, ByVal Materia As String, ByVal Curso As String, ByVal Sección As String, ByVal Jornada As String, ByVal NRC As String, ByVal Listas_Cruzadas As String, ByVal NRC_Ligados As String, ByVal Id_Listas_Cruzadas As String, ByVal Calificable As String, ByVal Minor As String, ByVal Rut_Profesor As String, ByVal Nombre_Profesor As String, ByVal Nombre_Asignatura As String, ByVal Horas_a_Pagar As String, ByVal Tipo_Actividad As String, ByVal Modalidad As String, ByVal Horario As String, ByVal Vacantes As String, ByVal Inscritos As String, ByVal Edificio As String, ByVal Sala As String, ByVal Capacidad_Sala As String, ByVal Restric_Cod_Programa As String, ByVal Restric_Desc_Programa As String, ByVal Restricciones_Campus As String, ByVal Nivel_del_Curso As String, ByVal Unidad_que_Paga As String, ByVal Semestre_que_Paga As String, ByVal Nivel_del_Programa As String, ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal TipoError As String)

        Dim insertar As String = "insert into Error_Excel values ('" & Facultad & "','" & Campus & "','" & Unidad_Académica & "','" & Periodo & "','" & Materia & "','" & Curso & "','" & Sección & "','" & Jornada & "','" & NRC & "','" & Listas_Cruzadas & "','" & NRC_Ligados & "','" & Id_Listas_Cruzadas & "','" & Calificable & "','" & Minor & "','" & Rut_Profesor & "','" & Nombre_Profesor & "','" & Nombre_Asignatura & "','" & Horas_a_Pagar & "','" & Tipo_Actividad & "','" & Modalidad & "','" & Horario & "','" & Vacantes & "','" & Inscritos & "','" & Edificio & "','" & Sala & "','" & Capacidad_Sala & "','" & Restric_Cod_Programa & "','" & Restric_Desc_Programa & "','" & Restricciones_Campus & "','" & Nivel_del_Curso & "','" & Unidad_que_Paga & "','" & Semestre_que_Paga & "','" & Nivel_del_Programa & "','" & Fecha_Inicio & "','" & Fecha_Fin & "','" & TipoError & "')"
        Try
            conectado()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        cnn.Close()

    End Function
    Public Function IngresarHorario(ByVal Fecha_carga As String, ByVal Dia As String, ByVal Cantidad As String, ByVal NRC As String, ByVal seccion As String, ByVal Lista_cruzada As String, ByVal NRC_Ligado As String, ByVal ID_Listas_Cruzadas As String, ByVal sala_codigo As String, ByVal Jornada As String, ByVal curso_materia As String, ByVal numero_periodo As String, ByVal tipo_actividad As String, ByVal campus_codigo As String, ByVal bloque_codigo As String, ByVal rut_docente As String, ByVal modalidad_codigo As String, ByVal Unid_aca_cod As String, ByVal Fecha_inicio As String, ByVal fecha_fin As String, ByVal nombre_curso As String, ByVal tipo_carga As String, ByVal Programa As String, ByVal nivel_curso As String, ByVal Docente As String, ByVal U_Q_Paga As String)
        IngresarBloques(bloque_codigo)
        If InStr(sala_codigo.ToString.ToUpper, "EXTERN") > 0 Then
            sala_codigo = "EXTERNA"
        End If

        Dim insertar As String = ""
        'Try
        Dim uqpaga = Split(U_Q_Paga, "/")
        'U_Q_Paga = uqpaga(0)
        Dim dtU_q_paga As DataTable = mostrar("select * from PROGRAMAS where DESCRIPCION= '" & uqpaga(0) & "'")
        If Not dtU_q_paga.Rows.Count > 0 Then
            Dim j = 1 + 2
        End If
        'Dim FECHA = DateTime.ParseExact(Mid(Fecha_carga, 1, 10), "yyyyMMddhhmm", Nothing)
        Dim dt_temp_tpact As DataTable = mostrar("select * from tipos_actividades where descripcion = '" & Replace(tipo_actividad, " ", "") & "'")
        ' Dim asda = "select * from tipos_actividades where descripcion = '" & Replace(tipo_actividad, " ", "") & "'"
        If dt_temp_tpact.Rows.Count = 0 Then
            tipo_actividad = Replace(tipo_actividad, " ", "")
            IngresarTipoActividad(tipo_actividad)

        Else
            tipo_actividad = dt_temp_tpact.Rows(0).Item(0).ToString

        End If

        Dim dt_temp_campcod As DataTable = mostrar("select campus_codigo from campus where descripcion='" & Replace(campus_codigo, " ", "") & "'")

        If dt_temp_campcod.Rows.Count = 0 Then
            IngresarCampus(campus_codigo, campus_codigo)
            campus_codigo = Replace(campus_codigo, " ", "")
        Else
            campus_codigo = dt_temp_campcod.Rows(0).Item(0)
        End If



        Dim dt_temp_jornada As DataTable = mostrar("select * from Jornadas where descipcion ='" & Jornada & "'")
        If dt_temp_jornada.Rows.Count = 0 Then
            IngresarJornadas(Jornada.Trim, Jornada.Trim)
            Jornada = Replace(Jornada, " ", "")
        Else
            Jornada = dt_temp_jornada.Rows(0).Item(0).ToString

        End If
        Dim dt_temp_Unid_acade As DataTable = mostrar("select * from  Unidades_Academicas where descripcion='" & Unid_aca_cod.ToUpper & "'")
        'Dim aaa = "select * from  Unidades_Academicas where descripcion='" & Unid_aca_cod.ToUpper & "'"
        If dt_temp_Unid_acade.Rows.Count = 0 Then

            IngresarUnidadAcademica(Unid_aca_cod.ToUpper)
            Unid_aca_cod = Mid(Replace(Unid_aca_cod.ToUpper, " ", ""), 1, 9)
        Else
            Unid_aca_cod = dt_temp_Unid_acade.Rows(0).Item(0).ToString
        End If


        Dim dt_temp_modalidad As DataTable = mostrar("select * from Modalidades where descripcion='" & modalidad_codigo & "'")
        ' Dim ccc = "select * from Modalidades where descripcion='" & modalidad_codigo & "'"
        'modalidad_codigo = dt_temp_modalidad.Rows(0).Item(0).ToString
        If dt_temp_modalidad.Rows.Count = 0 Then

            IngresarModalidad(modalidad_codigo.ToUpper)
            modalidad_codigo = Replace(modalidad_codigo, " ", "")
        Else
            modalidad_codigo = dt_temp_modalidad.Rows(0).Item(0).ToString
        End If

        Dim dt_temp_curso_materia As DataTable = mostrar("select * from Materias where curso_materia = '" & curso_materia & "'")
        If dt_temp_curso_materia.Rows.Count = 0 Then
            IngresarMaterias(curso_materia.ToUpper, curso_materia.ToUpper)
            curso_materia = Replace(modalidad_codigo, " ", "")
        Else
            curso_materia = dt_temp_curso_materia.Rows(0).Item(0).ToString
        End If

        'Dim dtU_q_paga As DataTable = mostrar("select CODIGO from  PROGRAMAS  where DESCRIPCION = '" & U_Q_Paga & "'")
        If rut_docente.Length > 10 Then
            Dim ruts = Split(rut_docente, "/")
            Dim docentes = Split(Docente, "/")
            rut_docente = rut_docente(0)
            Docente = docentes(0)
        End If
        Dim dt_temp_Docentes As DataTable = mostrar("select * from  docentes  where rut_docente='" & rut_docente & "'")
        'Dim     aaa = "select * from  Unidades_Academicas where descripcion='" & Unid_aca_cod.ToUpper & "'"
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
     Replace(Programa, " ", "") & "','" & nivel_curso & "'," & numero_periodo & ", '" & dtU_q_paga.Rows(0).Item(0).ToString & "')"

        'Dim asd = ''Fecha_carga', 'Dia', 'Cantidad', 'NRC', 'seccion', 'Lista_cruzada', 'NRC_Ligado', 'ID_Listas_Cruzadas', 'sala_codigo', 'Jornada', 'curso_materia', 'numero_periodo ', 'tipo_actividad', 'campus_codigo ', 'bloque_codigo ', 'rut_docente ', 'modalidad_codigo ', 'Unid_aca_cod', 'Fecha_inicio ', 'fecha_fin', 'nombre_curso ', 'tipo_carga', 'Programa', 'nivel_curso ''
        Try
            conectado()
            'Dim ds As New DataSet
            'insertar = insertar.ToUpper
            'Dim da As New SqlDataAdapter(insertar, cnn)

            cmd = New SqlCommand(insertar, cnn)
            cmd.Parameters.AddWithValue("@fechacarga", Convert.ToDateTime(Fecha_carga))
            cmd.Parameters.AddWithValue("@fechainicio", Convert.ToDateTime(Fecha_inicio))
            cmd.Parameters.AddWithValue("@fechafin", Convert.ToDateTime(fecha_fin))
            cmd.ExecuteNonQuery()

            '04-08-2014','29-11-2014'
            ' da.Fill(ds)
        Catch ex As Exception


        End Try


        cnn.Close()


    End Function
    Public Function IngresarMaterias(ByVal curso As String, ByVal descripcion As String)

        Dim insertar As String = "insert into Materias values('" & Replace(curso.ToUpper, " ", "") & "', '" & Replace(descripcion.ToUpper, " ", "") & "')"
        Try
            conectado()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        cnn.Close()
    End Function
    Public Function Ingresarperiodos(ByVal periodo As String)
        ' Dim dt As DataTable = mostrar("select * from periodos where periodo=" & periodo)
        '  Dim Numero_periodo As String = dt.Rows.Count + 1


        'Dim FECHA = DateTime.Now.ToShortDateString("dd/mm/yyyy")

        Dim insertar As String = "insert into Periodos values( 'ACTIVO', '" & Replace(periodo.ToUpper, " ", "") & "')"
        Try
            conectado()
            Dim ds As New DataSet
            insertar = insertar.ToUpper
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        cnn.Close()
    End Function
    Public Function IngresarTipoActividad(ByVal actividad As String)
        Dim insertar As String = "insert into tipos_actividades values('" & Replace(actividad.ToUpper, " ", "") & "','" & Replace(actividad.ToUpper, " ", "") & "')"
        Try
            conectado()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectado()
        End Try
    End Function

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

    Public Function IngresarUnidadAcademica(ByVal Unidad_academica As String)
        Dim codigo = Mid(Replace(Unidad_academica.ToUpper, " ", ""), 1, 9)
        Dim insertar As String = "insert into Unidades_Academicas values ('" & codigo & "','" & Unidad_academica.ToUpper & "')"
        Try
            conectado()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectado()
        End Try
    End Function
    Public Function IngresarModalidad(ByVal Modalidad As String)
        Dim insertar As String = "insert into modalidades values ('" & Replace(Modalidad.ToUpper, " ", "") & "',' ')"
        Try
            conectado()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectado()
        End Try
    End Function
    Public Function IngresarBloques(ByVal Horario As String)


        Dim insertar As String = "insert into Bloques values ('" & Replace(Horario.ToUpper, " ", "") & "','" & Horario & "')"
        Try
            conectado()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(insertar, cnn)
            da.Fill(ds)
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectado()
        End Try

    End Function

    Public Function consultaPeriodo() As DataTable
        Dim dtperiodo As DataTable = mostrar("select periodo from periodos where estado='ACTIVO'")
        Return dtperiodo
    End Function
    Public Function consultarCampus() As DataTable
        Dim dtcampus As DataTable = mostrar("select campus_codigo from Campus")
        Return dtcampus
    End Function
    Public Function consultarSalas(ByVal sede As String) As DataTable
        Dim dtSalas As DataTable = mostrar("select * from salas where sala_codigo like  '" & sede & "%' and Descripcion_sala<> 'NO DISPONIBLE'")
        Return dtSalas
    End Function
    Public Function consultaRescuelas() As DataTable
        Dim dtescuelas As DataTable = mostrar("select unidad_academica_codigo from Unidades_Academicas")
        Return dtescuelas
    End Function

    Public Function consultarProgramas() As DataTable
        Dim dtprogramas As DataTable = mostrar("select distinct(programa) from Horarios")
        Return dtprogramas
    End Function

    Public Function consultarNiveles() As DataTable
        Dim dtnivel_curso As DataTable = mostrar("select distinct(nivel_curso) from Horarios")
        Return dtnivel_curso
    End Function



End Class
