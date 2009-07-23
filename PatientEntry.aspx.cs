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

using Npgsql;

namespace HealthMonitorSystem
{
    public partial class PatientEntry : System.Web.UI.Page
    {
		
		
		
        protected void Page_Load(object sender, EventArgs e)
        {

        }

		       protected void btnpatient_Click(object sender, EventArgs e)

       {
			IDataReader reader;
			IDbConnection dbconn;
			IDbCommand dbcmd;

	    try
	
	       {
				
	
	          string connectionString = "Server=db.cecs.pdx.edu;" + "Port=5432;" + "Database=jammulan;" + "User ID=jammulan;" + "Password=kr!m22Uc;";
	
	
	
		       System.Data.IDbConnection dbcon;
		
		
		
		       dbcon = new Npgsql.NpgsqlConnection(connectionString);
		
			
		       dbcon.Open();
				
		       dbcmd = dbcon.CreateCommand();
				
		
		       int pid = int.Parse(txtpid.Text);
		       int temp = int.Parse(txttemp.Text);
			   
				
			   int bphigh = int.Parse(txtbphigh.Text);
		       int bplow = int.Parse(txtbplow.Text);
			   int pulserate = int.Parse(txtpulserate.Text);
			   int gluc = int.Parse(txtglucose.Text);
			 
				
		       int painlevel = int.Parse(listpainlevel.SelectedItem.Value);
		
			   string description = txtdescription.Text;
				
		       			
		       //string sql = string.Format("insert into patient(pid,temperature,bphigh,bplow,glucose,painlevel,description) values ({0},{1},{2},{3},{4},{5},{6})",pid,temp,bphigh,bplow,gluc,painlevel,description);
				
				string sql = string.Format("insert into patient(pid,temperature,bphigh,bplow,pulserate) values ({0},{1},{2},{3},{4})",pid,temp,bphigh,bplow,pulserate);
				
		       dbcmd.CommandText = sql;
			    dbcmd.ExecuteNonQuery();
				dbcon.Close();
				
		
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





       protected void btnCancel_Click(object sender, EventArgs e)

       {



       }


		       protected void btnClear_Click(object sender, EventArgs e)

       {



       }

		
    }
}
