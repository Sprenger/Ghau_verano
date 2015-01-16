Imports GHAU_CapaNegocio.Excel
Imports GHAU_CapaDatos.BaseDato
Imports GHAU_CapaNegocio.Negocio
Imports GHAU_CapaNegocio.VariablesFijas
Public Class Form3

    Public nombre_servidor, usuario, pass As String
    Dim datatable As New GHAU_CapaNegocio.ImportarHorario
    Public dt_docente As DataTable
    Private grilla_horario As DataTable = datatable.Cargar_Horario()
    Private dthorario As New GHAU_CapaNegocio.Negocio
    Public datatablehorarios As DataTable = dthorario.ConsultaHorarios
    Public datatableDocente As DataTable = dthorario.ConsultarDocentes
    Public datatableActividades As DataTable = dthorario.ConsultaHorarios
    Public datatablesalas As DataTable = dthorario.consultarsalas
    Public dtnodosSalas As DataTable = dthorario.salass("VM")
    Public dtprogramas As DataTable = dthorario.consultarprogramas
    Public dtunidaesAcademicas As DataTable = dthorario.consultarunidadesacademicas
    Public Dt_eventos As DataTable
    Public dtevento As DataTable
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_form3()
    End Sub

    Dim DIASELECCIONADO As String
    Dim dtGrilla As DataTable
    Public Sub cargar(ByVal dia As String, ByVal FORZADO As Boolean)
        If Not DIASELECCIONADO = dia Or FORZADO Then
            Dim dtfijo As DataTable = grilla_horario.Copy
            Dim dt = datatable.horario(dia, FormatDateTime(Mes.SelectionStart, DateFormat.ShortDate))
            dtGrilla = datatable.MaatchHorario(dtfijo, dt)
            GRILLA_MOSTRAR.DataSource = dtGrilla.Copy
            GRILLA_MOSTRAR.Columns(0).Frozen = True
            GRILLA_MOSTRAR.Columns(1).Frozen = True
            For i = 0 To GRILLA_MOSTRAR.RowCount - 1
                For j = 1 To GRILLA_MOSTRAR.ColumnCount - 1
                    If InStr(GRILLA_MOSTRAR.Rows(i).Cells(j).Value.ToString, "++") > 0 Then
                        'Dim c = Replace(GRILLA_MOSTRAR.Rows(i).Cells(j).Value, "/", vbNewLine)
                        GRILLA_MOSTRAR.Rows(i).Cells(j).ToolTipText = Replace(GRILLA_MOSTRAR.Rows(i).Cells(j).Value.ToString.ToUpper, "++", vbNewLine)
                        Dim DATOS = Split(GRILLA_MOSTRAR.Rows(i).Cells(j).Value.ToString.ToUpper, "++")
                        GRILLA_MOSTRAR.Rows(i).Cells(j).Value = DATOS(0) 'Replace(GRILLA_MOSTRAR.Rows(i).Cells(j).Value, "/", vbNewLine)

                    End If
                    GRILLA_MOSTRAR.ColumnHeadersHeight = 55
                Next
                GRILLA_MOSTRAR.Rows(i).Height = 23
            Next
            DIASELECCIONADO = dia
        End If

    End Sub

    Dim checkednodes As New List(Of TreeNode)()


    Private Sub TV_FiltroSala_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV_FiltroSala.AfterCheck
        RemoveHandler TV_FiltroSala.AfterCheck, AddressOf TV_FiltroSala_AfterCheck
        Call CheckAllChildNodes(e.Node)

        If e.Node.Checked Then
            If e.Node.Parent Is Nothing = False Then
                Dim allChecked As Boolean = True
                Call IsEveryChildChecked(e.Node.Parent, allChecked)
                If allChecked Then
                    e.Node.Parent.Checked = True
                    Call ShouldParentsBeChecked(e.Node.Parent)
                End If
            End If
        Else
            Dim parentNode As TreeNode = e.Node.Parent
            While parentNode Is Nothing = False
                parentNode.Checked = False
                parentNode = parentNode.Parent
            End While
        End If

        AddHandler TV_FiltroSala.AfterCheck, AddressOf TV_FiltroSala_AfterCheck
    End Sub
    Private Sub CheckAllChildNodes(ByVal parentNode As TreeNode)
        For Each childNode As TreeNode In parentNode.Nodes
            childNode.Checked = parentNode.Checked
            CheckAllChildNodes(childNode)
        Next
    End Sub

    Private Sub IsEveryChildChecked(ByVal parentNode As TreeNode, ByRef checkValue As Boolean)
        For Each node As TreeNode In parentNode.Nodes
            Call IsEveryChildChecked(node, checkValue)
            If Not node.Checked Then
                checkValue = False
            End If
        Next
    End Sub

    Private Sub ShouldParentsBeChecked(ByVal startNode As TreeNode)
        If startNode.Parent Is Nothing = False Then
            Dim allChecked As Boolean = True
            Call IsEveryChildChecked(startNode.Parent, allChecked)
            If allChecked Then
                startNode.Parent.Checked = True
                Call ShouldParentsBeChecked(startNode.Parent)
            End If
        End If
    End Sub

    Private Sub BTN_Filtrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Filtrar.Click
        Dim nodes As TreeNodeCollection = TV_FiltroSala.Nodes
        For i = 2 To GRILLA_MOSTRAR.Columns.Count - 1
            GRILLA_MOSTRAR.Columns(i).Visible = False
        Next
        'Se recorren los nodos principales
        For Each n As TreeNode In nodes
            'Se Declara un metodo para que recorra los hijos de los principales
            'Y los hijos de los hijos....Recorrido Total en pocas palabras
            'Para ello se envía el nodo actual para evaluar si tiene hijos
            RecorrerNodos(n)
        Next
    End Sub
    Private Sub RecorrerNodos(ByVal treeNode As TreeNode)
        Try
            'Si el nodo que recibimos tiene hijos se recorrerá
            'para luego verificar si esta o no checado
            For Each tn As TreeNode In treeNode.Nodes
                'Se Verifica si esta marcado...
                If tn.Checked = True Then
                    'Si esta marcado mostramos el texto del nodo
                    For i = 2 To GRILLA_MOSTRAR.Columns.Count - 1
                        Dim infosala = Split(GRILLA_MOSTRAR.Columns(i).HeaderText, vbNewLine)
                        If Replace(infosala(0).ToString, " ", "") = tn.Text.Trim Then
                            GRILLA_MOSTRAR.Columns(i).Visible = True
                            Exit For
                        End If
                    Next
                End If

                RecorrerNodos(tn)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TSB_importar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_importar.Click
        ImportarHorario.Show()
    End Sub

    Private Sub BTN_IngresoSalas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_IngresoSalas.Click
        importar_sala.Show()
    End Sub


    Dim opcion As New ContextMenuStrip
    Dim x, y As Integer

    Private Sub Grilla_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GRILLA_MOSTRAR.MouseClick

        x = e.X
        y = e.Y

    End Sub
    Public yinicio, xfin, xinicio, yfin As Integer

    Private Sub GRILLA_MOSTRAR_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GRILLA_MOSTRAR.CellMouseUp
        If e.Button <> Windows.Forms.MouseButtons.Right Then

            If e.ColumnIndex >= 2 And e.RowIndex >= 0 Then

                xfin = e.RowIndex
                yfin = e.ColumnIndex
                ' xxxxxx.Text = xfin
                If xinicio > xfin Then
                    Dim temp As Integer = xinicio
                    xinicio = xfin
                    xfin = temp

                End If
                For i = xinicio To xfin
                    Dim s = GRILLA_MOSTRAR.Rows(i).Cells(e.ColumnIndex).ToolTipText
                    If Not String.IsNullOrEmpty(s) Then
                        If GRILLA_MOSTRAR.Rows(i).Cells(e.ColumnIndex).Value.ToString = "" Then

                            'If InStr(GRILLA_MOSTRAR.Rows(i).Cells(e.ColumnIndex).Value.ToString.ToUpper, "EV") = 0 Then
                            If InStr(GRILLA_MOSTRAR.Rows(i).Cells(e.ColumnIndex).ToolTipText.ToUpper, "EVENTO") = 0 Then
                                GRILLA_MOSTRAR.ClearSelection()
                                Exit For
                            End If

                            'End If
                        End If
                    End If
                Next
            Else

                GRILLA_MOSTRAR.ClearSelection()
            End If
        End If

    End Sub

    Private Sub BTN_Exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Exportar.Click
        TransformarGrilla(GRILLA_MOSTRAR, grilla_horario, FormatDateTime(Me.Mes.SelectionStart, DateFormat.LongDate))
    End Sub

    Private Sub Mes_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles Mes.DateSelected
        cargar(FormatDateTime(Me.Mes.SelectionStart, DateFormat.LongDate), False) 'CStr(Me.Mes.SelectionRange.Start)
        '
        GRILLA_MOSTRAR.Focus()
    End Sub


    Private Sub TransformarGrilla(ByVal grilla_mostrar As DataGridView, ByVal grilla_horario As DataTable, ByVal dia As String)
        Dim dt As New DataTable
        Dim contador As Integer = 0
        For j = 0 To grilla_mostrar.Columns.Count - 1
            If grilla_mostrar.Columns(j).Visible = True Then
                dt.Columns.Add(grilla_mostrar.Columns(j).Name, Type.GetType("System.String"))
                For i = 0 To grilla_mostrar.RowCount - 1
                    If j = 0 Then
                        dt.Rows.Add()
                    End If
                    If grilla_mostrar.Rows(i).Cells(j).ToolTipText <> "" Then
                        dt.Rows(i).Item(j - contador) = Replace(grilla_mostrar.Rows(i).Cells(j).ToolTipText, vbNewLine, "++")
                    Else
                        dt.Rows(i).Item(j - contador) = grilla_mostrar.Rows(i).Cells(j).Value.ToString
                    End If


                Next
            Else
                contador = contador + 1
            End If
        Next

        Dim exportar As New GHAU_CapaNegocio.Excel
        exportar.Exportar(dt, dia) 'FormatDateTime(Me.Mes.SelectionStart, DateFormat.LongDate)
    End Sub


    Private Sub BTN_sala_Fija_fondo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_sala_Fija_fondo.Click
        If color.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            For i = 0 To GRILLA_MOSTRAR.Rows.Count - 1
                For j = 2 To GRILLA_MOSTRAR.Columns.Count - 1
                    If GRILLA_MOSTRAR.Rows(i).Cells(j).Value.ToString.ToUpper <> "" Then
                        Dim BuscaEvento() = Split(GRILLA_MOSTRAR.Rows(i).Cells(j).ToolTipText.ToUpper, vbNewLine)

                        If Not InStr(BuscaEvento(2).ToString.ToUpper, "EV") <> 0 Then
                            GRILLA_MOSTRAR.Rows(i).Cells(j).Style.BackColor = color.Color
                        End If
                    End If
                Next

            Next

        End If
    End Sub

    Private Sub BTN_sala_Fija_Texto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_sala_Fija_Texto.Click

        If color.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            For i = 0 To GRILLA_MOSTRAR.Rows.Count - 1
                For j = 2 To GRILLA_MOSTRAR.Columns.Count - 1
                    If GRILLA_MOSTRAR.Rows(i).Cells(j).Value.ToString.ToUpper <> "" Then
                        Dim BuscaEvento() = Split(GRILLA_MOSTRAR.Rows(i).Cells(j).ToolTipText.ToUpper, vbNewLine)

                        If Not InStr(BuscaEvento(2).ToString.ToUpper, "EV") <> 0 Then
                            GRILLA_MOSTRAR.Rows(i).Cells(j).Style.ForeColor = color.Color
                        End If
                    End If
                Next

            Next

        End If

    End Sub

    Private Sub BTN_sala_Evento_Texto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_sala_Evento_Texto.Click
        If color.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            For i = 0 To GRILLA_MOSTRAR.Rows.Count - 1
                For j = 3 To GRILLA_MOSTRAR.Columns.Count - 1
                    If GRILLA_MOSTRAR.Rows(i).Cells(j).Value.ToString.ToUpper <> "" Then
                        Dim BuscaEvento() = Split(GRILLA_MOSTRAR.Rows(i).Cells(j).ToolTipText.ToUpper, vbNewLine)
                        If InStr(BuscaEvento(2).ToString.ToUpper, "EV") <> 0 Then
                            GRILLA_MOSTRAR.Rows(i).Cells(j).Style.ForeColor = color.Color
                        End If
                    End If
                Next

            Next

        End If
    End Sub
    Private Sub BTN_sala_fondo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_sala_Evento_fondo.Click
        If color.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            For i = 0 To GRILLA_MOSTRAR.Rows.Count - 1
                For j = 3 To GRILLA_MOSTRAR.Columns.Count - 1
                    If GRILLA_MOSTRAR.Rows(i).Cells(j).Value.ToString.ToUpper <> "" Then
                        Dim BuscaEvento() = Split(GRILLA_MOSTRAR.Rows(i).Cells(j).ToolTipText.ToUpper, vbNewLine)
                        If InStr(BuscaEvento(2).ToString.ToUpper, "EV") <> 0 Then
                            GRILLA_MOSTRAR.Rows(i).Cells(j).Style.BackColor = color.Color
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    '+++++++++++++++++++++++++++++++++++++++++++++++++++

    Private Sub Grilla_Horarios_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
    Handles GRILLA_MOSTRAR.CellMouseDown
        grilla_mouse_down(e)
    End Sub
    Private Sub Grilla_Horarios_CellMouseUp(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) _
    Handles GRILLA_MOSTRAR.CellMouseUp
        grilla_mouse_up(e)
    End Sub


    Private Sub Grilla_Horarios_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles GRILLA_MOSTRAR.MouseUp
        menucontextual(e)
    End Sub

    Private Sub grilla_mouse_down(ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        yinicio = e.ColumnIndex.ToString
        If e.Button <> Windows.Forms.MouseButtons.Right Then
            xfin = 0
            xinicio = 0
            If e.ColumnIndex >= 4 And e.RowIndex >= 0 Then
                xinicio = e.RowIndex.ToString
                yinicio = e.ColumnIndex.ToString
            Else
                GRILLA_MOSTRAR.ClearSelection()
            End If
        End If
    End Sub

    Private Sub menucontextual(ByVal e As MouseEventArgs)
        If (xinicio >= 0) Then

            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
            Dim a = GRILLA_MOSTRAR.SelectedCells.Count
            Dim banderaLibre As Boolean = True
            'im banderalibre As  = 1 'se encarga de decir si esta vacio o no el arreglo
            Dim contador As Integer = 0 ' la cantidad total de vueltas que da en el ciclo for debe ser igual a (xfin-xinicio), de lo contrario salio una vez y existe algun ramo entremedio
            'si la bandera sale false = muestra solo modificar asignatura
            'si la bandera sale true = muestra solo nuevo evento
            'ordena el xincio como menor y el xfin el mayor
            If CInt(xinicio) > CInt(xfin) Then
                Dim temp_fin = xinicio ' variable temporal que sirve para guardar variable inicio para poder pasarsela a xfin y ordenarlas
                xinicio = xfin
                xfin = temp_fin

            End If
            For i = CInt(xinicio) + 1 To CInt(xfin)
                'If (i + 1) <= CInt(xfin) Then
                Dim aaa = GRILLA_MOSTRAR.Rows(i).Cells(CInt(yfin)).ToolTipText
                If GRILLA_MOSTRAR.Rows(i).Cells(CInt(yfin)).Value.ToString <> GRILLA_MOSTRAR.Rows(i - 1).Cells(CInt(yfin)).Value.ToString Then
                    GRILLA_MOSTRAR.ClearSelection()
                    GoTo b
                    ' End If
                End If
            Next
            For i = CInt(xinicio) To CInt(xfin)
                '  If (Grilla_Horarios.Rows(i).Cells(yfin).Value Is Nothing) OrElse (Grilla_Horarios.Rows(i).Cells(yfin).Value.ToString Is DBNull.Value) Then
                If GRILLA_MOSTRAR.Rows(i).Cells(CInt(yfin)).Value.ToString = "" Then
                    banderaLibre = True 'significa que la celda esta vacia y puede agregarse un evento hay

                ElseIf InStr(GRILLA_MOSTRAR.Rows(i).Cells(CInt(yfin)).ToolTipText.ToUpper, "EVENTO") > 0 Then

                    ' hay asignatura, no puede agregarse evento, pero puede modificarse asignatura
                    banderaLibre = False
                End If
            Next
            Dim cms = New ContextMenuStrip
            If banderaLibre Then 'And contador = (CInt(xfin) - CInt(xinicio)) Then
                Dim item1 = cms.Items.Add("Agregar Evento")
                item1.Tag = 1
                AddHandler item1.Click, AddressOf menuChoice
            Else
                Dim item2 = cms.Items.Add("Modificar")
                item2.Tag = 2
                AddHandler item2.Click, AddressOf menuChoice

            End If


            '-- etc
            '..
            cms.Show(GRILLA_MOSTRAR, e.Location)
        End If
b:
    End Sub

    Private Sub grilla_mouse_up(ByVal e As DataGridViewCellMouseEventArgs)
        If e.Button <> Windows.Forms.MouseButtons.Right Then
            yfin = e.ColumnIndex
            If e.ColumnIndex >= 2 And e.RowIndex >= 0 And yinicio = e.ColumnIndex Then
                xfin = e.RowIndex
                yfin = e.ColumnIndex
            Else
                GRILLA_MOSTRAR.ClearSelection()
            End If
        End If
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)

        Select Case selection
            Case 1
                Dim sala = (Mid(grilla_horario.Columns(Int(yinicio)).ColumnName, 1, InStr(grilla_horario.Columns(Int(yinicio)).ColumnName, vbNewLine)))
                Dim nombresala = Split(grilla_horario.Columns(Int(yinicio)).ColumnName, vbNewLine)
                Dim dia = Mid(FormatDateTime(Mes.SelectionStart, DateFormat.LongDate), 1, 2)
                If dia.ToString.ToUpper = "LU" Then
                    evento.CB_Lunes.CheckState = CheckState.Checked
                ElseIf dia.ToString.ToUpper = "MA" Then
                    evento.CB_Martes.CheckState = CheckState.Checked
                ElseIf dia.ToString.ToUpper = "MI" Then
                    evento.CB_Miercoles.CheckState = CheckState.Checked
                ElseIf dia.ToString.ToUpper = "JU" Then
                    evento.CB_Jueves.CheckState = CheckState.Checked
                ElseIf dia.ToString.ToUpper = "VI" Then
                    evento.CB_Viernes.CheckState = CheckState.Checked
                ElseIf dia.ToString.ToUpper = "DO" Then
                    evento.CB_Domingo.CheckState = CheckState.Checked
                Else
                    evento.CB_Sabado.CheckState = CheckState.Checked
                End If
                evento.TXT_Sala.Text = Mid(sala.ToUpper, 1, sala.Length - 1)
                If xinicio < 14 Then
                    evento.LBL_Jornada.Text = "DIURNO"
                Else
                    evento.LBL_Jornada.Text = "VESPERTINO"
                End If
                Dim temp_arr_horario() As Char = evento.LBL_Bloque.Text.ToCharArray
                For k = CInt(xinicio) To CInt(xfin)
                    temp_arr_horario(k) = "1"
                Next
                Dim bloque As String = ""
                For k = 0 To temp_arr_horario.Length - 1
                    bloque = bloque & temp_arr_horario(k)
                Next
                evento.LBL_Bloque.Text = bloque
                evento.LBL_sala.Text = nombresala(0)
                evento.LBL_dia.Text = FormatDateTime(Me.Mes.SelectionStart, DateFormat.LongDate)

                evento.Show()


            Case 2
                Dim evento = Split(GRILLA_MOSTRAR.Rows(xinicio).Cells(yinicio).ToolTipText, vbNewLine)

                'Dim dia = FormatDateTime(Me.Mes.SelectionStart, DateFormat.LongDate)
                Dt_eventos = dthorario.ConsultaEvento(FormatDateTime(Me.Mes.SelectionStart, DateFormat.LongDate), evento(4).ToString, evento(0).ToString, evento(3).ToString.ToUpper)

                HU3.Show()


        End Select

    End Sub

    Public Sub cargar_form3()
        Dim MyView As DataView = New DataView(dtnodosSalas)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, dtnodosSalas.Columns(3).ColumnName.ToString, dtnodosSalas.Columns(1).ColumnName.ToString)
        TV_FiltroSala.Nodes.Add("TODAS LAS SALAS")
        TV_FiltroSala.Nodes(0).Nodes.Add("Salas")
        TV_FiltroSala.Nodes(0).Nodes.Add("Otros")
        For J = 0 To dtSinDuplicados.Rows.Count - 1
            Dim encontrar = dtSinDuplicados.Rows(J).Item(1)
            If InStr(Replace(encontrar.ToString.ToUpper, " ", ""), "SAL") > 0 Then
                TV_FiltroSala.Nodes(0).Nodes(0).Nodes.Add(encontrar.ToString.ToUpper)
            Else
                TV_FiltroSala.Nodes(0).Nodes(1).Nodes.Add(encontrar.ToString.ToUpper)
            End If
        Next
        'GRILLA_MOSTRAR.DataSource = grilla_horario
        cargar(Mid(FormatDateTime(Mes.SelectionStart, DateFormat.LongDate), 1, 2).ToUpper, False)


    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Mantenedor_Programas.Show()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Mantenedor_Unidades_Academicas.Show()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_G_Usabilidad.Click
        G_Usabilidad.Show()
    End Sub

    Private Sub BTN_Uso_salas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Uso_salas.Click
        Grafico.Show()
    End Sub

    Private Sub ToolStripButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        HU21.Show()
    End Sub


End Class