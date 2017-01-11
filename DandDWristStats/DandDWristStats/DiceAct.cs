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
using Android.Graphics;
using DandDWristStats;

namespace DandDWristStats
{
    [Activity(Label = "DiceAct")]
    public class DiceAct : Activity
    {
        Button[] letters = new Button[8];
        string charname;
        int[] nums = new int[2];
        int rolltype;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Dicelayout);
            // Create your application here
            letters[0] = FindViewById<Button>(Resource.Id.buttonD4);
            letters[1] = FindViewById<Button>(Resource.Id.buttonD6);
            letters[2] = FindViewById<Button>(Resource.Id.buttonD8);
            letters[3] = FindViewById<Button>(Resource.Id.buttonD10);
            letters[4] = FindViewById<Button>(Resource.Id.buttonD12);
            letters[5] = FindViewById<Button>(Resource.Id.buttonD20);
            letters[6] = FindViewById<Button>(Resource.Id.buttonD30);
            letters[7] = FindViewById<Button>(Resource.Id.buttonD100);

            charname = Intent.GetStringExtra("charname");
            nums = Intent.GetIntArrayExtra("charnums");
            rolltype = Intent.GetIntExtra("rolltype",0);

            for (int i = 0; i < 8; i++)
            {
                letters[i].Click += whenbuttonpressed;
            }

        }
        private void whenbuttonpressed(object sender, EventArgs c)
        {
            Button btn = (Button)sender;
            for (int i = 0; i < 8; i++)
            {
                letters[i].SetTextColor(Color.White);
            }

            Bundle bun = new Bundle();

            if (btn.Id == Resource.Id.buttonD4)
            {
                btn.SetTextColor(Color.Yellow); 
                bun.PutString("MyData", "D4");
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
            }
            else if (btn.Id == Resource.Id.buttonD6)
            {
                btn.SetTextColor(Color.Yellow);
                bun.PutString("MyData", "D6");
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
            }
            else if (btn.Id == Resource.Id.buttonD8)
            {
                btn.SetTextColor(Color.Yellow);
                bun.PutString("MyData", "D8");
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
            }
            else if (btn.Id == Resource.Id.buttonD10)
            {
                btn.SetTextColor(Color.Yellow);
                bun.PutString("MyData", "D10");
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
            }
            else if (btn.Id == Resource.Id.buttonD12)
            {
                btn.SetTextColor(Color.Yellow);
                bun.PutString("MyData", "D12");
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
            }
            else if (btn.Id == Resource.Id.buttonD20)
            {
                btn.SetTextColor(Color.Yellow);
                bun.PutString("MyData", "D20");
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
            }
            else if (btn.Id == Resource.Id.buttonD30)
            {
                btn.SetTextColor(Color.Yellow);
                bun.PutString("MyData", "D30");
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
            }
            else if (btn.Id == Resource.Id.buttonD100)
            {
                btn.SetTextColor(Color.Yellow);
                bun.PutString("MyData", "D100");
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
            }

            if (rolltype == 1)
            {
                Intent activity2 = new Intent(this, typeof(DiceRollingAct));
                activity2.PutExtras(bun);
                StartActivity((activity2));
                Finish();
            }
            else if (rolltype == 2)
            {
                Intent activity2 = new Intent(this, typeof(RollingforskillsAct));
                activity2.PutExtras(bun);
                StartActivity((activity2));
                Finish();
            }
        }
    }
}