//-----------------------------------------------------------------------
// Copyright (c) 2009 Anuja Kharade,Navya Jammula.

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
				
						String sql = "SELECT id,firstname,lastname,firstname||' '||lastname as fullname FROM public.Login where id = " + pid;
						DataSet dsname = BaseDA.ExecuteDataSet(sql);			
						if(dsname != null )
						{
							if(dsname.Tables.Count > 0)
							{
								DataTable dt = dsname.Tables[0];
								foreach (DataRow dr in dt.Rows)
								{
								 lblfullname.Text = dr["fullname"].ToString();
								}	
							}
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
			this.ClearErrorMessages();
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
