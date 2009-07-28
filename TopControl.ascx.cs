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