//-----------------------------------------------------------------------
// Copyright (c) 2009 Navya Jammula.

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

namespace HealthMonitorSystem
{
    public partial class ChangePassword : BasePage
    {
		string username = string.Empty;
		string StrErros = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
			if(Request.QueryString["username"] != null)
			{				
				username = Request.QueryString["username"].ToString();
			}
			else
			{
				ErrorMessage += "You donot have access to this page";
				Response.Redirect("Default.aspx");
			}
        }
		
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
			
            if (!string.IsNullOrEmpty(StrErros))
            {
				lblError.Text = StrErros;
               // ClearErrorMessages();
            }
        }
		
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ErrorMessage = string.Empty;
            try
            {
				StrErros = string.Empty;
				if(string.IsNullOrEmpty(username))
				{
					ErrorMessage += "You donot have access to this page";
					Response.Redirect("Default.aspx");
				}
                if(string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    StrErros += "Password is required <br/>"; 
                }
				if(string.IsNullOrEmpty(txtRetypePassword.Text.Trim()))
                {
                    StrErros += "Retype Password is required <br/>"; 
                }
                if (!string.IsNullOrEmpty(txtPassword.Text.Trim()) && 
				    !string.IsNullOrEmpty(txtRetypePassword.Text.Trim()))
                {
                    if (txtPassword.Text.Trim() != txtRetypePassword.Text.Trim())
                    {
                        StrErros += "Password and Retyped Password must be the same <br/>";
                    }
                }

                if (string.IsNullOrEmpty(StrErros))
                {
                    //update new password 
					string strSql = string.Format("Update login set password='{0}' where " +
								"username = '{1}'", 
				                 BaseDA.Escape(txtPassword.Text.Trim()),
				                 username);					
					BaseDA.ExecuteNonQuery(strSql);	
					Response.Redirect("PasswordChanged.aspx");
                }				
            }
            catch(Exception ex)
            {
                StrErros = "Exception " + ex;   				
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
			Response.Redirect("Default.aspx", true);
        }
    }
}
