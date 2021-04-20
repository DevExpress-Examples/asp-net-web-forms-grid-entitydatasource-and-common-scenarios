<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LookUpColumn.aspx.cs" Inherits="LookUpColumn" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="mainForm" runat="server">
        <div>
            <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" 
                OnDataBinding="grid_DataBinding"
                OnRowDeleting="grid_RowDeleting" 
				OnRowInserting="grid_RowInserting" 
				OnRowUpdating="grid_RowUpdating"
                KeyFieldName="ProductID">
                <Columns>
                    <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" />
                    <dx:GridViewDataTextColumn FieldName="ProductID" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Category" FieldName="CategoryID"
                        VisibleIndex="5">
                        <PropertiesComboBox TextField="CategoryName" ValueField="CategoryID"
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
            </dx:ASPxGridView>
        </div>
        <br />
        <a href="Default.aspx"><< Home</a>
    </form>
</body>
</html>
