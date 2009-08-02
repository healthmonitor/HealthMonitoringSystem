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
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Data;
using System.Configuration;
using System.Collections;


namespace HealthMonitorSystem
{
	
	
	public class BasePage : System.Web.UI.Page
	{
		
		public int UserId
		{
			get
			{
				if(Session["UserId"] != null)
				{
					return Convert.ToInt32(Session["UserId"]);
				}
				return 0;
			}
			set 
			{
				Session["UserId"] = value;
			}
		}
		
		public string UserName
		{
			get
			{
				if(Session["UserName"] != null)
				{
					return Session["UserName"].ToString();
				}
				return string.Empty;
			}
			set 
			{
				Session["UserName"] = value;
			}
		}
		
		public string ErrorMessage
		{
			get
			{
				if(Session["ErrorMessage"] != null)
				{
					return Session["ErrorMessage"].ToString();
				}
				return string.Empty;
			}
			set 
			{
				Session["ErrorMessage"] = value;
			}
		}
		
		public bool IsAdmin
		{
			get
			{
				if(Session["IsAdmin"] != null)
				{
					return Convert.ToBoolean(Session["IsAdmin"]);
				}
				return false;
			}
			set 
			{
				Session["IsAdmin"] = value;
			}
		}
		
		public bool IsDoctor
		{
			get
			{
				if(Session["IsDoctor"] != null)
				{
					return Convert.ToBoolean(Session["IsDoctor"]);
				}
				return false;
			}
			set 
			{
				Session["IsDoctor"] = value;
			}
		}
		
		public void ClearErrorMessages()
		{
			this.ErrorMessage = string.Empty;
		}
		
		public void ClearSession()
		{
			Session.Abandon();
		}
	}
}
