//-----------------------------------------------------------------------
// Copyright (c) 2009 Navya Jammula.

// This file is part of HealthMonitoringSystem.
// HealthMonitoringSystem is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// HealthMonitoringSystem is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with HealthMonitoringSystem.  If not, see
// <http://www.gnu.org/licenses/>.
//-----------------------------------------------------------------------
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
		
		private int SelectedPId
		{
			get 
			{
				if(ViewState["SelectedPId"] != null)
				{
					return 	Convert.ToInt32(ViewState["SelectedPId"]);
				}
				return 0;
			}
			set 
			{
				ViewState["SelectedPId"] = value;
			}
		}

    protected void Page_Load(object sender, EventArgs e)
    {
        if(this.UserId<=0)
		{
			this.ErrorMessage = "Please login to the System";
			Response.Redirect("Default.aspx", true);
		}
			if(!IsPostBack)
			{
				phRemarks.Visible = false;
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
			if(dt.Rows.Count > 0)
			{
        		gv.DataSource = dt;
        		gv.DataBind(); 					
			}
			else
			{
				this.ErrorMessage = "Sorry you donot have any patients Assigned. <br />" +
							"You can go on a vacation.";
						
			}
		}
		}catch(Exception ex)
		{
			this.ErrorMessage = ex.Message;
		}
    }

    private DataTable RefreshData()
    {
        string strSql = " select dr.*, l.*, l.lastname ||  ' ' || l.firstname as name" +
						" from doctorpatient dr " +
						" inner join login l on dr.patientid=l.id " +
						" where dr.doctorid = " + this.UserId;
        DataSet ds = BaseDA.ExecuteDataSet(strSql);
		if(ds!= null && ds.Tables.Count > 0)
		{
        	return ds.Tables[0];
		}
		return null;
    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
			if(e.CommandName == "View")
			{
				Response.Redirect("PatientHist.aspx?id="+e.CommandArgument , true);											
			}
			else if(e.CommandName == "Remarks")
			{
				this.SelectedPId = Convert.ToInt32(e.CommandArgument);
				this.ShowRemarks();
			}
    }
		
	private void ShowRemarks()
	{
		phRemarks.Visible = true;
		txtRemarks.Text = string.Empty;
	}

    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        _strSort = e.SortExpression;
        if (e.SortDirection == SortDirection.Descending)
        {
            _strSort += " " + "DESC";
        }
    }

    protected void btnCancel_Click (object sender, System.EventArgs e)
    {
		phRemarks.Visible = false;	
    }

    protected void btnRemarks_Click (object sender, System.EventArgs e)
    {	
		try
		{
			if(string.IsNullOrEmpty(txtRemarks.Text.Trim()))
			{
				this.ErrorMessage += "Remarks is Required <br />";
			}
			else
			{
				//Save Remarks
				string strSql = string.Format("Update doctorpatient set doctorremarks='{0}' where " +
								"doctorid = {1} and patientid = {2} ", 
				                 BaseDA.Escape(txtRemarks.Text.Trim()),
				                 this.UserId, this.SelectedPId);
				BaseDA.ExecuteNonQuery(strSql);
				phRemarks.Visible = false;
				this.SelectedPId = 0;
			}
		}
		catch(Exception ex)
		{
			this.ErrorMessage = ex.Message;
		}
    }
}
}
