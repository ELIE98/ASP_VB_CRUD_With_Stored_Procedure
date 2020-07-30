@ModelType IEnumerable(Of Fourniseur.FournisseurModel)

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
                    <td>
                        <button type="button" class="btn btn-primary " id="btn_submit" data-id="@item.ID">
                            <i class="glyphicon glyphicon-pencil"></i>
                            Update
                        </button>
                    </td>
                     <td>
                         <button type="button" class="btn btn-danger " id="btn_delete" data-id="@item.ID" >
                             <i class="glyphicon glyphicon-remove"></i>
                             Delete
                         </button>
                     </td>
                    @*<td>@Html.ActionLink("Supprimer", "Delete", "Home", New With {.id = item.ID}, New With {.class = "btn btn-danger glyphicon glyphicon-trash"})</td>*@
                </tr>
            Next

        </tbody>
    </table>


</div>

