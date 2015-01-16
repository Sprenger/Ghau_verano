<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Grafico
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Grafico))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.DTP_Inicio = New System.Windows.Forms.DateTimePicker
        Me.DTP_Fin = New System.Windows.Forms.DateTimePicker
        Me.CB_Periodo = New System.Windows.Forms.CheckBox
        Me.CB_Fecha = New System.Windows.Forms.CheckBox
        Me.Cb_Periodos = New System.Windows.Forms.ComboBox
        Me.BTN_Graficar = New System.Windows.Forms.Button
        Me.BTN_Imprimir = New System.Windows.Forms.Button
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Grilla_grafico = New System.Windows.Forms.DataGridView
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.Cb_programas = New System.Windows.Forms.ComboBox
        Me.Lbl_Programas = New System.Windows.Forms.Label
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.Grilla_grafico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 441.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CB_Periodo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CB_Fecha, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Cb_Periodos, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BTN_Graficar, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BTN_Imprimir, 2, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(559, 64)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.DTP_Inicio, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DTP_Fin, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(71, 32)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(406, 26)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'DTP_Inicio
        '
        Me.DTP_Inicio.Location = New System.Drawing.Point(3, 3)
        Me.DTP_Inicio.Name = "DTP_Inicio"
        Me.DTP_Inicio.Size = New System.Drawing.Size(197, 20)
        Me.DTP_Inicio.TabIndex = 0
        '
        'DTP_Fin
        '
        Me.DTP_Fin.Location = New System.Drawing.Point(206, 3)
        Me.DTP_Fin.Name = "DTP_Fin"
        Me.DTP_Fin.Size = New System.Drawing.Size(197, 20)
        Me.DTP_Fin.TabIndex = 1
        '
        'CB_Periodo
        '
        Me.CB_Periodo.AutoSize = True
        Me.CB_Periodo.Location = New System.Drawing.Point(3, 3)
        Me.CB_Periodo.Name = "CB_Periodo"
        Me.CB_Periodo.Size = New System.Drawing.Size(62, 17)
        Me.CB_Periodo.TabIndex = 0
        Me.CB_Periodo.Text = "Periodo"
        Me.CB_Periodo.UseVisualStyleBackColor = True
        '
        'CB_Fecha
        '
        Me.CB_Fecha.AutoSize = True
        Me.CB_Fecha.Location = New System.Drawing.Point(3, 32)
        Me.CB_Fecha.Name = "CB_Fecha"
        Me.CB_Fecha.Size = New System.Drawing.Size(56, 17)
        Me.CB_Fecha.TabIndex = 1
        Me.CB_Fecha.Text = "Fecha"
        Me.CB_Fecha.UseVisualStyleBackColor = True
        '
        'Cb_Periodos
        '
        Me.Cb_Periodos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Cb_Periodos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_Periodos.FormattingEnabled = True
        Me.Cb_Periodos.Location = New System.Drawing.Point(71, 3)
        Me.Cb_Periodos.Name = "Cb_Periodos"
        Me.Cb_Periodos.Size = New System.Drawing.Size(407, 21)
        Me.Cb_Periodos.TabIndex = 2
        '
        'BTN_Graficar
        '
        Me.BTN_Graficar.Location = New System.Drawing.Point(484, 3)
        Me.BTN_Graficar.Name = "BTN_Graficar"
        Me.BTN_Graficar.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Graficar.TabIndex = 3
        Me.BTN_Graficar.Text = "Graficar"
        Me.BTN_Graficar.UseVisualStyleBackColor = True
        '
        'BTN_Imprimir
        '
        Me.BTN_Imprimir.Location = New System.Drawing.Point(484, 32)
        Me.BTN_Imprimir.Name = "BTN_Imprimir"
        Me.BTN_Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Imprimir.TabIndex = 4
        Me.BTN_Imprimir.Text = "Imprimir"
        Me.BTN_Imprimir.UseVisualStyleBackColor = True
        Me.BTN_Imprimir.Visible = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Grilla_grafico, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(15, 12)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(764, 486)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Grilla_grafico
        '
        Me.Grilla_grafico.AllowUserToAddRows = False
        Me.Grilla_grafico.AllowUserToDeleteRows = False
        Me.Grilla_grafico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_grafico.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_grafico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_grafico.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_grafico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_grafico.Location = New System.Drawing.Point(3, 108)
        Me.Grilla_grafico.Name = "Grilla_grafico"
        Me.Grilla_grafico.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_grafico.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_grafico.RowHeadersVisible = False
        Me.Grilla_grafico.Size = New System.Drawing.Size(758, 375)
        Me.Grilla_grafico.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.Controls.Add(Me.Cb_programas, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Lbl_Programas, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 73)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(559, 29)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'Cb_programas
        '
        Me.Cb_programas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Cb_programas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_programas.FormattingEnabled = True
        Me.Cb_programas.Location = New System.Drawing.Point(66, 3)
        Me.Cb_programas.Name = "Cb_programas"
        Me.Cb_programas.Size = New System.Drawing.Size(407, 21)
        Me.Cb_programas.TabIndex = 3
        '
        'Lbl_Programas
        '
        Me.Lbl_Programas.AutoSize = True
        Me.Lbl_Programas.Location = New System.Drawing.Point(3, 0)
        Me.Lbl_Programas.Name = "Lbl_Programas"
        Me.Lbl_Programas.Size = New System.Drawing.Size(57, 13)
        Me.Lbl_Programas.TabIndex = 0
        Me.Lbl_Programas.Text = "Programas"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'Grafico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 505)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(806, 544)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(806, 544)
        Me.Name = "Grafico"
        Me.Text = "Grafico"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.Grilla_grafico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DTP_Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_Fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents CB_Periodo As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Fecha As System.Windows.Forms.CheckBox
    Friend WithEvents Cb_Periodos As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Grilla_grafico As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cb_programas As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_Programas As System.Windows.Forms.Label
    Friend WithEvents BTN_Graficar As System.Windows.Forms.Button
    Friend WithEvents BTN_Imprimir As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
