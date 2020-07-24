Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class HomeController
    Inherits System.Web.Mvc.Controller
    'Get All
    Function Index() As ActionResult


        Dim fournisseurs = New List(Of FournisseurModel)
        fournisseurs = FOURNISSEUR_SELECT(choix:="ALL").AsEnumerable.Select(Function(x) New FournisseurModel With {
        .ID = x("ID"),
        .ADRESSE_SOCIALE = x("ADRESSE_SOCIALE"),
        .TYPE_FOURNISSEUR = x("TYPE_FOURNISSEUR"),
        .NOM = x("NOM"),
        .NOM_ENTREPRISE = x("NOM_ENTREPRISE"),
        .PRENOM = x("PRENOM"),
        .TELEPHONE = x("TELEPHONE")
        }).ToList




        Return View(fournisseurs)
    End Function

    'Add action

    Function Add() As ActionResult
        Return View()
    End Function

    'post Add action
    <AcceptVerbs(HttpVerbs.Post)>
    Function Add(fournisseur As FournisseurModel) As ActionResult
        Try
            FOURNISSEUR_INSERT(
                choix:="INSERT",
                type:=fournisseur.TYPE_FOURNISSEUR,
                nom:=fournisseur.NOM,
                prenom:=fournisseur.PRENOM,
                entreprise:=fournisseur.NOM_ENTREPRISE,
                telephone:=fournisseur.TELEPHONE,
                adresse:=fournisseur.ADRESSE_SOCIALE
                )

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try

    End Function


    'delete action
    Function Delete(id As Integer) As ActionResult

        'Delete This User
        FOURNISSEUR_INSERT(id:=id, choix:="DELETE")

        Return RedirectToAction("Index")
    End Function

    ' Edit Get
    Function Edit(id As Integer) As ActionResult

        Dim fournisseur = New FournisseurModel()
        fournisseur = FOURNISSEUR_SELECT(choix:="GETBYID", id:=id).AsEnumerable.Select(Function(x) New FournisseurModel With {
        .ID = x("ID"),
        .ADRESSE_SOCIALE = x("ADRESSE_SOCIALE"),
        .TYPE_FOURNISSEUR = x("TYPE_FOURNISSEUR"),
        .NOM = x("NOM"),
        .NOM_ENTREPRISE = x("NOM_ENTREPRISE"),
        .PRENOM = x("PRENOM"),
        .TELEPHONE = x("TELEPHONE")
        }).Where(Function(x) x.ID = id).FirstOrDefault()

        Return View(fournisseur)

    End Function

    ' Edit action post
    <AcceptVerbs(HttpVerbs.Post)>
    Function Edit(fournisseur As FournisseurModel) As ActionResult
        FOURNISSEUR_INSERT(
            choix:="UPDATE",
            id:=fournisseur.ID,
            adresse:=fournisseur.ADRESSE_SOCIALE,
            type:=fournisseur.TYPE_FOURNISSEUR,
            nom:=fournisseur.NOM,
            entreprise:=fournisseur.NOM_ENTREPRISE,
            prenom:=fournisseur.PRENOM,
            telephone:=fournisseur.TELEPHONE
        )

        Return RedirectToAction("Index")
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
