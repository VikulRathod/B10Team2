<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBookings.aspx.cs" Inherits="_1_Authentication.ADMIN.ViewBookings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td> Choose City:
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            </td>
             <td>
                &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
                  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                   Choose Date:
                <td><asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            <td> &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
                &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
                 Choose Status:
                <td> <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
            </td>
            </td>    
            </td></td>
        </tr>

        </table>
        <table<>
            <tr>
                Bookings:
                <asp:Label ID="Label1" runat="server"></asp:Label>

                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataSourceID="SqlDataSource2">
                    <Columns>
                        <asp:BoundField />
                    </Columns>

                </asp:GridView>

            </tr>
            <tr>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" OnSelected="SqlDataSource2_Selected" >
                        <SelectParameters>
                                    <asp:ControlParameter ControlID="DropDownList1" Name="PickupCity" 
                                        PropertyName="SelectedValue" Type="Decimal" />
                                    <asp:ControlParameter ControlID="DropDownList2" Name="st" 
                                        PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="Calendar1" Name="pkdt" 
                                        PropertyName="SelectedDate" />
                                </SelectParameters>
                </asp:SqlDataSource>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
