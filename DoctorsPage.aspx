<%@ Page Language="C#" Inherits="HealthMonitorSystem.DoctorsPage" MasterPageFile="~/HealthMaster.master" %>

<asp:Content id="doctors" ContentPlaceHolderID="cphMain" runat="server">
    <div>
    <asp:GridView AutoGenerateColumns="false" 
    runat="server"
    ID="gv" 
    OnRowCommand="gv_RowEditing" 
    >
    <Columns>
    <asp:BoundField DataField="ID" HeaderText="ID" />
    <asp:BoundField DataField="Name" HeaderText="Name"   />
    <asp:BoundField DataField="dob" DataFormatString="{0:MM-dd-yyyy}" HtmlEncode="false" HeaderText="Date of Birth"  />
    <asp:BoundField DataField="address" HeaderText="Address" />
    <asp:TemplateField HeaderText="View History">
    <ItemTemplate>
    <asp:LinkButton ID="bthView" runat="server" CommandName="View" CommandArgument=<%# DataBinder.Eval(Container.DataItem, "ID") %> >View</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </div>
    <br />
    
</asp:Content>