Public Class Llenado

    Private Combobox As String
    'Sub New(ByVal combobox As String)
    '    Me.Combobox = combobox
    'End Sub

    Function Docente() As DataTable
        Dim consulta As New GHAU_CapaDatos.LLenadoGrillaHorario
        Dim dt = consulta.consultarDocentes()

        Return dt
    End Function

    Function periodo() As DataTable
        Dim consulta As New GHAU_CapaDatos.BaseDato
        Return consulta.consultaPeriodo()
    End Function
    Function campus() As DataTable
        Dim consulta As New GHAU_CapaDatos.BaseDato
        Return consulta.consultarCampus()
    End Function

    Public Function escuelas() As DataTable
        Dim consulta As New GHAU_CapaDatos.BaseDato
        Return consulta.consultaRescuelas()
    End Function

    Public Function Programas() As DataTable
        Dim consulta As New GHAU_CapaDatos.BaseDato
        Return consulta.consultarProgramas

    End Function


    Public Function Niveles() As DataTable
        Dim consulta As New GHAU_CapaDatos.BaseDato
        Return consulta.consultarNiveles()
    End Function

End Class
