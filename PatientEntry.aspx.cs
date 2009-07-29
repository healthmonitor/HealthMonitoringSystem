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
	public partial class PatientEntry : BasePage
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
			
		btnHelp.Attributes.Add("onclick", "window.open('PatientEntryhelp.aspx',null,'left=400, top=100, height=250, width= 400, status=no, resizable= no, scrollbars= yes, toolbar= no,location= no, menubar= no');"); 
        }

		
		
    
		protected override void OnLoad (System.EventArgs e)
		{
			base.OnLoad (e);
			if(this.UserId > 0)
			{									
				DataSet ds = BaseDA.ExecuteDataSet("SELECT id,firstname,lastname FROM public.Login where isadmin = false and isdoctor = false");			
				
				//gvHist.DataSource = ds;
				//gvHist.DataBind();
				
				if(ds != null )
				{
					if(ds.Tables.Count > 0)
					{
						//gvHist.DataSource = ds.Tables[0];
						//gvHist.DataBind();
						listpid.DataSource = ds;
						listpid.DataTextField = "id";
						listpid.DataValueField = "id";
						listpid.DataBind();
						
						/*listpid.DataTextField = "firstname" + "lastname";
						listpid.DataValueField = "firstname" + "lastname";
						listpid.DataBind();*/
							
						                        
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
			IDataReader reader;
			IDbConnection dbconn;
			IDbCommand dbcmd;

	    try
	
	       {
				
	
	          /*string connectionString = "Server=db.cecs.pdx.edu;" + "Port=5432;" + "Database=jammulan;" + "User ID=jammulan;" + "Password=kr!m22Uc;";
	
	
	
		       System.Data.IDbConnection dbcon;
		
		
		
		       dbcon = new Npgsql.NpgsqlConnection(connectionString);
		
			
		       dbcon.Open();
				
		       dbcmd = dbcon.CreateCommand();*/
				
		
		       int pid = int.Parse(listpid.Text);
		       int temp = int.Parse(txttemp.Text);
			   
				
			   int bphigh = int.Parse(txtbphigh.Text);
		       int bplow = int.Parse(txtbplow.Text);
			   int pulserate = int.Parse(txtpulserate.Text);
			   int gluc = int.Parse(txtglucose.Text);
			 
				
		       int painlevel = int.Parse(listpainlevel.SelectedItem.Value);
		
			   string description = txtdescription.Text;
				
		       			
		       //string sql = string.Format("insert into patient(pid,temperature,bphigh,bplow,glucose,painlevel,description) values ({0},{1},{2},{3},{4},{5},{6})",pid,temp,bphigh,bplow,gluc,painlevel,description);
				
				/*string sql = string.Format("insert into patient(pid,temperature,bphigh,bplow,pulserate) values ({0},{1},{2},{3},{4})",pid,temp,bphigh,bplow,pulserate);
				
		       dbcmd.CommandText = sql;
			    dbcmd.ExecuteNonQuery();
				dbcon.Close();*/
				
				//DataSet ds = BaseDA.ExecuteDataSet("insert into patient(pid,temperature,bphigh,bplow,pulserate)" + "values ({0},{1},{2},{3},{4})," + pid +"," + temp + "," + bphigh + "," + bplow + "," + pulserate + ");";			
				
				string sql = "," + pid + "," + temp + "," + bphigh + "," + bplow + "," + pulserate;
				DataSet dsinsert = BaseDA.ExecuteDataSet("insert into patient(pid,temperature,bphigh,bplow,pulserate) values ({0},{1},{2},{3},{4})" + sql);
		
		       //System.Data.IDataReader reader = dbcmd.ExecuteReader();
		
				
		
		/*       if(reader.Read())
		
		       {
		
		               Response.Redirect("PatientEntry.aspx");
		
		
		
		       }
		
		               else
		
		               {
		
		                       Response.Write("Invalid Username or Password");
		
		               }*/
		
	
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





       		
		protected void btnHelp_Click(object sender, EventArgs e)

       {
  /* StringBuilder sb = new StringBuilder();
        sb.Append("<script>");
        sb.Append("window.open('http://msdn.microsoft.com', '', '');");
        sb.Append("</scri");
        sb.Append("pt>");

        Page.RegisterStartupScript("test", sb.ToString());*/
			

       }

		       protected void btnCancel_Click(object sender, EventArgs e)

       {
			
			Response.Redirect("PatientEntry.aspx");
			

       }

		
    }
	
	
}


