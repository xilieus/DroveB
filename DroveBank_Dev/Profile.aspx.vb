'//====================================================================================================
'// Programmer: Claude Lake
'// Created: 7/27/2017
'// Description: Page to update profile
'//====================================================================================================
Imports System.Data
Imports System.Data.SqlClient
Partial Class Profile
    Inherits System.Web.UI.Page
    ReadOnly myCon As New Controller

    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles Me.Load

        '// checks for an empty session
        If CStr(Session("CID")) = Nothing Then
            Response.Redirect("Default.aspx")
            Exit Sub
        End If

        If Not Page.IsPostBack Then

            Session("p-active") = "active"
            Session("c-active") = Nothing
            Session("n-active") = Nothing
            Bind_States()
            Load_Customer_Profile_Info()
        End If

    End Sub
    Private Sub Bind_States()
        '// Bind States drown down list from array
        ddlState.DataSource = myCon.ArrStates
        ddlState.DataBind()
    End Sub

    Private Sub Load_Customer_Profile_Info()

        Try


            Dim dsCusProfile As New DataSet
            Dim drCus As DataRow

            '//Set dataset from class
            dsCusProfile.Clear()
            dsCusProfile = myCon.Get_Customer_Profile(Session("CID"))


            For Each drCus In dsCusProfile.Tables(0).Rows

                If Not IsDBNull(drCus("First_Name")) Then
                    txtfname.Value = Trim(CType(drCus("First_Name"), String)).ToString
                Else
                    txtfname.Value = Nothing
                End If

                If Not IsDBNull(drCus("Last_Name")) Then
                    txtlname.Value = Trim(CType(drCus("Last_Name"), String)).ToString()
                Else
                    txtlname.Value = Nothing
                End If

                If Not IsDBNull(drCus("Middle_Name")) Then
                    txtmname.Value = Trim(CType(drCus("Middle_Name"), String)).ToString()
                Else
                    txtmname.Value = Nothing
                End If

                If Not IsDBNull(drCus("Address")) Then
                    txtaddress.Value = Trim(CType(drCus("Address"), String)).ToString()
                Else
                    txtaddress.Value = Nothing
                End If

                If Not IsDBNull(drCus("City")) Then
                    txtcity.Value = Trim(CType(drCus("City"), String)).ToString()
                Else
                    txtcity.Value = Nothing
                End If

                If Not IsDBNull(drCus("State")) Then
                    ddlState.Text = Trim(CType(drCus("State"), String)).ToString()
                Else
                    ddlState.Text = Nothing
                End If

                If Not IsDBNull(drCus("ZipCode")) Then
                    txtzip.Value = Trim(CType(drCus("ZipCode"), String)).ToString()
                Else
                    txtzip.Value = Nothing
                End If

                If Not IsDBNull(drCus("Phone")) Then
                    txtphone.Value = Trim(CType(drCus("Phone"), String)).ToString()
                Else
                    txtphone.Value = Nothing
                End If

                If Not IsDBNull(drCus("Email")) Then
                    txtemail.Value = Trim(CType(drCus("Email"), String)).ToString()
                Else
                    txtemail.Value = Nothing
                End If


            Next
            dsCusProfile.Clear()

        Catch ex As Exception
            formblock.Visible = False
        msgblock.Visible = True
        erralert.Visible = True
        erralert.InnerHtml = ex.ToString()
        End Try


    End Sub


    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Try

            If myCon.CnXilieus.State = ConnectionState.Closed Then myCon.CnXilieus.Open()

            Dim SqlCmd As New SqlCommand

            'Set Properties of the Command
            SqlCmd.Connection = myCon.CnXilieus
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "SP_DB_UPDATE_CUSTOMER_PROFILE"

            With SqlCmd.Parameters

                .AddWithValue("@CID", CInt(Session("CID"))).Direction = ParameterDirection.Input
                .AddWithValue("@First_Name", Trim(txtfname.Value).ToString()).Direction = ParameterDirection.Input
                .AddWithValue("@Last_Name", Trim(txtlname.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@Middle_Name", Trim(txtmname.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@Address", Trim(txtaddress.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@City", Trim(txtcity.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@State", Trim(ddlState.Text)).Direction = ParameterDirection.Input
                .AddWithValue("@ZipCode", Trim(txtzip.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@Phone", Trim(txtphone.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@Email", Trim(txtemail.Value)).Direction = ParameterDirection.Input
                .AddWithValue("@LAST_MODIFIED_DATE", Now.ToShortDateString.ToString()).Direction = ParameterDirection.Input


                'Execuate Command
                SqlCmd.ExecuteNonQuery()
                'release all resources
                SqlCmd.Parameters.Clear()
                SqlCmd.Dispose()

            End With

            msgblock.Visible = True
            successalert.Visible = True
            successalert.InnerHtml = "Porfile updated!"

        Catch ex As Exception
            formblock.Visible = False
            msgblock.Visible = True
            erralert.Visible = True
            erralert.InnerHtml = ex.ToString()
        End Try
    End Sub

End Class
