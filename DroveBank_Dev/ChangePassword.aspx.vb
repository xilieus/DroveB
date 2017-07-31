'//====================================================================================================
'// Programmer: Claude Lake
'// Created: 7/27/2017
'// Description: Page to update accounts
'//====================================================================================================
Imports System.Data
Imports System.Data.SqlClient
Partial Class ChangePassword
    Inherits System.Web.UI.Page
    ReadOnly myCon As New Controller

    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles Me.Load

        '// checks for an empty session
        If CStr(Session("CID")) = Nothing Then
            Response.Redirect("Default.aspx")
            Exit Sub
        End If

        If Not Page.IsPostBack Then

            Session("p-active") = Nothing
            Session("c-active") = "active"
            Session("n-active") = Nothing

        End If

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Try

            If myCon.CnXilieus.State = ConnectionState.Closed Then myCon.CnXilieus.Open()

            Dim SqlCmd As New SqlCommand

            'Set Properties of the Command
            SqlCmd.Connection = myCon.CnXilieus
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "SP_DB_UPDATE_CUSTOMER_PASSWORD"

            With SqlCmd.Parameters

                .AddWithValue("@CID", CInt(Session("CID"))).Direction = ParameterDirection.Input
                .AddWithValue("@PASSWORD", Trim(txtPasswordNewConfirm.Value).ToString()).Direction = ParameterDirection.Input
                .AddWithValue("@LAST_MODIFIED_DATE", Now.ToShortDateString.ToString()).Direction = ParameterDirection.Input


                'Execuate Command
                SqlCmd.ExecuteNonQuery()
                'release all resources
                SqlCmd.Parameters.Clear()
                SqlCmd.Dispose()

            End With

            msgblock.Visible = True
            successalert.Visible = True
            successalert.InnerHtml = "Password updated!"


        Catch ex As Exception
            formblock.Visible = False
            msgblock.Visible = True
            erralert.Visible = True
            erralert.InnerHtml = ex.ToString()
        End Try


    End Sub
End Class
