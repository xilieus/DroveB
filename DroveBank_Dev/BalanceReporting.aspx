<%@ Page Title="" Language="VB" MasterPageFile="~/DB.master" AutoEventWireup="false" CodeFile="BalanceReporting.aspx.vb" Inherits="BalanceReporting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type = "text/javascript" >
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>
    <div class="container">
      <!-- Example row of columns -->
      <div class="row">
          <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
         
          <h2>Transactions</h2>
          <h4>Account Transactions For <%Response.Write(Session("CUSNAME") & " - #" & Request.QueryString("AccId"))%></h4>
          
           <br />
               <div class="table-responsive">
              <asp:GridView ID="grdTransactions" runat="server" AutoGenerateColumns="False" DataKeyNames="TRANS_ID" DataSourceID="sqldsTrans" CssClass="table table-hover table-striped table-responsive" AllowSorting="True">
                  <Columns>
                      <asp:BoundField DataField="TRANS_DATE" HeaderText="TRANS DATE" SortExpression="TRANS_DATE" DataFormatString="{0:d}" />
                      <asp:BoundField DataField="TRANS_TYPE" HeaderText="TRANS TYPE" SortExpression="TRANS_TYPE" />
                      <asp:BoundField DataField="CHECK_NO" HeaderText="CHECK NO." SortExpression="CHECK_NO" />
                      <asp:BoundField DataField="DEPOSIT" HeaderText="DEPOSIT" SortExpression="DEPOSIT" DataFormatString="{0:c}" />
                      <asp:BoundField DataField="WITHDRAW" HeaderText="WITHDRAW" SortExpression="WITHDRAW" DataFormatString="{0:c}" />
                      <asp:BoundField DataField="BALANCE" HeaderText="BALANCE" SortExpression="BALANCE" DataFormatString="{0:c}" ReadOnly="True" />
                      <asp:BoundField DataField="TRANS_ID" HeaderText="TRANS_ID" ReadOnly="True" SortExpression="TRANS_ID" InsertVisible="False" Visible="False" />
                      <asp:BoundField DataField="ACC_NUM" HeaderText="ACC_NUM" SortExpression="ACC_NUM" Visible="False" />
                  </Columns>
              </asp:GridView>
               </div>
              <br />
                <a href="Accounts.aspx" class="btn-link">Return to accounts summary</a>
          <br />
              
          <asp:SqlDataSource ID="sqldsTrans" runat="server" ConnectionString="Data Source=wormwood.arvixe.com;Initial Catalog=xilieusdb;User ID=xdbu;Password=!Skb869$" ProviderName="System.Data.SqlClient" SelectCommand="SP_DB_CUSTOMER_ACCOUNT_TRANSACTIONS_DETAILS" SelectCommandType="StoredProcedure">
              <SelectParameters>
                  <asp:SessionParameter Name="CID" SessionField="CID" Type="Int32" />
                  <asp:QueryStringParameter Name="ACC_NUM" QueryStringField="AccId" Type="String" />
              </SelectParameters>
              </asp:SqlDataSource>



              </div>
       <!-- row -->
      </div>
 </div> <!-- /container -->




</asp:Content>

