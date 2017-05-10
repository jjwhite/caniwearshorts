using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;

namespace CanIWearShorts.droid
{
    [Activity(Label = "Can I Wear Shorts Today?", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            WebView webView = FindViewById<WebView>(Resource.Id.LocalWebView);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
            webView.Settings.SetGeolocationEnabled(true);            
            webView.SetWebChromeClient(new GeoWebChromeClient());
            webView.LoadUrl("https://jjwhite.github.io");

        }

        
    }

    public class GeoWebChromeClient : WebChromeClient
    {
        public override void OnGeolocationPermissionsShowPrompt(string origin, GeolocationPermissions.ICallback callback)
        {
            callback.Invoke(origin, true, false);
        }

    }
}

