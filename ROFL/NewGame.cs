using System;
using System.Windows.Forms;
using Engine;

namespace ROFL
{
    /// <summary>
    /// New Game Form.
    /// </summary>
    public partial class NewGame : TemplateForm
    {
        public NewGame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close Form event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Start Game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            var playerName = textBoxPlayerName.Text;

            if (playerName == "")
            {
                MessageBox.Show("Player Name cannot be empty!", "Empty Name");
            }
            else
            {
                // Show Scenario first
                var formScenario = new Scenario();
                Hide();
                formScenario.ShowDialog();

                // Create new Character and Game
                var character = new Character(playerName, EntityType.Character);
                var game = new Game(character);

                // Then open the Game Screen
                var formGame = new GameScreen(game);
                formGame.ShowDialog();
                Close();
            }
        }
    }
}
