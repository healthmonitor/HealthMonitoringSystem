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

public partial class ErrorControl : System.Web.UI.UserControl
{
    protected override void OnPreRender (System.EventArgs e)
	{
		base.OnPreRender (e);
		if(Session["ErrorMessage"] != null)
		{
			lblErrors.Text = Session["ErrorMessage"].ToString();
			Session["ErrorMessage"] = string.Empty;
		}
	}

	
}
