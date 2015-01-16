<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.LBL_Rut = New System.Windows.Forms.Label
        Me.BTN_Guardar = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.LBL_Nombre = New System.Windows.Forms.Label
        Me.LBL_Cargo = New System.Windows.Forms.Label
        Me.BTN_Insertar = New System.Windows.Forms.Button
        Me.TXT_Cargo = New System.Windows.Forms.TextBox
        Me.TXT_Rut = New System.Windows.Forms.TextBox
        Me.TXT_Nombre = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.GRILLA_xd = New System.Windows.Forms.DataGridView
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.GRILLA_xd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.LBL_Rut, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LBL_Rut
        '
        Me.LBL_Rut.AutoSize = True
        Me.LBL_Rut.Location = New System.Drawing.Point(3, 0)
        Me.LBL_Rut.Name = "LBL_Rut"
        Me.LBL_Rut.Size = New System.Drawing.Size(24, 13)
        Me.LBL_Rut.TabIndex = 5
        Me.LBL_Rut.Text = "Rut"
        '
        'BTN_Guardar
        '
        Me.BTN_Guardar.Location = New System.Drawing.Point(159, 58)
        Me.BTN_Guardar.Name = "BTN_Guardar"
        Me.BTN_Guardar.Size = New System.Drawing.Size(79, 23)
        Me.BTN_Guardar.TabIndex = 8
        Me.BTN_Guardar.Text = "Guardar"
        Me.BTN_Guardar.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Rut"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(159, 58)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(356, 371)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Rut"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(159, 58)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(79, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Guardar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Button3, 2, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.LBL_Nombre, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.LBL_Cargo, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.BTN_Insertar, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TXT_Cargo, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.TXT_Rut, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TXT_Nombre, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Button4, 2, 1)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(305, 100)
        Me.TableLayoutPanel4.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Rut"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(159, 61)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(79, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Guardar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'LBL_Nombre
        '
        Me.LBL_Nombre.AutoSize = True
        Me.LBL_Nombre.Location = New System.Drawing.Point(3, 29)
        Me.LBL_Nombre.Name = "LBL_Nombre"
        Me.LBL_Nombre.Size = New System.Drawing.Size(44, 13)
        Me.LBL_Nombre.TabIndex = 6
        Me.LBL_Nombre.Text = "Nombre"
        '
        'LBL_Cargo
        '
        Me.LBL_Cargo.AutoSize = True
        Me.LBL_Cargo.Location = New System.Drawing.Point(3, 58)
        Me.LBL_Cargo.Name = "LBL_Cargo"
        Me.LBL_Cargo.Size = New System.Drawing.Size(35, 13)
        Me.LBL_Cargo.TabIndex = 7
        Me.LBL_Cargo.Text = "Cargo"
        '
        'BTN_Insertar
        '
        Me.BTN_Insertar.Location = New System.Drawing.Point(159, 3)
        Me.BTN_Insertar.Name = "BTN_Insertar"
        Me.BTN_Insertar.Size = New System.Drawing.Size(79, 23)
        Me.BTN_Insertar.TabIndex = 4
        Me.BTN_Insertar.Text = "Insertar"
        Me.BTN_Insertar.UseVisualStyleBackColor = True
        '
        'TXT_Cargo
        '
        Me.TXT_Cargo.Location = New System.Drawing.Point(53, 61)
        Me.TXT_Cargo.Name = "TXT_Cargo"
        Me.TXT_Cargo.Size = New System.Drawing.Size(100, 20)
        Me.TXT_Cargo.TabIndex = 3
        '
        'TXT_Rut
        '
        Me.TXT_Rut.Location = New System.Drawing.Point(53, 3)
        Me.TXT_Rut.Name = "TXT_Rut"
        Me.TXT_Rut.Size = New System.Drawing.Size(100, 20)
        Me.TXT_Rut.TabIndex = 1
        '
        'TXT_Nombre
        '
        Me.TXT_Nombre.Location = New System.Drawing.Point(53, 32)
        Me.TXT_Nombre.Name = "TXT_Nombre"
        Me.TXT_Nombre.Size = New System.Drawing.Size(100, 20)
        Me.TXT_Nombre.TabIndex = 2
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(159, 32)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GRILLA_xd
        '
        Me.GRILLA_xd.AllowUserToAddRows = False
        Me.GRILLA_xd.AllowUserToDeleteRows = False
        Me.GRILLA_xd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GRILLA_xd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRILLA_xd.Location = New System.Drawing.Point(12, 131)
        Me.GRILLA_xd.Name = "GRILLA_xd"
        Me.GRILLA_xd.ReadOnly = True
        Me.GRILLA_xd.RowHeadersVisible = False
        Me.GRILLA_xd.Size = New System.Drawing.Size(305, 190)
        Me.GRILLA_xd.TabIndex = 11
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 333)
        Me.Controls.Add(Me.GRILLA_xd)
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.Name = "Form2"
        Me.Text = "Crear Docente"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.GRILLA_xd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LBL_Rut As System.Windows.Forms.Label
    Friend WithEvents BTN_Guardar As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents LBL_Nombre As System.Windows.Forms.Label
    Friend WithEvents LBL_Cargo As System.Windows.Forms.Label
    Friend WithEvents BTN_Insertar As System.Windows.Forms.Button
    Friend WithEvents TXT_Cargo As System.Windows.Forms.TextBox
    Friend WithEvents TXT_Rut As System.Windows.Forms.TextBox
    Friend WithEvents TXT_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents GRILLA_xd As System.Windows.Forms.DataGridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
