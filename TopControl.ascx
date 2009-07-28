<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopControl.ascx.cs" Inherits="HealthMonitorSystem.TopControl" %>

<table width="100%"><tr>
<td align="right">
<asp:LinkButton ID="lnkLogout" Text="Logout" OnClick="btnLoff_Click" runat="server"></asp:LinkButton>
	
</td>
<td align="right">
	<asp:Label id="lblName" runat="server"> </asp:Label></td>
</tr></table>
