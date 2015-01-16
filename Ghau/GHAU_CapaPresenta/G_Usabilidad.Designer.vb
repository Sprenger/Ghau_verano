<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class G_Usabilidad
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(G_Usabilidad))
        Me.Lbl_Fecha = New System.Windows.Forms.Label
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.DTP_Inicio = New System.Windows.Forms.DateTimePicker
        Me.DTP_Termino = New System.Windows.Forms.DateTimePicker
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.BTN_Generar = New System.Windows.Forms.Button
        Me.BTN_Imprimir = New System.Windows.Forms.Button
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.LbL_Jornada = New System.Windows.Forms.Label
        Me.Cb_Jornada = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.CB_ConEvento = New System.Windows.Forms.CheckBox
        Me.CB_SinEvento = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_Fecha
        '
        Me.Lbl_Fecha.AutoSize = True
        Me.Lbl_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Fecha.Location = New System.Drawing.Point(3, 0)
        Me.Lbl_Fecha.Name = "Lbl_Fecha"
        Me.Lbl_Fecha.Size = New System.Drawing.Size(54, 20)
        Me.Lbl_Fecha.TabIndex = 1
        Me.Lbl_Fecha.Text = "Fecha"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.DTP_Inicio, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DTP_Termino, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(190, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(456, 26)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'DTP_Inicio
        '
        Me.DTP_Inicio.Location = New System.Drawing.Point(3, 3)
        Me.DTP_Inicio.Name = "DTP_Inicio"
        Me.DTP_Inicio.Size = New System.Drawing.Size(222, 20)
        Me.DTP_Inicio.TabIndex = 0
        '
        'DTP_Termino
        '
        Me.DTP_Termino.CustomFormat = "dd MMM yyyy"
        Me.DTP_Termino.Location = New System.Drawing.Point(231, 3)
        Me.DTP_Termino.Name = "DTP_Termino"
        Me.DTP_Termino.Size = New System.Drawing.Size(222, 20)
        Me.DTP_Termino.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 462.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Fecha, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(649, 34)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 655.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Chart1, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel6, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel5, 1, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(12, 2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1181, 415)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'Chart1
        '
        ChartArea1.AxisX.Interval = 1
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.TableLayoutPanel3.SetColumnSpan(Me.Chart1, 2)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(3, 96)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine
        Series1.IsXValueIndexed = True
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.YValuesPerPoint = 4
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(1175, 319)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.BTN_Generar, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.BTN_Imprimir, 1, 0)
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(658, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(520, 34)
        Me.TableLayoutPanel6.TabIndex = 5
        '
        'BTN_Generar
        '
        Me.BTN_Generar.Location = New System.Drawing.Point(3, 3)
        Me.BTN_Generar.Name = "BTN_Generar"
        Me.BTN_Generar.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Generar.TabIndex = 7
        Me.BTN_Generar.Text = "Generar"
        Me.BTN_Generar.UseVisualStyleBackColor = True
        '
        'BTN_Imprimir
        '
        Me.BTN_Imprimir.Location = New System.Drawing.Point(263, 3)
        Me.BTN_Imprimir.Name = "BTN_Imprimir"
        Me.BTN_Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Imprimir.TabIndex = 8
        Me.BTN_Imprimir.Text = "Imprimir"
        Me.BTN_Imprimir.UseVisualStyleBackColor = True
        Me.BTN_Imprimir.Visible = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.LbL_Jornada, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Cb_Jornada, 1, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 43)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(222, 47)
        Me.TableLayoutPanel4.TabIndex = 5
        '
        'LbL_Jornada
        '
        Me.LbL_Jornada.AutoSize = True
        Me.LbL_Jornada.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbL_Jornada.Location = New System.Drawing.Point(3, 0)
        Me.LbL_Jornada.Name = "LbL_Jornada"
        Me.LbL_Jornada.Size = New System.Drawing.Size(67, 20)
        Me.LbL_Jornada.TabIndex = 2
        Me.LbL_Jornada.Text = "Jornada"
        '
        'Cb_Jornada
        '
        Me.Cb_Jornada.FormattingEnabled = True
        Me.Cb_Jornada.Items.AddRange(New Object() {"Todos", "Diurno", "Vespertino"})
        Me.Cb_Jornada.Location = New System.Drawing.Point(114, 3)
        Me.Cb_Jornada.Name = "Cb_Jornada"
        Me.Cb_Jornada.Size = New System.Drawing.Size(105, 21)
        Me.Cb_Jornada.TabIndex = 3
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.CB_ConEvento, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.CB_SinEvento, 0, 1)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(658, 43)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(202, 47)
        Me.TableLayoutPanel5.TabIndex = 6
        '
        'CB_ConEvento
        '
        Me.CB_ConEvento.AutoSize = True
        Me.CB_ConEvento.Location = New System.Drawing.Point(3, 3)
        Me.CB_ConEvento.Name = "CB_ConEvento"
        Me.CB_ConEvento.Size = New System.Drawing.Size(82, 17)
        Me.CB_ConEvento.TabIndex = 0
        Me.CB_ConEvento.Text = "Con Evento"
        Me.CB_ConEvento.UseVisualStyleBackColor = True
        '
        'CB_SinEvento
        '
        Me.CB_SinEvento.AutoSize = True
        Me.CB_SinEvento.Location = New System.Drawing.Point(3, 26)
        Me.CB_SinEvento.Name = "CB_SinEvento"
        Me.CB_SinEvento.Size = New System.Drawing.Size(78, 17)
        Me.CB_SinEvento.TabIndex = 1
        Me.CB_SinEvento.Text = "Sin Evento"
        Me.CB_SinEvento.UseVisualStyleBackColor = True
        '
        'G_Usabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1205, 435)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1221, 474)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1221, 474)
        Me.Name = "G_Usabilidad"
        Me.Text = "Grafico Usabilidad"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lbl_Fecha As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DTP_Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_Termino As System.Windows.Forms.DateTimePicker
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LbL_Jornada As System.Windows.Forms.Label
    Friend WithEvents Cb_Jornada As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CB_ConEvento As System.Windows.Forms.CheckBox
    Friend WithEvents CB_SinEvento As System.Windows.Forms.CheckBox
    Friend WithEvents BTN_Generar As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BTN_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
End Class
