<%@ Page Language="C#" MasterPageFile="HealthMaster.master" Inherits="HealthMonitorSystem.LogOff" %>
<asp:Content ContentPlaceHolderID="cphMain" runat="server">
    <div>
    You are Successfully logged out of the System. Please click 
      <asp:LinkButton ID="lnkLogin" PostBackUrl="~/Default.aspx" runat="server">here</asp:LinkButton>
        to Login.
    </div>
</asp:Content>