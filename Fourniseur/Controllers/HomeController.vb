Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Function ListeFournisseur() As ActionResult
        Dim fournisseurs = New List(Of FournisseurModel)
        fournisseurs = FOURNISSEUR_SELECT(choix:="ALL").AsEnumerable.Select(Function(x) New FournisseurModel With {
        .ID = x("ID"),
        .ADRESSE_SOCIALE = x("ADRESSE_SOCIALE"),
        .TYPE_FOURNISSEUR = x("LIBELLE"),
        .NOM = x("NOM"),
        .NOM_ENTREPRISE = x("NOM_ENTREPRISE"),
        .PRENOM = x("PRENOM"),
        .TELEPHONE = x("TELEPHONE")
        }).ToList
        Return PartialView("ListeFournisseur", fournisseurs)
    End Function

    Function Index() As ActionResult

        Return View()
    End Function




    'delete action
    Function Delete(id As Integer) As ActionResult

        'Delete This User
        FOURNISSEUR_INSERT(id:=id, choix:="DELETE")

        Return RedirectToAction("Index")
    End Function

    ' Edit Get
    Function Edit(idFournisseur As Integer) As ActionResult

        Dim fournisseur = New FournisseurEditModel
        'chargement dropdownlist
        Dim TypeList = FOURNISSEUR_SELECT(choix:="SELECT_TYPE").AsEnumerable.Select(Function(x) New SelectListItem() With {
        .Value = x("ID").ToString,
        .Text = x("libelle")
        }).ToList()
        'chargement du dropdownlist
        fournisseur.TYPE_FOURNISSEUR = New SelectList(TypeList, "Value", "Text")

        'verifier si c est l'ajout ou l'edit, si c est l edit charge les data avec le with
        If idFournisseur > 0 Then
            For Each x As DataRow In FOURNISSEUR_SELECT(choix:="GETBYID", id:=idFournisseur).Rows
                With fournisseur
                    .ID = If(IsDBNull(x("ID")), 0, x("ID"))
                    .ADRESSE_SOCIALE = x("ADRESSE_SOCIALE")
                    .TYPE_ID = x("TYPE_FOURNISSEUR").ToString
                    .NOM = x("NOM")
                    .NOM_ENTREPRISE = x("NOM_ENTREPRISE")
                    .PRENOM = x("PRENOM")
                    .TELEPHONE = x("TELEPHONE")
                End With
            Next
        End If
        Return PartialView("_Modal", fournisseur)
    End Function

    ' Edit Get


    Function Modal(idFournisseur As Integer) As ActionResult

        Dim fournisseur = New FournisseurEditModel
        'chargement dropdownlist
        'Dim TypeList = FOURNISSEUR_SELECT(choix:="SELECT_TYPE").AsEnumerable.Select(Function(x) New SelectListItem() With {
        '.Value = x("ID").ToString,
        '.Text = x("libelle")
        '}).ToList()
        'chargement du dropdownlist
        'fournisseur.TYPE_FOURNISSEUR = New SelectList(TypeList, "Value", "Text")

        'verifier si c est l'ajout ou l'edit, si c est l edit charge les data avec le with
        If idFournisseur > 0 Then
            'For Each x As DataRow In FOURNISSEUR_SELECT(choix:="GETBYID", id:=idFournisseur).Rows
            '    With fournisseur
            '        .ID = x("ID")
            '        .ADRESSE_SOCIALE = x("ADRESSE_SOCIALE")
            '        .TYPE_ID = x("TYPE_FOURNISSEUR").ToString
            '        .NOM = x("NOM")
            '        .NOM_ENTREPRISE = x("NOM_ENTREPRISE")
            '        .PRENOM = x("PRENOM")
            '        .TELEPHONE = x("TELEPHONE")
            '    End With
            'Next



        End If

        Return PartialView("_Modal", fournisseur)


    End Function
    ' Edit action post


    Function Post_Add_Edit(fournisseur As FournisseurEditModel) As ActionResult
        If ModelState.IsValid Then
            If fournisseur.ID = 0 Then
                FOURNISSEUR_INSERT(
                    choix:="INSERT",
                    id:=fournisseur.ID,
                    adresse:=fournisseur.ADRESSE_SOCIALE,
                    type:=fournisseur.TYPE_ID,
                    nom:=fournisseur.NOM,
                    entreprise:=fournisseur.NOM_ENTREPRISE,
                    prenom:=fournisseur.PRENOM,
                    telephone:=fournisseur.TELEPHONE)
                Return Json(New With {.success = True, .msg = "Ajout effectué avec succes !!"}, JsonRequestBehavior.AllowGet)
            Else
                FOURNISSEUR_INSERT(
                    choix:="UPDATE",
                    id:=fournisseur.ID,
                    adresse:=fournisseur.ADRESSE_SOCIALE,
                    type:=fournisseur.TYPE_ID,
                    nom:=fournisseur.NOM,
                    entreprise:=fournisseur.NOM_ENTREPRISE,
                    prenom:=fournisseur.PRENOM,
                    telephone:=fournisseur.TELEPHONE
                )
                Return Json(New With {.success = True, .msg = "modification effectuée avec succes !!"}, JsonRequestBehavior.AllowGet)
            End If
        End If


        'Return RedirectToAction("Index")
        Return Json(New With {.success = False})
    End Function




    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function


    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function


End Class
