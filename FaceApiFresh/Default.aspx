

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FaceApiFresh.Default" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Test</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <div class="navbar navbar-default navbar-fixed-top">
    <div class="container">
      <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
        <a class="navbar-brand" href="#"><b>Azure Face Api Test</b></a>
      </div>
      <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav navbar-right">
          <li><a href="#" class="smoothscroll">Copyright &copy; Nihar | 2019</a></li>
        </ul>
      </div>
      <!--/.nav-collapse -->
    </div>
  </div>


    <form id="form1" runat="server">
         <div class="row" style="margin-top:100px;">
        <div class="col-md-10 col-md-offset-1">
        <asp:textbox Cssclass="form-control" ID="tbResponse" runat="server" TextMode="MultiLine"></asp:textbox>

        <hr />
            <div class="col-md-12">
                <div class="col-md-6">
                     <asp:TextBox ID="tbFilter" runat="server" Cssclass="form-control" placeholder="Image Path (Optional)"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="FaceTest" runat="server" Text="Face Test" OnClick="FaceTest_Click" CssClass="btn btn-warning" />
                </div>
            </div>
        </div>
      </div>
    </form>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
