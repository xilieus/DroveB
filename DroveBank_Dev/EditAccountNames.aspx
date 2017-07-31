<%@ Page Title="" Language="VB" MasterPageFile="~/DB.master" AutoEventWireup="false" CodeFile="EditAccountNames.aspx.vb" Inherits="EditAccountNames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type = "text/javascript" >
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>


      <div class="container-fluid">
      <div class="row">
        <div class="col-sm-3 col-md-2 sidebar">
          <ul class="nav nav-sidebar">
            <li class="<%Response.Write(Session("p-active"))%>"> <a href="Profile.aspx">My Profile <span class="sr-only">(current)</span></a></li>
                <li class="<%Response.Write(Session("n-active"))%>"><a href="EditAccountNames.aspx">Edit Account Names</a></li>
            <li class="<%Response.Write(Session("c-active"))%>"><a href="ChangePassword.aspx">Change Password</a></li>         
          </ul>         
        </div>

          </div>
    </div>



     <div class="container">
      <!-- Example row of columns -->
      <div class="row">
            <div class="col-sm-9 col-sm-offset-3 col-md-6 col-md-offset-2 main">
          <h2>Edit Account Name</h2>
          <h4>Edit the name for any of the accounts.</h4>
         <br />
                    <div id="msgblock" runat="server" visible="false">
                     
                        <div class="alert alert-success" role="alert" id="successalert" runat="server" visible="false"></div>
                        <br />
                         <div class="alert alert-danger" role="alert" id="erralert" runat="server" visible="false" ></div>
                        
                     </div>              

                  <br />
                  <div id="formblock" runat="server" visible="true">
                
                      <div class="table-responsive">
                      <asp:GridView ID="grdAccounts" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="table table-hover table-striped table-responsive" DataKeyNames="ACC_NUM,CID">
                          <Columns>
                              <asp:CommandField ShowSelectButton="True" />
                              <asp:BoundField DataField="ACC_NUM" HeaderText="ACC_NUM" ReadOnly="True" SortExpression="ACC_NUM" />
                              <asp:BoundField DataField="ACC_TYPE" HeaderText="ACC_TYPE" SortExpression="ACC_TYPE" />
                              <asp:BoundField DataField="ACC_NAME" HeaderText="ACC_NAME" SortExpression="ACC_NAME" />
                              <asp:BoundField DataField="CID" HeaderText="CID" ReadOnly="True" SortExpression="CID" Visible="False" />
                          </Columns>
                      </asp:GridView>
                    </div>
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:XilieusDB %>" SelectCommand="SP_DB_GET_CUSTOMER_ACCOUNT_INFO" UpdateCommand="SP_DB_UPDATE_CUSTOMER_ACCOUNT" UpdateCommandType="StoredProcedure" SelectCommandType="StoredProcedure">
                          <SelectParameters>
                              <asp:SessionParameter Name="CID" SessionField="CID" Type="Int32" />
                             
                          </SelectParameters>
                          <UpdateParameters>
                              <asp:Parameter Name="ACC_NUM" Type="String" />
                              <asp:Parameter Name="CID" Type="Int32" />
                              <asp:Parameter Name="ACC_NAME" Type="String" />
                          </UpdateParameters>
                      </asp:SqlDataSource>
                      <br />
                      
                    
                  <br />
                <label>Account Number:</label>
                <input id="txtaccnum" type="text" class="form-control" runat="server" required="required" readonly>
               
                  <br />

                        <br />
                <label>Account Name:</label>
                <input id="txtaccname" type="text" class="form-control" runat="server" required="required" maxlength="25">
               
                  <br />

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

