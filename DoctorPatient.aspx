<%-- 
  Copyright (c) 2009 Anuja Kharade,Navya Jammula.

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
<%@ Page Language="C#" MasterPageFile="~/HealthMaster.master" Inherits="HealthMonitorSystem.DoctorPatient" %>

	<asp:Content id="hist" ContentPlaceHolderID="cphMain" runat="server">
	<br/>
	<asp:LinkButton id="lnkBack"  OnClick="lnkBack_Click" Visible="true" runat="server" >Back</asp:LinkButton>
	
	<br /><br />
	<asp:GridView AutoGenerateColumns="false" Width="60%" runat="server" id="gvHist"
	 OnRowDataBound="gvHist_RowDataBound">
	<Columns>	    	
	<asp:TemplateField HeaderText="Select">
    <ItemTemplate>
    <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox>    
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="id"  HeaderText="Id"  />
	<asp:BoundField DataField="Name" HeaderText="Name" /> 
	<asp:TemplateField HeaderText="Doctor">
    <ItemTemplate>
    <asp:DropDownList id="ddlDoctor" runat="server" />
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    <br /><br/>
    
    <asp:Button id="btnAssociate" runat="server" Text="Associate" OnClick="btnAssociate_Click"  />&nbsp;&nbsp;
	<asp:Button id="btnClear" runat="server" Text="Cancel" OnClick="btnClear_Click"  />
	</asp:Content>
