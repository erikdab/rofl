using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ROFL
{
    /// <summary>
    /// Base Game Form contains shared functionality between forms.
    /// 
    /// Currently this includes mouse drag handling.
    /// </summary>
    public class TemplateForm : Form
    {
        /// <inheritdoc />
        /// <summary>
        /// Override WndProc function to enable dragging without the Title Bar.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84)
                m.Result = (IntPtr)(0x2);
        }

        /// <summary>
        /// Enable/Disable Fullscreen mode.
        /// </summary>
        /// <param name="fullscreen">Whether to enable Fullscreen.</param>
        protected void GoFullscreen(bool fullscreen)
        {
            WindowState = fullscreen ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        /// <summary>
        /// Toggle Fullscreen mode.
        /// </summary>
        protected void ToggleFullscreen()
        {
            GoFullscreen(! IsFullscreen());
        }

        /// <summary>
        /// Is Form Fullscreen.
        /// </summary>
        /// <returns></returns>
        protected bool IsFullscreen()
        {
            return WindowState == FormWindowState.Maximized;
        }
    }
}
