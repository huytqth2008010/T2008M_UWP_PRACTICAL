using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using PRACTICAL.Models;
using System.Diagnostics;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PRACTICAL
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<String> imagePaths = new ObservableCollection<String>();
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void ImagesCombo_Loaded(object sender, RoutedEventArgs e)
        {
            string folderPath = "Assets";
            IEnumerable<string> filePaths = await ImageService.GetAssetFiles(folderPath);
            foreach (var filePath in filePaths)
            {
                imagePaths.Add(filePath);
            }
        }

        private void ProductList_Loaded(object sender, RoutedEventArgs e)
        {
            ProductList.Items.Add(new Product
            {
                Name = "Product 1",
                Description = "Lorem ipsum",
                ImagePath = "Assets/image1.jpg"
            });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(ImagesCombo.SelectedValue);
            ProductList.Items.Add(new Product
            {
                Name = NameText.Text,
                Description = DescriptionText.Text,
                ImagePath = (string)ImagesCombo.SelectedValue
            });
        }
    }
}
