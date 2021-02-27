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

            // Vind de positie van de knop binnen de array en declareer een index waarde aan de geselecteerde knop
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);

            // Doe niks wanneer de cell al een waarde bevat
            if (mResults[index] != MarkType.Leeg)
                return;

            // Zet de waarde van de cell gebasseerd op welke speler aan de beurt is
            mResults[index] = mPlayer1Turn ? MarkType.Kruis : MarkType.Rondje;

            // Zet de knop text naar het resultaat
            // Kort geschreven maar kan ook geschreven worden als if (mPlayer1Turn) { button.Content = "X"} else....
            button.Content = mPlayer1Turn ? "X" : "O";

            // Verander de rondjes in groen wanneer speler 2 aan de beurt is
            if (!mPlayer1Turn)
                button.Foreground = Brushes.Red;

            // toggle tussen de beurten van de spelers
            mPlayer1Turn ^= true;

            // Wanneer een zet gedaan is checked het programma of de huidige set een winning move is
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            #region horizontale wins

            // Check voor horizontale wins (met een & operator wordt alleen true returned wanneer alle waarden gelijk aan elke zijn binnen de statement)
            //
            // - Rij 0
            //
            if (mResults[0] != MarkType.Leeg && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                // Het spel beëindigd
                mGameEnded = true;

                // Highlight de winnende cellen in groen
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            //
            // - Rij 1
            //
            if (mResults[3] != MarkType.Leeg && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                // Het spel beëindigd
                mGameEnded = true;

                // Highlight de winnende cellen in groen
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            //
            // - Rij 2
            //
            if (mResults[6] != MarkType.Leeg && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                // Het spel beëindigd
                mGameEnded = true;

                // Highlight de winnende cellen in groen
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion horizontale wins

            #region verticale wins

            // Check voor verticale wins (met een & operator wordt alleen true returned wanneer alle waarden gelijk aan elke zijn binnen de statement)
            //
            // - Column 0
            //
            if (mResults[0] != MarkType.Leeg && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                // Het spel beëindigd
                mGameEnded = true;

                // Highlight de winnende cellen in groen
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            //
            // - Column 1
            //
            if (mResults[1] != MarkType.Leeg && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                // Het spel beëindigd
                mGameEnded = true;

                // Highlight de winnende cellen in groen
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            //
            // - Column 2
            //
            if (mResults[2] != MarkType.Leeg && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                // Het spel beëindigd
                mGameEnded = true;

                // Highlight de winnende cellen in groen
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion verticale wins

            #region diagonale wins

            //
            // - Diagionaal 0
            //
            if (mResults[0] != MarkType.Leeg && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                // Het spel beëindigd
                mGameEnded = true;

                // Highlight de winnende cellen in groen
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            //
            // - Diagonaal 1
            //
            if (mResults[2] != MarkType.Leeg && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                // Het spel beëindigd
                mGameEnded = true;

                // Highlight de winnende cellen in groen
                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;
            }

            #endregion diagonale wins

            #region geen winnaar

            // Check voor geen winner maar wel een volgespeeld bord
            if (!mResults.Any(result => result == MarkType.Leeg))
            {
                // Game beeïndigd
                mGameEnded = true;

                // Maak alle cellen in het grid oranje
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }

            #endregion geen winnaar
        }
    }
}