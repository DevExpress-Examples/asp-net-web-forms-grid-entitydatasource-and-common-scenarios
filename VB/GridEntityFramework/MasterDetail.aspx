<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterDetail.aspx.cs" Inherits="GridEntityFramework.MasterDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Detail Grid</title>
</head>
<body>
    <form id="form1" runat="server">
       <dx:ASPxGridView ID="gridMaster" runat="server" AutoGenerateColumns="False" OnDataBinding="gridMaster_DataBinding"
                KeyFieldName="CategoryID">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="CategoryID" VisibleIndex="0">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="gridDetail" runat="server"
                            AutoGenerateColumns="False" OnInit="gridDetail_Init" KeyFieldName="ProductID">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ProductID" VisibleIndex="0">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="3">
                                </dx:GridViewDataCheckColumn>
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
