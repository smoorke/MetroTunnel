<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tmrTick = New System.Windows.Forms.Timer(Me.components)
        Me.trayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RunMetro2033ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitMetroTunnelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsTray.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrTick
        '
        Me.tmrTick.Enabled = True
        Me.tmrTick.Interval = 666
        '
        'trayIcon
        '
        Me.trayIcon.ContextMenuStrip = Me.cmsTray
        Me.trayIcon.Icon = CType(resources.GetObject("trayIcon.Icon"), System.Drawing.Icon)
        Me.trayIcon.Text = "MetroTunnel"
        Me.trayIcon.Visible = True
        '
        'cmsTray
        '
        Me.cmsTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunMetro2033ToolStripMenuItem, Me.ToolStripMenuItem1, Me.QuitMetroTunnelToolStripMenuItem})
        Me.cmsTray.Name = "cmsTray"
        Me.cmsTray.Size = New System.Drawing.Size(169, 54)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 6)
        '
        'RunMetro2033ToolStripMenuItem
        '
        Me.RunMetro2033ToolStripMenuItem.Image = Global.MetroTunnel.My.Resources.Resources.MetroIco
        Me.RunMetro2033ToolStripMenuItem.Name = "RunMetro2033ToolStripMenuItem"
        Me.RunMetro2033ToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.RunMetro2033ToolStripMenuItem.Text = "Run Metro 2033"
        '
        'QuitMetroTunnelToolStripMenuItem
        '
        Me.QuitMetroTunnelToolStripMenuItem.Image = Global.MetroTunnel.My.Resources.Resources.Close
        Me.QuitMetroTunnelToolStripMenuItem.Name = "QuitMetroTunnelToolStripMenuItem"
        Me.QuitMetroTunnelToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.QuitMetroTunnelToolStripMenuItem.Text = "Quit MetroTunnel"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Name = "frmMain"
        Me.Opacity = 0R
        Me.Text = "MetroTunnel"
        Me.cmsTray.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tmrTick As Timer
    Friend WithEvents trayIcon As NotifyIcon
    Friend WithEvents cmsTray As ContextMenuStrip
    Friend WithEvents RunMetro2033ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents QuitMetroTunnelToolStripMenuItem As ToolStripMenuItem
End Class
