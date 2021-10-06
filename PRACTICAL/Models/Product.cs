using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace PRACTICAL.Models
{
    class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public BitmapImage Image
        {
            get => new BitmapImage(new Uri("ms-appx:///" + ImagePath));
        }
    }
}
