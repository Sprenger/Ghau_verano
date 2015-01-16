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

End Class
