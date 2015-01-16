Imports GHAU_CapaDatos.Control_BaseDato
Public Class Control_de_Dato
    

    Function estados() As String
        Dim ingreso As New GHAU_CapaDatos.Control_BaseDato
        Dim parametro = ingreso.Parametros
        Dim coneccion As Boolean = ingreso.conectado
        Dim tablas As Boolean = ingreso.coneccion(parametro)
        Dim salas As Boolean = ingreso.salas(parametro)
        Dim horario As Boolean = ingreso.Horario(parametro)
        Dim respuesta As String = parametro & vbNewLine & _
              coneccion & vbNewLine & tablas & vbNewLine & salas & vbNewLine & horario
        Return respuesta

    End Function

End Class
