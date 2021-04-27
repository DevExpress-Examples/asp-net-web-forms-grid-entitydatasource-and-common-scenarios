Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace GridEntityFramework
	Partial Public Class LookUpColumn
		Inherits System.Web.UI.Page

		Private _dataContext As Model1

		Public ReadOnly Property DataContext() As Model1
			Get
				If _dataContext Is Nothing Then
					_dataContext = New Model1()
				End If

				Return _dataContext
			End Get
		End Property
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			CType(grid.DataColumns("CategoryID"), GridViewDataComboBoxColumn).PropertiesComboBox.DataSource = DataContext.Categories.ToList()

		End Sub
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If Not IsCallback AndAlso Not IsPostBack Then
				grid.DataBind()
			End If
		End Sub

		Protected Sub grid_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
			Dim productID As Integer = CInt(Math.Truncate(e.Keys(grid.KeyFieldName)))
			Dim product As Product = DataContext.Products.Where(Function(p) p.ProductID = productID).FirstOrDefault()
			DataContext.Products.Remove(product)
			DataContext.SaveChanges()
			e.Cancel = True
		End Sub

		Protected Sub grid_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
			Dim product As New Product()
			product.ProductName = CStr(e.NewValues("ProductName"))
			product.UnitPrice = CDec(e.NewValues("UnitPrice"))
			product.CategoryID = CInt(Math.Truncate(e.NewValues("CategoryID")))
			DataContext.Products.Add(product)
			DataContext.SaveChanges()
			e.Cancel = True
			grid.CancelEdit()
		End Sub

		Protected Sub grid_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
			Dim productID As Integer = CInt(Math.Truncate(e.Keys(grid.KeyFieldName)))
			Dim product As Product = DataContext.Products.Where(Function(p) p.ProductID = productID).FirstOrDefault()
			product.ProductName = CStr(e.NewValues("ProductName"))
			product.UnitPrice = CDec(e.NewValues("UnitPrice"))
			product.CategoryID = CInt(Math.Truncate(e.NewValues("CategoryID")))
			DataContext.SaveChanges()
			e.Cancel = True
			grid.CancelEdit()
		End Sub
		Protected Sub grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
			grid.ForceDataRowType(GetType(Product))
			grid.DataSource = DataContext.Products.ToList()
		End Sub
	End Class
End Namespace