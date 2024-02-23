using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridEntityFramework {
    public partial class LookUpColumn : System.Web.UI.Page {
        private Model1 _dataContext;

        public Model1 DataContext {
            get {
                if (_dataContext == null) {
                    _dataContext = new Model1();
                }
                return _dataContext;
            }
        }
        protected void Page_Init(object sender, EventArgs e) {
            ((GridViewDataComboBoxColumn)grid.DataColumns["CategoryID"]).PropertiesComboBox.DataSource = DataContext.Categories.ToList();

        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsCallback && !IsPostBack) {
                grid.DataBind();
            }
        }

        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e) {
            int productID = (int)e.Keys[grid.KeyFieldName];
            Product product = DataContext.Products.Where(p => p.ProductID == productID).FirstOrDefault();
            DataContext.Products.Remove(product);
            DataContext.SaveChanges();
            e.Cancel = true;
        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e) {
            var product = new Product();
            product.ProductName = (string)e.NewValues["ProductName"];
            product.UnitPrice = (decimal)e.NewValues["UnitPrice"];
            product.CategoryID = (int)e.NewValues["CategoryID"];
            DataContext.Products.Add(product);
            DataContext.SaveChanges();
            e.Cancel = true;
            grid.CancelEdit();
        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
            int productID = (int)e.Keys[grid.KeyFieldName];
            Product product = DataContext.Products.Where(p => p.ProductID == productID).FirstOrDefault();
            product.ProductName = (string)e.NewValues["ProductName"];
            product.UnitPrice = (decimal)e.NewValues["UnitPrice"];
            product.CategoryID = (int)e.NewValues["CategoryID"];
            DataContext.SaveChanges();
            e.Cancel = true;
            grid.CancelEdit();
        }
        protected void grid_DataBinding(object sender, EventArgs e) {
            grid.ForceDataRowType(typeof(Product));
            grid.DataSource = DataContext.Products.ToList();
        }
    }
}
