

@*@Scripts.Render("~/bundles/jquery")*@

@*<script src="~/Scripts/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>*@

<!-- Modal -->
<div id="staticBackdrop" role="dialog" class="modal fade bs-example-modal-md" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="text-left">Ajoutez un Fournisseur</h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
          
                <div id="modalContent">

                    @Html.Action("ParticulierAction", "Home")

                </div>
            </div>
        </div>
    </div>
