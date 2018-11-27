
Imports System.Data.SqlClient
Public Class MasterData
    Inherits System.Web.UI.Page

    Dim SQL, SQL1, SQL2, SQL3, ReturnValue As String
    Dim DS1 As SqlDataReader
    Dim LocalClass As New CUSharedLocalClass
    Dim LogonClass As New LogonClass
    Protected TempDataView As DataView = New DataView
    Protected TempDataView2 As DataView = New DataView

    Public sqlConn2 As String = LocalClass.SQLCNN
    'Public sqlConn3 As String = LocalClass.SQLCNN
    'Public SQLConn2 As String = "Data Source=CUNETDEV;Initial Catalog=CUNET_DB;user id=ASPNET;password=1234;Integrated Security=False"

    Dim DT, DT1, DT2, DT3 As DataTable

    Protected Sub New_BTN_Click(sender As Object, e As EventArgs) Handles New_BTN.Click
        'Here we have to enable the detail pannel
        Details_PNL.Enabled = True

        'Then generate a valid and unused netid within this table

    End Sub

    Protected Sub Consultant_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Consultant_List.SelectedIndexChanged

        'When a consultant is selected, we have to populate the data objects in the details_PNL
        'We need to loadup all the dropdownlists and have preselected data presented
        'To do this we have to set the sysID to a global variable to be used within the populate subs

        'Dim Dept As String

        Session("SYSID") = Consultant_List.SelectedValue


        Details_PNL.Enabled = True

        LoadUpText(Session("SYSID"))


        PopulateDepartments(FindDepart(Session("SYSID")))
        PopulateSupervisors(FindSup(Session("SYSID")))
        'PopulateLocations()
        'PopulateUnit()
        'PopulateDiv()

    End Sub

    Sub LoadUpText(SYSID)

        'In this sub we just load up all the test fields from the db
        SQL = "select * from Consultant_Master_Tbl where sysid=" & SYSID
        DT = LocalClass.ExecuteSQLDataSet2(SQL)

        If DT.Rows.Count > 0 Then
            FirstName_txt.Text = DT.Rows(0)("first_name").ToString
            LastName_txt.Text = DT.Rows(0)("last_name").ToString
            NETID_txt.Text = DT.Rows(0)("netid").ToString
            eMail_txt.Text = DT.Rows(0)("email").ToString
            Service_Req_txt.Text = DT.Rows(0)("servicereq").ToString
            PhoneExtention_txt.Text = DT.Rows(0)("ext").ToString
            Position_txt.Text = DT.Rows(0)("position").ToString
            Office_txt.Text = DT.Rows(0)("office").ToString
            AD_txt.Text = DT.Rows(0)("Ad_object_Location").ToString
            Company_txt.Text = DT.Rows(0)("Company_Info").ToString



        End If


    End Sub

    Function FindDepart(SYSID)

        'This sub will set session variables for various dropdown lists to be used later
        Dim i As Integer

        SQL = "select * from Consultant_Master_Tbl where sysid=" & SYSID
        DT = LocalClass.ExecuteSQLDataSet2(SQL)

        If DT.Rows.Count > 0 Then
            FindDepart = DT.Rows(i)("deptname").ToString
        End If

    End Function

    Function FindSup(SYSID)

        'This sub will set session variables for various dropdown lists to be used later
        Dim i As Integer

        SQL = "select * from Consultant_Master_Tbl where sysid=" & SYSID
        DT = LocalClass.ExecuteSQLDataSet2(SQL)

        If DT.Rows.Count > 0 Then
            FindSup = DT.Rows(i)("Supervisor_Name").ToString
        End If

    End Function

    Protected Sub GenNETID_BTN_Click(sender As Object, e As EventArgs) Handles GenNETID_BTN.Click

        GenerateANETID(LastName_txt, FirstName_txt)

    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then

        Else
            'First Time into app, we load up the listbox of consultant names
            PopulateConsultants()

        End If

    End Sub

    Sub PopulateConsultants()

        Dim TodaysDate As Date = Now
        Dim ConsultantDate As Date

        'This sub will populate all consultants
        SQL = "Select * from Consultant_Master_Tbl order by lastfirst desc"

        DT = LocalClass.ExecuteSQLDataSet2(SQL)

        Consultant_List.Items.Clear()

        Consultant_List.Items.Add(New ListItem("-- Select A Consultant --", 0))
        Consultant_List.Items(0).Attributes.Add("disabled", "disabled")

        For i = 0 To DT.Rows.Count - 1

            Try
                ConsultantDate = DT.Rows(i)("Term_date").ToString
            Catch ex As Exception
                ConsultantDate = TodaysDate
            End Try

            If ConsultantDate <= TodaysDate Then
                Consultant_List.Items.Add(New ListItem(DT.Rows(i)("lastfirst").ToString, DT.Rows(i)("SYSID").ToString))
                Consultant_List.Items(i).Attributes.CssStyle.Add("style", "color:Green")

            Else
                Consultant_List.Items.Add(New ListItem(DT.Rows(i)("lastfirst").ToString, DT.Rows(i)("SYSID").ToString))
                Consultant_List.Items(i).Attributes.CssStyle.Add("style", "color:red;font-weight: bold")
            End If
        Next

    End Sub

    Sub PopulateSupervisors(Sup)

        SQL = "select Last + ',' + first lastfirst, Netid,Emplid from ID_TBL where status='A' and time_sheet_code in ('TS101') order by Last,first"
        DT = LocalClass.ExecuteSQLDataSet(SQL)

        Sup_List.Items.Clear()

        Sup_List.Items.Add(New ListItem("-- Select A Supervisor --", 0))
        Sup_List.Items(0).Attributes.Add("disabled", "disabled")

        For i = 0 To DT.Rows.Count - 1

            If Sup = DT.Rows(i)("lastfirst").ToString Then
                Sup_List.Items.Add(New ListItem(DT.Rows(i)("lastfirst").ToString, DT.Rows(i)("lastfirst").ToString))
                Sup_List.Items(i + 1).Selected = True
            Else
                Sup_List.Items.Add(New ListItem(DT.Rows(i)("lastfirst").ToString, DT.Rows(i)("lastfirst").ToString))
            End If

        Next

    End Sub

    Sub PopulateDepartments(Dept)

        SQL = "select distinct departname from ID_TBL where status='A' order by departname"
        DT = LocalClass.ExecuteSQLDataSet(SQL)

        Dept_List.Items.Clear()

        Dept_List.Items.Add(New ListItem("-- Select A Department --", 0))
        Dept_List.Items(0).Attributes.Add("disabled", "disabled")

        For i = 0 To DT.Rows.Count - 1

            If Dept = DT.Rows(i)("departname").ToString Then
                Dept_List.Items.Add(New ListItem(DT.Rows(i)("departname").ToString, DT.Rows(i)("departname").ToString))
                Dept_List.Items(i + 1).Selected = True
            Else
                Dept_List.Items.Add(New ListItem(DT.Rows(i)("departname").ToString, DT.Rows(i)("departname").ToString))
                'Dept_List.Items(i).Selected = False
            End If



        Next

    End Sub

    Sub PopulateLocations(SYSID)

        SQL = "select distinct Location1 from ID_TBL where status='A' order by Location1"
        DT = LocalClass.ExecuteSQLDataSet(SQL)

        Location_LST.Items.Clear()

        Location_LST.Items.Add(New ListItem("-- Select A Physical Location --", 0))
        Location_LST.Items(0).Attributes.Add("disabled", "disabled")

        For i = 0 To DT.Rows.Count - 1

            Location_LST.Items.Add(New ListItem(DT.Rows(i)("Location1").ToString, DT.Rows(i)("Location1").ToString))

        Next

    End Sub

    Sub PopulateUnit(SYSID)

        SQL = "Select DISTINCT Unit FROM dbo.HR_PDS_DATA_tbl As HR_PDS_DATA_tbl_2"
        DT = LocalClass.ExecuteSQLDataSet(SQL)

        Unit_LST.Items.Clear()

        Unit_LST.Items.Add(New ListItem("-- Select A Unit --", 0))
        Unit_LST.Items(0).Attributes.Add("disabled", "disabled")

        For i = 0 To DT.Rows.Count - 1

            Unit_LST.Items.Add(New ListItem(DT.Rows(i)("Unit").ToString, DT.Rows(i)("Unit").ToString))

        Next

    End Sub

    Sub PopulateDiv(SYSID)

        SQL = "Select  DISTINCT DIVISION FROM dbo.HR_PDS_DATA_tbl"
        DT = LocalClass.ExecuteSQLDataSet(SQL)

        DIV_LST.Items.Clear()

        DIV_LST.Items.Add(New ListItem("-- Select A Unit --", 0))
        DIV_LST.Items(0).Attributes.Add("disabled", "disabled")

        For i = 0 To DT.Rows.Count - 1

            DIV_LST.Items.Add(New ListItem(DT.Rows(i)("DIVISION").ToString, DT.Rows(i)("DIVISION").ToString))

        Next

    End Sub

    Function GenerateANETID(last, first)

        Dim PartA, PartB As String
        Dim Prefix As String = "C-"
        'Here we take in the last and first name textboxes and create the consultant's unique NETID

        'Test case 1: Last 4 for lastname followed first 2 of first name

        If Len(last) >= 4 Then
            'Ok to use the last name
            PartA = Mid(last, 1, 4)
        Else

        End If

        If Len(first) >= 2 Then
            'OK to use first name
            PartB = Mid(first, 1, 2)
        Else

        End If

        SQL = "select * from Consultant_Master_Tbl where NETID='" & Prefix & PartA & PartB
        DT = LocalClass.ExecuteSQLDataSet2(SQL)

        If DT.Rows.Count > 0 Then
            'If we get here then a check of the db found someone already using the netid so
            'we have to generate a new ID and check again

            'FindDepart = DT.Rows(i)("deptname").ToString
        End If



        GenerateANETID = Prefix & PartA & PartB

    End Function

End Class