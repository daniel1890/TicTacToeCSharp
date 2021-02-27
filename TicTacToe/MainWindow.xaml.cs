using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// Bewaart de huidige cellen in het actieve spel
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// Waar wanneer het de beurt van speler 1 is en false wanneer speler 2 aan de beurt is
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// Waar wanneer het spel beïndigd is
        /// </summary>
        private bool mGameEnded;

        #endregion Private Members

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        #endregion Constructor

        private void NewGame()
        {
            // Creeër een lege array met lege cellen
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Leeg;
            }

            // Speler 1 maakt de eerste zet
            mPlayer1Turn = true;

            // Loop door elk element wat zich bevind in het grid genaamd container....
            Container.Children.Cast<Button>().ToList().ForEach(Button =>
            {
                // Verander de achtergrond, voorgrond en content naar de default waarden
                Button.Content = string.Empty;
                Button.Background = Brushes.White;
                Button.Foreground = Brushes.Blue;
            });

            // Zorg ervoor dat de game niet zomaar eindigd
            mGameEnded = false;
        }
    }
}