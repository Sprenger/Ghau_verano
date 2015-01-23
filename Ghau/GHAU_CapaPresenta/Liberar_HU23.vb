Public Class Liberar_HU23

    Private Sub Liberar_HU23_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGADOR_iNICIO()
    End Sub

    Sub CARGADOR_iNICIO()
        Dim xd As New GHAU_CapaNegocio.funciones
        Dim dt As New GHAU_CapaNegocio.Negocio
        Dim datos = dt.consultarHorario(Form3.GRILLA_MOSTRAR.Rows(CInt(Form3.xinicio)).Cells(CInt(Form3.yfin)).Value)

        TextBox1.Text = datos.Rows(0).Item(3).ToString
        TextBox2.Text = CDate(datos.Rows(0).Item(17).ToString)
        TextBox3.Text = CDate(datos.Rows(0).Item(18).ToString)
        DTP_Inicio.Value = CDate(datos.Rows(0).Item(17).ToString)
        DTP_FIN.Value = CDate(datos.Rows(0).Item(18).ToString)

        '*******************se crea el boton para el check***************************
        Dim Label5 As New Label
        Label5.Enabled = True
        Label5.Location = New System.Drawing.Point(10, 101)
        Label5.Name = "Label"
        Label5.Size = New System.Drawing.Size(190, 20)
        Label5.TabIndex = 42
        Label5.Text = "Día" & "     " & "   Sala" & "     " & "                      Tipo Act."
        Label5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Label5.Visible = True
        Me.Controls.Add(Label5)

        For i = 0 To datos.Rows.Count - 1
            'textbox
            Dim Label4 As New Label
            Label4.Enabled = True
            Label4.Location = New System.Drawing.Point(10, 121 + (25 * i))
            Label4.Name = "Label"
            Label4.Size = New System.Drawing.Size(190, 20)
            Label4.TabIndex = 42
            Label4.Text = " " & xd.conversorreves(datos.Rows(i).Item(1)) & "       " & datos.Rows(i).Item(8).ToString & "       " & datos.Rows(i).Item(11).ToString
            Label4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Label4.Visible = True
            Me.Controls.Add(Label4)
            '
            'CheckBox1
            '

            Dim CheckBox1 As New CheckBox
            CheckBox1.AutoSize = True
            CheckBox1.Location = New System.Drawing.Point(210, 121 + (25 * i))
            CheckBox1.Name = datos.Rows(i).Item(1).ToString & " " & datos.Rows(i).Item(3).ToString & " " & datos.Rows(i).Item(11).ToString & " " & datos.Rows(i).Item(13).ToString & " " & datos.Rows(i).Item(8).ToString
            CheckBox1.Size = New System.Drawing.Size(91, 17)
            CheckBox1.TabIndex = 42
            CheckBox1.Text = ""
            CheckBox1.UseVisualStyleBackColor = True
            Me.Controls.Add(CheckBox1)

           
        Next
        '***************************************************************************
        If (datos.Rows.Count - 1) = 9 Then
            Me.ClientSize = New System.Drawing.Size(417, 362 + 25)
        End If
        End Sub

    Private Sub liberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles liberar.Click
        Dim dt As New GHAU_CapaNegocio.Negocio
        Dim bandera As New GHAU_CapaNegocio.funciones
        If bandera.formatear_fecha(DTP_Inicio.Value, DTP_FIN.Value) = True Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is System.Windows.Forms.CheckBox Then
                    If ctr.Checked = True Then
                        Dim dx = Split(ctr.name.ToString, " ")
                        dt.liberar_sala(dx(1), dx(0), dx(2), dx(3), DTP_Inicio.Value, DTP_FIN.Value, dx(4))

                    End If
                End If
            Next
            MsgBox("Guardado Exitoso!", MsgBoxStyle.Information, "Informacion")
            GHAU_CapaPresenta.Form3.cargar((FormatDateTime(Form3.Mes.SelectionStart, DateFormat.LongDate)), True)
            Me.Close()
        Else
            MsgBox("La Fecha Ingresada NO corresponde, favor verificar.", MsgBoxStyle.Information, "Error")
        End If

    End Sub

End Class