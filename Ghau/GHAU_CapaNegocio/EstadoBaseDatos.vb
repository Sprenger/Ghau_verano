Public Class EstadoBaseDatos
    Private HU As String
    Sub estado(ByVal Form As String)
        HU = Form

    End Sub
    Public Function EstadoSalas() As Boolean
        If HU = "INICIO" Then
            Dim ESTADO As New GHAU_CapaDatos.BaseDato
            If ESTADO.EstadoSalas Then
                Return True
            Else
                Return False
            End If
            'falta el EstadoHorario ir a basedato, capadatos
        End If
    End Function
End Class
