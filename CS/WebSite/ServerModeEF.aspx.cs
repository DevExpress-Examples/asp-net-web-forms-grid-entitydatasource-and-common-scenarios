using System;
using DevExpress.Web;
using DevExpress.Data.Linq;

public partial class ServerModeEF : System.Web.UI.Page {
    private Model1 _dataContext;

    public Model1 DataContext
    {
        get
        {
            if (_dataContext == null)
            {
                _dataContext = new Model1();
            }

            return _dataContext;
        }
    }
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsCallback && !IsPostBack)
            grid.DataBind();
    }
    protected void grid_DataBinding(object sender, EventArgs e) {
        (sender as ASPxGridView).DataSource = GetEntityServerModeSource();
    }
    private EntityServerModeSource GetEntityServerModeSource() {
        EntityServerModeSource esms = new EntityServerModeSource();
        esms.QueryableSource = DataContext.Products;
        esms.KeyExpression = "ProductID";

        return esms;
    }
}