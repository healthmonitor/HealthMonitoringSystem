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

namespace HealthMonitorSystem
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
		
		protected void btnRegister_Click(object sender, EventArgs e)
		{
			
            IDbConnection dbcon = null;
            IDbCommand dbcmd = null;
              try
              {

		          	string connectionString = "Server=db.cecs.pdx.edu;" + "Port=5432;" + "Database=jammulan;" + "User ID=jammulan;" + "Password=kr!m22Uc;";
		            dbcon = new Npgsql.NpgsqlConnection(connectionString);
		            dbcon.Open();
		            dbcmd = dbcon.CreateCommand();
					
					string userName = txtUserId.Text;
					string password = txtPassword.Text;
				    string firstName = txtFirstName.Text;
				    string lastName = txtLastName.Text;
				    //string gender = 
					//DateTime bdate = new DateTime();
				    string addr = txtAddress.Text;
				//	string securityQuestion = "";
					string answer = txtAnswer.Text;
				
				
		           
		            string sql = string.Format("select * from login where username = '{0}' and password ='{1}'",userName,password);
		            dbcmd.CommandText = sql;
		            
						           
			       
                }

               catch(Exception ex)

               {
                	Console.WriteLine("Exception " + ex);
               }

               finally

               {
			   		
			       if (dbcon != null)
			       {
			           dbcon.Close();
				   }	

			       if(dbcmd != null)
			       {		
			           dbcmd.Dispose();	
				   }	
               }
		}
		
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			
		}
    }
}
