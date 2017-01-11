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
    [Activity(Label = "statpickAct")]
    public class statpickAct : Activity
    {
        Button done;
        RadioGroup group;
        CheckBox prof;

        string charname;
        int[] nums = new int[8];
        int type;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.statpick);
            group = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            done = FindViewById<Button>(Resource.Id.continuebutton);
            prof = FindViewById<CheckBox>(Resource.Id.profcheckBox);

            charname = Intent.GetStringExtra("charname");
            nums = Intent.GetIntArrayExtra("charnums");
            type = Intent.GetIntExtra("type",0);
            // Create your application here
            done.Click += doneClicked;
        }

        private void doneClicked(object sender, EventArgs c)
        {
            RadioButton rad = FindViewById<RadioButton>(group.CheckedRadioButtonId);
            Bundle bun = new Bundle();
            bun.PutString("charname", charname);

            if (rad.Text == "Strength")
            {         
                if (prof.Checked)
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[0];
                    newnums[1] = nums[6];
                    bun.PutIntArray("charnums", newnums);
                }
                else
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[0];
                    newnums[1] = 0;
                    bun.PutIntArray("charnums", newnums);
                }
            }
            else  if (rad.Text == "Intlligence")
            {
                if (prof.Checked)
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[1];
                    newnums[1] = nums[6];
                    bun.PutIntArray("charnums", newnums);
                }
                else
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[1];
                    newnums[1] = 0;
                    bun.PutIntArray("charnums", newnums);
                }
            }
            else if (rad.Text == "Dexterity")
            {
                if (prof.Checked)
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[2];
                    newnums[1] = nums[6];
                    bun.PutIntArray("charnums", newnums);
                }
                else
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[2];
                    newnums[1] = 0;
                    bun.PutIntArray("charnums", newnums);
                }
            }
            else if(rad.Text == "Wisdom")
            {
                if (prof.Checked)
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[3];
                    newnums[1] = nums[6];
                    bun.PutIntArray("charnums", newnums);
                }
                else
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[3];
                    newnums[1] = 0;
                    bun.PutIntArray("charnums", newnums);
                }
            }
            else if(rad.Text == "Constitution")
            {
                if (prof.Checked)
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[4];
                    newnums[1] = nums[6];
                    bun.PutIntArray("charnums", newnums);
                }
                else
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[4];
                    newnums[1] = 0;
                    bun.PutIntArray("charnums", newnums);
                }
            }
            else if(rad.Text == "Charisma")
            {
                if (prof.Checked)
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[5];
                    newnums[1] = nums[6];
                    bun.PutIntArray("charnums", newnums);
                }
                else
                {
                    int[] newnums = new int[2];
                    newnums[0] = nums[5];
                    newnums[1] = 0;
                    bun.PutIntArray("charnums", newnums);
                }
            }


            if (type == 1)
            {
                Intent activity3 = new Intent(this, typeof(DiceRollingAct));
                activity3.PutExtras(bun);
                StartActivity((activity3));
                Finish();
            }
            else if (type == 2)
            {
                Intent activity3 = new Intent(this, typeof(DamageRollAct));
                activity3.PutExtras(bun);
                StartActivity((activity3));
                Finish();
            }
        }
    }
}