<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>DPC Packaging Pte Ltd  | Log in</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="plugins/iCheck/square/blue.css">

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <div class="login-logo">
    <a href="index2.html"><b>DPC</b>Packaging</a>
  </div>
  <!-- /.login-logo -->
 <div class="login-box-body">
    <p class="login-box-msg">Sign in</p>

    <form runat="server">
                           
                               <div class="form-group has-feedback">
                                   
                                    <asp:TextBox placeholder="Username" CssClass="form-control"  ID="UserName" runat="server"></asp:TextBox>
                                   <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                </div>

                                 <div class="form-group has-feedback">
                                   
                                    <asp:TextBox placeholder="Password" CssClass="form-control"  ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                     <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1"></asp:RequiredFieldValidator>

                                 </div>
                              
                            <div class="row">
                              <div class="col-xs-8">
                                  <label>
                             
                                   <asp:CheckBox CssClass="icheckbox_square-blue" ID="RememberMe" runat="server" />  
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                       Remember Me
                             </label>
                        </div>
                               
             <div class="col-xs-4">
                 <asp:Button  ID="LoginButton" CssClass="btn btn-primary btn-block btn-flat" runat="server"  Text="Log In" ValidationGroup="Login1" OnClick="loginBtn_Click" />
             </div>
                  </div>
                 </form>

  </div>
  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->

<!-- jQuery 2.2.0 -->
<script src="plugins/jQuery/jQuery-2.2.0.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="bootstrap/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src="plugins/iCheck/icheck.min.js"></script>
<script>
  $(function () {
    $('input').iCheck({
      checkboxClass: 'icheckbox_square-blue',
      radioClass: 'iradio_square-blue',
      increaseArea: '20%' // optional
    });
  });
</script>
</body>
</html>
