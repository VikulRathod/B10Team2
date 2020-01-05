<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="addtype.aspx.cs" Inherits="_1_Authentication.addtype" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
    <table>
        <tr>
            <td>
                <h2>Add Type</h2>
            </td>

        </tr>
        <tr>
            <td>
              Choose City:
            </td>
            <td>
           <asp:DropDownList ID="ddlClass" runat="server">
               
            </asp:DropDownList>                  
                <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server"
                     SelectCommand="SELECT [Name] FROM [addCityNames]" ConnectionString="<%$ ConnectionStrings:AuthenticationDBConnectionString %>"></asp:SqlDataSource>--%>
            </td>
        </tr>
        <tr>
            <td>
                Car Type
            </td>
            <td>
                <asp:TextBox ID="txtCarType" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Minimum Bill Charge:</td>
            <td>
                <asp:TextBox ID="txtMinBillCharge" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Free KMs</td>
            <td>
                <asp:TextBox ID="txtFreeKMs" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Waiting Charges:</td>
            <td>
                <asp:TextBox ID="txtWatCharge" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Extra Per KM Charge:</td>
            <td>
                <asp:TextBox ID="txtExtraPerCharge" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnAddType" runat="server" Text="Add Type" OnClick="btnAddType_Click" /></td>
        </tr>
        <tr> 
            <td>
                <asp:Label ID="lblAddType" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <h2>Allready Added Car Types for this City</h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </td>
        </tr>     

    </table>
        </form>
</body>
</html>
