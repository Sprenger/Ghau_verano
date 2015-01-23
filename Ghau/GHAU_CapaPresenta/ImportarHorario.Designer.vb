<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarHorario
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarHorario))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Lbl_Direccion = New System.Windows.Forms.Label
        Me.BTN_Abrir = New System.Windows.Forms.Button
        Me.Grilla_Ex = New System.Windows.Forms.DataGridView
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Grilla_Excel = New System.Windows.Forms.DataGridView
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.BTN_Save = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Txt_Ruta = New System.Windows.Forms.TextBox
        Me.BTN_Validar = New System.Windows.Forms.Button
        Me.Grilla_error = New System.Windows.Forms.DataGridView
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Grilla_Ex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.Grilla_Excel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Grilla_error, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_Direccion, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Lbl_Direccion
        '
        Me.Lbl_Direccion.AutoSize = True
        Me.Lbl_Direccion.Location = New System.Drawing.Point(3, 0)
        Me.Lbl_Direccion.Name = "Lbl_Direccion"
        Me.Lbl_Direccion.Size = New System.Drawing.Size(52, 13)
        Me.Lbl_Direccion.TabIndex = 0
        Me.Lbl_Direccion.Text = "Direccion"
        '
        'BTN_Abrir
        '
        Me.BTN_Abrir.Location = New System.Drawing.Point(395, 3)
        Me.BTN_Abrir.Name = "BTN_Abrir"
        Me.BTN_Abrir.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Abrir.TabIndex = 1
        Me.BTN_Abrir.Text = "Abrir"
        Me.BTN_Abrir.UseVisualStyleBackColor = True
        '
        'Grilla_Ex
        '
        Me.Grilla_Ex.AllowUserToAddRows = False
        Me.Grilla_Ex.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Ex.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grilla_Ex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Ex.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grilla_Ex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla_Ex.Location = New System.Drawing.Point(0, 0)
        Me.Grilla_Ex.Name = "Grilla_Ex"
        Me.Grilla_Ex.ReadOnly = True
        Me.Grilla_Ex.RowHeadersVisible = False
        Me.Grilla_Ex.Size = New System.Drawing.Size(931, 454)
        Me.Grilla_Ex.TabIndex = 6
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 6
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Direccion"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(353, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Abrir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Grilla_Excel
        '
        Me.Grilla_Excel.AllowUserToAddRows = False
        Me.Grilla_Excel.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grilla_Excel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grilla_Excel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grilla_Excel.DefaultCellStyle = DataGridViewCellStyle4
        Me.Grilla_Excel.Location = New System.Drawing.Point(3, 46)
        Me.Grilla_Excel.Name = "Grilla_Excel"
        Me.Grilla_Excel.ReadOnly = True
        Me.Grilla_Excel.RowHeadersVisible = False
        Me.Grilla_Excel.Size = New System.Drawing.Size(916, 378)
        Me.Grilla_Excel.TabIndex = 6
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BTN_Save, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button3, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Txt_Ruta, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BTN_Validar, 5, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(746, 36)
        Me.TableLayoutPanel2.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Direccion"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(353, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Abrir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BTN_Save
        '
        Me.BTN_Save.Location = New System.Drawing.Point(434, 3)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Save.TabIndex = 2
        Me.BTN_Save.Text = "Guardar"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(515, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Cancelar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Txt_Ruta
        '
        Me.Txt_Ruta.Location = New System.Drawing.Point(61, 3)
        Me.Txt_Ruta.Name = "Txt_Ruta"
        Me.Txt_Ruta.Size = New System.Drawing.Size(286, 20)
        Me.Txt_Ruta.TabIndex = 4
        '
        'BTN_Validar
        '
        Me.BTN_Validar.Location = New System.Drawing.Point(596, 3)
        Me.BTN_Validar.Name = "BTN_Validar"
        Me.BTN_Validar.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Validar.TabIndex = 5
        Me.BTN_Validar.Text = "Validar"
        Me.BTN_Validar.UseVisualStyleBackColor = True
        '
        'Grilla_error
        '
        Me.Grilla_error.AllowUserToAddRows = False
        Me.Grilla_error.AllowUserToDeleteRows = False
        Me.Grilla_error.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla_error.Location = New System.Drawing.Point(630, 45)
        Me.Grilla_error.Name = "Grilla_error"
        Me.Grilla_error.ReadOnly = True
        Me.Grilla_error.RowHeadersVisible = False
        Me.Grilla_error.Size = New System.Drawing.Size(289, 379)
        Me.Grilla_error.TabIndex = 9
        Me.Grilla_error.Visible = False
        '
        'ImportarHorario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 454)
        Me.Controls.Add(Me.Grilla_error)
        Me.Controls.Add(Me.Grilla_Excel)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(947, 493)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(947, 493)
        Me.Name = "ImportarHorario"
        Me.Text = "Importar Horario"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Grilla_Ex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.Grilla_Excel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.Grilla_error, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Lbl_Direccion As System.Windows.Forms.Label
    Friend WithEvents BTN_Abrir As System.Windows.Forms.Button
    Friend WithEvents Grilla_Ex As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Grilla_Excel As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BTN_Save As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Txt_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents BTN_Validar As System.Windows.Forms.Button
    Friend WithEvents Grilla_error As System.Windows.Forms.DataGridView

End Class
