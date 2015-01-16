Public Class Grafico
    Dim dtprograma As New GHAU_CapaNegocio.Negocio
    Dim dataperiodo As DataTable = dtprograma.consultarDescPeriodo
    Dim dataprograma As DataTable = dtprograma.consultarCodigoprogramas
    Private Sub CB_Fecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Fecha.CheckedChanged
        If CB_Fecha.Checked = True Then
            CB_Periodo.Checked = False
            Cb_Periodos.Enabled = False
            DTP_Fin.Enabled = True
            DTP_Inicio.Enabled = True
        End If
    End Sub

    Private Sub CB_Periodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Periodo.CheckedChanged
        If CB_Periodo.Checked = True Then
            CB_Fecha.Checked = False
            DTP_Inicio.Enabled = False
            DTP_Fin.Enabled = False
            Cb_Periodos.Enabled = True
        End If
    End Sub

    Private Sub Grafico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CB_Periodo.Checked = True
        'Cb_Periodos.DataSource = Nothing
        'Cb_Periodos.DataSource = dataperiodo

        Cb_Periodos.Items.Clear()
        Cb_Periodos.DataSource = dataperiodo
        Cb_Periodos.DisplayMember = dataperiodo.Columns(0).ColumnName.ToString
        Cb_Periodos.SelectedIndex = 0
        Me.Cb_Periodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList


        
        Cb_programas.Items.Clear()
        Cb_programas.DataSource = dataprograma
        Cb_programas.DisplayMember = dataprograma.Columns(0).ColumnName.ToString
        Cb_programas.SelectedIndex = 0


        Me.Cb_programas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
       

    End Sub
    Private Sub DTP_Inicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Inicio.ValueChanged
        If String.Format(DTP_Fin.Value.ToShortDateString) < String.Format(DTP_Inicio.Value.ToShortDateString) Then
            DTP_Fin.Value = DTP_Inicio.Value
        End If
    End Sub

    Private Sub DTP_Termino_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Fin.ValueChanged
        If String.Format(DTP_Fin.Value.ToShortDateString) < String.Format(DTP_Inicio.Value.ToShortDateString) Then
            DTP_Inicio.Value = DTP_Fin.Value
        End If
    End Sub
    Dim max, min As String
    Private Sub BTN_Graficar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Graficar.Click
        BTN_Imprimir.Visible = False
        If CB_Fecha.Checked Then

            Dim inicio As String = DTP_Inicio.Value.ToString
            Dim DATOGRAFICO = dtprograma.Graficousabilidad(DTP_Inicio.Value.ToString, DTP_Fin.Value.ToString, "", Cb_programas.Text, "Fecha")
            If Not DATOGRAFICO Is Nothing Then
                Dim MyView As DataView = New DataView(DATOGRAFICO)

                Grilla_grafico.DataSource = MyView.ToTable(True, DATOGRAFICO.Columns(0).ColumnName.ToString, DATOGRAFICO.Columns(1).ColumnName.ToString, DATOGRAFICO.Columns(2).ColumnName.ToString, DATOGRAFICO.Columns(3).ColumnName.ToString, DATOGRAFICO.Columns(4).ColumnName.ToString, DATOGRAFICO.Columns(5).ColumnName.ToString, DATOGRAFICO.Columns(6).ColumnName.ToString)

                max = DATOGRAFICO.Rows(0).Item(8).ToString
                min = DATOGRAFICO.Rows(1).Item(8).ToString
            Else
                Grilla_grafico.DataSource = Nothing
            End If
        Else
            Dim DATOGRAFICO = dtprograma.Graficousabilidad("0", "0", Cb_Periodos.Text, Cb_programas.Text, "PERIODO")
            Dim MyView As DataView = New DataView(DATOGRAFICO)
            If Not DATOGRAFICO Is Nothing Then
                Grilla_grafico.DataSource = MyView.ToTable(True, DATOGRAFICO.Columns(0).ColumnName.ToString, DATOGRAFICO.Columns(1).ColumnName.ToString, DATOGRAFICO.Columns(2).ColumnName.ToString, DATOGRAFICO.Columns(3).ColumnName.ToString, DATOGRAFICO.Columns(4).ColumnName.ToString, DATOGRAFICO.Columns(5).ColumnName.ToString, DATOGRAFICO.Columns(6).ColumnName.ToString)

                max = DATOGRAFICO.Rows(0).Item(8).ToString
                min = DATOGRAFICO.Rows(1).Item(8).ToString
            Else
                Grilla_grafico.DataSource = Nothing
            End If

            End If
            If Not max = 0 Then
                modificar(CInt(max), CInt(min))
            End If

    End Sub
    Sub modificar(ByVal maximo As Integer, ByVal minimo As Integer)
        Dim medio = CInt(((maximo - minimo) / 2).ToString)

        For i = 0 To Grilla_grafico.Rows.Count - 1
            BTN_Imprimir.Visible = True
            Grilla_grafico.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            For j = 1 To Grilla_grafico.Columns.Count - 1
                Grilla_grafico.Columns(j).SortMode = DataGridViewColumnSortMode.NotSortable


                If Not CInt(Grilla_grafico.Rows(i).Cells(j).Value) = 0 Then

                    Grilla_grafico.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    If CInt(Grilla_grafico.Rows(i).Cells(j).Value) = maximo Then
                        Grilla_grafico.Rows(i).Cells(j).Style.BackColor = Color.FromArgb(255, 0, 0)
                    ElseIf CInt(Grilla_grafico.Rows(i).Cells(j).Value) = minimo Then
                        Grilla_grafico.Rows(i).Cells(j).Style.BackColor = Color.FromArgb(0, 0, 255)
                    ElseIf CInt(Grilla_grafico.Rows(i).Cells(j).Value) = medio Then
                        Grilla_grafico.Rows(i).Cells(j).Style.BackColor = Color.FromArgb(255, 255, 0)
                    Else
                        If CInt(Grilla_grafico.Rows(i).Cells(j).Value) > medio Then

                            Dim nuevocolor As Integer = (maximo - CInt(Grilla_grafico.Rows(i).Cells(j).Value)) * (255 / (maximo - medio))
                            Grilla_grafico.Rows(i).Cells(j).Style.BackColor = Color.FromArgb(255, 0 + nuevocolor, 0)
                        Else

                            Dim nuevocolor As Integer = (CInt(Grilla_grafico.Rows(i).Cells(j).Value) - minimo) * (255 / (medio - minimo))

                            Grilla_grafico.Rows(i).Cells(j).Style.BackColor = Color.FromArgb(0, nuevocolor, 255 - nuevocolor)


                        End If
                    End If
                End If
            Next
        Next
        Grilla_grafico.ClearSelection()

    End Sub

    Private Sub BTN_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Imprimir.Click
        '        Dim p As Pen = New Pen(Brushes.Black, 2.5F)
        'e.graphics.fillrectangle(brushes.darkgray, new rectangle(100,100,dt.columns(0).width.dt.rows(0).height)
        'e.graphics.drawsrectangle(p, new rectangle(100,100,dt.columns(0).with,dt.rows(0).height)
        PrintDocument1.Print()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.Grilla_grafico.Width, Me.Grilla_grafico.Height)
        Grilla_grafico.DrawToBitmap(bm, New Rectangle(0, 0, Me.Grilla_grafico.Width, Me.Grilla_grafico.Height))
        e.Graphics.DrawImage(bm, 0, 0)

    End Sub
End Class