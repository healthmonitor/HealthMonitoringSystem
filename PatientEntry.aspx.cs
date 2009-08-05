// Copyright (c) 2009 Anuja Kharade.

//This file is part of HealthMonitoringSystem.
//HealthMonitoringSystem is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//HealthMonitoringSystem is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with HealthMonitoringSystem.  If not, see
//<http://www.gnu.org/licenses/>.

using System;

using System.Data;

using System.Configuration;

using System.Collections;

using System.Web;

using System.Web.Security;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Web.UI.WebControls.WebParts;

using System.Web.UI.HtmlControls;

using System.Data.OleDb;

using NauckIT.PostgreSQLProvider;

using System.Text;

using Npgsql;

namespace HealthMonitorSystem
{

	public partial class PatientEntry : BasePage
	{
		
		protected void Page_Load(object sender, EventArgs e)
        {
			
		}

		protected override void OnLoad (System.EventArgs e)
		{
		}
		
		protected override void OnPreRender (System.EventArgs e)
		{
			base.OnPreRender (e);
			
			btnHelp.Attributes.Add("onclick", "window.open('PatientEntryhelp.aspx',null,'left=400, top=100, height=250, width= 400, status=no, resizable= no, scrollbars= yes, toolbar= no,location= no, menubar= no');"); 
			
			//Clerks logs in
			
			if (IsAdmin == true)
			{
					
					lblpatient.Text = "Patient";
					lblstar.Text = "*";
					lblpatient.Visible = true;
					lblstar.Visible = true;
					btnHist.Visible = false;
					listpid.Visible = true;
				
					if(this.UserId > 0)
					{		
					//Fetch all the Patients' list
						String sql = "SELECT id,firstname,lastname,firstname||' '||lastname as fullname FROM public.Login where isadmin = false and isdoctor = false";
						DataSet ds = BaseDA.ExecuteDataSet(sql);			
						if(ds != null )
						{
							if(ds.Tables.Count > 0)
							{
								listpid.DataSource = ds;
								listpid.DataTextField = "fullname";
								listpid.DataValueField = "fullname";
								listpid.DataBind();
								//DataTable dt = ds.Tables[0];
							}
							else
							{	
								this.ErrorMessage += "No Patient Entry Maintained <br />";
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
				
				String sqlid = "SELECT id FROM public.Login where isadmin = false and isdoctor = false and firstname||' '||lastname = '" + listpid.SelectedItem.Value + "'";
				DataSet dspatid = BaseDA.ExecuteDataSet(sqlid);			
				
				if(dspatid != null )
				{
					if(dspatid.Tables.Count > 0)
					{
						DataTable dt = dspatid.Tables[0];
						foreach (DataRow dr in dt.Rows)
						{
						 lblpatid.Text = dr["id"].ToString();
						}	
					}
				}

			}
			//Patient logs in
			if ((IsAdmin == false) && (IsDoctor == false))
			{
				lblpatid.Text = this.UserId.ToString();
				listpid.Visible = false;
				lblpatient.Visible = false;
				lblstar.Visible = false;
				btnHist.Visible = true;
			}
	}

        
		       protected void btnpatient_Click(object sender, EventArgs e)
       {

	    try
	
	       {
				this.ErrorMessage = "";

				//clerk
				if (IsAdmin	== true)			
				{
				
					//populate list box with patient names
					String sql1 = "SELECT id FROM public.Login where isadmin = false and isdoctor = false and firstname||' '||lastname = '" + listpid.SelectedValue + "'";
					DataSet ds = BaseDA.ExecuteDataSet(sql1);			
					
					if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
							{
								DataRow dr = ds.Tables[0].Rows[0];						
								if(dr != null)
								{
									if(dr["Id"] != null)
									{
										lblpatid.Text = dr["id"].ToString();
									}
								}
							}
				}
				
				//patient
				//store the patient id to be inserted later for new records
				if (IsAdmin	== false)			
				{
						lblpatid.Text = this.UserId.ToString();
				}
				
				//Field Validations
				
				if(string.IsNullOrEmpty(listpid.Text.Trim()))
				{
					this.ErrorMessage += "No Patient Selected <br />";					
				}
				
				if((string.IsNullOrEmpty(txttemp.Text.Trim())))
				{
					this.ErrorMessage += "Temperature Is Required. <br />";					
				}
				else
				{
					 if (!CheckIfNumbericTemp ( txttemp.Text ))
					 {
					    this.ErrorMessage += "Temperature should be a Numeric Value<br />";	
					 }
					else
					{
						if ((Convert.ToDouble(txttemp.Text) <= 80.00) || (Convert.ToDouble(txttemp.Text) >= 120.00))
						{
							this.ErrorMessage += "Temperature should be a positive number between 80 and 120, decimal numbers are accepted. <br />";					
						}
					}		
				}
				if (string.IsNullOrEmpty(txtbphigh.Text.Trim()))
				{
					this.ErrorMessage += "Blood Pressure - HIGH Is Required. <br />";					
				}
				else
				{
					 if (!CheckIfNumberic ( txtbphigh.Text ))
					 {
					    this.ErrorMessage += "Blood Pressure - HIGH should be Numeric Value<br />";	
					 }
					else
					{
						if ((txtbphigh.Text.Length) > 5)
						{
							this.ErrorMessage += "Invalid Blood Pressure - HIGH value.Digits Cannot be Greater than 5 <br />";
						}
						else
						{
							if (((Convert.ToInt32(txtbphigh.Text) <= 0)))
							{
								this.ErrorMessage += "Blood Pressure - HIGH value must be positive number, decimal numbers are not accepted. <br />";					
							}
						}
					}
				}
				if (string.IsNullOrEmpty(txtbplow.Text.Trim()))
				{
					this.ErrorMessage += "Blood Pressure - LOW Is Required. <br />";					
				}
				else
				{
					 if (!CheckIfNumberic ( txtbplow.Text ))
					 {
					    this.ErrorMessage += "Blood Pressure - LOW should be Numeric Value<br />";	
					 }
					else
					{
						if ((txtbplow.Text.Length) > 5)
						{
							this.ErrorMessage += "Invalid Blood Pressure - LOW value.Digits Cannot be Greater than 5 <br />";
						}
						else
						{
							if (((Convert.ToInt32(txtbplow.Text) <= 0))) 
							{
								this.ErrorMessage += "Blood Pressure - LOW value must be positive number, decimal numbers are not accepted. <br />";					
							}
						}
					}
				}
				if (string.IsNullOrEmpty(txtpulserate.Text.Trim()))
				{
					this.ErrorMessage += "Pulse Rate Is Required. <br />";					
				}
				else
				{
					 if (!CheckIfNumberic ( txtpulserate.Text ))
					 {
					    this.ErrorMessage += "Pulse Rate should be a Numeric Value<br />";	
					 }
					else
					{

						if ( ((Convert.ToInt32(txtpulserate.Text) <= 20)) || ((Convert.ToInt32(txtpulserate.Text) >= 200)))
						{
							this.ErrorMessage += "Pulse Rate must be a positive number between 20 and 200, decimal numbers are not accepted. <br />";					
						}
					}
				}
				if (string.IsNullOrEmpty(txtglucose.Text.Trim()))
				{
				}
				else
				{
					 if (!CheckIfNumberic ( txtglucose.Text ))
					 {
					    this.ErrorMessage += "Glucose should be a Numeric Value <br />";	
					 }
					else
					{

						if ((Convert.ToInt32(txtglucose.Text) <= 20) || (Convert.ToInt32(txtglucose.Text) >= 300))
						{
							this.ErrorMessage += "Glucose level must be a positive number between 20 and 300. Decimal numbers are not accepted. <br />";					
						}
					}
				}

				String sql;
				int dbinsert=0;
				
				
			//Insert Records	
   			if (string.IsNullOrEmpty(ErrorMessage)) 
            {
				//glucose is blank, pain and desc are not blank
				if ((string.IsNullOrEmpty(txtglucose.Text.Trim())) && (listpainlevel.SelectedValue != "Select") && (!string.IsNullOrEmpty(txtdescription.Text.Trim())))
					{
						sql = string.Format("INSERT into public.patient (pid,temperature,bphigh,bplow,glucose,painlevel,description,entrydate,pulserate) VALUES (" + lblpatid.Text + "," + txttemp.Text + "," + txtbphigh.Text + "," + txtbplow.Text + "," + "NULL" + "," + listpainlevel.Text + ",'" + txtdescription.Text +  "',CURRENT_DATE," + txtpulserate.Text + ")");
						dbinsert = BaseDA.ExecuteNonQuery(sql);
					}
				
				//pain and glucose is blank,desc is not blank
				if ((string.IsNullOrEmpty(txtglucose.Text.Trim())) && (listpainlevel.SelectedValue.Trim().Contains("Select")) && (!string.IsNullOrEmpty(txtdescription.Text.Trim())))
						
					{
						sql = string.Format("INSERT into public.patient (pid,temperature,bphigh,bplow,glucose,painlevel,description,entrydate,pulserate) VALUES (" + lblpatid.Text + "," + txttemp.Text + "," + txtbphigh.Text + "," + txtbplow.Text + "," + "NULL" + "," + "NULL" + ",'" + txtdescription.Text +  "',CURRENT_DATE," + txtpulserate.Text + ")");
						dbinsert = BaseDA.ExecuteNonQuery(sql);
					}
				

				//desc and glucose is blank,pain is not blank
				if ((string.IsNullOrEmpty(txtglucose.Text.Trim())) && (listpainlevel.SelectedValue != "Select") && (string.IsNullOrEmpty(txtdescription.Text.Trim())))
					{
						sql = string.Format("INSERT into public.patient (pid,temperature,bphigh,bplow,glucose,painlevel,description,entrydate,pulserate) VALUES (" + lblpatid.Text + "," + txttemp.Text + "," + txtbphigh.Text + "," + txtbplow.Text + "," + "NULL" + "," + listpainlevel.Text + "," + "NULL" +  ",CURRENT_DATE," + txtpulserate.Text + ")");
						dbinsert = BaseDA.ExecuteNonQuery(sql);
					}

				//pain and desc is blank, glucose is not blank
				if ((!string.IsNullOrEmpty(txtglucose.Text.Trim())) && (listpainlevel.SelectedValue.Trim().Contains("Select")) && (string.IsNullOrEmpty(txtdescription.Text.Trim())))
					{
						sql = string.Format("INSERT into public.patient (pid,temperature,bphigh,bplow,glucose,painlevel,description,entrydate,pulserate) VALUES (" + lblpatid.Text + "," + txttemp.Text + "," + txtbphigh.Text + "," + txtbplow.Text + "," + txtglucose.Text + "," + "NULL" + "," + "NULL" +  ",CURRENT_DATE," + txtpulserate.Text + ")");
						dbinsert = BaseDA.ExecuteNonQuery(sql);
					}

				//pain is blank, glucose and desc are not blank
				if ((listpainlevel.SelectedValue.Trim().Contains("Select")) && (!string.IsNullOrEmpty(txtglucose.Text.Trim())) && (!string.IsNullOrEmpty(txtdescription.Text.Trim())))
					{
						sql = string.Format("INSERT into public.patient (pid,temperature,bphigh,bplow,glucose,painlevel,description,entrydate,pulserate) VALUES (" + lblpatid.Text + "," + txttemp.Text + "," + txtbphigh.Text + "," + txtbplow.Text + "," + txtglucose.Text + "," + "NULL" + ",'" + txtdescription.Text +  "',CURRENT_DATE," + txtpulserate.Text + ")");
						dbinsert = BaseDA.ExecuteNonQuery(sql);
					}

				//desc is blank, glucose and pain is not blank	
				if ((string.IsNullOrEmpty(txtdescription.Text.Trim())) && (!string.IsNullOrEmpty(txtglucose.Text.Trim())) && (listpainlevel.SelectedValue != "Select"))
					{
						sql = string.Format("INSERT into public.patient (pid,temperature,bphigh,bplow,glucose,painlevel,description,entrydate,pulserate) VALUES (" + lblpatid.Text + "," + txttemp.Text + "," + txtbphigh.Text + "," + txtbplow.Text + "," + txtglucose.Text + "," + listpainlevel.Text + "," + "NULL" +  ",CURRENT_DATE," + txtpulserate.Text + ")");
						dbinsert = BaseDA.ExecuteNonQuery(sql);
					}
				
				//all blank	
				if ((string.IsNullOrEmpty(txtdescription.Text.Trim())) && (string.IsNullOrEmpty(txtglucose.Text.Trim())) && (listpainlevel.SelectedValue.Trim().Contains("Select")))
					{
						sql = string.Format("INSERT into public.patient (pid,temperature,bphigh,bplow,glucose,painlevel,description,entrydate,pulserate) VALUES (" + lblpatid.Text + "," + txttemp.Text + "," + txtbphigh.Text + "," + txtbplow.Text + "," + "NULL" + "," + "NULL"  + "," + "NULL" +  ",CURRENT_DATE," + txtpulserate.Text + ")");
						dbinsert = BaseDA.ExecuteNonQuery(sql);
					}
				
					//all filled
				if (!string.IsNullOrEmpty(txtdescription.Text.Trim()) && (!string.IsNullOrEmpty(txtglucose.Text.Trim())) && (listpainlevel.SelectedValue != "Select"))
					{
						sql = string.Format("INSERT into public.patient (pid,temperature,bphigh,bplow,glucose,painlevel,description,entrydate,pulserate) VALUES (" + lblpatid.Text + "," + txttemp.Text + "," + txtbphigh.Text + "," + txtbplow.Text + "," + txtglucose.Text + "," + listpainlevel.Text + ",'" + txtdescription.Text +  "',CURRENT_DATE," + txtpulserate.Text + ")");
						dbinsert = BaseDA.ExecuteNonQuery(sql);
				}
			}					 

	      }
		
	
	       catch(Exception ex)
	
	       {
	
               	this.ErrorMessage = "Exception " + ex;
	
	       }

		
      }


			
		protected void Pname_SelectedIndexChanged(object sender, EventArgs e)
		{
		}


		protected void lnkBack_Click (object sender, System.EventArgs e)
		{
			if(this.IsAdmin)
			{
				Response.Redirect("~/ClerksPage.aspx", true);
			}
			else
			{
				Response.Redirect("~/Default.aspx", true);
			}
		}

       		
		protected void btnHelp_Click(object sender, EventArgs e)
       {
			
       }

	      protected void btnCancel_Click(object sender, EventArgs e)
       {
			
			Response.Redirect("PatientEntry.aspx");

       }

		protected void btnHist_Click(object sender, EventArgs e)
       {
			
			Response.Redirect("PatientHist.aspx?pid= " + this.UserId);
		
       }

		
	 bool CheckIfNumbericTemp( string myNumber )
	{
		bool IsNum = true;
		for( int index = 0; index < myNumber.Length; index++ )
	   	{
					
			if (myNumber[ index ].ToString().Contains("."))
			{
			}
			else
			{
			    if( !Char.IsNumber( myNumber[ index ] ))
			    {
				    IsNum = false;
				    break;
			    }
			}	
		}
	return IsNum;
	}
	
	 bool CheckIfNumberic( string myNumber )
	{
		bool IsNum = true;
		for( int index = 0; index < myNumber.Length; index++ )
	   	{
					
		   if( !Char.IsNumber( myNumber[ index ] ))
		   {
			    IsNum = false;
			    break;
		    }
	   }
	return IsNum;
	}

}

	
}


