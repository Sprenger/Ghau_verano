Public Class Validado_Rut
    Private Rut As String
    Sub New(ByVal RUT As String)
        Me.Rut = Rut
    End Sub

    Public Function ValidarRut(ByVal Rut As String) As Boolean
        Try
            Dim Digito As Integer
            Dim Contador As Integer
            Dim Multiplo As Integer
            Dim Acumulador As Integer
            Dim str_AuxDig As String = Nothing
            Dim str_Digito As String = Mid(Rut.ToUpper(), Rut.Length(), 1)
            Dim str_Rut As String = Mid(Rut, 1, Rut.Length() - 2)
            Contador = 2
            Acumulador = 0

            While str_Rut <> 0
                Multiplo = (str_Rut Mod 10) * Contador
                Acumulador = Acumulador + Multiplo
                str_Rut = str_Rut \ 10
                Contador = Contador + 1
                If Contador = 8 Then
                    Contador = 2
                End If

            End While

            Digito = 11 - (Acumulador Mod 11)
            str_AuxDig = CStr(Digito)
            Select Case Digito
                Case Is = 10 : str_AuxDig = "K"
                Case Is = 11 : str_AuxDig = "0"
                Case Else : str_AuxDig = str_AuxDig
            End Select

            If str_Digito <> str_AuxDig Then
                Return False
            Else
                Return True
            End If
        Catch
        End Try
    End Function

End Class
