using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DandDWristStats;

namespace DandDWristStats
{
    [Activity(Label = "D&D Wrist Stats", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            Button one = FindViewById<Button>(Resource.Id.newcharButton);
            Button two = FindViewById<Button>(Resource.Id.oldcharButton);
          
            one.Click += delegate { StartActivity(typeof(newCharAct)); };
            two.Click += delegate { StartActivity(typeof(oldCharAct)); };
        }
    }
}

