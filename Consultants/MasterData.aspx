<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MasterData.aspx.vb" Inherits="Consultants.MasterData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            vertical-align:top;
             
        }
        .auto-style2 {
            width: 128px;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            font-size: x-large;
        }
        .auto-style6 {
            width: 156px;
        }
        .auto-style7 {
            width: 156px;
            height: 23px;
        }
        .auto-style8 {
            height: 23px;
        }
        .auto-style9 {
            width: 156px;
            height: 22px;
        }
        .auto-style10 {
            height: 22px;
        }
    </style>
</head>
<body>
    <p class="auto-style3">
        <span class="auto-style4">Consultants for Active Directory</span><br />
    </p>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr style="vertical-align:top;">
                <td class="auto-style2">
                    <asp:Button ID="New_BTN" runat="server" Text="New Consultant" Width="100%" />
                    <br />
                    <asp:ListBox ID="Consultant_List" runat="server" AutoPostBack="True"></asp:ListBox>
                </td>
                <td>
                    <asp:Panel ID="Details_PNL" runat="server" Enabled="False">
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style6">First</td>
                                <td>
                                    <asp:TextBox ID="FirstName_txt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Last</td>
                                <td>
                                    <asp:TextBox ID="LastName_txt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">NETID</td>
                                <td>
                                    <asp:TextBox ID="NETID_txt" runat="server"></asp:TextBox>
                                    <asp:Button ID="GenNETID_BTN" runat="server" Text="Generate Unique NETID" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">eMail</td>
                                <td>
                                    <asp:TextBox ID="eMail_txt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Hire Date</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Term Date</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Department</td>
                                <td>
                                    <asp:DropDownList ID="Dept_List" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Supervisor</td>
                                <td>
                                    <asp:DropDownList ID="Sup_List" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Position</td>
                                <td>
                                    <asp:TextBox ID="Position_txt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">Location</td>
                                <td class="auto-style8">
                                    <asp:DropDownList ID="Location_LST" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Office</td>
                                <td>
                                    <asp:TextBox ID="Office_txt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Phone Extension</td>
                                <td>
                                    <asp:TextBox ID="PhoneExtention_txt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Division</td>
                                <td class="auto-style10">
                                    <asp:DropDownList ID="DIV_LST" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Unit</td>
                                <td>
                                    <asp:DropDownList ID="Unit_LST" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">AD Object Location</td>
                                <td>
                                    <asp:TextBox ID="AD_txt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Service Request</td>
                                <td>
                                    <asp:TextBox ID="Service_Req_txt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">SAP</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style6">Company Info</td>
                                <td>
                                    <asp:TextBox ID="Company_txt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
