<%@ Page Title="Log in" Language="C#" MasterPageFile="~/SteerRent.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SteerRent.Account.Login" %>
<%--<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>--%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  <style type="text/css">
          .WaterMarkedTextBoxPwd
    {
	    color: gray;
        font-style:italic;
	    display: inline;
        background-image:url('../Images/transparent.gif')
    }</style>

     <script lang="javascript" type="text/javascript">

         function KeyPressPwd(obj, waterMarkText) {
             if ($(obj).val() == waterMarkText) {
                 $(obj).val('');
                 $(obj).removeClass('WaterMarkedTextBoxPwd');
                 $(obj).propAttr('TextMode', 'Password');
             }

         }

         function BlurPwd(obj, waterMarkText) {
             if ($(obj).val().length == 0) {
                 $(obj).val(waterMarkText);
                 $(obj).addClass('WaterMarkedTextBoxPwd');
                 $(obj).propAttr('TextMode', 'text');
             }
             else {
                 $(obj).removeClass('WaterMarkedTextBoxPwd');
                 $(obj).propAttr('TextMode', 'Password');
             }
         }
    </script>

<%--    <img src="../Images/steerrent_home.png" />
    <hgroup class="title">
     <h3>LOGIN</h3>   
    </hgroup>--%>
    <div>
        <div id="login_mn">
            <div id="login_main-cntr">
                <h1>Login to SteerRent</h1>
                <div class="lgn-innr">
                    <br />
                    <div class="error_message" style="display: none;">
                        <ul>
                            <br />
                            <li>Display error message here</li>
                        </ul>
                    </div>

                    <div class="lgn-frm">
                        <p>
                            <input name="username" value="Username" type="text">
                        </p>
                        <p>
                            <input name="password" value="Password" type="text"></p>

                        <div class="frgt">
                            <span class="left padd5">
                                <input id="f" type="checkbox" value="checkbox"><label>Remember me</label></span>
                            <label class="right padd10">Forgot Password</label>
                        </div>
                        <div class="clear"></div>
                        <p class="button">
                            <input class="btn_login" name="login" type="button" value="Login"></p>

                    </div>
                </div>

            </div>

            <div class="copyright">&copy;&nbsp;2013&nbsp;SteerRent.&nbsp;All rights reserved.</div>
        </div>

       <%-- <asp:TextBox runat="server" onkeypress="KeyPress(this,'Username')" ClientIDMode="Static" onblur="Blur(this,'Username')" CssClass="WaterMarkedTextBox"
            ID="txtUserName" Text="Username" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
        <br />
        <input placeholder="Password" id="txtPwd" type="password" runat="server" />
        <asp:TextBox runat="server" ID="txtPassword" ClientIDMode="Static" onkeypress="KeyPressPwd(this,'Password')" 
             Text="Password" onblur="BlurPwd(this,'Password')" CssClass="WaterMarkedTextBoxPwd" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="field-validation-error" ErrorMessage="The password field is required." />
        <br />
        <asp:CheckBox runat="server" ID="RememberMe" />
        <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember Me</asp:Label>
        &nbsp;&nbsp;
                            <a class="checkbox" href="/">Forgot Password</a>
        <br />
        <div>
            <asp:Button runat="server" CommandName="Login" Text="Log in" />
        </div>--%>
    </div>
 <%--       <p style="display:none">
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>


    <section id="socialLoginForm" style="display:none">
        <h2>Use another service to log in.</h2>
        <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
    </section>--%>

</asp:Content>
