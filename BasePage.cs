
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
