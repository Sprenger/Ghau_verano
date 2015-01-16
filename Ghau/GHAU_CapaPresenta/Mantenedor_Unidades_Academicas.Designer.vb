<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mantenedor_Unidades_Academicas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mantenedor_Unidades_Academicas))
        Me.BTN_Nuevo = New System.Windows.Forms.Button
        Me.BTN_Insertar = New System.Windows.Forms.Button
        Me.TXT_Descripcion = New System.Windows.Forms.TextBox
        Me.Grilla_Academicas = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXT_Codigo = New System.Windows.Forms.TextBox
        CType(Me.Grilla_Academicas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_Nuevo
        '
        Me.BTN_Nuevo.Location = New System.Drawing.Point(696, 131)
        Me.BTN_Nuevo.Name = "BTN_Nuevo"
        Me.BTN_Nuevo.Size = New System.Drawing.Size(134, 23)
        Me.BTN_Nuevo.TabIndex = 16
        Me.BTN_Nuevo.Text = "Nuevo"
        Me.BTN_Nuevo.UseVisualStyleBackColor = True
        '
        'BTN_Insertar
        '
        Me.BTN_Insertar.Location = New System.Drawing.Point(696, 102)
        Me.BTN_Insertar.Name = "BTN_Insertar"
        Me.BTN_Insertar.Size = New System.Drawing.Size(134, 23)
        Me.BTN_Insertar.TabIndex = 15
        Me.BTN_Insertar.Text = "Crear"
        Me.BTN_Insertar.UseVisualStyleBackColor = True
        '
        'TXT_Descripcion
        '
        Me.TXT_Descripcion.Location = New System.Drawing.Point(661, 76)
        Me.TXT_Descripcion.Name = "TXT_Descripcion"
        Me.TXT_Descripcion.Size = New System.Drawing.Size(192, 20)
        Me.TXT_Descripcion.TabIndex = 14
        '
        'Grilla_Academicas
        '
        Me.Grilla_Academicas.AllowUserToAddRows = False
        Me.Grilla_Academicas.AllowUserToDeleteRows = False
        Me.Grilla_Academicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla_Academicas.Location = New System.Drawing.Point(12, 12)
        Me.Grilla_Academicas.Name = "Grilla_Academicas"
        Me.Grilla_Academicas.ReadOnly = True
        Me.Grilla_Academicas.RowHeadersVisible = False
        Me.Grilla_Academicas.Size = New System.Drawing.Size(643, 482)
        Me.Grilla_Academicas.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(658, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Descripcion Unidades Academicas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(658, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Codigo Unidades Academicas"
        '
        'TXT_Codigo
        '
        Me.TXT_Codigo.Location = New System.Drawing.Point(661, 28)
        Me.TXT_Codigo.MaxLength = 9
        Me.TXT_Codigo.Name = "TXT_Codigo"
        Me.TXT_Codigo.Size = New System.Drawing.Size(192, 20)
        Me.TXT_Codigo.TabIndex = 12
        '
        'Mantenedor_Unidades_Academicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 506)
        Me.Controls.Add(Me.BTN_Nuevo)
        Me.Controls.Add(Me.BTN_Insertar)
        Me.Controls.Add(Me.TXT_Descripcion)
        Me.Controls.Add(Me.Grilla_Academicas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXT_Codigo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(881, 545)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(881, 545)
        Me.Name = "Mantenedor_Unidades_Academicas"
        Me.Text = "Mantenedor_Unidades_Academicas"
        CType(Me.Grilla_Academicas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_Nuevo As System.Windows.Forms.Button
    Friend WithEvents BTN_Insertar As System.Windows.Forms.Button
    Friend WithEvents TXT_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Grilla_Academicas As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXT_Codigo As System.Windows.Forms.TextBox
End Class
