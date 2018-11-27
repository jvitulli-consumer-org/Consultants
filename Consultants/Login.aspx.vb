Imports System.Data.SqlClient
Public Class Login
    Inherits System.Web.UI.Page

    Dim SQL, SQL1, SQL2, ReturnValue As String
    Dim DS1 As SqlDataReader
    Dim LocalClass As New CUSharedLocalClass
    Dim LogonClass As New LogonClass
    Protected TempDataView As DataView = New DataView
    Protected TempDataView2 As DataView = New DataView

    Public sqlConn2 As String = LocalClass.SQLCNN
    Dim DT, DT1, DT2 As DataTable

    Protected Sub LoginBTN_Click(sender As Object, e As EventArgs) Handles LoginBTN.Click

        'Things we need to do here:
        '1. Validate the user login against AD or by masterpass

        '--Get mimic password--
        SQL1 = "select Rtrim(Ltrim(PSWRD))PSWRD from id_tbl where Rtrim(Ltrim(emplid))=1010"
        DT1 = LocalClass.ExecuteSQLDataSet(SQL1)

        If Trim(PSTXT.Text) = "" & DT1.Rows(0)("PSWRD").ToString & "" Then
            Session("EMPLID") = DT.Rows(0)("EMPLID").ToString
            Session("NETID") = DT.Rows(0)("NETID").ToString
        Else
            ValidateActiveDirectoryLogin(Trim(IDTXT.Text), Trim(PSTXT.Text))
        End If

        LocalClass.CloseSQLServerConnection()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This app is really basic but has some nuances to be aware of:
        '1. It uses two seperate databases/severs... One for login info (the CRNet) system
        '2. The other is a seperate instanace of SQL called ars01ynk16vp with a databased called Accounts
        'In that accounts database is just one table called Consultant_Master_tbl

        'The Process: a) get login info for the logged in user from CRNet
        '             b) perform all database updates/inserts from the second sever know as ExecuteSQLDataSet2 function in the share local class

        'Once the user validates, we pass it to the page MasterData.aspx
        'MasterData will do all the real work on processing requests

        LoginBTN.Attributes.Add("onMouseOver", "this.style.cursor='pointer';")


    End Sub


    Function ValidateActiveDirectoryLogin(ByVal Username As String, ByVal Password As String) As Boolean
        Dim Success As Boolean = False
        Dim Entry As New System.DirectoryServices.DirectoryEntry("LDAP://consumer.org", Username, Password)
        Dim Searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        Searcher.SearchScope = DirectoryServices.SearchScope.OneLevel

        Try
            Dim Results As System.DirectoryServices.SearchResult = Searcher.FindOne
            Success = Not (Results Is Nothing)
        Catch
            Success = False
        End Try

        If Success = False Then
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Login", "<script language='JavaScript'> alert('Your NETID or Password is incorrect.'); </script>")
        Else
            'Response.Write("you password is correct")
            SQL = " Select * from ID_TBL where netid='" & Username & "' and Status='A'"
            DT = LocalClass.ExecuteSQLDataSet(SQL)
            If DT.Rows.Count > 0 Then
                Session("EMPLID") = DT.Rows(0)("EMPLID").ToString
                Session("NETID") = DT.Rows(0)("NETID").ToString
                Session("DEPTID") = DT.Rows(0)("DEPTID1").ToString

                '--Does this user have the rights to even get into this app? --
                ' Restriction is currently based on who is within the IT department
                SQL2 = "Select * From ID_TBL Where emplid = " & Session("emplid")
                SQL2 &= " And deptid1 = 9009130"

                DT2 = LocalClass.ExecuteSQLDataSet(SQL2)

                If DT2.Rows.Count > 0 Then
                    Response.Redirect("MasterData.aspx?id=" & Trim(Session("EMPLID")))
                Else
                    'If we get here then show that you are not allowed
                    StopRightHere()
                End If

            End If
        End If

        LocalClass.CloseSQLServerConnection()
    End Function

    Sub StopRightHere()

        Response.Write("<table width=100%><tr><td height=200px></td></tr><tr><td>")
        Response.Write("<p align=center><font color=blue><b>Thank you for your interest in accessing this application. However, you are not eligible to use this feature of CRNet.</b></p>")
        'Response.Write("<p align=center><b>Only active employees are authorized.</b></p>")
        Response.Write("<p align=center><b>If you feel this is incorrect, please contact IT support at extension 2003.</b></p>")
        Response.Write("<p align=center><a href='https://sites.google.com/a/consumer.org/crnet/crnethome'><img src=Images/Back_button.png style=width:50px></a></p></td></tr></table>")
        Response.End()

    End Sub

End Class