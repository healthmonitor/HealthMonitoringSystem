<%@ Page Language="C#" MasterPageFile="~/HealthMaster.master" Inherits="HealthMonitorSystem.DoctorPatient" %>

	<asp:Content id="hist" ContentPlaceHolderID="cphMain" runat="server">
	<br/>
	<asp:LinkButton id="lnkBack"  OnClick="lnkBack_Click" Visible="true" runat="server" >Back</asp:LinkButton>
	
	<br /><br />
	<asp:GridView AutoGenerateColumns="false" runat="server" id="gvHist">
	<Columns>
	<asp:BoundField DataField="id"  HeaderText="Doctor"  />    	
	<asp:BoundField DataField="firstname" HeaderText="firstname" />
    <asp:BoundField DataField="lastname" HeaderText="lastname"   />
    </Columns>
    </asp:GridView>
    <br /><br/>
    
    
	
	</asp:Content>
