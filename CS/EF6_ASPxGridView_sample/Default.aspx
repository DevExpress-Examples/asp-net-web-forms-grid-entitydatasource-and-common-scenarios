<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EF6_ASPxGridView_sample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to bind ASPxGridView and implement CRUD with EF6</title>
</head>
<body>
    <form id="form1" runat="server">
        	<dx:ASPxGridView ID="grid" runat="server" KeyFieldName="ProductID" 
				OnDataBinding="grid_DataBinding"
				OnRowDeleting="grid_RowDeleting" 
				OnRowInserting="grid_RowInserting" 
				OnRowUpdating="grid_RowUpdating">
				<Columns>
					<dx:GridViewCommandColumn ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true"></dx:GridViewCommandColumn>
					<dx:GridViewDataTextColumn FieldName="ProductID" EditFormSettings-Visible="False"/>
					<dx:GridViewDataTextColumn FieldName="ProductName" />
					<dx:GridViewDataTextColumn FieldName="UnitPrice"/>
				</Columns>
			</dx:ASPxGridView>
    </form>
</body>
</html>
