<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServerModeEF.aspx.cs" Inherits="ServerModeEF" %>
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
        <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="ProductID"
            OnDataBinding="grid_DataBinding">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="ProductID" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="3">
                </dx:GridViewDataCheckColumn>
            </Columns>
        </dx:ASPxGridView>
    </div>
    <br />
    <a href="Default.aspx"><< Home</a>
    </form>
</body>
</html>