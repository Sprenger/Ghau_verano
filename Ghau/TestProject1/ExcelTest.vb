Imports System.Data

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports GHAU_CapaNegocio



'''<summary>
'''This is a test class for ExcelTest and is intended
'''to contain all ExcelTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ExcelTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


'''<summary>
'''A test for ValidarChoquesExcel
'''</summary>
    <TestMethod()> _
     Public Sub ValidarChoquesExcelTest()
        Dim target As Excel = New Excel ' TODO: Initialize to an appropriate value
        Dim dato As New DataTable ' TODO: Initialize to an appropriate value

        dato.Columns.Add("Facultad", Type.GetType("System.String"))
        dato.Columns.Add("Campus", Type.GetType("System.String"))
        dato.Columns.Add("Unidad Académica", Type.GetType("System.String"))
        dato.Columns.Add("Periodo", Type.GetType("System.String"))
        dato.Columns.Add("Materia", Type.GetType("System.String"))
        dato.Columns.Add("Curso", Type.GetType("System.String"))
        dato.Columns.Add("Sección", Type.GetType("System.String"))
        dato.Columns.Add("Jornada", Type.GetType("System.String"))
        dato.Columns.Add("NRC", Type.GetType("System.String"))
        dato.Columns.Add("Listas Cruzadas", Type.GetType("System.String"))
        dato.Columns.Add("NRC Ligados", Type.GetType("System.String"))
        dato.Columns.Add("Id Listas Cruzadas", Type.GetType("System.String"))
        dato.Columns.Add("Calificable", Type.GetType("System.String"))
        dato.Columns.Add("Minor", Type.GetType("System.String"))
        dato.Columns.Add("Rut Profesor", Type.GetType("System.String"))
        dato.Columns.Add("Nombre Profesor", Type.GetType("System.String"))
        dato.Columns.Add("Nombre Asignatura", Type.GetType("System.String"))
        dato.Columns.Add("Horas a Pagar", Type.GetType("System.String"))
        dato.Columns.Add("Tipo Actividad", Type.GetType("System.String"))
        dato.Columns.Add("Modalidad", Type.GetType("System.String"))
        dato.Columns.Add("Horario", Type.GetType("System.String"))
        dato.Columns.Add("Vacantes", Type.GetType("System.String"))
        dato.Columns.Add("Inscritos", Type.GetType("System.String"))
        dato.Columns.Add("Edificio", Type.GetType("System.String"))
        dato.Columns.Add("Sala", Type.GetType("System.String"))
        dato.Columns.Add("Capacidad Sala", Type.GetType("System.String"))
        dato.Columns.Add("Restric# Cod#Programa", Type.GetType("System.String"))
        dato.Columns.Add("Restric# Desc#Programa", Type.GetType("System.String"))
        dato.Columns.Add("Restricciones Campus", Type.GetType("System.String"))
        dato.Columns.Add("Nivel del Curso", Type.GetType("System.String"))
        dato.Columns.Add("Unidad que Paga", Type.GetType("System.String"))
        dato.Columns.Add("Semestre que Paga", Type.GetType("System.String"))
        dato.Columns.Add("Nivel del Programa", Type.GetType("System.String"))
        dato.Columns.Add("Fecha Inicio", Type.GetType("System.String"))
        dato.Columns.Add("Fecha Fin", Type.GetType("System.String"))
        dato.Rows.Add()
        dato.Rows(0).Item(0) = "DERE"
        dato.Rows(0).Item(1) = "VIÑA DEL MAR"
        dato.Rows(0).Item(2) = "FACULTAD DE DERECHO"
        dato.Rows(0).Item(3) = ""
        dato.Rows(0).Item(4) = "DDA"
        dato.Rows(0).Item(5) = "121"
        dato.Rows(0).Item(6) = "360"
        dato.Rows(0).Item(7) = "VESPERTINO"
        dato.Rows(0).Item(8) = "1222"
        dato.Rows(0).Item(9) = "NO"
        dato.Rows(0).Item(10) = ""
        dato.Rows(0).Item(11) = ""
        dato.Rows(0).Item(12) = "SI"
        dato.Rows(0).Item(13) = ""
        dato.Rows(0).Item(14) = "99820055"
        dato.Rows(0).Item(15) = "FABIAN VILLARROEL RIOS"
        dato.Rows(0).Item(16) = "EL COMERCIO INTERNAC Y SUS PR"
        dato.Rows(0).Item(17) = "2"
        dato.Rows(0).Item(18) = "TEORIA"
        dato.Rows(0).Item(19) = "PRESENCIAL"
        dato.Rows(0).Item(20) = ".Vi 1835 - 2210"
        dato.Rows(0).Item(21) = "20"
        dato.Rows(0).Item(22) = "0"
        dato.Rows(0).Item(23) = "VM"
        dato.Rows(0).Item(24) = "SAL707"
        dato.Rows(0).Item(25) = "31"
        dato.Rows(0).Item(26) = "UNAB25495"
        dato.Rows(0).Item(27) = "DIPLOMADO EN DERECHO ADUANERO"
        dato.Rows(0).Item(28) = "VIÑA DEL MAR"
        dato.Rows(0).Item(29) = "PR"
        dato.Rows(0).Item(30) = "DIPLOMADO EN DERECHO ADUANERO"
        dato.Rows(0).Item(31) = ""
        dato.Rows(0).Item(32) = "1MOD"
        dato.Rows(0).Item(33) = "25-04-2015"
        dato.Rows(0).Item(34) = "08-05-2015"

        Dim expected As New DataTable  ' TODO: Initialize to an appropriate value
        expected.Columns.Add("NRC", Type.GetType("System.String"))
        expected.Columns.Add("Descripcion", Type.GetType("System.String"))
        expected.Rows.Add()
        expected.Rows(0).Item(0) = "1222"
        expected.Rows(0).Item(1) = "No posee PERIODO"
        'ssert.IsTrue(DataTableComparer.AreEqual(dt1, dt2))
        Dim actual As DataTable
        actual = target.ValidarChoquesExcel(dato)
        Assert.IsTrue(CompareDataTables(expected, actual))
        'Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
    Private Function CompareDataTables(ByVal DT1 As DataTable, ByVal DT2 As DataTable) As Boolean
        If (DT1 Is Nothing) AndAlso (DT2 Is Nothing) Then
            Return True
        ElseIf (DT1 IsNot Nothing) AndAlso (DT2 IsNot Nothing) Then
            If DT1.Rows.Count = DT2.Rows.Count Then
                If DT1.Columns.Count = DT2.Columns.Count Then
                    For i As Integer = 0 To DT1.Rows.Count - 1
                        For j As Integer = 0 To DT1.Columns.Count - 1
                            If DT1.Rows(i)(j).ToString() <> DT2.Rows(i)(j).ToString() Then
                                Return False
                            End If
                        Next
                    Next
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

End Class
