<%@ Page Title="" Language="VB" MasterPageFile="~/DB.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container-fluid">
      <div class="row">
        <div class="col-sm-3 col-md-2 sidebar">
          <ul class="nav nav-sidebar">
            <li class="<%Response.Write(Session("p-active"))%>"> <a href="Profile.aspx">My Profile <span class="sr-only">(current)</span></a></li>
                <li class="<%Response.Write(Session("n-active"))%>"><a href="EditAccountNames.aspx">Set Account Names</a></li>
            <li class="<%Response.Write(Session("c-active"))%>"><a href="ChangePassword.aspx">Change Password</a></li>         
          </ul>
         
        </div>

          </div>
    </div>


    
     <div class="container">
      <!-- Example row of columns -->
      <div class="row">
            <div class="col-sm-9 col-sm-offset-3 col-md-6 col-md-offset-2 main">
          <h2>Change Pasword</h2>
          <h4>Update your password.</h4>
         <br />
                    <div id="msgblock" runat="server" visible="false">
                     
                        <div class="alert alert-success" role="alert" id="successalert" runat="server" visible="false"></div>
                        <br />
                         <div class="alert alert-danger" role="alert" id="erralert" runat="server" visible="false" ></div>
                        
                     </div>              

                  <br />
                  <div id="formblock" runat="server" visible="true">
                    
                  <br />
                <label>New password:</label>
                <input id="txtPasswordNew" type="text" class="form-control" runat="server" required="required" maxlength="12">
               
                  <br />

                        <br />
                <label>Repeat new password:</label>
                <input id="txtPasswordNewConfirm" type="text" class="form-control" runat="server" required="required" maxlength="12">
               
                  <br />

                         <br />
                   <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-lg btn-success btn-block" />
                  <br />


                        <br />

        <asp:RegularExpressionValidator 
        ID="RegularExpressionValidator1" 
        runat ="server" 
        ErrorMessage="Password must be 8-12 characters long, Must contain at least one number, Must contain at least one upper case letter, Must contain at least one special character." 
        Display="Dynamic"
        ValidationExpression="(?=^.{8,12}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$" 
        ControlToValidate="txtPasswordNew" ForeColor="Red"></asp:RegularExpressionValidator>
        <br /><br />
        <asp:CompareValidator ID="CompareValidator1" 
            runat="server" 
            ErrorMessage="Passwords does not match" 
            ControlToValidate="txtPasswordNewConfirm" 
            ControlToCompare="txtPasswordNew" ForeColor="Red"></asp:CompareValidator>

                       <!-- /formblock -->
                </div>


        </div>
       <!-- row -->
      </div>
 </div> <!-- /container -->



     <script type = "text/javascript" >
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>



</asp:Content>

