<%@ Page Title="" Language="VB" MasterPageFile="~/DB.master" AutoEventWireup="false" CodeFile="Deposit.aspx.vb" Inherits="Deposit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type = "text/javascript" >
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>

     <div class="container">
      <!-- Example row of columns -->
      <div class="row">
              <div class="col-sm-9 col-sm-offset-3 col-md-6 col-md-offset-2 main">
                <h3>Make a Deposit</h3>  
                 
                 <br />
                    <div id="msgblock" runat="server" visible="false">
                     
                        <div class="alert alert-success" role="alert" id="successalert" runat="server" visible="false"></div>
                        <br />
                         <div class="alert alert-danger" role="alert" id="erralert" runat="server" visible="false" ></div>
                        
                     </div>

                <div id="formblock" runat="server" visible="true">
                     <br />       

                  <br />
                        <label>Select An Account:</label>
                        <asp:DropDownList ID="ddlAccounts" runat="server" class="form-control" required="required"></asp:DropDownList>
                     <br />                    
                
                        <label>Amount:</label>
                        <input id="txtAmount" type="text" class="form-control" runat="server" required="required" maxlength="10">
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid number." ControlToValidate="txtAmount" ForeColor="Red" ValidationExpression="^[0-9]*$">Please enter a valid number</asp:RegularExpressionValidator>
                 

                  <br />
                        <label>Transaction Type:</label>
                        <asp:DropDownList ID="ddlTransType" runat="server" class="form-control" required="required">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Cash</asp:ListItem>
                            <asp:ListItem>Check</asp:ListItem>
                 </asp:DropDownList>
                     <br /> 
                 
                  <label>Check No.:</label>
                        <input id="txtCheckNum" type="text" class="form-control" runat="server" maxlength="10">
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please enter a valid number." ControlToValidate="txtCheckNum" ForeColor="Red" ValidationExpression="^[0-9]*$">Please enter a valid number</asp:RegularExpressionValidator>
                  <br />
                        
                         <label>Description (optional):</label>
                         <p class="help-block">50 characters max</p>
                         <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="5"  class="form-control" MaxLength="50"></asp:TextBox>
                            
                                    <br />

                      <label>Attach Image of Check</label>
                        <asp:FileUpload ID="MyFile" runat="server" class="form-control" /> 

                     <br />
                   <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-lg btn-success btn-block" />

               </div>

        </div>
       <!-- row -->
      </div>
 </div> <!-- /container -->
</asp:Content>

