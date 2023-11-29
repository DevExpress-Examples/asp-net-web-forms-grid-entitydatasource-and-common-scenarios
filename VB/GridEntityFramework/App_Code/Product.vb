Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel.DataAnnotations

Namespace GridEntityFramework

    Public Partial Class Product

        Public Property ProductID As Integer

        <Required>
        <StringLength(40)>
        Public Property ProductName As String

        Public Property SupplierID As Integer?

        Public Property CategoryID As Integer?

        <StringLength(20)>
        Public Property QuantityPerUnit As String

        <Column(TypeName:="money")>
        Public Property UnitPrice As Decimal?

        Public Property UnitsInStock As Short?

        Public Property UnitsOnOrder As Short?

        Public Property ReorderLevel As Short?

        Public Property Discontinued As Boolean

        Public Overridable Property Category As Category
    End Class
End Namespace
