<%-- 
  Copyright (c) 2009 Navya Jammula.

  This file is part of HealthMonitoringSystem.
  HealthMonitoringSystem is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.
  
  HealthMonitoringSystem is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with HealthMonitoringSystem.  If not, see
  <http://www.gnu.org/licenses/>.

--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HealthMonitorSystem.ChangePassword" MasterPageFile="~/HealthMaster.master"%>

<asp:Content id="login" ContentPlaceHolderID="cphMain" runat="server">
<fieldset style="width: 494px; height: 205px" >
<legend>Change Password</legend>
        
<table border="0" width="100%">
<tr>
    <td><font color="red">*</font>&nbsp;New password:</td>
    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox></td>
</tr>
<tr>
    <td><font color="red">*</font>&nbsp;Retype new password:</td>
    <td><asp:TextBox ID="txtRetypePassword" runat="server" TextMode="Password" ></asp:TextBox></td>
</tr>
<tr>
    <td colspan="2" align="center">
     
        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
   </td>
 </tr>    
 </table>
 <font color="red"><b>* indicates required field</b> </font>  
 <br /> 
  <asp:Label id="lblError" ForeColor="Red" runat="server" />
  </fieldset>
 
</asp:Content> 
