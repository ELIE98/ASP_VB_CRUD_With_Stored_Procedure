@ModelType Fourniseur.FournisseurEditModel
@*@Scripts.Render("~/bundles/jquery")*@

<script src="~/Scripts/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>

<!-- Modal -->
<div id="staticBackdrop" role="dialog" class="modal fade bs-example-modal-md" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title text-center" id="">Insertion Form</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div class="container">
                    @Using (Ajax.BeginForm("Post_Add_Edit", "Home", New AjaxOptions() With {.InsertionMode = InsertionMode.Replace, .UpdateTargetId = "", .HttpMethod = "POST", .OnSuccess = "success(data);"}, New With {.role = "form"}))

                        @Html.AntiForgeryToken

                        @<div class="form">
                            <h4 class="text-center">FournisseurModel</h4>
                            <hr />

                            @Html.HiddenFor(Function(model) model.ID)

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.TYPE_FOURNISSEUR, htmlAttributes:=New With {.class = "control-label col-md-6"})
                                <div class="col-md-6">
                                    @Html.DropDownListFor(Function(model) model.TYPE_ID, Model.TYPE_FOURNISSEUR, "Select type", New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(model) model.TYPE_ID, "", New With {.class = "text-danger"})
                                </div>
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.ADRESSE_SOCIALE, htmlAttributes:=New With {.class = "control-label col-md-6"})
                                <div class="col-md-6">
                                    @Html.EditorFor(Function(model) model.ADRESSE_SOCIALE, New With {.htmlAttributes = New With {.class = "form-control"}})
                                    @Html.ValidationMessageFor(Function(model) model.ADRESSE_SOCIALE, "", New With {.class = "text-danger"})
                                </div>
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.NOM_ENTREPRISE, htmlAttributes:=New With {.class = "control-label col-md-6"})
                                <div class="col-md-6">
                                    @Html.EditorFor(Function(model) model.NOM_ENTREPRISE, New With {.htmlAttributes = New With {.class = "form-control"}})
                                    @Html.ValidationMessageFor(Function(model) model.NOM_ENTREPRISE, "", New With {.class = "text-danger"})
                                </div>
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.NOM, htmlAttributes:=New With {.class = "control-label col-md-6"})
                                <div class="col-md-6">
                                    @Html.EditorFor(Function(model) model.NOM, New With {.htmlAttributes = New With {.class = "form-control"}})
                                    @Html.ValidationMessageFor(Function(model) model.NOM, "", New With {.class = "text-danger"})
                                </div>
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.PRENOM, htmlAttributes:=New With {.class = "control-label col-md-6"})
                                <div class="col-md-6">
                                    @Html.EditorFor(Function(model) model.PRENOM, New With {.htmlAttributes = New With {.class = "form-control"}})
                                    @Html.ValidationMessageFor(Function(model) model.PRENOM, "", New With {.class = "text-danger"})
                                </div>
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.TELEPHONE, htmlAttributes:=New With {.class = "control-label col-md-6"})
                                <div class="col-md-6">
                                    @Html.EditorFor(Function(model) model.TELEPHONE, New With {.htmlAttributes = New With {.class = "form-control"}})
                                    @Html.ValidationMessageFor(Function(model) model.TELEPHONE, "", New With {.class = "text-danger"})
                                </div>
                            </div>


                        </div>


                        @<div Class="modal-footer">
                            <Button type="button" Class="btn btn-danger " data-dismiss="modal"><i Class="glyphicon glyphicon-remove"></i> Close</Button>
                            <Button type="submit" Class="btn btn-success"><i Class="glyphicon glyphicon-ok-sign"></i> Send</Button>
                        </div>
                    End Using
                </div>
            </div>
        </div>
    </div>
</div>