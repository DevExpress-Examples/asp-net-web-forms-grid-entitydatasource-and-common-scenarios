Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web

Partial Public Class AutomaticEditingCapabilities
	Inherits System.Web.UI.Page
	Protected Sub grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        CType(sender, ASPxGridView).ForceDataRowType(GetType(NorthwindModel.Categories))
	End Sub
End Class