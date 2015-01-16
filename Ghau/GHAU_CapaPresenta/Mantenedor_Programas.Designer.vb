<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mantenedor_Programas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mantenedor_Programas))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BTN_Nuevo = New System.Windows.Forms.Button
        Me.BTN_Insertar = New System.Windows.Forms.Button
        Me.TXT_Codigo = New System.Windows.Forms.TextBox
        Me.TXT_Descripcion = New System.Windows.Forms.TextBox
        Me.Grilla_Programa = New System.Windows.Forms.DataGridView
        CType(Me.Grilla_Programa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(658, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo Programa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(658, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripcion Programa"
        '
        'BTN_Nuevo
        '
        Me.BTN_Nuevo.Location = New System.Drawing.Point(661, 131)
        Me.BTN_Nuevo.Name = "BTN_Nuevo"
        Me.BTN_Nuevo.Size = New System.Drawing.Size(134, 23)
        Me.BTN_Nuevo.TabIndex = 9
        Me.BTN_Nuevo.Text = "Nuevo"
        Me.BTN_Nuevo.UseVisualStyleBackColor = True
        '
        'BTN_Insertar
        '
        Me.BTN_Insertar.Location = New System.Drawing.Point(661, 102)
        Me.BTN_Insertar.Name = "BTN_Insertar"
        Me.BTN_Insertar.Size = New System.Drawing.Size(134, 23)
        Me.BTN_Insertar.TabIndex = 5
        Me.BTN_Insertar.Text = "Crear"
        Me.BTN_Insertar.UseVisualStyleBackColor = True
        '
        'TXT_Codigo
        '
        Me.TXT_Codigo.Location = New System.Drawing.Point(661, 28)
        Me.TXT_Codigo.MaxLength = 9
        Me.TXT_Codigo.Name = "TXT_Codigo"
        Me.TXT_Codigo.Size = New System.Drawing.Size(134, 20)
        Me.TXT_Codigo.TabIndex = 2
        '
        'TXT_Descripcion
        '
        Me.TXT_Descripcion.Location = New System.Drawing.Point(661, 76)
        Me.TXT_Descripcion.Name = "TXT_Descripcion"
        Me.TXT_Descripcion.Size = New System.Drawing.Size(134, 20)
        Me.TXT_Descripcion.TabIndex = 3
        '
        'Grilla_Programa
        '
        Me.Grilla_Programa.AllowUserToAddRows = False
        Me.Grilla_Programa.AllowUserToDeleteRows = False
        Me.Grilla_Programa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla_Programa.Location = New System.Drawing.Point(12, 12)
        Me.Grilla_Programa.MaximumSize = New System.Drawing.Size(640, 413)
        Me.Grilla_Programa.MinimumSize = New System.Drawing.Size(640, 413)
        Me.Grilla_Programa.Name = "Grilla_Programa"
        Me.Grilla_Programa.ReadOnly = True
        Me.Grilla_Programa.RowHeadersVisible = False
        Me.Grilla_Programa.Size = New System.Drawing.Size(640, 413)
        Me.Grilla_Programa.TabIndex = 3
        '
        'Mantenedor_Programas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 435)
        Me.Controls.Add(Me.BTN_Nuevo)
        Me.Controls.Add(Me.BTN_Insertar)
        Me.Controls.Add(Me.TXT_Descripcion)
        Me.Controls.Add(Me.Grilla_Programa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXT_Codigo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(843, 474)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(843, 474)
        Me.Name = "Mantenedor_Programas"
        Me.Text = "Programas"
        CType(Me.Grilla_Programa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXT_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents TXT_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents BTN_Insertar As System.Windows.Forms.Button
    Friend WithEvents BTN_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Grilla_Programa As System.Windows.Forms.DataGridView
End Class
