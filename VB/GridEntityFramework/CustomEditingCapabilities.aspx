<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="CustomEditingCapabilities.aspx.vb" Inherits="GridEntityFramework.CustomEditingCapabilities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom Editing Capabilities</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="grid" runat="server" KeyFieldName="ProductID"
                OnDataBinding="grid_DataBinding"
                OnRowDeleting="grid_RowDeleting"
                OnRowInserting="grid_RowInserting"
                OnRowUpdating="grid_RowUpdating">
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" />
                    <dx:GridViewDataTextColumn FieldName="ProductID" EditFormSettings-Visible="False" />
                    <dx:GridViewDataTextColumn FieldName="ProductName" />
                    <dx:GridViewDataTextColumn FieldName="UnitPrice" />
                </Columns>
            </dx:ASPxGridView>
        </div>
        <br />
        <a href="Default.aspx"><< Home</a>
    </form>
</body>
</html>
