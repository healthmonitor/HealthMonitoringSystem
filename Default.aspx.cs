using System;
using System.Data;
using Npgsql;

namespace HealthMonitorSystem
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            IDataReader reader = null;
            IDbConnection dbcon = null;
            IDbCommand dbcmd = null;
              try
              {

		          	string connectionString = "Server=db.cecs.pdx.edu;" + "Port=5432;" + "Database=jammulan;" + "User ID=jammulan;" + "Password=kr!m22Uc;";
		            dbcon = new Npgsql.NpgsqlConnection(connectionString);
		            dbcon.Open();
		            dbcmd = dbcon.CreateCommand();
		            string userName = txtuser.Text;
		            string password = txtpassword.Text;
		            string sql = string.Format("select * from login where username = '{0}' and password ='{1}'",userName,password);
		            dbcmd.CommandText = sql;
		            reader = dbcmd.ExecuteReader();
						           
			        if(reader.Read())
		            {
		            	Response.Redirect("PatientEntry.aspx");
		            }
			        else
			        {
			             Response.Write("Invalid Username or Password");
					}	
				// Adding a comment to see if this reflected. Testing differences
				// Navya has added one more line
				//Rohini test 4
                }
			

               catch(Exception ex)

               {
                	Console.WriteLine("Exception " + ex);
               }

               finally

               {
			   		if (reader != null)
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
			
					}	

               }

            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void lnkregister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void lnkforgotpwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPwd.aspx");
        }
    }
}
