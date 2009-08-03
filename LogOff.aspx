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
<%@ Page Language="C#" MasterPageFile="HealthMaster.master" Inherits="HealthMonitorSystem.LogOff" %>
<asp:Content ContentPlaceHolderID="cphMain" runat="server">
    <div>
    You are Successfully logged out of the System. Please click 
      <asp:LinkButton ID="lnkLogin" PostBackUrl="~/Default.aspx" runat="server">here</asp:LinkButton>
        to Login.
    </div>
</asp:Content>