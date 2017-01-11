using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DandDWristStats;

namespace DandDWristStats
{
    [Activity(Label = "OptionsAct")]
    public class OptionsAct : Activity
    {
        Button[] options = new Button[3];
        string charname;
        int[] nums = new int[2];

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Options);
            // Create your application here
            options[0] = FindViewById<Button>(Resource.Id.buttonswitch);
            options[1] = FindViewById<Button>(Resource.Id.buttonmain);
            options[2] = FindViewById<Button>(Resource.Id.buttonroll);

            charname = Intent.GetStringExtra("charname");
            nums = Intent.GetIntArrayExtra("charnums");
           
            options[0].Click += delegate {  Finish(); StartActivity(typeof(oldCharAct)); };  //SetResult(Result.Ok);
            options[1].Click += delegate {  Finish(); StartActivity(typeof(MainActivity)); }; //SetResult(Result.Ok);
            options[2].Click += rolltypepressed;
        }
        private void rolltypepressed(object sender, EventArgs c)
        {
            Bundle bun = new Bundle();
            bun.PutString("charname", charname);
            bun.PutIntArray("charnums", nums);
            Intent activity3 = new Intent(this, typeof(RollTypeAct));
            activity3.PutExtras(bun);
            StartActivity((activity3));

            Finish();
            
            //if (rolltype == 1)
            //{
            //    Intent myIntent = new Intent(this, typeof(DiceRollingAct));
            //    SetResult(Result.Ok, myIntent);
            //    Finish();
            //}
            //else if (rolltype == 2)
            //{
            //    Intent myIntent = new Intent(this, typeof(DamageRollAct));
            //    SetResult(Result.Ok, myIntent);
            //    Finish();
            //}
            //else if (rolltype == 3)
            //{
            //    Intent myIntent = new Intent(this, typeof(RollingforskillsAct));
            //    SetResult(Result.Ok, myIntent);
            //    Finish();
            //}

        }


    }
}