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
            <select id="sex" name=".sx">
            <option value="-1">[Select]</option>
            <option value="m">Male</option>
            <option value="f">Female</option>
            </select></td>
          </tr> 
          <tr>
            <td ><font color="red">*</font>Date of Birth:</td>
            <td ><select name=".bmon" id="bmon">
            <option value="-1" >[Select a Month]</option>
            <option value="0">January</option>
            <option value="1">February</option>
            <option value="2">March</option>
            <option value="3">April</option>
            <option value="4">May</option>
            <option value="5">June</option>
            <option value="6">July</option>
            <option value="7">August</option>
            <option value="8">September</option>
            <option value="9">October</option>
            <option value="10">November</option>
            <option value="11">December</option>
            </select> &nbsp;
            <asp:TextBox ID="txtbDay" runat="server"></asp:TextBox>&nbsp;,&nbsp;
            <asp:TextBox ID="txtbYear" runat="server"></asp:TextBox>
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
		    <td width="50%"><select id="pwq" name=".pw_q">
		    <option value="-1" selected>[Select a Question]</option>
		    <option value="What is your fathers middle name?">What is your father's middle name?</option>
		    <option value="What was the name of your first school?">What was the name of your first school?</option>
		    <option value="Who was your childhood hero?">Who was your childhood hero? </option>
		    <option value="What is your favorite pastime?">What is your favorite pastime?</option>
		    <option value="What is your all-time favorite sports team?">What is your all-time favorite sports team?</option>
		    <option value="What was your high school mascot?">What was your high school mascot?</option>
		    <option value="What make was your first car or bike?">What make was your first car or bike?</option>
		    <option value="Where did you first meet your spouse?">Where did you first meet your spouse?</option>	
		    <option value="What is your pets name?">What is your pet's name?</option>
		    </select></td>
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
