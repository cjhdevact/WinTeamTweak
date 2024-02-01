Module ResWrite
    Public Sub ResStrWrite(ByVal respath As String, ByVal wrtpath As String)
        Try
            If wrtpath <> "" Then
                If System.IO.File.Exists(wrtpath) = False Then
                    '设置释放路径   导出路径
                    Dim fs As New System.IO.FileStream(wrtpath, IO.FileMode.Create)
                    fs.Close()
                    Dim fs2 As New IO.StreamWriter(wrtpath)
                    fs2.WriteLine(respath)
                    fs2.Close()

                Else
                    IO.File.Delete(wrtpath)
                    '设置释放路径   导出路径
                    Dim fs As New System.IO.FileStream(wrtpath, IO.FileMode.Create)
                    fs.Close()
                    Dim fs2 As New IO.StreamWriter(wrtpath)
                    fs2.WriteLine(respath)
                    fs2.Close()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("将文件写入到 " & wrtpath & " 时发生错误。" & vbCrLf & ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub ResByteWrite(ByVal respath As Byte(), ByVal wrtpath As String)
        Try
            If wrtpath <> "" Then
                If System.IO.File.Exists(wrtpath) = False Then
                    Using fs As New System.IO.FileStream(wrtpath, IO.FileMode.Create)
                        fs.Write(respath, 0, respath.Length)
                        fs.Close()
                    End Using
                Else
                    IO.File.Delete(wrtpath)
                    Using fs As New System.IO.FileStream(wrtpath, IO.FileMode.Create)
                        fs.Write(respath, 0, respath.Length)
                        fs.Close()
                    End Using
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("将文件写入到 " & wrtpath & " 时发生错误。" & vbCrLf & ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
