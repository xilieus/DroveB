'//====================================================================================================
'// Programmer: Claude Lake
'// Created: 7/24/2017
'// Description: Page that displays summary of accounts
'//====================================================================================================
Imports System.Data
Imports System.Data.SqlClient
Partial Class Accounts
    Inherits System.Web.UI.Page

    ReadOnly myCon As New Controller
    Dim CustomerId As Integer
    Dim CusAcctId As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        '// checks for an empty session
        If CStr(Session("CID")) = Nothing Then
            Response.Redirect("Default.aspx")
            Exit Sub
        End If

        If Not IsPostBack Then
            Load_Customer_Accounts_Summary()
        End If


    End Sub

    Private Sub Load_Customer_Info()

        Try

            Dim dsInfo As New DataSet

            '//Set dataset from class
            dsInfo.Clear()
            dsInfo = myCon.Get_Customer_Accounts_Summary(Session("CID"))

            Dim blnswitch As Boolean
            blnswitch = False

            tblAccounts.Rows.Clear()

        Catch ex As Exception
            Response.Redirect("Default.aspx")
        End Try
    End Sub

    Private Sub Load_Customer_Accounts_Summary()

        Try

            Dim dsAccts As New DataSet
            Dim dr As DataRow

            '//Set dataset from class
            dsAccts.Clear()
            dsAccts = myCon.Get_Customer_Accounts_Summary(Session("CID"))

            Dim blnswitch As Boolean
            blnswitch = False

            tblAccounts.Rows.Clear()

            '//Output account summary info into a table object
            '// I am dynamically creating at runtime, table cells and rows

            For Each dr In dsAccts.Tables(0).Rows

                '//Create table cell objects for Table object
                Dim trow2_c1 As TableCell
                Dim trow2_c2 As TableCell


                '//Create table row objects for Table object
                Dim trow2 As New TableRow

                '//Initialize table cell objects
                trow2_c1 = New TableCell
                trow2_c2 = New TableCell

                Dim link As New HyperLink
                link.NavigateUrl = "BalanceReporting.aspx?AccId=" & dr(2).ToString()
                link.Text = dr(1).ToString() & "-" & dr(2).ToString()
                trow2_c1.Controls.Add(link)
                trow2_c2.Text = FormatCurrency(dr(0).ToString(), 2)


                '//Add table cell to table row cells
                trow2.Cells.Add(trow2_c1)
                trow2.Cells.Add(trow2_c2)

                '//Add table rows objects to table object to ourput the data
                tblAccounts.Rows.Add(trow2)


            Next
            dsAccts.Clear()

        Catch ex As Exception
            Response.Redirect("Default.aspx")
        End Try


    End Sub


End Class
