using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace ROFL
{
    public partial class CharacterInfo : UserControl
    {
        /// <summary>
        /// Player Character.
        /// </summary>
        public Character Player { get; private set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public CharacterInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize CharacterInfo with player.
        /// </summary>
        /// <param name="player"></param>
        public void InitializeCharacterInfo(Character player)
        {
            Player = player;
        }
        
        /// <summary>
        /// Update Player Panel Controls.
        /// </summary>
        public void UpdateInfo()
        {
            // If received experience for more than 1 level, upgrade multiple times.
            while (Player.LevelUpRemainingCost == 0)
            {
                Player.LevelUpTry();
            }

            labelCharacterName.Text = Player.Name;

            labelCharacterLevel.Text = Player.Level.ToString();
            labelCharacterMoney.Text = $"{Player.Money:C}";

            progressBarCharacterHealth.Maximum = Player.MaxHealth;
            progressBarCharacterHealth.Value = Player.Health;
            toolTipInfo.SetToolTip(progressBarCharacterHealth, HealthDescriptor());

            progressBarCharacterExperience.Maximum = Player.LevelUpCost;
            progressBarCharacterExperience.Value = Player.Experience;
            toolTipInfo.SetToolTip(progressBarCharacterExperience,
                $"You still need {Player.LevelUpRemainingCost} Experience to Level Up.");
        }
        
        /// <summary>
        /// Description of Health Status.
        /// </summary>
        /// <returns>Health Descriptor</returns>
        public string HealthDescriptor()
        {
            var percentage = (double)Player.Health / Player.MaxHealth;
            var healthPoints = $" ({Player.Health}/{Player.MaxHealth})";

            if (percentage >= 1.0)
            {
                return $"You are at full Health.{healthPoints}";
            }

            if (percentage >= 0.8)
            {
                return $"You are at good Health.{healthPoints}";
            }

            if (percentage >= 0.6)
            {
                return $"You are wounded.{healthPoints}";
            }

            if (percentage >= 0.4)
            {
                return $"You need healing!{healthPoints}";
            }

            if (percentage >= 0.2)
            {
                return $"You are gravely wounded!{healthPoints}";
            }

            if (percentage > 0.0)
            {
                return $"Get to safety!{healthPoints}";
            }

            return "You are dead!";
        }
    }
}
