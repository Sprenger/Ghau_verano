<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HU3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HU3))
        Me.LBL_Jornada = New System.Windows.Forms.Label
        Me.LBL_Bloque = New System.Windows.Forms.Label
        Me.CB_Docente = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.BTN_MODIFICAR = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXT_nombre_actividad = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CB_Viernes = New System.Windows.Forms.CheckBox
        Me.CB_Domingo = New System.Windows.Forms.CheckBox
        Me.CB_Sabado = New System.Windows.Forms.CheckBox
        Me.CB_Lunes = New System.Windows.Forms.CheckBox
        Me.CB_Miercoles = New System.Windows.Forms.CheckBox
        Me.CB_Jueves = New System.Windows.Forms.CheckBox
        Me.CB_Martes = New System.Windows.Forms.CheckBox
        Me.DTP_Inicio = New System.Windows.Forms.DateTimePicker
        Me.DTP_Termino = New System.Windows.Forms.DateTimePicker
        Me.BTN_Eliminar = New System.Windows.Forms.Button
        Me.CB_Sala = New System.Windows.Forms.ComboBox
        Me.LBL_dia = New System.Windows.Forms.Label
        Me.LBL_NRC = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBL_Jornada
        '
        Me.LBL_Jornada.AutoSize = True
        Me.LBL_Jornada.Location = New System.Drawing.Point(655, 67)
        Me.LBL_Jornada.Name = "LBL_Jornada"
        Me.LBL_Jornada.Size = New System.Drawing.Size(0, 13)
        Me.LBL_Jornada.TabIndex = 29
        Me.LBL_Jornada.Visible = False
        '
        'LBL_Bloque
        '
        Me.LBL_Bloque.AutoSize = True
        Me.LBL_Bloque.Location = New System.Drawing.Point(528, 67)
        Me.LBL_Bloque.Name = "LBL_Bloque"
        Me.LBL_Bloque.Size = New System.Drawing.Size(127, 13)
        Me.LBL_Bloque.TabIndex = 28
        Me.LBL_Bloque.Text = "00000000000000000000"
        Me.LBL_Bloque.Visible = False
        '
        'CB_Docente
        '
        Me.CB_Docente.AutoCompleteCustomSource.AddRange(New String() {"Chile", "Peru", "argentina"})
        Me.CB_Docente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CB_Docente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CB_Docente.FormattingEnabled = True
        Me.CB_Docente.Location = New System.Drawing.Point(661, 34)
        Me.CB_Docente.Name = "CB_Docente"
        Me.CB_Docente.Size = New System.Drawing.Size(121, 21)
        Me.CB_Docente.TabIndex = 27
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(834, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Sala"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(672, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "NombreDocente"
        '
        'BTN_MODIFICAR
        '
        Me.BTN_MODIFICAR.Location = New System.Drawing.Point(948, 18)
        Me.BTN_MODIFICAR.Name = "BTN_MODIFICAR"
        Me.BTN_MODIFICAR.Size = New System.Drawing.Size(75, 23)
        Me.BTN_MODIFICAR.TabIndex = 23
        Me.BTN_MODIFICAR.Text = "Modificar"
        Me.BTN_MODIFICAR.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(545, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Nombre Actividad"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Termino"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Inicio"
        '
        'TXT_nombre_actividad
        '
        Me.TXT_nombre_actividad.Location = New System.Drawing.Point(528, 34)
        Me.TXT_nombre_actividad.Name = "TXT_nombre_actividad"
        Me.TXT_nombre_actividad.Size = New System.Drawing.Size(127, 20)
        Me.TXT_nombre_actividad.TabIndex = 19
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CB_Viernes, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CB_Domingo, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CB_Sabado, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CB_Lunes, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CB_Miercoles, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CB_Jueves, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CB_Martes, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(168, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(354, 43)
        Me.TableLayoutPanel1.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(293, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Domingo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(243, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Sabado"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(195, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Viernes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(148, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Jueves"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(90, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Miercoles"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Martes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Lunes"
        '
        'CB_Viernes
        '
        Me.CB_Viernes.AutoSize = True
        Me.CB_Viernes.Location = New System.Drawing.Point(195, 16)
        Me.CB_Viernes.Name = "CB_Viernes"
        Me.CB_Viernes.Size = New System.Drawing.Size(15, 14)
        Me.CB_Viernes.TabIndex = 7
        Me.CB_Viernes.UseVisualStyleBackColor = True
        '
        'CB_Domingo
        '
        Me.CB_Domingo.AutoSize = True
        Me.CB_Domingo.Location = New System.Drawing.Point(293, 16)
        Me.CB_Domingo.Name = "CB_Domingo"
        Me.CB_Domingo.Size = New System.Drawing.Size(15, 14)
        Me.CB_Domingo.TabIndex = 8
        Me.CB_Domingo.UseVisualStyleBackColor = True
        '
        'CB_Sabado
        '
        Me.CB_Sabado.AutoSize = True
        Me.CB_Sabado.Location = New System.Drawing.Point(243, 16)
        Me.CB_Sabado.Name = "CB_Sabado"
        Me.CB_Sabado.Size = New System.Drawing.Size(15, 14)
        Me.CB_Sabado.TabIndex = 8
        Me.CB_Sabado.UseVisualStyleBackColor = True
        '
        'CB_Lunes
        '
        Me.CB_Lunes.AutoSize = True
        Me.CB_Lunes.Location = New System.Drawing.Point(3, 16)
        Me.CB_Lunes.Name = "CB_Lunes"
        Me.CB_Lunes.Size = New System.Drawing.Size(15, 14)
        Me.CB_Lunes.TabIndex = 2
        Me.CB_Lunes.UseVisualStyleBackColor = True
        '
        'CB_Miercoles
        '
        Me.CB_Miercoles.AutoSize = True
        Me.CB_Miercoles.Location = New System.Drawing.Point(90, 16)
        Me.CB_Miercoles.Name = "CB_Miercoles"
        Me.CB_Miercoles.Size = New System.Drawing.Size(15, 14)
        Me.CB_Miercoles.TabIndex = 5
        Me.CB_Miercoles.UseVisualStyleBackColor = True
        '
        'CB_Jueves
        '
        Me.CB_Jueves.AutoSize = True
        Me.CB_Jueves.Location = New System.Drawing.Point(148, 16)
        Me.CB_Jueves.Name = "CB_Jueves"
        Me.CB_Jueves.Size = New System.Drawing.Size(15, 14)
        Me.CB_Jueves.TabIndex = 6
        Me.CB_Jueves.UseVisualStyleBackColor = True
        '
        'CB_Martes
        '
        Me.CB_Martes.AutoSize = True
        Me.CB_Martes.Location = New System.Drawing.Point(45, 16)
        Me.CB_Martes.Name = "CB_Martes"
        Me.CB_Martes.Size = New System.Drawing.Size(15, 14)
        Me.CB_Martes.TabIndex = 4
        Me.CB_Martes.UseVisualStyleBackColor = True
        '
        'DTP_Inicio
        '
        Me.DTP_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Inicio.Location = New System.Drawing.Point(68, 18)
        Me.DTP_Inicio.Name = "DTP_Inicio"
        Me.DTP_Inicio.Size = New System.Drawing.Size(80, 20)
        Me.DTP_Inicio.TabIndex = 17
        '
        'DTP_Termino
        '
        Me.DTP_Termino.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Termino.Location = New System.Drawing.Point(68, 44)
        Me.DTP_Termino.Name = "DTP_Termino"
        Me.DTP_Termino.Size = New System.Drawing.Size(80, 20)
        Me.DTP_Termino.TabIndex = 16
        '
        'BTN_Eliminar
        '
        Me.BTN_Eliminar.Location = New System.Drawing.Point(948, 45)
        Me.BTN_Eliminar.Name = "BTN_Eliminar"
        Me.BTN_Eliminar.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Eliminar.TabIndex = 30
        Me.BTN_Eliminar.Text = "Eliminar"
        Me.BTN_Eliminar.UseVisualStyleBackColor = True
        '
        'CB_Sala
        '
        Me.CB_Sala.AutoCompleteCustomSource.AddRange(New String() {"Chile", "Peru", "argentina"})
        Me.CB_Sala.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CB_Sala.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CB_Sala.FormattingEnabled = True
        Me.CB_Sala.Location = New System.Drawing.Point(788, 34)
        Me.CB_Sala.Name = "CB_Sala"
        Me.CB_Sala.Size = New System.Drawing.Size(121, 21)
        Me.CB_Sala.TabIndex = 31
        '
        'LBL_dia
        '
        Me.LBL_dia.AutoSize = True
        Me.LBL_dia.Location = New System.Drawing.Point(162, 70)
        Me.LBL_dia.Name = "LBL_dia"
        Me.LBL_dia.Size = New System.Drawing.Size(45, 13)
        Me.LBL_dia.TabIndex = 34
        Me.LBL_dia.Text = "Label13"
        Me.LBL_dia.Visible = False
        '
        'LBL_NRC
        '
        Me.LBL_NRC.AutoSize = True
        Me.LBL_NRC.Location = New System.Drawing.Point(286, 70)
        Me.LBL_NRC.Name = "LBL_NRC"
        Me.LBL_NRC.Size = New System.Drawing.Size(45, 13)
        Me.LBL_NRC.TabIndex = 35
        Me.LBL_NRC.Text = "Label13"
        Me.LBL_NRC.Visible = False
        '
        'HU3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1227, 92)
        Me.Controls.Add(Me.LBL_NRC)
        Me.Controls.Add(Me.LBL_dia)
        Me.Controls.Add(Me.CB_Sala)
        Me.Controls.Add(Me.BTN_Eliminar)
        Me.Controls.Add(Me.LBL_Jornada)
        Me.Controls.Add(Me.LBL_Bloque)
        Me.Controls.Add(Me.CB_Docente)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BTN_MODIFICAR)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXT_nombre_actividad)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.DTP_Inicio)
        Me.Controls.Add(Me.DTP_Termino)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1243, 131)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1243, 131)
        Me.Name = "HU3"
        Me.Text = "Crear Eventos"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBL_Jornada As System.Windows.Forms.Label
    Friend WithEvents LBL_Bloque As System.Windows.Forms.Label
    Friend WithEvents CB_Docente As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BTN_MODIFICAR As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXT_nombre_actividad As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_Viernes As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Domingo As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Sabado As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Lunes As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Miercoles As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Jueves As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Martes As System.Windows.Forms.CheckBox
    Friend WithEvents DTP_Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_Termino As System.Windows.Forms.DateTimePicker
    Friend WithEvents BTN_Eliminar As System.Windows.Forms.Button
    Friend WithEvents CB_Sala As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_dia As System.Windows.Forms.Label
    Friend WithEvents LBL_NRC As System.Windows.Forms.Label
End Class
