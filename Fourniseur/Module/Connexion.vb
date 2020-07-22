Imports System.Data.SqlClient

Module Connexion
    'Function OPEN_CONNEXION(p_bdname As String) As SqlConnection

    '    Dim cnx As New SqlConnection
    '    If cnx.State = ConnectionState.Closed Then
    '        cnx.ConnectionString = ConfigurationManager.AppSettings("DBConnString").ToString + "User=sa;Password=123;Database=" + p_bdname
    '        Try

    '            cnx.Open()
    '            MsgBox("bd connected")
    '        Catch ex As Exception
    '            MsgBox("erreur de connexion : " + ex.ToString)
    '        End Try
    '    End If

    '    Return cnx
    'End Function


    Function OPEN_CONNEXION() As SqlConnection ' MySqlConnection
        If HttpContext.Current.Session("cnx") Is Nothing Then
            Dim cnx As New SqlConnection
            cnx.ConnectionString = ConfigurationManager.AppSettings("DBConnString")
            cnx.Open()
            MsgBox(cnx.State.ToString)
            HttpContext.Current.Session("cnx") = cnx
        End If
        Return CType(HttpContext.Current.Session("cnx"), SqlConnection)
    End Function

End Module
