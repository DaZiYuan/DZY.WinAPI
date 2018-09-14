﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace DZY.WinAPI
{
    /// <summary>Values to pass to the GetDCEx method.</summary>
    [Flags()]
    public enum DeviceContextValues : uint
    {
        /// <summary>DCX_WINDOW: Returns a DC that corresponds to the window rectangle rather
        /// than the client rectangle.</summary>
        Window = 0x00000001,

        /// <summary>DCX_CACHE: Returns a DC from the cache, rather than the OWNDC or CLASSDC
        /// window. Essentially overrides CS_OWNDC and CS_CLASSDC.</summary>
        Cache = 0x00000002,

        /// <summary>DCX_NORESETATTRS: Does not reset the attributes of this DC to the
        /// default attributes when this DC is released.</summary>
        NoResetAttrs = 0x00000004,

        /// <summary>DCX_CLIPCHILDREN: Excludes the visible regions of all child windows
        /// below the window identified by hWnd.</summary>
        ClipChildren = 0x00000008,

        /// <summary>DCX_CLIPSIBLINGS: Excludes the visible regions of all sibling windows
        /// above the window identified by hWnd.</summary>
        ClipSiblings = 0x00000010,

        /// <summary>DCX_PARENTCLIP: Uses the visible region of the parent window. The
        /// parent's WS_CLIPCHILDREN and CS_PARENTDC style bits are ignored. The origin is
        /// set to the upper-left corner of the window identified by hWnd.</summary>
        ParentClip = 0x00000020,

        /// <summary>DCX_EXCLUDERGN: The clipping region identified by hrgnClip is excluded
        /// from the visible region of the returned DC.</summary>
        ExcludeRgn = 0x00000040,

        /// <summary>DCX_INTERSECTRGN: The clipping region identified by hrgnClip is
        /// intersected with the visible region of the returned DC.</summary>
        IntersectRgn = 0x00000080,

        /// <summary>DCX_EXCLUDEUPDATE: Unknown...Undocumented</summary>
        ExcludeUpdate = 0x00000100,

        /// <summary>DCX_INTERSECTUPDATE: Unknown...Undocumented</summary>
        IntersectUpdate = 0x00000200,

        /// <summary>DCX_LOCKWINDOWUPDATE: Allows drawing even if there is a LockWindowUpdate
        /// call in effect that would otherwise exclude this window. Used for drawing during
        /// tracking.</summary>
        LockWindowUpdate = 0x00000400,

        /// <summary>DCX_USESTYLE: Undocumented, something related to WM_NCPAINT message.</summary>
        UseStyle = 0x00010000,

        /// <summary>DCX_VALIDATE When specified with DCX_INTERSECTUPDATE, causes the DC to
        /// be completely validated. Using this function with both DCX_INTERSECTUPDATE and
        /// DCX_VALIDATE is identical to using the BeginPaint function.</summary>
        Validate = 0x00200000,
    }

    public enum WindowLongFlags : int
    {
        GWL_EXSTYLE = -20,
        GWLP_HINSTANCE = -6,
        GWLP_HWNDPARENT = -8,
        GWL_ID = -12,
        GWL_STYLE = -16,
        GWL_USERDATA = -21,
        GWL_WNDPROC = -4,
        DWLP_USER = 0x8,
        DWLP_MSGRESULT = 0x0,
        DWLP_DLGPROC = 0x4
    }

    [Flags()]
    public enum SetWindowPosFlags : uint
    {
        /// <summary>If the calling thread and the thread that owns the window are attached to different input queues,
        /// the system posts the request to the thread that owns the window. This prevents the calling thread from
        /// blocking its execution while other threads process the request.</summary>
        /// <remarks>SWP_ASYNCWINDOWPOS</remarks>
        AsynWindowPos = 0x4000,

        /// <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
        /// <remarks>SWP_DEFERERASE</remarks>
        DeferErase = 0x2000,

        /// <summary>Draws a frame (defined in the window's class description) around the window.</summary>
        /// <remarks>SWP_DRAWFRAME</remarks>
        DrawFrame = 0x0020,

        /// <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to
        /// the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE
        /// is sent only when the window's size is being changed.</summary>
        /// <remarks>SWP_FRAMECHANGED</remarks>
        FrameChanged = 0x0020,

        /// <summary>Hides the window.</summary>
        /// <remarks>SWP_HIDEWINDOW</remarks>
        HideWindow = 0x0080,

        /// <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the
        /// top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter
        /// parameter).</summary>
        /// <remarks>SWP_NOACTIVATE</remarks>
        NoActivate = 0x0010,

        /// <summary>Discards the entire contents of the client area. If this flag is not specified, the valid
        /// contents of the client area are saved and copied back into the client area after the window is sized or
        /// repositioned.</summary>
        /// <remarks>SWP_NOCOPYBITS</remarks>
        NoCopyBits = 0x0100,

        /// <summary>Retains the current position (ignores X and Y parameters).</summary>
        /// <remarks>SWP_NOMOVE</remarks>
        NoMove = 0x0002,

        /// <summary>Does not change the owner window's position in the Z order.</summary>
        /// <remarks>SWP_NOOWNERZORDER</remarks>
        NoOwnerZOrder = 0x0200,

        /// <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to
        /// the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent
        /// window uncovered as a result of the window being moved. When this flag is set, the application must
        /// explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
        /// <remarks>SWP_NOREDRAW</remarks>
        NoRedraw = 0x0008,

        /// <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
        /// <remarks>SWP_NOREPOSITION</remarks>
        NoReposition = 0x0200,

        /// <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
        /// <remarks>SWP_NOSENDCHANGING</remarks>
        NoSendChanging = 0x0400,

        /// <summary>Retains the current size (ignores the cx and cy parameters).</summary>
        /// <remarks>SWP_NOSIZE</remarks>
        NoSize = 0x0001,

        /// <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
        /// <remarks>SWP_NOZORDER</remarks>
        NoZOrder = 0x0004,

        /// <summary>Displays the window.</summary>
        /// <remarks>SWP_SHOWWINDOW</remarks>
        ShowWindow = 0x0040
    }

    public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left, Top, Right, Bottom;

        public RECT(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public RECT(System.Drawing.Rectangle r)
            : this(r.Left, r.Top, r.Right, r.Bottom)
        {
        }

        public int X
        {
            get { return Left; }
            set { Right -= (Left - value); Left = value; }
        }

        public int Y
        {
            get { return Top; }
            set { Bottom -= (Top - value); Top = value; }
        }

        public int Height
        {
            get { return Bottom - Top; }
            set { Bottom = value + Top; }
        }

        public int Width
        {
            get { return Right - Left; }
            set { Right = value + Left; }
        }

        public System.Drawing.Point Location
        {
            get { return new System.Drawing.Point(Left, Top); }
            set { X = value.X; Y = value.Y; }
        }

        public System.Drawing.Size Size
        {
            get { return new System.Drawing.Size(Width, Height); }
            set { Width = value.Width; Height = value.Height; }
        }

        public static implicit operator System.Drawing.Rectangle(RECT r)
        {
            return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
        }

        public static implicit operator RECT(System.Drawing.Rectangle r)
        {
            return new RECT(r);
        }

        public static bool operator ==(RECT r1, RECT r2)
        {
            return r1.Equals(r2);
        }

        public static bool operator !=(RECT r1, RECT r2)
        {
            return !r1.Equals(r2);
        }

        public bool Equals(RECT r)
        {
            return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
        }

        public override bool Equals(object obj)
        {
            if (obj is RECT)
                return Equals((RECT)obj);
            else if (obj is System.Drawing.Rectangle)
                return Equals(new RECT((System.Drawing.Rectangle)obj));
            return false;
        }

        public override int GetHashCode()
        {
            return ((System.Drawing.Rectangle)this).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
        }
    }

    [Flags]
    public enum RedrawWindowFlags : uint
    {
        /// <summary>
        /// Invalidates the rectangle or region that you specify in lprcUpdate or hrgnUpdate.
        /// You can set only one of these parameters to a non-NULL value. If both are NULL, RDW_INVALIDATE invalidates the entire window.
        /// </summary>
        Invalidate = 0x1,

        /// <summary>Causes the OS to post a WM_PAINT message to the window regardless of whether a portion of the window is invalid.</summary>
        InternalPaint = 0x2,

        /// <summary>
        /// Causes the window to receive a WM_ERASEBKGND message when the window is repainted.
        /// Specify this value in combination with the RDW_INVALIDATE value; otherwise, RDW_ERASE has no effect.
        /// </summary>
        Erase = 0x4,

        /// <summary>
        /// Validates the rectangle or region that you specify in lprcUpdate or hrgnUpdate.
        /// You can set only one of these parameters to a non-NULL value. If both are NULL, RDW_VALIDATE validates the entire window.
        /// This value does not affect internal WM_PAINT messages.
        /// </summary>
        Validate = 0x8,

        NoInternalPaint = 0x10,

        /// <summary>Suppresses any pending WM_ERASEBKGND messages.</summary>
        NoErase = 0x20,

        /// <summary>Excludes child windows, if any, from the repainting operation.</summary>
        NoChildren = 0x40,

        /// <summary>Includes child windows, if any, in the repainting operation.</summary>
        AllChildren = 0x80,

        /// <summary>Causes the affected windows, which you specify by setting the RDW_ALLCHILDREN and RDW_NOCHILDREN values, to receive WM_ERASEBKGND and WM_PAINT messages before the RedrawWindow returns, if necessary.</summary>
        UpdateNow = 0x100,

        /// <summary>
        /// Causes the affected windows, which you specify by setting the RDW_ALLCHILDREN and RDW_NOCHILDREN values, to receive WM_ERASEBKGND messages before RedrawWindow returns, if necessary.
        /// The affected windows receive WM_PAINT messages at the ordinary time.
        /// </summary>
        EraseNow = 0x200,

        Frame = 0x400,

        NoFrame = 0x800
    }

    [Flags]
    public enum SendMessageTimeoutFlags : uint
    {
        SMTO_NORMAL = 0x0,
        SMTO_BLOCK = 0x1,
        SMTO_ABORTIFHUNG = 0x2,
        SMTO_NOTIMEOUTIFNOTHUNG = 0x8,
        SMTO_ERRORONEXIT = 0x20
    }

    public enum SetWinEventHookEventType : uint
    {
        EVENT_MIN = 0x00000001,
        EVENT_MAX = 0x7FFFFFFF,
        EVENT_SYSTEM_SOUND = 0x00000001,
        EVENT_SYSTEM_ALERT = 0x00000002,
        EVENT_SYSTEM_FOREGROUND = 0x00000003,
        EVENT_SYSTEM_MENUSTART = 0x00000004,
        EVENT_SYSTEM_MENUEND = 0x00000005,
        EVENT_SYSTEM_MENUPOPUPSTART = 0x00000006,
        EVENT_SYSTEM_MENUPOPUPEND = 0x00000007,
        EVENT_SYSTEM_CAPTURESTART = 0x00000008,
        EVENT_SYSTEM_CAPTUREEND = 0x00000009,
        EVENT_SYSTEM_MOVESIZESTART = 0x0000000A,
        EVENT_SYSTEM_MOVESIZEEND = 0x0000000B,
        EVENT_SYSTEM_CONTEXTHELPSTART = 0x0000000C,
        EVENT_SYSTEM_CONTEXTHELPEND = 0x0000000D,
        EVENT_SYSTEM_DRAGDROPSTART = 0x0000000E,
        EVENT_SYSTEM_DRAGDROPEND = 0x0000000F,
        EVENT_SYSTEM_DIALOGSTART = 0x00000010,
        EVENT_SYSTEM_DIALOGEND = 0x00000011,
        EVENT_SYSTEM_SCROLLINGSTART = 0x00000012,
        EVENT_SYSTEM_SCROLLINGEND = 0x00000013,
        EVENT_SYSTEM_SWITCHSTART = 0x00000014,
        EVENT_SYSTEM_SWITCHEND = 0x00000015,
        /// <summary>
        /// 窗口最小化
        /// </summary>
        EVENT_SYSTEM_MINIMIZESTART = 0x00000016,
        EVENT_SYSTEM_MINIMIZEEND = 0x00000017,
        EVENT_CONSOLE_CARET = 0x00004001,
        EVENT_CONSOLE_UPDATE_REGION = 0x00004002,
        EVENT_CONSOLE_UPDATE_SIMPLE = 0x00004003,
        EVENT_CONSOLE_UPDATE_SCROLL = 0x00004004,
        EVENT_CONSOLE_LAYOUT = 0x00004005,
        EVENT_CONSOLE_START_APPLICATION = 0x00004006,
        EVENT_CONSOLE_END_APPLICATION = 0x00004007,
        EVENT_OBJECT_CREATE = 0x00008000,
        EVENT_OBJECT_DESTROY = 0x00008001,
        EVENT_OBJECT_SHOW = 0x00008002,
        EVENT_OBJECT_HIDE = 0x00008003,
        EVENT_OBJECT_REORDER = 0x00008004,
        EVENT_OBJECT_FOCUS = 0x00008005,
        EVENT_OBJECT_SELECTION = 0x00008006,
        EVENT_OBJECT_SELECTIONADD = 0x00008007,
        EVENT_OBJECT_SELECTIONREMOVE = 0x00008008,
        EVENT_OBJECT_SELECTIONWITHIN = 0x00008009,
        EVENT_OBJECT_STATECHANGE = 0x0000800A,
        EVENT_OBJECT_LOCATIONCHANGE = 0x0000800B,
        EVENT_OBJECT_NAMECHANGE = 0x0000800C,
        EVENT_OBJECT_DESCRIPTIONCHANGE = 0x0000800D,
        EVENT_OBJECT_VALUECHANGE = 0x0000800E,
        EVENT_OBJECT_PARENTCHANGE = 0x0000800F,
        EVENT_OBJECT_HELPCHANGE = 0x00008010,
        EVENT_OBJECT_DEFACTIONCHANGE = 0x00008011,
        EVENT_OBJECT_ACCELERATORCHANGE = 0x00008012
    }

    public delegate void SetWinEventHookDelegate(IntPtr hook, SetWinEventHookEventType eventType,
    IntPtr window, int objectId, int childId, uint threadId, uint time);

    [Flags]
    public enum SetWinEventHookFlag : uint
    {
        WINEVENT_OUTOFCONTEXT = 0x0,
        WINEVENT_SKIPOWNTHREAD = 0x1,
        WINEVENT_SKIPOWNPROCESS = 0x2,
        WINEVENT_INCONTEXT = 0x4
    }

    public struct POINT
    {
        public long x;
        public long y;
    }

    public struct WINDOWPLACEMENT
    {
        public uint length;
        public uint flags;
        public uint showCmd;
        public POINT ptMinPosition;
        public POINT ptMaxPosition;
        public RECT rcNormalPosition;
    }

    //https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagwindowplacement#SW_SHOWMAXIMIZED
    [Flags]
    public enum WINDOWPLACEMENTFlags
    {
        SW_HIDE = 0,
        SW_MAXIMIZE = 3,
        SW_MINIMIZE = 6,
        SW_RESTORE = 9,
        SW_SHOW = 5,
        SW_SHOWMAXIMIZED = 3,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOWNORMAL = 1
    }

    public class USER32Wrapper
    {
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_UPDATEINIFILE = 0x01;
        public const uint SPI_GETDESKWALLPAPER = 0x0073;

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr window, out uint processId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWinEventHook(SetWinEventHookEventType eventTypeMin,
            SetWinEventHookEventType eventTypeMax, IntPtr library, SetWinEventHookDelegate handler,
            uint processId, uint threadId, SetWinEventHookFlag flags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnhookWinEvent(IntPtr hook);


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);


        /// <summary>
        /// Changes an attribute of the specified window. The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs..</param>
        /// <param name="nIndex">GWL_EXSTYLE, GWL_HINSTANCE, GWL_ID, GWL_STYLE, GWL_USERDATA, GWL_WNDPROC </param>
        /// <param name="dwNewLong">The replacement value.</param>
        /// <returns>If the function succeeds, the return value is the previous value of the specified 32-bit integer.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. </returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, WindowLongFlags nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, StringBuilder vParam, UInt32 winIni);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr parentHandle, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);

        [DllImport("user32.dll")]
        public static extern uint GetClassLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);

        public static string GetWindowText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            if (size > 0)
            {
                var builder = new StringBuilder(size + 1);
                GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }

            return string.Empty;
        }

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, DeviceContextValues flags);

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetShellWindow();

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int abc);

        [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
        public static extern IntPtr GetWindowDC(Int32 ptr);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, [In] ref RECT lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hwnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(IntPtr windowHandle, uint Msg, IntPtr wParam, IntPtr lParam, SendMessageTimeoutFlags flags, uint timeout, out IntPtr result);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    }
}