Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.IO
Imports System.Globalization

Public Class Excel
    Private DATO As String



    ' ''Sub New(ByVal Dato As String)
    ' ''    Me.DATO = Dato
    ' ''End Sub


    Function LLENADOgrillaEventos(ByVal ruta As String) As DataTable 'Llena la grilla con los datos de la hoja excel
        DATO = ruta
        'If Lenguaje.ToUpper = "ESPAÑOL" Then
        '    hoja = "HOJA1"
        'Else
        '    hoja = "sheet1"

        'End If
        ' Dim sheetname As String = "HOJA1"
        Dim sheetname As String = "HOJA1"
        If ((String.IsNullOrEmpty(DATO)) OrElse (String.IsNullOrEmpty(sheetname))) Then Throw New ArgumentNullException()

        Try
            Dim extension As String = IO.Path.GetExtension(DATO)
            'establece a ruta del excel para la coneccion
            Dim connString As String = "Data Source=" & DATO
            'ESTABLECE LA CONECCION
            If (extension = ".xls") Then
                connString &= ";Provider=Microsoft.Jet.OLEDB.4.0;" & _
                       "Extended Properties='Excel 8.0;HDR=YES;IMEX=1'"

            Else
                Throw New ArgumentException( _
                  "La extensión " & extension & " del archivo no está permitida.")
            End If

            Using conexion As New OleDbConnection(connString) 'inicia coneccion a la base de dato

                Dim sql As String = "SELECT * FROM [" & sheetname & "$]"

                Dim adaptador As New OleDbDataAdapter(sql, conexion)

                Dim dt As New DataTable("Excel")
                adaptador.Fill(dt)
                Try
                    If dt.Rows.Count > 0 Then
                        Return dt

                    Else
                        Return Nothing


                    End If

                Catch
                    Return dt
                End Try
            End Using

        Catch ex As Exception
            MsgBox("Ocurrio un error al abrir el excel, asegurese que el nombre de la hoja se llame 'HOJA1'")
            '  asignaturas.Txt_RutaXLS.Text = ""

        End Try

    End Function


    Function LLENADOgrilla(ByVal ruta As String) As DataTable 'Llena la grilla con los datos de la hoja excel
        DATO = ruta
        'If Lenguaje.ToUpper = "ESPAÑOL" Then
        '    hoja = "HOJA1"
        'Else
        '    hoja = "sheet1"

        'End If
        ' Dim sheetname As String = "HOJA1"
        Dim sheetname As String = "HOJA1"
        If ((String.IsNullOrEmpty(DATO)) OrElse (String.IsNullOrEmpty(sheetname))) Then Throw New ArgumentNullException()

        Try
            Dim extension As String = IO.Path.GetExtension(DATO)
            'establece a ruta del excel para la coneccion
            Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DATO & _
            ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=0'"

            ' Dim cadconex As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Me.txtRutaXLS.Text.Trim & 
            '";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""





            '"Data Source=" & DATO & ";Provider=Microsoft.Jet.OLEDB.4.0;" & _
            '"Extended Properties='Excel 8.0;HDR=YES;IMEX=2;MAXSCANROWS=0;\"";"
            '
            ' "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + xlsx + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=0'"
            Using conexion As New OleDbConnection(connString) 'inicia coneccion a la base de dato

                Dim sql As String = "SELECT * FROM [" & sheetname & "$]"

                Dim adaptador As New OleDbDataAdapter(Sql, conexion)

                Dim dt As New DataTable("Excel")



                adaptador.Fill(dt)
                                Return dt
            End Using

        Catch ex As Exception
            '   MsgBox("Ocurrio un error al abrir el excel, asegurese que el nombre de la hoja se llame 'HOJA1'")
            '  asignaturas.Txt_RutaXLS.Text = ""

        End Try

    End Function

    Function validar(ByVal dato As DataTable) As DataTable
        Dim dtDuplicados = dato
        Dim programas As New GHAU_CapaNegocio.Negocio
        Dim dtprograma_descripcion = programas.ConsultarProrgamas_descripcion()
        Dim MyView As DataView = New DataView(dtDuplicados)
        Dim AGREGAR As String = ""
        Dim contador As Integer = 100
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(30).ColumnName.ToString)

        For i = dtSinDuplicados.Rows.Count - 1 To 0 Step -1
            Dim encontrado As Boolean = False ' dice si se encontro el dato en la BD
            Dim dtsinduplicar = Split(dtSinDuplicados.Rows(i).Item(0).ToString, "/")
            For j = 0 To dtprograma_descripcion.Rows.Count - 1

                'AGREGAR = AGREGAR & "insert into PROGRAMAS values('" & contador & "','" & dtsinduplicar(0) & "')" & vbNewLine
                Dim comparado = dtprograma_descripcion.Rows(j).Item(0).ToString
                contador = contador + 1
                If Replace(dtsinduplicar(0).ToString, " ", "") = Replace(dtprograma_descripcion.Rows(j).Item(0).ToString, " ", "") Then
                    encontrado = True
                    Exit For
                End If

            Next
            If encontrado Then
                dtSinDuplicados.Rows(i).Delete()


            End If

        Next

        Return dtSinDuplicados
    End Function


    Sub Exportar(ByVal dtgrilla As DataTable, ByVal dia As String)
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            Dim NCol As Integer = dtgrilla.Columns.Count
            Dim NRow As Integer = dtgrilla.Rows.Count
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 2 To NCol
                exHoja.Cells.Item(1, i) = dtgrilla.Columns(i - 1).ColumnName 'Columns(i - 1).Name.ToString
            Next

            For Col As Integer = 0 To NCol - 1
                Dim c As String = ""

                c = ColumnName(Col + 1)

                For Fila As Integer = 0 To NRow - 1
                    Dim datos = Split(dtgrilla.Rows(Fila).Item(Col).ToString, "++")
                    If datos.Length > 2 And datos.Length <= 6 Then
                        exHoja.Cells.Item(Fila + 2, Col + 1) = Replace(dtgrilla.Rows(Fila).Item(Col).ToString, "++", " ")
                        Dim x = Fila + 2
                        exHoja.Range(c & x).AddComment()
                        exHoja.Range(c & x).Comment.Text(Text:="Any Comment")

                    ElseIf datos.Length > 6 Then
                        exHoja.Cells.Item(Fila + 2, Col + 1) = 1

                    ElseIf datos.Length = 1 Then

                        exHoja.Cells.Item(Fila + 2, Col + 1) = dtgrilla.Rows(Fila).Item(Col).ToString


                    End If

                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3

            exHoja.Columns.AutoFit()
            exHoja.Range("A:GZ").EntireColumn.ColumnWidth = 20
            exHoja.Range("A:GZ").WrapText = True
            exHoja.Range("1:99").EntireRow.RowHeight = 80

            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing



        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            ' Return False
        End Try
    End Sub

    Function ColumnName(ByVal index As Integer) As String
        Static chars() As Char = {"A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c}

        index -= 1 ''//adjust so it matches 0-indexed array rather than 1-indexed column

        Dim quotient As Integer = index \ 26 ''//normal / operator rounds. \ does integer division, which truncates
        If quotient > 0 Then
            ColumnName = ColumnName(quotient) & chars(index Mod 26)
        Else
            ColumnName = chars(index Mod 26)
        End If
    End Function







    Function ValidarChoquesExcel(ByVal dato As DataTable) As DataTable
        Dim pivote As Date = CDate("30-12-2013") '.DayOfWeek ' fecha que servira para 
        Dim dt_Choques As New DataTable
        dt_Choques.Columns.Add("NRC", Type.GetType("System.String"))
        dt_Choques.Columns.Add("Descripcion", Type.GetType("System.String"))
        Dim ObjSalas As New GHAU_CapaDatos.Salas ' coneccion a clase salas
        Dim DatoExcel As DataView = New DataView(dato)

        Dim Fechas As DataTable = DatoExcel.ToTable(True, "Fecha Inicio", "Fecha Fin")
        Dim objHorario As New GHAU_CapaDatos.Horarios
        Dim dtSala = ObjSalas.MostrarSalas_Disponibles 'Salas disponibles  
        Dim dataView As New DataView(Fechas)
        dataView.Sort = " Fecha Inicio asc"
        Dim TempFecha As DataTable = dataView.ToTable()
        Dim F_I_Excel As String 'fecha inicio excel
        Dim k As Integer = 0
        Try
3:
            F_I_Excel = CDate(TempFecha.Rows(k).Item(0).ToString)
        Catch ex As Exception

            k = k + 1
            GoTo 3
        End Try

        Dim diferencias As Integer = (CDate(F_I_Excel) - pivote).Days
        Dim Funciones As Integer = Math.Truncate(diferencias / 7) 'Math.Truncate(decimalNumber)
        Dim funcion2 As Integer = Funciones * 7
        Funciones = diferencias - funcion2
        F_I_Excel = DateAdd(DateInterval.Day, -CInt(Funciones), CDate(F_I_Excel))



        'Fecha Inicio del excel
        dataView.Sort = Fechas.Columns(1).ColumnName.ToString & " desc"
        TempFecha = dataView.ToTable()
        Dim TempFF As String  'fecha FIN del excel
        k = 0
        Try
4:
            TempFF = CDate(TempFecha.Rows(k).Item(1).ToString)
        Catch ex As Exception
            k = k + 1
            GoTo 4
        End Try

        Dim dtHorario = objHorario.MostrarHorarioFechas(F_I_Excel, TempFF) 'compara con la base de dato deacuerdo ala menor fecha del excel y la mayor del mismo
        Dim DFE = DateDiff(DateInterval.Day, CDate(F_I_Excel), CDate(TempFF)) + 1 'diferencia de la fechas obtenida en el excel

        Dim arr_cubo(DFE, dtSala.Rows.Count - 1, 20) As Boolean 'arreglo que informa si esta ocupada o no la sala


        'Dim TempDia = CDate(TempFI) 'DateAdd(DateInterval.Day, 1, CDate(TempFI))
        Dim sala, bloque As String
        Dim Dif_Horario, difIinicios As Integer
        '        Dim inicioT As Date
        'Dim c = dtHorario
        Dim bloc As String = ""

        For i = 0 To dtHorario.Rows.Count - 1 'dt de la base de dato
           
            Try
                Dif_Horario = DateDiff(DateInterval.Day, CDate(dtHorario.Rows(i).Item(3).ToString), CDate(dtHorario.Rows(i).Item(4).ToString)) + 1 'marca los dias que son del nrc (fecha fin - fecha Inicio)


                difIinicios = DateDiff(DateInterval.Day, CDate(F_I_Excel), CDate(dtHorario.Rows(i).Item(3).ToString))
                bloque = dtHorario.Rows(i).Item(5).ToString.ToCharArray
                sala = dtHorario.Rows(i).Item(2).ToString()
                ' Dim cc = difIinicios + Dif_Horario
                Funciones = CInt(dtHorario.Rows(i).Item(1).ToString) - 1 'Math.Truncate(decimalNumber)


                For j = 0 + difIinicios + Funciones To difIinicios + Dif_Horario Step 7
                    For b = InStr(bloque, "1") To 19
                        'Dim arrrr = arr_cubo(396, 151, 6)
                        'If CInt(sala) < 185 Then
                        If bloque(b) = "1" Then
                            bloc = bloc & j & "," & CInt(sala) & "," & b & ": " & "True" & vbNewLine
                            arr_cubo(j, CInt(sala), b) = True

                        End If
                        'Else

                        '                       End If
                        '
                    Next
                Next
            Catch ex As Exception
                'MsgBox(tempj & "____" & bb & vbNewLine & (sala))

            End Try

        Next
        Dim salas As String = ""

        For i = 0 To dtSala.Rows.Count - 1
            salas = salas & dtSala.Rows(i).Item(1).ToString & " " & dtSala.Rows(i).Item(3).ToString & vbNewLine
        Next
        '(dif * 2, dtSala.Rows.Count - 1, 20

        For i = 0 To dato.Rows.Count - 1
            If dato.Rows(i).Item(3).ToString = "" Or dato.Rows(i).Item(3) Is Nothing Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee PERIODO"
            ElseIf dato.Rows(i).Item(1).ToString = "" Or dato.Rows(i).Item(1) Is Nothing Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee CAMPUS"
            ElseIf dato.Rows(i).Item(2).ToString = "" Or dato.Rows(i).Item(2) Is Nothing Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee UNIDAD ACADEMICA"
            ElseIf dato.Rows(i).Item(5).ToString = "" Or dato.Rows(i).Item(5) Is Nothing Then
                Dim valor = dato
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee CURSO "
            ElseIf dato.Rows(i).Item(4).ToString = "" Or dato.Rows(i).Item(4) Is Nothing Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee MATERIA "
            ElseIf dato.Rows(i).Item(7).ToString = "" Or dato.Rows(i).Item(7) Is Nothing Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee JORNADA "
            ElseIf dato.Rows(i).Item(33).ToString = "" Or dato.Rows(i).Item(34).ToString = "" Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee fecha de inicio o fin"
            ElseIf dato.Rows(i).Item(18).ToString = "" Or dato.Rows(i).Item(18) Is Nothing Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee  ACTIVIDAD"
            ElseIf dato.Rows(i).Item(19).ToString = "" Or dato.Rows(i).Item(19) Is Nothing Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee  MODALIDAD"
            ElseIf dato.Rows(i).Item(18).ToString = "" Or dato.Rows(i).Item(18) Is Nothing Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee Actividad"
            ElseIf dato.Rows(i).Item(20).ToString = "" Or dato.Rows(i).Item(20) Is Nothing Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee HORARIO"
            ElseIf dato.Rows(i).Item(24).ToString = "" Or dato.Rows(i).Item(24) Is Nothing Or dato.Rows(i).Item(24).ToString.Length < 3 Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee SALA"
            ElseIf InStr(dato.Rows(i).Item(1).ToString, "MAR") = 0 Then
            Else
                Dim Exdia As New GHAU_CapaNegocio.funciones

                Dim ExARRhorario(), Exedificio, Exsala(), ExfechaInicio, ExfechaFin, ExJornada As String
                '  Dim dtexcel = dato
                ExARRhorario = Split(Replace(dato.Rows(i).Item(20).ToString, "/", ""), ".") 'arreglo horario que separa por . el arreglo (0) siempre tienen valor ""
                Exedificio = dato.Rows(i).Item(23).ToString
                Exsala = Split(dato.Rows(i).Item(24).ToString, "/")
                ExfechaInicio = CDate(dato.Rows(i).Item(33).ToString)
                ExfechaFin = CDate(dato.Rows(i).Item(34).ToString)
                ExJornada = dato.Rows(i).Item(7).ToString.ToUpper
                Dim diferenciaExcelF = DateDiff(DateInterval.Day, CDate(F_I_Excel), CDate(ExfechaInicio)) 'diferencia entre la maxima del excel y el dato inicio
                Dim diferencia_Entre = DateDiff(DateInterval.Day, CDate(ExfechaInicio), CDate(ExfechaFin)) + 1 'diferencia entre el mismo rows del excel
                Dim contadorSala As Integer = 0
                For z = 1 To ExARRhorario.Length - 1
                    Dim temp_dia = Mid(ExARRhorario(z).ToString, 1, 2) 'rescata el dia del arreglo horarrio
                    'Dim temp_Modulosinicio = Mid(Replace(ExARRhorario(z).ToString, " ", ""), 3, 4) 'obtiene la hora Inicio
                    'Dim temp_ModulosFin = Mid(Replace(ExARRhorario(z).ToString, " ", ""), 8) 'Obtiene la Hra fin
                    Dim temp_Modulos = Exdia.modularizacion(Mid(Replace(ExARRhorario(z).ToString, " ", ""), 3, 4), Mid(Replace(ExARRhorario(z).ToString, " ", ""), 8), ExJornada) 'devuelve el modulo correspondiente
                    'Dim dia = Exdia.conversordia(temp_dia)
                    Dim temp_sala As String = z
                    Try
1:
                        'contadorSala = contadorSala - 1
                        temp_sala = Exsala(contadorSala)
                    Catch ex As Exception
                        contadorSala = contadorSala - 1
                        If contadorSala < 0 Then
                            Exit For
                        End If
                        GoTo 1
                    End Try
                    '  Dim sala=

                    'Dim UbicacionSala = InStr(salas, (temp_sala)) 'Ubicacion de la sala dentro del string
                    'Dim salasF = Mid(salas, InStr(salas, (temp_sala))) 'desde la ubicacion de la sala hasta el final del string
                    '  Dim salas_final = Mid(Mid(salas, InStr(salas, (temp_sala))), 1, InStr(Mid(salas, InStr(salas, (temp_sala))), vbNewLine)) 'linea de la sala con la posicion
                    Dim salasF = Mid(Mid(Mid(salas, InStr(salas, (temp_sala))), 1, InStr(Mid(salas, InStr(salas, (temp_sala))), vbNewLine)), InStr(Mid(Mid(salas, InStr(salas, (temp_sala))), 1, InStr(Mid(salas, InStr(salas, (temp_sala))), vbNewLine)), " ")) 'Solo posicion de la sala

                    'Dim salasss = InStr(salas, (arr_salas(temp_sala_dia)))
                    'Dim salasF = Mid(salas, InStr(salas, (arr_salas(temp_sala_dia))))
                    'Dim salasFinal = Mid((Mid(salas, InStr(salas, (arr_salas(temp_sala_dia))))), 1, InStr(salas, vbNewLine) + 2)
                    'Dim rowIndex As Integer = CInt(Mid(Mid((Mid(salas, InStr(salas, (arr_salas(temp_sala_dia))))), 1, InStr(salas, vbNewLine) + 2), (arr_salas(temp_sala_dia)).Length + 2))



                    'Dim salasF = Mid(salas, InStr(salas, (arr_salas(temp_sala_dia))))
                    'Dim salasFinal = Mid((Mid(salas, InStr(salas, (arr_salas(temp_sala_dia))))), 1, InStr(salas, vbNewLine) + 2)
                    ' Dim rowIndex As Integer = CInt(Mid(Mid((Mid(salas, InStr(salas, (arr_salas(temp_sala_dia))))), 1, InStr(salas, vbNewLine) + 2), (arr_salas(temp_sala_dia)).Length + 2))

                    For j = diferenciaExcelF To diferenciaExcelF + diferencia_Entre Step 7
                        For l = InStr(temp_Modulos, "1") To 20
                            If arr_cubo(j, CInt(salasF), l) = True Then
                                dt_Choques.Rows.Add()
                                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString

                                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "Choque en el modulo " & l & " Dia " & (CDate(dato.Rows(i).Item(33).ToString).Date.AddDays(l))
                            End If
                        Next


                    Next

                Next

                'For j= diferenciaExcel to diferenciaExcel+diferencia_Entre



            End If


        Next



        Dim vista As New DataView(dt_Choques)
        Dim dtsindupl As DataTable = vista.ToTable(True, "NRC", "Descripcion")


        Return dtsindupl
    End Function

End Class
