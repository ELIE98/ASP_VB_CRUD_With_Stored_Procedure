@ModelType Fourniseur.FournisseurEditModel 
<!-- Modal -->
<div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                a          <h5 class="modal-title" id="staticBackdropLabel">add or Edit</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
               @Using (Ajax.BeginForm("Edit", "Home", New AjaxOptions With {.OnSuccess = "success", .OnFailure = "Error", .OnComplete = "Completed", .HttpMethod = "POST"}))
                @Html.AntiForgeryToken

                @<div class="form-horizontal">
                    <h4>FournisseurModel</h4>
                    <hr />

                    @Html.HiddenFor(Function(model) model.ID)

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.TYPE_FOURNISSEUR, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.DropDownListFor(Function(model) model.TYPE_ID, Model.TYPE_FOURNISSEUR, "--", New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(model) model.TYPE_ID, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.ADRESSE_SOCIALE, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.ADRESSE_SOCIALE, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.ADRESSE_SOCIALE, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.NOM_ENTREPRISE, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.NOM_ENTREPRISE, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.NOM_ENTREPRISE, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.NOM, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.NOM, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.NOM, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.PRENOM, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.PRENOM, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.PRENOM, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.TELEPHONE, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.TELEPHONE, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.TELEPHONE, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <input type="submit" value="Save" class="btn btn-success" />
                        </div>
                    </div>
                </div>
               End Using

            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                     
        </div>
    </div>
</div>
<script>
    function success(response) {
        alert(SUCCES);
    };


    function Error(response) {
        alert(ERROR);
    };

    function Completed() {

         RedirectToAction("Index");
    };
</script>