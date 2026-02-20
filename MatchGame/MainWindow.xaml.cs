using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MatchGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            InitializeComponent();

            SetUpGame();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            TimeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                TimeTextBlock.Text = TimeTextBlock.Text + " - Jogar Novamente?";
            }
        }

        private void SetUpGame()
        {
            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;

            List<string> animalEmoji = new List<string>()
            {
                "🐶", "🐶",
                "🐱", "🐱",
                "🐭", "🐭",
                "🐹", "🐹",
                "🐰", "🐰",
                "🦊", "🦊",
                "🐻", "🐻",
                "🐼", "🐼"
            };
            Random gerador = new Random();
            
            foreach (TextBlock textblock in mainGrid.Children.OfType<TextBlock>())
            {
                if(textblock.Name == "TimeTextBlock")
                {
                    continue;
                }
                else
                {
                int index = gerador.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textblock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }
    }

        TextBlock LastTextBlockClicked;
        bool findingMatch = false;
        private int matchesFound;
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        TextBlock TempoAnterior;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Opacity = 0.2;
                LastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == LastTextBlockClicked.Text)
            {
                textBlock.Opacity = 0.2;
                matchesFound++;
                findingMatch = false;
            }
            else
            {
                LastTextBlockClicked.Opacity = 1.0;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}