<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="ServerModeEF.aspx.vb" Inherits="GridEntityFramework.ServerModeEF" %>

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
                <dx:GridViewDataTextColumn FieldName="ProductID" />
                <dx:GridViewDataTextColumn FieldName="ProductName" />
                <dx:GridViewDataTextColumn FieldName="UnitPrice" />
                <dx:GridViewDataCheckColumn FieldName="Discontinued" />
            </Columns>
        </dx:ASPxGridView>
    </div>
    <br />
    <a href="Default.aspx"><< Home</a>
    </form>
</body>
</html>
