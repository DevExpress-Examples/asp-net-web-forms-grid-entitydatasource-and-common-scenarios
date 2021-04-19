Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Collections
Imports DevExpress.Web

Partial Public Class CustomEditingCapabilities
	Inherits System.Web.UI.Page
	Private _dataContext As NorthwindModel.NorthwindEntities
	Public ReadOnly Property DataContext() As NorthwindModel.NorthwindEntities
		Get
			If Me._dataContext Is Nothing Then
				Me._dataContext = New NorthwindModel.NorthwindEntities()
			End If
			Return Me._dataContext
		End Get
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsCallback) AndAlso (Not IsPostBack) Then
			grid.DataBind()
		End If
	End Sub

	Protected Sub grid_CustomErrorText(ByVal sender As Object, ByVal e As ASPxGridViewCustomErrorTextEventArgs)
		If e.Exception.InnerException IsNot Nothing Then
			e.ErrorText += String.Format("{0}InnerException: '{1}'", Environment.NewLine, e.Exception.InnerException.Message)
		End If
	End Sub

	Protected Sub grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
		Dim gridView As ASPxGridView = CType(sender, ASPxGridView)
		gridView.ForceDataRowType(GetType(NorthwindModel.Categories))

		gridView.DataSource = DataContext.Categories
		'gridView.DataSource = DataContext.Categories.Select("it.CategoryID, it.CategoryName, it.Description");
	End Sub
	Protected Sub grid_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
		Dim gridView As ASPxGridView = CType(sender, ASPxGridView)

		Dim categoryID As Integer = CInt(Fix(e.Keys(gridView.KeyFieldName)))
		Dim category As NorthwindModel.Categories = DataContext.Categories.Where(Function(c) c.CategoryID = categoryID).FirstOrDefault()

		DataContext.DeleteObject(category)
		DataContext.SaveChanges()

		e.Cancel = True
	End Sub
	Protected Sub grid_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
		Dim gridView As ASPxGridView = CType(sender, ASPxGridView)

		Dim category As New NorthwindModel.Categories()

		category.CategoryName = e.NewValues("CategoryName").ToString()
		category.Description = e.NewValues("Description").ToString()

		DataContext.AddToCategories(category)
		DataContext.SaveChanges()

		e.Cancel = True
		gridView.CancelEdit()
	End Sub
	Protected Sub grid_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
		Dim gridView As ASPxGridView = CType(sender, ASPxGridView)

		Dim categoryID As Integer = CInt(Fix(e.Keys(gridView.KeyFieldName)))
		Dim category As NorthwindModel.Categories = DataContext.Categories.Where(Function(c) c.CategoryID = categoryID).FirstOrDefault()

		category.CategoryName = e.NewValues("CategoryName").ToString()
		category.Description = e.NewValues("Description").ToString()

		DataContext.SaveChanges()

		e.Cancel = True
		gridView.CancelEdit()
	End Sub

End Class
