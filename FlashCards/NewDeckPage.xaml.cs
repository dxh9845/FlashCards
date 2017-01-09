using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.Storage;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCards
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewDeckPage : Page
    {

        public NewDeckPage()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// Create a folder for the deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Create_Deck(object sender, RoutedEventArgs e)
        {
            string DeckName = this.deckName.Text;
            if (String.IsNullOrEmpty(DeckName))
            {
                throw new NotImplementedException();
            }
            else
            {
                StorageFolder folder = null;
                try
                {
                    folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(DeckName, CreationCollisionOption.FailIfExists);
                    this.Frame.Navigate(typeof(CreateFlashCard), folder.Name);

                } catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

    }
}
