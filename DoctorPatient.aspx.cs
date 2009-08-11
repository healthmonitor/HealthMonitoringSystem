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
using System.Web.UI.WebControls;

namespace HealthMonitorSystem
{
	public partial class DoctorPatient : BasePage
	{	
		private DataTable DoctorInfo
		{
			get
			{
				if(ViewState["DoctorInfo"] == null) 
				{
					ViewState["DoctorInfo"] = getDoctorInfo();					
				}
				return ViewState["DoctorInfo"] as DataTable;
			}
			set
			{
				ViewState["DoctorInfo"] = null;
			}
		}

		protected override void OnLoad (System.EventArgs e)
		{
			base.OnLoad (e);
			if(this.UserId > 0)
			{	
				if(this.IsAdmin)
				{
					if(!IsPostBack)
					{
						this.RefreshData();
					}
				}
				else
				{
					this.ErrorMessage += "You donot have privileges for Doctor Patient Linking page.<br />";
					if(this.IsDoctor)
					{
						Response.Redirect("DoctorsPage.aspx", true);
					}
					else
					{
						Response.Redirect("PatientEntry.aspx", true);
					}
				}
			}
			else
			{
				this.ErrorMessage += "Please login to the System for further Access <br />";
				Response.Redirect("Default.aspx", true);
			}
			
		}
		
		private void RefreshData()
		{
			string strSql = " SELECT id, firstname || ' ' || lastname as Name " + 
								" FROM login where isdoctor = false and isadmin=false " + 
								" and isnewuser=true order by Name";
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
						this.ErrorMessage += "No Results Found";
					}
				}
				else
				{
					this.ErrorMessage += "DataSet is null";
				}
		}
		
		protected void gvHist_RowDataBound(Object sender, GridViewRowEventArgs e)
		{
			Control ctlDoctor = e.Row.FindControl("ddlDoctor");
			if(ctlDoctor != null)
			{
				DropDownList ddlDoc = (DropDownList)ctlDoctor;
				ddlDoc.DataSource = this.DoctorInfo;
				ddlDoc.DataTextField = "Name";
				ddlDoc.DataValueField = "id";				
				ddlDoc.DataBind();
				ddlDoc.Items.Insert(0, new ListItem("Select", "0"));
			}
		}

		protected void lnkBack_Click (object sender, System.EventArgs e)
		{
			Response.Redirect("~/ClerksPage.aspx", true);			
		}
				
		private DataTable getDoctorInfo()
		{
			string strSql = " SELECT id, firstname || ' ' || lastname as Name " + 
							" FROM login where isdoctor = true " + 
							" order by Name";
			DataSet ds = BaseDA.ExecuteDataSet(strSql);			
			gvHist.DataSource = ds;
			if(ds!= null && ds.Tables.Count > 0 && ds.Tables[0] != null)
			{
				return ds.Tables[0];
			}			
			return null;
		}
		
		private bool ValidateData()
		{
			this.ClearErrorMessages();
			bool blnValid = true;
			foreach(GridViewRow row in gvHist.Rows)
			{
				CheckBox chk = (CheckBox)(row.FindControl("chkSelect"));
				if(chk.Checked)
				{
					DropDownList ddlDoc = (DropDownList)(row.FindControl("ddlDoctor"));
					if(ddlDoc.SelectedValue == "0")
					{
						blnValid = false;
						this.ErrorMessage += "Please specify a Doctor for all the Selected Patients";
						break;
					}					
				}
			}
			return blnValid;
		}


		protected void btnAssociate_Click (object sender, System.EventArgs e)
		{
			try
			{
				if(this.ValidateData())
				{

						string strSql = " insert into doctorpatient(doctorid, patientid) " +
										 " values ({0}, {1}); " +
										 " update login set isnewuser=false where id={2} ";
						foreach(GridViewRow row in gvHist.Rows)
						{
							
							CheckBox chk = (CheckBox)(row.FindControl("chkSelect"));
							if(chk.Checked)
							{
								int PatId = Convert.ToInt32(row.Cells[1].Text);
								DropDownList ddlDoc = (DropDownList)(row.FindControl("ddlDoctor"));
								int intDocId = Convert.ToInt32(ddlDoc.SelectedValue);
								//check duplicate
								string userIdSql = string.Format( "select * from doctorpatient where doctorid = " + intDocId + " and patientid = " + PatId);
								DataSet ds = BaseDA.ExecuteDataSet(userIdSql);
								
								if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
								{
									DataRow dr = ds.Tables[0].Rows[0];						
									if(dr != null)
									{
										if(dr["doctorid"] != null)
										{
											ErrorMessage += "Patient " +  row.Cells[2].Text + " already associated to the selected Doctor  <br/>";
										}
									}
								}
								else
									BaseDA.ExecuteNonQuery(string.Format(strSql, intDocId, PatId, PatId));							

							}
						}
						this.RefreshData();
						}	
			}
			catch(Exception ex)
			{
				this.ErrorMessage = "Exception : " + ex.Message;
			}
		}

		protected void btnClear_Click (object sender, System.EventArgs e)
		{
			this.RefreshData();
		}

	}
}
