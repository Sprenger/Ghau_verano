Public Class Programas
    Private codigo As String
    Private descripcion As String

    Sub programas(ByVal programa_codigo As String, ByVal programa_descipcion As String)


    End Sub


    Property desc() As String
        Get
            Return descripcion
        End Get
        Private Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Property cod() As String
        Get
            Return codigo
        End Get
        Private Set(ByVal value As String)
            codigo = value
        End Set
    End Property

    Function consultar(ByVal cod(), ByVal desc())
        Dim dt As New GHAU_CapaDatos.BaseDato

    End Function

End Class
