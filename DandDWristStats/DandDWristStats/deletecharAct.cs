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
    [Activity(Label = "deletecharAct")]
    public class deletecharAct : Activity
    {

        Button name;
        Button yes;
        Button no;
        CharacterStats[] savedchars = new CharacterStats[3];
        int[] nums = new int[8];
        string[] temp = new string[3];
        string saved = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DeleteChar);
            // Create your application here
            name = FindViewById<Button>(Resource.Id.buttonname);
            yes = FindViewById<Button>(Resource.Id.yesbutton);
            no = FindViewById<Button>(Resource.Id.nobutton);

            name.Text = "DELETE: " + Intent.GetStringExtra("charname") + "?";
            nums = Intent.GetIntArrayExtra("charnums");

            yes.Click += delete;
            no.Click += delegate { Finish(); StartActivity(typeof(oldCharAct)); };
        }

        private void delete(object sender, EventArgs c)
        {
            readingsaves();
            for (int i = 0; i < 3; i++)
            {
                if (savedchars[i].slot == nums[7])
                {
                    var pref = Application.Context.GetSharedPreferences("Mysaves", FileCreationMode.Private);
                    var prefEditor = pref.Edit();
                    prefEditor.PutString("charstats", "");
                    saved = "";
                    savedchars[i] = null;

                    for (int o = 0; o < 3; o++)
                    {
                        if (savedchars[o] != null)
                        {
                            if (o == 0 || o == 1)
                            {
                                saved += savedchars[o].name.ToString() + ",";
                                saved += savedchars[o].strength.ToString() + ",";
                                saved += savedchars[o].intelligence.ToString() + ",";
                                saved += savedchars[o].dexterity.ToString() + ",";
                                saved += savedchars[o].wisdom.ToString() + ",";
                                saved += savedchars[o].constitution.ToString() + ",";
                                saved += savedchars[o].charisma.ToString() + ",";
                                saved += savedchars[o].prof.ToString() + ",";
                                saved += savedchars[o].slot.ToString() + "/";
                            }
                            else
                            {
                                saved += savedchars[o].name.ToString() + ",";
                                saved += savedchars[o].strength.ToString() + ",";
                                saved += savedchars[o].intelligence.ToString() + ",";
                                saved += savedchars[o].dexterity.ToString() + ",";
                                saved += savedchars[o].wisdom.ToString() + ",";
                                saved += savedchars[o].constitution.ToString() + ",";
                                saved += savedchars[o].charisma.ToString() + ",";
                                saved += savedchars[o].prof.ToString() + ",";
                                saved += savedchars[o].slot.ToString();
                            }

                        }

                    }


                    prefEditor.PutString("charstats", saved);
                    prefEditor.Commit();
                    Finish();
                    StartActivity(typeof(oldCharAct));
                    break;

                }

            }

        }

        protected void readingsaves()
        {
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