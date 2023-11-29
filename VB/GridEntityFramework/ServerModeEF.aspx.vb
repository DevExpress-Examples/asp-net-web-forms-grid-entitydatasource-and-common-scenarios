Imports DevExpress.Data.Linq
Imports DevExpress.Web
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace GridEntityFramework

    Public Partial Class ServerModeEF
        Inherits Page

        Private _dataContext As Model1

        Public ReadOnly Property DataContext As Model1
            Get
                If _dataContext Is Nothing Then
                    _dataContext = New Model1()
                End If

                Return _dataContext
            End Get
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsCallback AndAlso Not IsPostBack Then grid.DataBind()
        End Sub

        Protected Sub grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
            TryCast(sender, ASPxGridView).DataSource = GetEntityServerModeSource()
        End Sub

        Private Function GetEntityServerModeSource() As EntityServerModeSource
            Dim esms As EntityServerModeSource = New EntityServerModeSource()
            esms.QueryableSource = DataContext.Products
            esms.KeyExpression = "ProductID"
            Return esms
        End Function
    End Class
End Namespace
