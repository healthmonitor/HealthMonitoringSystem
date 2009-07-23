<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="Default.aspx.cs" Inherits="HealthMonitorSystem._Default"
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
   <title>Login </title>
</head>
<body>
   <form id="form1" runat="server">
   <div>
   <br /><br />
   <table border="0" width="40%">   
   <tr>
       <td>Login </td>
       <td><asp:TextBox ID="txtuser" runat="server" ></asp:TextBox></td>
   </tr>
   
   <tr>
	   <td>Password </td>
	   <td><asp:TextBox ID="txtpassword" runat="server" TextMode= "Password" ></asp:TextBox></td>
   </tr>
   
   <tr><td colspan=2>&nbsp;</td></tr>

   <tr>
       <td colspan="2" align="center">
	       <asp:Button ID="btnlogin" Text="Submit" runat="server" OnClick="btnlogin_Click"  />
	            &nbsp; &nbsp;
	       <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
       </td>
   </tr>

   <tr><td colspan=2>&nbsp;</td></tr>
   
   <tr>
       <td colspan="2" align="center">New User? &nbsp;
           <asp:LinkButton ID="lnkRegister" Text="Register" runat="server" OnClick="lnkregister_Click" />
               &nbsp; &nbsp;
           <asp:LinkButton ID="lnkforgotpwd" Text="Forgot Password"  runat="server" OnClick="lnkforgotpwd_Click" />

      </td>
   </tr>
   </table>
   <br /><br/>
   <asp:Label id="lblError" runat="server" ForeColor="Red" > </asp:Label>	
   </div>
   </form>
</body>
</html>