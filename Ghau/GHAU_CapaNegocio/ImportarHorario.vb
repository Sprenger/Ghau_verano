Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Public Class ImportarHorario
    Private DATO As String
    Function MaatchHorario(ByRef horariofijos As DataTable, ByVal horariodelDia As DataTable) As DataTable

        Dim dthorariodeldia As DataTable = horariofijos
        For i = 0 To horariodelDia.Rows.Count - 1
            
            Dim temp_arr_horario() As Char = horariodelDia.Rows(i).Item(2).ToCharArray
            For j = 0 To temp_arr_horario.Length - 1
                
                If temp_arr_horario(j).ToString = "1" Then
                    If j >= 14 Then
                        If dthorariodeldia.Rows(j - 3).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1).ToString = "" Then
                            dthorariodeldia.Rows(j - 3).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1) = horariodelDia.Rows(i).Item(1) & " V" & "++ " & horariodelDia.Rows(i).Item(10) & "++" & horariodelDia.Rows(i).Item(11) & "++" & horariodelDia.Rows(i).Item(3) & "++ (" & horariodelDia.Rows(i).Item(5) & ") ++" & horariodelDia.Rows(i).Item(7)
                        Else
                           
                            Dim valor = Split(dthorariodeldia.Rows(j - 3).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1), "++")
                            valor(0) = Replace(valor(0), " ", "")
                            Dim tempNRC = Mid(Replace(valor(0).ToString, " ", ""), 1, valor(0).ToString.Length - 1)
                            Dim tempJornada = Mid(Replace(valor(0).ToString, " ", ""), valor(0).ToString.Length)
                            dthorariodeldia.Rows(j - 3).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1) = tempNRC & "-" & horariodelDia.Rows(i).Item(1) & " " & tempJornada & "++" & valor(1) & "++" & valor(2) & "++" & valor(3) & "++" & valor(4) & "++" & (CInt(valor(5).ToString) + CInt(horariodelDia.Rows(i).Item(7)))

                        End If

                    Else
                        If j >= 11 Then
                            If dthorariodeldia.Rows(j).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1).ToString = "" Then

                                dthorariodeldia.Rows(j).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1) = horariodelDia.Rows(i).Item(1) & " D" & "++ " & horariodelDia.Rows(i).Item(10) & "++" & horariodelDia.Rows(i).Item(11) & "++" & horariodelDia.Rows(i).Item(3) & "++ (" & horariodelDia.Rows(i).Item(5) & ") ++" & horariodelDia.Rows(i).Item(7)
                            Else
                                Dim valor = Split(dthorariodeldia.Rows(j).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1), "++")
                                valor(0) = Replace(valor(0), " ", "")
                                Dim tempNRC = Mid(Replace(valor(0).ToString, " ", ""), 1, valor(0).ToString.Length - 1)
                                Dim tempJornada = Mid(Replace(valor(0).ToString, " ", ""), valor(0).ToString.Length)
                                dthorariodeldia.Rows(j).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1) = tempNRC & "-" & horariodelDia.Rows(i).Item(1) & " " & tempJornada & "++" & valor(1) & "++" & valor(2) & "++" & valor(3) & "++" & valor(4) & "++" & (CInt(valor(5).ToString) + CInt(horariodelDia.Rows(i).Item(7)))

                                Dim c = 1 + 2 + 3

                            End If
                        Else
                            If dthorariodeldia.Rows(j).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1).ToString = "" Then

                                dthorariodeldia.Rows(j).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1) = horariodelDia.Rows(i).Item(1) & "++ " & horariodelDia.Rows(i).Item(10) & "++" & horariodelDia.Rows(i).Item(11) & "++" & horariodelDia.Rows(i).Item(3) & "++ (" & horariodelDia.Rows(i).Item(5) & ") ++" & horariodelDia.Rows(i).Item(7)
                            Else
                                Dim valor = Split(dthorariodeldia.Rows(j).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1), "++")
                                valor(0) = Replace(valor(0), " ", "")
                                dthorariodeldia.Rows(j).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1) = valor(0) & "-" & horariodelDia.Rows(i).Item(1) & "++" & valor(1) & "++" & valor(2) & "++" & valor(3) & "++" & valor(4) & "++" & (CInt(valor(5).ToString) + CInt(horariodelDia.Rows(i).Item(7)))
                                Dim k = dthorariodeldia.Rows(j).Item(CInt(horariodelDia.Rows(i).Item(8).ToString) + 1)

                                Dim c = 1 + 2 + 3


                            End If
                        End If
                    End If
                End If
            Next

            
        Next

        Return dthorariodeldia
    End Function

    Function horario(ByVal dia As String, ByVal fecha As String) As DataTable
        Dim dt As DataTable
        Dim dia_Numero As String = Mid(dia.ToUpper.Trim, 1, 2)
        Select Case dia_Numero
            Case "LU"
                dia = "1"
            Case "MA"
                dia = "2"
            Case "MI"
                dia = "3"
            Case "JU"
                dia = "4"
            Case "VI"
                dia = "5"
            Case "SA"
                dia = "6"
            Case "DO"
                dia = "7"
            Case Else
                dia = "8"

        End Select

        Dim dthorario As New GHAU_CapaDatos.LLenadoGrillaHorario
        dt = dthorario.horario(dia, fecha)

        Return dt
    End Function
    Function Cargar_Horario() As DataTable

        Dim dtsala, dthorario As New GHAU_CapaDatos.LLenadoGrillaHorario
        Dim dtdocente As New GHAU_CapaDatos.BaseDato
        Dim dts, dth, dt, dtd As New DataTable

        dts = dtsala.Sala
        'dth = dthorario.horario(dia, fecha)
        'Dim pntocontrolconsultaselect__dth = "select sala_codigo,nrc, bloque_codigo, Nombre_curso, Tipo_Carga, rut_docente from Horarios where sala_codigo like 'VM%' and dia='" & dia & "' order by sala_codigo"
        dt.Columns.Add(" ", Type.GetType("System.String"))
        dt.Columns.Add("MODULOS", Type.GetType("System.String")) '0


        Dim pntocontrolDT = dt
        For i = 0 To 16
            dt.Rows.Add()
            Select Case i
                Case 0
                    dt.Rows(i).Item(1) = i + 1 & " - 8:30" & " " & "9:15" & " D"
                Case 1
                    dt.Rows(i).Item(1) = i + 1 & " - 9:25" & " " & "10:10" & " D"
                Case 2
                    dt.Rows(i).Item(1) = i + 1 & " - 10:20" & " " & "11:05" & " D"
                Case 3
                    dt.Rows(i).Item(1) = i + 1 & " - 11:15" & " " & "12:00" & " D"
                Case 4
                    dt.Rows(i).Item(1) = i + 1 & " - 12:10" & " " & "12:55" & " D"
                Case 5
                    dt.Rows(i).Item(1) = i + 1 & " - 13:05" & " " & "13:50" & " D"
                Case 6
                    dt.Rows(i).Item(1) = i + 1 & " - 14:00" & " " & "14:45" & " D"
                Case 7
                    dt.Rows(i).Item(1) = i + 1 & " - 14:55" & " " & "15:40" & " D"
                Case 8
                    dt.Rows(i).Item(1) = i + 1 & " - 15:50" & " " & "16:35" & " D"
                Case 9
                    dt.Rows(i).Item(1) = i + 1 & " - 16:45" & " " & "17:30" & " D"
                Case 10
                    dt.Rows(i).Item(1) = i + 1 & " - 1740" & " " & "18:25" & " D"
                Case 11
                    dt.Rows(i).Item(1) = i + 1 & " - 18:35" & " " & "19:20" & " D"
                    dt.Rows(i).Item(0) = i - 10 & " - 19:00" & " " & "19:45" & " V"
                Case 12
                    dt.Rows(i).Item(1) = i + 1 & " - 19:30" & " " & "20:15" & " D"
                    dt.Rows(i).Item(0) = i - 10 & " - 19:46" & " " & "20:30" & " V"
                Case 13
                    dt.Rows(i).Item(1) = i + 1 & " - 20:25" & " " & "21:10" & " D"
                    dt.Rows(i).Item(0) = i - 10 & " - 20:40" & " " & "21:25" & " V"
                Case 14
                    dt.Rows(i).Item(0) = i - 10 & " - 21:26" & " " & "22:10" & " V"
                Case 15
                    dt.Rows(i).Item(0) = i - 10 & " - 22:20" & " " & "23:05" & " V"

                Case 16
                    dt.Rows(i).Item(0) = i - 10 & " - 23:06" & " " & "23:50" & " V"

            End Select

        Next
        For i = 0 To dts.Rows.Count - 1
            dt.Columns.Add(dts.Rows(i).Item(0).ToString & vbNewLine & "CAP: " & dts.Rows(i).Item(1).ToString & vbNewLine, Type.GetType("System.String")) '0

        Next

        'punto de control
        Return dt
    End Function

    Sub IngresoSala(ByVal dato As DataTable)
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
        dt.Columns(3).ColumnName = "Estado"
        dt.Columns(1).ColumnName = "codigo_sala"
        dt.Columns(0).ColumnName = "Sede"
        Dim dataView As New DataView(dt)
        dataView.Sort = dt.Columns(0).ColumnName & " asc, " & dt.Columns(1).ColumnName & " asc" 'dt.Columns(0).ColumnName & " asc, " & dt.Columns(3).ColumnName & " asc, " & dt.Columns(1).ColumnName & " asc"
        Dim dataTable As DataTable = dataView.ToTable()
        dataTable.Columns.Add("Ubicacion", Type.GetType("System.String"))
        Dim ubicacion As Integer = 1
        Dim sede As String
        For i = 0 To dataTable.Rows.Count - 1
            If i = 0 Then 'el primero en pasar se asigna la ubicacion 1 y la
1:              sede = Replace(dataTable.Rows(i).Item(0), " ", "")
                If InStr(Replace(dataTable.Rows(i).Item(3).ToString.ToUpper, " ", ""), "NODISPONIBLE") > 0 Then
                    dataTable.Rows(i).Item(14) = 0
                Else
                    ubicacion = 1
                    dataTable.Rows(i).Item(14) = ubicacion
                    ubicacion = ubicacion + 1
                End If
            Else
                If InStr(Replace(dataTable.Rows(i).Item(0), " ", ""), sede) > 0 Then
                    If InStr(Replace(dataTable.Rows(i).Item(3).ToString.ToUpper, " ", ""), "NODISPONIBLE") > 0 Then
                        dataTable.Rows(i).Item(14) = 0
                    Else
                        dataTable.Rows(i).Item(14) = ubicacion
                        ubicacion = ubicacion + 1
                    End If
                Else
                    GoTo 1
                End If

            End If

        Next

        ingreso_recursos(dt)
        ingreso_salas(dataTable)
        Ingreso_edificios(dt)
        Ingreso_Salas_Edificios(dt)


    End Sub
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

    Public _nombreservidor_, _nombreusuario_, _pass_ As String
    Public Function Parametros() As String
        Dim fichero = Environment.GetEnvironmentVariable("windir") 'Busca en que disco esta a carpeta de windows

        fichero = fichero & "/ghau/Coneccion.bat"
        Dim texto As String
        Dim sr As New System.IO.StreamReader(fichero) 'lee texto coneccion.bat
        texto = sr.ReadToEnd()
        sr.Close()
        Dim parametro() As String = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
        _nombreservidor_ = parametro(0)
        _nombreusuario_ = parametro(1)
        _pass_ = parametro(2)
        Return _nombreservidor_ & "++" & _nombreusuario_ & "++" & _pass_
    End Function
    Function Ingreso(ByVal dato As DataTable) As DataTable
        'Dim coneccion = Parametros()

        Dim dtfijo As New DataTable
        dtfijo = dato.Copy
        ingreso_periodos(dtfijo, Parametros())
        Dim dt As DataTable = ordenar_excel(dtfijo)
        ingreso_horario(dt)

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
    Function ordenar_excel(ByVal dato As DataTable) As DataTable
        Dim dterrores As New DataTable
        '0
        ' dato = dterrores
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
        dtHorario.Columns.Add("Nombre_docente", Type.GetType("System.String")) '30
        dtHorario.Columns.Add("U_q_paga", Type.GetType("System.String")) 'U_que_paga
        dterrores = dato.Clone

        dterrores.Columns.Add("TipoError", Type.GetType("System.String"))

        For i = 0 To dato.Rows.Count - 1
            If dato.Rows(i).Item(20).ToString = " " Then
                dato.Rows(i).Item(20) = ".OT 0830 - 1920 "
            End If
            If dato.Rows(i).Item(24).ToString = " " Or dato.Rows(i).Item(24).ToString.Length < 2 Then
                dato.Rows(i).Item(24) = "EXTERNA"
            End If

            If dato.Rows(i).Item(14).ToString = " " Then
                dato.Rows(i).Item(24) = " "
            End If

            'VM-EXTERNA
            dtHorario.Rows.Add()
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22) = "00000000000000000000" 'lunes
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23) = "00000000000000000000" 'martes
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24) = "00000000000000000000" 'miercoles
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25) = "00000000000000000000" 'jueve
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26) = "00000000000000000000" 'viernes
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27) = "00000000000000000000" 'sab
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28) = "00000000000000000000" 'dom
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29) = "00000000000000000000" 'otro
            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(30) = dato.Rows(i).Item(15).ToString.ToUpper
            Dim arr_sala() = Split(Replace(dato.Rows(i).Item(24).ToString, " ", ""), "/")
            Dim arr_edificio() = Split(Replace(dato.Rows(i).Item(23).ToString, " ", ""), "/")
            If Mid(Replace(dato.Rows(i).Item(20).ToString, " ", ""), 1, 1) = "/" Then
                dato.Rows(i).Item(20) = Mid(Replace(dato.Rows(i).Item(20).ToString, " ", ""), 2)
            End If

            Dim arr_dia = Split(dato.Rows(i).Item(20).ToString, "/")
            If arr_dia(0).Length < 6 Then
                dato.Rows(i).Item(20) = "Vacio"
                arr_dia(0) = "Vacio"
            End If
            'If DBNull.Value.Equals(dato.Rows(i).Item(20)) Then
            'For x = 0 To dato.Columns.Count - 1
            If DBNull.Value.Equals(dato.Rows(i).Item(19)) Then
                dato.Rows(i).Item(19) = " "
            End If
            If DBNull.Value.Equals(dato.Rows(i).Item(3)) Or DBNull.Value.Equals(dato.Rows(i).Item(4)) Or DBNull.Value.Equals(dato.Rows(i).Item(8)) Or DBNull.Value.Equals(dato.Rows(i).Item(14)) Or DBNull.Value.Equals(dato.Rows(i).Item(18)) Or DBNull.Value.Equals(dato.Rows(i).Item(19)) Or DBNull.Value.Equals(dato.Rows(i).Item(20)) Then
                Dim ColumnaVacia As String = " "
                If DBNull.Value.Equals(dato.Rows(i).Item(3)) Then
                    ColumnaVacia = "PERIODO"
                End If
                If DBNull.Value.Equals(dato.Rows(i).Item(4)) Then
                    ColumnaVacia = ColumnaVacia & " " & "MATERIA"
                End If

                If DBNull.Value.Equals(dato.Rows(i).Item(8)) Then
                    ColumnaVacia = ColumnaVacia & " " & "NRC"
                End If
                If DBNull.Value.Equals(dato.Rows(i).Item(14)) Then
                    'ColumnaVacia = ColumnaVacia & " " & "RUT DOCENTE"
                    dato.Rows(i).Item(14) = "0000000000"
                    GoTo 3
                End If
                If DBNull.Value.Equals(dato.Rows(i).Item(18)) Then
                    ColumnaVacia = ColumnaVacia & " " & "TIPO ACTIVIDAD"
                End If
                If DBNull.Value.Equals(dato.Rows(i).Item(19)) Then
                    ColumnaVacia = ColumnaVacia & " " & "MODALIDAD"
                End If
                If DBNull.Value.Equals(dato.Rows(i).Item(20)) Then
                    If InStr(Replace(dato.Rows(i).Item(24).ToString, " ", ""), "EX") > 0 Then
                        dato.Rows(i).Item(20) = ".OT 0000-0000"
                        GoTo 3
                    Else
                        ColumnaVacia = ColumnaVacia & " " & "HORARIO"

                    End If
                End If



                dterrores.Rows.Add()
                For columnas = 0 To dato.Columns.Count - 1
                    dterrores.Rows(dterrores.Rows.Count - 1).Item(columnas) = dato.Rows(i).Item(columnas)
                Next
                dterrores.Rows(dterrores.Rows.Count - 1).Item(dterrores.Columns.Count - 1) = ColumnaVacia
                GoTo 1
            End If
            'Next

            'Dim iiii = CInt(dato.Rows(i).Item(8))
3:
            If InStr(dato.Rows(i).Item(24).ToString, "/") > 0 Then 'osea es una sala sal606/sal608

                For j = 0 To arr_dia.Length - 1
                    ' Dim largo As Integer = 

                    If dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7).ToString = arr_edificio(j) & "-" & arr_sala(j) Or dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7).ToString = "" Then
                        Dim dd = dato.Rows(i).Item(20).ToString
                        For x = 0 To CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)
                            Dim puntocontrolfinalFor = CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)
                            Dim temp_horario = Mid(Replace(arr_dia(j).ToString, " ", ""), ((12 * x) + 1), 12)
                            Dim temp_bloque = Modularizacion(Mid(temp_horario, 4, 4), Mid(temp_horario, 9, 4), Replace(dato.Rows(i).Item(7).ToString, " ", "")) 'obtengo el bloque
                            If temp_bloque = "" Or temp_bloque = "FALLA" Then
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
                            Try
                                For k = CInt(Mid(temp_bloque, 1, 2)) - 1 To CInt(Mid(temp_bloque, 4)) - 1
                                    temp_arr_horario(k) = "1"
                                Next
                            Catch ex As Exception
                                dtHorario.Rows.RemoveAt(dtHorario.Rows.Count - 1)

                                dterrores.Rows.Add()
                                For columnas = 0 To dato.Columns.Count - 1
                                    dterrores.Rows(dterrores.Rows.Count - 1).Item(columnas) = dato.Rows(i).Item(columnas)
                                Next
                                dterrores.Rows(dterrores.Rows.Count - 1).Item(dterrores.Columns.Count - 1) = "revisar columna 'horario'"
                                GoTo 1

                            End Try
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

                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(31) = dato.Rows(i).Item(30).ToString

                            Dim numero As String = ""
                            If dato.Rows(i).Item(5).ToString.Length = 2 Then
                                numero = "0" & dato.Rows(i).Item(5).ToString
                            ElseIf dato.Rows(i).Item(5).ToString.Length >= 3 Then
                                numero = dato.Rows(i).Item(5).ToString
                            ElseIf dato.Rows(i).Item(5).ToString.Length = 1 Then

                                numero = "00" & dato.Rows(i).Item(5).ToString

                            End If


                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(9) = dato.Rows(i).Item(4).ToString & numero
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(10) = dato.Rows(i).Item(3).ToString
                            Dim Isra = dato.Rows(i).Item(18).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(11) = dato.Rows(i).Item(18).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(12) = dato.Rows(i).Item(1).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(13) = dato.Rows(i).Item(14).ToString
                            Dim MODA = dato.Rows(i).Item(19).ToString
                            Dim NRC = dato.Rows(i).Item(8).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(14) = dato.Rows(i).Item(19).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(15) = dato.Rows(i).Item(2).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(16) = dato.Rows(i).Item(33).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(17) = dato.Rows(i).Item(34).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(18) = dato.Rows(i).Item(16).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(19) = "D"
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(20) = dato.Rows(i).Item(26).ToString
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(21) = dato.Rows(i).Item(29).ToString






                        Next 'termino de recorrer arr_dia

                    Else
                        dtHorario.Rows.Add()
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(22) = "00000000000000000000" 'lunes
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(23) = "00000000000000000000" 'martes
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(24) = "00000000000000000000" 'miercoles
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(25) = "00000000000000000000" 'jueve
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(26) = "00000000000000000000" 'viernes
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(27) = "00000000000000000000" 'sab
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28) = "00000000000000000000" 'dom
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(29) = "00000000000000000000" 'otro
                        For x = 0 To CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)

                            ' Dim puntocontrolfinalFor = CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)
                            Dim temp_horario = Mid(Replace(arr_dia(j).ToString, " ", ""), ((12 * x) + 1), 12)
                            Dim temp_bloque = Modularizacion(Mid(temp_horario, 4, 4), Mid(temp_horario, 9, 4), Replace(dato.Rows(i).Item(7).ToString, " ", "")) 'obtengo el bloque
                            If temp_bloque = "" Or temp_bloque = "FALLA" Then
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
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7) = arr_edificio(j) & "-" & arr_sala(j)
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(2) = dato.Rows(i).Item(8).ToString

                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(11) = dato.Rows(i).Item(18).ToString



                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(31) = dato.Rows(i).Item(30).ToString

                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(0) = DateTime.Now() '.ToShortDateString()
                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(1) = dato.Rows(i).Item(21).ToString
                            'Dim op = dato.Rows(i).Item(21).ToString

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

                            dtHorario.Rows(dtHorario.Rows.Count - 1).Item(9) = dato.Rows(i).Item(4).ToString & numero

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
                    'Dim ASD = dato.Rows(i).Item(20)
                    For j = 0 To CInt((Replace(dato.Rows(i).Item(20).ToString, " ", "").Length / 12) - 1)
                        Dim temp_horario = Mid(Replace(dato.Rows(i).Item(20).ToString, " ", ""), ((j * 12) + 1), 12)
                        ' Dim puntocontrolfinalFor = CInt(Replace(arr_dia(j), " ", "").Length / 12 - 1)
                        Dim NOMBRE = dato.Columns(7).ColumnName
                        Dim NRC = dato.Rows(i).Item(8).ToString
                        Dim jor = dato.Rows(i).Item(7).ToString

                        Dim temp_bloque = Modularizacion(Mid(temp_horario, 4, 4), Mid(temp_horario, 9, 4), Replace(dato.Rows(i).Item(7).ToString, " ", "")) 'obtengo el bloque
                        If temp_bloque = "" Or temp_bloque = "FALLA" Then
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
                        'Dim isra = dato.Rows(i).Item(8).ToString



                        Dim temp_arr_horario() As Char = modulo.ToCharArray
                        Dim bloque As String = ""
                        Try
                            'If temp_bloque = "00-00" Then

                            '    bloque = modulo
                            'Else
                            For k = CInt(Mid(temp_bloque, 1, 2)) - 1 To CInt(Mid(temp_bloque, 4)) - 1
                                temp_arr_horario(k) = "1"
                            Next


                            For k = 0 To temp_arr_horario.Length - 1
                                bloque = bloque & temp_arr_horario(k)
                            Next
                            'End If
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
                        Catch ex As Exception
                            'dtHorario.Rows.RemoveAt(dtHorario.Rows.Count - 1)
                            Dim a = 1 + 2
                        End Try

                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(7) = dato.Rows(i).Item(23).ToString & "-" & dato.Rows(i).Item(24).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(2) = dato.Rows(i).Item(8).ToString
                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(11) = dato.Rows(i).Item(18).ToString




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

                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(9) = dato.Rows(i).Item(4).ToString & codigo
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


                        dtHorario.Rows(dtHorario.Rows.Count - 1).Item(31) = dato.Rows(i).Item(30).ToString

                    Next

                    Dim horario = ""
                Else


                    Dim temp_horario = Mid(Replace(dato.Rows(i).Item(20).ToString, " ", ""), (1), 12)
                    Dim temp_dia = Mid(temp_horario.ToUpper, 1, 3) 'obtengo el dia
                    Dim nrc = dato.Rows(i).Item(8).ToString
                    Dim bloque = ""

                    If temp_horario.Length - 1 = -1 Or dato.Rows(i).Item(20).ToString.Length < 11 Then
                        bloque = dtHorario.Rows(dtHorario.Rows.Count - 1).Item(28)
                        If temp_dia = Nothing Then
                            temp_dia = "otro"
                        End If
                    Else
                        Dim temp_bloque = Modularizacion(Mid(temp_horario, 4, 4), Mid(temp_horario, 9, 4), Replace(dato.Rows(i).Item(7).ToString, " ", "")) 'obtengo el bloque
                        If temp_bloque = "" Or temp_bloque = "FALLA" Then
                            dtHorario.Rows.RemoveAt(dtHorario.Rows.Count - 1)

                            dterrores.Rows.Add()
                            For columnas = 0 To dato.Columns.Count - 1
                                dterrores.Rows(dterrores.Rows.Count - 1).Item(columnas) = dato.Rows(i).Item(columnas)
                            Next
                            dterrores.Rows(dterrores.Rows.Count - 1).Item(dterrores.Columns.Count - 1) = "revisar columna 'horario'"
                            GoTo 1
                        End If
                        ' Dim temp_dia = Mid(temp_horario.ToUpper, 1, 3) 'obtengo el dia
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
                        'Dim bloque As String = ""
                        For k = 0 To temp_arr_horario.Length - 1
                            bloque = bloque & temp_arr_horario(k)
                        Next
                    End If
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



                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(0) = DateTime.Now() '.ToShortDateString()
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(1) = dato.Rows(i).Item(21).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(3) = dato.Rows(i).Item(6).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(4) = dato.Rows(i).Item(9).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(5) = dato.Rows(i).Item(10).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(6) = dato.Rows(i).Item(11).ToString
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(8) = dato.Rows(i).Item(7).ToString
                    Dim numero As String = ""

                    If dato.Rows(i).Item(5).ToString = "" Then
                        numero = "000"
                    Else
                        If CInt(dato.Rows(i).Item(5).ToString) >= 10 And CInt(dato.Rows(i).Item(5).ToString) < 100 Then
                            numero = "0" & dato.Rows(i).Item(5).ToString
                        ElseIf CInt(dato.Rows(i).Item(5).ToString) < 10 Then
                            numero = "00" & dato.Rows(i).Item(5).ToString
                        ElseIf CInt(dato.Rows(i).Item(5).ToString) >= 100 Then
                            numero = dato.Rows(i).Item(5).ToString

                        End If
                    End If
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(9) = dato.Rows(i).Item(4).ToString & numero
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(10) = dato.Rows(i).Item(3).ToString
                    'Dim tempnrc = dato.Rows(i).Item(8).ToString
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
                    dtHorario.Rows(dtHorario.Rows.Count - 1).Item(31) = dato.Rows(i).Item(30).ToString

                End If

            End If

1:

        Next

        Dim dtlimpiado As DataTable
        dtlimpiado = dtHorario.Copy
        'dtlimpiado.Rows.Clear()
        'For x = 0 To dtHorario.Rows.Count - 1
        '    For y = x + 1 To dtlimpiado.Rows.Count - 1
        '        If x <> y Then
        '            Dim NRC_DTHORARIO = Replace(dtHorario.Rows(x).Item(2).ToString, " ", "")
        '            Dim NRC_DTLimpiado = Replace(dtlimpiado.Rows(y).Item(2).ToString, " ", "")
        '            Dim sala_dthorario = Replace(dtHorario.Rows(x).Item(7).ToString, " ", "")
        '            Dim sala_dtLimpiado = Replace(dtlimpiado.Rows(y).Item(7).ToString, " ", "")
        '            Dim tipoact_horario = Replace(dtHorario.Rows(x).Item(11).ToString, " ", "")
        '            Dim tipoact_limpiado = Replace(dtlimpiado.Rows(y).Item(11).ToString, " ", "")
        '            Dim o = dtHorario
        '            If NRC_DTHORARIO = NRC_DTLimpiado Then
        '                If sala_dthorario = sala_dtLimpiado Then
        '                    If tipoact_horario = tipoact_limpiado Then
        '                        For j = 22 To 29
        '                            Dim temp_arr_horarioLimpio() As Char = dtlimpiado.Rows(y).Item(j).ToString.ToCharArray
        '                            Dim temp_arr_horario() As Char = dtHorario.Rows(x).Item(j).ToString.ToCharArray
        '                            For jj = 0 To temp_arr_horario.Length - 1
        '                                If temp_arr_horario(jj).ToString = "1" Then
        '                                    temp_arr_horarioLimpio(jj) = "1"
        '                                End If
        '                            Next
        '                            Dim modulofinal As String = ""
        '                            For jj = 0 To temp_arr_horarioLimpio.Length - 1
        '                                modulofinal = modulofinal & temp_arr_horarioLimpio(jj)
        '                            Next
        '                            dtHorario.Rows(x).Item(j) = modulofinal
        '                        Next
        '                        For j = 0 To dtHorario.Columns.Count - 1
        '                            dtHorario.Rows(y).Item(j) = ""
        '                        Next

        '                    End If
        '                End If
        '            Else
        '                Exit For
        '            End If
        '        Else
        '        End If
        '    Next
        'Next

        Dim dataView As New DataView(dtHorario)
        dataView.Sort = dtHorario.Columns(8).ColumnName & " desc"
        Dim dataTable As DataTable = dataView.ToTable()
        'Dim array(0) As String
        'For I = 0 To dataTable.Rows.Count - 1
        '    If dataTable.Rows(I).Item(0).ToString = "" Then
        '        array(array.Length - 1) = I
        '        ReDim Preserve array(UBound(array) + 1)

        '    Else
        '        ReDim Preserve array(UBound(array) - 1)
        '        Exit For
        '    End If
        'Next
2:
        'If dataTable.Rows(dataTable.Rows.Count - 1).Item(2).ToString = "" Then
        '    dataTable.Rows(dataTable.Rows.Count - 1).Delete()
        '    GoTo 2
        'End If


        If dterrores.Rows.Count > 0 Then
            ingreso_Error_Excel(dterrores)
        End If

        Return dataTable
    End Function
    Function ingreso_Error_Excel(ByVal dato As DataTable)
        Dim ingreso As New GHAU_CapaDatos.BaseDato
        'Dim variable As String = ""
      
        For i = 0 To dato.Rows.Count - 1
            ingreso.IngresarERROR_EXCEL(dato.Rows(i).Item(0).ToString, dato.Rows(i).Item(1).ToString, dato.Rows(i).Item(2).ToString, dato.Rows(i).Item(3).ToString, dato.Rows(i).Item(4).ToString, dato.Rows(i).Item(5).ToString, dato.Rows(i).Item(6).ToString, dato.Rows(i).Item(7).ToString, dato.Rows(i).Item(8).ToString, dato.Rows(i).Item(9).ToString, dato.Rows(i).Item(10).ToString, dato.Rows(i).Item(11).ToString, dato.Rows(i).Item(12).ToString, dato.Rows(i).Item(13).ToString, dato.Rows(i).Item(14).ToString, dato.Rows(i).Item(15).ToString, dato.Rows(i).Item(16).ToString, dato.Rows(i).Item(17).ToString, dato.Rows(i).Item(18).ToString, dato.Rows(i).Item(19).ToString, dato.Rows(i).Item(20).ToString, dato.Rows(i).Item(21).ToString, dato.Rows(i).Item(22).ToString, dato.Rows(i).Item(23).ToString, dato.Rows(i).Item(24).ToString, dato.Rows(i).Item(25).ToString, dato.Rows(i).Item(26).ToString, dato.Rows(i).Item(27).ToString, dato.Rows(i).Item(28).ToString, dato.Rows(i).Item(29).ToString, dato.Rows(i).Item(30).ToString, dato.Rows(i).Item(31).ToString, dato.Rows(i).Item(32).ToString, dato.Rows(i).Item(33).ToString, dato.Rows(i).Item(34).ToString, dato.Rows(i).Item(35).ToString)
        Next

    End Function
    Public contador As Integer = 0
    Sub ingreso_horario(ByVal dato As DataTable)

        Dim datossinDuplicar As DataTable = dato
        'Dim datossinDuplicar = Limpieza(dtHorario)

        Dim ingreso As New GHAU_CapaDatos.BaseDato
        'Dim nuedosindopicar = Limpieza(datossinDuplicar)
        For i = datossinDuplicar.Rows.Count - 1 To 0 Step -1         'For i = 0 To datossinDuplicar.Rows.Count - 1

            'inserta los campus a la base de dat
            If datossinDuplicar.Rows(i).Item(0).ToString <> "" Then

                Dim fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, _
                curso_materia, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, _
                Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso, Periodo, U_Q_Paga As String

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
                Dim docente = datossinDuplicar.Rows(i).Item(30).ToString
                U_Q_Paga = datossinDuplicar.Rows(i).Item(31).ToString

                If InStr(datossinDuplicar.Rows(i).Item(22), 1) > 0 Then
                    dia = "1"
                    bloque_codigo = datossinDuplicar.Rows(i).Item(22).ToString
                    ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso, docente, U_Q_Paga)
                End If
                If InStr(datossinDuplicar.Rows(i).Item(23), 1) > 0 Then
                    dia = "2"
                    bloque_codigo = datossinDuplicar.Rows(i).Item(23).ToString
                    ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso, docente, U_Q_Paga)
                End If
                If InStr(datossinDuplicar.Rows(i).Item(24), 1) > 0 Then
                    dia = "3"
                    bloque_codigo = datossinDuplicar.Rows(i).Item(24).ToString
                    ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso, docente, U_Q_Paga)
                End If
                If InStr(datossinDuplicar.Rows(i).Item(25), 1) > 0 Then
                    dia = "4"
                    bloque_codigo = datossinDuplicar.Rows(i).Item(25).ToString
                    ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso, docente, U_Q_Paga)

                End If
                If InStr(datossinDuplicar.Rows(i).Item(26), 1) > 0 Then
                    dia = "5"
                    bloque_codigo = datossinDuplicar.Rows(i).Item(26).ToString
                    ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso, docente, U_Q_Paga)
                End If
                If InStr(datossinDuplicar.Rows(i).Item(27), 1) > 0 Then
                    dia = "6"
                    bloque_codigo = datossinDuplicar.Rows(i).Item(27).ToString
                    ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso, docente, U_Q_Paga)
                End If
                If InStr(datossinDuplicar.Rows(i).Item(28), 1) > 0 Then
                    dia = "7"
                    bloque_codigo = datossinDuplicar.Rows(i).Item(28).ToString
                    ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso, docente, U_Q_Paga)
                End If
                If InStr(datossinDuplicar.Rows(i).Item(29), 1) > 0 Then
                    dia = "8"
                    bloque_codigo = datossinDuplicar.Rows(i).Item(29).ToString
                    ingreso.IngresarHorario(fecha_carga, dia, cantidad, nrc, seccion, lista_cruzada, nrc_ligado, id_listas_cruzadas, sala_codigo, jornada_codigo, curso_materia, Periodo, tipo_actividad, campus_codigo, bloque_codigo, Rut_docente, modalidad_codigo, unidad_academica_codigo, Fecha_inicio, Fecha_fin, Nombre_curso, Tipo_Carga, Programa, Nivel_Curso, docente, U_Q_Paga)
                End If



            End If

            datossinDuplicar.Rows(i).Delete()
        Next

        'Return dterrores
    End Sub
    Function Limpieza(ByVal dt As DataTable) As DataTable

        Dim dtlimpiado As DataTable
        dtlimpiado = dt.Copy
        'dtlimpiado.Rows.Clear()
        For x = 0 To dt.Rows.Count - 1
            For y = x + 1 To dtlimpiado.Rows.Count - 1
                If x <> y Then
                    Dim NRC_DTHORARIO = Replace(dt.Rows(x).Item(2).ToString, " ", "")
                    Dim NRC_DTLimpiado = Replace(dtlimpiado.Rows(y).Item(2).ToString, " ", "")
                    Dim sala_dthorario = Replace(dt.Rows(x).Item(7).ToString, " ", "")
                    Dim sala_dtLimpiado = Replace(dtlimpiado.Rows(y).Item(7).ToString, " ", "")
                    Dim tipoact_horario = Replace(dt.Rows(x).Item(18).ToString, " ", "")
                    Dim tipoact_limpiado = Replace(dt.Rows(y).Item(18).ToString, " ", "")

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
                    Else
                        Exit For
                    End If

                Else

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
    Function Modularizacion(ByVal inicio As String, ByVal fin As String, ByVal Jornada As String) As String
        Dim flag As Boolean = True
        Dim modulo As String = ""
        If inicio.ToString = "" Or fin.ToString = "" Then
            If inicio.ToString = "" Then
                inicio = fin
            Else
                fin = inicio
            End If
        End If
        If Jornada Is Nothing Then
            Jornada = "DIURNO"
        End If
        If Jornada.ToString.ToUpper = "DIURNO" Then
2:
            If CInt(inicio) < 1 Then
                modulo = "01-"
            ElseIf 1 < CInt(inicio) And CInt(inicio) <= 830 Then
                modulo = "01-"
            ElseIf 830 < CInt(inicio) And CInt(inicio) <= 925 Then 'inicio = "0925" Then
                modulo = "02-"
            ElseIf 925 < CInt(inicio) And CInt(inicio) <= 1020 Then 'inicio = "1020" Then
                modulo = "03-"
            ElseIf 1020 < CInt(inicio) And CInt(inicio) <= 1115 Then 'inicio = "1115" Then
                modulo = "04-"
            ElseIf 1115 < CInt(inicio) And CInt(inicio) <= 1210 Then 'inicio = "1210" Then
                modulo = "05-"
            ElseIf 1210 < CInt(inicio) And CInt(inicio) <= 1305 Then ' inicio = "1305" Then
                modulo = "06-"
            ElseIf 1305 < CInt(inicio) And CInt(inicio) <= 1400 Then 'inicio = "1400" Then
                modulo = "07-"
            ElseIf 1400 < CInt(inicio) And CInt(inicio) <= 1455 Then 'inicio = "1455" Then
                modulo = "08-"
            ElseIf 1455 < CInt(inicio) And CInt(inicio) <= 1550 Then 'inicio = "1550" Then
                modulo = "09-"
            ElseIf 1550 < CInt(inicio) And CInt(inicio) <= 1645 Then 'inicio = "1645" Then
                modulo = "10-"
            ElseIf 1645 < CInt(inicio) And CInt(inicio) <= 1740 Then ' inicio = "1740" Then
                modulo = "11-"
            ElseIf 1740 < CInt(inicio) And CInt(inicio) <= 1835 Then 'inicio = "1835" Then
                modulo = "12-"
            ElseIf 1835 < CInt(inicio) And CInt(inicio) <= 1930 Then 'inicio = "19 30" Then
                modulo = "13-"
            ElseIf 1930 < CInt(inicio) And CInt(inicio) <= 2025 Then ' inicio = "2025" Then
                modulo = "14-"
            ElseIf 2025 < CInt(inicio) Then
                GoTo 1
            End If


            If 0 < CInt(fin) And CInt(fin) <= 915 Then 'fin = "0915" Then
                modulo = modulo & "01"
            ElseIf CInt(fin) < 1 Then
                modulo = modulo & "20"
            ElseIf 915 < CInt(fin) And CInt(fin) <= 1010 Then 'fin = "1010" Then
                modulo = modulo & "02"
            ElseIf 1010 < CInt(fin) And CInt(fin) <= 1105 Then 'fin = "1105" Then
                modulo = modulo & "03"
            ElseIf 1105 < CInt(fin) And CInt(fin) <= 1200 Then 'fin = "1200" Then
                modulo = modulo & "04"
            ElseIf 1200 < CInt(fin) And CInt(fin) <= 1255 Then 'fin = "1255" Then
                modulo = modulo & "05"
            ElseIf 1255 < CInt(fin) And CInt(fin) <= 1350 Then 'fin = "1350" Then
                modulo = modulo & "06"
            ElseIf 1350 < CInt(fin) And CInt(fin) <= 1445 Then 'fin = "1445" Then
                modulo = modulo & "07"
            ElseIf 1445 < CInt(fin) And CInt(fin) <= 1540 Then ' fin = "1540" Then
                modulo = modulo & "08"
            ElseIf 1540 < CInt(fin) And CInt(fin) <= 1635 Then 'fin = "1635" Then
                modulo = modulo & "09"
            ElseIf 1635 < CInt(fin) And CInt(fin) <= 1730 Then  'fin = "1730" Then
                modulo = modulo & "10"
            ElseIf 1730 < CInt(fin) And CInt(fin) <= 1825 Then 'fin = "1825" Then
                modulo = modulo & "11"
            ElseIf 1825 < CInt(fin) And CInt(fin) <= 1920 Then 'fin = "1920" Then
                modulo = modulo & "12"
            ElseIf 1920 < CInt(fin) And CInt(fin) <= 2015 Then 'fin = "2015" Then
                modulo = modulo & "13"
            ElseIf 2015 < CInt(fin) And CInt(fin) <= 2110 Then 'fin = "2110" Then
                modulo = modulo & "14"
            ElseIf 2110 < CInt(fin) Then
                GoTo 1
            End If

        End If

        If Jornada = "VESPERTINO" Then
1:

            If 1800 < CInt(inicio) And CInt(inicio) <= 1900 Then 'inicio = "1900" Then
                modulo = "15-"
            ElseIf 1900 < CInt(inicio) And CInt(inicio) <= 1946 Then 'inicio = "1946" Then
                modulo = "16-"
            ElseIf 1946 < CInt(inicio) And CInt(inicio) <= 2040 Then ' inicio = "2040" Then
                modulo = "17-"
            ElseIf 2040 < CInt(inicio) And CInt(inicio) <= 2126 Then 'inicio = "2126" Then
                modulo = "18-"
            ElseIf 2126 < CInt(inicio) And CInt(inicio) <= 2220 Then 'inicio = "2220" Then
                modulo = "19-"
            ElseIf 2220 < CInt(inicio) And CInt(inicio) <= 2306 Then 'inicio = "2306" Then
                modulo = "20-"
                'Else
                '    modulo = "Error"
                '    GoTo 1
            Else
                If flag Then 'para que no se quede dando vueltas infinitas
                    flag = False
                    GoTo 2
                End If
            End If


            If 1845 < CInt(fin) And CInt(fin) <= 1945 Then 'fin = "1945" Then
                modulo = modulo & "15"

            ElseIf 1945 < CInt(fin) And CInt(fin) <= 2030 Then ' fin = "2030" Then
                modulo = modulo & "16"
            ElseIf 2030 < CInt(fin) And CInt(fin) <= 2125 Then 'fin = "2125" Then
                modulo = modulo & "17"
            ElseIf 2125 < CInt(fin) And CInt(fin) <= 2210 Then 'fin = "2210" Then
                modulo = modulo & "18"
            ElseIf 2210 < CInt(fin) And CInt(fin) <= 2305 Then 'fin = "2305" Then
                modulo = modulo & "19"
            ElseIf 2305 < CInt(fin) And CInt(fin) <= 2350 Then 'fin = "2350" Then
                modulo = modulo & "20"
            Else
                If flag Then 'para que no se quede dando vueltas infinitas
                    flag = False
                    GoTo 2
                End If
                'Else
                '    modulo = "Error"
            End If
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

    Sub ingreso_Eventos(ByVal fechainicio As String, ByVal fechafin As String, ByVal dia As String, ByVal NombreActividad As String, ByVal Responsable As String, ByVal sala As String, ByVal Jornada As String, ByVal modulo As String)

        Dim ingreso As New GHAU_CapaDatos.Ingresar
        ingreso.IngresarEvento(fechainicio, fechafin, dia, NombreActividad, Responsable, sala, Parametros(), Jornada, modulo)

    End Sub
    Function Count_eventos()
        Dim ingreso As New GHAU_CapaDatos.Ingresar

        Return ingreso.eventoscount(Parametros)
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
            Dim ubicacion As Integer = dato.Rows(i).Item(14).ToString.Trim




            ingreso.IngresarSalas(sala_codigo, temp_sala, Cod_inventario, Descripcion_sala, capacidad, area, ancho, largo, Cod_escuela, tipo_salon, recursos_codigo, ubicacion)
        Next


    End Function
    Function ingreso_docentes(ByVal dato As DataTable) 'ingresa docente

        For i = 0 To dato.Rows.Count - 1
            Try 'hay que arreglar el dato de esta funcion para que acepte los datos que se aceptan a traves del form 2
                If (Replace(dato.Rows(i).Item(1).ToString, " ", "") <> "") Or (Replace(dato.Rows(i).Item(0).ToString, " ", "") <> "") Then
                    'inserta los docentes a la base de dato
                    Dim ingreso As New GHAU_CapaDatos.BaseDato
                    ingreso.IngresarDocentes(dato.Rows(i).Item(1).ToString, dato.Rows(i).Item(0).ToString, "DOCENTE")
                End If
            Catch
                'Dim ingreso As New GHAU_CapaDatos.BaseDato
                'ingreso.IngresarDocentes(dato.Rows(i).Item(0).ToString, dato.Rows(i).Item(1).ToString, dato.Rows(i).Item(2).ToString)
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

    Function ingreso_periodos(ByVal dato As DataTable, ByVal stringconeccion As String) 'ingresa docente
        Dim dtDuplicados = dato
        'elimina los Jornadas repetidos
        Dim MyView As DataView = New DataView(dtDuplicados)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(3).ColumnName.ToString)
        For i = 0 To dtSinDuplicados.Rows.Count - 1
            Dim ingreso As New GHAU_CapaDatos.Ingresar
            ingreso.IngresarPeriodo(dtSinDuplicados.Rows(i).Item(0).ToString, stringconeccion)
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


