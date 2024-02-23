<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookUpColumn.aspx.cs" Inherits="GridEntityFramework.LookUpColumn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lookup Column</title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" 
                OnDataBinding="grid_DataBinding"
                OnRowDeleting="grid_RowDeleting" 
				OnRowInserting="grid_RowInserting" 
				OnRowUpdating="grid_RowUpdating"
                KeyFieldName="ProductID">
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" />
                    <dx:GridViewDataTextColumn FieldName="ProductID" >
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ProductName" />
                    <dx:GridViewDataTextColumn FieldName="UnitPrice" /
                    <dx:GridViewDataComboBoxColumn Caption="Category" FieldName="CategoryID" >
                        <PropertiesComboBox TextField="CategoryName" ValueField="CategoryID" ValueType="System.Int32" />
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
            </dx:ASPxGridView>
        </div>
        <br />
        <a href="Default.aspx"><< Home</a>
    </form>
</body>
</html>
