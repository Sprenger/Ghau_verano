Public Class Modularizacion ' clase para crear 
    Private DATO As DataTable
    Sub New(ByVal Dato As DataTable)
        Me.DATO = Dato
    End Sub

    Function data() As DataTable
        Dim dt2 As New DataTable

        For j = 0 To DATO.Columns.Count - 1

            dt2.Columns.Add(DATO.Columns(j).ColumnName, Type.GetType("System.String"))
        Next
        dt2.Rows.Add()
        For j = 0 To DATO.Rows.Count - 1
            Dim nrc = DATO.Rows(j).Item(20).ToString
            If InStr(DATO.Rows(j).Item(20).ToString, "/") <> 0 Then

                Dim dia() As String = Split(DATO.Rows(j).Item(20), "/") 'me sirve para hacer mach con sala y poder respaldarlo en la bd
                Dim temp_dia() As String = Split(DATO.Rows(j).Item(20), "/") 'me sirve para reordenar sin afectar el anterior arreglo
                Dim temp_temp_dia(0) As String 'me sirve para almacenar los dias sin repetirlos
                Dim vuelta As Boolean = False 'sirve para decidir si ya se agrego un primer dato en el array falso= temp_temp_dia se encuentra vacio
                Array.Sort(temp_dia)
                Dim sala() As String = Split(DATO.Rows(j).Item(24), "/")
                For x = 0 To dia.Length - 1

                    If vuelta Then
                        If Mid(Replace(temp_temp_dia(temp_temp_dia.Length - 1), " ", ""), 1, 3) <> Mid(Replace(temp_dia(x), " ", ""), 1, 3) Then
                            ReDim Preserve temp_temp_dia(UBound(temp_temp_dia) + 1)
                            temp_temp_dia(UBound(temp_temp_dia)) = Mid(Replace(temp_dia(x), " ", ""), 1, 3) & " " & Modularizacion(Mid(Replace(temp_dia(x), " ", ""), 4, 4), Mid(Replace(temp_dia(x), " ", ""), 9, 4))
                        Else
                            temp_temp_dia(temp_temp_dia.Length - 1) = Mid(temp_temp_dia(temp_temp_dia.Length - 1), 1, 6) & Mid(Modularizacion(Mid(Replace(temp_dia(x), " ", ""), 4, 4), Mid(Replace(temp_dia(x), " ", ""), 9, 4)), 3)

                        End If
                    Else
                        Dim nuevodia = Mid(Replace(temp_dia(x), " ", ""), 1, 3) & " " & Modularizacion(Mid(Replace(dia(x), " ", ""), 4, 4), Mid(Replace(dia(x), " ", ""), 9, 4))
                        temp_temp_dia(0) = nuevodia
                        vuelta = True
                    End If
                Next
                For k = 0 To temp_temp_dia.Length - 1
                    For i = 0 To DATO.Columns.Count - 1
                        If i = 20 Then
                            dt2.Rows(dt2.Rows.Count - 1).Item(i) = temp_temp_dia(k).ToString
                        ElseIf i = 24 Then
                            For h = 0 To dia.Length - 1
                                If Mid(Replace(temp_temp_dia(k), " ", ""), 1, 3) = Mid(Replace(dia(h), " ", ""), 1, 3) Then
                                    dt2.Rows(dt2.Rows.Count - 1).Item(i) = sala(h)
                                    Exit For
                                End If
                            Next

                        Else
                            dt2.Rows(dt2.Rows.Count - 1).Item(i) = DATO.Rows(j).Item(i).ToString

                        End If
                    Next
                    dt2.Rows.Add()
                Next

            Else
                For i = 0 To DATO.Columns.Count - 1
                    If i = 20 Then
                        dt2.Rows(dt2.Rows.Count - 1).Item(i) = Mid(DATO.Rows(j).Item(20).ToString, 1, 4) & Modularizacion(Mid(Replace(DATO.Rows(j).Item(20).ToString, " ", ""), 4, 4), Mid(Replace(DATO.Rows(j).Item(20).ToString, " ", ""), 9, 4))

                    Else
                        dt2.Rows(dt2.Rows.Count - 1).Item(i) = DATO.Rows(j).Item(i).ToString
                    End If

                Next
                dt2.Rows.Add()
            End If

        Next




        '   Next
        Return dt2

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
            Dim problem = "aca hay poblemas"
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
            Dim problem = "aca hay poblemas"
        End If

        Return modulo
    End Function

    Function boque(ByVal DATO As DataTable)
        Dim dtDuplicados = DATO
        'elimina los campus repetidos
        Dim MyView As DataView = New DataView(dtDuplicados)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtDuplicados.Columns(20).ColumnName.ToString)
        Dim row_Vacia(0) As Integer
        For i = 0 To dtSinDuplicados.Rows.Count - 1

            If Replace(dtSinDuplicados.Rows(i).Item(0).ToString, " ", "") = "" Then
                ReDim Preserve row_Vacia(UBound(row_Vacia) + 1)
                row_Vacia(UBound(row_Vacia)) = i
            Else
                dtSinDuplicados.Rows(i).Item(0) = Mid(Replace(dtSinDuplicados.Rows(i).Item(0).ToString, " ", ""), 4)
            End If

        Next
        For i = row_Vacia.Length - 1 To 1 Step -1
            dtSinDuplicados.Rows(row_Vacia(i)).Delete()
        Next

    End Function

End Class