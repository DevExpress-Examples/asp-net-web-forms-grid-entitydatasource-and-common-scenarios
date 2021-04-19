<%@ Page Language="vb" AutoEventWireup="true" CodeFile="LookUpColumn.aspx.vb" Inherits="LookUpColumn" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="mainForm" runat="server">
	<div>
		<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="eds"
			KeyFieldName="ProductID">
			<Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True"/>
				<dx:GridViewDataTextColumn FieldName="ProductID" VisibleIndex="1">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="4">
				</dx:GridViewDataCheckColumn>
				<dx:GridViewDataComboBoxColumn Caption="Category" FieldName="Categories.CategoryID"
					VisibleIndex="5">
					<PropertiesComboBox DataSourceID="lookupDS" TextField="CategoryName" ValueField="CategoryID"
						ValueType="System.Int32">
					</PropertiesComboBox>
				</dx:GridViewDataComboBoxColumn>
			</Columns>
		</dx:ASPxGridView>
	</div>
	<br /><a href="Default.aspx"><< Home</a>
	<!--Grid DataSource-->
	<asp:EntityDataSource ID="eds" runat="server" ConnectionString="name=NorthwindEntities"
		DefaultContainerName="NorthwindEntities" EntitySetName="Products" EnableUpdate="True">
	</asp:EntityDataSource>
	<!---->
	<!--ComboBoxColumn DataSource-->
	<asp:EntityDataSource ID="lookupDS" runat="server" ConnectionString="name=NorthwindEntities"
		DefaultContainerName="NorthwindEntities" EntitySetName="Categories" Select="it.[CategoryID], it.[CategoryName]">
	</asp:EntityDataSource>
	<!---->
	</form>
</body>
</html>