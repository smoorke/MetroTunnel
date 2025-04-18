Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting.Messaging

Module NativeMethods
    <DllImport("user32.dll", SetLastError:=True)>
    Public Function GetWindowThreadProcessId(
        hwnd As IntPtr,
        ByRef lpdwProcessId As UInteger) As UInteger
    End Function

    Public Function GetClass(hWnd As IntPtr) As String
        Dim buf As New Text.StringBuilder(256)
        GetClassName(hWnd, buf, buf.Capacity)
        Return buf.ToString
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Function GetClassName(
        hwnd As IntPtr,
        lpClassName As Text.StringBuilder,
        nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function GetWindowRect(hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function
    <DllImport("user32.dll", SetLastError:=True)>
    Public Function GetClientRect(hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function
    <DllImport("user32.dll", SetLastError:=True)>
    Public Function ClientToScreen(hWnd As IntPtr, ByRef lpPoint As Point) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    ' SetWindowPos declaration
    <DllImport("user32.dll", SetLastError:=True)>
    Public Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr, X As Integer, Y As Integer, cx As Integer, cy As Integer, uFlags As UInteger) As Boolean
    End Function
    Public Const HWND_TOP = 0 ' Places the window at the top of the Z order
    Public Const SWP_NOSIZE As UInteger = &H1 ' Retains the current size
    Public Const SWP_NOZORDER As UInteger = &H4 ' Retains the current Z order
    Public Const SWP_NOACTIVATE As UInteger = &H10 ' Prevents the window from being activated.
    Public Const SWP_ASYNCWINDOWPOS As UInteger = &H4000 ' Moves the window asynchronously

    <StructLayout(LayoutKind.Sequential)>
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
        Public Function ToRectangle() As Rectangle
            Return Rectangle.FromLTRB(Me.left, Me.top, Me.right, Me.bottom)
        End Function
    End Structure

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function GetGUIThreadInfo(
                    idThread As UInteger,
                    ByRef lpgui As GUITHREADINFO) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)>
    Public Structure GUITHREADINFO
        Public cbSize As Integer
        Public flags As GUI_FLAGS
        Public hwndActive As IntPtr
        Public hwndFocus As IntPtr
        Public hwndCapture As IntPtr
        Public hwndMenuOwner As IntPtr
        Public hwndMoveSize As IntPtr
        Public hwndCaret As IntPtr
        Public rcCaret As RECT
    End Structure

    <Flags>
    Public Enum GUI_FLAGS As UInteger
        GUI_NONE = &H0
        GUI_CARETBLINKING = &H1 ' The caret is blinking.
        GUI_INMOVESIZE = &H2 ' The thread is in a move or size loop.
        GUI_INMENUMODE = &H4 ' The thread is in menu mode.
        GUI_SYSTEMMENUMODE = &H8 ' The thread is in the system menu mode.
        GUI_POPUPMENUMODE = &H10 ' The thread is in a popup menu loop.
    End Enum

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Function SendMessage(hWnd As IntPtr, Msg As UInteger, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    ' Constants for SendMessage
    Public Const WM_SYSCOMMAND As UInteger = &H112 ' System command message
    Public Const SC_MOVE As UInteger = &HF010 ' Move command
    Public Const SC_MINIMIZE As UInteger = &HF020 ' System command for minimizing a window


    <DllImport("user32.dll", SetLastError:=True)>
    Public Function GetSystemMenu(hWnd As IntPtr, bRevert As Boolean) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function EnableMenuItem(hMenu As IntPtr, uIDEnableItem As UInteger, uEnable As UInteger) As Boolean
    End Function

    ' Constants for EnableMenuItem
    Public Const MF_BYCOMMAND As UInteger = &H0 ' Indicates that uIDEnableItem gives the command ID
    Public Const MF_GRAYED As UInteger = &H1 ' Disables the menu item and grays it out

End Module
