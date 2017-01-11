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
    enum stats6
    {
        Strength  = 0,
        Intlligence = 1,
        Dexterity,
        Wisdom,
        Constitution,
        Charisma,
        prof
    }

    [Activity(Label = "skillrollAct")]
    public class skillrollAct : Activity
    {
        Button[] skillz = new Button[18];
        Button topname;
        string charname;
        int[] nums = new int[8];
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Skillrolls);
            // Create your application here
            skillz[0] = FindViewById<Button>(Resource.Id.Acrobaticsbutton);
            skillz[1] = FindViewById<Button>(Resource.Id.Animalbutton);
            skillz[2] = FindViewById<Button>(Resource.Id.Arcanabutton);
            skillz[3] = FindViewById<Button>(Resource.Id.Athleticsbutton);
            skillz[4] = FindViewById<Button>(Resource.Id.Deceptionbutton);
            skillz[5] = FindViewById<Button>(Resource.Id.Historybutton);
            skillz[6] = FindViewById<Button>(Resource.Id.Insightbutton);
            skillz[7] = FindViewById<Button>(Resource.Id.Intimidationbutton);
            skillz[8] = FindViewById<Button>(Resource.Id.Investigationbutton);
            skillz[9] = FindViewById<Button>(Resource.Id.Medicinebutton);
            skillz[10] = FindViewById<Button>(Resource.Id.Naturebutton);
            skillz[11] = FindViewById<Button>(Resource.Id.Perceptionbutton);
            skillz[12] = FindViewById<Button>(Resource.Id.Persuasionbutton);
            skillz[13] = FindViewById<Button>(Resource.Id.Religionbutton);
            skillz[14] = FindViewById<Button>(Resource.Id.Performancebutton);
            skillz[15] = FindViewById<Button>(Resource.Id.Slightbutton);
            skillz[16] = FindViewById<Button>(Resource.Id.Stealthbutton);
            skillz[17] = FindViewById<Button>(Resource.Id.Survivalbutton);

            topname = FindViewById<Button>(Resource.Id.charname);

            charname = Intent.GetStringExtra("charname");
            nums = Intent.GetIntArrayExtra("charnums");
            topname.Text = charname;

            for (int i = 0; i < skillz.Length; i++)
            {
                skillz[i].Click += whenbuttonpressed;
            }

        }

        private void whenbuttonpressed(object sender, EventArgs c)
        {

            Button btn = (Button)sender;
            Bundle bun = new Bundle();
            

            if (btn.Text == "Acrobatics")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Dexterity];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Acrobatics");
            }
            else if (btn.Text == "Animal                    Handling")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Wisdom];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Animal Handling");

            }
            else if (btn.Text == "Arcana")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Intlligence];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Arcana");
            }
            else if (btn.Text == "Athletics")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Strength];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Athletics");
            }
            else if (btn.Text == "Deception")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Charisma];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Deception");
            }
            else if (btn.Text == "History")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Intlligence];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "History");
            }
            else if (btn.Text == "Insight")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Wisdom];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Insight");
            }
            else if (btn.Text == "Intimidation")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Charisma];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Intimidation");
            }
            else if (btn.Text == "Investigation")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Intlligence];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Investigation");
            }
            else if (btn.Text == "Medicine")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Wisdom];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Medicine");
            }
            else if (btn.Text == "Nature")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Intlligence];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Nature");
            }
            else if (btn.Text == "Perception")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Wisdom];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Perception");
            }
            else if (btn.Text == "Persuasion")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Charisma];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Persuasion");
            }
            else if (btn.Text == "Religion")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Intlligence];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Religion");
            }
            else if (btn.Text == "Slight                                                                                              of Hand")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Dexterity];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Slight of Hand");
            }
            else if (btn.Text == "Stealth")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Dexterity];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Stealth");
            }
            else if (btn.Text == "Survival")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Wisdom];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Survival");
            }
            else if (btn.Text == "Performance")
            {
                int[] newnums = new int[2];
                newnums[0] = nums[(int)stats6.Charisma];
                newnums[1] = nums[(int)stats6.prof];
                bun.PutIntArray("charnums", newnums);
                bun.PutString("charname", charname);
                bun.PutString("skillname", "Performance");
            }

            Intent activity3 = new Intent(this, typeof(skillrollplusesAct));
            activity3.PutExtras(bun);
            StartActivity((activity3));
        }



    }
}