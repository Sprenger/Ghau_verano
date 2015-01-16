Imports GHAU_CapaNegocio

Public Class evento
    Private CB_dias As String
    Sub Crear()
        If TXT_nombre_actividad.Text <> "" Then
            Dim ingresar As New GHAU_CapaNegocio.Eventos

            'Dim consu = ingresar.consultarExiste(LBL_Bloque.Text, LBL_sala.Text, Mid(CB_dias, 1, CB_dias.Length - 3) & ")")
            If Not ingresar.consultarExiste(LBL_Bloque.Text, LBL_sala.Text, Mid(CB_dias, 1, CB_dias.Length - 3) & ")") Is Nothing Then
                Dim result As Integer = MessageBox.Show("Hay Choque con otros horarios, " & vbNewLine & "Desea agregar de todos modos?, esto creara choque de horarios", "caption", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    GoTo 3
                End If
            End If

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

                ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & LBL_sala.Text, LBL_Bloque.Text, _
                                       nrc, DateTime.Now(), "", CB_Docente.Text)
            End If
            If CB_Martes.Checked = True Then
                dias = "2"
                ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & LBL_sala.Text, LBL_Bloque.Text, _
                                          nrc, DateTime.Now(), "", CB_Docente.Text)
            End If
            If CB_Miercoles.Checked = True Then
                dias = "3"
                ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & LBL_sala.Text, LBL_Bloque.Text, _
                                            nrc, DateTime.Now(), "", CB_Docente.Text)
            End If
            If CB_Jueves.Checked = True Then
                dias = "4"
                ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & LBL_sala.Text, LBL_Bloque.Text, _
                                           nrc, DateTime.Now(), "", CB_Docente.Text)
            End If
            If CB_Viernes.Checked = True Then
                dias = "5"
                ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & LBL_sala.Text, LBL_Bloque.Text, _
                                             nrc, DateTime.Now(), "", CB_Docente.Text)
            End If
            If CB_Sabado.Checked = True Then
                dias = "6"
                ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & LBL_sala.Text, LBL_Bloque.Text, _
                                         nrc, DateTime.Now(), "", CB_Docente.Text)
            End If
            If CB_Domingo.Checked = True Then
                dias = "7"
                ingresar.Ingreso_M_Eventos(CStr(Me.DTP_Inicio.Value), CStr(Me.DTP_Termino.Value), dias, TXT_nombre_actividad.Text, "VM-" & LBL_sala.Text, LBL_Bloque.Text, _
                                                        nrc, DateTime.Now(), "", CB_Docente.Text)
            End If


            Dim dia = 1
            If Mid(LBL_dia.Text.ToUpper, 1, 2) = "LU" And CB_Lunes.Checked = True Then
                llenado(nrc)
            ElseIf Mid(LBL_dia.Text.ToUpper, 1, 2) = "MA" And CB_Martes.Checked = True Then
                llenado(nrc)
            ElseIf Mid(LBL_dia.Text.ToUpper, 1, 2) = "MI" And CB_Miercoles.Checked = True Then
                llenado(nrc)
            ElseIf Mid(LBL_dia.Text.ToUpper, 1, 2) = "JU" And CB_Jueves.Checked = True Then
                llenado(nrc)
            ElseIf Mid(LBL_dia.Text.ToUpper, 1, 2) = "VI" And CB_Viernes.Checked = True Then
                llenado(nrc)
            ElseIf Mid(LBL_dia.Text.ToUpper, 1, 2) = "SA" And CB_Sabado.Checked = True Then
                llenado(nrc)
            ElseIf Mid(LBL_dia.Text.ToUpper, 1, 2) = "DO" And CB_Domingo.Checked = True Then
                llenado(nrc)

            End If
            'Dim k = 1 + 1

        End If

2:

        Me.Close()
3:




    End Sub

    Public Sub llenado(ByVal NRC_actual As String) 'llena grilla
        Dim temp_arr_horario() As Char = LBL_Bloque.Text.ToCharArray
        Dim a = Form3.xinicio
        Dim b = Form3.Mes.DataBindings.ToString
        '   For I = 0 To temp_arr_horario.Length - 1

        For i = CInt(Form3.xinicio) To CInt(Form3.xfin)
            Form3.GRILLA_MOSTRAR.Rows(i).Cells(CInt(Form3.yinicio)).Value = NRC_actual
            Form3.GRILLA_MOSTRAR.Rows(i).Cells(CInt(Form3.yinicio)).ToolTipText = NRC_actual & vbNewLine & " " & vbNewLine & "EVENTO" & vbNewLine & TXT_nombre_actividad.Text.ToString.ToUpper & vbNewLine & CB_Docente.Text.ToString.ToUpper

        Next

    End Sub


    Private Sub evento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CB_Docente.Items.Clear()
        CB_Docente.DataSource = Form3.datatableDocente
        CB_Docente.DisplayMember = Form3.datatableDocente.Columns(1).ColumnName.ToString
        CB_Docente.SelectedIndex = 0
        DTP_Inicio.Value = FormatDateTime(Form3.Mes.SelectionStart, DateFormat.ShortDate)
        Me.CB_Docente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        'Recorrer y cargar los items para el Autocompletado



    End Sub

    Private Sub DTP_Inicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Inicio.ValueChanged
        If String.Format(DTP_Termino.Value.ToShortDateString) < String.Format(DTP_Inicio.Value.ToShortDateString) Then
            DTP_Termino.Value = DTP_Inicio.Value
        End If
    End Sub

    Private Sub DTP_Termino_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Termino.ValueChanged
        If String.Format(DTP_Termino.Value.ToShortDateString) < String.Format(DTP_Inicio.Value.ToShortDateString) Then
            DTP_Inicio.Value = DTP_Termino.Value
        End If
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
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Crear()
    End Sub
End Class