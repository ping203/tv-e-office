<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE.Works.Default" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">    
    <script type="text/javascript">
        $(document).ready(function() {
            $("#commentForm").validate();
        });
        function check() {
            return false;
        }
  </script>
    <div class="list wp-form" id="create-document">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Tạo công việc mới</h2>
                <form class="cmxform" id="commentForm" method="get" action="" onsubmit="javascript:return check();">
 <fieldset>
   <legend>A simple comment form with submit validation and default messages</legend>
   <p>
     <label for="cname">Name</label>
     <em>*</em><input id="cname" name="name" size="25" class="required" minlength="2" />
   </p>
   <p>
     <label for="cemail">E-Mail</label>
     <em>*</em><input id="cemail" name="email" size="25"  class="required email" />
   </p>
   <p>
     <label for="curl">URL</label>
     <em>  </em><input id="curl" name="url" size="25"  class="url" value="" />
   </p>
   <p>
     <label for="ccomment">Your comment</label>
     <em>*</em><textarea id="ccomment" name="comment" cols="22"  class="required"></textarea>
   </p>
   <p>
   	<input type="text" class="required email" />
   </p>
   <p>
     <input class="" type="submit" value="Submit"/>
   </p>
 </fieldset>
 </form>
            </div>
</asp:Content>
