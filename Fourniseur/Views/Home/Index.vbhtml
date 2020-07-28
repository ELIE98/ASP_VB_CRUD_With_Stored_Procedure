@ModelType Fourniseur.ViewFournisseurModel
@Code
    ViewData("Title") = "Index"
End Code





<div class="container">
    <h4 class="text-center">Liste item</h4>
    @*@Html.ActionLink("Ajouter", "Edit", "Home", New With {.class = "btn btn-success glyphicon glyphicon-plus "})*@
    <button type="button" class="btn btn-primary" id="btn_submit_add">
        <i class="glyphicon glyphicon-plus"></i>
        Add
    </button>
    <div id="listFournisseurs">
        @Html.Action("ListeFournisseur", "Home")
    </div>
    <span id="message">

    </span>
   
</div>
<div id="afficheModal">

</div>

@*@Scripts.Render("~/bundles/jqueryval")*@
@Section Scripts

    @*<script src="~/Scripts/jquery-1.10.2.js"></script>*@
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.unobtrusive-ajax.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>

    <script type="text/javascript">
     function success(data) {

         if (data.success) {
             $('#staticBackdrop').modal('hide');
             ListeFournisseur();
             $('#message').html('');
             $('#message').html(data.msg).css('color','green');
         } else {
             $('#message').html('');
             $('#message').html(data.msg).css('color', 'red');
         }

     };


     $(document).on('click', '#btn_submit_add', function () {
         chargerInfo(0);
     })

     $(document).on('click', '#btn_submit', function () {
         chargerInfo($(this).attr('data-id'));
        })


     function chargerInfo(id) {
         $.ajax({
             url: '@Url.Action("Edit", "Home")',
             type: 'GET',
             data: { idFournisseur: id },
             success: function (result) {
                 $('#afficheModal').html('');
                 $('#afficheModal').html(result);
                 $('#staticBackdrop').modal({ backdrop: 'static' }, 'show');
             }

         });
     }

     function ListeFournisseur() {
         $.ajax({
             url: '@Url.Action("ListeFournisseur", "Home")',
             type: 'GET',
             success: function (result) {
                 
                 $('#listFournisseurs').html('');
                 $('#listFournisseurs').html(result);

             }

         });
     }




       

    </script>
End Section