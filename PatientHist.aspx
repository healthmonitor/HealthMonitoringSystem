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
