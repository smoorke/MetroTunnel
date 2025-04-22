Imports System.Runtime.InteropServices

Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Hide()
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Const WS_EX_TOOLWINDOW As Integer = &H80 ' Creates a tool window (does not appear in the taskbar).  
            Const WS_VISIBLE As Integer = &H10000000
            Const WS_EX_TRANSPARENT As Integer = &H20 ' Makes the window transparent to mouse clicks.  
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or WS_VISIBLE
            cp.ExStyle = cp.ExStyle Or WS_EX_TOOLWINDOW Or WS_EX_TRANSPARENT
            Return cp
        End Get
    End Property

    Protected Overloads Overrides ReadOnly Property ShowWithoutActivation() As Boolean
        Get
            Return True
        End Get
    End Property



    Dim MetroProc As Process = Process.GetProcessesByName("Metro") _
                                .FirstOrDefault(Function(pp) GetClass(pp.MainWindowHandle) = "_uengine_")
    Dim MetroThread = GetWindowThreadProcessId(If(MetroProc?.MainWindowHandle, IntPtr.Zero), Nothing)
    Dim GTI As New GUITHREADINFO With {.cbSize = Marshal.SizeOf(GetType(GUITHREADINFO))}

    Private Async Sub tmrTick_Tick(sender As Object, e As EventArgs) Handles tmrTick.Tick 'every 99 ms
        If MetroProc Is Nothing OrElse MetroProc.HasExited() Then
            Await Task.Run(Sub()
                               MetroProc = Process.GetProcessesByName("Metro") _
                                .FirstOrDefault(Function(pp) GetClass(pp.MainWindowHandle) = "_uengine_")
                               Me.MetroThread = GetWindowThreadProcessId(If(MetroProc?.MainWindowHandle, IntPtr.Zero), Nothing)
                               If MetroProc IsNot Nothing Then Me.Invoke(Sub() RunMetro2033ToolStripMenuItem.Enabled = False)
                           End Sub)
        End If

        If MetroProc Is Nothing OrElse MetroProc.HasExited Then
            RunMetro2033ToolStripMenuItem.Enabled = True
            MetroProc = Nothing
            Me.MetroThread = 0
            Exit Sub
        End If

        'do nothing when user is moving window
        If GetGUIThreadInfo(MetroThread, GTI) AndAlso GTI.flags.HasFlag(GUI_FLAGS.GUI_INMOVESIZE) Then Exit Sub

        'find sysmenu and diable move item
        Dim hSysMenu As IntPtr = GetSystemMenu(If(MetroProc?.MainWindowHandle, IntPtr.Zero), False)
        If hSysMenu <> IntPtr.Zero Then
            EnableMenuItem(hSysMenu, SC_MOVE, MF_BYCOMMAND Or MF_GRAYED)
        End If

        Dim rcc As RECT
        GetClientRect(If(MetroProc?.MainWindowHandle, IntPtr.Zero), rcc)
        If rcc.right = 0 Then 'this needs further testing
            Debug.Print($"METRO isn't windwed {rcc}")
            Exit Sub
        End If

        Dim rcw As RECT
        GetWindowRect(If(MetroProc?.MainWindowHandle, IntPtr.Zero), rcw)
        Dim ptCTL As Point
        ClientToScreen(If(MetroProc?.MainWindowHandle, IntPtr.Zero), ptCTL)

        'check if caption is off screen
        Dim scrn As Screen = Screen.FromPoint(ptCTL)
        Dim work As Rectangle = scrn.WorkingArea()
        If Not work.Contains(New Point(rcw.left, rcw.top)) Then
            'move window to make catpion vis
            SetWindowPos(If(MetroProc?.MainWindowHandle, IntPtr.Zero), HWND_TOP,
                         rcw.left, Math.Max(work.Top, rcw.top),
                         -1, -1,
                         SWP_NOSIZE Or SWP_NOZORDER Or SWP_NOACTIVATE)
        End If

    End Sub

    Private Sub QuitMetroTunnelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitMetroTunnelToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub RunMetroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunMetro2033ToolStripMenuItem.Click
        'https://store.steampowered.com/app/286690/Metro_2033_Redux/
        Dim pp As Process = Nothing
        Try
            pp = Process.Start("explorer", "steam://rungameid/286690")
        Catch ex As Exception
            Debug.Print($"bab0 starting Metro2033 {ex.Message}")
        Finally
            pp?.Dispose()
        End Try
    End Sub

End Class