'//====================================================================================================
'// Programmer: Claude Lake
'// Created: 7/27/2017
'// Description: Page to make withdraws
'//====================================================================================================

Imports System.Data
Imports System.Data.SqlClient
Partial Class Withdraw
    Inherits System.Web.UI.Page

    ReadOnly myCon As New Controller
    Dim TransAct As SqlTransaction

    Private Sub Withdraw_Load(sender As Object, e As EventArgs) Handles Me.Load

        '// checks for an empty session
        If CStr(Session("CID")) = Nothing Then
            Response.Redirect("Default.aspx")
            Exit Sub
        End If

        If Not IsPostBack Then
            Load_Accounts()
        End If


    End Sub

    Private Sub Load_Accounts()

        '====================================================================
        ' In this procedure, I am making a call to my global function class
        ' retreive customer accounts. This class will then return a dataset
        ' to be loaded in to the dropdown list. Within the procedure, I am also
        ' making anotehr call to retrieve the customer account balance for
        ' each account to be displayed.
        '====================================================================
        Try

            Dim ds As New DataSet
            Dim dr As DataRow
            ds.Clear()
            ds = myCon.Get_Customer_Account_Info(Session("CID"))
            ddlAccounts.Items.Clear()
            ddlAccounts.Items.Add("")

            For Each dr In ds.Tables(0).Rows
                Dim newListItem As New ListItem
                newListItem.Text = CType(dr(0), String) & " - " & FormatCurrency(myCon.Get_Customer_Account_Balance(Session("CID"), dr(1).ToString()), 2)
                newListItem.Value = CType(dr(1), String)
                ddlAccounts.Items.Add(newListItem)
            Next
            ds.Clear()

        Catch ex As Exception
            formblock.Visible = False
            msgblock.Visible = True
            erralert.Visible = True
            erralert.InnerHtml = ex.ToString()
        End Try

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Try

            Dim strconf As String = Guid.NewGuid().ToString("N").Substring(0, 10)
            Dim transid As String = Nothing


            If myCon.CnXilieus.State = ConnectionState.Closed Then myCon.CnXilieus.Open()

            '**************************************************************
            'Initialize Transaction
            '**************************************************************
            '// Clear Transaction
            TransAct = Nothing

            '// Start a local transaction.
            TransAct = myCon.CnXilieus.BeginTransaction(IsolationLevel.ReadCommitted)

            Dim SqlCmd As New SqlCommand


            '//=============================================================================
            '//BEGIN WITHDRAW TRANSACTION
            '//=============================================================================


            'Set Properties of the Command
            SqlCmd.Connection = myCon.CnXilieus
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "SP_DB_CUSTOMER_WITHDRAW_TRANSACTION"
            SqlCmd.Transaction = TransAct

            With SqlCmd.Parameters

                .AddWithValue("@TRANS_TYPE", Trim(ddlTransType.Text)).Direction = ParameterDirection.Input
                .AddWithValue("@CID", Integer.Parse(Session("CID"))).Direction = ParameterDirection.Input
                .AddWithValue("@ACC_NUM", Trim(ddlAccounts.SelectedValue.ToString())).Direction = ParameterDirection.Input
                .AddWithValue("@WITHDRAW", Trim(txtAmount.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@TRANS_DATE", Now.ToShortDateString).Direction = ParameterDirection.Input
                .AddWithValue("@DESCRIPTION", Trim(txtDesc.Text)).Direction = ParameterDirection.Input

                'Execuate Command and return auto generated id. The return is is being executed at the server level.
                transid = SqlCmd.ExecuteScalar
                'release all resources
                SqlCmd.Parameters.Clear()
                SqlCmd.Dispose()

            End With

            '//=============================================================================
            '//BEGIN CONFIRMATION TRANSACTION
            '//=============================================================================

            'Set Properties of the Command
            SqlCmd.Connection = myCon.CnXilieus
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "SP_DB_CUSTOMER_TRANSACTION_CONFIRMATION"
            SqlCmd.Transaction = TransAct

            With SqlCmd.Parameters

                .AddWithValue("@CONFIRMATION_NUM", strconf).Direction = ParameterDirection.Input
                .AddWithValue("@TRANS_ID", transid).Direction = ParameterDirection.Input
                .AddWithValue("@CID", Integer.Parse(Session("CID"))).Direction = ParameterDirection.Input

                'Execuate Command
                SqlCmd.ExecuteNonQuery()
                'release all resources
                SqlCmd.Parameters.Clear()
                SqlCmd.Dispose()

            End With

            '**************************************************************
            'Save Changes and Commits the database transaction
            TransAct.Commit()
            '**************************************************************
            TransAct = Nothing
            myCon.CnXilieus.Close()

            formblock.Visible = False
            msgblock.Visible = True
            successalert.Visible = True
            successalert.InnerHtml =
                "<html><body><h3>Withdraw Transaction Completed Successfully</h3>" &
                   " <b>Status</b>: Withdraw Completed <br />" &
                  " <b>Confirmation #</b>: " & strconf & "<br />" &
                   " <b>Withdraw Account</b>: " & ddlAccounts.Text & "<br />" &
                   " <b>Withdraw Amount</b>: " & txtAmount.Value & "<br />" &
                   " <b>Description</b>: " & txtDesc.Text & "<br />" &
                   " <br />" &
                   "<a href='Withdraw.aspx'>Make a Withdraw</a>" &
                   "</body></html>"


        Catch ex As Exception
            formblock.Visible = False
        msgblock.Visible = True
        erralert.Visible = True
        erralert.InnerHtml = ex.ToString()
        End Try



    End Sub
End Class
