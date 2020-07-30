@ModelType Fourniseur.FournisseurEditModel
@*@Scripts.Render("~/bundles/jquery")*@

<script src="~/Scripts/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>

<!-- Modal -->
<div id="staticBackdrop" role="dialog" class="modal fade bs-example-modal-md" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h3 class="text-center">Confirmation</h3>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div class="container">
                    @Using (Ajax.BeginForm("Delete", "Home", New AjaxOptions() With {.HttpMethod = "POST", .OnSuccess = "success(data);"}, New With {.role = "form"}))

                        @Html.AntiForgeryToken

                        @<div class="form">

                            <hr />

                            @Html.HiddenFor(Function(model) model.ID)
                            <h3 class="text-center"> Voulez-vous supprimer l' élément ID @Model.ID ?</h3>

                        </div>


                        @<div Class="modal-footer">
                            <Button type="button" Class="btn btn-danger " data-dismiss="modal"><i Class="glyphicon glyphicon-remove"></i> Close</Button>
                            <Button type="submit" Class="btn btn-success"><i Class="glyphicon glyphicon-ok-sign"></i> Yes</Button>
                        </div>
                    End Using
                </div>
            </div>
        </div>
    </div>
</div>
