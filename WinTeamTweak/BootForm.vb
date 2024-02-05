Public Class BootForm
    Public noe As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MainForm.CurUserName = TextBox1.Text
        MainForm.Show()
        noe = 1
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub BootForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If noe = 0 Then
            e.Cancel = True
            Try
                Shell(MainForm.NSPath & "cmd.exe /c taskkill.exe /f /im """ & MainForm.NSudoName & """", AppWinStyle.Hide, True)
                Shell("cmd.exe /c taskkill.exe /f /im """ & MainForm.NSudoName & """", AppWinStyle.Hide, True)
                System.IO.File.Delete(Application.StartupPath & "\" & MainForm.NSudoName)
            Catch ex As Exception
                MessageBox.Show("删除临时文件 " & Application.StartupPath & "\" & MainForm.NSudoName & " 时发生错误。" & vbCrLf & ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            End
        End If
    End Sub

    Private Sub BootForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        noe = 0
        MainForm.NSudoName = "NSudoLG_" & MainForm.RndString(15) & ".exe"
        If System.Environment.Is64BitOperatingSystem = True Then
            ResByteWrite(My.Resources.NSudoLG64, Application.StartupPath & "\" & MainForm.NSudoName)
        Else
            ResByteWrite(My.Resources.NSudoLG32, Application.StartupPath & "\" & MainForm.NSudoName)
        End If
        If System.IO.File.Exists(Application.StartupPath & "\" & MainForm.NSudoName) = False Then
            MessageBox.Show("由于无法释放 " & Application.StartupPath & "\" & MainForm.NSudoName & "！NSudoL 选项将不可用。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MainForm.CheckBox1.Checked = False
            MainForm.CheckBox1.Enabled = False
            TweakForm.CheckBox8.Checked = False
            TweakForm.CheckBox8.Enabled = False
            RegForm.CheckBox8.Checked = False
            RegForm.CheckBox8.Enabled = False
        End If

        If MainForm.CheckBox1.Checked = True Then
            MainForm.NSPath = """" & Application.StartupPath & "\" & MainForm.NSudoName & """ -Wait -U:T -P:E "
        Else
            MainForm.NSPath = ""
        End If
        '第一次运行需要提升权限，提升后获取的是提升权限的用户名
        'TextBox1.Text = System.Environment.UserName
        Dim cursysarch As String
        Dim curapparch As String

        If System.Environment.Is64BitOperatingSystem = True Then
            cursysarch = "x64"
        Else
            cursysarch = "x86"
        End If

        If System.Environment.Is64BitProcess = True Then
            curapparch = "x64"
        Else
            curapparch = "x86"
        End If

        Label5.Text = "当前系统架构为 " & cursysarch & " ，当前程序架构为 " & curapparch & " 。"
    End Sub
End Class
