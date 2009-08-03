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
		String patid;
		int pain;
		
		
		protected void Page_Load(object sender, EventArgs e)
        {
			
			btnHelp.Attributes.Add("onclick", "window.open('PatientEntryhelp.aspx',null,'left=400, top=100, height=250, width= 400, status=no, resizable= no, scrollbars= yes, toolbar= no,location= no, menubar= no');"); 
			
			
			
			if (string.IsNullOrEmpty(Request.QueryString["userid"]))
			{
				String sql1 = "SELECT id FROM public.Login where isadmin = false and isdoctor = false and firstname||' '||lastname = '" + listpid.SelectedItem.Value + "'";
				DataSet ds = BaseDA.ExecuteDataSet(sql1);			
				
				if(ds != null )
				{
					if(ds.Tables.Count > 0)
					{
						DataTable dt = ds.Tables[0];
						foreach (DataRow dr in dt.Rows)
						{
						 lblpatid.Text = dr["id"].ToString();
						}	
					}
				}
				
			}
        }

		protected override void OnLoad (System.EventArgs e)
		{
			string fname,lname;

			
			
		base.OnLoad (e);
			if(this.UserId > 0)
			{			
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
						DataTable dt = ds.Tables[0];
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
	}

		
		
        
		       protected void btnpatient_Click(object sender, EventArgs e)

       {

	    try
	
	       {
		
	
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

				
   			if (string.IsNullOrEmpty(ErrorMessage))
            {
		       string sql = string.Format("INSERT into public.patient (pid,temperature,bphigh,bplow,glucose,painlevel,description,entrydate,pulserate) VALUES (" + lblpatid.Text + "," + txttemp.Text + "," + txtbphigh.Text + "," + txtbplow.Text + "," + txtglucose.Text + "," + listpainlevel.Text + ",'" + txtdescription.Text +  "',CURRENT_DATE," + txtpulserate.Text + ")");
			   int dbinsert = BaseDA.ExecuteNonQuery(sql);
				if (dbinsert != -1)
						this.ErrorMessage = "Records Inserted Successfully";
			}					 
				

		    
	       }
	
	       catch(Exception ex)
	
	       {
	
               	this.ErrorMessage = "Exception " + ex;
	
	       }
	                       
      }


			
		protected void Pname_SelectedIndexChanged(object sender, EventArgs e)
		{
			String sql1 = "SELECT id FROM public.Login where isadmin = false and isdoctor = false and firstname||' '||lastname = '" + listpid.SelectedItem.Value + "'";
				DataSet ds = BaseDA.ExecuteDataSet(sql1);			
				
				if(ds != null )
				{
					if(ds.Tables.Count > 0)
					{
						DataTable dt = ds.Tables[0];
						foreach (DataRow dr in dt.Rows)
						{
						 lblpatid.Text = dr["id"].ToString();
						}	
					}
				}

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

string RelativeURL(string relativeURL)

{

Image imgTemp = new Image();

imgTemp.ImageUrl = relativeURL;

return imgTemp.ResolveClientUrl(imgTemp.ImageUrl);

}
	

    }

	
}


