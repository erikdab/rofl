using System;

namespace ROFL
{
    /// <summary>
    /// Main Menu Game Form.
    /// </summary>
    public partial class Menu : TemplateForm
    {
        public Menu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close Form event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Start New Game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            var form = new NewGame();
            Hide();
            form.ShowDialog();
            Show();
        }
    }
}
