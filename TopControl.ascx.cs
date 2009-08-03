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
public partial class TopControl : System.Web.UI.UserControl
{
    protected override void OnPreRender (System.EventArgs e)
    {
    	base.OnPreRender (e);    
			if(Session["UserName"] != null)
			{
				lblName.Text = "Welcome <br/>" + Session["UserName"].ToString();
			}
			else
			{
				lnkLogout.Visible = false;
			}
	}   
		
	protected void btnLoff_Click (object sender, EventArgs e)
    {
			Session.Abandon();
			Response.Redirect("~/LogOff.aspx", true);
		}
	}
}