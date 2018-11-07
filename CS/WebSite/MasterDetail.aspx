<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MasterDetail.aspx.cs" Inherits="MasterDetail" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="mainForm" runat="server">
    <div>
        <dx:ASPxGridView ID="gridMaster" runat="server" AutoGenerateColumns="False" DataSourceID="masterDS"
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
                    <dx:ASPxGridView ID="gridDetail" runat="server" OnBeforePerformDataSelect="gridDetail_BeforePerformDataSelect"
                        AutoGenerateColumns="False" DataSourceID="detailDS" KeyFieldName="ProductID">
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
    <br /><a href="Default.aspx"><< Home</a>
    <!--Master Grid DataSource-->
    <asp:EntityDataSource ID="masterDS" runat="server" ConnectionString="name=NorthwindEntities"
        DefaultContainerName="NorthwindEntities" EntitySetName="Categories">
    </asp:EntityDataSource>
    <!---->
    <!--Detail Grid DataSource-->
    <asp:EntityDataSource ID="detailDS" runat="server" ConnectionString="name=NorthwindEntities"
        DefaultContainerName="NorthwindEntities" EntitySetName="Products" Where="it.[Categories].[CategoryID] = @parCategoryID">
        <WhereParameters>
            <asp:SessionParameter DbType="Int32" Name="parCategoryID" SessionField="SessionCategoryID" />
        </WhereParameters>
    </asp:EntityDataSource>
    <!---->
    </form>
</body>
</html>