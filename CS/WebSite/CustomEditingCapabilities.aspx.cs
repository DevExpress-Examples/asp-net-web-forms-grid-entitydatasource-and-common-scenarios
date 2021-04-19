using System;
using System.Linq;
using System.Collections;
using DevExpress.Web;

public partial class CustomEditingCapabilities : System.Web.UI.Page {
    private NorthwindModel.NorthwindEntities dataContext;
    public NorthwindModel.NorthwindEntities DataContext {
        get {
            if(this.dataContext == null)
                this.dataContext = new NorthwindModel.NorthwindEntities();
            return this.dataContext;
        }
    }

    protected void Page_Load(object sender, EventArgs e) {
        if(!IsCallback && !IsPostBack)
            grid.DataBind();
    }

    protected void grid_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e) {
        if(e.Exception.InnerException != null)
            e.ErrorText += string.Format("{0}InnerException: '{1}'", Environment.NewLine, e.Exception.InnerException.Message);
    }

    protected void grid_DataBinding(object sender, EventArgs e) {
        ASPxGridView gridView = (ASPxGridView)sender;
        gridView.ForceDataRowType(typeof(NorthwindModel.Categories));
        
        gridView.DataSource = DataContext.Categories;
        //gridView.DataSource = DataContext.Categories.Select("it.CategoryID, it.CategoryName, it.Description");
    }
    protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e) {
        ASPxGridView gridView = (ASPxGridView)sender;

        int categoryID = (int)e.Keys[gridView.KeyFieldName];
        NorthwindModel.Categories category = DataContext.Categories.Where(c => c.CategoryID == categoryID).FirstOrDefault();

        DataContext.DeleteObject(category);
        DataContext.SaveChanges();

        e.Cancel = true;
    }
    protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e) {
        ASPxGridView gridView = (ASPxGridView)sender;

        NorthwindModel.Categories category = new NorthwindModel.Categories();

        category.CategoryName = e.NewValues["CategoryName"].ToString();
        category.Description = e.NewValues["Description"].ToString();

        DataContext.AddToCategories(category);
        DataContext.SaveChanges();

        e.Cancel = true;
        gridView.CancelEdit();
    }
    protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
        ASPxGridView gridView = (ASPxGridView)sender;

        int categoryID = (int)e.Keys[gridView.KeyFieldName];
        NorthwindModel.Categories category = DataContext.Categories.Where(c => c.CategoryID == categoryID).FirstOrDefault();
        
        category.CategoryName = e.NewValues["CategoryName"].ToString();
        category.Description = e.NewValues["Description"].ToString();

        DataContext.SaveChanges();

        e.Cancel = true;
        gridView.CancelEdit();
    }

}
