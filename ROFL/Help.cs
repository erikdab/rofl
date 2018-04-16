using System;

namespace ROFL
{
    /// <summary>
    /// Help Game Form.
    /// </summary>
    public partial class Help : TemplateForm
    {
        public Help()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close Form Button handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
