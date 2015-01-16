Imports GHAU_CapaNegocio
Public Class Mantenedor_Unidades_Academicas

    Dim dtuacademicas As New DataTable
    Private Sub INICIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BTN_Nuevo.Visible = False
        BTN_Nuevo.Enabled = False
        Grilla_Academicas.DataSource = Form3.dtunidaesAcademicas
        Grilla_Academicas.ClearSelection()
        Grilla_Academicas.Columns(1).Width = 500
    End Sub
    Dim dt As DataTable
    Private Sub BTN_Insertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Insertar.Click
        If TXT_Codigo.Text <> "" Then
            TXT_Codigo.Text = TXT_Codigo.Text.ToUpper
            TXT_Descripcion.Text = TXT_Descripcion.Text.ToUpper
            'Grilla_Academicas.Rows.Add()
            'Grilla_Academicas.Rows(Grilla_Academicas.Rows.Count - 1).Cells(0).Value = TXT_Codigo.Text
            'Grilla_Academicas.Rows(Grilla_Academicas.Rows.Count - 1).Cells(1).Value = TXT_Descripcion.Text
            BTN_Nuevo.Enabled = True

            Dim dt As New GHAU_CapaNegocio.Negocio
            If BTN_Insertar.Text = "Crear" Then
                If dt.ingresaruacademicas(TXT_Codigo.Text, TXT_Descripcion.Text) Then
                    Form3.dtunidaesAcademicas.Rows.Add()
                    Form3.dtunidaesAcademicas.Rows(Form3.dtunidaesAcademicas.Rows.Count - 1).Item(0) = TXT_Codigo.Text.ToString
                    Form3.dtunidaesAcademicas.Rows(Form3.dtunidaesAcademicas.Rows.Count - 1).Item(1) = TXT_Descripcion.Text.ToString
                    Grilla_Academicas.DataSource = Form3.dtunidaesAcademicas
                    TXT_Codigo.Text = ""
                    TXT_Descripcion.Text = ""
                Else
                    MsgBox("El codigo -" & TXT_Codigo.Text & "- ya existe" & vbNewLine & " informacion  no ingresada")
                End If
            Else
                If dt.modificaruacademicas(codigoviejo, descripcionviejo, TXT_Codigo.Text, TXT_Descripcion.Text) Then
                    Form3.dtunidaesAcademicas.Rows.Add()
                    Form3.dtunidaesAcademicas.Rows(CInt(posicionx)).Item(0) = TXT_Codigo.Text.ToString
                    Form3.dtunidaesAcademicas.Rows(CInt(posicionx)).Item(1) = TXT_Descripcion.Text.ToString
                    Grilla_Academicas.DataSource = Form3.dtunidaesAcademicas
                    BTN_Insertar.Text = "Crear"
                    BTN_Nuevo.Visible = False
                    BTN_Nuevo.Enabled = False
                    Grilla_Academicas.ClearSelection()
                    TXT_Codigo.Text = ""
                    TXT_Descripcion.Text = ""
                    Grilla_Academicas.ClearSelection()
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
        Grilla_Academicas.ClearSelection()
        TXT_Codigo.Text = ""
        TXT_Descripcion.Text = ""
        BTN_Nuevo.Visible = False
        BTN_Nuevo.Enabled = False
    End Sub

    Public codigoviejo, descripcionviejo, posicionx, posiciony As String
    Private Sub selectedCellsButton_Click( _
    ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Grilla_Academicas.Click

        Dim selectedCellCount As Integer = _
             Grilla_Academicas.GetCellCount(DataGridViewElementStates.Selected)

        If selectedCellCount = 1 Then

            If Not Grilla_Academicas.AreAllCellsSelected(True) Then

                Dim i As Integer
                posicionx = Grilla_Academicas.SelectedCells(i).RowIndex.ToString
                posiciony = Grilla_Academicas.SelectedCells(i).ColumnIndex.ToString
                TXT_Codigo.Text = Grilla_Academicas.Rows(Grilla_Academicas.SelectedCells(i).RowIndex).Cells(0).Value
                TXT_Descripcion.Text = Grilla_Academicas.Rows(Grilla_Academicas.SelectedCells(i).RowIndex).Cells(1).Value
                codigoviejo = TXT_Codigo.Text
                descripcionviejo = TXT_Descripcion.Text
                BTN_Insertar.Text = "Modificar"
                BTN_Nuevo.Visible = True
                BTN_Nuevo.Enabled = True
            End If

        Else
            Grilla_Academicas.ClearSelection()

        End If

    End Sub
End Class