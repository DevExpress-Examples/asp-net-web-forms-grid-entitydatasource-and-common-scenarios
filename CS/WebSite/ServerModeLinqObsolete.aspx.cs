using System;

public partial class ServerModeLinqObsolete : System.Web.UI.Page {
    protected void serverModeDataSource_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e) {
        NorthwindModel.NorthwindEntities dataContext = new NorthwindModel.NorthwindEntities();
        e.QueryableSource = dataContext.Products;
        e.KeyExpression = "ProductID";
    }
}