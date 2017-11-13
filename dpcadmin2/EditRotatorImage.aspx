﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRotatorImage.aspx.cs" Inherits="EditRotatorImage" %>

<!DOCTYPE html>
<!--
This is a starter template page. Use this page to start your new project from
scratch. This page gets rid of all links and provides the needed markup only.
-->
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>DPC Packaging Pte Ltd  | Intranet</title>
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
  <!-- AdminLTE Skins. We have chosen the skin-blue for this starter
        page. However, you can choose any other skin. Make sure you
        apply the skin class to the body tag so the changes take effect.
  -->
  <link rel="stylesheet" href="dist/css/skins/skin-blue.min.css">

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<!--
BODY TAG OPTIONS:
=================
Apply one or more of the following classes to get the
desired effect
|---------------------------------------------------------|
| SKINS         | skin-blue                               |
|               | skin-black                              |
|               | skin-purple                             |
|               | skin-yellow                             |
|               | skin-red                                |
|               | skin-green                              |
|---------------------------------------------------------|
|LAYOUT OPTIONS | fixed                                   |
|               | layout-boxed                            |
|               | layout-top-nav                          |
|               | sidebar-collapse                        |
|               | sidebar-mini                            |
|---------------------------------------------------------|
-->
<body class="hold-transition skin-blue sidebar-mini">
    <form id="form1" runat="server">
<div class="wrapper">

  <!-- Main Header -->
  <header class="main-header">

    <!-- Logo -->
    <a href="default.aspx" class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini"><b>DPC</b></span>
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg"><b>Design</b>Packaging</span>
    </a>

    <!-- Header Navbar -->
    <nav class="navbar navbar-static-top" role="navigation">
      <!-- Sidebar toggle button-->
      <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
        <span class="sr-only">Toggle navigation</span>
      </a>
      <!-- Navbar Right Menu -->
      <div class="navbar-custom-menu">
        <ul class="nav navbar-nav">
          <!-- Messages: style can be found in dropdown.less-->
          <li class="dropdown messages-menu">
            <!-- Menu toggle button -->
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <i class="fa fa-envelope-o"></i>
              <span class="label label-success">4</span>
            </a>
            <ul class="dropdown-menu">
              <li class="header">You have 4 messages</li>
              <li>
                <!-- inner menu: contains the messages -->
                <ul class="menu">
                  <li><!-- start message -->
                    <a href="#">
                      <div class="pull-left">
                        <!-- User Image -->
                        <img src="dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">
                      </div>
                      <!-- Message title and timestamp -->
                      <h4>
                        Support Team
                        <small><i class="fa fa-clock-o"></i> 5 mins</small>
                      </h4>
                      <!-- The message -->
                      <p>Why not buy a new awesome theme?</p>
                    </a>
                  </li>
                  <!-- end message -->
                </ul>
                <!-- /.menu -->
              </li>
              <li class="footer"><a href="#">See All Messages</a></li>
            </ul>
          </li>
          <!-- /.messages-menu -->

          <!-- Notifications Menu -->
          <li class="dropdown notifications-menu">
            <!-- Menu toggle button -->
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <i class="fa fa-bell-o"></i>
              <span class="label label-warning">10</span>
            </a>
            <ul class="dropdown-menu">
              <li class="header">You have 10 notifications</li>
              <li>
                <!-- Inner Menu: contains the notifications -->
                <ul class="menu">
                  <li><!-- start notification -->
                    <a href="#">
                      <i class="fa fa-users text-aqua"></i> 5 new members joined today
                    </a>
                  </li>
                  <!-- end notification -->
                </ul>
              </li>
              <li class="footer"><a href="#">View all</a></li>
            </ul>
          </li>
          <!-- Tasks Menu -->
          <li class="dropdown tasks-menu">
            <!-- Menu Toggle Button -->
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <i class="fa fa-flag-o"></i>
              <span class="label label-danger">9</span>
            </a>
            <ul class="dropdown-menu">
              <li class="header">You have 9 tasks</li>
              <li>
                <!-- Inner menu: contains the tasks -->
                <ul class="menu">
                  <li><!-- Task item -->
                    <a href="#">
                      <!-- Task title and progress text -->
                      <h3>
                        Design some buttons
                        <small class="pull-right">20%</small>
                      </h3>
                      <!-- The progress bar -->
                      <div class="progress xs">
                        <!-- Change the css width attribute to simulate progress -->
                        <div class="progress-bar progress-bar-aqua" style="width: 20%" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                          <span class="sr-only">20% Complete</span>
                        </div>
                      </div>
                    </a>
                  </li>
                  <!-- end task item -->
                </ul>
              </li>
              <li class="footer">
                <a href="#">View all tasks</a>
              </li>
            </ul>
          </li>
          <!-- User Account Menu -->
          <li class="dropdown user user-menu">
            <!-- Menu Toggle Button -->
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <!-- The user image in the navbar-->
              <img src="dist/img/user2-160x160.jpg" class="user-image" alt="User Image">
              <!-- hidden-xs hides the username on small devices so only the image appears. -->
              <span class="hidden-xs">Richard</span>
            </a>
            <ul class="dropdown-menu">
              <!-- The user image in the menu -->
              <li class="user-header">
                <img src="dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">

                <p>
                  Richard - CEO
                  <small>Super Admin</small>
                </p>
              </li>
              <!-- Menu Body -->
              <li class="user-body">
                <div class="row">
                  <div class="col-xs-4 text-center">
                    <a href="#">Followers</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href="#">Sales</a>
                  </div>
                  <div class="col-xs-4 text-center">
                    <a href="#">Friends</a>
                  </div>
                </div>
                <!-- /.row -->
              </li>
              <!-- Menu Footer-->
              <li class="user-footer">
                <div class="pull-left">
                  <a href="#" class="btn btn-default btn-flat">Profile</a>
                </div>
                <div class="pull-right">
                  <a href="#" class="btn btn-default btn-flat">Sign out</a>
                </div>
              </li>
            </ul>
          </li>
          <!-- Control Sidebar Toggle Button -->
          <li>
            <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
          </li>
        </ul>
      </div>
    </nav>
  </header>
  <!-- Left side column. contains the logo and sidebar -->
  <aside class="main-sidebar">

    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">

      <!-- Sidebar user panel (optional) -->
      <div class="user-panel">
        <div class="pull-left image">
          <img src="dist/img/user2-160x160.jpg" class="img-circle" alt="User Image">
        </div>
        <div class="pull-left info">
          <p>Richard</p>
          <!-- Status -->
          <a href="#"><i class="fa fa-circle text-success"></i> Online</a>
        </div>
      </div>

      <!-- search form (Optional) -->
        <div class="input-group">
          <input type="text" name="q" class="form-control" placeholder="Search...">
              <span class="input-group-btn">
                <button type="submit" name="search" id="search-btn" class="btn btn-flat"><i class="fa fa-search"></i>
                </button>
              </span>
        </div>
      <!-- /.search form -->

      <!-- Sidebar Menu -->
     <ul class="sidebar-menu">
        <li class="header">HEADER</li>
        <!-- Optionally, you can add icons to the links -->
        <li><a href="Default.aspx"><i class="fa fa-link"></i> <span>Dashboard</span></a></li>       
        <li class="treeview active">
          <a href="#"><i class="fa fa-link"></i> <span>Products</span> <i class="fa fa-angle-left pull-right"></i></a>
          <ul class="treeview-menu">
             <li><a href="ManageProducts.aspx">Manage Products</a></li> 
          </ul>
        </li>
         <li class="treeview">
          <a href="#"><i class="fa fa-link"></i> <span>Awards</span> <i class="fa fa-angle-left pull-right"></i></a>
          <ul class="treeview-menu">
            <li><a href="ManageAwards.aspx">Manage Awards</a></li>           
          </ul>
        </li>
          <li class="treeview">
          <a href="#"><i class="fa fa-link"></i> <span>Rotator Images</span> <i class="fa fa-angle-left pull-right"></i></a>
          <ul class="treeview-menu">
            <li><a href="UploadRotator.aspx">Upload Rotator Items</a></li>
            <li class="active"><a href="EditRotator.aspx">Edit Rotator Details</a></li>
          </ul>
        </li>
         <li class="treeview ">
          <a href="#"><i class="fa fa-link"></i> <span>Rotator Packages</span> <i class="fa fa-angle-left pull-right"></i></a>
          <ul class="treeview-menu">
            <li><a href="CreateRotatorPackage.aspx">Create Rotator Package</a></li>
            <li><a href="EditRotatorPackage.aspx">Edit Rotator Package</a></li>
          </ul>
        </li>
           <li class="treeview">
          <a href="#"><i class="fa fa-cog"></i> <span>Settings</span> <i class="fa fa-angle-left pull-right"></i></a>
          <ul class="treeview-menu">
            <li><a href="ManageAdminAccounts.aspx">Manage Admin Accounts</a></li>
          </ul>
        </li>
      </ul>
      <!-- /.sidebar-menu -->
    </section>
    <!-- /.sidebar -->
  </aside>

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
       Edit Rotator Image

      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Level</a></li>
        <li class="active">Here</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        
        <div class="row">
        <div class="col-md-12">
          <!-- general form elements -->
          <div class="box box-primary">
          <div class="box-header with-border">
              <h3 class="box-title">Edit Rotator Image Details</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            
              <div class="box-body">

               <div class="col-md-12">
            <div class="box-body">
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="rmID" DataSourceID="SqlDataSource1" ShowHeader="True" class="responsive display table table-striped table-bordered table-hover dataTable no-footer">

                                   <Columns>
                                       
                        <asp:TemplateField HeaderText="Image 1" HeaderStyle-HorizontalAlign="Center">
                         <ItemTemplate>
             
                              <asp:Image ID="Image1" runat="server" Height="122px" ImageUrl='<%# Eval("rmImage1")%>' Width="148px" />
                         
                              </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="16%" />
                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Image 2" HeaderStyle-HorizontalAlign="Center">
                         <ItemTemplate>
             
                              <asp:Image ID="Image2" runat="server" Height="122px" ImageUrl='<%# Eval("rmImage2")%>' Width="148px" />
                         
                              </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="16%" />
                      </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Image 3" HeaderStyle-HorizontalAlign="Center">
                         <ItemTemplate>
             
                              <asp:Image ID="Image3" runat="server" Height="122px" ImageUrl='<%#  Eval("rmImage3")%>' Width="148px" />
                         
                              </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="16%" />
                      </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Image 4" HeaderStyle-HorizontalAlign="Center">
                         <ItemTemplate>
             
                              <asp:Image ID="Image4" runat="server" Height="122px" ImageUrl='<%# Eval("rmImage4")%>' Width="148px" />
                         
                              </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="16%" />
                      </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Image 5" HeaderStyle-HorizontalAlign="Center">
                         <ItemTemplate>
             
                              <asp:Image ID="Image5" runat="server" Height="122px" ImageUrl='<%# Eval("rmImage5")%>' Width="148px" />
                         
                              </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="16%" />
                      </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Image 6" HeaderStyle-HorizontalAlign="Center">
                         <ItemTemplate>
             
                              <asp:Image ID="Image6" runat="server" Height="122px" ImageUrl='<%# Eval("rmImage6")%>' Width="148px" />
                         
                              </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="16%" />
                      </asp:TemplateField>

                                   </Columns>
                               </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DesignPackagingConceptConnectionString %>" SelectCommand="SELECT * FROM [dpcrImages] WHERE ([rmID] = @rotatorID)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="rotatorID" QueryStringField="rotatorID" />
                </SelectParameters>
            </asp:SqlDataSource>
          </div>
           
        </div>      
                  <div class="col-md-4" style="text-align: -webkit-center;">
                       <img alt="" src="" id="product3" style="height: 300px; width: 300px"/>
                   <asp:DataList ID="Datalist1" runat="server" Font-Bold="False" 
                    DataSourceID="SqlDataSource2" style="text-align: center; display:none" >
                    <ItemTemplate>
                        <div id="dvImages" style="display: none; height:300px; width:300px">
                            <img style="height: 300px; width: 300px" alt="" src='<%# Eval("rmImage1") %>' />
                            <img style="height: 300px; width: 300px" alt="" src='<%# Eval("rmImage2") %>' />
                            <img style="height: 300px; width: 300px" alt="" src='<%# Eval("rmImage3") %>' />
                            <img style="height: 300px; width: 300px" alt="" src='<%# Eval("rmImage4") %>' />
                            <img style="height: 300px; width: 300px" alt="" src='<%# Eval("rmImage5") %>' />
                            <img style="height: 300px; width: 300px" alt="" src='<%# Eval("rmImage6") %>' />
						</div>
											</ItemTemplate>
                                            </asp:DataList>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DesignPackagingConceptConnectionString %>" 
                    SelectCommand="SELECT [rmImage1], [rmImage2], [rmImage3], [rmImage4], [rmImage5], [rmImage6] FROM [dpcrImages] WHERE ([rmID] = @rmID)">
                                                <SelectParameters>
                                                    <asp:QueryStringParameter Name="rmID" QueryStringField="rotatorID" Type="String" />
                                                </SelectParameters>
                </asp:SqlDataSource>
                  </div>        
               <div class="col-md-4">
                <div class="form-group">
                  <label for="inputname">Item Name</label>
                  <asp:TextBox ID="itemname" placeholder="Item Name" type="text" runat="server" class="form-control"></asp:TextBox>                  
                </div>                
                <div class="form-group">
                  <label>Item Category</label>
                  <asp:DropDownList ID="itemcat" runat="server" class="form-control">
                      <asp:ListItem Text="Please Choose an Item Category" Value="Please Choose and Item Category" />
                       <asp:ListItem Text="CNY Packaging" Value="CNY Packaging" />
                       <asp:ListItem Text="Chocolates and Cakes Packaging" Value="Chocolates and Cakes Packaging" />
                      <asp:ListItem Text="Calenders" Value="Calenders" />
                      <asp:ListItem Text="Mooncake Packaging" Value="Mooncake Packaging" />
                      <asp:ListItem Text="Menus" Value="Menus" />
                      <asp:ListItem Text="Retail and Corporate" Value="Retail and Corporate" />
                      <asp:ListItem Text="Wine Packaging" Value="Wine Packaging" />
                      <asp:ListItem Text="Christmas Packaging" Value="Christmas Packaging" />
                  </asp:DropDownList>
                </div>
                   <div class="form-group">
                  <label>Item Satus</label>
                   <asp:DropDownList ID="itemstatus" runat="server" class="form-control">
                       <asp:ListItem Text="Please Choose and Item Status" Value="Please Choose and Item Status" />
                       <asp:ListItem Text="Draft" Value="Draft" />
                       <asp:ListItem Text="Published" Value="Published" />
                  </asp:DropDownList>
                </div>
                </div>
               <div class="col-md-4">
                <div class="form-group">
                  <label>Item Description</label>
                  <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" class="form-control" placeholder="Please Enter Item Description"></asp:TextBox>
                  
                </div>
                <div class="form-group">
                  <label>Item Notes</label>
                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" class="form-control" placeholder="Please Enter Item Notes"></asp:TextBox>
                 
                </div>
                
                
                </div>
              </div>
              <!-- /.box-body -->

              <div class="box-footer" style="text-align: -webkit-right;">
                  <asp:Button ID="btnSubmit" runat="server" Text="Edit Product Details" type="submit"  OnClick="updateDetailsBtn_Click" class="btn btn-primary"/>
                
              </div>
            
          </div>
            <div class="box box-primary">
                 <div class="box-body">
                <div class="box-header with-border">
              <h3 class="box-title">Edit Rotator Images</h3>
            </div>
                <div class="form-group">
                  <label for="exampleInputFile">Item Picture 1</label>
                  <asp:FileUpload ID="FileUpload1" runat="server" type="file"/>
                    <asp:HiddenField ID="im1" runat="server" />
                  <p class="help-block">Please upload only PNG/JPG files</p>
                </div>
                     <div class="form-group">
                  <label for="exampleInputFile">Item Picture 2</label>
                  <asp:FileUpload ID="FileUpload2" runat="server" type="file"/>
                     <asp:HiddenField ID="im2" runat="server" />
                  <p class="help-block">Please upload only PNG/JPG files</p>
                </div>
                     <div class="form-group">
                  <label for="exampleInputFile">Item Picture 3 </label>
                  <asp:FileUpload ID="FileUpload3" runat="server" type="file"/>
                    <asp:HiddenField ID="im3" runat="server" />
                  <p class="help-block">Please upload only PNG/JPG files</p>
                </div>
                     <div class="form-group">
                  <label for="exampleInputFile">Item Picture 4</label>
                  <asp:FileUpload ID="FileUpload4" runat="server" type="file"/>
                         <asp:HiddenField ID="im4" runat="server" />
                  <p class="help-block">Please upload only PNG/JPG files</p>
                </div>
                     <div class="form-group">
                  <label for="exampleInputFile">Item Picture 5</label>
                  <asp:FileUpload ID="FileUpload5" runat="server" type="file"/>
                         <asp:HiddenField ID="im5" runat="server" />
                  <p class="help-block">Please upload only PNG/JPG files</p>
                </div>
                     <div class="form-group">
                  <label for="exampleInputFile">Item Picture 6</label>
                  <asp:FileUpload ID="FileUpload6" runat="server" type="file"/>
                         <asp:HiddenField ID="im6" runat="server" />
                  <p class="help-block">Please upload only PNG/JPG files</p>
                </div>
                 <div class="box-footer">
                  <asp:Button ID="btnImageSubmit" runat="server" Text="Edit Product Image" type="submit" OnClick="updatePic_Click" class="btn btn-primary"/>
                </div>
              </div>
             </div>
          <!-- /.box -->


        </div>
        </div>

      <!-- Your Page Content Here -->

    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->

  <!-- Main Footer -->
  <footer class="main-footer">
    <!-- To the right -->
    <div class="pull-right hidden-xs">
      Anything you want
    </div>
    <!-- Default to the left -->
    <strong>Copyright &copy; 2016 <a href="#">Design Packaging Concept</a>.</strong> All rights reserved.
  </footer>

  <!-- Control Sidebar -->
  <aside class="control-sidebar control-sidebar-dark">
    <!-- Create the tabs -->
    <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
      <li class="active"><a href="#control-sidebar-home-tab" data-toggle="tab"><i class="fa fa-home"></i></a></li>
      <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i class="fa fa-gears"></i></a></li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
      <!-- Home tab content -->
      <div class="tab-pane active" id="control-sidebar-home-tab">
        <h3 class="control-sidebar-heading">Recent Activity</h3>
        <ul class="control-sidebar-menu">
          <li>
            <a href="javascript::;">
              <i class="menu-icon fa fa-birthday-cake bg-red"></i>

              <div class="menu-info">
                <h4 class="control-sidebar-subheading">Langdon's Birthday</h4>

                <p>Will be 23 on April 24th</p>
              </div>
            </a>
          </li>
        </ul>
        <!-- /.control-sidebar-menu -->

        <h3 class="control-sidebar-heading">Tasks Progress</h3>
        <ul class="control-sidebar-menu">
          <li>
            <a href="javascript::;">
              <h4 class="control-sidebar-subheading">
                Custom Template Design
                <span class="label label-danger pull-right">70%</span>
              </h4>

              <div class="progress progress-xxs">
                <div class="progress-bar progress-bar-danger" style="width: 70%"></div>
              </div>
            </a>
          </li>
        </ul>
        <!-- /.control-sidebar-menu -->

      </div>
      <!-- /.tab-pane -->
      <!-- Stats tab content -->
      <div class="tab-pane" id="control-sidebar-stats-tab">Stats Tab Content</div>
      <!-- /.tab-pane -->
      <!-- Settings tab content -->
      <div class="tab-pane" id="control-sidebar-settings-tab">
          <h3 class="control-sidebar-heading">General Settings</h3>

          <div class="form-group">
            <label class="control-sidebar-subheading">
              Report panel usage
              <input type="checkbox" class="pull-right" checked>
            </label>

            <p>
              Some information about this general settings option
            </p>
          </div>
          <!-- /.form-group -->
      </div>
      <!-- /.tab-pane -->
    </div>
  </aside>
  <!-- /.control-sidebar -->
  <!-- Add the sidebar's background. This div must be placed
       immediately after the control sidebar -->
  <div class="control-sidebar-bg"></div>
</div>
<!-- ./wrapper -->

<!-- REQUIRED JS SCRIPTS -->

<!-- jQuery 2.2.0 -->
<script src="plugins/jQuery/jQuery-2.2.0.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="bootstrap/js/bootstrap.min.js"></script>
<!-- AdminLTE App -->
<script src="dist/js/app.min.js"></script>
    
    <script type="text/javascript" src="http://cdn.rawgit.com/matdumsa/jQuery.threesixty/master/jquery.threesixty.js"></script>
<!-- Optionally, you can add Slimscroll and FastClick plugins.
     Both of these plugins are recommended to enhance the
     user experience. Slimscroll is required when using the
     fixed layout. -->
         <script type="text/javascript">
        $(function () {
            //Load the image URLs into an Array.
            var arr = new Array();
            $("#dvImages img").each(function () {
                arr.push($(this).attr("src"));
            });

            //Set the first image URL as source for the Product.
            $("#product1, #product2, #product3").attr("src", arr[0]);

            //Click mode.
            $("#product1").threesixty({ images: arr,
                method: 'click',
                sensibility: 1
            });

            //MouseMove mode.
            $("#product2").threesixty({ images: arr,
                method: 'mousemove',
                sensibility: 1
            });

            //Automatic mode.
            $("#product3").threesixty({ images: arr,
                method: 'auto',
                direction: 'forward',
                autoscrollspeed: 500
            });
        });
    </script>
    </form>
</body>
</html>