﻿@ModelType IEnumerable(Of FournisseurModel)

@Code
    ViewData("Title") = "Home Page"
End Code

<div class="container">
    <h4 class="text-center">Liste item</h4>
    @Html.ActionLink("Ajouter", "Edit", "Home", New With {.class = "btn btn-success glyphicon glyphicon-plus "})
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#staticBackdrop" id="btn_submit">
       <i class="glyphicon glyphicon-plus"></i>
        Add
    </button>
    <div class="row ">
        <table class="table mt-4">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">Type fournisseur</th>
                    <th scope="col">Adresse Sociale</th>
                    <th scope="col">Entreprise</th>
                    <th scope="col">Nom</th>
                    <th scope="col">Prenom</th>
                    <th scope="col">Telephone</th>
                    <th scope="col">Editer</th>
                    <th scope="col">Supprimer</th>
                </tr>
            </thead>
            <tbody>
               @For Each item In Model
                @<tr>
                    <td>@item.TYPE_FOURNISSEUR</td>
                    <td>@item.ADRESSE_SOCIALE</td>
                    <td>@item.NOM_ENTREPRISE</td>
                    <td>@item.NOM</td>
                    <td>@item.PRENOM</td>
                    <td>@item.TELEPHONE</td>
                @*@code 
                    MsgBox(item.ID.ToString)
                End Code*@

                   <td>@Html.ActionLink("Editer", "Edit", "Home", New With {.id = item.ID}, New With {.class = "btn btn-warning glyphicon glyphicon-pencil"})</td>
                   <td>@Html.ActionLink("Supprimer", "Delete", "Home", New With {.id = item.ID}, New With {.class = "btn btn-danger glyphicon glyphicon-trash"})</td>
                </tr>
                    Next
               
            </tbody>
        </table>
       
       
    </div>
    
    <div id="afficheModal">

    </div>
   @*@Html.Action("Edit", "Home")*@
               
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    <script>
        $('#btn_submit').on('click', function () {
            //alert($('#ID').val());
            $.ajax({
                url: "@Url.Action("Modal", "Home")",

                type: 'GET',

                //data: { id: $('#ID').val() }
            }).done(function (result) {
                alert(result);
                $('#afficheModal').html(result);
                $('#staticBackdrop').modal({ backdrop: 'static' }, 'show');
            });
        });

      
    </script>
End Section