using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridEntityFramework {
    public partial class MasterDetail : System.Web.UI.Page {
        private Model1 _dataContext;

        public Model1 DataContext {
            get {
                if (_dataContext == null) {
                    _dataContext = new Model1();
                }

                return _dataContext;
            }
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsCallback && !IsPostBack) {
                gridMaster.DataBind();
            }
        }

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
    }
}
