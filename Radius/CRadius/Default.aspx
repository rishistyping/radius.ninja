<%@ Page AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Radius Login</title>
    <link href="~/CSS/LoginStyles2.css?version=31" rel="stylesheet" type="text/css" />
    <meta name="title" content="" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <style type="text/css" media="screen">
        #horizon {
            text-align: center;
            position: absolute;
            top: 50%;
            left: 0px;
            width: 100%;
            height: 1px;
            overflow: visible;
            visibility: visible;
            display: block;
        }

        #content {
            text-align: center;
            position: absolute;
            left: 50%;
            width: 330px; /* Overall width of div */
            height: 600px; /* Overall height of div */
            top: -250px; /* half of the overall height */
            margin-left: -165px; /* half of the overall width */
            visibility: visible;
        }

        .auto-style3 {
            margin-left: auto;
            margin-right: auto;
            background-color: #0865c6;
            color: white;
            text-align: right;
        }

        .auto-style5 {
            text-align: left;
        }

        .auto-style6 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="horizon">
            <div id="content">
                <table class="clsCard" cellpadding="10" cellspacing="0" style="border: 1px solid #b2b2b2; border-radius: 5px; vertical-align: top; background-color: white;">
                    <tr>
                        <td class="auto-style3" colspan="2">
                            <asp:Image ID="ImageLogo" runat="server" CssClass="clsPad" AlternateText="TUTI.dx" ImageUrl="~/Images/WhiteLogo.png" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="auto-style5">
                            <p>Welcome to Radius.</p>
                            <p>Radius broadcasts location rules to mobile devices. It helps people know when they enter restricted locations, and understand what to do when they do.</p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="auto-style5">Please Sign In:</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">Username</td>
                        <td style="text-align: right">
                            <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="clsControl" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">Password</td>
                        <td style="text-align: right">
                            <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="clsControl" TextMode="Password" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5"></td>
                        <td style="text-align: right">
                            <asp:Button ID="ButtonSignIn" runat="server" CssClass="clsButton" OnClick="ButtonSignIn_Click" Text="Enter" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <table cellpadding="10" cellspacing="0" style="width: 100%; vertical-align: middle; text-align: center" class="clsMenuBar clsCard">
            <tr>
                <td>
                    <table cellpadding="5" cellspacing="0" style="margin-left: auto; margin-right: auto;">
                        <tr>
                            <td style="vertical-align: middle">
                                <asp:CheckBox ID="CheckBoxRememberMe" runat="server" Style="text-align: right" />
                            </td>
                            <td style="vertical-align: middle; white-space: nowrap; padding-right: 5px">
                                <asp:Label ID="LabelRememberMe" runat="server" Text="Remember me on this computer"></asp:Label>
                            </td>
                            <td>|</td>
                            <td style="vertical-align: middle; white-space: nowrap; padding-right: 5px">Password:
                                        <asp:HyperLink ID="HyperLinkPasswordReminder0" runat="server" NavigateUrl="~/PortalZone/PasswordChange.aspx">Change</asp:HyperLink>
                                or
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/PortalZone/PasswordReset.aspx">Reset</asp:HyperLink></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
