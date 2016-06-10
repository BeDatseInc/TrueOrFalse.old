using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;

namespace TrueOrFalse.Droid
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(1000);
            StartActivity(new Intent(Application.Context,typeof(MainActivity)));
        }
    }
}