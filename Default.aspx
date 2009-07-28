<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HealthMaster.master"
CodeBehind="Default.aspx.cs" Inherits="HealthMonitorSystem._Default"
%>
<asp:Content id="login" ContentPlaceHolderID="cphMain" runat="server">
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
   </div>
</asp:Content>  