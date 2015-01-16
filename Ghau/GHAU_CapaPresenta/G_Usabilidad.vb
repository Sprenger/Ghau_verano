Imports System.Windows.Forms.DataVisualization.Charting

Public Class G_Usabilidad
    Dim dtprograma As New GHAU_CapaNegocio.Negocio
    Dim datajornadasDescripcion As DataTable = dtprograma.consultarjornadascodigo
    Dim datajornada As DataTable = dtprograma.consultarjornadas
    Dim datatipo_actividad As DataTable = dtprograma.ConsultarTipoActividad("EVENTO")
    Dim datasalas As DataTable = dtprograma.consultarcantidadSoloSala

    Public evento As Boolean

    Private Sub CB_ConEvento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConEvento.CheckedChanged
        If CB_ConEvento.Checked Then
            evento = True
            CB_SinEvento.Checked = False
        End If
    End Sub

    Private Sub CB_SinEvento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_SinEvento.CheckedChanged
        If CB_SinEvento.Checked Then
            CB_ConEvento.Checked = False
            evento = False
        End If
    End Sub


    Private Sub DTP_Inicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Inicio.ValueChanged

        If DTP_Termino.Value < DTP_Inicio.Value Then
            DTP_Termino.Value = DTP_Inicio.Value
        End If
    End Sub

    Private Sub DTP_Termino_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Termino.ValueChanged
        If DTP_Termino.Value < DTP_Inicio.Value Then
            DTP_Inicio.Value = DTP_Termino.Value
        End If
    End Sub


    Private Sub G_Usabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DTP_Inicio.Format = DateTimePickerFormat.Custom
        DTP_Termino.Format = DateTimePickerFormat.Custom
        Cb_Jornada.SelectedIndex = 0
        Me.Cb_Jornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        CB_SinEvento.Checked = True

    End Sub

    Private Sub BTN_Generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Generar.Click
        Dim FechaInicio = String.Format(DTP_Inicio.Value.ToShortDateString)
        Dim dia = String.Format(DTP_Inicio.Value.DayOfWeek)
        Dim fechaFin = String.Format(DTP_Termino.Value.ToShortDateString)
        Dim Dias As Long = DateDiff(DateInterval.Day, DTP_Inicio.Value, DTP_Termino.Value)

        Dim dt = dtprograma.consultarHorario(FechaInicio, fechaFin, Cb_Jornada.Text, evento, dia, datatipo_actividad.Rows(0).Item(0).ToString, Dias, CInt(datasalas.Rows(0).Item(0).ToString))

        Chart1.DataSource = dt

        Chart1.Series("Series1").XValueMember = "fecha"
        Chart1.Series("Series1").YValueMembers = "valor"

        Chart1.DataBind()

        'Chart1.Series("Series1").XValueMember = "Producto"
        'Chart1.Series("Series1").YValueMembers = "poto"
        'Chart1.DataSource = dt


        'Lo Unico que resta es darle la serie al Chart

        If dt.Rows.Count > 0 Then
            BTN_Imprimir.Visible = True
        End If


    End Sub

    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As Printing.PrintPageEventArgs)
        ' Create and initialize print font 
        Dim printFont As New System.Drawing.Font("Arial", 1)
        ' Create Rectangle structure, used to set the position of the chart 
        Dim myRec As New System.Drawing.Rectangle(0, 0, 1000, 500)        ' Draw a line of text, followed by the chart, and then another line of text 
        ev.Graphics.DrawString("", printFont, Brushes.Black, 0, 0)
        Chart1.Printing.PrintPaint(ev.Graphics, New Rectangle(0, 0, Me.Chart1.Size.Width, Me.Chart1.Size.Height))
        ev.Graphics.DrawString("Line after chart", printFont, Brushes.Black, 100, 500)
    End Sub

 

 

    Private Sub BTN_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Imprimir.Click
        Dim pd As New System.Drawing.Printing.PrintDocument()
        ' Add the event handler, and then print 
        AddHandler pd.PrintPage, AddressOf pd_PrintPage
        ' Print the document 
        pd.Print()
    End Sub
End Class