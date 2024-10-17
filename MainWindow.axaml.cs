using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSVPLibrary;

namespace RSVPAvalonia
{
    public partial class MainWindow : Window
    {
        private RSVPProcessor _processor;
        private TextBlock _wordTextBlock;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _processor = new RSVPProcessor();
            _wordTextBlock = this.FindControl<TextBlock>("WordTextBlock");

            // Example: Input some text directly
            _processor.InputText("This is a sample text for the transparent background RSVP display.", false);

            // Start the display process
            _ = DisplayWordsAsync();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private async Task DisplayWordsAsync()
        {
            string word;
            while ((word = _processor.Next()) != null)
            {
                _wordTextBlock.Text = word;

                // Adjust the delay time here as needed
                await Task.Delay(200);
            }

            // Optionally close or reset the app when done
            //this.Close();
        }
    }
}
