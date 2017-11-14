// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SplashScreen.cs" company="The Silly Company">
//   The Silly Company 2016. All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SillyCompany.Mobile.Practices.Droid
{
    using System;

    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Support.V7.App;
    using Android.Util;
    using Android.Views;
    
    [Activity(
        Theme = "@style/ZoliTheme.Splash", 
        MainLauncher = true,
        NoHistory = true, 
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            this.SetContentView(this.LayoutInflater.Inflate(Resource.Layout.Splash, (ViewGroup)null));
        }

        protected override async void OnResume()
        {
            base.OnResume();

            try
            {
                await
                    DroidEntryPointSingleton.EnsureInitialized(
                        () => this.RunOnUiThread(() => this.StartActivity(typeof(MainActivity))));
            }
            catch (Exception exception)
            {
                Log.Error("silly", $"Exception while initializing app: {exception.Message}");
                throw;
            }
        }
    }
}