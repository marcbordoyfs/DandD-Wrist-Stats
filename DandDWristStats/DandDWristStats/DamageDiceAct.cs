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
    [Activity(Label = "DamageDiceAct")]
    public class DamageDiceAct : Activity
    {
        Button[] letters = new Button[8];

        long total;
        string charname;
        int[] nums = new int[2];

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DamageDice);
            // Create your application here
            letters[0] = FindViewById<Button>(Resource.Id.buttonD4Damage);
            letters[1] = FindViewById<Button>(Resource.Id.buttonD6Damage);
            letters[2] = FindViewById<Button>(Resource.Id.buttonD8Damage);
            letters[3] = FindViewById<Button>(Resource.Id.buttonD10Damage);
            letters[4] = FindViewById<Button>(Resource.Id.buttonD12Damage);
            letters[5] = FindViewById<Button>(Resource.Id.buttonD20Damage);
            letters[6] = FindViewById<Button>(Resource.Id.buttonD30Damage);
            letters[7] = FindViewById<Button>(Resource.Id.buttonD100Damage);

            total = Intent.GetLongExtra("DamageTotal", 0);
            charname = Intent.GetStringExtra("charname");
            nums = Intent.GetIntArrayExtra("charnums");

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

            if (btn.Id == Resource.Id.buttonD4Damage)
            {
                btn.SetTextColor(Color.Yellow);

                Bundle bun = new Bundle();
                bun.PutLong("TOTAL", total);
                bun.PutString("MyData", "D4");
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);

                Intent activity2 = new Intent(this, typeof(DamageRollAct));
                activity2.PutExtras(bun);
                
                StartActivity((activity2));
                Finish();
            }
            else if (btn.Id == Resource.Id.buttonD6Damage)
            {
                btn.SetTextColor(Color.Yellow);

                Bundle bun = new Bundle();
                bun.PutString("MyData", "D6");
                bun.PutLong("TOTAL", total);
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
                Intent activity2 = new Intent(this, typeof(DamageRollAct));
                activity2.PutExtras(bun);

                StartActivity((activity2));
                Finish();
            }
            else if (btn.Id == Resource.Id.buttonD8Damage)
            {
                btn.SetTextColor(Color.Yellow);

                Bundle bun = new Bundle();
                bun.PutString("MyData", "D8");
                bun.PutLong("TOTAL", total);
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
                Intent activity2 = new Intent(this, typeof(DamageRollAct));
                activity2.PutExtras(bun);

                StartActivity((activity2));
                Finish();
            }
            else if (btn.Id == Resource.Id.buttonD10Damage)
            {
                btn.SetTextColor(Color.Yellow);

                Bundle bun = new Bundle();
                bun.PutString("MyData", "D10");
                bun.PutLong("TOTAL", total);
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
                Intent activity2 = new Intent(this, typeof(DamageRollAct));
                activity2.PutExtras(bun);

                StartActivity((activity2));
                Finish();
            }
            else if (btn.Id == Resource.Id.buttonD12Damage)
            {
                btn.SetTextColor(Color.Yellow);

                Bundle bun = new Bundle();
                bun.PutString("MyData", "D12");
                bun.PutLong("TOTAL", total);
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
                Intent activity2 = new Intent(this, typeof(DamageRollAct));
                activity2.PutExtras(bun);

                StartActivity((activity2));
                Finish();
            }
            else if (btn.Id == Resource.Id.buttonD20Damage)
            {
                btn.SetTextColor(Color.Yellow);

                Bundle bun = new Bundle();
                bun.PutString("MyData", "D20");
                bun.PutLong("TOTAL", total);
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
                Intent activity2 = new Intent(this, typeof(DamageRollAct));
                activity2.PutExtras(bun);

                StartActivity((activity2));
                Finish();
            }
            else if (btn.Id == Resource.Id.buttonD30Damage)
            {
                btn.SetTextColor(Color.Yellow);

                Bundle bun = new Bundle();
                bun.PutString("MyData", "D30");
                bun.PutLong("TOTAL", total);
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
                Intent activity2 = new Intent(this, typeof(DamageRollAct));
                activity2.PutExtras(bun);

                StartActivity((activity2));
                Finish();
            }
            else if (btn.Id == Resource.Id.buttonD100Damage)
            {
                btn.SetTextColor(Color.Yellow);

                Bundle bun = new Bundle();
                bun.PutString("MyData", "D100");
                bun.PutLong("TOTAL", total);
                bun.PutString("charname", charname);
                bun.PutIntArray("charnums", nums);
                Intent activity2 = new Intent(this, typeof(DamageRollAct));
                activity2.PutExtras(bun);

                StartActivity((activity2));
                Finish();
            }
        }

    }
}