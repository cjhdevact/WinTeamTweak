Public Class TweakForm
    Public a As Integer
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If a = 0 Then
            If CheckBox8.Checked = True Then
                MainForm.NSPath = """" & Application.StartupPath & "\" & MainForm.NSudoName & """ -Wait -U:T -P:E "
            Else
                MainForm.NSPath = ""
            End If
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
            CheckBox5.Enabled = False
            CheckBox6.Enabled = False
            CheckBox7.Enabled = False
            CheckBox8.Enabled = False
            CheckBox9.Enabled = False

            Button16.Enabled = False
            Label1.Visible = True

            If CheckBox3.Checked = True Then
                Label1.Text = "导出策略中..."
                Call MainForm.Button2_Click(sender, e)
            End If
            If CheckBox1.Checked = True Then
                Label1.Text = "删除 Microsoft Edge 策略中..."
                Call MainForm.Button3_Click(sender, e)
            End If
            If CheckBox2.Checked = True Then
                Label1.Text = "删除系统策略中..."
                Call MainForm.Button14_Click(sender, e)
            End If
            If CheckBox4.Checked = True Then
                Label1.Text = "启用任务管理器中..."
                Call MainForm.Button9_Click(sender, e)
            End If
            If CheckBox5.Checked = True Then
                Label1.Text = "修复Win32程序关联中..."
                Call MainForm.Button15_Click(sender, e)
            End If
            If CheckBox6.Checked = True Then
                Label1.Text = "设置shell为explorer中..."
                Call MainForm.Button11_Click(sender, e)
            End If
            If CheckBox7.Checked = True Then
                Label1.Text = "添加当前用户管理员权限中..."
                Call MainForm.Button17_Click(sender, e)
            End If
            If CheckBox9.Checked = True Then
                Label1.Text = "写入 7zFM.exe 到下载目录中..."
                Call MainForm.Button20_Click(sender, e)
            End If
            If MainForm.CheckBox1.Checked = True Then
                MainForm.NSPath = """" & Application.StartupPath & "\" & MainForm.NSudoName & """ -Wait -U:T -P:E "
            Else
                MainForm.NSPath = ""
            End If
            Label1.Text = "优化完成"
            Button16.Text = "关闭"
            Button16.Enabled = True
            a = 1
        Else
            a = 0
            Me.Close()
        End If

    End Sub

    Private Sub TweakForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        a = 0
        Label1.Visible = False
        Button16.Enabled = True
        Button16.Text = "一键优化"
        Label1.Text = "优化中..."
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        CheckBox4.Enabled = True
        CheckBox5.Enabled = True
        CheckBox6.Enabled = True
        CheckBox7.Enabled = True
        CheckBox8.Enabled = True
        CheckBox9.Enabled = True
    End Sub
End Class