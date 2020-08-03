Imports System.ComponentModel.DataAnnotations
Public Class ViewFournisseurModel


End Class

Public Class FournisseurModel
    Public Property ID As Integer
    Public Property TYPE_FOURNISSEUR As String
    Public Property ADRESSE_SOCIALE As String
    Public Property NOM_ENTREPRISE As String
    Public Property NOM As String
    Public Property PRENOM As String
    Public Property TELEPHONE As String
End Class


Public Class FournisseurEditModel
    Public Property ID As Integer
    <Required(ErrorMessage:="information  requise")>
    Public Property TYPE_ID As String
    Public Property TYPE_FOURNISSEUR As IEnumerable(Of SelectListItem)
    <Required(ErrorMessage:="information  requise")>
    Public Property ADRESSE_SOCIALE As String
    <Required(ErrorMessage:="information  requise")>
    Public Property NOM_ENTREPRISE As String
    <Required(ErrorMessage:="information  requise")>
    Public Property NOM As String
    <Required(ErrorMessage:="information  requise")>
    Public Property PRENOM As String
    <Required(ErrorMessage:="information  requise")>
    Public Property TELEPHONE As String
End Class

Public Class FournisseurParticulierModel
    Public Property ID As Integer
    <Required(ErrorMessage:="information  requise")>
    Public Property TYPE_ID As String
    Public Property TYPE_FOURNISSEUR As IEnumerable(Of SelectListItem)
    <Required(ErrorMessage:="information  requise")>
    Public Property NOM As String
    <Required(ErrorMessage:="information  requise")>
    Public Property PRENOM As String
    <Required(ErrorMessage:="information  requise")>
    Public Property TELEPHONE As String
End Class

Public Class FournisseurEntrepriseModel
    Public Property ID As Integer
    <Required(ErrorMessage:="information  requise")>
    Public Property TYPE_ID As String
    Public Property TYPE_FOURNISSEUR As IEnumerable(Of SelectListItem)
    <Required(ErrorMessage:="information  requise")>
    Public Property ADRESSE_SOCIALE As String
    <Required(ErrorMessage:="information  requise")>
    Public Property NOM_ENTREPRISE As String
    <Required(ErrorMessage:="information  requise")>
    Public Property TELEPHONE As String
End Class