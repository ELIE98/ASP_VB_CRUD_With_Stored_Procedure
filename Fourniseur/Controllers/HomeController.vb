Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult

        'Procedé de recuperation du datable en liste

        Dim Fournisseurs As New List(Of FournisseurModel)
        Fournisseurs = GetAll().AsEnumerable.Select(Function(x) New FournisseurModel With {
        .ADRESSE_SOCIALE = x("ADRESSE_SOCIALE"),
        .TYPE_FOURNISSEUR = x("TYPE_FOURNISSEUR"),
        .NOM = x("NOM"),
        .NOM_ENTREPRISE = x("NOM_ENTREPRISE"),
        .PRENOM = x("PRENOM"),
        .TELEPHONE = x("TELEPHONE")
        }).ToList


        Return View(Fournisseurs)
    End Function

    'Add action

    Function Add() As ActionResult


        Return View()
    End Function

    'post Add action
    <AcceptVerbs(HttpVerbs.Post)>
    Function Add(fournisseur As FournisseurModel) As ActionResult
        Try
            Dim db As SqlClient.SqlConnection = OPEN_CONNEXION()
            Dim commande As SqlCommand = db.CreateCommand()
            commande.CommandType = CommandType.StoredProcedure
            commande.Parameters.AddWithValue("@type", fournisseur.TYPE_FOURNISSEUR)
            commande.Parameters.AddWithValue("@adresse", fournisseur.ADRESSE_SOCIALE)
            commande.Parameters.AddWithValue("@entreprise", fournisseur.NOM_ENTREPRISE)
            commande.Parameters.AddWithValue("@nom", fournisseur.NOM)
            commande.Parameters.AddWithValue("@prenom", fournisseur.PRENOM)
            commande.Parameters.AddWithValue("@telephone", fournisseur.TELEPHONE)

            commande.CommandText = "AddFournisseur"
            commande.ExecuteNonQuery()
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try

    End Function

    Function Delete(id As Integer) As ActionResult
        Dim db As SqlClient.SqlConnection = OPEN_CONNEXION()
        Dim commande As SqlCommand = db.CreateCommand()
        commande.CommandType = CommandType.StoredProcedure
        commande.Parameters.AddWithValue("@id", id)
        commande.CommandText = "DeleteFourniseur"
        commande.ExecuteNonQuery()
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

    'Fonction de récuperation des data de la BD via stored procedure !! 
    Public Function GetAll() As DataTable
        Dim data As DataTable
        data = New DataTable
        Dim db As SqlClient.SqlConnection = OPEN_CONNEXION()
        Dim commande As SqlCommand = db.CreateCommand()
        commande.CommandType = CommandType.StoredProcedure
        commande.CommandText = "getAllFournisseurFromDb"

        data.Load(commande.ExecuteReader())
        Return data
    End Function
End Class
