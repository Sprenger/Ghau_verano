Public NotInheritable Class VariablesFijas
    'Public Shared horariofijo As DataTable
    'Public Function horario()
    '    Dim dtsala, dthorario As New GHAU_CapaDatos.LLenadoGrillaHorario
    '    Dim dtdocente As New GHAU_CapaDatos.BaseDato
    '    Dim dts, dth, dt, dtd As New DataTable

    '    dts = dtsala.Sala
    '    'dth = dthorario.horario(dia, fecha)
    '    'Dim pntocontrolconsultaselect__dth = "select sala_codigo,nrc, bloque_codigo, Nombre_curso, Tipo_Carga, rut_docente from Horarios where sala_codigo like 'VM%' and dia='" & dia & "' order by sala_codigo"
    '    dt.Columns.Add(" ", Type.GetType("System.String"))
    '    dt.Columns.Add("MODULOS", Type.GetType("System.String")) '0


    '    Dim pntocontrolDT = dt
    '    For i = 0 To 16
    '        dt.Rows.Add()
    '        Select Case i
    '            Case 0
    '                dt.Rows(i).Item(1) = i + 1 & i + 1 & " - 8:30" & " " & "9:15" & " D"
    '            Case 1
    '                dt.Rows(i).Item(1) = i + 1 & " - 9:25" & " " & "10:10" & " D"
    '            Case 2
    '                dt.Rows(i).Item(1) = i + 1 & " - 10:20" & " " & "11:05" & " D"
    '            Case 3
    '                dt.Rows(i).Item(1) = i + 1 & " - 11:15" & " " & "12:00" & " D"
    '            Case 4
    '                dt.Rows(i).Item(1) = i + 1 & " - 12:10" & " " & "12:55" & " D"
    '            Case 5
    '                dt.Rows(i).Item(1) = i + 1 & " - 13:05" & " " & "13:50" & " D"
    '            Case 6
    '                dt.Rows(i).Item(1) = i + 1 & " - 14:00" & " " & "14:45" & " D"
    '            Case 7
    '                dt.Rows(i).Item(1) = i + 1 & " - 14:55" & " " & "15:40" & " D"
    '            Case 8
    '                dt.Rows(i).Item(1) = i + 1 & " - 15:50" & " " & "16:35" & " D"
    '            Case 9
    '                dt.Rows(i).Item(1) = i + 1 & " - 16:45" & " " & "17:30" & " D"
    '            Case 10
    '                dt.Rows(i).Item(1) = i + 1 & " - 1740" & " " & "18:25" & " D"
    '            Case 11
    '                dt.Rows(i).Item(1) = i + 1 & " - 18:35" & " " & "19:20" & " D"
    '                dt.Rows(i).Item(0) = i - 10 & " - 19:00" & " " & "19:45" & " V"
    '            Case 12
    '                dt.Rows(i).Item(1) = i + 1 & " - 19:30" & " " & "20:15" & " D"
    '                dt.Rows(i).Item(0) = i - 10 & " - 19:46" & " " & "20:30" & " V"
    '            Case 13
    '                dt.Rows(i).Item(1) = i + 1 & " - 20:25" & " " & "21:10" & " D"
    '                dt.Rows(i).Item(0) = i - 10 & " - 20:40" & " " & "21:25" & " V"
    '            Case 14
    '                dt.Rows(i).Item(0) = i - 10 & " - 21:26" & " " & "22:10" & " V"
    '            Case 15
    '                dt.Rows(i).Item(0) = i - 10 & " - 22:20" & " " & "23:05" & " V"

    '            Case 16
    '                dt.Rows(i).Item(0) = i - 10 & " - 23:06" & " " & "23:50" & " V"

    '        End Select

    '    Next
    '    For i = 0 To dts.Rows.Count - 1
    '        dt.Columns.Add(dts.Rows(i).Item(0).ToString & vbNewLine & "CAPACIDAD: " & dts.Rows(i).Item(1).ToString & vbNewLine, Type.GetType("System.String")) '0

    '    Next
    '    horariofijo = dt
    '    'punto de control


    'End Function

End Class