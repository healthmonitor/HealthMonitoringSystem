
using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace HealthMonitorSystem
{
	public partial class DoctorsPage : BasePage
	{
		private static string _strSort;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(this.UserId<=0)
		{
			this.ErrorMessage = "Please login to the System";
			Response.Redirect("Default.aspx", true);
		}
    }

    protected override void OnPreRender(EventArgs e)
    {
		try{
        base.OnPreRender(e);
        DataTable dt = this.RefreshData();
		if(dt!= null)
		{
        	if (!string.IsNullOrEmpty(_strSort))
        	{
            	DataView dv = dt.DefaultView;
            	dv.Sort = _strSort;
            	dt = dv.ToTable();
        	}
        	gv.DataSource = dt;
        	gv.DataBind(); 					
		}
		}catch(Exception ex)
		{
			this.ErrorMessage = ex.Message;
		}
    }

    private DataTable RefreshData()
    {
        string strSql = " select dr.*, l.*, l.lastname ||  ' ' || l.firstname as name" +
						" from doctorremarks dr " +
						" inner join login l on dr.patientid=l.id " +
						" where dr.doctorid = " + this.UserId;
        DataSet ds = BaseDA.ExecuteDataSet(strSql);
		if(ds!= null && ds.Tables.Count > 0)
		{
        	return ds.Tables[0];
		}
		return null;
    }

    protected void gv_RowEditing(object sender, GridViewCommandEventArgs e)
    {
			if(e.CommandName == "View")
			{
				Response.Redirect("PatientHist.aspx?id="+e.CommandArgument , true);											
			}
    }

    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        _strSort = e.SortExpression;
        if (e.SortDirection == SortDirection.Descending)
        {
            _strSort += " " + "DESC";
        }
    }
	}
}
