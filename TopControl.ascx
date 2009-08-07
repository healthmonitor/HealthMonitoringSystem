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
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopControl.ascx.cs" Inherits="HealthMonitorSystem.TopControl" %>

<table width="100%" bgcolor="lightblue" > 
<tr>
<td align="right">
<b><p align="center" > <font color="white" size="6px">Health Monitor System</font></p></b>
	<asp:Label id="lblName" runat="server"> </asp:Label> <br />
</td>
</tr>
<tr>
<td align="right">
<asp:LinkButton ID="lnkLogout" Text="Logout" OnClick="btnLoff_Click" runat="server"></asp:LinkButton>
</td>
</tr>
</table>
