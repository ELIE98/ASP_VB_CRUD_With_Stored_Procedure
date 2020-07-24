@ModelType Fourniseur.FournisseurModel
@Code
    ViewData("Title") = "Add"
End Code

<h2>Add</h2>

@Using (Html.BeginForm("Add", "Home"))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>FournisseurModel</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.TYPE_FOURNISSEUR, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TYPE_FOURNISSEUR, New With {.htmlAttributes = New With {.class = "form-control", .min = 1, .max = 2, .id = "type"}})
                @Html.ValidationMessageFor(Function(model) model.TYPE_FOURNISSEUR, "", New With {.class = "text-danger"})
            </div>
        </div>
          
              <div Class="form-group">
                @Html.LabelFor(Function(model) model.NOM, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div Class="col-md-10">
                    @Html.EditorFor(Function(model) model.NOM, New With {.htmlAttributes = New With {.class = "form-control"}, .disabled = True, .id = "nom"})
                    @Html.ValidationMessageFor(Function(model) model.NOM, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div Class="form-group">
                @Html.LabelFor(Function(model) model.PRENOM, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div Class="col-md-10">
                    @Html.EditorFor(Function(model) model.PRENOM, New With {.htmlAttributes = New With {.class = "form-control"}, .disabled = True, .id = "prenom"})
                    @Html.ValidationMessageFor(Function(model) model.PRENOM, "", New With {.class = "text-danger"})
                </div>
          </div>





        <div Class="form-group">
                @Html.LabelFor(Function(model) model.ADRESSE_SOCIALE, htmlAttributes:=New With {.class = "control-label col-md-2"})
                 <div Class="col-md-10">
                    @Html.EditorFor(Function(model) model.ADRESSE_SOCIALE, New With {.htmlAttributes = New With {.class = "form-control"}, .id = "adresse"})
                    @Html.ValidationMessageFor(Function(model) model.ADRESSE_SOCIALE, "", New With {.class = "text-danger"})
                 </div>
             </div>

            <div Class="form-group">
                @Html.LabelFor(Function(model) model.NOM_ENTREPRISE, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div Class="col-md-10">
                   @Html.EditorFor(Function(model) model.NOM_ENTREPRISE, New With {.htmlAttributes = New With {.class = "form-control"}, .id = "entreprise"})
                   @Html.ValidationMessageFor(Function(model) model.NOM_ENTREPRISE, "", New With {.class = "text-danger"})
                </div>
            </div>





            <div Class="form-group">
                @Html.LabelFor(Function(model) model.TELEPHONE, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div Class="col-md-10">
                    @Html.EditorFor(Function(model) model.TELEPHONE, New With {.htmlAttributes = New With {.class = "form-control"}, .id = "telephone"})
                    @Html.ValidationMessageFor(Function(model) model.TELEPHONE, "", New With {.class = "text-danger"})
                </div>
            </div>






        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-success glyphicon glyphicon-plus "  />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back", "Index", "Home", New With {.class = "btn btn-primary glyphicon glyphicon-arrow-left"})
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")

    <script>
        $(document).ready(function () {
            $('#type').on('change', function () {
                var value = $(this).val();
                //alert(typeof(value));

                if (value === "2") {
                    $('#nom').attr("disabled", "disabled");
                    $('#prenom').attr("disabled", "disabled");
                } else if (value === "1") {
                    $('#adresse').attr("disabled", "disabled");
                    $('#entreprise').attr("disabled", "disabled");
                }
            });

        })
    </script>
End Section
