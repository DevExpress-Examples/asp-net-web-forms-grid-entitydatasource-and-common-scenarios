<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="MasterDetail.aspx.vb" Inherits="GridEntityFramework.MasterDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Detail Grid</title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxGridView ID="gridMaster" runat="server" AutoGenerateColumns="False" OnDataBinding="gridMaster_DataBinding" KeyFieldName="CategoryID">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="CategoryID" >
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CategoryName" />
                <dx:GridViewDataTextColumn FieldName="Description" />
            </Columns>
            <Templates>
                <DetailRow>
                    <dx:ASPxGridView ID="gridDetail" runat="server" AutoGenerateColumns="False" OnInit="gridDetail_Init" KeyFieldName="ProductID">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="ProductID" >
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ProductName" />
                            <dx:GridViewDataTextColumn FieldName="UnitPrice" />
                            <dx:GridViewDataCheckColumn FieldName="Discontinued" />
                        </Columns>
                    </dx:ASPxGridView>
                </DetailRow>
            </Templates>
            <SettingsDetail ShowDetailRow="true" />
        </dx:ASPxGridView>
    </div>
    <br />
    <a href="Default.aspx"><< Home</a>
    </form>
</body>
</html>
