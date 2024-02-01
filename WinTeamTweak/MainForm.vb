Public Class MainForm
    Public CurUserName As String
    Public NSPath As String
    Public NSudoName As String
    Function RndString(ByVal l As Integer) As String
        Randomize()
        Dim R, i As Integer
        Dim S As Char
        Dim returnStr As String
        returnStr = ""
        'a-z 的ASCII码是：97-122
        'A-Z 的ASCII码是：65-90
        '0-9 的ASCII码是：48-57
        For i = 1 To l
            R = Int(Rnd() * 62) '随机生成的字符有大小写字母和数字，共有26个
            If R < 10 Then '如果小于10，则是数字 数字的ASCII是48-57 对应 随机数字 0-9 所以要将随机数字加48
                S = Chr(R + 48) 'Chr 是将把数字按Ascii码转换为对应的字符
            ElseIf R < 36 Then '如果小于36，则是大写字母 大写字母的ASCII是65-90 对应 随机数字10-35 所以要将随机数字加55
                S = Chr(R + 55)
            Else '如果大于36，则是小写字母 小写字母的ASCII是97-122 对应 随机数字36-62 所以要将随机数字加61
                S = Chr(R + 61)
            End If
            returnStr = returnStr + S
        Next
        RndString = returnStr
    End Function
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CheckBox1.Checked = True Then
            NSPath = """" & Application.StartupPath & "\" & NSudoName & """ -Wait -U:T -P:E "
        Else
            NSPath = ""
        End If
        Label1.Text = "当前默认用户名为：" & CurUserName
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
            Try
            Shell(NSPath & "cmd.exe /c taskkill.exe /f /im """ & Application.StartupPath & "\" & NSudoName & """", AppWinStyle.Hide, True)
            System.IO.File.Delete(Application.StartupPath & "\" & NSudoName)
            Catch ex As Exception
                MessageBox.Show("删除临时文件 " & Application.StartupPath & "\" & NSudoName & " 时发生错误。" & vbCrLf & ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            NSPath = """" & Application.StartupPath & "\" & NSudoName & """ -Wait -U:T -P:E "
        Else
            NSPath = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Shell("winver.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Shell(NSPath & "cmd.exe /c REG EXPORT HKEY_LOCAL_MACHINE\SOFTWARE\Policies ""%userprofile%\..\" & CurUserName & "\Downloads\WinTeamPolicies-HKLM1_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell(NSPath & "cmd.exe /c REG EXPORT HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Policies ""%userprofile%\..\" & CurUserName & "\Downloads\WinTeamPolicies-HKLM2_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell(NSPath & "cmd.exe /c REG EXPORT HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies ""%userprofile%\..\" & CurUserName & "\Downloads\WinTeamPolicies-HKLM3_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell("cmd.exe /c REG EXPORT HKEY_CURRENT_USER\SOFTWARE\Policies ""%userprofile%\..\" & CurUserName & "\Downloads\WinTeamPolicies-HKCR1_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell("cmd.exe /c REG EXPORT HKEY_CURRENT_USER\SOFTWARE\Microsoft\Policies ""%userprofile%\..\" & CurUserName & "\Downloads\WinTeamPolicies-HKCR2_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell("cmd.exe /c REG EXPORT HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies ""%userprofile%\..\" & CurUserName & "\Downloads\WinTeamPolicies-HKCR3_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell("cmd.exe /c REG EXPORT ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Group Policy Objects"" ""%userprofile%\..\" & CurUserName & "\Downloads\WinTeamPolicies-HKCR4_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell(NSPath & "cmd.exe /c REG EXPORT ""HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Group Policy Objects"" ""%userprofile%\..\" & CurUserName & "\Downloads\WinTeamPolicies-HKLM4_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MessageBox.Show("导出任务执行完毕，策略备份文件已导出到下载目录的WinTeamPolicies-XXXX_XXXXX.reg。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Shell("cmd.exe /c REG EXPORT ""HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge"" ""%userprofile%\..\" & CurUserName & "\Downloads\EdgePolicies-HKCR1_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell(NSPath & "cmd.exe /c REG EXPORT ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\MicrosoftEdge"" ""%userprofile%\..\" & CurUserName & "\Downloads\EdgePolicies-HKLM1_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell("cmd.exe /c REG EXPORT ""HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Edge"" ""%userprofile%\..\" & CurUserName & "\Downloads\EdgePolicies-HKCR2_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell(NSPath & "cmd.exe /c REG EXPORT ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge"" ""%userprofile%\..\" & CurUserName & "\Downloads\EdgePolicies-HKLM2_" & RndString(5) & ".reg"" /y", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell(NSPath & "cmd.exe /c REG DELETE ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\MicrosoftEdge"" /f", AppWinStyle.NormalFocus, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell("cmd.exe /c REG DELETE ""HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\MicrosoftEdge"" /f", AppWinStyle.NormalFocus, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell(NSPath & "cmd.exe /c REG DELETE ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge"" /f", AppWinStyle.NormalFocus, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell("cmd.exe /c REG DELETE ""HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Edge"" /f", AppWinStyle.NormalFocus, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MessageBox.Show("删除任务执行完毕，策略备份文件已导出到下载目录的EdgePolicies-XXXX_XXXXX.reg。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Shell("explorer.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Shell(NSPath & "cmd.exe /c taskkill /f /im ppishell.exe", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell("explorer.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Shell(NSPath & "cmd.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Shell("notepad.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Shell(NSPath & "cmd.exe /c REG ADD ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"" /v DisableTaskMgr /t REG_DWORD /d 0 /f", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MessageBox.Show("已启用任务管理器", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Shell(NSPath & "regedit.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Shell(NSPath & "taskmgr.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If CheckBox1.Enabled = False Then
            MessageBox.Show("由于无法释放 " & Application.StartupPath & "\" & NSudoName & "，无法使用 NSudoL 提升权限。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("当前仅支持导出策略配置、删除 Edge 策略、启用任务管理器、运行Cmd、运行注册表编辑器、运行任务管理器、设置shell、删除系统策略、添加（删除）当前用户管理员权限、修复Win32程序关联、运行计算机管理、运行UAC设置、修改注册信息使用高级权限，需要本程序以管理员身份启动。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Public Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            Shell(NSPath & "cmd.exe /c REG ADD ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\winlogon"" /v Shell /t REG_SZ /d ""explorer.exe"" /f", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MessageBox.Show("已设置默认shell为explorer.exe，重启生效。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            Shell(NSPath & "cmd.exe /c REG ADD ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\winlogon"" /v Shell /t REG_SZ /d ""ppishell.exe"" /f", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MessageBox.Show("已设置默认shell为ppishell.exe，重启生效。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            Shell(NSPath & "cmd.exe /c taskkill /f /im explorer.exe", AppWinStyle.Hide, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Shell("ppishell.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If MessageBox.Show("建议在删除前备份一下策略，确定要删除系统策略吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Shell(NSPath & "cmd.exe /c REG ADD ""HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer"" /v DisableContextMenusInStart /t REG_DWORD /d 0 /f", AppWinStyle.NormalFocus, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                Shell(NSPath & "cmd.exe /c REG ADD ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Programs"" /v NoProgramsCPL /t REG_DWORD /d 0 /f", AppWinStyle.NormalFocus, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                Shell(NSPath & "cmd.exe /c REG DELETE ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer"" /f", AppWinStyle.NormalFocus, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                Shell(NSPath & "cmd.exe /c REG DELETE ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Associations"" /f", AppWinStyle.NormalFocus, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                Shell(NSPath & "cmd.exe /c REG DELETE ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\CredUI"" /f", AppWinStyle.NormalFocus, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            MessageBox.Show("删除策略执行完毕。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Public Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim regname As String
        regname = "FixReg_" & RndString(20) & ".reg"
        Try
            ResStrWrite(My.Resources.RegisteredApplications, Application.StartupPath & "\" & regname)
            If MessageBox.Show("Windows Team的Win32程序默认没有被注册。" & vbCrLf & "确定要修复注册吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Shell(NSPath & "regedit.exe /s """ & Application.StartupPath & "\" & regname & """", AppWinStyle.Hide, True, 5)
                MessageBox.Show("修复关联执行完毕。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            IO.File.Delete(Application.StartupPath & "\" & regname)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        TweakForm.ShowDialog()
    End Sub

    Public Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If MessageBox.Show("将当前用户" & CurUserName & "添加到Administrators用户组可以提升当前用户权限。" & vbCrLf & "此操作必须使用NSudo提升权限（如果是以普通用户身份运行）" & vbCrLf & "你要将当前用户添加Administrators用户组吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Shell(NSPath & "cmd.exe /c net LOCALGROUP Administrators " & CurUserName & " /add", AppWinStyle.NormalFocus, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If MessageBox.Show("将当前用户" & CurUserName & "保留在Users用户组可能会降低当前用户权限。" & vbCrLf & "你要将当前用户从Users用户组移除吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Try
                    Shell(NSPath & "cmd.exe /c net LOCALGROUP Users " & CurUserName & " /delete", AppWinStyle.NormalFocus, True)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        MessageBox.Show("Windows Team（协同版）优化工具" & vbCrLf & "版本：" & My.Application.Info.Version.ToString & vbCrLf & vbCrLf & "版权所有 © 2024 CJH。保留所有权利。" & vbCrLf & vbCrLf & "Github：https://github.com/cjhdevact/WinTeamTweak" & vbCrLf & vbCrLf & "Tips：Ctrl + C 复制这段文字。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Try
            Shell(NSPath & "UserAccountControlSettings.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Try
            Shell(NSPath & "mmc.exe compmgmt.msc", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        If MessageBox.Show("该操作会将 7-Zip 23.01 的管理器写入到下载目录，通过该程序，你可以浏览C盘等被限制访问的目录。" & vbCrLf & "你确定要写入吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If System.Environment.Is64BitOperatingSystem = True Then
                ResByteWrite(My.Resources._7zFM64, System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) & "\..\..\" & CurUserName & "\Downloads\7zFM_" & RndString(5) & ".exe")
                MessageBox.Show("已写入7zFM_XXXXX.exe！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ResByteWrite(My.Resources._7zFM32, System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) & "\..\..\" & CurUserName & "\Downloads\7zFM_" & RndString(5) & ".exe")
                MessageBox.Show("已写入7zFM_XXXXX.exe！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        RegForm.ShowDialog()
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Dim regname As String
        regname = "Policies_" & RndString(20) & ".reg"
        Try
            ResStrWrite(My.Resources.RegisteredApplications, Application.StartupPath & "\" & regname)
            If MessageBox.Show("本策略文件是从Windows Team 22000.1 版本提取的，其他版本使用可能有差异，可能会造成一些问题。" & vbCrLf & "确定要导入原始策略吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Shell(NSPath & "regedit.exe /s """ & Application.StartupPath & "\" & regname & """", AppWinStyle.Hide, True, 5)
                MessageBox.Show("导入原始策略执行完毕。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            IO.File.Delete(Application.StartupPath & "\" & regname)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        If MessageBox.Show("将当前用户" & CurUserName & "恢复默认权限会降低当前用户权限。" & vbCrLf & "你要恢复当前用户默认权限吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Shell(NSPath & "cmd.exe /c net LOCALGROUP Administrators " & CurUserName & " /delete", AppWinStyle.NormalFocus, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Try
                Shell(NSPath & "cmd.exe /c net LOCALGROUP Users " & CurUserName & " /add", AppWinStyle.NormalFocus, True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class