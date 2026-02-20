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

namespace MatchGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }

        private void SetUpGame()
        {
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
            
            foreach(TextBlock textblock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = gerador.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textblock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }
    }
}