Imports System.Data.SqlClient

Module Fournisseur

    Public Function FOURNISSEUR_INSERT(Optional id As Integer = 0,
                                       Optional choix As String = "",
                                       Optional type As Integer = 0,
                                       Optional entreprise As String = "",
                                       Optional nom As String = "",
                                       Optional prenom As String = "",
                                       Optional telephone As String = "",
                                       Optional adresse As String = ""
                                       ) As Exception


        Dim db As SqlClient.SqlConnection = OPEN_CONNEXION()
        Dim commande As SqlCommand = db.CreateCommand
        commande.CommandType = CommandType.StoredProcedure
        commande.Parameters.AddWithValue("@id", id)
        commande.Parameters.AddWithValue("@choix", choix)
        commande.Parameters.AddWithValue("@type", type)
        commande.Parameters.AddWithValue("@adresse", adresse)
        commande.Parameters.AddWithValue("@entreprise", entreprise)
        commande.Parameters.AddWithValue("@nom", nom)
        commande.Parameters.AddWithValue("@prenom", prenom)
        commande.Parameters.AddWithValue("@telephone", telephone)
        commande.CommandText = "FOURNISSEUR_INSERT"
        commande.ExecuteNonQuery()

        Return Nothing

    End Function

    Public Function FOURNISSEUR_SELECT(Optional id As Integer = 0, Optional choix As String = "") As DataTable

        Dim data As DataTable
        data = New DataTable
        Dim db As SqlClient.SqlConnection = OPEN_CONNEXION()
        Dim commande As SqlCommand = db.CreateCommand
        commande.CommandType = CommandType.StoredProcedure
        commande.Parameters.AddWithValue("@id", id)
        commande.Parameters.AddWithValue("@choix", choix)
        commande.CommandText = "FOURNISSEUR_SELECT"

        'commande.ExecuteNonQuery
        data.Load(commande.ExecuteReader)
        Return data
        'Return Nothing

    End Function
End Module
