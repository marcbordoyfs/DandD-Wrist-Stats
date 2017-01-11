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
    struct Stats
    {
        public bool flag;
        public int num;
        public Button button;
        public string name;
    }
    [Activity(Label = "newCharAct")]
    public class newCharAct : Activity
    {


        Button name;
        Stats[] stats = new Stats[7];
        ImageButton[] otherbuttons = new ImageButton[4];
        string text;
        string saved = "";
        CharacterStats[] savedchars = new CharacterStats[3];
        string[] temp = new string[3];
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.newchar);

            // read in saved to savedchars
            readingsaves();

            stats[0].button = FindViewById<Button>(Resource.Id.buttonSTR);
            stats[1].button = FindViewById<Button>(Resource.Id.buttonINT);
            stats[2].button = FindViewById<Button>(Resource.Id.buttonDEX);
            stats[3].button = FindViewById<Button>(Resource.Id.buttonWIS);
            stats[4].button = FindViewById<Button>(Resource.Id.buttonCON);
            stats[5].button = FindViewById<Button>(Resource.Id.buttonCHR);
            stats[6].button = FindViewById<Button>(Resource.Id.buttonPROF);

            stats[0].name = "Strength";
            stats[1].name = "Intelligence";
            stats[2].name = "Dexterity";
            stats[3].name = "Wisdom";
            stats[4].name = "Constitution";
            stats[5].name = "Charisma";
            stats[6].name = "Proficiency";

            otherbuttons[0] = FindViewById<ImageButton>(Resource.Id.imageButtonup);
            otherbuttons[1] = FindViewById<ImageButton>(Resource.Id.imageButtondown);
            otherbuttons[2] = FindViewById<ImageButton>(Resource.Id.newtomainbutton);
            otherbuttons[3] = FindViewById<ImageButton>(Resource.Id.imageButtonsave);

            name = FindViewById<Button>(Resource.Id.enternewname);

            text = Intent.GetStringExtra("MyData") ?? "Tap to enter name";
            name.Text = text;

            // Create your application here
            for (int i = 0; i < 7; i++)
            {
                stats[i].flag = false;
                stats[i].num = 8;
                if (i == 6)
                    stats[6].num = 0;
                stats[i].button.Text = stats[i].name.ToString() + ": " + stats[i].num.ToString();
                stats[i].button.Click += statbuttonpressed;
            }

            otherbuttons[0].Click += upbuttonpressed;
            otherbuttons[1].Click += downbuttonpressed;
            otherbuttons[2].Click += delegate { Finish(); };
            otherbuttons[3].Click += savebuttonclick;
            name.Click += delegate { Finish(); StartActivity(typeof(nameinput)); };

        }

        private void statbuttonpressed(object sender, EventArgs c)
        {
            Button btn = (Button)sender;
            for (int i = 0; i < 7; i++)
            {
                if (btn == stats[i].button)
                {
                    stats[i].flag = true;
                    stats[i].button.SetTextColor(Color.Yellow);
                }
                else
                {
                    stats[i].flag = false;
                    stats[i].button.SetTextColor(Color.White);
                }

            }
        }

        private void upbuttonpressed(object sender, EventArgs c)
        {
            for (int i = 0; i < 7; i++)
            {
                if (stats[i].flag)
                {
                    stats[i].num += 1;
                    if (stats[i].num == 31)
                        stats[i].num = 30;
                    stats[i].button.Text = stats[i].name + ": " + stats[i].num.ToString();
                }
            }

        }
        private void downbuttonpressed(object sender, EventArgs c)
        {
            for (int i = 0; i < 7; i++)
            {
                if (stats[i].flag)
                {
                    stats[i].num -= 1;
                    if (stats[i].num == -1)
                        stats[i].num = 0;
                    stats[i].button.Text = stats[i].name + ": " + stats[i].num.ToString();
                }
            }
        }

        private void savebuttonclick(object sender, EventArgs c)
        {
            if (savedchars[0] == null|| savedchars[1] == null || savedchars[2] == null )
            {


                CharacterStats player = new CharacterStats();
                player.name = name.Text;

                player.strength = stats[0].num;
                player.intelligence = stats[1].num;
                player.dexterity = stats[2].num;
                player.wisdom = stats[3].num;
                player.constitution = stats[4].num;
                player.charisma = stats[5].num;
                player.prof = stats[6].num;

                for (int i = 0; i < 3; i++)
                {
                    if (savedchars[i] == null)
                    {
                        player.slot = i;
                        savedchars[i] = player;
                        break;
                    }
                }

                // saves player info
                saving();
                Finish();
            }
            else { RunOnUiThread(() => Toast.MakeText(this, "all 3 slots used", ToastLength.Long).Show()); }
        }

        protected void saving()
        {

            //store
            var pref = Application.Context.GetSharedPreferences("Mysaves", FileCreationMode.Private);
            var prefEditor = pref.Edit();
            prefEditor.PutString("charstats", "");
            saved = "";

            for (int i = 0; i < 3; i++)
            {
                if (savedchars[i] != null)
                {
                    if (i == 1 || i == 0)
                    {
                        saved += savedchars[i].name.ToString() + ",";
                        saved += savedchars[i].strength.ToString() + ",";
                        saved += savedchars[i].intelligence.ToString() + ",";
                        saved += savedchars[i].dexterity.ToString() + ",";
                        saved += savedchars[i].wisdom.ToString() + ",";
                        saved += savedchars[i].constitution.ToString() + ",";
                        saved += savedchars[i].charisma.ToString() + ",";
                        saved += savedchars[i].prof.ToString() + ",";
                        saved += savedchars[i].slot.ToString() + "/";
                    }
                    else
                    {
                        saved += savedchars[i].name.ToString() + ",";
                        saved += savedchars[i].strength.ToString() + ",";
                        saved += savedchars[i].intelligence.ToString() + ",";
                        saved += savedchars[i].dexterity.ToString() + ",";
                        saved += savedchars[i].wisdom.ToString() + ",";
                        saved += savedchars[i].constitution.ToString() + ",";
                        saved += savedchars[i].charisma.ToString() + ",";
                        saved += savedchars[i].prof.ToString() + ",";
                        saved += savedchars[i].slot.ToString();
                    }

                }
            }


            prefEditor.PutString("charstats", saved);
            prefEditor.Commit();

        }

        protected void readingsaves()
        {
            //retreive 
            var pref = Application.Context.GetSharedPreferences("Mysaves", FileCreationMode.Private);
            saved = pref.GetString("charstats", "//");

            temp = saved.Split('/');


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


    }

}