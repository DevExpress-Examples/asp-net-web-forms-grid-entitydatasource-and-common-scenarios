using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EF6_ASPxGridView_sample
{
    public partial class Default : System.Web.UI.Page
    {
        private Model1 _dataContext;

        public Model1 DataContext
        {
            get
            {
                if (_dataContext is null)
                {
                    _dataContext = new Model1();
                }

                return _dataContext;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback && !IsPostBack)
            {
                grid.DataBind();
            }
        }

        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int productID = (int)e.Keys[grid.KeyFieldName];
            Product product = DataContext.Products.Where(p => p.ProductID == productID).FirstOrDefault();
            DataContext.Products.Remove(product);
            DataContext.SaveChanges();
            e.Cancel = true;
        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var product = new Product();
            product.ProductName = (string)e.NewValues["ProductName"];
            product.UnitPrice = (decimal)e.NewValues["UnitPrice"];
            DataContext.Products.Add(product);
            DataContext.SaveChanges();
            e.Cancel = true;
            grid.CancelEdit();
        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int productID = (int)e.Keys[grid.KeyFieldName];
            Product product = DataContext.Products.Where(p => p.ProductID == productID).FirstOrDefault();
            product.ProductName = (string)e.NewValues["ProductName"];
            product.UnitPrice = (decimal)e.NewValues["UnitPrice"];
            DataContext.SaveChanges();
            e.Cancel = true;
            grid.CancelEdit();
        }

        protected void grid_DataBinding(object sender, EventArgs e)
        {
            grid.ForceDataRowType(typeof(Product));
            grid.DataSource = DataContext.Products.ToList();
        }
    }
}