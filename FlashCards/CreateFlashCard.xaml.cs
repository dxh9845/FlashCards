using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCards
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateFlashCard : Page
    {

        // The name of the folder where the coloring page is saved in the app's Local folder
        private string _FolderName;

        public CreateFlashCard()
        {
            this.InitializeComponent();

            // Initialize the InkCanvas controls
            InitializeInkCanvases();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string text = e.Parameter.ToString();
            _FolderName = text;

            int CardNum = int.Parse(CardNumber.Text);
            int CardTotalNum = int.Parse(CardTotal.Text);
            // Check to enable the Forward/Back buttons
            EnableButtonCheck(CardNum, CardTotalNum);
        }

        private void EnableButtonCheck(int CardNumber, int CardTotal)
        {
            // Are we at the first card? Then we can't go back

            BackButton.IsEnabled = CardNumber == 1 ? false : true;
            ForwardButton.IsEnabled = CardNumber == CardTotal ? false : true;

            // Disable the add button until we know we are at the very end
            AddButton.IsEnabled = CardNumber == CardTotal ? true : false;
        }

        private void InitializeInkCanvases()
        {
            // Initialize the InkCanvas controls
            inkCanvas.InkPresenter.InputDeviceTypes =
            inkCanvas2.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen;

            inkCanvas.InkPresenter.UnprocessedInput.PointerEntered += UnprocessedInput_PointerEntered;
            inkCanvas2.InkPresenter.UnprocessedInput.PointerEntered += UnprocessedInput_PointerEntered1;
        }

        private void UnprocessedInput_PointerEntered(InkUnprocessedInput sender, PointerEventArgs args)
        {
            frontBorder.BorderBrush = new SolidColorBrush(Colors.Orange);
            backBorder.BorderBrush = new SolidColorBrush(Colors.Gray);
            inkToolbar.TargetInkCanvas = inkCanvas;
        }

        private void UnprocessedInput_PointerEntered1(InkUnprocessedInput sender, PointerEventArgs args)
        {
            frontBorder.BorderBrush = new SolidColorBrush(Colors.Gray);
            backBorder.BorderBrush = new SolidColorBrush(Colors.Orange);
            inkToolbar.TargetInkCanvas = inkCanvas2;
        }

        // On size change of app
        private void OnSizeChange(object sender, SizeChangedEventArgs e)
        {
            SetCanvasSize();
        }

        private void SetCanvasSize()
        {
            frontGrid.Width = RootGrid.ActualWidth / 2;
            frontGrid.Height = RootGrid.ActualHeight / 2;
            inkCanvas.Width = RootGrid.ActualWidth / 2;
            inkCanvas.Height = RootGrid.ActualHeight / 2;
            backGrid.Width = RootGrid.ActualWidth / 2;
            backGrid.Height = RootGrid.ActualHeight / 2;
            inkCanvas2.Width = RootGrid.ActualWidth / 2;
            inkCanvas2.Height = RootGrid.ActualHeight / 2;
        }


        /// <summary>
        /// Load a certain CardNumber
        /// </summary>
        /// <param name="CardNumber"></param>
        private async void LoadCard(int CardIndex)
        {
            try
            {
                StorageFolder folder = await ApplicationData.Current.LocalFolder.GetFolderAsync(_FolderName);
                StorageFile frontFile = await folder.GetFileAsync("Card" + CardIndex + "A.gif");
                StorageFile backFile = await folder.GetFileAsync("Card" + CardIndex + "B.gif");
                if (frontFile != null)
                {
                    IRandomAccessStream stream = await frontFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    using (var inputStream = stream.GetInputStreamAt(0))
                    {
                        await inkCanvas.InkPresenter.StrokeContainer.LoadAsync(stream);
                    }
                    stream.Dispose();
                }

                if (backFile != null)
                {
                    IRandomAccessStream stream = await backFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    using (var inputStream = stream.GetInputStreamAt(0))
                    {
                        await inkCanvas2.InkPresenter.StrokeContainer.LoadAsync(stream);
                    }
                    stream.Dispose();
                }

                // We have successfully loaded both cards, now change CardNumber
                CardNumber.Text = CardIndex.ToString();
            }
            catch (Exception ex)
            {
                // We went forward without saving 
                CardNumber.Text = CardIndex.ToString();
                Debug.WriteLine(ex);
            }
        }

        private void ClearCanvases()
        {
            inkCanvas.InkPresenter.StrokeContainer.Clear();
            inkCanvas2.InkPresenter.StrokeContainer.Clear();
        }

        private async void AddToDeck(object sender, RoutedEventArgs e)
        {
            // If there was ink on the canvases
            if (inkCanvas.InkPresenter.StrokeContainer.GetStrokes().Count > 0 
                && inkCanvas2.InkPresenter.StrokeContainer.GetStrokes().Count > 0)
            {
                // Save the cards and wait to finish
                await SaveCard();

                // Now make way for new InkCanvases
                ClearCanvases();

                // We added a new card! Add one to the number
                int CardInt = int.Parse(CardNumber.Text) + 1;

                // Change the new Card Number
                CardNumber.Text =  CardInt.ToString();

                // Add 1 to the CardTotal
                int CardTotalInt = int.Parse(CardTotal.Text) + 1;
                CardTotal.Text = CardTotalInt.ToString();

                // Reevaluate button availability 
                EnableButtonCheck(CardInt, CardTotalInt);

            }
            // The user is adding a new card without drawing on the old one
            else
            {
                return;   
            }

            
        }

        /// <summary>
        /// Get the previous card, if available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetPreviousCard(object sender, RoutedEventArgs e)
        {
            // Get the card number
            int currentCardNumber = int.Parse(CardNumber.Text);
            int totalCardNumber = int.Parse(CardTotal.Text);
            if (currentCardNumber == 1)
            {
                return;
            }
            else
            {
                // Save the existing card
                await SaveCard();
                // Now Clear the Canvas to ensure it is fresh
                ClearCanvases();
                // Then Load the previous
                LoadCard(currentCardNumber-1);
                // Reevaluate button availability
                EnableButtonCheck(currentCardNumber -1, totalCardNumber);

            }
        }


        /// <summary>
        /// Get the next card, if available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetNextCard(object sender, RoutedEventArgs e)
        {
            // Get the card number
            int currentCardNumber = int.Parse(CardNumber.Text);
            int totalCardNumber = int.Parse(CardTotal.Text);
            if (currentCardNumber == totalCardNumber)
            {
                return;
            }
            else
            {
                // Save the existing card
                await SaveCard();
                // Now Clear the Canvas to ensure it is fresh
                ClearCanvases();
                // Then load the next
                LoadCard(currentCardNumber+1);
                // Reevaluate button availability 
                EnableButtonCheck(currentCardNumber+1, totalCardNumber);
            }
        }


        /// <summary>
        /// Save the canvases to GIF files in the deck's folder.
        /// </summary>
        /// <param name="FolderName"> The folder to save the files in</param>
        /// <param name="CardIndex">The "number" of the card that is being saved</param>
        public async Task SaveCard()
        {
            // Find existing folder
            StorageFolder folder = await ApplicationData.Current.LocalFolder.GetFolderAsync(_FolderName);
            if (folder == null)
            {
                // Error!
            }
            else
            {
                // Get the card index 
                int CardIndex = int.Parse(CardNumber.Text);
                // Use a utility function to write to files
                if (inkCanvas.InkPresenter.StrokeContainer.GetStrokes().Count > 0
                    && inkCanvas2.InkPresenter.StrokeContainer.GetStrokes().Count > 0)
                {
                    await WriteWithStream(folder, CardIndex, 'A', inkCanvas.InkPresenter);
                    await WriteWithStream(folder, CardIndex, 'B', inkCanvas2.InkPresenter);
                }
                    

            }

        }

        /// <summary>
        /// Write an InkCanvas to GIF using streams
        /// </summary>
        /// <param name="folder">The folder we are writing to</param>
        /// <param name="CardIndex">The number of the Card</param>
        /// <param name="Letter">A or B depending on Front or Back</param>
        /// <param name="FrontOrBack">The InkPresenter object for the front or back of the card</param>
        /// <returns></returns>
        private async Task WriteWithStream(StorageFolder folder, int CardIndex, char Letter, InkPresenter FrontOrBack)
        {
            // Generate the ink files, A and B
            StorageFile inkFile = await folder.CreateFileAsync("Card" + CardIndex + Letter + ".gif", CreationCollisionOption.ReplaceExisting);
            // Prevent changes until we're done
            //CachedFileManager.DeferUpdates(inkFile);
            // Open a stream
            IRandomAccessStream stream = await inkFile.OpenAsync(FileAccessMode.ReadWrite);
            // Write out using the stream
            using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
            {
                await FrontOrBack.StrokeContainer.SaveAsync(outputStream);
                await outputStream.FlushAsync();
            }
            // Dispose of the stream
            stream.Dispose();
            // We are now done with the file
            Windows.Storage.Provider.FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(inkFile);
        }

    }
}
