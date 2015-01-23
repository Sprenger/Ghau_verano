Public Class funciones
    Public Function Estado_coneccion() As Boolean
        Dim x As New GHAU_CapaDatos.BaseDato
        Dim dt As DataTable = x.Estadoconeccion
        If dt Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function modularizacion(ByVal inicio As String, ByVal fin As String, ByVal Jornada As String) As String

        Dim flag As Boolean = True
        Dim modulo As String = ""
        Dim ini, fini As String


        If Jornada.ToString.ToUpper = "DIURNO" Then
2:
            If 1 < CInt(inicio) And CInt(inicio) <= 830 Then
                ini = "01"
            ElseIf 830 < CInt(inicio) And CInt(inicio) <= 925 Then 'inicio = "0925" Then
                ini = "02"
            ElseIf 925 < CInt(inicio) And CInt(inicio) <= 1020 Then 'inicio = "1020" Then
                ini = "03"
            ElseIf 1020 < CInt(inicio) And CInt(inicio) <= 1115 Then 'inicio = "1115" Then
                ini = "04"
            ElseIf 1115 < CInt(inicio) And CInt(inicio) <= 1210 Then 'inicio = "1210" Then
                ini = "05"
            ElseIf 1210 < CInt(inicio) And CInt(inicio) <= 1305 Then ' inicio = "1305" Then
                ini = "06"
            ElseIf 1305 < CInt(inicio) And CInt(inicio) <= 1400 Then 'inicio = "1400" Then
                ini = "07"
            ElseIf 1400 < CInt(inicio) And CInt(inicio) <= 1455 Then 'inicio = "1455" Then
                ini = "08"
            ElseIf 1455 < CInt(inicio) And CInt(inicio) <= 1550 Then 'inicio = "1550" Then
                ini = "09"
            ElseIf 1550 < CInt(inicio) And CInt(inicio) <= 1645 Then 'inicio = "1645" Then
                ini = "10"
            ElseIf 1645 < CInt(inicio) And CInt(inicio) <= 1740 Then ' inicio = "1740" Then
                ini = "11"
            ElseIf 1740 < CInt(inicio) And CInt(inicio) <= 1835 Then 'inicio = "1835" Then
                ini = "12"
            ElseIf 1835 < CInt(inicio) And CInt(inicio) <= 1930 Then 'inicio = "19 30" Then
                ini = "13"
            ElseIf 1930 < CInt(inicio) And CInt(inicio) <= 2025 Then ' inicio = "2025" Then
                ini = "14"
            ElseIf 2025 < CInt(inicio) Then
                GoTo 1
            End If


            If CInt(fin) <= 915 Then 'fin = "0915" Then
                fini = "01"
            ElseIf CInt(fin) < 1 Then
                fini = "20"
            ElseIf 915 < CInt(fin) And CInt(fin) <= 1010 Then 'fin = "1010" Then
                fini = "02"
            ElseIf 1010 < CInt(fin) And CInt(fin) <= 1105 Then 'fin = "1105" Then
                fini = "03"
            ElseIf 1105 < CInt(fin) And CInt(fin) <= 1200 Then 'fin = "1200" Then
                fini = "04"
            ElseIf 1200 < CInt(fin) And CInt(fin) <= 1255 Then 'fin = "1255" Then
                fini = "05"
            ElseIf 1255 < CInt(fin) And CInt(fin) <= 1350 Then 'fin = "1350" Then
                fini = "06"
            ElseIf 1350 < CInt(fin) And CInt(fin) <= 1445 Then 'fin = "1445" Then
                fini = "07"
            ElseIf 1445 < CInt(fin) And CInt(fin) <= 1540 Then ' fin = "1540" Then
                fini = "08"
            ElseIf 1540 < CInt(fin) And CInt(fin) <= 1635 Then 'fin = "1635" Then
                fini = "09"
            ElseIf 1635 < CInt(fin) And CInt(fin) <= 1730 Then  'fin = "1730" Then
                fini = "10"
            ElseIf 1730 < CInt(fin) And CInt(fin) <= 1825 Then 'fin = "1825" Then
                fini = "11"
            ElseIf 1825 < CInt(fin) And CInt(fin) <= 1920 Then 'fin = "1920" Then
                fini = "12"
            ElseIf 1920 < CInt(fin) And CInt(fin) <= 2015 Then 'fin = "2015" Then
                fini = "13"
            ElseIf 2015 < CInt(fin) And CInt(fin) <= 2110 Then 'fin = "2110" Then
                fini = "14"
            ElseIf 2110 < CInt(fin) Then
                GoTo 1
            End If


        ElseIf Jornada = "VESPERTINO" Then
1:

            If 1800 < CInt(inicio) And CInt(inicio) <= 1900 Then 'inicio = "1900" Then
                ini = "15"
            ElseIf 1900 < CInt(inicio) And CInt(inicio) <= 1946 Then 'inicio = "1946" Then
                ini = "16"
            ElseIf 1946 < CInt(inicio) And CInt(inicio) <= 2040 Then ' inicio = "2040" Then
                ini = "17"
            ElseIf 2040 < CInt(inicio) And CInt(inicio) <= 2126 Then 'inicio = "2126" Then
                ini = "18"
            ElseIf 2126 < CInt(inicio) And CInt(inicio) <= 2220 Then 'inicio = "2220" Then
                ini = "19"
            ElseIf 2220 < CInt(inicio) And CInt(inicio) <= 2306 Then 'inicio = "2306" Then
                ini = "20"
                'Else
                '    modulo = "Error"
                '    GoTo 1
            Else
                If flag Then 'para que no se quede dando vueltas infinitas
                    flag = False
                    GoTo 2
                End If
            End If


            If 1845 < CInt(fin) And CInt(fin) <= 1945 Then 'fin = "1945" Then
                fini = "15"

            ElseIf 1945 < CInt(fin) And CInt(fin) <= 2030 Then ' fin = "2030" Then
                fini = "16"
            ElseIf 2030 < CInt(fin) And CInt(fin) <= 2125 Then 'fin = "2125" Then
                fini = "17"
            ElseIf 2125 < CInt(fin) And CInt(fin) <= 2210 Then 'fin = "2210" Then
                fini = "18"
            ElseIf 2210 < CInt(fin) And CInt(fin) <= 2305 Then 'fin = "2305" Then
                fini = "19"
            ElseIf 2305 < CInt(fin) And CInt(fin) <= 2350 Then 'fin = "2350" Then
                fini = "20"
            Else
                If flag Then 'para que no se quede dando vueltas infinitas
                    flag = False
                    GoTo 2
                End If
                'Else
                '    modulo = "Error"
            End If

        ElseIf Jornada = "EVENTO" Then


            If CInt(inicio) < 1 Then
                ini = "01"
            ElseIf CInt(inicio) = 830 Then
                ini = "01"
            ElseIf CInt(inicio) = 925 Then 'inicio = "0925" Then
                ini = "02"
            ElseIf CInt(inicio) = 1020 Then 'inicio = "1020" Then
                ini = "03"
            ElseIf CInt(inicio) = 1115 Then 'inicio = "1115" Then
                ini = "04"
            ElseIf CInt(inicio) = 1210 Then 'inicio = "1210" Then
                ini = "05"
            ElseIf CInt(inicio) = 1305 Then ' inicio = "1305" Then
                ini = "06"
            ElseIf CInt(inicio) = 1400 Then 'inicio = "1400" Then
                ini = "07"
            ElseIf CInt(inicio) = 1455 Then 'inicio = "1455" Then
                ini = "08"
            ElseIf CInt(inicio) = 1550 Then 'inicio = "1550" Then
                ini = "09"
            ElseIf CInt(inicio) = 1645 Then 'inicio = "1645" Then
                ini = "10"
            ElseIf CInt(inicio) = 1740 Then ' inicio = "1740" Then
                ini = "11"
            ElseIf CInt(inicio) = 1835 Then 'inicio = "1835" Then
                ini = "12"
            ElseIf CInt(inicio) = 1930 Then 'inicio = "19 30" Then
                ini = "13"
            ElseIf CInt(inicio) = 2025 Then ' inicio = "2025" Then
                ini = "14"
            ElseIf CInt(inicio) = 1900 Then ' inicio = "1900" Then
                ini = "15"
            ElseIf CInt(inicio) = 1946 Then ' inicio = "1946" Then
                ini = "16"
            ElseIf CInt(inicio) = 2040 Then ' inicio = "2040" Then
                ini = "17"
            ElseIf CInt(inicio) = 2126 Then ' inicio = "2126" Then
                ini = "18"
            ElseIf CInt(inicio) = 2220 Then ' inicio = "2220" Then
                ini = "19"
            ElseIf CInt(inicio) = 2306 Then ' inicio = "2306" Then
                ini = "20"
            End If


            If CInt(fin) = 915 Then 'fin = "0915" Then
                fini = "01"
            ElseIf CInt(fin) = 1 Then
                fini = "20"
            ElseIf CInt(fin) = 1010 Then 'fin = "1010" Then
                fini = "02"
            ElseIf CInt(fin) = 1105 Then 'fin = "1105" Then
                fini = "03"
            ElseIf CInt(fin) = 1200 Then 'fin = "1200" Then
                fini = "04"
            ElseIf CInt(fin) = 1255 Then 'fin = "1255" Then
                fini = "05"
            ElseIf CInt(fin) = 1350 Then 'fin = "1350" Then
                fini = "06"
            ElseIf CInt(fin) = 1445 Then 'fin = "1445" Then
                fini = "07"
            ElseIf CInt(fin) = 1540 Then ' fin = "1540" Then
                fini = "08"
            ElseIf CInt(fin) = 1635 Then 'fin = "1635" Then
                fini = "09"
            ElseIf CInt(fin) = 1730 Then  'fin = "1730" Then
                fini = "10"
            ElseIf CInt(fin) = 1825 Then 'fin = "1825" Then
                fini = "11"
            ElseIf CInt(fin) = 1920 Then 'fin = "1920" Then
                fini = "12"
            ElseIf CInt(fin) = 2015 Then 'fin = "2015" Then
                fini = "13"
            ElseIf CInt(fin) = 2110 Then 'fin = "2110" Then
                fini = "14"
            ElseIf CInt(fin) = 1945 Then 'fin = "2110" Then
                fini = "15"
            ElseIf CInt(fin) = 2030 Then 'fin = "2110" Then
                fini = "16"
            ElseIf CInt(fin) = 2125 Then 'fin = "2110" Then
                fini = "17"
            ElseIf CInt(fin) = 2210 Then 'fin = "2110" Then
                fini = "18"
            ElseIf CInt(fin) = 2305 Then 'fin = "2110" Then
                fini = "19"
            ElseIf CInt(fin) = 2350 Then 'fin = "2110" Then
                fini = "20"
            ElseIf 2110 < CInt(fin) Then
                GoTo 1
            End If


        End If
        Dim Temp_Mod = "00000000000000000000"
        Dim arrTemp = Temp_Mod.ToCharArray

        For i = CInt(ini) - 1 To CInt(fini) - 1
            arrTemp(i) = "1"

        Next
        For i = 0 To arrTemp.Length - 1
            modulo = modulo & arrTemp(i)
        Next

        Return modulo
    End Function

    Public Function formatear_fecha(ByVal inicio, ByVal fin)
        Dim d0 = Replace(inicio, "-", "/")
        Dim s0 = Replace(fin, "-", "/")
        Dim d1 = Split(d0, "/")
        Dim d2 = d1(2) & d1(1) & d1(0)
        Dim s1 = Split(s0, "/")
        Dim s2 = s1(2) & s1(1) & s1(0)

        If CInt(d2) < CInt(s2) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function conversordia(ByVal dia As String)
        Dim dia_Numero As String = Mid(dia.ToUpper.Trim, 1, 2)
        Select Case dia_Numero
            Case "LU"
                dia = "1"
            Case "MA"
                dia = "2"
            Case "MI"
                dia = "3"
            Case "JU"
                dia = "4"
            Case "VI"
                dia = "5"
            Case "SA"
                dia = "6"
            Case "DO"
                dia = "7"
            Case Else
                dia = "8"

        End Select
        Return dia
    End Function

    Public Function conversorreves(ByVal dia As Integer)
        Dim dialetra As String
        Select Case dia
            Case "1"
                dialetra = "LU"
            Case "2"
                dialetra = "MA"
            Case "3"
                dialetra = "MI"
            Case "4"
                dialetra = "JU"
            Case "5"
                dialetra = "VI"
            Case "6"
                dialetra = "SA"
            Case "7"
                dialetra = "DO"
            Case Else
                MsgBox("Error Dia no encontrado")
        End Select

        Return dialetra
    End Function
End Class
