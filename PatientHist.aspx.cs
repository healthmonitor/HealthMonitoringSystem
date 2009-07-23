
using System;
using System.Web;
using System.Web.UI;
using System.Data;

namespace HealthMonitorSystem
{
	
	
	public partial class PatientHist : BasePage
	{
		
		protected override void OnPreRender (System.EventArgs e)
		{
			base.OnPreRender (e);
			lblName.Text = "Welcome <br />" + this.UserName;
			if(!string.IsNullOrEmpty(this.ErrorMessage))
			{
				lblError.Text = this.ErrorMessage;
				this.ClearErrorMessages();
			}
		}

		protected override void OnLoad (System.EventArgs e)
		{
			base.OnLoad (e);
			if(this.UserId > 0)
			{									
				DataSet ds = BaseDA.ExecuteDataSet("SELECT * FROM public.Patient");			
				gvHist.DataSource = ds;
				gvHist.DataBind();
				if(ds != null )
				{
					if(ds.Tables.Count > 0)
					{
						gvHist.DataSource = ds.Tables[0];
						gvHist.DataBind();
					}
					else
					{	
						this.ErrorMessage += "No Tables Returned <br />";
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

	}
}
