using System;

namespace ROFL
{
    /// <summary>
    /// Scenario Game Form.
    /// </summary>
    public partial class Scenario : TemplateForm
    {
        public Scenario()
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
