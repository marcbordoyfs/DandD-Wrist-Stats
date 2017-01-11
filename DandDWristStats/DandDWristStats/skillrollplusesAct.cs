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
    [Activity(Label = "skillrollplusesAct")]
    public class skillrollplusesAct : Activity
    {
        Button[] buttons = new Button[3];
        bool disadvon = false;
        bool advon = false;
        CheckBox prof;
        CheckBox doubleprof;

        string charname;
        string skillname;
        int[] nums = new int[2];

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.skillrollpulses);

            buttons[0] = FindViewById<Button>(Resource.Id.Advantagebutton);
            buttons[1] = FindViewById<Button>(Resource.Id.Disadvantagebutton);
            buttons[2] = FindViewById<Button>(Resource.Id.continuebutton);
            prof = FindViewById<CheckBox>(Resource.Id.checkBoxprof);
            doubleprof = FindViewById<CheckBox>(Resource.Id.checkBox2xprof);

            charname = Intent.GetStringExtra("charname") ?? "";
            nums = Intent.GetIntArrayExtra("charnums");
            skillname = Intent.GetStringExtra("skillname") ?? "";

            buttons[0].Click += dis_advantageclicked;
            buttons[1].Click += dis_advantageclicked;
            buttons[2].Click += whenbuttonpressed;

            prof.Click += checkprof;
            doubleprof.Click += checkdoubleprof;

        }
        private void checkprof(object sender, EventArgs c)
        {
            if (!prof.Checked)
            {
                prof.Checked = false;
                doubleprof.Checked = false;
            }
            else
            {
                prof.Checked = true;
            }
        }
        private void checkdoubleprof(object sender, EventArgs c)
        {
            if (prof.Checked)
            {
                if (doubleprof.Checked)
                {
                    doubleprof.Checked = true;
                }
                else
                {
                    doubleprof.Checked = false;
                }
            }
            else
            {
                doubleprof.Checked = false;
            }

        }

        private void dis_advantageclicked(object sender, EventArgs c)
        {
            Button btn = (Button)sender;
            buttons[0].SetTextColor(Color.White);
            buttons[1].SetTextColor(Color.White);
            if (btn.Id == Resource.Id.Advantagebutton)
            {
                advon = !advon;
                if (advon == true)
                {
                    buttons[0].SetTextColor(Color.Yellow);
                    disadvon = false;
                    buttons[1].SetTextColor(Color.White);
                }
            }
            else if (btn.Id == Resource.Id.Disadvantagebutton)
            {
                disadvon = !disadvon;
                if (disadvon == true)
                {
                    buttons[1].SetTextColor(Color.Yellow);
                    advon = false;
                    buttons[0].SetTextColor(Color.White);
                }
            }

        }

        private void whenbuttonpressed(object sender, EventArgs c)
        {
            Bundle bun = new Bundle();
            bool[] checks = new bool[4];
            checks[0] = advon;
            checks[1] = disadvon;
            checks[2] = prof.Checked;
            checks[3] = doubleprof.Checked;

            bun.PutIntArray("charnums", nums);
            bun.PutString("charname", charname);
            bun.PutString("skillname", skillname);
            bun.PutBooleanArray("checks", checks);

            Intent activity3 = new Intent(this, typeof(RollingforskillsAct));
            activity3.PutExtras(bun);
            StartActivity((activity3));
            Finish();
        }


    }
}