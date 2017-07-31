'//====================================================================================================
'// Programmer: Claude Lake
'// Created: 7/28/2017
'// Description: Page to make transfers
'//====================================================================================================
Imports System.Data
Imports System.Data.SqlClient
Partial Class OpenAccount
    Inherits System.Web.UI.Page

    ReadOnly myCon As New Controller
    Dim TransAct As SqlTransaction
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Try

            Dim temppwd As String = Guid.NewGuid().ToString().Substring(0, 12)
            Dim straccount As String = Guid.NewGuid().ToString("N").Substring(0, 8)
            Dim cid As Integer = Nothing

            If myCon.CnXilieus.State = ConnectionState.Closed Then myCon.CnXilieus.Open()


            '**************************************************************
            'Initialize Transaction
            '**************************************************************
            '// Clear Transaction
            TransAct = Nothing

            '//Start a local transaction.
            TransAct = myCon.CnXilieus.BeginTransaction(IsolationLevel.ReadCommitted)


            Dim SqlCmd As New SqlCommand

            '//=============================================================================
            '//BEGIN CUSTOMER PROFILE CREATION
            '//=============================================================================

            'Set Properties of the Command
            SqlCmd.Connection = myCon.CnXilieus
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "SP_DB_CREATE_CUSTOMER"
            SqlCmd.Transaction = TransAct

            With SqlCmd.Parameters

                .AddWithValue("@FIRST_NAME", Trim(txtfname.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@LAST_NAME", Trim(txtlname.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@EMAIL", Trim(txtemail.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@PASSWORD", temppwd).Direction = ParameterDirection.Input
                .AddWithValue("@CREATE_DATE", Now.ToShortDateString.ToString()).Direction = ParameterDirection.Input


                'Execuate Command and return auto generated id. The return is is being executed at the server level.
                cid = SqlCmd.ExecuteScalar

                'Execuate Command
                '  SqlCmd.ExecuteNonQuery()
                'release all resources
                SqlCmd.Parameters.Clear()
                SqlCmd.Dispose()

            End With


            '//=============================================================================
            '//BEGIN ACCOUNT CREATION
            '//=============================================================================

            'Set Properties of the Command
            SqlCmd.Connection = myCon.CnXilieus
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "SP_DB_CREATE_CUSTOMER_ACCOUNT"
            SqlCmd.Transaction = TransAct

            With SqlCmd.Parameters

                .AddWithValue("@ACC_NUM", straccount).Direction = ParameterDirection.Input
                .AddWithValue("@CID", cid).Direction = ParameterDirection.Input
                .AddWithValue("@ACC_TYPE", Trim(ddlAccType.Text)).Direction = ParameterDirection.Input
                .AddWithValue("@ACC_DATE_OPEN", Now.ToShortDateString).Direction = ParameterDirection.Input

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
                "<html><body><h3>Account Creation</h3>" &
                   " <b>Status</b>:Account created successfully! <br />" &
                   " <b>Account #</b>: " & straccount & "<br />" &
                   " <b>Temp Password</b>: " & temppwd & "<br/>" &
                   " <br />" &
                   "<a href='Default.aspx'>Sign In</a>" &
                   "</body></html>"

        Catch sqlex As SqlException
            '//Roll back a transaction from a pending state.
            '//This will not allow a record to be comitted to the database.

            TransAct.Rollback()
            TransAct = Nothing
            myCon.CnXilieus.Close()
            formblock.Visible = False
            msgblock.Visible = True
            erralert.Visible = True
            erralert.InnerHtml = sqlex.ToString()

        Catch ex As Exception

            formblock.Visible = False
            msgblock.Visible = True
            erralert.Visible = True
            erralert.InnerHtml = ex.ToString()

        End Try



    End Sub





End Class
