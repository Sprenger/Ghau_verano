<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HU21
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HU21))
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.Label2 = New System.Windows.Forms.Label
        Me.BTN_Abrir = New System.Windows.Forms.Button
        Me.Cargar_Evento = New System.Windows.Forms.Button
        Me.BTN_Limpiar = New System.Windows.Forms.Button
        Me.Txt_Ruta = New System.Windows.Forms.TextBox
        Me.Grilla_Ex = New System.Windows.Forms.DataGridView
        Me.Grilla_dx = New System.Windows.Forms.DataGridView
        Me.LBL_Error = New System.Windows.Forms.Label
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.Grilla_Ex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grilla_dx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Grilla_Ex, 0, 1)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.07026!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.92974!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(907, 427)
        Me.TableLayoutPanel5.TabIndex = 8
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
        Me.TableLayoutPanel6.Controls.Add(Me.BTN_Abrir, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Cargar_Evento, 3, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.BTN_Limpiar, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Txt_Ruta, 1, 0)
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(655, 36)
        Me.TableLayoutPanel6.TabIndex = 5
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
        'BTN_Abrir
        '
        Me.BTN_Abrir.Location = New System.Drawing.Point(353, 3)
        Me.BTN_Abrir.Name = "BTN_Abrir"
        Me.BTN_Abrir.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Abrir.TabIndex = 1
        Me.BTN_Abrir.Text = "Abrir"
        Me.BTN_Abrir.UseVisualStyleBackColor = True
        '
        'Cargar_Evento
        '
        Me.Cargar_Evento.Location = New System.Drawing.Point(434, 3)
        Me.Cargar_Evento.Name = "Cargar_Evento"
        Me.Cargar_Evento.Size = New System.Drawing.Size(75, 23)
        Me.Cargar_Evento.TabIndex = 2
        Me.Cargar_Evento.Text = "Guardar"
        Me.Cargar_Evento.UseVisualStyleBackColor = True
        '
        'BTN_Limpiar
        '
        Me.BTN_Limpiar.Location = New System.Drawing.Point(515, 3)
        Me.BTN_Limpiar.Name = "BTN_Limpiar"
        Me.BTN_Limpiar.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Limpiar.TabIndex = 3
        Me.BTN_Limpiar.Text = "Limpiar"
        Me.BTN_Limpiar.UseVisualStyleBackColor = True
        '
        'Txt_Ruta
        '
        Me.Txt_Ruta.Location = New System.Drawing.Point(61, 3)
        Me.Txt_Ruta.Name = "Txt_Ruta"
        Me.Txt_Ruta.Size = New System.Drawing.Size(286, 20)
        Me.Txt_Ruta.TabIndex = 4
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
        Me.Grilla_Ex.Location = New System.Drawing.Point(3, 46)
        Me.Grilla_Ex.Name = "Grilla_Ex"
        Me.Grilla_Ex.ReadOnly = True
        Me.Grilla_Ex.RowHeadersVisible = False
        Me.Grilla_Ex.Size = New System.Drawing.Size(901, 378)
        Me.Grilla_Ex.TabIndex = 4
        '
        'Grilla_dx
        '
        Me.Grilla_dx.AllowUserToAddRows = False
        Me.Grilla_dx.AllowUserToDeleteRows = False
        Me.Grilla_dx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla_dx.Location = New System.Drawing.Point(679, 58)
        Me.Grilla_dx.Name = "Grilla_dx"
        Me.Grilla_dx.ReadOnly = True
        Me.Grilla_dx.RowHeadersVisible = False
        Me.Grilla_dx.Size = New System.Drawing.Size(240, 381)
        Me.Grilla_dx.TabIndex = 9
        '
        'LBL_Error
        '
        Me.LBL_Error.AutoSize = True
        Me.LBL_Error.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Error.Location = New System.Drawing.Point(738, 15)
        Me.LBL_Error.Name = "LBL_Error"
        Me.LBL_Error.Size = New System.Drawing.Size(111, 33)
        Me.LBL_Error.TabIndex = 10
        Me.LBL_Error.Text = "Errores"
        '
        'HU21
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 454)
        Me.Controls.Add(Me.LBL_Error)
        Me.Controls.Add(Me.Grilla_dx)
        Me.Controls.Add(Me.TableLayoutPanel5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(947, 493)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(947, 493)
        Me.Name = "HU21"
        Me.Text = "Importar Eventos"
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.Grilla_Ex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grilla_dx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Grilla_Ex As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BTN_Abrir As System.Windows.Forms.Button
    Friend WithEvents Cargar_Evento As System.Windows.Forms.Button
    Friend WithEvents BTN_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Txt_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Grilla_dx As System.Windows.Forms.DataGridView
    Friend WithEvents LBL_Error As System.Windows.Forms.Label
End Class
