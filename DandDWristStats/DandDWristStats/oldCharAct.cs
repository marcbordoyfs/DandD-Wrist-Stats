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
    [Activity(Label = "oldCharAct")]
    public class oldCharAct : Activity
    {
        Button[] charbuttons = new Button[3];
        string readinsaves;
        CharacterStats[] savedchars = new CharacterStats[3];

        string[] temp = new string[3];
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.oldchar);

            // Create your application here @+id/char1editbutton
            ImageButton returnbutton = FindViewById<ImageButton>(Resource.Id.oldtomainbutton);
            ImageButton char1edit = FindViewById<ImageButton>(Resource.Id.char1editbutton);
            ImageButton char2edit = FindViewById<ImageButton>(Resource.Id.char2editbutton);
            ImageButton char3edit = FindViewById<ImageButton>(Resource.Id.char3editbutton);

            charbuttons[0] = FindViewById<Button>(Resource.Id.charbutton1);
            charbuttons[1] = FindViewById<Button>(Resource.Id.charbutton2);
            charbuttons[2] = FindViewById<Button>(Resource.Id.charbutton3);

            readingsaves();

            for (int i = 0; i < 3; i++)
            {
                if (savedchars[i] != null)
                {
                    charbuttons[i].Text = savedchars[i].name;
                }
            }

            char1edit.Click += character1editclick;
            char2edit.Click += character2editclick;
            char3edit.Click += character3editclick;

            charbuttons[0].Click += character1play;
            charbuttons[1].Click += character2play;
            charbuttons[2].Click += character3play;
            returnbutton.Click += delegate { Finish(); };
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

        private void character1play(object sender, EventArgs c)
        {
            if (savedchars[0] != null)
            {
                Bundle bun = new Bundle();
                bun.PutString("charname", savedchars[0].name);

                int[] nums = new int[8];
                nums[0] = savedchars[0].strength;
                nums[1] = savedchars[0].intelligence;
                nums[2] = savedchars[0].dexterity;
                nums[3] = savedchars[0].wisdom;
                nums[4] = savedchars[0].constitution;
                nums[5] = savedchars[0].charisma;
                nums[6] = savedchars[0].prof;
                nums[7] = savedchars[0].slot;
                bun.PutIntArray("charnums", nums);

                Intent activity3 = new Intent(this, typeof(RollTypeAct));
                activity3.PutExtras(bun);

                StartActivity((activity3));
            }
        }
        private void character2play(object sender, EventArgs c)
        {
            if (savedchars[1] != null)
            {
                Bundle bun = new Bundle();
                bun.PutString("charname", savedchars[1].name);
                int[] nums = new int[8];
                nums[0] = savedchars[1].strength;
                nums[1] = savedchars[1].intelligence;
                nums[2] = savedchars[1].dexterity;
                nums[3] = savedchars[1].wisdom;
                nums[4] = savedchars[1].constitution;
                nums[5] = savedchars[1].charisma;
                nums[6] = savedchars[1].prof;
                nums[7] = savedchars[1].slot;
                bun.PutIntArray("charnums", nums);

                Intent activity3 = new Intent(this, typeof(RollTypeAct));
                activity3.PutExtras(bun);

                StartActivity((activity3));
            }
        }
        private void character3play(object sender, EventArgs c)
        {
            if (savedchars[2] != null)
            {
                Bundle bun = new Bundle();
                bun.PutString("charname", savedchars[2].name);
                int[] nums = new int[8];
                nums[0] = savedchars[2].strength;
                nums[1] = savedchars[2].intelligence;
                nums[2] = savedchars[2].dexterity;
                nums[3] = savedchars[2].wisdom;
                nums[4] = savedchars[2].constitution;
                nums[5] = savedchars[2].charisma;
                nums[6] = savedchars[2].prof;
                nums[7] = savedchars[2].slot;
                bun.PutIntArray("charnums", nums);

                Intent activity3 = new Intent(this, typeof(RollTypeAct));
                activity3.PutExtras(bun);

                StartActivity((activity3));
            }
        }

        private void character1editclick(object sender, EventArgs c)
        {
            if (savedchars[0] != null)
            {
                Bundle bun = new Bundle();
                bun.PutString("charname", savedchars[0].name);

                int[] nums = new int[8];
                nums[0] = savedchars[0].strength;
                nums[1] = savedchars[0].intelligence;
                nums[2] = savedchars[0].dexterity;
                nums[3] = savedchars[0].wisdom;
                nums[4] = savedchars[0].constitution;
                nums[5] = savedchars[0].charisma;
                nums[6] = savedchars[0].prof;
                nums[7] = savedchars[0].slot;
                bun.PutIntArray("charnums", nums);

                Intent activity3 = new Intent(this, typeof(EditCharacterAct));
                activity3.PutExtras(bun);

                StartActivity((activity3));
                Finish();
            }

        }
        private void character2editclick(object sender, EventArgs c)
        {
            if (savedchars[1] != null)
            {
                Bundle bun = new Bundle();
                bun.PutString("charname", savedchars[1].name);
                int[] nums = new int[8];
                nums[0] = savedchars[1].strength;
                nums[1] = savedchars[1].intelligence;
                nums[2] = savedchars[1].dexterity;
                nums[3] = savedchars[1].wisdom;
                nums[4] = savedchars[1].constitution;
                nums[5] = savedchars[1].charisma;
                nums[6] = savedchars[1].prof;
                nums[7] = savedchars[1].slot;
                bun.PutIntArray("charnums", nums);

                Intent activity3 = new Intent(this, typeof(EditCharacterAct));
                activity3.PutExtras(bun);

                StartActivity((activity3));
                Finish();
            }

        }
        private void character3editclick(object sender, EventArgs c)
        {
            if (savedchars[2] != null)
            {
                Bundle bun = new Bundle();
                bun.PutString("charname", savedchars[2].name);
                int[] nums = new int[8];
                nums[0] = savedchars[2].strength;
                nums[1] = savedchars[2].intelligence;
                nums[2] = savedchars[2].dexterity;
                nums[3] = savedchars[2].wisdom;
                nums[4] = savedchars[2].constitution;
                nums[5] = savedchars[2].charisma;
                nums[6] = savedchars[2].prof;
                nums[7] = savedchars[2].slot;
                bun.PutIntArray("charnums", nums);

                Intent activity3 = new Intent(this, typeof(EditCharacterAct));
                activity3.PutExtras(bun);

                StartActivity((activity3));
                Finish();
            }

        }

    }

}