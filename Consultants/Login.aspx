<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Consultants.Login" StyleSheetTheme="" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
    
  


<head runat="server">
    
    <title>Consultant Accounts</title>
    <style type="text/css">
        .auto-style1 {
            height: 113px;
        }
    </style>
</head>
<body>
<form id="Logon" runat="server">
      <center><img src="MTST.png" alt='' class="auto-style1"/><br />
          Consultant AD Accounts<br />

       <asp:Panel ID="LoginPNL" runat="server" >

              <table style="width: 300px;">
                 <tr><td style="width: 80px; text-align:left;  ">&nbsp;&nbsp;<strong>NETID</strong></td>
                     <td align="left"><asp:TextBox ID="IDTXT" runat="server" Width="180px" value=""></asp:TextBox></td></tr>
                 <tr><td style="width: 80px; height:30px; text-align:left;"><strong>Password</strong></td>
                     <td style="height:30px; text-align:left"><asp:TextBox ID="PSTXT" runat="server" Width="180px" value="" TextMode="Password"></asp:TextBox></td></tr>
                 <tr><td>&nbsp;</td>
                     <td style="text-align:center; height:30px;" align="center"><asp:Button ID="LoginBTN" runat="server" BackColor="#00ae4d" Width="90px" Text="Login" BorderStyle="None" ForeColor="White"/></td></tr>
                 <tr><td colspan="2" style="text-align:center"><a style="text-decoration:none; color:blue; " onmouseover="this.style.color='red';" onmouseout="this.style.color='blue';" target="_blank" 
                                href="http://cu-ykvm-ars/QPM/User/Identification/">Forgot, Change or Unlock my Password</a></td></tr>

<!--            <tr><td colspan="2" style="text-align:center"><a style="text-decoration: none; color: blue;" onmouseover="this.style.color='red';" onmouseout="this.style.color='blue';" target="_blank"
                href="http://<%=Request.Url.Host%>/applications/UserPswChg.asp?BASEAPP=/applications/Logon.asp">Change my Password</a></td></tr>
            <tr><td colspan="2" style="text-align:center"><a style="text-decoration: none; color: blue;" onmouseover="this.style.color='red';" onmouseout="this.style.color='blue';" target="_blank"
                href="http://<%=Request.Url.Host%>/applications/UserPswrd.asp">Forgot password?</a></td></tr>-->


                        </table>
                    </asp:Panel>
        

    </center>
    
      
    </form>
</body>
</html>