Public Class RegForm
    Public NSPath2 As String
    Private Sub RegForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CheckBox8.Checked = True Then
            MainForm.NSPath = """" & Application.StartupPath & "\" & MainForm.NSudoName & """ -Wait -U:T -P:E "
        Else
            MainForm.NSPath = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Shell(NSPath2 & "cmd.exe /c REG ADD ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion"" /v RegisteredOwner /t REG_SZ /d """ & TextBox1.Text & """ /f", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If Environment.Is64BitOperatingSystem = True Then
            Try
                Shell(NSPath2 & "cmd.exe /c REG ADD ""HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion"" /v RegisteredOwner /t REG_SZ /d """ & TextBox1.Text & """ /f", AppWinStyle.Hide, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        MessageBox.Show("已写入注册用户信息。" & vbCrLf & "注册表位置：HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion" & vbCrLf & "键名：RegisteredOwner" & vbCrLf & "类型：REG_SZ" & vbCrLf & "值：" & TextBox1.Text, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If Environment.Is64BitOperatingSystem = True Then
            MessageBox.Show("已写入注册用户信息。" & vbCrLf & "注册表位置：HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion" & vbCrLf & "键名：RegisteredOwner" & vbCrLf & "类型：REG_SZ" & vbCrLf & "值：" & TextBox1.Text, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Shell(NSPath2 & "cmd.exe /c REG ADD ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion"" /v RegisteredOrganization /t REG_SZ /d """ & TextBox2.Text & """ /f", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If Environment.Is64BitOperatingSystem = True Then
            Try
                Shell(NSPath2 & "cmd.exe /c REG ADD ""HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion"" /v RegisteredOrganization /t REG_SZ /d """ & TextBox2.Text & """ /f", AppWinStyle.Hide, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        MessageBox.Show("已写入注册组织信息。" & vbCrLf & "注册表位置：HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion" & vbCrLf & "键名：RegisteredOrganization" & vbCrLf & "类型：REG_SZ" & vbCrLf & "值：" & TextBox2.Text, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If Environment.Is64BitOperatingSystem = True Then
            MessageBox.Show("已写入注册组织信息。" & vbCrLf & "注册表位置：HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion" & vbCrLf & "键名：RegisteredOrganization" & vbCrLf & "类型：REG_SZ" & vbCrLf & "值：" & TextBox2.Text, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Shell(NSPath2 & "cmd.exe /c REG DELETE ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion"" /v RegisteredOwner /f", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If Environment.Is64BitOperatingSystem = True Then
            Try
                Shell(NSPath2 & "cmd.exe /c REG DELETE ""HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion"" /v RegisteredOwner /f", AppWinStyle.Hide, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        MessageBox.Show("已删除注册用户信息。" & vbCrLf & "注册表位置：HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion" & vbCrLf & "键名：RegisteredOwner", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If Environment.Is64BitOperatingSystem = True Then
            MessageBox.Show("已删除注册用户信息。" & vbCrLf & "注册表位置：HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion" & vbCrLf & "键名：RegisteredOwner", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Shell(NSPath2 & "cmd.exe /c REG DELETE ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion"" /v RegisteredOrganization /f", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If Environment.Is64BitOperatingSystem = True Then
            Try
                Shell(NSPath2 & "cmd.exe /c REG DELETE ""HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion"" /v RegisteredOrganization /f", AppWinStyle.Hide, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        MessageBox.Show("已删除注册组织信息。" & vbCrLf & "注册表位置：HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion" & vbCrLf & "键名：RegisteredOrganization", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If Environment.Is64BitOperatingSystem = True Then
            MessageBox.Show("已删除组织用户信息。" & vbCrLf & "注册表位置：HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion" & vbCrLf & "键名：RegisteredOrganization", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked = True Then
            MainForm.NSPath = """" & Application.StartupPath & "\" & MainForm.NSudoName & """ -Wait -U:T -P:E "
        Else
            MainForm.NSPath = ""
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If MessageBox.Show("确定要恢复默认值吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call Button3_Click(sender, e)
            Call Button4_Click(sender, e)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TextBox3.Text = "SH-" & MainForm.RndString(12).ToUpper
    End Sub
End Class