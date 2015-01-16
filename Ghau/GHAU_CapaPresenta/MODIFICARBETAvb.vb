Public Class MODIFICARBETAvb


    Private Sub CB_Modificar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Modificar.CheckedChanged
        If CB_Modificar.Checked = True Then
            Me.Size = New Size(493, 679)
        Else
            Me.Size = New Size(493, 370)


        End If
    End Sub



    Private Sub HU3vb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CB_DOCENTES.DataSource = Form3.datatableDocente
        CB_DOCENTES.DisplayMember = Form3.datatableDocente.Columns(1).ColumnName.ToString

    End Sub
End Class