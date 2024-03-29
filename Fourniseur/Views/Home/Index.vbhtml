﻿@ModelType Fourniseur.ViewFournisseurModel
@Code
    ViewData("Title") = "Index"
End Code





<div class="container">
    <h4 class="text-center">Liste item</h4>
    <span id="message" class="alert alert-success" style="display:none;">

        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </span>

    @*@Html.ActionLink("Ajouter", "Edit", "Home", New With {.class = "btn btn-success glyphicon glyphicon-plus "})*@
    <button type="button" class="btn btn-primary" id="btn_submit_add">
        <i class="glyphicon glyphicon-plus"></i>
        Add
    </button>
    <div id="listFournisseurs">
        @Html.Action("ListeFournisseur", "Home")
    </div>
    
   
</div>
<div id="afficheModal">

</div>


@Section Scripts

    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.unobtrusive-ajax.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
   
    <script type="text/javascript">

        function success(data) {

            if (data.success) {
                $('#staticBackdrop').modal('hide');
                ListeFournisseur();
                $('#message').html('');
                $('#message').css('display', 'block');
                $('#message').append(data.msg)/*.css('color', 'red')*/;
            } else {
                $('#message').html('');
                $('#message').append(data.msg)/*.css('color', 'red')*/;
            }

        };


    $(document).on('click', '#btn_submit_add', function () {

            chargerInfo(0);
    })

    $(document).on('click', '#btn_delete', function () {
        var id = $(this).attr('data-id');

        bootbox.confirm("Voulez-vous supprimer l'élément ayant l'ID : " + id + " ?", function (result) {
            if (result) {
                $.ajax({
                    data:{id:id},
                    url: '/Home/Delete/',
                    method: 'GET',
                    success: function() {
                        $(this).parents("tr").remove();
                        $("#listAffichage").load(location.href + " #listAffichage");
                    }
                });
            }
        });
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

        //choix du formulaire a ramener

        function change(params) {
            var type = params.value;
            var id = 0;
            
            if (type =="1") {
                $.ajax({
                    url: '@Url.Action("ParticulierAction", "Home")',
                   
                    type: 'GET',
                    data: { idFournisseur: id },
                    success: function (result) {

                        
                        $('#modalContent').html(result);
                        
                    }

                });
            } 
            else (type =="2")
            {
                $.ajax({
                    url: '@Url.Action("EntrepriseAction", "Home")',
                   
                    type: 'GET',
                    data: { idFournisseur: id },
                    success: function (result) {

                        
                        $('#modalContent').html(result);
                       
                    }

                });
            }
        };

        $(document).on('click', '#submit', function () {
            var dropValue = $("#dropdowntype").val();
            var datas = $("#form").serialize();
            //alert(typeof(dropValue));
            if (dropValue == "1") {
                $.ajax({                 
                    url: '/Home/Post_Add_Edit/',
                    type: 'POST',
                    data: datas,
                    success: function () {
                        $("#listAffichage").load(location.href + " #listAffichage")
                    }

                });
            }
            else if(dropValue == "2")
            {
                $.ajax({
                    url: '/Home/Post_Add_Edit/',
                    type: 'POST',
                    data: datas,
                    success: function () {
                        $("#listAffichage").load(location.href + " #listAffichage")
                    }

                });
            }
        })
</script>
End Section