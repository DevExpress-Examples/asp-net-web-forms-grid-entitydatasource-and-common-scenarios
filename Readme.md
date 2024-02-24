<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128541074/20.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3251)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Grid View for ASP.NET Web Forms - How to implement common scenarios within a grid bound with Entity Framework 6

This example demonstrates how to bind [ASPxGridView](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView) with Entity Framework 6 and implement common scenarios: CRUD operations, a master-detail grid, a lookup column, and server mode. 

## Implementation Details

### CRUD Operations

Follow the steps below to enable CRUD operations in ASPxGridView.

#### Insert a Row

1. Handle the [RowInserting](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.RowInserting) event.
2. Create a `DataContext` instance.
3. Create a new data item and fill its properties from the [e.NewValues](https://docs.devexpress.com/AspNet/DevExpress.Web.Data.ASPxDataInsertingEventArgs.NewValues) dictionary.
4. Add a new data item to the corresponding table.
5. Save changes.
6. Set the [e.Cancel](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.canceleventargs.cancel) property to `true` to cancel the operation.
7. Call the [CancelEdit](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.CancelEdit) method to close the edit form.  


```html
<dx:ASPxGridView ID="grid" runat="server" KeyFieldName="ProductID" OnRowInserting="grid_RowInserting" ...>
```
```csharp
public Model1 DataContext { ... }

protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e) {
    var product = new Product();
    product.ProductName = (string)e.NewValues["ProductName"];
    product.UnitPrice = (decimal)e.NewValues["UnitPrice"];
    DataContext.Products.Add(product);
    DataContext.SaveChanges();
    e.Cancel = true;
    grid.CancelEdit();
}
```

#### Edit a Row

1. Handle the [RowUpdating](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.RowUpdating) event.
2. Create a `DataContext` instance.
3. Use the [e.Keys](https://docs.devexpress.com/AspNet/DevExpress.Web.Data.ASPxDataUpdatingEventArgs.Keys) property to get the processed data item. 
4. Edit data item properties.
5. Save changes.
6. Set the [e.Cancel](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.canceleventargs.cancel) property to `true` to cancel the operation.
7. Call the [CancelEdit](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.CancelEdit) method to close the edit form.

```html
<dx:ASPxGridView ID="grid" runat="server" KeyFieldName="ProductID" OnRowUpdating="grid_RowUpdating" ...>
```
```csharp
public Model1 DataContext { ... }

protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
    int productID = (int)e.Keys[grid.KeyFieldName];
    Product product = DataContext.Products.Where(p => p.ProductID == productID).FirstOrDefault();
    product.ProductName = (string)e.NewValues["ProductName"];
    product.UnitPrice = (decimal)e.NewValues["UnitPrice"];
    DataContext.SaveChanges();
    e.Cancel = true;
    grid.CancelEdit();
}
```

#### Delete a Row

1. Handle the [RowDeleting](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.RowDeleting) event.
2. Create a `DataContext` instance.
3. Use the [e.Keys](https://docs.devexpress.com/AspNet/DevExpress.Web.Data.ASPxDataDeletingEventArgs.Keys) property to get the processed data item. 
4. Remove the data item.
5. Save changes.
6. Set the [e.Cancel](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.canceleventargs.cancel) property to `true` to cancel the operation.

```html
<dx:ASPxGridView ID="grid" runat="server" KeyFieldName="ProductID" OnRowDeleting="grid_RowDeleting" ...>
```
```csharp
public Model1 DataContext { ... }

protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e) {
    int productID = (int)e.Keys[grid.KeyFieldName];
    Product product = DataContext.Products.Where(p => p.ProductID == productID).FirstOrDefault();
    DataContext.Products.Remove(product);
    DataContext.SaveChanges();
    e.Cancel = true;
}
```

#### Files to Review

* [CustomEditingCapabilities.aspx](./CS/GridEntityFramework/CustomEditingCapabilities.aspx) (VB: [CustomEditingCapabilities.aspx](./VB/GridEntityFramework/CustomEditingCapabilities.aspx))
* [CustomEditingCapabilities.aspx.cs](./CS/GridEntityFramework/CustomEditingCapabilities.aspx.cs) (VB: [CustomEditingCapabilities.aspx.vb](./VB/GridEntityFramework/CustomEditingCapabilities.aspx.vb))

## Master-Detail Layout

1. Place an `ASPxGridView` control in the [DetailRow](https://docs.devexpress.com/AspNet/DevExpress.Web.GridViewTemplates.DetailRow) grid template to create a master-detail grid layout.
2. Handle the detail grid's `Init` event to bind the grid. Call the [GetMasterRowKeyValue](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.GetMasterRowKeyValue) method to get the current master row's key value.

```html
<dx:ASPxGridView ID="gridMaster" runat="server" AutoGenerateColumns="False" 
    OnDataBinding="gridMaster_DataBinding" KeyFieldName="CategoryID">
    <Columns> ... </Columns>
    <Templates>
        <DetailRow>
            <dx:ASPxGridView ID="gridDetail" runat="server"
                AutoGenerateColumns="False" OnInit="gridDetail_Init" KeyFieldName="ProductID">
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
```

```csharp
protected void gridMaster_DataBinding(object sender, EventArgs e) {
    gridMaster.ForceDataRowType(typeof(Category));
    gridMaster.DataSource = DataContext.Categories.ToList();
}

protected void gridDetail_Init(object sender, EventArgs e) {
    ASPxGridView grid = sender as ASPxGridView;
    int masterKey = (int)grid.GetMasterRowKeyValue();
    grid.DataSource = DataContext.Products.Where(p => p.CategoryID == masterKey).ToList();
    grid.DataBind();
}
```

#### Files to Review

* [MasterDetail.aspx](./CS/GridEntityFramework/MasterDetail.aspx) (VB: [MasterDetail.aspx](./VB/GridEntityFramework/MasterDetail.aspx))
* [MasterDetail.aspx.cs](./CS/GridEntityFramework/MasterDetail.aspx.cs) (VB: [MasterDetail.aspx.vb](./VB/GridEntityFramework/MasterDetail.aspx.vb))

## Lookup Column
  
Add a column of the [GridViewDataComboBoxColumn](https://docs.devexpress.com/AspNet/DevExpress.Web.GridViewDataComboBoxColumn) type in the [Columns](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.Columns) collection to create a lookup column in the grid. Bind the column to a data source in the `Page_Init` event.
  
```html
<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="ProductID" ...>
    <Columns>
        ...
        <dx:GridViewDataComboBoxColumn Caption="Category" FieldName="CategoryID" >
            <PropertiesComboBox TextField="CategoryName" ValueField="CategoryID" ValueType="System.Int32" />
        </dx:GridViewDataComboBoxColumn>
    </Columns>
</dx:ASPxGridView>
```

```csharp
protected void Page_Init(object sender, EventArgs e) {
    ((GridViewDataComboBoxColumn)grid.DataColumns["CategoryID"]).PropertiesComboBox.DataSource = DataContext.Categories.ToList();

}
```

#### Files to Review

* [LookUpColumn.aspx](./CS/GridEntityFramework/LookUpColumn.aspx) (VB: [LookUpColumn.aspx](./VB/GridEntityFramework/LookUpColumn.aspx))
* [LookUpColumn.aspx.cs](./CS/GridEntityFramework/LookUpColumn.aspx.cs) (VB: [LookUpColumn.aspx.vb](./VB/GridEntityFramework/LookUpColumn.aspx.vb))

## Server Mode

Use the [EntityServerModeDataSource](https://docs.devexpress.com/AspNet/DevExpress.Data.Linq.EntityServerModeDataSource) component to bind the `ASPxGridView` control to a data source with the Entity Framework, and enable [database server mode](https://docs.devexpress.com/AspNet/17292/components/grid-view/concepts/bind-to-data/binding-to-large-data-database-server-mode/data-binding-to-large-data-via-ef).

```html  
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerModeEF.aspx.cs" Inherits="GridEntityFramework.ServerModeEF" %>

<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="ProductID" OnDataBinding="grid_DataBinding">
    <Columns> ... </Columns>
</dx:ASPxGridView>
```  

```csharp
protected void grid_DataBinding(object sender, EventArgs e) {
    (sender as ASPxGridView).DataSource = GetEntityServerModeSource();
}
private EntityServerModeSource GetEntityServerModeSource() {
    EntityServerModeSource esms = new EntityServerModeSource();
    esms.QueryableSource = DataContext.Products;
    esms.KeyExpression = "ProductID";

    return esms;
}
```

#### Files to Review

* [ServerModeEF.aspx](./CS/GridEntityFramework/ServerModeEF.aspx) (VB: [ServerModeEF.aspx](./VB/GridEntityFramework/ServerModeEF.aspx))
* [ServerModeEF.aspx.cs](./CS/GridEntityFramework/ServerModeEF.aspx.cs) (VB: [ServerModeEF.aspx.vb](./VB/GridEntityFramework/ServerModeEF.aspx.vb))
 
## Files to Review

* [CustomEditingCapabilities.aspx](./CS/GridEntityFramework/CustomEditingCapabilities.aspx) (VB: [CustomEditingCapabilities.aspx](./VB/GridEntityFramework/CustomEditingCapabilities.aspx))
* [CustomEditingCapabilities.aspx.cs](./CS/GridEntityFramework/CustomEditingCapabilities.aspx.cs) (VB: [CustomEditingCapabilities.aspx.vb](./VB/GridEntityFramework/CustomEditingCapabilities.aspx.vb))
* [LookUpColumn.aspx](./CS/GridEntityFramework/LookUpColumn.aspx) (VB: [LookUpColumn.aspx](./VB/GridEntityFramework/LookUpColumn.aspx))
* [LookUpColumn.aspx.cs](./CS/GridEntityFramework/LookUpColumn.aspx.cs) (VB: [LookUpColumn.aspx.vb](./VB/GridEntityFramework/LookUpColumn.aspx.vb))
* [MasterDetail.aspx](./CS/GridEntityFramework/MasterDetail.aspx) (VB: [MasterDetail.aspx](./VB/GridEntityFramework/MasterDetail.aspx))
* [MasterDetail.aspx.cs](./CS/GridEntityFramework/MasterDetail.aspx.cs) (VB: [MasterDetail.aspx.vb](./VB/GridEntityFramework/MasterDetail.aspx.vb))
* [ServerModeEF.aspx](./CS/GridEntityFramework/ServerModeEF.aspx) (VB: [ServerModeEF.aspx](./VB/GridEntityFramework/ServerModeEF.aspx))
* [ServerModeEF.aspx.cs](./CS/GridEntityFramework/ServerModeEF.aspx.cs) (VB: [ServerModeEF.aspx.vb](./VB/GridEntityFramework/ServerModeEF.aspx.vb))


## Documentation

* [How to adjust GridView to work with Stored Procedures (EntityFramework)](https://supportcenter.devexpress.com/ticket/details/k18520/how-to-adjust-gridview-to-work-with-stored-procedures-entityframework)  

## More Examples

* [Grid View for ASP.NET MVC - How to bind grid to Entity Framework in regular and database server modes](https://github.com/DevExpress-Examples/asp-net-mvc-grid-bind-to-entity-framework)
