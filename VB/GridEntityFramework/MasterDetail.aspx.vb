Imports DevExpress.Web
Imports System
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace GridEntityFramework

    Public Partial Class MasterDetail
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
            If Not IsCallback AndAlso Not IsPostBack Then
                gridMaster.DataBind()
            End If
        End Sub

        Protected Sub gridMaster_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
            gridMaster.ForceDataRowType(GetType(Category))
            gridMaster.DataSource = DataContext.Categories.ToList()
        End Sub

        Protected Sub gridDetail_Init(ByVal sender As Object, ByVal e As EventArgs)
            Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
            Dim masterKey As Integer = CInt(grid.GetMasterRowKeyValue())
            grid.DataSource = DataContext.Products.Where(Function(p) p.CategoryID = masterKey).ToList()
            grid.DataBind()
        End Sub
    End Class
End Namespace
