
using System;
using System.Web;
using System.Web.UI;
using System.Data;

namespace HealthMonitorSystem
{
	
	
	public partial class PatientHist : BasePage
	{	

		protected override void OnLoad (System.EventArgs e)
		{
			base.OnLoad (e);
			if(this.UserId > 0)
			{	
				int pid = 0;
				if(this.IsDoctor && Request.QueryString["id"] != null) 
				{
					pid = Convert.ToInt32(Request.QueryString["id"]);					
				}
				else
				{
					pid = this.UserId;
				}		
				string strSql = " SELECT *, bphigh || '/' || bplow as bp " + 
								" FROM public.Patient where pid = "+pid +
								" order by entrydate desc";
				DataSet ds = BaseDA.ExecuteDataSet(strSql);			
				gvHist.DataSource = ds;
				gvHist.DataBind();
				if(ds != null )
				{
					if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
					{
						gvHist.DataSource = ds.Tables[0];
						gvHist.DataBind();
					}
					else
					{
						gvHist.Visible = false;						
						this.ErrorMessage += "No Resluts Found";
					}
				}
				else
				{
					this.ErrorMessage += "DataSet is null";
				}
			}
			else
			{
				this.ErrorMessage += "Please login to the System for further Access <br />";
				Response.Redirect("Default.aspx");
			}
		}

		protected void lnkBack_Click (object sender, System.EventArgs e)
		{
			if(this.IsDoctor)
			{
				Response.Redirect("~/DoctorsPage.aspx", true);
			}
			else
			{
				Response.Redirect("~/PatientEntry.aspx", true);
			}
		}

	}
}
