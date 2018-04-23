Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web

'DevExpress.Xpf.Core.vXX.Y.dll
Imports DevExpress.Data.Linq
'DevExpress.Xpf.Core.vXX.Y.dll

Partial Public Class ServerModeEF
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsCallback) AndAlso (Not IsPostBack) Then
			grid.DataBind()
		End If
	End Sub
	Protected Sub grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        CType(sender, ASPxGridView).DataSource = GetEntityServerModeSource()
	End Sub
	Private Function GetEntityServerModeSource() As EntityServerModeSource
		Dim esms As New EntityServerModeSource()
		esms.QueryableSource = New NorthwindModel.NorthwindEntities().Products
		esms.KeyExpression = "ProductID"

		Return esms
	End Function
End Class