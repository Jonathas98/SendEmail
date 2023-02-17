Imports System.IO
Imports System.Text
Imports Microsoft.Office
Module MethodSend
    Public Function ReadArchive(ByVal strMensagem As String, ByVal strAssunto As String)

        Dim strPathArquivo = "I:\Operacional\Sistema\Dados\"
        Dim strArquivo = strPathArquivo + "Send_Email.txt"
        Dim strLinha As String
        Dim aryDados

        Try
            Using arquivo As New StreamReader(strArquivo, Encoding.UTF8)
                Do While arquivo.Peek <> -1
                    strLinha = arquivo.ReadLine()
                    aryDados = Split(strLinha, ";")
                    Call SendMail(aryDados(1), aryDados(0), strMensagem, strAssunto)
                Loop

            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao realizar a leitura do arquivo")
        End Try
        Return True
    End Function

    Sub SendMail(strEmailDestino As String, strNome As String, strMensagem As String, strAssunto As String)
        Try
            Dim outApp = New Interop.Outlook.Application
            Dim outMsg As Interop.Outlook.MailItem
            outMsg = outApp.CreateItem(Interop.Outlook.OlItemType.olMailItem)

            outMsg.Subject = strAssunto
            outMsg.Body = strMensagem
            outMsg.To = strEmailDestino

            outMsg.Send()
            MessageBox.Show("Email enviado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception
            MessageBox.Show("Erro ao enviar Email" + vbNewLine + "Erro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
