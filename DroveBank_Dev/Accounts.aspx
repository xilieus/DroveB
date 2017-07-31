<%@ Page Title="" Language="VB" MasterPageFile="~/DB.master" AutoEventWireup="false" CodeFile="Accounts.aspx.vb" Inherits="Accounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div class="container">
      <!-- Example row of columns -->
      <div class="row">
             <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <h2>Summary</h2>
          <h4>Account Summary for <%Response.Write(Session("CUSNAME")) %></h4>
         
              
                
                 
         <div class="table-responsive">
          <asp:Table ID="tblAccounts" runat="server" CssClass="table table-hover table-striped table-responsive"></asp:Table>
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

