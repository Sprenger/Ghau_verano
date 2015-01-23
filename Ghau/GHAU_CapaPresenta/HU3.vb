Public Class HU3
    Public nrc_ultimo As String
    Private Sub HU3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGADOR_iNICIO()
    End Sub
    Sub CARGADOR_INICIO()
        Try
            CB_Docente.DataSource = Form3.datatableDocente
            CB_Docente.DisplayMember = Form3.datatableDocente.Columns(1).ColumnName.ToString
            Dim dt As New GHAU_CapaNegocio.Negocio
            Dim datos = dt.consultarHorario(Form3.GRILLA_MOSTRAR.Rows(CInt(Form3.xinicio)).Cells(CInt(Form3.yfin)).Value)
            'Dim p = Form3.dt_docente.Rows(0).Item(8).ToString
            CB_Docente.Text = datos.Rows(0).Item(25).ToString
            TXT_nombre_actividad.Text = datos.Rows(0).Item(19).ToString
            CB_Sala.DataSource = Form3.datatablesalas
            CB_Sala.DisplayMember = Form3.datatablesalas.Columns(1).ColumnName.ToString
            CB_Sala.Text = datos.Rows(0).Item(8).ToString
            DTP_Inicio.Value = CDate(datos.Rows(0).Item(17).ToString)
            DTP_Termino.Value = CDate(datos.Rows(0).Item(18).ToString)
            LBL_Bloque.Text = datos.Rows(0).Item(13).ToString
            LBL_NRC.Text = datos.Rows(0).Item(3).ToString

            For i = 0 To datos.Rows.Count - 1
                If datos.Rows(i).Item(1) = "1" Then
                    CB_Lunes.CheckState = CheckState.Checked
                ElseIf datos.Rows(i).Item(1) = "2" Then
                    CB_Martes.CheckState = CheckState.Checked
                ElseIf datos.Rows(i).Item(1) = "3" Then
                    CB_Miercoles.CheckState = CheckState.Checked

                ElseIf datos.Rows(i).Item(1) = "4" Then
                    CB_Miercoles.CheckState = CheckState.Checked
                ElseIf datos.Rows(i).Item(1) = "5" Then
                    CB_Miercoles.CheckState = CheckState.Checked
                ElseIf datos.Rows(i).Item(1) = "6" Then
                    CB_Miercoles.CheckState = CheckState.Checked
                ElseIf datos.Rows(i).Item(1) = "7" Then
                    CB_Miercoles.CheckState = CheckState.Checked

                End If

            Next


        Catch ex As Exception

        End Try
    End Sub

    Dim dias As String = ""
    Private Sub BTN_MODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_MODIFICAR.Click


        'Dim ingresoevento As New GHAU_CapaNegocio.Negocio

        'If CB_Lunes.Checked = True Then
        '    dias = "1"
        'End If
        'If CB_Martes.Checked = True Then
        '    dias = "2"
        'End If
        'If CB_Miercoles.Checked = True Then
        '    dias = "3"
        'End If
        'If CB_Jueves.Checked = True Then
        '    dias = "4"
        'End If
        'If CB_Viernes.Checked = True Then
        '    dias = "5"
        'End If
        'If CB_Sabado.Checked = True Then
        '    dias = "6"
        'End If
        'If CB_Domingo.Checked = True Then
        '    dias = "7"

        'End If
        'llenado()
        'Dim FechaForm = FormatDateTime(Form3.Mes.SelectionStart, DateFormat.ShortDate)
        'Dim FechaInicio = String.Format(DTP_Inicio.Value.ToShortDateString)
        'Dim fechaFin = String.Format(DTP_Termino.Value.ToShortDateString)

        'ingresoevento.ModificarEvento(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text.ToUpper, Form3.dtevento.Rows(0).Item(3).ToString, CB_Sala.Text)
        ''CStr(Me.DTP_Inicio.Value)
        'Form3.GRILLA_MOSTRAR.ClearSelection()
        'Me.Close()

        eliminar(LBL_NRC.Text)
        Crear()
        GHAU_CapaPresenta.Form3.cargar((FormatDateTime(Form3.Mes.SelectionStart, DateFormat.LongDate)), True)
        Me.Close()



    End Sub
    Private CB_dias As String
    Sub eliminar(ByVal nrc As String)
        Dim EVENTO_ELIMINAR As New GHAU_CapaNegocio.Eventos
        EVENTO_ELIMINAR.eliminarEvento(nrc)
    End Sub
    Private Sub CB_Lunes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Lunes.CheckedChanged
        If CB_Lunes.Checked = True Then
            If CB_dias = "" Then
                CB_dias = " (dia='1' or "
            Else
                CB_dias = CB_dias & " dia ='1' or "
            End If
        Else
            If CB_dias <> "" Then
                CB_dias = Replace(CB_dias, " dia ='1' or ", "")
            End If
        End If
    End Sub

    Private Sub CB_Ma(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Martes.CheckedChanged
        If CB_Martes.Checked = True Then
            If CB_dias = "" Then
                CB_dias = " (dia='2' or "
            Else
                CB_dias = CB_dias & " dia ='2' or"
            End If
        Else
            If CB_dias <> "" Then
                CB_dias = Replace(CB_dias, " dia ='2' or ", "")
            End If
        End If
    End Sub

    Private Sub CB_Mi(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Miercoles.CheckedChanged
        If CB_Miercoles.Checked = True Then
            If CB_dias = "" Then
                CB_dias = " (dia='3' or "
            Else
                CB_dias = CB_dias & " dia ='3' or"
            End If
        Else
            If CB_dias <> "" Then
                CB_dias = Replace(CB_dias, " dia ='3' or ", "")
            End If
        End If
    End Sub
    Private Sub CB_Ju(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Jueves.CheckedChanged
        If CB_Jueves.Checked = True Then
            If CB_dias = "" Then
                CB_dias = " (dia='4' or "
            Else
                CB_dias = CB_dias & " dia ='4' or"
            End If
        Else
            If CB_dias <> "" Then
                CB_dias = Replace(CB_dias, " dia ='4' or ", "")
            End If
        End If
    End Sub

    Private Sub CB_vi(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Viernes.CheckedChanged
        If CB_Lunes.Checked = True Then
            If CB_dias = "" Then
                CB_dias = " (dia='5' or "
            Else
                CB_dias = CB_dias & " dia ='5' or"
            End If
        Else
            If CB_dias <> "" Then
                CB_dias = Replace(CB_dias, " dia ='5' or ", "")
            End If
        End If
    End Sub

    Private Sub CB_sa(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Sabado.CheckedChanged
        If CB_Sabado.Checked = True Then
            If CB_dias = "" Then
                CB_dias = " (dia='6' or "
            Else
                CB_dias = CB_dias & " dia ='6' or"
            End If
        Else
            If CB_dias <> "" Then
                CB_dias = Replace(CB_dias, " dia ='6' or ", "")
            End If
        End If
    End Sub

    Private Sub CB_Do(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Domingo.CheckedChanged
        If CB_Domingo.Checked = True Then
            If CB_dias = "" Then
                CB_dias = " (dia='7' or "
            Else
                CB_dias = CB_dias & " dia ='7' or"
            End If
        Else
            If CB_dias <> "" Then
                CB_dias = Replace(CB_dias, " dia ='7' or ", "")
            End If
        End If
    End Sub
    Sub Crear()



        If TXT_nombre_actividad.Text <> "" Then
            Dim ingresar As New GHAU_CapaNegocio.Eventos
            Dim tep_dia As String = " en los dias "
            Dim bandera_Lunes As Boolean = True
            Dim bandera_Ma As Boolean = True
            Dim bandera_Mi As Boolean = True
            Dim bandera_Ju As Boolean = True

            Dim bandera_vi As Boolean = True
            Dim bandera_sa As Boolean = True
            Dim bandera_do As Boolean = True


            Dim consu = ingresar.consultarExiste(LBL_Bloque.Text, CB_Sala.Text, Mid(CB_dias, 1, CB_dias.Length - 3) & ")")
            If Not consu Is Nothing Then
                For i = 0 To consu.Rows.Count - 1
                    If consu.Rows(i).Item(1).ToString = "1" And bandera_Lunes Then
                        tep_dia = tep_dia & " LUNES " & ", "
                        bandera_Lunes = False

                    ElseIf consu.Rows(i).Item(1).ToString = "2" And bandera_Ma Then
                        tep_dia = tep_dia & " MARTES " & ", "
                        bandera_Ma = False
                    ElseIf consu.Rows(i).Item(1).ToString = "3" And bandera_Mi Then
                        tep_dia = tep_dia & " MIERCOLES " & ", "
                        bandera_Mi = False

                    ElseIf consu.Rows(i).Item(1).ToString = "4" And bandera_Ju Then
                        tep_dia = tep_dia & " JUEVES " & ", "
                        bandera_Ju = False

                    ElseIf consu.Rows(i).Item(1).ToString = "5" And bandera_vi Then
                        tep_dia = tep_dia & " VIERNES " & ", "
                        bandera_vi = False

                    ElseIf consu.Rows(i).Item(1).ToString = "6" And bandera_sa Then
                        tep_dia = tep_dia & " SABADO " & ", "
                        bandera_sa = False

                    ElseIf consu.Rows(i).Item(1).ToString = "7" And bandera_do Then
                        tep_dia = tep_dia & " DOMINGO " & ", "
                        bandera_Mi = False
                    Else

                    End If
                Next
                tep_dia = Mid(tep_dia, 1, tep_dia.Length - 2)
                Dim result As Integer = MessageBox.Show("Hay Choque" & tep_dia & vbNewLine & "Desea agregar de todos modos?, esto creara choque de horarios", "caption", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    GoTo 3
                ElseIf result = DialogResult.Yes Then

4:

                    Dim dt_Sala As New GHAU_CapaDatos.Salas

                    Dim ingresoevento As New GHAU_CapaNegocio.ImportarHorario

                    Dim dias As String = ""
                    Dim dt_eventoNRC = ingresar.ConsultarEventos("EVENTO", "curso_materia", "MAX(nrc)")
                    Dim NRC_evento = Split(dt_eventoNRC.Rows(0).Item(0).ToString, "-")
                    Dim nrc As String
                    If NRC_evento.Length = 1 Then
                        nrc = "EV-0"
                    Else
                        nrc = NRC_evento(0) & "-" & (CInt(NRC_evento(1).ToString) + 1)

                    End If
                    If CB_Lunes.Checked = True Then
                        dias = "1"

                        ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & CB_Sala.Text, LBL_Bloque.Text, _
                                               nrc, DateTime.Now(), "", CB_Docente.Text)
                    End If
                    If CB_Martes.Checked = True Then
                        dias = "2"
                        ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & CB_Sala.Text, LBL_Bloque.Text, _
                                                  nrc, DateTime.Now(), "", CB_Docente.Text)
                    End If
                    If CB_Miercoles.Checked = True Then
                        dias = "3"
                        ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & CB_Sala.Text, LBL_Bloque.Text, _
                                                    nrc, DateTime.Now(), "", CB_Docente.Text)
                    End If
                    If CB_Jueves.Checked = True Then
                        dias = "4"
                        ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & CB_Sala.Text, LBL_Bloque.Text, _
                                                   nrc, DateTime.Now(), "", CB_Docente.Text)
                    End If
                    If CB_Viernes.Checked = True Then
                        dias = "5"
                        ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & CB_Sala.Text, LBL_Bloque.Text, _
                                                     nrc, DateTime.Now(), "", CB_Docente.Text)
                    End If
                    If CB_Sabado.Checked = True Then
                        dias = "6"
                        ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & CB_Sala.Text, LBL_Bloque.Text, _
                                                 nrc, DateTime.Now(), "", CB_Docente.Text)
                    End If
                    If CB_Domingo.Checked = True Then
                        dias = "7"
                        ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & CB_Sala.Text, LBL_Bloque.Text, _
                                                                nrc, DateTime.Now(), "", CB_Docente.Text)
                    End If



                    'Dim k = 1 + 1

                End If
            Else
                Dim eliminar As New GHAU_CapaNegocio.Eventos
                eliminar.eliminarEvento(LBL_NRC.Text)

                GoTo 4

2:
            End If
            GHAU_CapaPresenta.Form3.cargar((FormatDateTime(Form3.Mes.SelectionStart, DateFormat.LongDate)), True)
            Me.Close()

3:


        End If 'end if consu.rows

    End Sub

    Public Sub llenado() 'llena grilla
        Dim temp_arr_horario() As Char = Form3.dtevento.Rows(0).Item(0).ToString.ToCharArray
        Dim diaAnterior = Form3.dtevento.Rows(0).Item(1).ToString
        If diaAnterior = dias Then
            For I = 0 To temp_arr_horario.Length - 1
                If temp_arr_horario(I) = "1" Then
                    Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).Value = Form3.dtevento.Rows(0).Item(3)
                    Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).ToolTipText = Form3.dtevento.Rows(0).Item(3) & vbNewLine & " " & vbNewLine & "EVENTO" & vbNewLine & TXT_nombre_actividad.Text.ToString.ToUpper & vbNewLine & CB_Docente.Text & vbNewLine & " "
                End If
            Next
        Else
            For I = 0 To temp_arr_horario.Length - 1
                If temp_arr_horario(I) = "1" Then
                    Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).Value = " "
                    Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).ToolTipText = " "
                End If
            Next

        End If
    End Sub

    Private Sub BTN_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Eliminar.Click

        'Dim eliminar As New GHAU_CapaNegocio.Negocio
        'eliminar.Eliminarevento(Form3.GRILLA_MOSTRAR.Rows(Form3.xinicio).Cells(Form3.yfin).Value)
        ''CStr(Me.DTP_Inicio.Value)
        ''Dim temp_arr_horario() As Char = Form3.dtevento.Rows(0).Item(0).ToString.ToCharArray
        'Dim a = Form3.GRILLA_MOSTRAR.Rows(CInt(Form3.xinicio)).Cells(CInt(Form3.yinicio)).ToolTipText
        'For I = 0 To Form3.GRILLA_MOSTRAR.Rows.Count - 1
        '    If Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).Value = Form3.GRILLA_MOSTRAR.Rows(CInt(Form3.xinicio)).Cells(CInt(Form3.yinicio)).Value Then
        '        Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).Value = " "
        '        Form3.GRILLA_MOSTRAR.Rows(I).Cells(CInt(Form3.yinicio)).ToolTipText = " "

        '    End If

        'Next
        'Form3.GRILLA_MOSTRAR.ClearSelection()
        'Me.Close()

        eliminar(LBL_NRC.Text)
        GHAU_CapaPresenta.Form3.cargar((FormatDateTime(Form3.Mes.SelectionStart, DateFormat.LongDate)), True)
        Me.Close()
    End Sub
End Class