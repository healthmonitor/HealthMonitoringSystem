<%-- -----------------------------------------------------------------------
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
//----------------------------------------------------------------------- --%>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HealthMonitorSystem.Register"  MasterPageFile="~/HealthMaster.master"%>

<asp:Content id="login" ContentPlaceHolderID="cphMain" runat="server">


	<asp:LinkButton id="lnkBack"  OnClick="lnkBack_Click" Visible="true" runat="server" >Back</asp:LinkButton>
	<br/>
	<br/>
	<br/>

    <fieldset style="width: 1040px; height: 200">
        <legend>Registration Form</legend>
        <table border="0" width="100%" >
          <tr>
            <td colspan="2" style="height: 41px"><h3>Create Your ID</h3></td>
          </tr>
          <tr>
            <td style="width: 155px; height: 26px"><font color="red">*</font>&nbsp;User Name:</td>
            <td style="height: 26px; width: 444px;"><asp:TextBox ID="txtUserId" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td style="width: 155px"><font color="red">*</font>&nbsp;Password:</td>
            <td style="width: 444px"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox></td>
          </tr>
          <tr>
            <td style="width: 155px"><font color="red">*</font>&nbsp;Re-type password:</td>
            <td style="width: 444px"><asp:TextBox ID="txtRetypePwd" runat="server" TextMode="Password" ></asp:TextBox></td>
          </tr>
          <tr><td colspan="2"></td></tr>
          <tr>
          <td colspan="2"><h3>Personal Information</h3></td>
          </tr>
          <tr>
            <td style="width: 155px"><font color="red">*</font>&nbsp;First name:</td>
            <td style="width: 444px"><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td style="width: 155px"><font color="red">*</font>&nbsp;Last name:</td>
            <td style="width: 444px"><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td style="width: 155px">Gender:</td>
            <td style="width: 444px">
             <asp:DropDownList ID="listGender" runat="server">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:DropDownList>
            </td>
          </tr>
          
          
          <tr>
            <td style="width: 155px" ><font color="red">*</font>Date of Birth:</td>
            <td style="width: 444px">
            	<asp:DropDownList ID="listMonth" runat="server">
                    <asp:ListItem Value="-1" Selected = "TRUE">[Select a Month]</asp:ListItem>
                    <asp:ListItem Value="1">January</asp:ListItem>
                    <asp:ListItem Value="2">February</asp:ListItem>
                    <asp:ListItem Value="3">March</asp:ListItem>
                    <asp:ListItem Value="4">April</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">June</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">August</asp:ListItem>
                    <asp:ListItem Value="9">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>                   
                </asp:DropDownList> &nbsp; Day (dd):
                <asp:TextBox ID="txtDay" runat="server" MaxLength = "2" Width="84px" ></asp:TextBox> &nbsp; &nbsp;Year (yyyy):
                <asp:TextBox ID="txtYear" runat="server" MaxLength = "4" Width="83px"></asp:TextBox>
				
            </td>
           
          </tr>
          
          
           <tr>
            <td style="width: 155px">Address:</td>
            <td style="width: 444px"><asp:TextBox ID="txtAddress" runat="server" TextMode = "MultiLine" ></asp:TextBox></td>
          </tr>
          
                    
        <tr>
        <td colspan="2">
        <h3>If you forget your Password.....</h3>
        </td>
        </tr>
 
        <tr>
        <td style="width: 155px"><font color="red">*</font>Security Question:</td>
        <td style="width: 444px">
        <asp:DropDownList ID="listSecQuestion" runat="server">
            <asp:ListItem Value="-1" Selected = "TRUE">[Select a question]</asp:ListItem>
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
            <td style="width: 155px"><font color="red">*</font>Answer:</td>
            <td style="width: 444px"><asp:TextBox ID="txtAnswer" runat="server"  Width="200px" ></asp:TextBox></td>
       </tr>
 
        <tr>
        <td colspan="2" align="center">
         
        <asp:Button ID="btnRegister" Text="Register" runat="server" OnClick="btnRegister_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
    </td>
    </tr>
          
    </table>
    
    <font color="red"><b>* indicates required field</b> </font>
    <br/>
    <br/>
    
    <asp:Label  ID="lblErrors" ForeColor="Red" runat="server" ></asp:Label>
	
    </fieldset>
 
</asp:Content> 