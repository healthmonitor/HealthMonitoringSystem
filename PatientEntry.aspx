<%@ Page Language="C#" MasterPageFile="~/HealthMaster.master" CodeBehind="PatientEntry.aspx.cs" Inherits="HealthMonitorSystem.PatientEntry"%>


<asp:Content id="login" ContentPlaceHolderID="cphMain" runat="server" >


<br/>
	<asp:LinkButton id="lnkBack"  OnClick="lnkBack_Click" Visible="true" runat="server" >Back</asp:LinkButton>

	<asp:LinkButton id="lnkHist"  Style = "Z-INDEX: 115; RIGHT: 400px; POSITION: absolute;" OnClick="lnkHist_Click" Visible="true" runat="server" >View History</asp:LinkButton>
	<asp:LinkButton id="lnkTip"  Style = "Z-INDEX: 101; RIGHT: 200px; POSITION: absolute;" OnClick="lnkTip_Click" Visible="true" runat="server" >Health Tips</asp:LinkButton>

<head>
    <title>Patient Entry</title>
    
</head>

    <br /><b><p align="center">Health Status Update Form</p></b>

<font size="2">
<p align="left">Enter your medical information on this form</p>
<p align="left"><font color="red">*</font> - Indicitaes Required Fields on this form</p>
<p align="left">Click on Submit to record the information</p>
<p align="left">Click on Cancel to clear all fields</p>
</font>

<br/>

   <div>
   <br /><br />
   <table border="0" width="65%">   
<tr>
               <td> 
               <font color="red">
               <asp:Label id="lblstar" runat="server" > </asp:Label>
               </font>
               
               <asp:Label id="lblpatient" runat="server" > </asp:Label>
               </td>
               <td>
				    <asp:DropDownList ID="listpid" runat="server" onselectedindexchanged="Pname_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList> 
                    <td>
                    <!--asp:Label id="lblstar" runat="server" > </asp:Label-->
                    </td>
                    <asp:Label id="lblpatid" runat="server" Visible = "false" > </asp:Label>
	           </td>
           </tr>

          <tr>
          		
               <td><font color="red">*</font>Temperature </td>
               
               <td>
    	             <asp:TextBox ID="txttemp" runat="server" ValidationGroup="Patient"></asp:TextBox>
    	             
    	             <td>Fahrenheit</td>
    	             <td></td>
               </td>
           </tr>
           
             <tr>

               <td><font color="red">*</font>Bloop Pressure-high </td>
				
               <td>
                     <asp:TextBox ID="txtbphigh" runat="server" ValidationGroup="Patient"></asp:TextBox>
                     
                     <td>mmHg</td>
               </td>
           </tr>

			<tr>

               <td><font color="red">*</font>Bloop Pressure-low </td>
				
               <td>
                     <asp:TextBox ID="txtbplow" runat="server" ValidationGroup="Patient"></asp:TextBox>
                     
                     <td>mmHg</td>
               </td>
           </tr>


			<tr>

               <td><font color="red">*</font>Pulse Rate </td>
				
               <td>
                     <asp:TextBox ID="txtpulserate" runat="server" ValidationGroup="Patient"></asp:TextBox>
                     
                     <td>per minute</td>
               </td>
           </tr>

			<tr>
				
               <td>Glucose </td>
				
               <td>
                     <asp:TextBox ID="txtglucose" runat="server" ValidationGroup="Patient"></asp:TextBox>
                     
                     <td>mg / dl</td>
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
                     <asp:TextBox ID="txtdescription" runat="server" textmode="multiline" ValidationGroup="Patient"></asp:TextBox>
               </td>
           </tr>
			<!--tr>
               <td>Date </td>
               <td>
                    <asp:Label id="lblDate" runat="server" > </asp:Label>               
               </td>
           </tr-->
   
   
   <tr><td colspan=2>&nbsp;</td></tr>
   
   <tr>
       <td colspan="2" align="center"> &nbsp;
           <asp:Button ID="btnpatient" runat="server" OnClick="btnpatient_Click" onclientclick="return confirm('Do you want to save?')" Text="Submit" ValidationGroup="Patient"/>
           <!--asp:Button ID="btnpatient" runat="server"  onclientclick="btnpatient_Click" Text="Submit" ValidationGroup="Patient"/-->
           &nbsp; &nbsp;
           <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click"  ValidationGroup="Patient"/>
           &nbsp; &nbsp;
           <asp:Button ID="btnHelp" Text="Help" runat="server" OnClick="btnHelp_Click"  ValidationGroup="Patient"/>
           &nbsp; &nbsp;
      </td>
   </tr>
   
	<asp:Label  ID="lblErrors" ForeColor="Red" runat="server" ></asp:Label>
   </table>   
   </div>

</asp:Content>  
