<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OpenAccount.aspx.vb" Inherits="OpenAccount" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="Drove Bank">
    <meta name="author" content="">
    <title>Drove Bank, LLC</title>

    <!-- Bootstrap core CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" />

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link href="Scripts/css/ie10-viewport-bug-workaround.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="Scripts/css/dashboard.css" rel="stylesheet" />
       <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    


</head>
<body>

     <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="Default.aspx">DroveBank, LLC</a>
        </div>

           <div id="navbar" class="navbar-collapse collapse">
          <ul class="nav navbar-nav navbar-right">
             <li><a href="Default.aspx">Sign In</a></li>
              <li><a href="OpenAccount.aspx">Open An Account</a></li>
           
          </ul>
          
        </div>
       
      </div>
    </nav>
      
      <div class="container"> 
          
            <!-- col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main |form-group col-sm-6 col-md-6 col-md-offset-1-->
      <div class="row">
             <div class="col-sm-9 col-sm-offset-3 col-md-6 col-md-offset-2 main">
          <h2>Open Your Account</h2>
          <h4>Fill the in formation below</h4>  
                 
                 
                  <br />
                    <div id="msgblock" runat="server" visible="false">
                     
                        <div class="alert alert-success" role="alert" id="successalert" runat="server" visible="false"></div>
                        <br />
                         <div class="alert alert-danger" role="alert" id="erralert" runat="server" visible="false" ></div>
                        
                     </div>

                 <br />
                                       
    
        <div id="formblock" runat="server" visible="true">

              <form id="form1" runat="server" class="form-signin">
        
               
        <br />
                <label>First Name:</label>
                <input id="txtfname" type="text" class="form-control" runat="server" required="required" maxlength="25">
               
                  <br />
                <label>Last Name:</label>
                <input id="txtlname" type="text" class="form-control" runat="server" required="required" maxlength="25">
                <br />

                <label>Email:</label> 
                    <input id="txtemail" type="text" class="form-control" runat="server" required="required">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="email address is invalid" ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                       
         
                       <br />

                  <br />
                        <label>Account Type:</label>
                        <asp:DropDownList ID="ddlAccType" runat="server" class="form-control" required="required">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Checking</asp:ListItem>
                            <asp:ListItem>Savings</asp:ListItem>
                 </asp:DropDownList>
                     <br /> 

               <p>By creating an account you agree to our <a href="#">Terms & Privacy</a>.
         <br />   <br />
                   <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-lg btn-success btn-block" />
                  <br />
      
              </form>
             </div>
      </div>
       <!-- row -->
      </div>
 </div> <!-- /container -->
   

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
   <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    
 
    
</body>
</html>

