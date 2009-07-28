using System;
using System.Data;
using Npgsql;

namespace HealthMonitorSystem
{
    public partial class _Default : BasePage
    {
		
		protected override void OnPreRender (System.EventArgs e)
		{
			base.OnPreRender (e);
			if(!string.IsNullOrEmpty(this.ErrorMessage))
			{
				//lblError.Text = this.ErrorMessage;
				//this.ClearErrorMessages();
			}
		}

		
        protected void btnlogin_Click(object sender, EventArgs e)
        {
			try
            {				
				// Checking for Required Fields
				if(string.IsNullOrEmpty(txtuser.Text.Trim()))
				{
					this.ErrorMessage += "User Name is Required <br />";					
				}
				if(string.IsNullOrEmpty(txtpassword.Text.Trim()))
				{
					this.ErrorMessage += "Password is Required<br />";					
				}
				
				//Checking for Errors
				if(string.IsNullOrEmpty(this.ErrorMessage))
				{
					DataSet ds = BaseDA.ExecuteDataSet(string.Format("select * from login where username = '{0}' and password ='{1}'",
			                                       BaseDA.Escape(txtuser.Text), BaseDA.Escape(txtpassword.Text)));				
					if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
					{
						DataRow dr = ds.Tables[0].Rows[0];						
						if(dr != null)
						{
							if(dr["Id"] != null)
							{
								this.UserId	= Convert.ToInt32(dr["Id"]);
								this.UserName = dr["lastname"].ToString()  + " " + dr["firstname"].ToString();
								this.IsAdmin = Convert.ToBoolean(dr["isadmin"]);
								this.IsDoctor = Convert.ToBoolean(dr["isdoctor"]);
							}
						}
					}
					if(this.UserId > 0)
					{
						if(IsDoctor)
						{
							Response.Redirect("DoctorsPage.aspx", false);
						}
						else if(IsAdmin)
						{
							
						}
						else
						{
							Response.Redirect("PatientEntry.aspx", false);
						}
					}
					else
					{
						this.ErrorMessage += "Invalid Username or Password";
					}
				}
			}
			catch(Exception ex)
            {
               	this.ErrorMessage = "Exception " + ex;
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
