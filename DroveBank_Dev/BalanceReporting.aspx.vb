
Partial Class BalanceReporting
    Inherits System.Web.UI.Page

    Private Sub BalanceReporting_Load(sender As Object, e As EventArgs) Handles Me.Load


        '// checks for an empty session
        If CStr(Session("CID")) = Nothing Then
            Response.Redirect("Default.aspx")
            Exit Sub
        End If

        '// checks for an empty accid query value
        If Not Page.IsPostBack Then
            If Request.QueryString("AccId") = Nothing Then
                Response.Redirect("Default.aspx")
            End If
        End If

    End Sub
End Class
