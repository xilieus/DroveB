<%@ Page Title="" Language="VB" MasterPageFile="~/DB.master" AutoEventWireup="false" CodeFile="Profile.aspx.vb" Inherits="Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type = "text/javascript" >
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>

      <div class="col-sm-3 col-md-2 sidebar">
          <ul class="nav nav-sidebar">
            <li class="<%Response.Write(Session("p-active"))%>"> <a href="Profile.aspx">My Profile <span class="sr-only">(current)</span></a></li>
                <li class="<%Response.Write(Session("n-active"))%>"><a href=" EditAccountNames.aspx">Edit Account Names</a></li>
            <li class="<%Response.Write(Session("c-active"))%>"><a href="ChangePassword.aspx">Change Password</a></li>         
          </ul>         
        </div>
    

 
     <div class="container">
      <!-- Example row of columns -->
      <div class="row">
            <div class="form-group col-sm-6 col-md-6 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <h2>Profile Information</h2>
          <h4>Update your profile information.</h4>
         <br />
                    <div id="msgblock" runat="server" visible="false">
                     
                        <div class="alert alert-success" role="alert" id="successalert" runat="server" visible="false"></div>
                        <br />
                         <div class="alert alert-danger" role="alert" id="erralert" runat="server" visible="false" ></div>
                        
                     </div>              

                  <br />
                  <div id="formblock" runat="server" visible="true">
                  <br />
                <label>First Name:</label>
                <input id="txtfname" type="text" class="form-control" runat="server" required="required" maxlength="25">
               
                  <br />
                <label>Last Name:</label>
                <input id="txtlname" type="text" class="form-control" runat="server" required="required" maxlength="25">
                <br />

                 <br />
                <label>Middle Name:</label>
                <input id="txtmname" type="text" class="form-control" runat="server" maxlength="25">
                <br />

                  <br />
                <label>Address:</label>
                <input id="txtaddress" type="text" class="form-control" runat="server" required="required" maxlength="75">
                <br />

                   <br />
                <label>City:</label>
                <input id="txtcity" type="text" class="form-control" runat="server" required="required" maxlength="50">
                <br />

                   <br />
                <label>State:</label>
                <asp:DropDownList ID="ddlState" class="controls" runat="server" required="required" ></asp:DropDownList>
                <br />

                 <br />
                <label>Zipcode:</label>
                <input id="txtzip" type="text" class="form-control" runat="server" required="required" maxlength="5">
                <br />

                <label>Email (username):</label> 
                    <input id="txtemail" type="text" class="form-control" runat="server" required="required">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="email address is invalid" ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                <br />
                <label>Phone:</label>
                <input id="txtphone" type="text" class="form-control" runat="server" required="required">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="phone number is invalid" ControlToValidate="txtphone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ForeColor="Red"></asp:RegularExpressionValidator>              
         
                       <br />
                   <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-lg btn-success btn-block" />
                  <br />
                       <!-- /formblock -->
                </div>


        </div>
       <!-- row -->
      </div>
 </div> <!-- /container -->




</asp:Content>

