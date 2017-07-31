Imports System.Data
Imports System.Data.SqlClient
Public Class Controller

    Public SqlConnectionString As String = ConfigurationManager.ConnectionStrings("XilieusDB").ConnectionString
    Public CnXilieus As New SqlConnection(SqlConnectionString)
    Public ArrStates As String() =
    {"", "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FM", "FL", "GA", "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY",
    "LA", "ME", "MH", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "MP", "OH", "OK",
    "OR", "PW", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VI", "VA", "WA", "WV", "WI", "WY"}


    Public Function Get_Customer_Accounts_Summary(ByVal strCID As Integer) As DataSet

        Dim adAccts As New SqlDataAdapter
        Dim dsCusAccts As New DataSet
        Dim sqlCmd As SqlCommand = New SqlCommand

        '//Define Sql Command and Set Properties
        sqlCmd.Connection = CnXilieus
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "SP_DB_CUSTOMER_ACCTS_SUMMARY"

        With sqlCmd.Parameters
            .AddWithValue("@CID", strCID)
        End With

        'Define DataAdapter to Fill data
        adAccts = New SqlDataAdapter(sqlCmd)
        adAccts.Fill(dsCusAccts, "SP_DB_CUSTOMER_ACCTS_SUMMARY")

        Return dsCusAccts

    End Function

    Public Function Get_Customer_Account_Info(ByVal intCID As Integer) As DataSet

        Dim adAcct As New SqlDataAdapter
        Dim dsCusAcct As New DataSet
        Dim sqlCmd As SqlCommand = New SqlCommand

        '//Define Sql Command and Set Properties
        sqlCmd.Connection = CnXilieus
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "SP_DB_GET_CUSTOMER_ACCOUNT_INFO"

        With sqlCmd.Parameters
            .AddWithValue("@CID", intCID)
        End With

        'Define DataAdapter to Fill data
        adAcct = New SqlDataAdapter(sqlCmd)
        adAcct.Fill(dsCusAcct, "SP_DB_GET_CUSTOMER_ACCOUNT_INFO")

        Return dsCusAcct

    End Function
    Public Function Get_Customer_Account_Balance(ByVal intCID As Integer, ByVal strAccId As String) As String

        Dim adAcctBalance As New SqlDataAdapter
        Dim dsAcctBalance As New DataSet
        Dim sqlCmd As SqlCommand = New SqlCommand
        Dim strbalance As String = "0"

        '//Define Sql Command and Set Properties
        sqlCmd.Connection = CnXilieus
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "SP_DB_GET_CUSTOMER_ACCOUNT_BALANCE"

        With sqlCmd.Parameters
            .AddWithValue("@CID", intCID)
            .AddWithValue("@ACC_NUM", strAccId)
        End With

        'Define DataAdapter to Fill data
        adAcctBalance = New SqlDataAdapter(sqlCmd)
        adAcctBalance.Fill(dsAcctBalance, "SP_DB_GET_CUSTOMER_ACCOUNT_BALANCE")

        For Each dr In dsAcctBalance.Tables(0).Rows
            strbalance = dr(0).ToString
        Next

        Return strbalance

    End Function

    Public Function Get_Customer_Profile(ByVal intCID As Integer) As DataSet

        Dim adProfile As New SqlDataAdapter
        Dim dsProfile As New DataSet
        Dim sqlCmd As SqlCommand = New SqlCommand

        '//Define Sql Command and Set Properties
        sqlCmd.Connection = CnXilieus
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "SP_DB_GET_CUSTOMER_PROFILE_INFO"

        With sqlCmd.Parameters
            .AddWithValue("@CID", intCID)
        End With

        'Define DataAdapter to Fill data
        adProfile = New SqlDataAdapter(sqlCmd)
        adProfile.Fill(dsProfile, "SP_DB_GET_CUSTOMER_PROFILE_INFO")

        Return dsProfile

    End Function

    Public Function Authenticate_User(ByVal uid As String, ByVal pwd As String) As DataSet


        Dim adauth As New SqlDataAdapter
        Dim dsauth As New DataSet
        Dim sqlCmd As SqlCommand = New SqlCommand

        ' //Define Sql Command and Set Properties
        sqlCmd.Connection = CnXilieus
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "SP_DB_AUTH_USER"


        With sqlCmd.Parameters
            .AddWithValue("@loginId", uid).Direction = ParameterDirection.Input
            .AddWithValue("@pwd", pwd).Direction = ParameterDirection.Input
        End With

        'Define Sql Command and Set Properties
        adauth = New SqlDataAdapter(sqlCmd)
        adauth.Fill(dsauth, "SP_DB_AUTH_USER")

        Return dsauth
        dsauth.Clear()
        adauth.Dispose()


    End Function

End Class
