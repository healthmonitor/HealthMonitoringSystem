<%@ Page Language="C#" Inherits="HealthMonitorSystem.PatientHist" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head>
	<title>PatientHist</title>
</head>
<body>
	<form id="form1" runat="server">
	<br/>
	<table border="0" width="100%">
	<tr align="right">
	<td align="right"><asp:Label id="lblName" runat="server"> </asp:Label></td>
	</tr>
	</table>
	
	<br /><br />
	<asp:GridView AllowPaging="true" AllowSorting="true" runat="server" id="gvHist"></asp:GridView>
	<br /><br/>
	<asp:Label id="lblError" runat="server" ForeColor="Red" > </asp:Label>
	</form>
</body>
</html>