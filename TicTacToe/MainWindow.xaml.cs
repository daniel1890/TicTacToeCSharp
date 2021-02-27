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

        /// <summary>
        /// Start een nieuw spel en reset alle waarden aan het begin
        /// </summary>
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

        /// <summary>
        /// Deze methode wordt aangeroepen wanneer een knop geklikt wordt
        /// </summary>
        /// <param name="sender">De knop die geklikt was</param>
        /// <param name="e">De events die bij de klik horen</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            // Cast de sender naar een knop
            var button = (Button)sender;

            // Vind de positie van de knop binnen de array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // Doe niks wanneer de cell al een waarde bevat
            if (mResults[index] != MarkType.Leeg)
                return;

            // Zet de waarde van de cell gebasseerd op welke speler aan de beurt is
            mResults[index] = mPlayer1Turn ? MarkType.Kruis : MarkType.Rondje;

            // Zet de knop text naar het resultaat
            button.Content = mPlayer1Turn ? "X" : "O";

            // Verander de rondjes in groen
            if (!mPlayer1Turn)
                button.Foreground = Brushes.Red;

            // toggle tussen de beurten van de spelers
            mPlayer1Turn ^= true;
        }
    }
}