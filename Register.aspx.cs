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
					Response.Write(userName);
				
					string password = txtPassword.Text;
					Response.Write(password);
				
				    string firstName = txtFirstName.Text;
					Response.Write(firstName);
				
				    string lastName = txtLastName.Text;
					Response.Write(lastName);
				
					string gender = listGender.SelectedItem.Value.ToString();	
					Response.Write(gender);
					
				//	DateTime bDate =  birthDate.SelectedDate;
				
					
				   
					string addr = txtAddress.Text;
					Response.Write(addr);
				
					string securityQuestion = listSecurityQuestion.SelectedItem.Value.ToString();
					Response.Write(securityQuestion);
					string answer = txtAnswer.Text;
					Response.Write(answer);		
		           
		            //string sql = string.Format("INSERT INTO LOGIN (username ,password,firstname,lastname,gender,addr,securityQuestion,answer) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')"
				      //                     ,userName,password,firstName,lastName,gender,addr,securityQuestion,answer);
				
					string sql = string.Format("INSERT INTO LOGIN (username ,password,firstname,lastname,gender) VALUES ('{0}','{1}','{2}','{3}','{4}')",userName,password,firstName,lastName,gender);
				
		            dbcmd.CommandText = sql;
		            dbcmd.ExecuteNonQuery();
					          
			       
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
