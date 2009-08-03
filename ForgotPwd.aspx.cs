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
using System.Data;
using System.Globalization;

namespace HealthMonitorSystem
{
    public partial class ForgotPwd : BasePage
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ErrorMessage = string.Empty;
            try
            {
                //check for required field validation 	

                if (string.IsNullOrEmpty(txtUserId.Text.Trim()))
                {
                    ErrorMessage += "User name is required <br/>";
                }
               /* if (Int16.Parse(listSecQuestion.SelectedValue.Trim())== -1)
                {				
                    ErrorMessage += "Security question is required <br/>";
                }*/
                if (string.IsNullOrEmpty(txtAnswer.Text.Trim()))
                {
                    ErrorMessage += "Answer is required <br/>";
                }
                if(string.IsNullOrEmpty(listMonth.SelectedValue.Trim()) || string.IsNullOrEmpty(txtDay.Text.Trim()) || string.IsNullOrEmpty(txtYear.Text.Trim()))
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

                //Valid entry

                if (string.IsNullOrEmpty(ErrorMessage))
                {


                    string sql =
                        string.Format(
                            "SELECT * FROM LOGIN WHERE username= '{0}'and dob = '{1}' and securityQuestion= '{2}' and answer = '{3}'",
                            BaseDA.Escape(txtUserId.Text.Trim()), birthDate,
                            BaseDA.Escape(listSecQuestion.SelectedValue), BaseDA.Escape(txtAnswer.Text.Trim()));

                    DataSet ds = BaseDA.ExecuteDataSet(sql);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        if (dr != null)
                        {
                            Response.Redirect("ChangePassword.aspx?username=" + this.txtUserId.Text.Trim(),true);
                        }

                    }
                }
            }
            catch(Exception)
            {
                //ErrorMessage = "Exception " + ex;
                lblErrors.Text = ErrorMessage;
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
