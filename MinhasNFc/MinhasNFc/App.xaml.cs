using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MinhasNFc.Views;
using MinhasNFc.Helpers.Database;

using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

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
            SolicitaPermissoesAsync();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private async void SolicitaPermissoesAsync()
        {

            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            if (cameraStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
                cameraStatus = results[Permission.Camera];
            }

            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                storageStatus = results[Permission.Storage];
            }

            if (storageStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                //await DisplayAlert("Permissões", "Acesse suas configurações e ative as permissões", "Ok");
            }
        }
    }
}
