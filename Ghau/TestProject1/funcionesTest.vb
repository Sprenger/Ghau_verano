Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports GHAU_CapaNegocio



'''<summary>
'''Se trata de una clase de prueba para funcionesTest y se pretende que
'''contenga todas las pruebas unitarias funcionesTest.
'''</summary>
<TestClass()> _
Public Class funcionesTest


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
            testContextInstance = Value
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
    '''Una prueba de modularizacion
    '''</summary>
    <TestMethod()> _
    Public Sub modularizacionTest()
        Dim target As GHAU_CapaNegocio.funciones = New GHAU_CapaNegocio.funciones ' TODO: Inicializar en un valor adecuado
        Dim inicio As String = "830" ' TODO: Inicializar en un valor adecuado
        Dim fin As String = "915" ' TODO: Inicializar en un valor adecuado
        Dim Jornada As String = "Evento" ' TODO: Inicializar en un valor adecuado
        Dim expected As String = "10000000000000000000" ' TODO: Inicializar en un valor adecuado
        Dim actual As String
        actual = target.modularizacion(inicio, fin, Jornada)
        Assert.AreEqual(expected, actual)

    End Sub
End Class
