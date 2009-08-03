
//-----------------------------------------------------------------------
// Copyright (c) 2009 Rohini Venkataramaiah. 

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
//along with HealthMonitoringSystem.  If not, see <http://www.gnu.org/licenses/>.
//-----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Data;
using Npgsql;

namespace HealthMonitorSystem
{
    public partial class Register : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!string.IsNullOrEmpty(ErrorMessage))
            {   
               
                ClearErrorMessages();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            ErrorMessage = string.Empty;
            try
            {
                //check for required field validation 	

                if (string.IsNullOrEmpty(txtUserId.Text.Trim()))
                {
                    ErrorMessage += "User name is required <br/>";
                }
				
				//check if the user name selected already exists in the database, if it exists its an invalid entry
				if (!string.IsNullOrEmpty(txtUserId.Text.Trim()))
                {
                    string userIdSql = string.Format( "SELECT * FROM LOGIN WHERE username = '{0}'",BaseDA.Escape(txtUserId.Text.Trim()));
					DataSet ds = BaseDA.ExecuteDataSet(userIdSql);
					
					if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
					{
						DataRow dr = ds.Tables[0].Rows[0];						
						if(dr != null)
						{
							if(dr["Id"] != null)
							{
								ErrorMessage += "User name already exists. Please choose a different user name <br/>";
							}
							
						}
						
					}				
					
                }

                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    ErrorMessage += "Password is required <br/>";

                }
                if (string.IsNullOrEmpty(txtRetypePwd.Text.Trim()))
                {
                    ErrorMessage += "Retype Password is required <br/>";

                }

                // check that password = retyped password
                if (!string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtRetypePwd.Text.Trim()))
                {
                    if (txtPassword.Text.Trim() != txtRetypePwd.Text.Trim())
                    {
                        ErrorMessage += "Password and Retyped Password must be the same <br/>";
                    }
                }

                if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
                {
                    ErrorMessage += "First name is required <br/>";
                }

                if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
                {
                    ErrorMessage += "Last name is required <br/>";
                }

              /*  if (Int16.Parse(listSecQuestion.SelectedValue.Trim())== -1)
                {				
                    ErrorMessage += "Security question is required <br/>";
                }*/
				
                if (string.IsNullOrEmpty(txtAnswer.Text.Trim()))
                {
                    ErrorMessage += "Answer is required <br/>";
                }
                if (string.IsNullOrEmpty(listMonth.SelectedValue.Trim()) || string.IsNullOrEmpty(txtDay.Text.Trim()) || string.IsNullOrEmpty(txtYear.Text.Trim()))
                {
                    ErrorMessage += "Birthdate is required <br/>";
                }

                DateTime birthDate = DateTime.MinValue;

                //Build birth date from the values entered and validate it
                if (!string.IsNullOrEmpty(listMonth.SelectedValue.Trim()) && !string.IsNullOrEmpty(txtDay.Text.Trim()) && !string.IsNullOrEmpty(txtYear.Text.Trim()))
                {
                    int month = Int16.Parse(listMonth.SelectedValue);
                    int day = Int16.Parse(txtDay.Text.Trim());
                    int year = Int16.Parse(txtYear.Text.Trim());
                    
                    if (!IsValidDate(listMonth.SelectedValue, txtDay.Text.Trim(), txtYear.Text.Trim()))
                    {
                        ErrorMessage = "Enter a valid date<br/>";
                    }

                    birthDate = new DateTime(year, month, day);
                    
                   
                }
				
				
				if (!string.IsNullOrEmpty(ErrorMessage))
				{
					lblErrors.Text = ErrorMessage;
				}			

                //If there is no error message , Valid entry

                if (string.IsNullOrEmpty(ErrorMessage))
                {
                    //No validation errors, insert the entry
                    
                    string sql = string.Format("INSERT INTO LOGIN (username ,password,firstname,lastname,gender,dob,address,securityQuestion,answer,isnewuser) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                      BaseDA.Escape(txtUserId.Text), BaseDA.Escape(txtPassword.Text), BaseDA.Escape(txtFirstName.Text), BaseDA.Escape(txtLastName.Text), BaseDA.Escape(listGender.SelectedValue), birthDate, BaseDA.Escape(txtAddress.Text), BaseDA.Escape(listSecQuestion.SelectedValue), BaseDA.Escape(txtAnswer.Text),"TRUE");

                    BaseDA.ExecuteNonQuery(sql);
                }

            }

            catch (Exception ex)
            {
               // ErrorMessage = "Exception " + ex;
                lblErrors.Text = ErrorMessage;
                
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
			Response.Redirect("Default.aspx",true);
        }

        private bool IsValidDate(string month, string day, string year)
        {
            try
            {
                //DateTime.ParseExact(string.Format("{0}/{1}/{2}", month, day, year), "d", CultureInfo.InvariantCulture);
                DateTime.Parse(string.Format("{0}/{1}/{2}", month, day, year), CultureInfo.InvariantCulture);
            }
            catch (Exception )
            {
                return false;
            }
            return true;
        }
    }
}