<%@ Page Language="C#" MasterPageFile="~/HealthMaster.master" Inherits="HealthMonitorSystem.PatientHist" %>

	<asp:Content id="hist" ContentPlaceHolderID="cphMain" runat="server">
	<br/>
	<asp:LinkButton id="lnkBack"  OnClick="lnkBack_Click" Visible="true" runat="server" >Back</asp:LinkButton>
	
	<br /><br />
	<asp:GridView AutoGenerateColumns="false" runat="server" id="gvHist">
	<Columns>
	<asp:BoundField DataField="entrydate" DataFormatString="{0:MM-dd-yyyy}" HtmlEncode="false" HeaderText="Date Entered"  />    	
	<asp:BoundField DataField="temperature" HeaderText="Temparature" />
    <asp:BoundField DataField="bp" HeaderText="Blood Pressure"   />
    <asp:BoundField DataField="glucose" HeaderText="Glucose Level" />
    <asp:BoundField DataField="pulserate" HeaderText="Pulse Rate" />
    <asp:BoundField DataField="painlevel" HeaderText="Pain Level" />
    <asp:BoundField DataField="description" HeaderText="Comments" />
    </Columns>
    </asp:GridView>
	<br /><br/>
	
	</asp:Content>
