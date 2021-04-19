using System;
using DevExpress.Web;

/*DevExpress.Xpf.Core.vXX.Y.dll*/
using DevExpress.Data.Linq;
/*DevExpress.Xpf.Core.vXX.Y.dll*/

public partial class ServerModeEF : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsCallback && !IsPostBack)
            grid.DataBind();
    }
    protected void grid_DataBinding(object sender, EventArgs e) {
        (sender as ASPxGridView).DataSource = GetEntityServerModeSource();
    }
    private EntityServerModeSource GetEntityServerModeSource() {
        EntityServerModeSource esms = new EntityServerModeSource();
        esms.QueryableSource = new NorthwindModel.NorthwindEntities().Products;
        esms.KeyExpression = "ProductID";

        return esms;
    }
}