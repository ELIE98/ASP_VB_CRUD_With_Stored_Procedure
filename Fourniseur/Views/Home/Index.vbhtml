@ModelType IEnumerable(Of FournisseurModel)
@Code
    ViewData("Title") = "Home Page"
End Code

<div class="container">
    <h4 class="text-center">Liste item</h4>
    @Html.ActionLink("Ajouter", "Add", "Home", New With {.class = "btn btn-success glyphicon glyphicon-plus"})
    <div class="row ">
        <table class="table">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">Type fournisseur</th>
                    <th scope="col">Adresse Sociale</th>
                    <th scope="col">Entreprise</th>
                    <th scope="col">Nom</th>
                    <th scope="col">Prenom</th>
                    <th scope="col">Telephone</th></tr>
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
</div>