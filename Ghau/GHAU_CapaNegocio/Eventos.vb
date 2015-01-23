Public Class Eventos
    Dim dx As DateTime
    Dim dx2 As DateTime

    Dim x As New GHAU_CapaDatos.Agregar_evento
    Dim z As New GHAU_CapaNegocio.funciones
    Dim eliminarNRC As New GHAU_CapaDatos.BaseDato

    Public Function recorrer_l(ByVal dia, ByVal fecha)
        Dim val = x.recorrer(dia, fecha)
        If val Is Nothing Then
            Return False
        Else
            Return val
        End If
    End Function
    Public Function liberando(ByVal liberta As DataTable, ByVal dt As DataTable)
        For k = 0 To liberta.Rows.Count - 1
            For j = 0 To dt.Rows.Count - 1
                If liberta.Rows(k).Item(0).ToString = dt.Rows(j).Item(1).ToString Then
                    Dim asdasd = liberta.Rows(k).Item(0).ToString
                    Return True
                Else
                    Return False
                End If

            Next
        Next
    End Function


    Function ingreso_evento(ByVal dato As DataTable) As DataTable
        Dim dterror As New DataTable
        dterror.Columns.Add("NRC", Type.GetType("System.String"))
        dterror.Columns.Add("ERROR", Type.GetType("System.String"))
        Dim bandera2 As Integer

        For i = 0 To dato.Rows.Count - 1
            Dim bandera1 = dato.Rows.Count

            'filtro campus
            If "VIÑADELMAR" = Replace(dato.Rows(i).Item(4).ToString.ToUpper, " ", "") Then
                'filtro sala
                If dato.Rows(i).Item(11).ToString <> "" Then
                    'filtro fecha in fecha ter
                    If dato.Rows(i).Item(5).ToString <> "" Or dato.Rows(i).Item(6).ToString <> "" Then
                        'en caso que falle convertir a cdate(D A T O)
                        'filtro para saber si esta dentro de la fecha actual
                        Try
                            dx = CDate(dato.Rows(i).Item(5))

                        Catch ex As Exception
                            dterror.Rows.Add()
                            dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                            dterror.Rows(dterror.Rows.Count - 1).Item(1) = "Fecha Inicio se encuentra vacio"
                            GoTo 1
                        End Try
                        Try
                            dx2 = CDate(dato.Rows(i).Item(6))

                        Catch ex As Exception
                            dterror.Rows.Add()
                            dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                            dterror.Rows(dterror.Rows.Count - 1).Item(1) = "Fecha  Fin se encuentra vacio"
                            GoTo 1
                        End Try

                        If dx >= DateTime.Now.Date Or dx2 >= DateTime.Now.Date Then
                            'filtro edificio
                            If dato.Rows(i).Item(10).ToString <> "" Then
                                'filtro hora de clase
                                If dato.Rows(i).Item(8).ToString <> "" And dato.Rows(i).Item(9).ToString <> "" Then
                                    'Dia de la semana
                                    If dato.Rows(i).Item(8).ToString <> "" Then
                                        '***************************************************************
                                        dx = dato.Rows(i).Item(5).ToString
                                        Dim periodo As Integer = dx.ToString("yyyy") & "00"

                                        Dim da As Date = dato.Rows(i).Item(8).ToString
                                        Dim da2 = Format(da, "HH:mm")
                                        Dim da3 = Replace(da2, ":", "")

                                        Dim da4 As Date = dato.Rows(i).Item(9).ToString
                                        Dim da5 = Format(da4, "HH:mm")
                                        Dim da6 = Replace(da5, ":", "")

                                        Dim da7 = "EVENTO"
                                        Dim bloque = z.modularizacion(da3, da6, da7)
                                        Dim arr_dia = Split(dato.Rows(i).Item(7).ToString, " ")
                                        bandera2 = bandera2 + 1

                                        Dim fecha As Date = Date.Now
                                        Dim pe As Integer = fecha.ToString("yyyy") & "00"

                                        If bandera1 = bandera2 Then

                                            x.eliminarEvento(pe)

                                            For p = 0 To arr_dia.Length - 1
                                                x.guardar_A_Evento(dato.Rows(i).Item(5).ToString, dato.Rows(i).Item(6).ToString, _
                                                             cambiadia(arr_dia(p)), dato.Rows(i).Item(1).ToString, _
                                                             dato.Rows(i).Item(2).ToString, dato.Rows(i).Item(11).ToString, bloque, _
                                                             dato.Rows(i).Item(0).ToString, Date.Now, "PRESENCIAL", periodo)
                                            Next
                                            'MsgBox("Guardado Exitoso!")
                                            Return Nothing
                                        Else
                                            MsgBox("Desea Cargar Los que no tienen Error?", MsgBoxStyle.YesNo, "Errores de Registro")
                                            If MsgBoxResult.Yes = 6 Then
                                                x.eliminarEvento(pe)
                                                For p = 0 To arr_dia.Length - 1
                                                    x.guardar_A_Evento(dato.Rows(i).Item(5).ToString, dato.Rows(i).Item(6).ToString, _
                                                                 cambiadia(arr_dia(p)), dato.Rows(i).Item(1).ToString, _
                                                                 dato.Rows(i).Item(2).ToString, dato.Rows(i).Item(11).ToString, bloque, _
                                                                 dato.Rows(i).Item(0).ToString, Date.Now, "PRESENCIAL", periodo)
                                                Next
                                                MsgBox("Guardado Exitoso!")
                                            End If
                                        End If

                                        '******************************************************************

                                    Else
                                        dterror.Rows.Add()
                                        dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                                        dterror.Rows(dterror.Rows.Count - 1).Item(1) = "dia no asignado"
                                    End If
                                Else
                                    dterror.Rows.Add()
                                    dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                                    dterror.Rows(dterror.Rows.Count - 1).Item(1) = "hora de clase no asignado"
                                End If

                            Else
                                dterror.Rows.Add()
                                dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                                dterror.Rows(dterror.Rows.Count - 1).Item(1) = "edificio no asignado"
                            End If
                        Else
                            dterror.Rows.Add()
                            dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                            dterror.Rows(dterror.Rows.Count - 1).Item(1) = "Fecha fuera de rango"
                        End If

                    Else
                        dterror.Rows.Add()
                        dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                        dterror.Rows(dterror.Rows.Count - 1).Item(1) = "No tiene Fecha de inicio o fecha de fin"
                    End If

                Else
                    dterror.Rows.Add()
                    dterror.Rows(dterror.Rows.Count - 1).Item(0) = dato.Rows(i).Item(0).ToString.ToUpper
                    dterror.Rows(dterror.Rows.Count - 1).Item(1) = "Sala Vacia"

                End If
            End If
1:
        Next
        'Next
        x.guardar_evento(dterror)

        Return (dterror)
    End Function

    Function cambiadia(ByVal dia As String)

        dia = Replace(dia.ToUpper, "Á", "A")
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

        Return dia
    End Function

    Sub EliminarEventos(ByVal NRC As String)

        eliminarNRC.EliminarEventos(NRC)
    End Sub
    Sub Ingreso_M_Eventos(ByVal Fecha_inicio As String, ByVal fecha_fin As String, ByVal dia As String, ByVal nombre_curso As String, _
                               ByVal sala As String, ByVal Bloque As String, _
                               ByVal NRC As String, ByVal fecha_carga As String, ByVal modalidad_codigo As String, ByVal Responsable As String)
        Dim numero_periodo As Date = CDate(Fecha_inicio)
        Dim anno = numero_periodo.ToString("yyyy") & "00"
        Dim dt_Docente As New GHAU_CapaDatos.Docente
        Dim Rut_docente = dt_Docente.ConsultarDocentes(Responsable, "NOMBRE", "rut_docente")
        Dim dt_modalidad As New GHAU_CapaDatos.Modalidades
        Dim modalidades = dt_modalidad.ConsultaModalidades("PRESENCIAL", "Descripcion", "modalidad_codigo")
        x.guardar_M_Evento(Fecha_inicio, fecha_fin, dia, nombre_curso, Rut_docente.Rows(0).Item(0).ToString, sala, Bloque, NRC, fecha_carga, modalidades.Rows(0).Item(0).ToString, anno)

    End Sub
    Function horario(ByVal dia As String, ByVal fecha As String) As DataTable
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
    End Function

    Function consultarExiste(ByVal bloque As String, ByVal sala As String, ByVal dias As String) As DataTable
        bloque = Replace(bloque, "0", "_")
        Dim derechaIzq = False
        Dim arrbloques = bloque.ToCharArray
        For i = 11 To 13
            If arrbloques(i) = "1" Then
                arrbloques(i + 3) = "1"

            End If
        Next
        Dim Nuevobloque As String = ""
        For i = 0 To arrbloques.Length - 1
            Nuevobloque = Nuevobloque & arrbloques(i)
        Next
        Dim Nuevobloque2 = Nuevobloque


        Dim dt_Existe As DataTable
        Dim respuesta As Boolean = False

1:
        If (Replace(Nuevobloque, "_", "")) = "" Then
            Return Nothing
        End If

        dt_Existe = x.BuscarExiste(Nuevobloque, Nuevobloque2, sala, dias)
        If dt_Existe.Rows.Count = 0 And InStr(Nuevobloque, "1") > 0 Then
            arrbloques = Nuevobloque.ToCharArray

            For i = 0 To arrbloques.Length - 1
                If arrbloques(i) = "1" Then
                    arrbloques(i) = "_"
                    Exit For
                End If
            Next


            Nuevobloque = ""
            For i = 0 To arrbloques.Length - 1
                Nuevobloque = Nuevobloque & arrbloques(i)
            Next
            arrbloques = Nuevobloque2.ToCharArray

            For i = arrbloques.Length - 1 To 0 Step -1
                If arrbloques(i) = "1" Then
                    arrbloques(i) = "_"
                    Exit For
                End If
            Next
            Nuevobloque2 = ""
            For i = 0 To arrbloques.Length - 1
                Nuevobloque2 = Nuevobloque2 & arrbloques(i)
            Next


            GoTo 1
        End If

        Return dt_Existe 'x.BuscarExiste(bloque, sala)
    End Function
    Function ConsultarEventos(ByVal parametro As String, ByVal columnaconsulta As String, ByVal columnaretorno As String) As DataTable
        Return x.BuscarEventos(parametro, columnaconsulta, columnaretorno)
    End Function
    Sub eliminar(ByVal nrc As String)
        x.eliminarEvento_nrc(nrc)
    End Sub
    Sub eliminarEvento(ByVal NRC As String)
        Dim eliminar As New GHAU_CapaDatos.Agregar_evento

        eliminar.EliminarEventos(NRC)
    End Sub

End Class
