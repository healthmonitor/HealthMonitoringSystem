<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientEntry.aspx.cs" Inherits="HealthMonitorSystem.PatientEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Patient Entry</title>
</head>
<body>
<br /><b><p align="center">Health Status Update Form</p></b>
<font size="2">
<p align="left">Enter your medical information on this form</p>
<p align="left">Click on Submit to record the information</p>
<p align="left">Click on Cancel to clear all fields</p>
</font>
<br/>
	
    <form id="form1" runat="server">
      
             <table border="0" width="40%">

           <tr>
               <td>Patient ID </td>
               <td>
                    <asp:TextBox ID="txtpid" runat="server" ValidationGroup = "Patient"></asp:TextBox>
	           </td>
           </tr>

          <tr>
               <td>Temperature </td>
               
               <td>
    	             <asp:TextBox ID="txttemp" runat="server" ValidationGroup="Patient"></asp:TextBox>
    	             <td>Fahrenheit</td>
    	             <asp:RequiredFieldValidator ID="TempRequired"runat="server" ControlToValidate="txttemp" 
                     ErrorMessage="Please Enter the recorded temperature." ToolTip="Please Enter the recorded temperature."  >*</asp:RequiredFieldValidator>
               </td>
           </tr>
           
             <tr>

               <td>Bloop Pressure-high </td>
				
               <td>
                     <asp:TextBox ID="txtbphigh" runat="server" ValidationGroup="Patient"></asp:TextBox>
                     <td>mmHg</td>
                     <asp:RequiredFieldValidator ID="BPhighRequired"runat="server" ControlToValidate="txtbphigh" 
                     ErrorMessage="Please Enter the recorded Blood Pressure." ToolTip="Please Enter the recordedBlood Pressure."  >*</asp:RequiredFieldValidator>
               </td>
           </tr>

			<tr>

               <td>Bloop Pressure-low </td>
				
               <td>
                     <asp:TextBox ID="txtbplow" runat="server" ValidationGroup="Patient"></asp:TextBox>
                     <td>mmHg</td>
                     <asp:RequiredFieldValidator ID="BPlowRequired"runat="server" ControlToValidate="txtbplow" 
                     ErrorMessage="Please Enter the recorded Blood Pressure." ToolTip="Please Enter the recorded Blood Pressure."  >*</asp:RequiredFieldValidator>
               </td>
           </tr>


			<tr>

               <td>Pulse Rate </td>
				
               <td>
                     <asp:TextBox ID="txtpulserate" runat="server" ValidationGroup="Patient"></asp:TextBox>
                     <td>per minute</td>
                     <asp:RequiredFieldValidator ID="PulserateRequired"runat="server" ControlToValidate="txtpulserate" 
                     ErrorMessage="Please Enter the recorded Pulse Rate." ToolTip="Please Enter the recorded Pulse Rate."  >*</asp:RequiredFieldValidator>
               </td>
           </tr>

			<tr>

               <td>Glucose </td>
				
               <td>
                     <asp:TextBox ID="txtglucose" runat="server" ValidationGroup="Patient"></asp:TextBox>
                     <td>mg / dl</td>
                     <asp:RequiredFieldValidator ID="BPGlucoseRequired"runat="server" ControlToValidate="txtglucose" 
                     ErrorMessage="Please Enter the recorded Glucose level." ToolTip="Please Enter the recorded Glucose level."  >*</asp:RequiredFieldValidator>
               </td>
           </tr>

			<tr>

               <td>Pain Level </td>
			
               <td>
                     <asp:DropDownList ID="listpainlevel" runat="server">
                     <asp:ListItem>Select</asp:ListItem>
                     <asp:ListItem>1</asp:ListItem>
 					 <asp:ListItem>2</asp:ListItem>
						<asp:ListItem>3</asp:ListItem>
						<asp:ListItem>4</asp:ListItem>
						<asp:ListItem>5</asp:ListItem>
						<asp:ListItem>6</asp:ListItem>
						<asp:ListItem>7</asp:ListItem>
						<asp:ListItem>8</asp:ListItem>
						<asp:ListItem>9</asp:ListItem>
						<asp:ListItem>10</asp:ListItem>
                     </asp:DropDownList> 
                     <td>1-Less Pain,10-Severe Pain</td>
               </td>
           </tr>

			<tr>

               <td>Description </td>

               <td>
                     <asp:TextBox ID="txtdescription" runat="server" ValidationGroup="Patient"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="DescriptionRequired"runat="server" ControlToValidate="txtdescription" 
                     ErrorMessage="Please Enter the Brief Description." ToolTip="Please Enter the Brief Description."  >*</asp:RequiredFieldValidator>
               </td>
           </tr>

			<!--tr>
               <td>Entry Date </td>

               <td>
                     <asp:TextBox ID="txtentrydate" runat="server" ValidationGroup="Patient"></asp:TextBox>
               </td>
           </tr-->



           <tr><td colspan=2>&nbsp;</td></tr>
           <tr>
               <td colspan="2" align="center">
               <asp:Button ID="btnpatient" Text="Submit" runat="server" OnClick="btnpatient_Click"  ValidationGroup="Patient"/>
                  &nbsp; &nbsp;
               <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnpatient_Click"  ValidationGroup="Patient"/>
                  &nbsp; &nbsp;
                <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnpatient_Click"  ValidationGroup="Patient"/>
                  &nbsp; &nbsp;
                  
               </td>

          </tr>

          <tr><td colspan=2>&nbsp;</td></tr>

          
       </table>

   </form>
</body>
</html>
