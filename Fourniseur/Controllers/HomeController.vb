Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function ListeFournisseur() As ActionResult
        Dim fournisseurs = New List(Of FournisseurModel)
        fournisseurs = FOURNISSEUR_SELECT(choix:="ALL").AsEnumerable.Select(Function(x) New FournisseurModel With {
        .ID = If(IsDBNull(x("ID")), 0, x("ID")),
        .ADRESSE_SOCIALE = If(IsDBNull(x("ADRESSE_SOCIALE")), "NEANT", x("ADRESSE_SOCIALE")),
        .TYPE_FOURNISSEUR = If(IsDBNull(x("LIBELLE")), "NEANT", x("LIBELLE")),
        .NOM = If(IsDBNull(x("NOM")), "NEANT", x("NOM")),
        .NOM_ENTREPRISE = If(IsDBNull(x("NOM_ENTREPRISE")), "NEANT", x("NOM_ENTREPRISE")),
        .PRENOM = If(IsDBNull(x("PRENOM")), "NEANT", x("PRENOM")),
        .TELEPHONE = If(IsDBNull(x("TELEPHONE")), "NEANT", x("TELEPHONE"))
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

        Dim fournisseur = New FournisseurParticulierModel

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
                    '.ADRESSE_SOCIALE = If(IsDBNull(x("ADRESSE_SOCIALE")), "NEANT", x("ADRESSE_SOCIALE"))
                    .TYPE_ID = If(IsDBNull(x("TYPE_FOURNISSEUR").ToString), "NEANT", x("TYPE_FOURNISSEUR"))
                    .NOM = If(IsDBNull(x("NOM")), "NEANT", x("NOM"))
                    '.NOM_ENTREPRISE = If(IsDBNull(x("NOM_ENTREPRISE")), "NEANT", x("NOM_ENTREPRISE"))
                    .PRENOM = If(IsDBNull(x("PRENOM")), "NEANT", x("PRENOM"))
                    .TELEPHONE = If(IsDBNull(x("TELEPHONE")), "NEANT", x("TELEPHONE"))
                End With
            Next

            Return PartialView("_FormsParticulier", fournisseur)
        End If

        Return PartialView("_FormsParticulier", fournisseur)
    End Function

    'single forms actions

    Function EntrepriseAction(idFournisseur As Integer) As ActionResult

        Dim fournisseur = New FournisseurEditModel

        Dim entreprise = New FournisseurEntrepriseModel
        'chargement dropdownlist
        Dim TypeList = FOURNISSEUR_SELECT(choix:="SELECT_TYPE").AsEnumerable.Select(Function(x) New SelectListItem() With {
        .Value = x("ID").ToString,
        .Text = x("libelle")
        }).Where(Function(x) x.Value = "2").ToList
        'chargement du dropdownlist
        fournisseur.TYPE_FOURNISSEUR = New SelectList(TypeList, "Value", "Text")
        entreprise.TYPE_FOURNISSEUR = New SelectList(TypeList, "Value", "Text")
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

            'verifier le type de fournisseur avant le rendu du formulaire adéquat

            For Each x As DataRow In FOURNISSEUR_SELECT(choix:="GETBYID", id:=idFournisseur).Rows
                With entreprise
                    .ID = If(IsDBNull(x("ID")), 0, x("ID"))
                    .TYPE_ID = x("TYPE_FOURNISSEUR").ToString
                    .TELEPHONE = x("TELEPHONE")
                End With
            Next
            Return PartialView("_FormsEntreprise", entreprise)
        End If

        Return PartialView("_FormsEntreprise", entreprise)
    End Function

    Function ParticulierAction(idFournisseur As Integer) As ActionResult

        Dim fournisseur = New FournisseurEditModel
        Dim particulier = New FournisseurParticulierModel

        'chargement dropdownlist
        Dim TypeList = FOURNISSEUR_SELECT(choix:="SELECT_TYPE").AsEnumerable.Select(Function(x) New SelectListItem() With {
        .Value = x("ID").ToString,
        .Text = x("libelle")
        }).Where(Function(x) x.Value = "1").ToList
        'chargement du dropdownlist
        fournisseur.TYPE_FOURNISSEUR = New SelectList(TypeList, "Value", "Text")
        particulier.TYPE_FOURNISSEUR = New SelectList(TypeList, "Value", "Text")
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




            For Each x As DataRow In FOURNISSEUR_SELECT(choix:="GETBYID", id:=idFournisseur).Rows
                    With particulier
                        .ID = If(IsDBNull(x("ID")), 0, x("ID"))
                        .TYPE_ID = x("TYPE_FOURNISSEUR").ToString
                        .NOM = x("NOM")
                        .PRENOM = x("PRENOM")
                        .TELEPHONE = x("TELEPHONE")
                    End With
                Next
                Return PartialView("_FormsParticulier", particulier)

            End If

        Return PartialView("_FormsParticulier", particulier)
    End Function



    ' Edit Get


    'Function Modal(idFournisseur As Integer) As ActionResult

    '    Dim fournisseur = New FournisseurEditModel
    '    'chargement dropdownlist
    '    'Dim TypeList = FOURNISSEUR_SELECT(choix:="SELECT_TYPE").AsEnumerable.Select(Function(x) New SelectListItem() With {
    '    '.Value = x("ID").ToString,
    '    '.Text = x("libelle")
    '    '}).ToList()
    '    'chargement du dropdownlist
    '    'fournisseur.TYPE_FOURNISSEUR = New SelectList(TypeList, "Value", "Text")

    '    'verifier si c est l'ajout ou l'edit, si c est l edit charge les data avec le with
    '    If idFournisseur > 0 Then
    '        'For Each x As DataRow In FOURNISSEUR_SELECT(choix:="GETBYID", id:=idFournisseur).Rows
    '        '    With fournisseur
    '        '        .ID = x("ID")
    '        '        .ADRESSE_SOCIALE = x("ADRESSE_SOCIALE")
    '        '        .TYPE_ID = x("TYPE_FOURNISSEUR").ToString
    '        '        .NOM = x("NOM")
    '        '        .NOM_ENTREPRISE = x("NOM_ENTREPRISE")
    '        '        .PRENOM = x("PRENOM")
    '        '        .TELEPHONE = x("TELEPHONE")
    '        '    End With
    '        'Next



    '    End If

    '    Return PartialView("_Modal", fournisseur)


    'End Function


    ''

    Function Modal(idFournisseur As Integer) As ActionResult
        Dim fournisseur = New FournisseurEditModel
        Dim particulier = New FournisseurParticulierModel
        Dim entreprise = New FournisseurEntrepriseModel
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

            'verifier le type de fournisseur avant le rendu du formulaire adéquat
            If fournisseur.TYPE_ID = "1" Then

                For Each x As DataRow In FOURNISSEUR_SELECT(choix:="GETBYID", id:=idFournisseur).Rows
                    With particulier
                        .ID = If(IsDBNull(x("ID")), 0, x("ID"))
                        .TYPE_ID = x("TYPE_FOURNISSEUR").ToString
                        .NOM = x("NOM")
                        .PRENOM = x("PRENOM")
                        .TELEPHONE = x("TELEPHONE")
                    End With
                Next
                Return PartialView("_FormsParticulier", particulier)
            Else
                For Each x As DataRow In FOURNISSEUR_SELECT(choix:="GETBYID", id:=idFournisseur).Rows
                    With entreprise
                        .ID = If(IsDBNull(x("ID")), 0, x("ID"))
                        .TYPE_ID = x("TYPE_FOURNISSEUR").ToString
                        .TELEPHONE = x("TELEPHONE")
                    End With
                Next
                Return PartialView("_FormsEntreprise", entreprise)
            End If
        End If
        Return PartialView("_FormsParticulier", particulier)
    End Function
    ''
    ' Edit action post


    Function Post_Add_Edit(fournisseur As FournisseurEditModel) As ActionResult

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




        Return Json(New With {.success = False})
    End Function




    'Function About() As ActionResult
    '    ViewData("Message") = "Your application description page."

    '    Return View()
    'End Function


    'Function Contact() As ActionResult
    '    ViewData("Message") = "Your contact page."

    '    Return View()
    'End Function


End Class
