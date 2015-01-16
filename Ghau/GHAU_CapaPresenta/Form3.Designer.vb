<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Mes = New System.Windows.Forms.MonthCalendar
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TSB_importar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.BTN_IngresoSalas = New System.Windows.Forms.ToolStripButton
        Me.BTN_Exportar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.BTN_G_Usabilidad = New System.Windows.Forms.ToolStripButton
        Me.BTN_Uso_salas = New System.Windows.Forms.ToolStripButton
        Me.GRILLA_MOSTRAR = New System.Windows.Forms.DataGridView
        Me.TV_FiltroSala = New System.Windows.Forms.TreeView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TP_Filtro = New System.Windows.Forms.TabPage
        Me.BTN_Filtrar = New System.Windows.Forms.Button
        Me.TP_Color = New System.Windows.Forms.TabPage
        Me.BTN_sala_Evento_Texto = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BTN_sala_Fija_Texto = New System.Windows.Forms.Button
        Me.BTN_sala_Fija_fondo = New System.Windows.Forms.Button
        Me.BTN_sala_Evento_fondo = New System.Windows.Forms.Button
        Me.BTN_TextoFondo = New System.Windows.Forms.Button
        Me.LBL_Evento = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.BTN_TextoAsignaturas = New System.Windows.Forms.Button
        Me.BTN_FondoAsignaturas = New System.Windows.Forms.Button
        Me.BTN_FondoEventos = New System.Windows.Forms.Button
        Me.color = New System.Windows.Forms.ColorDialog
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GRILLA_MOSTRAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TP_Filtro.SuspendLayout()
        Me.TP_Color.SuspendLayout()
        Me.SuspendLayout()
        '
        'Mes
        '
        Me.Mes.Location = New System.Drawing.Point(18, 18)
        Me.Mes.Name = "Mes"
        Me.Mes.TabIndex = 7
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSB_importar, Me.ToolStripButton3, Me.BTN_IngresoSalas, Me.BTN_Exportar, Me.ToolStripButton1, Me.ToolStripButton2, Me.BTN_G_Usabilidad, Me.BTN_Uso_salas})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1222, 25)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSB_importar
        '
        Me.TSB_importar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_importar.Image = CType(resources.GetObject("TSB_importar.Image"), System.Drawing.Image)
        Me.TSB_importar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_importar.Name = "TSB_importar"
        Me.TSB_importar.Size = New System.Drawing.Size(23, 22)
        Me.TSB_importar.Text = "Importar"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Cargar Eventos"
        '
        'BTN_IngresoSalas
        '
        Me.BTN_IngresoSalas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTN_IngresoSalas.Image = CType(resources.GetObject("BTN_IngresoSalas.Image"), System.Drawing.Image)
        Me.BTN_IngresoSalas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_IngresoSalas.Name = "BTN_IngresoSalas"
        Me.BTN_IngresoSalas.Size = New System.Drawing.Size(23, 22)
        Me.BTN_IngresoSalas.Text = "Cargar Sala"
        '
        'BTN_Exportar
        '
        Me.BTN_Exportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTN_Exportar.Image = CType(resources.GetObject("BTN_Exportar.Image"), System.Drawing.Image)
        Me.BTN_Exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Exportar.Name = "BTN_Exportar"
        Me.BTN_Exportar.Size = New System.Drawing.Size(23, 22)
        Me.BTN_Exportar.Text = "Exportar Excel"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Programa"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'BTN_G_Usabilidad
        '
        Me.BTN_G_Usabilidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTN_G_Usabilidad.Image = CType(resources.GetObject("BTN_G_Usabilidad.Image"), System.Drawing.Image)
        Me.BTN_G_Usabilidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_G_Usabilidad.Name = "BTN_G_Usabilidad"
        Me.BTN_G_Usabilidad.Size = New System.Drawing.Size(23, 22)
        Me.BTN_G_Usabilidad.Text = "Grafico General"
        '
        'BTN_Uso_salas
        '
        Me.BTN_Uso_salas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTN_Uso_salas.Image = CType(resources.GetObject("BTN_Uso_salas.Image"), System.Drawing.Image)
        Me.BTN_Uso_salas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Uso_salas.Name = "BTN_Uso_salas"
        Me.BTN_Uso_salas.Size = New System.Drawing.Size(23, 22)
        Me.BTN_Uso_salas.Text = "Grafico Uso de salas"
        '
        'GRILLA_MOSTRAR
        '
        Me.GRILLA_MOSTRAR.AllowUserToAddRows = False
        Me.GRILLA_MOSTRAR.AllowUserToDeleteRows = False
        Me.GRILLA_MOSTRAR.AllowUserToResizeColumns = False
        Me.GRILLA_MOSTRAR.AllowUserToResizeRows = False
        Me.GRILLA_MOSTRAR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRILLA_MOSTRAR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GRILLA_MOSTRAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRILLA_MOSTRAR.Location = New System.Drawing.Point(284, 28)
        Me.GRILLA_MOSTRAR.MaximumSize = New System.Drawing.Size(926, 476)
        Me.GRILLA_MOSTRAR.MinimumSize = New System.Drawing.Size(926, 476)
        Me.GRILLA_MOSTRAR.Name = "GRILLA_MOSTRAR"
        Me.GRILLA_MOSTRAR.ReadOnly = True
        Me.GRILLA_MOSTRAR.RowHeadersVisible = False
        Me.GRILLA_MOSTRAR.Size = New System.Drawing.Size(926, 476)
        Me.GRILLA_MOSTRAR.TabIndex = 9
        '
        'TV_FiltroSala
        '
        Me.TV_FiltroSala.CheckBoxes = True
        Me.TV_FiltroSala.Location = New System.Drawing.Point(6, 0)
        Me.TV_FiltroSala.Name = "TV_FiltroSala"
        Me.TV_FiltroSala.Size = New System.Drawing.Size(164, 216)
        Me.TV_FiltroSala.TabIndex = 10
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TP_Filtro)
        Me.TabControl1.Controls.Add(Me.TP_Color)
        Me.TabControl1.Location = New System.Drawing.Point(18, 183)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(243, 308)
        Me.TabControl1.TabIndex = 11
        '
        'TP_Filtro
        '
        Me.TP_Filtro.Controls.Add(Me.BTN_Filtrar)
        Me.TP_Filtro.Controls.Add(Me.TV_FiltroSala)
        Me.TP_Filtro.Location = New System.Drawing.Point(4, 22)
        Me.TP_Filtro.Name = "TP_Filtro"
        Me.TP_Filtro.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_Filtro.Size = New System.Drawing.Size(235, 282)
        Me.TP_Filtro.TabIndex = 0
        Me.TP_Filtro.Text = "Filtro"
        Me.TP_Filtro.UseVisualStyleBackColor = True
        '
        'BTN_Filtrar
        '
        Me.BTN_Filtrar.Location = New System.Drawing.Point(176, 6)
        Me.BTN_Filtrar.Name = "BTN_Filtrar"
        Me.BTN_Filtrar.Size = New System.Drawing.Size(53, 23)
        Me.BTN_Filtrar.TabIndex = 11
        Me.BTN_Filtrar.Text = "Filtrar"
        Me.BTN_Filtrar.UseVisualStyleBackColor = True
        '
        'TP_Color
        '
        Me.TP_Color.Controls.Add(Me.BTN_sala_Evento_Texto)
        Me.TP_Color.Controls.Add(Me.Label1)
        Me.TP_Color.Controls.Add(Me.Label2)
        Me.TP_Color.Controls.Add(Me.BTN_sala_Fija_Texto)
        Me.TP_Color.Controls.Add(Me.BTN_sala_Fija_fondo)
        Me.TP_Color.Controls.Add(Me.BTN_sala_Evento_fondo)
        Me.TP_Color.Location = New System.Drawing.Point(4, 22)
        Me.TP_Color.Name = "TP_Color"
        Me.TP_Color.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_Color.Size = New System.Drawing.Size(235, 282)
        Me.TP_Color.TabIndex = 1
        Me.TP_Color.Text = "Colores"
        Me.TP_Color.UseVisualStyleBackColor = True
        '
        'BTN_sala_Evento_Texto
        '
        Me.BTN_sala_Evento_Texto.Location = New System.Drawing.Point(167, 24)
        Me.BTN_sala_Evento_Texto.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_sala_Evento_Texto.Name = "BTN_sala_Evento_Texto"
        Me.BTN_sala_Evento_Texto.Size = New System.Drawing.Size(56, 28)
        Me.BTN_sala_Evento_Texto.TabIndex = 23
        Me.BTN_sala_Evento_Texto.Text = "Texto"
        Me.BTN_sala_Evento_Texto.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 35)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Salas Evento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 84)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Salas Fijas"
        '
        'BTN_sala_Fija_Texto
        '
        Me.BTN_sala_Fija_Texto.Location = New System.Drawing.Point(167, 76)
        Me.BTN_sala_Fija_Texto.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_sala_Fija_Texto.Name = "BTN_sala_Fija_Texto"
        Me.BTN_sala_Fija_Texto.Size = New System.Drawing.Size(56, 28)
        Me.BTN_sala_Fija_Texto.TabIndex = 20
        Me.BTN_sala_Fija_Texto.Text = "Texto"
        Me.BTN_sala_Fija_Texto.UseVisualStyleBackColor = True
        '
        'BTN_sala_Fija_fondo
        '
        Me.BTN_sala_Fija_fondo.Location = New System.Drawing.Point(96, 76)
        Me.BTN_sala_Fija_fondo.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_sala_Fija_fondo.Name = "BTN_sala_Fija_fondo"
        Me.BTN_sala_Fija_fondo.Size = New System.Drawing.Size(56, 28)
        Me.BTN_sala_Fija_fondo.TabIndex = 18
        Me.BTN_sala_Fija_fondo.Text = "Fondo"
        Me.BTN_sala_Fija_fondo.UseVisualStyleBackColor = True
        '
        'BTN_sala_Evento_fondo
        '
        Me.BTN_sala_Evento_fondo.Location = New System.Drawing.Point(96, 27)
        Me.BTN_sala_Evento_fondo.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_sala_Evento_fondo.Name = "BTN_sala_Evento_fondo"
        Me.BTN_sala_Evento_fondo.Size = New System.Drawing.Size(56, 28)
        Me.BTN_sala_Evento_fondo.TabIndex = 19
        Me.BTN_sala_Evento_fondo.Text = "Fondo"
        Me.BTN_sala_Evento_fondo.UseVisualStyleBackColor = True
        '
        'BTN_TextoFondo
        '
        Me.BTN_TextoFondo.Location = New System.Drawing.Point(188, 20)
        Me.BTN_TextoFondo.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_TextoFondo.Name = "BTN_TextoFondo"
        Me.BTN_TextoFondo.Size = New System.Drawing.Size(96, 28)
        Me.BTN_TextoFondo.TabIndex = 17
        Me.BTN_TextoFondo.Text = "Texto"
        Me.BTN_TextoFondo.UseVisualStyleBackColor = True
        '
        'LBL_Evento
        '
        Me.LBL_Evento.AutoSize = True
        Me.LBL_Evento.Location = New System.Drawing.Point(8, 26)
        Me.LBL_Evento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBL_Evento.Name = "LBL_Evento"
        Me.LBL_Evento.Size = New System.Drawing.Size(70, 13)
        Me.LBL_Evento.TabIndex = 16
        Me.LBL_Evento.Text = "Salas Evento"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 62)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Salas Fijas"
        '
        'BTN_TextoAsignaturas
        '
        Me.BTN_TextoAsignaturas.Location = New System.Drawing.Point(184, 55)
        Me.BTN_TextoAsignaturas.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_TextoAsignaturas.Name = "BTN_TextoAsignaturas"
        Me.BTN_TextoAsignaturas.Size = New System.Drawing.Size(96, 28)
        Me.BTN_TextoAsignaturas.TabIndex = 14
        Me.BTN_TextoAsignaturas.Text = "Texto"
        Me.BTN_TextoAsignaturas.UseVisualStyleBackColor = True
        '
        'BTN_FondoAsignaturas
        '
        Me.BTN_FondoAsignaturas.Location = New System.Drawing.Point(107, 55)
        Me.BTN_FondoAsignaturas.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_FondoAsignaturas.Name = "BTN_FondoAsignaturas"
        Me.BTN_FondoAsignaturas.Size = New System.Drawing.Size(76, 28)
        Me.BTN_FondoAsignaturas.TabIndex = 11
        Me.BTN_FondoAsignaturas.Text = "Fondo"
        Me.BTN_FondoAsignaturas.UseVisualStyleBackColor = True
        '
        'BTN_FondoEventos
        '
        Me.BTN_FondoEventos.Location = New System.Drawing.Point(107, 20)
        Me.BTN_FondoEventos.Margin = New System.Windows.Forms.Padding(4)
        Me.BTN_FondoEventos.Name = "BTN_FondoEventos"
        Me.BTN_FondoEventos.Size = New System.Drawing.Size(76, 28)
        Me.BTN_FondoEventos.TabIndex = 12
        Me.BTN_FondoEventos.Text = "Fondo"
        Me.BTN_FondoEventos.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 518)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GRILLA_MOSTRAR)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Mes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1238, 556)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1238, 556)
        Me.Name = "Form3"
        Me.Text = "Horario Unab"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GRILLA_MOSTRAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TP_Filtro.ResumeLayout(False)
        Me.TP_Color.ResumeLayout(False)
        Me.TP_Color.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Mes As System.Windows.Forms.MonthCalendar
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSB_importar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GRILLA_MOSTRAR As System.Windows.Forms.DataGridView
    Friend WithEvents TV_FiltroSala As System.Windows.Forms.TreeView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TP_Filtro As System.Windows.Forms.TabPage
    Friend WithEvents BTN_Filtrar As System.Windows.Forms.Button
    Friend WithEvents TP_Color As System.Windows.Forms.TabPage
    Friend WithEvents BTN_IngresoSalas As System.Windows.Forms.ToolStripButton
    Friend WithEvents BTN_Exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BTN_sala_Evento_Texto As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BTN_sala_Fija_Texto As System.Windows.Forms.Button
    Friend WithEvents BTN_sala_Fija_fondo As System.Windows.Forms.Button
    Friend WithEvents BTN_sala_Evento_fondo As System.Windows.Forms.Button
    Friend WithEvents BTN_TextoFondo As System.Windows.Forms.Button
    Friend WithEvents LBL_Evento As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BTN_TextoAsignaturas As System.Windows.Forms.Button
    Friend WithEvents BTN_FondoAsignaturas As System.Windows.Forms.Button
    Friend WithEvents BTN_FondoEventos As System.Windows.Forms.Button
    Friend WithEvents color As System.Windows.Forms.ColorDialog
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BTN_G_Usabilidad As System.Windows.Forms.ToolStripButton
    Friend WithEvents BTN_Uso_salas As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
End Class
