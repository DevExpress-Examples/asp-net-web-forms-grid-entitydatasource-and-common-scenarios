Imports Microsoft.VisualBasic
Imports System

Partial Public Class ServerModeLinqObsolete
	Inherits System.Web.UI.Page
	Protected Sub serverModeDataSource_Selecting(ByVal sender As Object, ByVal e As DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs)
		Dim dataContext As New NorthwindModel.NorthwindEntities()
		e.QueryableSource = dataContext.Products
		e.KeyExpression = "ProductID"
	End Sub
End Class