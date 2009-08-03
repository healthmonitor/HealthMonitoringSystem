<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HealthMaster.master"
CodeBehind="ClerksPage.aspx.cs" Inherits="HealthMonitorSystem.ClerksPage"
%>

<asp:Content id="login" ContentPlaceHolderID="cphMain" runat="server">
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