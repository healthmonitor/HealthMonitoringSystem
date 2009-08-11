<%-- 
  Copyright (c) 2009 Navya Jammula,Anuja Kharade

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

<%@ Page Language="C#" Inherits="HealthMonitorSystem.DoctorsPage" MasterPageFile="~/HealthMaster.master" %>

<asp:Content id="doctors" ContentPlaceHolderID="cphMain" runat="server">
<br />
<head>
    <title>Doctor Page</title>
</head>

<b><p align="center">Patients Records </p></b>
    <div>
    <asp:GridView AutoGenerateColumns="false" Width="90%" HorizontalAlign="Center" 
    runat="server"
    ID="gv" 
    OnRowCommand="gv_RowCommand" 
    >
    <Columns>
    <asp:BoundField DataField="Name" HeaderText="Name"   />
    <asp:BoundField DataField="dob" DataFormatString="{0:MM-dd-yyyy}" HtmlEncode="false" HeaderText="Date of Birth"  />
    <asp:BoundField DataField="address" HeaderText="Address" />
    <asp:BoundField DataField="doctorremarks" HeaderText="Remarks" />    
    <asp:TemplateField HeaderText="View History">
    <ItemTemplate>
    <asp:LinkButton ID="btnView" runat="server" CommandName="View" CommandArgument=
    		<%# DataBinder.Eval(Container.DataItem, "ID") %> >View</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Add Comments">
    <ItemTemplate>
    <asp:LinkButton ID="btnRemarks" runat="server" CommandName="Remarks" CommandArgument=
    		<%# DataBinder.Eval(Container.DataItem, "ID") %> >Add</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </div>
    <br />
    <asp:PlaceHolder id="phRemarks" runat="server">
    <table>
    <tr>
    <td>
    	Remarks &nbsp;&nbsp;&nbsp;&nbsp;
    	<asp:TextBox id="txtRemarks" runat="server" Rows="5" Columns="75" TextMode="MultiLine" />
    </td>
    </tr>
    <tr>
    <td align="center"> 
    	<asp:Button id="btnRemarks" runat="server" Text="Save" OnClick="btnRemarks_Click" />
    	<asp:Button id="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </td>
    </tr>
    </table>
    </asp:PlaceHolder>
    
</asp:Content>