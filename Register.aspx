<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HealthMonitorSystem.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Register :</title>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset style="width: 500; height: 395" >
        <legend>Registration Form</legend>
        <table border="0" width="100%" >
          <tr>
            <td colspan="2"><h3>Create Your ID</h3></td>            
          </tr>
          <tr>
            <td><font color="red">*</font>&nbsp;User Name:</td>
            <td><asp:TextBox ID="txtUserId" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td><font color="red">*</font>&nbsp;Password:</td>
            <td><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td><font color="red">*</font>&nbsp;Re-type password:</td>
            <td><asp:TextBox ID="txtRetypePwd" runat="server"></asp:TextBox></td>
          </tr>
          <tr><td colspan="2"></td></tr>
          <tr>
          <td colspan="2"><h3>Personal Information</h3></td>   
          </tr>
          <tr>
            <td><font color="red">*</font>&nbsp;First name:</td>
            <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td><font color="red">*</font>&nbsp;Last name:</td>
            <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
          </tr> 
          <tr>
            <td>Gender:</td> 
            <td>
            	<asp:DropDownList ID="listGender" runat="server">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>                                             
                </asp:DropDownList> 
            </td>
          </tr> 
          <tr>
            <td ><font color="red">*</font>Date of Birth:</td>
            <td >
            	<!--asp:Calendar ID="birthDate" SelectedDate= "DateTime" runat="server" /-->
            </td>
          </tr> 
          
           <tr>
            <td>Address:</td>
            <td><asp:TextBox ID="txtAddress" runat="server" TextMode = "MultiLine" ></asp:TextBox></td>
          </tr> 
                    
		   <tr>
		    <td colspan=2>
		    <h3>If you forget your Password.....</h3>
		    </td>   
		  </tr>
		
		  <tr>
		    <td width="50%"><font color="red">*</font>Security Question:</td>
		    <td width="50%">
		    	<asp:DropDownList ID="listSecurityQuestion" runat="server">
                    <asp:ListItem Value = "What is your father's middle name?">What is your father's middle name?</asp:ListItem>
                    <asp:ListItem Value = "What was the name of your first school?">What was the name of your first school?</asp:ListItem>  
                    <asp:ListItem Value = "Who was your childhood hero?">Who was your childhood hero?</asp:ListItem>  
                    <asp:ListItem Value = "What is your favorite pastime?">What is your favorite pastime?</asp:ListItem> 
                    <asp:ListItem Value = "What is your all-time favorite sports team?">What is your all-time favorite sports team?</asp:ListItem>   
                    <asp:ListItem Value = "What was your high school mascot?">What was your high school mascot?</asp:ListItem>
                    <asp:ListItem Value = "What make was your first car or bike?">What make was your first car or bike?</asp:ListItem>
                    <asp:ListItem Value = "Where did you first meet your spouse?">Where did you first meet your spouse?</asp:ListItem>
                    <asp:ListItem Value = "What is your pet's name?">What is your pet's name?</asp:ListItem>                                         
                </asp:DropDownList>     
		    </td>
		  </tr> 
		  
		  <tr>
            <td>Answer:</td>
            <td><asp:TextBox ID="txtAnswer" runat="server" TextMode = "MultiLine" ></asp:TextBox></td>
          </tr> 

		  <tr>
		   <td colspan="2" align="center">
		
		       <asp:Button ID="btnRegister" Text="Register" runat="server"
					OnClick="btnRegister_Click"  />
		            &nbsp; &nbsp;
		       <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
		   </td>
		  </tr>
          
        </table>
        </fieldset>

    </form>
</body>
</html>
