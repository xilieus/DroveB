'//====================================================================================================
'// Programmer: Claude Lake
'// Created: 7/27/2017
'// Description: Page to make transfers
'//====================================================================================================
Imports System.Data
Imports System.Data.SqlClient
Partial Class _Default
    Inherits System.Web.UI.Page
    ReadOnly myCon As New Controller
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click



        If Not Page.IsPostBack Then
            Session("CID") = Nothing
            Session("CUSNAME") = Nothing
        Else

            If Verify_User(Trim(txtEmail.Value), Trim(txtPassword.Value)) = True Then
                Response.Redirect("Accounts.aspx", False)
            Else
                errmsg.InnerText = "Your user login is incorrect!"
                errmsg.Visible = True
            End If

        End If

    End Sub

    Private Function Verify_User(ByVal uid As String, ByVal pwd As String) As Boolean

        '// This function is use to verify a security user login access
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim blnfound As Boolean
        ds.Clear()

        ds = myCon.Authenticate_User(uid, pwd)

        blnfound = False
        For Each dr In ds.Tables(0).Rows

            blnfound = True
            Session("CID") = dr(0).ToString()
            Session("CUSNAME") = dr(1).ToString()

        Next

        Return blnfound


    End Function

End Class
