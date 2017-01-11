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
    [Activity(Label = "RollTypeAct")]
    public class RollTypeAct : Activity
    {
        Button[] buttons = new Button[3];
        Button namebutton;
        ImageButton imbutton;

        int[] nums = new int[8];

        CharacterStats[] savedchars = new CharacterStats[3];
        string readinsaves;
        string[] temp = new string[3];
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RollType);

            // Create your application here
            buttons[0] = FindViewById<Button>(Resource.Id.attackbutton);
            buttons[1] = FindViewById<Button>(Resource.Id.damagebutton);
            buttons[2] = FindViewById<Button>(Resource.Id.skillbutton);
            imbutton = FindViewById<ImageButton>(Resource.Id.imageButtonreturn);
            namebutton = FindViewById<Button>(Resource.Id.buttonname);

            namebutton.Text = Intent.GetStringExtra("charname");
            // nums = Intent.GetIntArrayExtra("charnums");

            buttons[0].Click += dicerollclick;
            buttons[1].Click += damagerollclick;
            buttons[2].Click += skillrollclick;
            imbutton .Click += delegate { Finish(); };


            readingsaves();
        }

        protected void readingsaves()
        {
            //retreive 
            var pref = Application.Context.GetSharedPreferences("Mysaves", FileCreationMode.Private);
            readinsaves = pref.GetString("charstats", "//");

            temp = readinsaves.Split('/');


            for (int i = 0; i < temp.Length; i++)
            {
                if (i >= 3)
                    break;

                if (temp[i] != null && temp[i] != "")
                {
                    string[] secondtemp = new string[9];
                    CharacterStats player = new CharacterStats();
                    secondtemp = temp[i].Split(',');
                    // broke
                    player.name = secondtemp[0];
                    int.TryParse(secondtemp[1], out player.strength);
                    int.TryParse(secondtemp[2], out player.intelligence);
                    int.TryParse(secondtemp[3], out player.dexterity);
                    int.TryParse(secondtemp[4], out player.wisdom);
                    int.TryParse(secondtemp[5], out player.constitution);
                    int.TryParse(secondtemp[6], out player.charisma);
                    int.TryParse(secondtemp[7], out player.prof);
                    int.TryParse(secondtemp[8], out player.slot);

                    savedchars[i] = player;
                }
            }

        }

        private void dicerollclick(object sender, EventArgs c)
        {
            Bundle bun = new Bundle();
            for (int i = 0; i < 3; i++)
            {
                if ((savedchars[i] != null) && (namebutton.Text == savedchars[i].name))
                {
                    bun.PutString("charname", savedchars[i].name);
                    int[] nums = new int[8];
                    nums[0] = savedchars[i].strength;
                    nums[1] = savedchars[i].intelligence;
                    nums[2] = savedchars[i].dexterity;
                    nums[3] = savedchars[i].wisdom;
                    nums[4] = savedchars[i].constitution;
                    nums[5] = savedchars[i].charisma;
                    nums[6] = savedchars[i].prof;
                    nums[7] = savedchars[i].slot;
                    bun.PutIntArray("charnums", nums);
                }

            }


            bun.PutInt("type", 1);
            Intent activity3 = new Intent(this, typeof(statpickAct));
            activity3.PutExtras(bun);
            StartActivity((activity3));
        }
        private void damagerollclick(object sender, EventArgs c)
        {
            Bundle bun = new Bundle();
            for (int i = 0; i < 3; i++)
            {
                if ((savedchars[i] != null) && (namebutton.Text == savedchars[i].name))
                {
                    bun.PutString("charname", savedchars[i].name);
                    int[] nums = new int[8];
                    nums[0] = savedchars[i].strength;
                    nums[1] = savedchars[i].intelligence;
                    nums[2] = savedchars[i].dexterity;
                    nums[3] = savedchars[i].wisdom;
                    nums[4] = savedchars[i].constitution;
                    nums[5] = savedchars[i].charisma;
                    nums[6] = savedchars[i].prof;
                    nums[7] = savedchars[i].slot;
                    bun.PutIntArray("charnums", nums);
                }

            }
            bun.PutInt("type", 2);
            Intent activity3 = new Intent(this, typeof(statpickAct));
            activity3.PutExtras(bun);
            StartActivity((activity3));
        }
        private void skillrollclick(object sender, EventArgs c)
        {
            Bundle bun = new Bundle();
            for (int i = 0; i < 3; i++)
            {
                if ((savedchars[i] != null)&& (namebutton.Text == savedchars[i].name))
                {
                    bun.PutString("charname", savedchars[i].name);
                    int[] nums = new int[8];
                    nums[0] = savedchars[i].strength;
                    nums[1] = savedchars[i].intelligence;
                    nums[2] = savedchars[i].dexterity;
                    nums[3] = savedchars[i].wisdom;
                    nums[4] = savedchars[i].constitution;
                    nums[5] = savedchars[i].charisma;
                    nums[6] = savedchars[i].prof;
                    nums[7] = savedchars[i].slot;
                    bun.PutIntArray("charnums", nums);
                }

            }
            Intent activity3 = new Intent(this, typeof(skillrollAct));
            activity3.PutExtras(bun);
            StartActivity((activity3));
        }



    }
}