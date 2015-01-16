Imports GHAU_CapaDatos.MantenedorBD
Public Class Negocio
    Public _NombreServidor_, _NombreUsuario_, _Pass_

    Sub New()
        Dim fichero = Environment.GetEnvironmentVariable("windir") 'Busca en que disco esta a carpeta de windows
        fichero = fichero & "/ghau/Coneccion.bat"
        Dim texto
        Dim sr As New System.IO.StreamReader(fichero) 'lee texto coneccion.bat
        texto = sr.ReadToEnd()
        sr.Close()
        Dim parametro() = Split(texto, vbNewLine) 'areglo que almacena informacion del texto
        _NombreServidor_ = parametro(0)
        _NombreUsuario_ = parametro(1)
        _Pass_ = parametro(2) 'rescata parametros desde el archivo .bat

    End Sub
    Function consultarBloque()
        Dim programa As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Return programa.consultarbloques
    End Function
    Function consultarHorario(ByVal nrc As String) As DataTable
        Dim programa As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Return programa.consultarHorario(nrc)

    End Function
    Function consultarBloques(ByVal bloque As String, ByVal Sala As String)

    End Function
    Function consultarHorario(ByVal fechaInicio As String, ByVal fechafin As String, ByVal jornada As String, ByVal evento As Boolean, ByVal dia As String, ByVal even As String, ByVal Dias As Long, ByVal COUNTSALA As Integer) As DataTable 'pensando en devolver el numero
        Dim programa As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim grafico As New DataTable

        grafico.Columns.Add("fecha", Type.GetType("System.String"))
        grafico.Columns.Add("valor", Type.GetType("System.String"))
        Dim fecha As Date = fechaInicio
        Dim cantjornada As Integer
        If jornada.ToUpper = "TODOS" Then
            cantjornada = 17
        ElseIf jornada.ToUpper = "DIURNO" Then
            cantjornada = 14
        Else
            cantjornada = 6
        End If
        Dim countsalas = (cantjornada * COUNTSALA)
        For i = 0 To Dias

            'If Not Dias = 0 Then
            Dim dtValor = programa.consultarHorario(fecha.ToString, fechafin, jornada, evento, dia, even, countsalas)

            If Not dtValor Is Nothing Then


                Dim valr = dtValor.Rows(0).Item(0).ToString
                If valr <> "" Then
                    grafico.Rows.Add()
                    grafico.Rows(grafico.Rows.Count - 1).Item(0) = Mid(fecha.ToString, 1, 10)

                    grafico.Rows(grafico.Rows.Count - 1).Item(1) = dtValor.Rows(0).Item(0).ToString

                End If




                If dia = 6 Then
                    dia = 1
                    fecha = fecha.AddDays(2)
                Else
                    dia = dia + 1
                    fecha = fecha.AddDays(1)
                End If
            End If
        Next




        Return grafico
    End Function
    Function consultarPrograma()
        Dim programa As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Return programa.consultarProgramas
    End Function
    Function ingresaruacademicas(ByVal Codigo As String, ByVal Glosa As String) As Boolean
        Dim programa As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)

        Return programa.ingresaruacademicas(Codigo, Glosa)

    End Function

    'Function ingresarEventos(ByVal nrc As String, ByVal Descriocion As String, ByVal Rut As String, ByVal campus As String, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal dia As String, ByVal Bloque As String, ByVal sala As String, ByVal edificio As String) As Boolean
    '    Dim programa As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)

    '    Return programa.IngresarPrograma(Codigo, Glosa)

    'End Function


    Function ingresarPrograma(ByVal Codigo As String, ByVal Glosa As String) As Boolean
        Dim programa As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)

        Return programa.IngresarPrograma(Codigo, Glosa)

    End Function
    Function modificarPrograma(ByVal Codigoviejo As String, ByVal Glosavieja As String, ByVal Codigonuevo As String, ByVal Glosanueva As String) As Boolean
        Dim programa As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)

        Return programa.modificarPrograma(Codigonuevo, Glosanueva, Codigoviejo, Glosavieja)

    End Function

    Function modificaruacademicas(ByVal Codigoviejo As String, ByVal Glosavieja As String, ByVal Codigonuevo As String, ByVal Glosanueva As String) As Boolean
        Dim programa As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)

        Return programa.modificaruacademicas(Codigonuevo, Glosanueva, Codigoviejo, Glosavieja)

    End Function

    Sub ModificarEvento(ByVal inicio As String, ByVal fin As String, ByVal dia As String, ByVal Nombre_evento As String, ByVal nrc As String, ByVal Sala_codigo As String)
        Dim horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        horario.ModificarEvento(inicio, fin, dia, Nombre_evento, nrc, Sala_codigo)


    End Sub



    Sub Eliminarevento(ByVal nrc As String)
        Dim horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        horario.eliminarEvento(nrc)


    End Sub

    Function ConsultaEvento(ByVal dia_evento, ByVal docente_evento, ByVal nrc_evento, ByVal nombre_evento) As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)

        dia_evento = Mid(dia_evento, 1, 4)
        If InStr(dia_evento.ToUpper, "LU") > 0 Then
            dia_evento = "1"
        ElseIf InStr(dia_evento.ToUpper, "MA") > 0 Then
            dia_evento = "2"
        ElseIf InStr(dia_evento.ToUpper, "MI") > 0 Then
            dia_evento = "3"
        ElseIf InStr(dia_evento.ToUpper, "JU") > 0 Then
            dia_evento = "4"
        ElseIf InStr(dia_evento.ToUpper, "VI") > 0 Then
            dia_evento = "5"
        ElseIf InStr(dia_evento.ToUpper, "SA") > 0 Then
            dia_evento = "6"
        ElseIf InStr(dia_evento.ToUpper, "DO") > 0 Then
            dia_evento = "7"
        End If
        Dim dtHorario As DataTable = Horario.ConsultarEventos(dia_evento, docente_evento, nrc_evento, nombre_evento)
        Return dtHorario
    End Function
    Function consultarsalas() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtHorario As DataTable = Horario.consultarSalas("VM")
        Return dtHorario
    End Function
    Function ConsultaHorarios() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtHorario As DataTable = Horario.consultarHorario()
        Return dtHorario
    End Function

    Function consultarunidadesacademicas() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtHorario As DataTable = Horario.ConsultarUnidadesAcademicas()
        Return dtHorario
    End Function


    Function consultarperiodo() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtprograma As DataTable = Horario.Consultarperiodos()
        Return dtprograma
    End Function

    Function consultarjornadas() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtprograma As DataTable = Horario.ConsultarJornada()
        Return dtprograma
    End Function

    Function consultarjornadascodigo() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtprograma As DataTable = Horario.consultarjornadascodigo()
        Return dtprograma
    End Function

    Function consultarDescPeriodo() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtprograma As DataTable = Horario.consultarDescPeriodo()
        Return dtprograma
    End Function

    Function consultarCodigoprogramas() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtprograma As DataTable = Horario.ConsultarcodigoPrograma()
        Return dtprograma
    End Function


    Function consultarprogramas() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtprograma As DataTable = Horario.ConsultarProgramas_unab()
        Return dtprograma
    End Function
    Function ConsultarProrgamas_descripcion() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtprograma As DataTable = Horario.ConsultarProgramas_Descripcion()
        Return dtprograma
    End Function

    Function ConsultarDocentes() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtdocente As DataTable = Horario.ConsultarDocentes()
        Return dtdocente
    End Function

    Function consultarcantidadSoloSala() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)

        Return Horario.consultarcantidadSoloSala

    End Function

    Function consultarcantidadSala() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtdocente As DataTable = Horario.consultarcantidadSala
        Return dtdocente
    End Function


    Function ConsultarTipoActividad(ByVal DESCRIPCION As String) As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtdocente As DataTable = Horario.ConsultarTipoActividad(DESCRIPCION)
        Return dtdocente
    End Function
    Function ConsultarTipoActividad() As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dtdocente As DataTable = Horario.ConsultarTipoActividad()
        Return dtdocente
    End Function

    Function salass(ByVal sede As String) As DataTable
        Dim Horario As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim dt = Horario.consultarSalas(sede)
        Return dt
    End Function
    Function consultarErrores() As DataTable
        Dim errores As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Return errores.consultarErrore()
    End Function
    Function Graficousabilidad(ByVal fechainicio As String, ByVal fechafin As String, ByVal periodo As String, ByVal programa As String, ByVal opcion As String) As DataTable
        Dim datos As New GHAU_CapaDatos.MantenedorBD(_NombreServidor_, _NombreUsuario_, _Pass_)
        Dim jornada As String = ""
        Dim DtJornada = datos.consultarJornada_programa(programa)
        If DtJornada Is Nothing Or DtJornada.Rows.Count = 0 Then
            Return Nothing
        End If
        jornada = DtJornada.Rows(0).Item(0).ToString
        Dim grafico As New DataTable
        grafico.Columns.Add("Modulo", Type.GetType("System.String"))
        grafico.Columns.Add("LUNES", Type.GetType("System.String"))
        grafico.Columns.Add("MARTES", Type.GetType("System.String"))
        grafico.Columns.Add("MIERCOLES", Type.GetType("System.String"))
        grafico.Columns.Add("JUEVES", Type.GetType("System.String"))
        grafico.Columns.Add("VIERNES", Type.GetType("System.String"))
        grafico.Columns.Add("SABADO", Type.GetType("System.String"))
        grafico.Columns.Add("DOMINGO", Type.GetType("System.String"))
        Dim min, max As Integer
        If opcion = "PERIODO" Then ' o se filtra por periodo o por dias
            Dim datosnecesarios As DataTable = datos.GraficosHorario(periodo, programa, jornada)

            min = 0
            If datosnecesarios.Rows.Count > 0 Then

1:              If InStr(jornada, "D") > min Then 'si es diurno entra aqui
                    For i = 1 To 14
                        grafico.Rows.Add()
                        grafico.Rows(grafico.Rows.Count - 1).Item(0) = i
                        grafico.Rows(grafico.Rows.Count - 1).Item(1) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(2) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(3) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(4) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(5) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(6) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(7) = 0
                    Next
                ElseIf InStr(jornada, "V") > min Then ''si es Vespertino entra aqui
                    For i = 1 To 6
                        grafico.Rows.Add()
                        grafico.Rows(grafico.Rows.Count - 1).Item(0) = i
                        grafico.Rows(grafico.Rows.Count - 1).Item(1) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(2) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(3) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(4) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(5) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(6) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(7) = 0
                    Next
                    'Else
                    '    min = min + 1
                    '    If min <= datosnecesarios.Rows.Count Then
                    '        GoTo 1
                    '    Else
                    '        GoTo 2
                    '    End If

                End If

                max = 0
                For i = 0 To datosnecesarios.Rows.Count - 1
                    Dim temp_arr_horario() As Char = datosnecesarios.Rows(i).Item(1).ToCharArray

                    For j = 0 To grafico.Rows.Count - 1
                        If temp_arr_horario(j).ToString = "1" Then
                            Dim valor = CInt(datosnecesarios.Rows(i).Item(2).ToString)
                            grafico.Rows(j).Item(CInt(datosnecesarios.Rows(i).Item(2).ToString)) = Int(grafico.Rows(j).Item(valor)) + 1

                        End If

                    Next

                Next
                min = 100
                max = 0
                For i = 0 To grafico.Rows.Count - 1
                    For j = 1 To grafico.Columns.Count - 1
                        If grafico.Rows(i).Item(j).ToString <> "0" Then
                            If min > CInt(grafico.Rows(i).Item(j).ToString) Then
                                min = CInt(grafico.Rows(i).Item(j).ToString)
                            End If
                            If max < CInt(grafico.Rows(i).Item(j).ToString) Then
                                max = CInt(grafico.Rows(i).Item(j).ToString)
                            End If
                        End If
                    Next
                Next

            Else
                'For i = 1 To 14
                '    grafico.Rows.Add()
                '    grafico.Rows(grafico.Rows.Count - 1).Item(0) = i
                '    grafico.Rows(grafico.Rows.Count - 1).Item(1) = 0
                '    grafico.Rows(grafico.Rows.Count - 1).Item(2) = 0
                '    grafico.Rows(grafico.Rows.Count - 1).Item(3) = 0
                '    grafico.Rows(grafico.Rows.Count - 1).Item(4) = 0
                '    grafico.Rows(grafico.Rows.Count - 1).Item(5) = 0
                '    grafico.Rows(grafico.Rows.Count - 1).Item(6) = 0
                '    grafico.Rows(grafico.Rows.Count - 1).Item(7) = 0
                'Next
                Return Nothing
            End If
        Else
            Dim datosnecesarios As DataTable = datos.GraficosHorario(fechainicio.ToString, fechafin.ToString, programa.ToString, jornada.ToString)

            If datosnecesarios.Rows.Count > 0 Then

                If InStr(jornada, "D") > min Then 'si es diurno entra aqui
                    For i = 1 To 14
                        grafico.Rows.Add()
                        grafico.Rows(grafico.Rows.Count - 1).Item(0) = i
                        grafico.Rows(grafico.Rows.Count - 1).Item(1) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(2) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(3) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(4) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(5) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(6) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(7) = 0
                    Next
                ElseIf InStr(jornada, "V") > min Then ''si es Vespertino entra aqui
                    For i = 1 To 6
                        grafico.Rows.Add()
                        grafico.Rows(grafico.Rows.Count - 1).Item(0) = i
                        grafico.Rows(grafico.Rows.Count - 1).Item(1) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(2) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(3) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(4) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(5) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(6) = 0
                        grafico.Rows(grafico.Rows.Count - 1).Item(7) = 0
                    Next
                               End If

                max = 0
                For i = 0 To datosnecesarios.Rows.Count - 1
                    Dim temp_arr_horario() As Char = datosnecesarios.Rows(i).Item(1).ToCharArray

                    For j = 0 To grafico.Rows.Count - 1
                        If temp_arr_horario(j).ToString = "1" Then
                            Dim valor = CInt(datosnecesarios.Rows(i).Item(2).ToString)
                            grafico.Rows(j).Item(CInt(datosnecesarios.Rows(i).Item(2).ToString)) = Int(grafico.Rows(j).Item(valor)) + 1

                        End If

                    Next

                Next
                min = 100
                max = 0
                For i = 0 To grafico.Rows.Count - 1
                    For j = 1 To grafico.Columns.Count - 1
                        If grafico.Rows(i).Item(j).ToString <> "0" Then
                            If min > CInt(grafico.Rows(i).Item(j).ToString) Then
                                min = CInt(grafico.Rows(i).Item(j).ToString)
                            End If
                            If max < CInt(grafico.Rows(i).Item(j).ToString) Then
                                max = CInt(grafico.Rows(i).Item(j).ToString)
                            End If
                        End If
                    Next
                Next

            Else
                Return Nothing
            End If








            End If
            grafico.Columns.Add("MaxMin", Type.GetType("System.String"))
            grafico.Rows(0).Item(grafico.Columns.Count - 1) = max
            grafico.Rows(1).Item(grafico.Columns.Count - 1) = min

2:
            '  Return programa.consultarHorarioFecha()
            Return grafico
    End Function


End Class


