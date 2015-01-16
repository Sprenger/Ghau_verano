Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports GHAU_CapaNegocio
Imports System.Data



'''<summary>
'''Se trata de una clase de prueba para EventosTest y se pretende que
'''contenga todas las pruebas unitarias EventosTest.
'''</summary>
<TestClass()> _
Public Class EventosTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Obtiene o establece el contexto de la prueba que proporciona
    '''la información y funcionalidad para la ejecución de pruebas actual.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "Atributos de prueba adicionales"
    '
    'Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
    '
    'Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize para ejecutar código antes de ejecutar cada prueba
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''Una prueba de ingreso_evento
    '''</summary>
    <TestMethod()> _
    Public Sub ingreso_eventoTest()
        Dim dtevento As New DataTable
        Dim dt2 As New DataTable

        dtevento.Columns.Add("Evento", Type.GetType("System.String"))
        dtevento.Columns.Add("Descripción", Type.GetType("System.String"))
        dtevento.Columns.Add("Rut_Contacto", Type.GetType("System.String"))
        dtevento.Columns.Add("Nombre_Contacto", Type.GetType("System.String"))
        dtevento.Columns.Add("Campus", Type.GetType("System.String"))
        dtevento.Columns.Add("Fecha_Inicio", Type.GetType("System.String"))
        dtevento.Columns.Add("Fecha_Fin", Type.GetType("System.String"))
        dtevento.Columns.Add("Día_de_la_semana", Type.GetType("System.String"))
        dtevento.Columns.Add("Hora_Inicio", Type.GetType("System.String"))
        dtevento.Columns.Add("Hora_Fin", Type.GetType("System.String"))
        dtevento.Columns.Add("Edificio", Type.GetType("System.String"))
        dtevento.Columns.Add("Salón", Type.GetType("System.String"))


        dt2.Columns.Add("NRC", Type.GetType("System.String"))
        dt2.Columns.Add("Descripcion", Type.GetType("System.String"))


        dtevento.Rows.Add()
        dtevento.Rows(dtevento.Rows.Count - 1).Item(0) = "C3670"
        dtevento.Rows(dtevento.Rows.Count - 1).Item(1) = "VIN-MED PRUEBA"
        dtevento.Rows(dtevento.Rows.Count - 1).Item(2) = ""
        dtevento.Rows(dtevento.Rows.Count - 1).Item(3) = ""
        dtevento.Rows(dtevento.Rows.Count - 1).Item(4) = "VIÑA DEL MAR"
        dtevento.Rows(dtevento.Rows.Count - 1).Item(5) = "07/01/2015"
        dtevento.Rows(dtevento.Rows.Count - 1).Item(6) = "07/01/2015"
        dtevento.Rows(dtevento.Rows.Count - 1).Item(7) = "Miércoles"
        dtevento.Rows(dtevento.Rows.Count - 1).Item(8) = "14:45"
        dtevento.Rows(dtevento.Rows.Count - 1).Item(9) = "12:10"
        dtevento.Rows(dtevento.Rows.Count - 1).Item(10) = "VM"
        dtevento.Rows(dtevento.Rows.Count - 1).Item(11) = "SAL202"

        dt2.Rows.Add()
        dt2.Rows(dt2.Rows.Count - 1).Item(0) = "C3670"
        dt2.Rows(dt2.Rows.Count - 1).Item(1) = "Fecha fuera de rango"

        Dim target As GHAU_CapaNegocio.Eventos = New GHAU_CapaNegocio.Eventos ' TODO: Inicializar en un valor adecuado
        Dim dato As System.Data.DataTable = dtevento ' TODO: Inicializar en un valor adecuado
        Dim expected As System.Data.DataTable = dt2 ' TODO: Inicializar en un valor adecuado
        Dim actual As System.Data.DataTable
        actual = target.ingreso_evento(dato)
        For i = 0 To dt2.Rows.Count - 1
            Dim x1 = expected.Rows(i).Item(0)
            Dim x2 = actual.Rows(i).Item(0)
            Dim y1 = expected.Rows(i).Item(1)
            Dim y2 = actual.Rows(i).Item(1)
            Assert.AreEqual(x1, x2)
            Assert.AreEqual(y1, y2)
        Next
    End Sub
End Class
