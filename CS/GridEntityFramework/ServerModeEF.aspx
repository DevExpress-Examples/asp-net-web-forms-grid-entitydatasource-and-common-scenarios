<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerModeEF.aspx.cs" Inherits="GridEntityFramework.ServerModeEF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entity Framework Server Mode</title>
</head>
<body>
    <form id="form1" runat="server">
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
