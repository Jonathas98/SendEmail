Imports System.IO

Public Class FrmSend_email
    Private Sub BtnEnviarEmail_Click(sender As Object, e As EventArgs) Handles BtnEnviarEmail.Click
        Call ReadArchive(txtMensagem.Text, txtAssunto.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
