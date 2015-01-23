Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
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

                Dim dtDuplicados = dt
                Dim MyView As DataView = New DataView(dtDuplicados)

                Dim dtSinDuplicados As DataTable
                dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(30).ColumnName.ToString)
                Dim contador = 1000
                Dim ingresados = ""
                Dim insertar As String = ""
                For i = 0 To dtSinDuplicados.Rows.Count - 1
                    Dim c = Split(Trim(dtSinDuplicados.Rows(i).Item(0).ToString), "/")
                    For j = 0 To c.Length - 1
                        If InStr(ingresados, Replace(c(j), " ", "")) = 0 Then
                            insertar = insertar & "insert into PROGRAMAS values ('" & contador & "','" & c(j) & "')" & vbNewLine
                            contador = contador + 1
                            ingresados = ingresados & "/" & Replace(c(j), " ", "")
                        End If

                    Next



                Next


                Try
                    Dim dataView As New DataView(dt)
                    dataView.Sort = dt.Columns(8).ColumnName & " asc"
                    Dim dataTable As DataTable = dataView.ToTable()
                    Dim verificaor As DataTable = validar(dataTable)
                    'Dim c = dataTable
                    If verificaor.Rows.Count > 0 Then
                        Return verificaor

                    Else
                        Return dataTable


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
        Dim TempFI As String 'fecha inicio excel
        Dim k As Integer = 0
        Try
3:
            TempFI = CDate(TempFecha.Rows(k).Item(0).ToString)
        Catch ex As Exception

            k = k + 1
            GoTo 3
        End Try
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

        Dim dtHorario = objHorario.MostrarHorarioFechas(TempFI, TempFF) 'compara con la base de dato deacuerdo ala menor fecha del excel y la mayor del mismo
        Dim dif = DateDiff(DateInterval.Day, CDate(TempFI), CDate(TempFF)) + 1 'diferencia de la fechas obtenida en el excel

        Dim arr_cubo(dif, dtSala.Rows.Count - 1, 20) As Boolean 'arreglo que informa si esta ocupada o no la sala
        Dim TempDia = CDate(TempFI) 'DateAdd(DateInterval.Day, 1, CDate(TempFI))
        Dim sala, bloque As String
        Dim Dif_Horario, difIinicios As Integer
        Dim inicioT As Date
        For i = 0 To dtHorario.Rows.Count - 1
            Dif_Horario = DateDiff(DateInterval.Day, CDate(dtHorario.Rows(i).Item(3).ToString), CDate(dtHorario.Rows(i).Item(4).ToString)) + 1 'marca los dias que son del nrc (fecha fin - fecha Inicio)
            inicioT = CDate(dtHorario.Rows(i).Item(3).ToString)
            difIinicios = DateDiff(DateInterval.Day, CDate(TempFI), CDate(inicioT))
            bloque = dtHorario.Rows(i).Item(5).ToString.ToCharArray
            sala = dtHorario.Rows(i).Item(2).ToString()
            For j = 0 + difIinicios To difIinicios + Dif_Horario
                For b = 0 To 19
                    If CInt(sala) < 185 Then
                        If bloque(b) = "1" Then

                            arr_cubo(j, CInt(sala), b) = True
                        End If
                    End If
                Next
            Next
        Next

        Dim Temp_arr_dias() As String
        For i = 0 To dato.Rows.Count - 1

1:
            If i = dato.Rows.Count Then
                GoTo 7

            End If

            If dato.Rows(i).Item(33).ToString = "" Or dato.Rows(i).Item(34).ToString = "" Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee fecha de inicio o fin"
                i += 1
                GoTo 1
            End If
            Dim nrc = dato.Rows(i).Item(8).ToString

            Dif_Horario = DateDiff(DateInterval.Day, CDate(dato.Rows(i).Item(33).ToString), CDate(dato.Rows(i).Item(34).ToString)) + 1 'marca los dias que son del nrc (fecha fin - fecha Inicio)
            Dim arr_dias = Split(dato.Rows(i).Item(20).ToString.Trim, ".") ' crea arreglo por cada dia
            If dato.Rows(i).Item(24).ToString = "" Then
                dt_Choques.Rows.Add()
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "No posee sala"
                GoTo 2
            End If
            Dim arr_salas = Split(Replace(dato.Rows(i).Item(24).ToString, "/", " "), " ")

            Dim modulo As New GHAU_CapaDatos.funciones
            'Dim Bloque=modulo.modularizacion(
            Dim jornada As String = dato.Rows(i).Item(7).ToString

            For j = 0 + difIinicios To difIinicios + Dif_Horario ' recorre fecha

                For d = 1 To arr_dias.Length - 1
                    Temp_arr_dias = Split(arr_dias(d).Trim, " ")
                    If Replace((arr_dias(d).Trim), " ", "") = "" Then
                        GoTo 6
                    End If
                    Dim jornadadd = dato.Rows(i).Item(7).ToString

                    bloque = modulo.modularizacion(Temp_arr_dias(1).ToString, Temp_arr_dias(3).ToString, dato.Rows(i).Item(7).ToString).ToCharArray
                    Dim result As DataRow()
                    Dim temp_sala_dia As Integer
                    Try
                        temp_sala_dia = d
5:
                        Dim kk = arr_salas(temp_sala_dia)
                        If kk = "EXTERNA" Then
                            i += 1
                            GoTo 1
                        End If
                        result = dtSala.Select("Sala='" & kk.Trim & "'")
                    Catch ex As Exception
                        temp_sala_dia -= 1
                        GoTo 5
                    End Try
                    Dim rowIndex As Integer
                    Try
                        rowIndex = dtSala.Rows.IndexOf(result(0))
                    Catch ex As Exception

                        i += 1
                        GoTo 1 'salas no existen
                    End Try
                    'If arr_dias(0).ToUpper = "." & Replace(Mid((CDate(dato.Rows(i).Item(33).ToString).Date.AddDays(1)).ToString("dddd MM YY").ToUpper, 1, 2), "á", "a").ToUpper Then

                    For b = 0 To 19
                        If bloque(b) = "1" Then
                            If arr_cubo(j, rowIndex + 1, b) Then

                                dt_Choques.Rows.Add()
                                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(0) = dato.Rows(i).Item(8).ToString
                                dt_Choques.Rows(dt_Choques.Rows.Count - 1).Item(1) = "Choque en el modulo " & b + 1 & " Dia " & (CDate(dato.Rows(i).Item(33).ToString).Date.AddDays(1))

                                'Temp_arr_dias
                                i += 1
                            End If
                            GoTo 1

                        End If

                    Next
                    ' End If
                Next
6:
                j = j + 7
            Next

2:
        Next
7:
        Return dt_Choques


    End Function

End Class
