using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MinhasNFc.Views;
using MinhasNFc.Helpers.Database;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MinhasNFc
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var db = new Db();
            db.VerificarTabelas();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
