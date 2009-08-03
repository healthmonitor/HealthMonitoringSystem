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
    //public partial class PatientEntry : System.Web.UI.Page
	public partial class ClerksPage : BasePage
	{
		
		/*protected override void OnPreRender (System.EventArgs e)
		{
			base.OnPreRender (e);
			lblName.Text = "Welcome <br />" + this.UserName;
			if(!string.IsNullOrEmpty(this.ErrorMessage))
			{
				lblError.Text = this.ErrorMessage;
				this.ClearErrorMessages();
			}
		}*/
		
		protected void Page_Load(object sender, EventArgs e)
        {
			//btnClear.Attributes.Add("onClick","Empty();");
			
		//	btnHelp.Attributes.Add("onclick","window.open("temphelp.aspx","help","width=800,height=500,top=100,left=100,scrollbars=yes");
			
		//btnHelp.Attributes.Add("onclick", "window.open('PatientEntryhelp.aspx',null,'left=400, top=100, height=250, width= 400, status=no, resizable= no, scrollbars= yes, toolbar= no,location= no, menubar= no');"); 
        }

		
		
    
		protected override void OnLoad (System.EventArgs e)
		{
			
							
						                        
				
		}

		
		
        
		       protected void btnpatient_Click(object sender, EventArgs e)

       {
			IDataReader reader;
			IDbConnection dbconn;
			IDbCommand dbcmd;

	    try
	
	       {
				
		
	
	       }
	
	       catch(Exception ex)
	
	       {
	
	               Console.WriteLine("Exception " + ex);
	
	       }
	
	       finally
	
	       {
	
	               /*if (reader != null)
	
	               {
	
	                   reader.Close();
	
	               }
	
	               if (dbcon != null)
	
	               {
	
	                   dbcon.Close();
	
	               }
	
	               if(dbcmd != null)
	
	               {
	
	                   dbcmd.Dispose();
	
	               }*/
	
			}
                       
      }


       		
		protected void btnPatientEntry_Click(object sender, EventArgs e)

       {
			Response.Redirect("PatientEntry.aspx");

       }

		protected void btnPatientHistory_Click(object sender, EventArgs e)

       {
			Response.Redirect("PatientHist.aspx");

       }

		/*protected void btnDocPatHistory_Click(object sender, EventArgs e)

       {
			Response.Redirect("PatientHist.aspx");

       }*/

		protected void btnDocPatEntry_Click(object sender, EventArgs e)

       {
			Response.Redirect("DoctorPatient.aspx");

       }

		
    }
	
	
}


