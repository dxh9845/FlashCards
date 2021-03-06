﻿using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCards
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OpenDeck : Page
    {
        public OpenDeck()
        {
            this.InitializeComponent();

            GetFolders();
        }

        private async void GetFolders()
        {

            //List<FolderViewItem> decks 
            IReadOnlyList<StorageFolder> decks = await ApplicationData.Current.LocalFolder.GetFoldersAsync();

            DeckGrid.ItemsSource = decks.ToList();

        }

        private void GoToDeck(object sender, ItemClickEventArgs e)
        {
            var folder = (StorageFolder) e.ClickedItem;
            this.Frame.Navigate(typeof(CreateFlashCard), folder);
        }
    }

    internal class FolderViewItem
    {
        public string FolderName { get; set; }
        public int FolderCount { get; set; }

        public FolderViewItem()
        {
        }
    }

}
