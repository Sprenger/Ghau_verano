Imports GHAU_CapaNegocio
Public Class Mantenedor_Programas

    Dim dtprograma As New DataTable
    Private Sub INICIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BTN_Nuevo.Visible = False
        BTN_Nuevo.Enabled = False
        Grilla_Programa.DataSource = Form3.dtprogramas
        Grilla_Programa.ClearSelection()
        Grilla_Programa.Columns(1).Width = 500
    End Sub
    Dim dt As DataTable
    Private Sub BTN_Insertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Insertar.Click
        If TXT_Codigo.Text <> "" Then
            TXT_Codigo.Text = TXT_Codigo.Text.ToUpper
            TXT_Descripcion.Text = TXT_Descripcion.Text.ToUpper
            'Grilla_Programa.Rows.Add()
            'Grilla_Programa.Rows(Grilla_Programa.Rows.Count - 1).Cells(0).Value = TXT_Codigo.Text
            'Grilla_Programa.Rows(Grilla_Programa.Rows.Count - 1).Cells(1).Value = TXT_Descripcion.Text
            BTN_Nuevo.Enabled = True

            Dim dt As New GHAU_CapaNegocio.Negocio
            If BTN_Insertar.Text = "Crear" Then
                If dt.ingresarPrograma(TXT_Codigo.Text, TXT_Descripcion.Text) Then
                    Form3.dtprogramas.Rows.Add()
                    Form3.dtprogramas.Rows(Form3.dtprogramas.Rows.Count - 1).Item(0) = TXT_Codigo.Text.ToString
                    Form3.dtprogramas.Rows(Form3.dtprogramas.Rows.Count - 1).Item(1) = TXT_Descripcion.Text.ToString
                    Grilla_Programa.DataSource = Form3.dtprogramas
                    TXT_Codigo.Text = ""
                    TXT_Descripcion.Text = ""
                Else
                    MsgBox("El codigo -" & TXT_Codigo.Text & "- ya existe" & vbNewLine & " informacion  no ingresada")
                End If
            Else
                If dt.modificarPrograma(codigoviejo, descripcionviejo, TXT_Codigo.Text, TXT_Descripcion.Text) Then
                    Form3.dtprogramas.Rows.Add()
                    Form3.dtprogramas.Rows(CInt(posicionx)).Item(0) = TXT_Codigo.Text.ToString
                    Form3.dtprogramas.Rows(CInt(posicionx)).Item(1) = TXT_Descripcion.Text.ToString
                    Grilla_Programa.DataSource = Form3.dtprogramas
                    BTN_Insertar.Text = "Crear"
                    BTN_Nuevo.Visible = False
                    BTN_Nuevo.Enabled = False
                    Grilla_Programa.ClearSelection()
                    TXT_Codigo.Text = ""
                    TXT_Descripcion.Text = ""
                    Grilla_Programa.ClearSelection()
                Else
                    MsgBox("Codigo:  -" & TXT_Codigo.Text & "-  ya se encuentra en uso" & vbNewLine & "Cambio no realizado")
                End If

            End If

        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Nuevo.Click
        'Dim dt As New GHAU_CapaNegocio.Negocio
        'dt.ingresarPrograma(dtprograma)
        'Me.Close()
        BTN_Insertar.Text = "Crear"
        Grilla_Programa.ClearSelection()
        TXT_Codigo.Text = ""
        TXT_Descripcion.Text = ""
        BTN_Nuevo.Visible = False
        BTN_Nuevo.Enabled = False
    End Sub

    Public codigoviejo, descripcionviejo, posicionx, posiciony As String
    Private Sub selectedCellsButton_Click( _
    ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Grilla_Programa.Click

        Dim selectedCellCount As Integer = _
             Grilla_Programa.GetCellCount(DataGridViewElementStates.Selected)

        If selectedCellCount = 1 Then

            If Not Grilla_Programa.AreAllCellsSelected(True) Then

                Dim i As Integer
                posicionx = Grilla_Programa.SelectedCells(i).RowIndex.ToString
                posiciony = Grilla_Programa.SelectedCells(i).ColumnIndex.ToString
                TXT_Codigo.Text = Grilla_Programa.Rows(Grilla_Programa.SelectedCells(i).RowIndex).Cells(0).Value
                TXT_Descripcion.Text = Grilla_Programa.Rows(Grilla_Programa.SelectedCells(i).RowIndex).Cells(1).Value
                codigoviejo = TXT_Codigo.Text
                descripcionviejo = TXT_Descripcion.Text
                BTN_Insertar.Text = "Modificar"
                BTN_Nuevo.Visible = True
                BTN_Nuevo.Enabled = True
            End If

        Else
            Grilla_Programa.ClearSelection()

        End If

    End Sub


End Class