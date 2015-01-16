Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Public Class IngresoBD
    Private DATO As String

    Function horario(ByVal dia As String) As DataTable
       
        If dia = "LU" Then
            dia = "1"
        ElseIf dia = "MA" Then
            dia = "2"
        ElseIf dia = "MI" Then
            dia = "3"
        ElseIf dia = "JU" Then
            dia = "4"
        ElseIf dia = "VI" Then
            dia = "5"
        ElseIf dia = "SA" Or dia = "SÁ" Then
            dia = "6"
        Else
            dia = "7"
        End If


        Dim dtsala, dthorario, dtdocente As New GHAU_CapaDatos.BaseDato
        Dim dts, dth, dt, dtd As New DataTable

        dts = dtsala.mostrar("select sala,capacidad,recursos_codigo, Descripcion_sala from Salas where sala_codigo like 'VM%'order by sala_codigo")
        dth = dthorario.mostrar("select sala_codigo,nrc, bloque_codigo, Nombre_curso, Tipo_Carga, rut_docente, jornada_codigo from Horarios where sala_codigo like 'VM%' and dia='" & dia & "' order by sala_codigo")
        'Dim pntocontrolconsultaselect__dth = "select sala_codigo,nrc, bloque_codigo, Nombre_curso, Tipo_Carga, rut_docente from Horarios where sala_codigo like 'VM%' and dia='" & dia & "' order by sala_codigo"

        dt.Columns.Add("Boque", Type.GetType("System.String")) '0
        dt.Columns.Add("  ", Type.GetType("System.String")) '0
        ' dt.Columns.Add("Fin", Type.GetType("System.String")) '0
        For i = 0 To dts.Rows.Count - 1
            Dim ESTADO As String
            If InStr(dts.Rows(i).Item(3).ToString, "NO DISPONIBLE") > 0 Then
                ESTADO = "NO DISPONIBLE"
            Else
                ESTADO = "DISPONIBLE"
            End If
            dt.Columns.Add(dts.Rows(i).Item(0).ToString & vbNewLine & "CAPACIDAD: " & dts.Rows(i).Item(1).ToString & vbNewLine & "ESTADO: " & ESTADO, Type.GetType("System.String")) '0

        Next

        'crea las 19 rows para representar los modulos del horario
        For i = 0 To 19
            dt.Rows.Add()
            If i < 14 Then
                dt.Rows(dt.Rows.Count - 1).Item(0) = i + 1 & vbNewLine & "D"
            Else
                dt.Rows(dt.Rows.Count - 1).Item(0) = i - 13 & vbNewLine & "V"
            End If

        Next
        For i = 0 To 19
            Select Case i
                Case 0
                    dt.Rows(i).Item(1) = "8:30" & vbNewLine & "9:15"
                Case 1
                    dt.Rows(i).Item(1) = "9:25" & vbNewLine & "10:10"

                Case 2


                    dt.Rows(i).Item(1) = "10:20" & vbNewLine & "11:05"
                Case 3
                    dt.Rows(i).Item(1) = "11:15" & vbNewLine & "12:00"
                Case 4
                    dt.Rows(i).Item(1) = "12:10" & vbNewLine & "12:55"
                Case 5
                    dt.Rows(i).Item(1) = "13:05" & vbNewLine & "13:50"
                Case 6
                    dt.Rows(i).Item(1) = "14:00" & vbNewLine & "14:45"
                Case 7
                    dt.Rows(i).Item(1) = "14:55" & vbNewLine & "15:40"
                Case 8
                    dt.Rows(i).Item(1) = "15:50" & vbNewLine & "16:35"
                Case 9
                    dt.Rows(i).Item(1) = "16:45" & vbNewLine & "17:30"
                Case 10
                    dt.Rows(i).Item(1) = "1740" & vbNewLine & "18:25"
                Case 11
                    dt.Rows(i).Item(1) = "18:35" & vbNewLine & "19:20"
                Case 12
                    dt.Rows(i).Item(1) = "19:30" & vbNewLine & "20:15"
                Case 13
                    dt.Rows(i).Item(1) = "20:25" & vbNewLine & "21:10"
                Case 14
                    dt.Rows(i).Item(1) = "19:00" & vbNewLine & "19:45"
                Case 15
                    dt.Rows(i).Item(1) = "19:46" & vbNewLine & "20:30"
                Case 16
                    dt.Rows(i).Item(1) = "20:40" & vbNewLine & "21:25"
                Case 17
                    dt.Rows(i).Item(1) = "21:26" & vbNewLine & "22:10"
                Case 18
                    dt.Rows(i).Item(1) = "22:20" & vbNewLine & "23:05"
                Case 19
                    dt.Rows(i).Item(1) = "23:06" & vbNewLine & "23:50"

            End Select

        Next
        'punto de control
        Dim dtctl = dt
        'hace el match entre sala y horario
        For i = 0 To dth.Rows.Count - 1
            For j = 1 To dt.Columns.Count - 1
                Dim sala_horario = dth.Rows(i).Item(0).ToString
                Dim salaarray = Split(dt.Columns(j).ColumnName.ToString, vbNewLine)
                Dim sala_datatable = "VM-" & salaarray(0)
                If Replace(sala_horario, " ", "") = Replace(sala_datatable, " ", "") Then
                    Dim modulo = dth.Rows(i).Item(2).ToString
                    Dim modulos = modulo.ToCharArray
                    For x = 0 To modulos.Length - 1
                        If modulos(x) = "1" Then ' sala_codigo,nrc, bloque_codigo, Nombre_curso, Tipo_Carga
                            Dim modalidad = Mid(dth.Rows(i).Item(6).ToString, 1, 1)

                            dtd = dtdocente.mostrar("select nombre from Docentes where rut_docente='" & dth.Rows(i).Item(5).ToString & "'")
                            If modalidad.ToUpper.Trim = "D" Then
                                dt.Rows(x).Item(j) = dth.Rows(i).Item(1) & "/" & dth.Rows(i).Item(3) & "/" & dtd.Rows(0).Item(0)
                            Else

                                dt.Rows(x + 14).Item(j) = dth.Rows(i).Item(1) & "/" & dth.Rows(i).Item(3) & "/" & dtd.Rows(0).Item(0)
                            End If
                            
                        End If

                    Next

                End If


            Next
        Next
    
        Return dt
    End Function

    Function IngresoSala(ByVal dato As DataTable)
        Dim dt As New DataTable
        dt = dato.Clone
        dt.Columns.Add("Codigo", Type.GetType("System.String"))
        dt.Columns.Add("descripcion", Type.GetType("System.String"))
        dt.Rows.Clear()
        For i = 0 To dato.Rows.Count - 1
            If i <> dato.Rows.Count - 1 Then
                If dato.Rows(i + 1).Item(0).ToString <> "" Then
                    dt.Rows.Add()
                    For j = 0 To dato.Columns.Count - 1

                        dt.Rows(dt.Rows.Count - 1).Item(j) = dato.Rows(i).Item(j).ToString
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(12) = "7"
                    dt.Rows(dt.Rows.Count - 1).Item(13) = "PROYECTOR"

                Else
                    Dim atributo As String = ""
                    Dim salto As Integer = 0
                    dt.Rows.Add()
                    For j = 0 To dato.Columns.Count - 1
                        If j <> 10 Then
                            dt.Rows(dt.Rows.Count - 1).Item(j) = dato.Rows(i).Item(j).ToString
                        Else
                            atributo = dato.Rows(i).Item(j).ToString

                            For k = i + 1 To dato.Rows.Count - 1
                                If dato.Rows(k).Item(0).ToString = "" Then
                                    atributo = atributo.Trim & "/" & dato.Rows(k).Item(j).ToString.Trim
                                Else
                                    salto = k - 1 'deja al i con valor k -1 ya que recorrio todo los vacios y los lleno en la columna atributo correspondiente
                                    Exit For
                                End If
                            Next
                            Dim tablaatributo = Split(atributo, "/")
                            Dim codigo As String = ""
                            Dim descripcion As String = ""
                            For k = 0 To tablaatributo.Length - 1
                                Dim atributocodigo() = Split(tablaatributo(k).ToString.Trim, "-")
                                codigo = codigo & Replace(atributocodigo(0), "", "") & "/"
                                descripcion = descripcion & atributocodigo(1) & "/"
                            Next
                            Dim cod = Replace(codigo.ToString.Trim, " ", "")
                            dt.Rows(dt.Rows.Count - 1).Item(12) = cod
                            dt.Rows(dt.Rows.Count - 1).Item(13) = descripcion
                        End If
                    Next
                    i = salto
                End If
            Else

                If dato.Rows(i).Item(0).ToString <> "" Then
                    dt.Rows.Add()
                    For j = 0 To dato.Columns.Count - 1

                        dt.Rows(dt.Rows.Count - 1).Item(j) = dato.Rows(i).Item(j).ToString
                    Next
                    dt.Rows(dt.Rows.Count - 1).Item(12) = "7"
                    dt.Rows(dt.Rows.Count - 1).Item(13) = "PROYECTOR"

                End If
                End If



        Next


        ingreso_recursos(dt)
        ingreso_salas(dt)
        Ingreso_edificios(dt)
        Ingreso_Salas_Edificios(dt)


    End Function
    Function Ingreso_Salas_Edificios(ByVal dato As DataTable) As Boolean

        Dim ingreso As New GHAU_CapaDatos.BaseDato

        For i = 0 To dato.Rows.Count - 1
            Dim sala_codigo As String = dato.Rows(i).Item(0).ToString.Trim & "-" & dato.Rows(i).Item(1).ToString.Trim
            'inserta los campus a la base de dato
            ingreso.IngresarSalas_Edificios(sala_codigo, dato.Rows(i).Item(0).ToString.Trim)
        Next
    End Function

    Function Ingreso_edificios(ByVal dato As DataTable) As Boolean
        Dim ingreso As New GHAU_CapaDatos.BaseDato
        Dim MyView As DataView = New DataView(dato)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dato.Columns(0).ColumnName.ToString)
        For i = 0 To dtSinDuplicados.Rows.Count - 1
            'inserta los campus a la base de dato
            ingreso.IngresarEdificio(dtSinDuplicados.Rows(i).Item(0).ToString.Trim, dtSinDuplicados.Rows(i).Item(0).ToString.Trim)
        Next
    End Function
    Function errores(ByVal dato As DataTable)
        Dim dtDuplicados = dato
        'elimina los campus repetidos
        Dim MyView As DataView = New DataView(dtDuplicados)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(1).ColumnName.ToString)
        Dim ingreso As New GHAU_CapaDatos.BaseDato
        For i = 0 To dtSinDuplicados.Rows.Count - 1
            'inserta los campus a la base de dato

            'ingreso.IngresarHorarios_errores(dtSinDuplicados.Rows(i).Item(0).ToString, dtSinDuplicados.Rows(i).Item(1).ToString,dtSinDuplicados.Rows(i).Item(2).ToString,dtSinDuplicados.Rows(i).Item(3).ToString,)
        Next
    End Function
    Function Ingreso(ByVal dato As DataTable) As DataTable
        'ingreso_campus(dato)
        ingreso_docentes(dato)
        'ingreso_jornadas(dato)
        ingreso_materias(dato)
        ingreso_periodos(dato)
        'ingreso_Tipo_Actividad(dato)
        ingreso_Unidad_Academica(dato)
        'ingreso_Modalidad(dato)
        'ingreso_salas(dato)
        'dato = ingreso_Bloques(dato)
        Dim dterrores As DataTable = ingreso_horario(dato)

        Return dterrores
    End Function

    'modulos que rescatan datos desde excel para enviarlos a MOD_SQL 
    Function ingreso_campus(ByVal dato As DataTable) 'sirve para ingresar datos a campus
        Dim dtDuplicados = dato
        'elimina los campus repetidos
        Dim MyView As DataView = New DataView(dtDuplicados)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(1).ColumnName.ToString)
        Dim ingreso As New GHAU_CapaDatos.BaseDato
        For i = 0 To dtSinDuplicados.Rows.Count - 1
            'inserta los campus a la base de dato

            ingreso.IngresarCampus(dtSinDuplicados.Rows(i).Item(0).ToString, "")
        Next
    End Function
    Function ingreso_horario(ByVal dato As DataTable) As DataTable
        Dim dterrores As New DataTable
        dterrores = dato.Clone
        dterrores.Rows.Clear()
        dterrores.Columns.Add("TipoError", Type.GetType("System.String")) '0
        Dim dtHorario As New DataTable
        dtHorario.Columns.Add("Fecha_carga", Type.GetType("System.String")) '0
        dtHorario.Columns.Add("Cantidad", Type.GetType("System.String")) '1
        dtHorario.Columns.Add("NRC", Type.GetType("System.String")) '2
        dtHorario.Columns.Add("seccion", Type.GetType("System.String")) '3
        dtHorario.Columns.Add("Lista_cruzada", Type.GetType("System.String")) '4
        dtHorario.Columns.Add("NRC_Ligado", Type.GetType("System.String")) '5
        dtHorario.Columns.Add("ID_Listas_Cruzadas", Type.GetType("System.String")) '6
        dtHorario.Columns.Add("sala_codigo", Type.GetType("System.String")) '7
        dtHorario.Columns.Add("Jornada", Type.GetType("System.String")) '8
        dtHorario.Columns.Add("curso_materia", Type.GetType("System.String")) '9
        dtHorario.Columns.Add("periodo ", Type.GetType("System.String")) '10
        dtHorario.Columns.Add("tipo_actividad", Type.GetType("System.String")) '11
        dtHorario.Columns.Add("campus_codigo ", Type.GetType("System.String")) '12
        dtHorario.Columns.Add("rut_docente ", Type.GetType("System.String")) '13
        dtHorario.Columns.Add("modalidad_codigo ", Type.GetType("System.String")) '14
        dtHorario.Columns.Add("Unid_aca_cod", Type.GetType("System.String")) '15
        dtHorario.Columns.Add("Fecha_inicio ", Type.GetType("System.String")) '16
        dtHorario.Columns.Add("fecha_fin", Type.GetType("System.String")) '17
        dtHorario.Columns.Add("nombre_curso ", Type.GetType("System.String")) '18
        dtHorario.Columns.Add("tipo_carga", Type.GetType("System.String")) '19
        dtHorario.Columns.Add("Programa", Type.GetType("System.String")) '20
        dtHorario.Columns.Add("nivel_curso ", Type.GetType("System.String")) '21
        dtHorario.Columns.Add("DiaLunes", Type.GetType("System.String")) '22
        dtHorario.Columns.Add("DiaMartes", Type.GetType("System.String")) '23
        dtHorario.Columns.Add("DiaMiercoles", Type.GetType("System.String")) '24
        dtHorario.Columns.Add("DiaJueves", Type.GetType("System.String")) '25
        dtHorario.Columns.Add("DiaViernes", Type.GetType("System.String")) '26
        dtHorario.Columns.Add("DiaSabado", Type.GetType("System.String")) '27
        dtHorario.Columns.Add("DiaDomingo", Type.GetType("System.String")) '28
        dtHorario.Columns.Add("DiaOtros", Type.GetType("System.String")) '29
        dtHorario.Columns.Add("Revisado", Type.GetType("System.String")) '30
        For i = 0 To dato.Rows.Count - 1
            dtHorario.Rows.Add()
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22) = "00000000000000" 'lunes
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23) = "00000000000000" 'martes
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24) = "00000000000000" 'miercoles
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25) = "00000000000000" 'jueve
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26) = "00000000000000" 'viernes
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27) = "00000000000000" 'sab
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28) = "00000000000000" 'dom
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29) = "00000000000000" 'otro

            Dim arr_sala() = Split(Replace(dato.Rows(i).Item(24).ToString, " ", ""), "/")
            Dim arr_edificio() = Split(Replace(dato.Rows(i).Item(23).ToString, " ", ""), "/")
            Dim arr_dia = Split(dato.Rows(i).Item(20).ToString, "/")

            'If DBNull.Value.Equals(dato.Rows(i).Item(20)) Then
            'For x = 0 To dato.Columns.Count - 1
            If DBNull.Value.Equals(dato.Rows(i).Item(3)) Or DBNull.Value.Equals(dato.Rows(i).Item(4)) Or DBNull.Value.Equals(dato.Rows(i).Item(8)) Or DBNull.Value.Equals(dato.Rows(i).Item(14)) Or DBNull.Value.Equals(dato.Rows(i).Item(18)) Or DBNull.Value.Equals(dato.Rows(i).Item(19)) Or DBNull.Value.Equals(dato.Rows(i).Item(20)) Then
                dterrores.Rows.Add()
                For columnas = 0 To dato.Columns.Count - 1
                    dterrores.Rows(dterrores.Rows.Count - 1).Item(columnas) = dato.Rows(i).Item(columnas)
                Next
                dterrores.Rows(dterrores.Rows.Count - 1).Item(dterrores.Columns.Count - 1) = "revisar: 'Periodo','Materia','NRC','Rut Profesor','Tipo Actividad','Modalidad','Horario"
                GoTo 1
            End If
            'Next

            Dim iiii = CInt(dato.Rows(i).Item(8))

            If InStr(dato.Rows(i).Item(24).ToString, "/") > 0 Then 'osea es una sala sal606/sal608

                For j = 0 To arr_dia.Length - 1
                    ' Dim largo As Integer = 

                    If dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7).ToString = arr_edificio(j) & "-" & arr_sala(j) Or dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7).ToString = "" Then
                        For x = 0 To CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)
                            Dim puntocontrolfinalFor = CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)
                            Dim temp_horario = Mid(Replace(arr_dia(j).ToString, " ", ""), ((12 * x) + 1), 12)
                            Dim temp_bloque = Modularizacion(Mid(temp_horario, 4, 4), Mid(temp_horario, 9, 4)) 'obtengo el bloque
                            If temp_bloque = "" Then
                                dtHorario.Rows.RemoveAt(dtHorario.Rows.Count - 1)

                                dterrores.Rows.Add()
                                For columnas = 0 To dato.Columns.Count - 1
                                    dterrores.Rows(dterrores.Rows.Count - 1).Item(columnas) = dato.Rows(i).Item(columnas)
                                Next
                                dterrores.Rows(dterrores.Rows.Count - 1).Item(dterrores.Columns.Count - 1) = "revisar columna 'horario'"
                                GoTo 1
                            End If

                            Dim temp_dia = Mid(temp_horario.ToUpper, 1, 3) 'obtengo el dia
                            Dim modulo As String = ""
                            Select Case temp_dia.ToUpper
                                Case ".LU"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22).ToString
                                Case ".MA"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23).ToString
                                Case ".MI"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24).ToString
                                Case ".JU"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25).ToString
                                Case ".VI"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26).ToString
                                Case ".SA"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27).ToString
                                Case ".DO"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28).ToString
                                Case Else
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29).ToString
                            End Select
                            Dim temp_arr_horario() As Char = modulo.ToCharArray
                            For k = CInt(Mid(temp_bloque, 1, 2)) - 1 To CInt(Mid(temp_bloque, 4)) - 1
                                temp_arr_horario(k) = "1"
                            Next
                            Dim bloque As String = ""
                            For k = 0 To temp_arr_horario.Length - 1
                                bloque = bloque & temp_arr_horario(k)
                            Next
                            Select Case temp_dia.ToUpper
                                Case ".LU"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22) = bloque
                                Case ".MA"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23) = bloque
                                Case ".MI"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24) = bloque
                                Case ".JU"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25) = bloque
                                Case ".VI"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26) = bloque
                                Case ".SA"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27) = bloque
                                Case ".DO"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28) = bloque
                                Case Else
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29) = bloque
                            End Select
                            'dtHorario.Rows.Add()
                            Dim dts = dtHorario
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(0) = DateTime.Now() '.ToShortDateString()
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(1) = dato.Rows(i).Item(21).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(2) = dato.Rows(i).Item(8).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(3) = dato.Rows(i).Item(6).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(4) = dato.Rows(i).Item(9).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(5) = dato.Rows(i).Item(10).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(6) = dato.Rows(i).Item(11).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7) = arr_edificio(j) & "-" & arr_sala(j)
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(8) = dato.Rows(i).Item(7).ToString


                            Dim numero As String = ""
                            If dato.Rows(i).Item(5).ToString.Length = 2 Then
                                numero = "0" & dato.Rows(i).Item(5).ToString
                            ElseIf dato.Rows(i).Item(5).ToString.Length >= 3 Then
                                numero = dato.Rows(i).Item(5).ToString
                            ElseIf dato.Rows(i).Item(5).ToString.Length = 1 Then

                                numero = "00" & dato.Rows(i).Item(5).ToString

                            End If


                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(9) = dato.Rows(i).Item(4).ToString & "-" & numero
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(10) = dato.Rows(i).Item(3).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(11) = dato.Rows(i).Item(18).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(12) = dato.Rows(i).Item(1).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(13) = dato.Rows(i).Item(14).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(14) = dato.Rows(i).Item(19).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(15) = dato.Rows(i).Item(2).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(16) = dato.Rows(i).Item(33).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(17) = dato.Rows(i).Item(34).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(18) = dato.Rows(i).Item(16).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(19) = "D"
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(20) = dato.Rows(i).Item(26).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(21) = dato.Rows(i).Item(29).ToString




                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(30) = "NO Revisado"

                        Next 'termino de recorrer arr_dia

                    Else
                        dtHorario.Rows.Add()
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22) = "00000000000000" 'lunes
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23) = "00000000000000" 'martes
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24) = "00000000000000" 'miercoles
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25) = "00000000000000" 'jueve
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26) = "00000000000000" 'viernes
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27) = "00000000000000" 'sab
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28) = "00000000000000" 'dom
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29) = "00000000000000" 'otro

                        For x = 0 To CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)

                            ' Dim puntocontrolfinalFor = CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)
                            Dim temp_horario = Mid(Replace(arr_dia(j).ToString, " ", ""), ((12 * x) + 1), 12)
                            Dim temp_bloque = Modularizacion(Mid(temp_horario, 4, 4), Mid(temp_horario, 9, 4)) 'obtengo el bloque
                            Dim temp_dia = Mid(temp_horario.ToUpper, 1, 3) 'obtengo el dia
                            Dim modulo As String = ""
                            Select Case temp_dia.ToUpper
                                Case ".LU"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22)
                                Case ".MA"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23)
                                Case ".MI"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24)
                                Case ".JU"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25)
                                Case ".VI"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26)
                                Case ".SA"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27)
                                Case ".DO"
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28)
                                Case Else
                                    modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29)
                            End Select
                            Dim temp_arr_horario() As Char = modulo.ToCharArray
                            For k = CInt(Mid(temp_bloque, 1, 2)) - 1 To CInt(Mid(temp_bloque, 4)) - 1
                                temp_arr_horario(k) = "1"
                            Next
                            Dim bloque As String = ""
                            For k = 0 To temp_arr_horario.Length - 1
                                bloque = bloque & temp_arr_horario(k)
                            Next
                            Select Case temp_dia.ToUpper
                                Case ".LU"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22) = bloque
                                Case ".MA"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23) = bloque
                                Case ".MI"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24) = bloque
                                Case ".JU"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25) = bloque
                                Case ".VI"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26) = bloque
                                Case ".SA"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27) = bloque
                                Case ".DO"
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28) = bloque
                                Case Else
                                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29) = bloque
                            End Select
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7) = arr_edificio(j) & "-" & arr_sala(j)
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(2) = dato.Rows(i).Item(8).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(11) = dato.Rows(i).Item(18).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(30) = "NO Revisado"



                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(0) = DateTime.Now() '.ToShortDateString()
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(1) = dato.Rows(i).Item(21).ToString

                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(3) = dato.Rows(i).Item(6).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(4) = dato.Rows(i).Item(9).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(5) = dato.Rows(i).Item(10).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(6) = dato.Rows(i).Item(11).ToString

                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(8) = dato.Rows(i).Item(7).ToString
                            Dim numero As String = ""
                            'If CInt(dato.Rows(i).Item(5).ToString) >= 10 And CInt(dato.Rows(i).Item(5).ToString) < 100 Then
                            '    numero = "0" & dato.Rows(i).Item(5).ToString
                            'ElseIf CInt(dato.Rows(i).Item(5).ToString) >= 100 Then
                            '    numero = dato.Rows(i).Item(5).ToString
                            'ElseIf CInt(dato.Rows(i).Item(5).ToString) < 10 Then

                            '    numero = "00" & dato.Rows(i).Item(5).ToString

                            'End If
                            If dato.Rows(i).Item(5).ToString.Length = 2 Then
                                numero = "0" & dato.Rows(i).Item(5).ToString
                            ElseIf dato.Rows(i).Item(5).ToString.Length >= 3 Then
                                numero = dato.Rows(i).Item(5).ToString
                            ElseIf dato.Rows(i).Item(5).ToString.Length = 1 Then

                                numero = "00" & dato.Rows(i).Item(5).ToString

                            End If

                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(9) = dato.Rows(i).Item(4).ToString & "-" & numero

                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(10) = dato.Rows(i).Item(3).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(12) = dato.Rows(i).Item(1).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(13) = dato.Rows(i).Item(14).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(14) = dato.Rows(i).Item(19).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(15) = dato.Rows(i).Item(2).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(16) = dato.Rows(i).Item(33).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(17) = dato.Rows(i).Item(34).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(18) = dato.Rows(i).Item(16).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(19) = "D"
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(20) = dato.Rows(i).Item(26).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(21) = dato.Rows(i).Item(29).ToString




                        Next 'termino de recorrer arr_dia


                    End If




                Next


            Else

                If dato.Rows(i).Item(20).ToString.Length > 12 Then
                    Dim Control_maximoFor = CInt((Replace(dato.Rows(i).Item(20).ToString, " ", "").Length / 12) - 1)

                    For j = 0 To CInt((Replace(dato.Rows(i).Item(20).ToString, " ", "").Length / 12) - 1)
                        Dim temp_horario = Mid(Replace(dato.Rows(i).Item(20).ToString, " ", ""), ((j * 12) + 1), 12)
                        ' Dim puntocontrolfinalFor = CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)

                        Dim temp_bloque = Modularizacion(Mid(temp_horario, 4, 4), Mid(temp_horario, 9, 4)) 'obtengo el bloque
                        If temp_bloque = "" Then
                            dtHorario.Rows.RemoveAt(dtHorario.Rows.Count - 1)

                            dterrores.Rows.Add()
                            For columnas = 0 To dato.Columns.Count - 1
                                dterrores.Rows(dterrores.Rows.Count - 1).Item(columnas) = dato.Rows(i).Item(columnas)
                            Next
                            dterrores.Rows(dterrores.Rows.Count - 1).Item(dterrores.Columns.Count - 1) = "revisar columna 'horario'"
                            GoTo 1
                        End If
                        Dim temp_dia = Mid(temp_horario.ToUpper, 1, 3) 'obtengo el dia
                        Dim modulo As String = ""
                        Select Case temp_dia.ToUpper
                            Case ".LU"
                                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22)
                            Case ".MA"
                                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23)
                            Case ".MI"
                                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24)
                            Case ".JU"
                                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25)
                            Case ".VI"
                                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26)
                            Case ".SA"
                                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27)
                            Case ".DO"
                                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28)
                            Case Else
                                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29)
                        End Select

                        Dim temp_arr_horario() As Char = modulo.ToCharArray
                        For k = CInt(Mid(temp_bloque, 1, 2)) - 1 To CInt(Mid(temp_bloque, 4)) - 1
                            temp_arr_horario(k) = "1"
                        Next
                        Dim bloque As String = ""
                        For k = 0 To temp_arr_horario.Length - 1
                            bloque = bloque & temp_arr_horario(k)
                        Next
                        Select Case temp_dia.ToUpper
                            Case ".LU"
                                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22) = bloque
                            Case ".MA"
                                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23) = bloque
                            Case ".MI"
                                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24) = bloque
                            Case ".JU"
                                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25) = bloque
                            Case ".VI"
                                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26) = bloque
                            Case ".SA"
                                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27) = bloque
                            Case ".DO"
                                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28) = bloque
                            Case Else
                                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29) = bloque
                        End Select
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7) = dato.Rows(i).Item(23).ToString & "-" & dato.Rows(i).Item(24).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(2) = dato.Rows(i).Item(8).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(11) = dato.Rows(i).Item(18).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(30) = "NO Revisado"



                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(0) = DateTime.Now() '.ToShortDateString()
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(1) = dato.Rows(i).Item(21).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(3) = dato.Rows(i).Item(6).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(4) = dato.Rows(i).Item(9).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(5) = dato.Rows(i).Item(10).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(6) = dato.Rows(i).Item(11).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(8) = dato.Rows(i).Item(7).ToString
                        Dim codigo As String = dato.Rows(i).Item(8).ToString
                        Dim Nrrc = dato.Rows(i).Item(5).ToString.Length
                        'If dato.Rows(i).Item(5).ToString.Length >= 10 And dato.Rows(i).Item(5).ToString.Length < 100 Then
                        '    codigo = "0" & dato.Rows(i).Item(5).ToString
                        'ElseIf dato.Rows(i).Item(5).ToString.Length >= 100 Then
                        '    codigo = dato.Rows(i).Item(5).ToString
                        'ElseIf dato.Rows(i).Item(5).ToString.Length < 10 Then
                        '    codigo = "00" & dato.Rows(i).Item(5).ToString

                        'End If
                        If dato.Rows(i).Item(5).ToString.Length = 2 Then
                            codigo = "0" & dato.Rows(i).Item(5).ToString
                        ElseIf dato.Rows(i).Item(5).ToString.Length >= 3 Then
                            codigo = dato.Rows(i).Item(5).ToString
                        ElseIf dato.Rows(i).Item(5).ToString.Length = 1 Then

                            codigo = "00" & dato.Rows(i).Item(5).ToString

                        End If

                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(9) = dato.Rows(i).Item(4).ToString & "-" & codigo
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(10) = dato.Rows(i).Item(3).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(12) = dato.Rows(i).Item(1).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(13) = dato.Rows(i).Item(14).ToString

                        Dim ds = dtHorario
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(14) = dato.Rows(i).Item(19).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(15) = dato.Rows(i).Item(2).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(16) = dato.Rows(i).Item(33).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(17) = dato.Rows(i).Item(34).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(18) = dato.Rows(i).Item(16).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(19) = "D"
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(20) = dato.Rows(i).Item(26).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(21) = dato.Rows(i).Item(29).ToString



                    Next
                    Dim corroborar() = Split(dato.Rows(i).Item(20).ToString, "/")
                    Dim horario = ""
                Else


                    Dim temp_horario = Mid(Replace(dato.Rows(i).Item(20).ToString, " ", ""), (1), 12)
                    Dim temp_bloque = Modularizacion(Mid(temp_horario, 4, 4), Mid(temp_horario, 9, 4)) 'obtengo el bloque
                    Dim temp_dia = Mid(temp_horario.ToUpper, 1, 3) 'obtengo el dia
                    Dim modulo As String = ""
                    Select Case temp_dia.ToUpper
                        Case ".LU"
                            modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22)
                        Case ".MA"
                            modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23)
                        Case ".MI"
                            modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24)
                        Case ".JU"
                            modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25)
                        Case ".VI"
                            modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26)
                        Case ".SA"
                            modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27)
                        Case ".DO"
                            modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28)
                        Case Else
                            modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29)
                    End Select

                    Dim temp_arr_horario() As Char = modulo.ToCharArray
                    Dim a = temp_bloque
                    For k = CInt(Mid(temp_bloque, 1, 2)) - 1 To CInt(Mid(temp_bloque, 4)) - 1
                        temp_arr_horario(k) = "1"
                    Next
                    Dim bloque As String = ""
                    For k = 0 To temp_arr_horario.Length - 1
                        bloque = bloque & temp_arr_horario(k)
                    Next
                    Select Case temp_dia.ToUpper
                        Case ".LU"
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22) = bloque
                        Case ".MA"
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23) = bloque
                        Case ".MI"
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24) = bloque
                        Case ".JU"
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25) = bloque
                        Case ".VI"
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26) = bloque
                        Case ".SA"
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27) = bloque
                        Case ".DO"
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28) = bloque
                        Case Else
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29) = bloque
                    End Select


                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7) = dato.Rows(i).Item(23).ToString & "-" & dato.Rows(i).Item(24).ToString

                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(2) = dato.Rows(i).Item(8).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(11) = dato.Rows(i).Item(18).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(30) = "NO Revisado"


                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(0) = DateTime.Now() '.ToShortDateString()
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(1) = dato.Rows(i).Item(21).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(3) = dato.Rows(i).Item(6).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(4) = dato.Rows(i).Item(9).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(5) = dato.Rows(i).Item(10).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(6) = dato.Rows(i).Item(11).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(8) = dato.Rows(i).Item(7).ToString
                    Dim numero As String = ""
                    If CInt(dato.Rows(i).Item(5).ToString) >= 10 And CInt(dato.Rows(i).Item(5).ToString) < 100 Then
                        numero = "0" & dato.Rows(i).Item(5).ToString
                    ElseIf CInt(dato.Rows(i).Item(5).ToString) < 10 Then
                        numero = "00" & dato.Rows(i).Item(5).ToString
                    ElseIf CInt(dato.Rows(i).Item(5).ToString) >= 100 Then
                        numero = dato.Rows(i).Item(5).ToString
                    End If
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(9) = dato.Rows(i).Item(4).ToString & "-" & numero
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(10) = dato.Rows(i).Item(3).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(12) = dato.Rows(i).Item(1).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(13) = dato.Rows(i).Item(14).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(14) = dato.Rows(i).Item(19).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(15) = dato.Rows(i).Item(2).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(16) = dato.Rows(i).Item(33).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(17) = dato.Rows(i).Item(34).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(18) = dato.Rows(i).Item(16).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(19) = "D"
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(20) = dato.Rows(i).Item(26).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(21) = dato.Rows(i).Item(29).ToString
                End If

                ' For j=0 to  Dim temp_horario = Mid(Replace(arr_dia(j).ToString, " ", ""), ((12 * x) + 1), 12)
                '    For x = 0 To CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)

                '        ' Dim puntocontrolfinalFor = CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)
                '        Dim temp_horario = Mid(Replace(arr_dia(j).ToString, " ", ""), ((12 * x) + 1), 12)
                '        Dim temp_bloque = Modularizacion(Mid(temp_horario, 4, 4), Mid(temp_horario, 9, 4)) 'obtengo el bloque
                '        Dim temp_dia = Mid(temp_horario.ToUpper, 1, 3) 'obtengo el dia
                '        Dim modulo As String = ""
                '        Select Case temp_dia.ToUpper
                '            Case ".LU"
                '                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22)
                '            Case ".MA"
                '                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23)
                '            Case ".MI"
                '                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24)
                '            Case ".JU"
                '                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25)
                '            Case ".VI"
                '                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26)
                '            Case ".SA"
                '                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27)
                '            Case ".DO"
                '                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28)
                '            Case Else
                '                modulo = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29)
                '        End Select
                '        Dim temp_arr_horario() As Char = modulo.ToCharArray
                '        For k = CInt(Mid(temp_bloque, 1, 2)) - 1 To CInt(Mid(temp_bloque, 4)) - 1
                '            temp_arr_horario(k) = "1"
                '        Next
                '        Dim bloque As String = ""
                '        For k = 0 To temp_arr_horario.Length - 1
                '            bloque = bloque & temp_arr_horario(k)
                '        Next
                '        Select Case temp_dia.ToUpper
                '            Case ".LU"
                '                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22) = bloque
                '            Case ".MA"
                '                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23) = bloque
                '            Case ".MI"
                '                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24) = bloque
                '            Case ".JU"
                '                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25) = bloque
                '            Case ".VI"
                '                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26) = bloque
                '            Case ".SA"
                '                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27) = bloque
                '            Case ".DO"
                '                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28) = bloque
                '            Case Else
                '                dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29) = bloque
                '        End Select
                '        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7) = arr_edificio(j) & "-" & arr_sala(j)

                '    Next 'termino de recorrer arr_dia


            End If

1:
        Next



        'Catch ex As Exception
        '    Dim c = 1 + 2

        'End Try


        Dim datossinDuplicar = Limpieza(dtHorario)

        For i = datossinDuplicar.Rows.Count - 1 To 0 Step -1
            If datossinDuplicar.Rows(i).Item(2).ToString = "" Then
                datossinDuplicar.Rows(i).Delete()
            End If
        Next
        'Dim nuedosindopicar = Limpieza(datossinDuplicar)
        For i = 0 To datossinDuplicar.Rows.Count - 1

            'inserta los campus a la base de dat
            Dim ingreso As New GHAU_CapaDatos.BaseDato
            Dim ds = datossinDuplicar
            Dim fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, _
            curso_materia, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, _
            Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso, Periodo As String

            fecha_carga = datossinDuplicar.Rows(i).Item(0).ToString
            cantidad = datossinDuplicar.Rows(i).Item(1).ToString
            nrc = datossinDuplicar.Rows(i).Item(2).ToString
            seccion = datossinDuplicar.Rows(i).Item(3).ToString
            lista_cruzada = datossinDuplicar.Rows(i).Item(4).ToString
            nrc_ligado = datossinDuplicar.Rows(i).Item(5).ToString
            id_listas_cruzadas = datossinDuplicar.Rows(i).Item(6).ToString
            sala_codigo = datossinDuplicar.Rows(i).Item(7).ToString
            jornada_codigo = datossinDuplicar.Rows(i).Item(8).ToString
            curso_materia = datossinDuplicar.Rows(i).Item(9).ToString
            tipo_actividad = datossinDuplicar.Rows(i).Item(11).ToString
            campus_codigo = datossinDuplicar.Rows(i).Item(12).ToString
            Rut_docente = datossinDuplicar.Rows(i).Item(13).ToString
            modalidad_codigo = datossinDuplicar.Rows(i).Item(14).ToString
            unidad_academica_codigo = datossinDuplicar.Rows(i).Item(15).ToString
            Fecha_inicio = datossinDuplicar.Rows(i).Item(16).ToString
            Fecha_fin = datossinDuplicar.Rows(i).Item(17).ToString
            Nombre_curso = datossinDuplicar.Rows(i).Item(18).ToString
            Tipo_Carga = datossinDuplicar.Rows(i).Item(19).ToString
            Programa = datossinDuplicar.Rows(i).Item(20).ToString
            Nivel_Curso = datossinDuplicar.Rows(i).Item(21).ToString
            Periodo = datossinDuplicar.Rows(i).Item(10).ToString



            If InStr(datossinDuplicar.Rows(i).Item(22), 1) > 0 Then
                dia = "1"
                bloque_codigo = datossinDuplicar.Rows(i).Item(22).ToString
                ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso)
            End If
            If InStr(datossinDuplicar.Rows(i).Item(23), 1) > 0 Then
                dia = "2"
                bloque_codigo = datossinDuplicar.Rows(i).Item(23).ToString
                ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso)
            End If
            If InStr(datossinDuplicar.Rows(i).Item(24), 1) > 0 Then
                dia = "3"
                bloque_codigo = datossinDuplicar.Rows(i).Item(24).ToString
                ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso)
            End If
            If InStr(datossinDuplicar.Rows(i).Item(25), 1) > 0 Then
                dia = "4"
                bloque_codigo = datossinDuplicar.Rows(i).Item(25).ToString
                ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso)

            End If
            If InStr(datossinDuplicar.Rows(i).Item(26), 1) > 0 Then
                dia = "5"
                bloque_codigo = datossinDuplicar.Rows(i).Item(26).ToString
                ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso)
            End If
            If InStr(datossinDuplicar.Rows(i).Item(27), 1) > 0 Then
                dia = "6"
                bloque_codigo = datossinDuplicar.Rows(i).Item(27).ToString
                ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso)
            End If
            If InStr(datossinDuplicar.Rows(i).Item(28), 1) > 0 Then
                dia = "7"
                bloque_codigo = datossinDuplicar.Rows(i).Item(28).ToString
                ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso)
            End If
            If InStr(datossinDuplicar.Rows(i).Item(29), 1) > 0 Then
                dia = "8"
                bloque_codigo = datossinDuplicar.Rows(i).Item(29).ToString
                ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso)
            End If




        Next

        Return dterrores
    End Function
    Function Limpieza(ByVal dt As DataTable) As DataTable

        Dim dtlimpiado As DataTable
        dtlimpiado = dt.Copy
        'dtlimpiado.Rows.Clear()
        For x = 0 To dt.Rows.Count - 1
            For y = x To dtlimpiado.Rows.Count - 1
                If x <> y Then
                    Dim NRC_DTHORARIO = Replace(dt.Rows(x).Item(2).ToString, " ", "")
                    Dim NRC_DTLimpiado = Replace(dtlimpiado.Rows(y).Item(2).ToString, " ", "")
                    Dim sala_dthorario = Replace(dt.Rows(x).Item(7).ToString, " ", "")
                    Dim sala_dtLimpiado = Replace(dtlimpiado.Rows(y).Item(7).ToString, " ", "")
                    Dim tipoact_horario = Replace(dt.Rows(x).Item(11).ToString, " ", "")
                    Dim tipoact_limpiado = Replace(dt.Rows(y).Item(11).ToString, " ", "")
                    If NRC_DTHORARIO = "3231" Then
                        Dim g = "a"
                    End If

                    If NRC_DTHORARIO = NRC_DTLimpiado Then
                        If sala_dthorario = sala_dtLimpiado Then
                            If tipoact_horario = tipoact_limpiado Then
                                For j = 22 To 29
                                    Dim temp_arr_horarioLimpio() As Char = dtlimpiado.Rows(y).Item(j).ToString.ToCharArray
                                    Dim temp_arr_horario() As Char = dt.Rows(x).Item(j).ToString.ToCharArray
                                    For jj = 0 To temp_arr_horario.Length - 1
                                        If temp_arr_horario(jj).ToString = "1" Then
                                            temp_arr_horarioLimpio(jj) = "1"
                                        End If
                                    Next
                                    Dim modulofinal As String = ""
                                    For jj = 0 To temp_arr_horarioLimpio.Length - 1
                                        modulofinal = modulofinal & temp_arr_horarioLimpio(jj)
                                    Next
                                    dt.Rows(x).Item(j) = modulofinal
                                Next
                                For j = 0 To dt.Columns.Count - 1
                                    dt.Rows(y).Item(j) = ""
                                Next

                            End If
                        End If
                    End If


                End If
            Next





        Next



        Return dt

    End Function
    Function CambioDia(ByVal dia As String) As String
        If dia.ToUpper = ".LU" Then
            dia = "1"
        ElseIf dia.ToUpper = ".MA" Then
            dia = "2"
        ElseIf dia.ToUpper = ".MI" Then
            dia = "3"
        ElseIf dia.ToUpper = ".JU" Then
            dia = "4"
        ElseIf dia.ToUpper = ".VI" Then
            dia = "5"
        ElseIf dia.ToUpper = ".SA" Then
            dia = "6"
        ElseIf dia.ToUpper = ".DO" Then
            dia = "7"
        Else
            dia = "8"
        End If

        Return dia

    End Function
    Function Modularizacion(ByVal inicio As String, ByVal fin As String) As String
        Dim modulo As String = ""

        If inicio = "0830" Then
            modulo = "01-"
        ElseIf inicio = "0925" Then
            modulo = "02-"
        ElseIf inicio = "1020" Then
            modulo = "03-"
        ElseIf inicio = "1115" Then
            modulo = "04-"
        ElseIf inicio = "1210" Then
            modulo = "05-"
        ElseIf inicio = "1305" Then
            modulo = "06-"
        ElseIf inicio = "1400" Then
            modulo = "07-"
        ElseIf inicio = "1455" Then
            modulo = "08-"
        ElseIf inicio = "1550" Then
            modulo = "09-"
        ElseIf inicio = "1645" Then
            modulo = "10-"
        ElseIf inicio = "1740" Then
            modulo = "11-"
        ElseIf inicio = "1835" Then
            modulo = "12-"
        ElseIf inicio = "1930" Then
            modulo = "13-"
        ElseIf inicio = "2025" Then
            modulo = "14-"
        ElseIf inicio = "1900" Then
            modulo = "01-"
        ElseIf inicio = "1946" Then
            modulo = "02-"
        ElseIf inicio = "2040" Then
            modulo = "03-"
        ElseIf inicio = "2126" Then
            modulo = "04-"
        ElseIf inicio = "2220" Then
            modulo = "05-"
        ElseIf inicio = "2306" Then
            modulo = "06-"
        Else

        End If


        If fin = "0915" Then
            modulo = modulo & "01"
        ElseIf fin = "1010" Then
            modulo = modulo & "02"
        ElseIf fin = "1105" Then
            modulo = modulo & "03"
        ElseIf fin = "1200" Then
            modulo = modulo & "04"
        ElseIf fin = "1255" Then
            modulo = modulo & "05"
        ElseIf fin = "1350" Then
            modulo = modulo & "06"
        ElseIf fin = "1445" Then
            modulo = modulo & "07"
        ElseIf fin = "1540" Then
            modulo = modulo & "08"
        ElseIf fin = "1635" Then
            modulo = modulo & "09"
        ElseIf fin = "1730" Then
            modulo = modulo & "10"
        ElseIf fin = "1825" Then
            modulo = modulo & "11"
        ElseIf fin = "1920" Then
            modulo = modulo & "12"
        ElseIf fin = "2015" Then
            modulo = modulo & "13"
        ElseIf fin = "2110" Then
            modulo = modulo & "14"
        ElseIf fin = "1945" Then
            modulo = modulo & "01"

        ElseIf fin = "2030" Then
            modulo = modulo & "02"
        ElseIf fin = "2125" Then
            modulo = modulo & "03"
        ElseIf fin = "2210" Then
            modulo = modulo & "04"
        ElseIf fin = "2305" Then
            modulo = modulo & "05"
        ElseIf fin = "2350" Then
            modulo = modulo & "06"
        Else
            modulo = ""
        End If

        Return modulo
    End Function
    Function ingreso_recursos(ByVal dato As DataTable) As DataTable
       
       
        Dim vista As New DataView(dato)
        Dim dtsindupl As DataTable = vista.ToTable(True, dato.Columns(12).ColumnName, dato.Columns(13).ColumnName)
        Dim ingreso As New GHAU_CapaDatos.BaseDato
        For i = 0 To dtsindupl.Rows.Count - 1
            'If InStr(dtsindupl.Rows(i).Item(0).ToString, "-") > 0 Then
            '    Dim row = Replace(dtsindupl.Rows(i).Item(0).ToString, "/", vbNewLine)
            '    Dim datos = Split(row, vbNewLine)

            '    Dim codigo, descripcion As String
            '    codigo = ""
            '    descripcion = ""
            '    '    Dim datoss = datos(h)
            '    For j = 0 To datos.Length - 1
            '        Dim atributos = Split(datos(j), "-")
            '        '    ingreso.Ingresarecursos(Replace(atributos(0), " ", ""), atributos(1))
            '        codigo = codigo & Replace(atributos(0), "", "") & "/"
            '        descripcion = descripcion & atributos(1) & "/"
            '    Next


            ingreso.Ingresarecursos(Replace(dtsindupl.Rows(i).Item(0).ToString, " ", ""), dtsindupl.Rows(i).Item(1).ToString)
            'Next
            ' End If

        Next

    End Function
    Function ingreso_salas(ByVal dato As DataTable) 'sirve para ingresar datos a campus
        Dim ingreso As New GHAU_CapaDatos.BaseDato
        'ingreso.IngresarSalas()
        For i = 0 To dato.Rows.Count - 1
            'Dim sala_codigo As String = dato.Rows(i).Item(0).ToString & "-" & dato.Rows(i).Item(1).ToString
            'Dim descripcion As String = dato.Rows(i).Item(1).ToString
            'Dim capacidad As Integer = 
            'Dim recurso_codigo As String = dato.Rows(i).Item(10).ToString
            'Dim rec As String = "a+b+c    e+f"
            'Dim rec2 = Replace(rec, " ", "")
            Dim sala_codigo As String = dato.Rows(i).Item(0).ToString.Trim & "-" & dato.Rows(i).Item(1).ToString.Trim

            Dim temp_sala As String = dato.Rows(i).Item(1).ToString.Trim.Replace(" ", "").Trim


            'Dim estado As String = dato.Rows(i).Item(3).ToString
            Dim Cod_inventario As String = dato.Rows(i).Item(2).ToString.Trim

            Dim Descripcion_sala As String = dato.Rows(i).Item(3).ToString.Trim
            Dim capacidad As Integer = CInt(dato.Rows(i).Item(4).ToString.Trim)
            Dim area As String = dato.Rows(i).Item(5).ToString.Trim
            Dim ancho As String = dato.Rows(i).Item(6).ToString.Trim
            Dim largo As String = dato.Rows(i).Item(7).ToString.Trim
            Dim Cod_escuela As String = dato.Rows(i).Item(8).ToString.Trim
            Dim tipo_salon As String = dato.Rows(i).Item(9).ToString.Trim
            Dim recursos_codigo As String = dato.Rows(i).Item(12).ToString.Trim





            ingreso.IngresarSalas(sala_codigo, temp_sala, Cod_inventario, Descripcion_sala, capacidad, area, ancho, largo, Cod_escuela, tipo_salon, recursos_codigo)
        Next


    End Function
    Function ingreso_docentes(ByVal dato As DataTable) 'ingresa docente
        For i = 0 To dato.Rows.Count - 1
            Try 'hay que arreglar el dato de esta funcion para que acepte los datos que se aceptan a traves del form 2
                If (Replace(dato.Rows(i).Item(14).ToString, " ", "") <> "") Or (Replace(dato.Rows(i).Item(15).ToString, " ", "") <> "") Then
                    'inserta los docentes a la base de dato
                    Dim ingreso As New GHAU_CapaDatos.BaseDato
                    ingreso.IngresarDocentes(dato.Rows(i).Item(14).ToString, dato.Rows(i).Item(15).ToString, "DOCENTE")
                End If
            Catch
                Dim ingreso As New GHAU_CapaDatos.BaseDato
                ingreso.IngresarDocentes(dato.Rows(i).Item(0).ToString, dato.Rows(i).Item(1).ToString, dato.Rows(i).Item(2).ToString)
            End Try


        Next
    End Function
    Function ingreso_jornadas(ByVal dato As DataTable) 'ingresa docente
        Dim dtDuplicados = dato
        'elimina los Jornadas repetidos
        Dim MyView As DataView = New DataView(dtDuplicados)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(7).ColumnName.ToString)
        For i = 0 To dtSinDuplicados.Rows.Count - 1
            'inserta los campus a la base de dato
            Dim ingreso As New GHAU_CapaDatos.BaseDato
            ingreso.IngresarJornadas(Mid(dtSinDuplicados.Rows(i).Item(0).ToString, 1, 1), dtSinDuplicados.Rows(i).Item(0).ToString)
        Next
    End Function
    Function ingreso_materias(ByVal dato As DataTable) 'ingresa docente

        'elimina los Jornadas repetidos

        For i = 0 To dato.Rows.Count - 1
            'inserta los campus a la base de dato
            Dim ingreso As New GHAU_CapaDatos.BaseDato
            Try
                Dim numero = CInt(dato.Rows(i).Item(5)), curso As String = ""

                If numero < 100 And numero >= 10 Then
                    curso = "0" & dato.Rows(i).Item(5).ToString
                ElseIf numero < 10 Then
                    curso = "00" & dato.Rows(i).Item(5).ToString
                Else
                    curso = dato.Rows(i).Item(5).ToString

                End If
                ingreso.IngresarMaterias(dato.Rows(i).Item(4).ToString & "-" & curso, dato.Rows(i).Item(4).ToString, "")
            Catch
            End Try
        Next
    End Function
    Function ingreso_periodos(ByVal dato As DataTable) 'ingresa docente
        Dim dtDuplicados = dato
        'elimina los Jornadas repetidos
        Dim MyView As DataView = New DataView(dtDuplicados)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(3).ColumnName.ToString)
        For i = 0 To dtSinDuplicados.Rows.Count - 1
            'inserta los campus a la base de dato
            Dim ingreso As New GHAU_CapaDatos.BaseDato
            ingreso.Ingresarperiodos(dtSinDuplicados.Rows(i).Item(0).ToString)
        Next
    End Function
    Function ingreso_Tipo_Actividad(ByVal dato As DataTable) 'sirve para ingresar datos a campus
        Dim dtDuplicados = dato
        'elimina los campus repetidos
        Dim MyView As DataView = New DataView(dtDuplicados)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(18).ColumnName.ToString)
        For i = 0 To dtSinDuplicados.Rows.Count - 1
            'inserta los campus a la base de dato
            Dim ingreso As New GHAU_CapaDatos.BaseDato
            ingreso.IngresarTipoActividad(dtSinDuplicados.Rows(i).Item(0).ToString)
        Next
    End Function
    Function ingreso_Unidad_Academica(ByVal dato As DataTable) 'sirve para ingresar datos a campus
        Dim dtDuplicados = dato
        'elimina los campus repetidos
        Dim MyView As DataView = New DataView(dtDuplicados)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(2).ColumnName.ToString)
        For i = 0 To dtSinDuplicados.Rows.Count - 1
            'inserta los campus a la base de dato
            Dim ingreso As New GHAU_CapaDatos.BaseDato
            ingreso.IngresarUnidadAcademica(dtSinDuplicados.Rows(i).Item(0).ToString)
        Next
    End Function
    Function ingreso_Modalidad(ByVal dato As DataTable) 'sirve para ingresar datos a campus
        Dim dtDuplicados = dato
        'elimina los campus repetidos
        Dim MyView As DataView = New DataView(dtDuplicados)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(19).ColumnName.ToString)
        For i = 0 To dtSinDuplicados.Rows.Count - 1
            'inserta los campus a la base de dato
            Dim ingreso As New GHAU_CapaDatos.BaseDato
            ingreso.IngresarModalidad(dtSinDuplicados.Rows(i).Item(0).ToString)
        Next
    End Function
    Function ingreso_Bloques(ByVal dato As DataTable) As DataTable 'ingresa docente 


        Dim dt As New Modularizacion(dato)
        Dim dtdatosbloque As DataTable = dt.data()
        dt.boque(dtdatosbloque)

        For i = 0 To dtdatosbloque.Rows.Count - 1
            'inserta los campus a la base de dato
            Dim ingreso As New GHAU_CapaDatos.BaseDato
            ingreso.IngresarBloques(dtdatosbloque.Rows(i).Item(0).ToString)
        Next
        Return dtdatosbloque
    End Function

End Class


