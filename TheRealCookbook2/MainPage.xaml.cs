using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;




// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TheRealCookbook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage : Page
    {


        public MainPage()
        {
            this.InitializeComponent();
        }
        //Get our api key 
        public static string KGetter()
        {
            var reasources = new Windows.ApplicationModel.Resources.ResourceLoader("Resources");
            string key = reasources.GetString("Key1");

            return key;
        }
        //this is the get Recipes button click event----- gets url and title--- serchproxy
        private async void btn1_Click(object sender, RoutedEventArgs e)
        {
            SearchProxyClass.ProxyClass.RootObject SearchObject = await SearchProxyClass.SearchObject(txtbox1.Text);
            hyperlinkRecipeButton.NavigateUri = new Uri(SearchObject.recipes[0].source_url);
            hyperlinkRecipeButton.Content = SearchObject.recipes[0].title;

            //set image source to populate on application
            string path = SearchObject.recipes[0].image_url;
            BitmapImage bitmap = new BitmapImage(new Uri(path));
            UrlPicture.Source = bitmap;
            // try to get another to populate
            hyperlinkRecipeButton1.NavigateUri = new Uri(SearchObject.recipes[1].source_url);
            hyperlinkRecipeButton1.Content = SearchObject.recipes[1].title;
            //second picture
            string path1 = SearchObject.recipes[1].image_url;
            BitmapImage bitmap1 = new BitmapImage(new Uri(path1));
            UrlPicture1.Source = bitmap1;

        }


        //trying to make hyperlink
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void onRecipeButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {

                Uri uri = new Uri(hyperlinkRecipeButton.NavigateUri.ToString());
                myweb.Navigate(uri);
            }
            catch
            {
            }




        }



    }
}
