Option Strict On
Public Class car

    Private Shared carCount As Integer                  ' static or shared private variable to hold the number of cars
    Private carIdentificationNumber As Integer = 0      ' private variable to hold the car's identification number
    Private carMaker As String = String.Empty           ' private variable to hold the car's maker
    Private carModel As String = String.Empty           ' private variable to hold the car's model
    Private carYear As String = String.Empty            ' private variable to hold the car's year
    Private carPrice As Integer = 0                     ' private variable to hold the car's price
    Private carNewStatus As Boolean = False             ' private variable to hold the car's new status

    ''' <summary>
    ''' Constructor - Default - creates a new car object
    ''' </summary>
    Public Sub New()

        carCount += 1      ' increment the shared/static variable counter by 1
        carIdentificationNumber = carCount ' assign the car id

    End Sub

    ''' <summary>
    ''' Constructor - Parameterized - creates a new car object
    ''' </summary>
    ''' <param name="maker"></param>
    ''' <param name="model"></param>
    ''' <param name="year"></param>
    ''' <param name="newStatus"></param>
    Public Sub New(maker As String, model As String, year As String, price As String, newStatus As Boolean)

        ' call the other constructor 
        ' to set the car count and
        ' to set the car id
        Me.New()

        carMaker = maker                ' set the maker
        carModel = model                ' set the model
        carYear = year                  ' set the manufacture year
        carPrice = CInt(price)          ' set the price
        carNewStatus = newStatus        ' set the car status

    End Sub

    ''' <summary>
    ''' Count ReadOnly Property - Gets the number of cars that have been instantiated/created
    ''' </summary>
    ''' <returns>Integer</returns>
    Public ReadOnly Property Count() As Integer
        Get
            Return carCount
        End Get
    End Property

    ''' <summary>
    ''' IdentificationNumber ReadOnly Property - Gets a specific car's identification number
    ''' </summary>
    ''' <returns>Integer</returns>
    Public ReadOnly Property IdentificationNumber() As Integer
        Get
            Return carIdentificationNumber
        End Get
    End Property

    ''' <summary>
    ''' NewStatus Property - Gets and Sets the new status of a car
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Property NewStatus() As Boolean
        Get
            Return carNewStatus
        End Get
        Set(ByVal value As Boolean)
            carNewStatus = value
        End Set
    End Property

    ''' <summary>
    ''' Maker property - Gets and Sets the maker of a car
    ''' </summary>
    ''' <returns>String</returns>
    Public Property Maker() As String
        Get
            Return carMaker
        End Get
        Set(ByVal value As String)
            carMaker = value
        End Set
    End Property

    ''' <summary>
    ''' Model property - Gets and Sets the model of a car
    ''' </summary>
    ''' <returns>String</returns>
    Public Property Model() As String
        Get
            Return carModel
        End Get
        Set(ByVal value As String)
            carModel = value
        End Set
    End Property
    ''' <summary>
    ''' Year property - Gets and Sets the manufacture year of a car
    ''' </summary>
    ''' <returns>String</returns>
    Public Property Year() As String
        Get
            Return carYear
        End Get
        Set(ByVal value As String)
            carYear = value
        End Set
    End Property

    ''' <summary>
    ''' Price property - Gets and Sets the price of a car
    ''' </summary>
    ''' <returns>String</returns>
    Public Property Price() As Integer
        Get
            Return carPrice
        End Get
        Set(ByVal value As Integer)
            carPrice = value
        End Set
    End Property


End Class
