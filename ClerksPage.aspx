<%--
  Copyright (c) 2009 Anuja Kharade.
 
  This file is part of HealthMonitoringSystem.
  HealthMonitoringSystem is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.
  
  HealthMonitoringSystem is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
  GNU General Public License for more details.
 
  You should have received a copy of the GNU General Public License
  along with HealthMonitoringSystem. If not, see
  <http://www.gnu.org/licenses/>.
 
--%>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HealthMaster.master"
CodeBehind="ClerksPage.aspx.cs" Inherits="HealthMonitorSystem.ClerksPage"
%>

<asp:Content id="login" ContentPlaceHolderID="cphMain" runat="server">
<br/>
	<asp:LinkButton id="lnkBack"  OnClick="lnkBack_Click" Visible="true" runat="server" >Back</asp:LinkButton>
<head>
    <title>Clerk Activities</title>
</head>
    
    <br /><b><p align="center">Clerk Activities</p></b>
<font size="2">
<p align="left">As a Clerk, you can perform the following activities</p>
<p align="left">Assign Patients to the Doctors they have been visiting for treatment</p>
<p align="left">Enter the Patients's Medical Test Records</p>
</font>

<br/>

   <div>
   <br /><br />
   <table border="0" width="40%">   
   <tr><td colspan=2>&nbsp;</td></tr>
   
   <tr>
       <td colspan="2" align="center"> &nbsp;
       		<asp:Button ID="btnPatientEntry" Text="Patient Entry" runat="server" OnClick="btnPatientEntry_Click"  ValidationGroup="Clerk"/> <br/><br/>
           <asp:Button ID="btnDocPatEntry" Text="Doctor Patient Link" runat="server" OnClick="btnDocPatEntry_Click"  ValidationGroup="Clerk"/> <br/><br/>
           &nbsp; &nbsp;
      </td>
   </tr>
   </table>   
   </div>
</asp:Content>  