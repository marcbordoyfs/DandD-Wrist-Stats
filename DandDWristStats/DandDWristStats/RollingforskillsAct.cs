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
    [Activity(Label = "RollingforskillsAct")]
    public class RollingforskillsAct : Activity
    {
        Button[] buttons = new Button[2];
        Button namebutton;
        TextView[] textboxs = new TextView[2];
        ImageButton imbutton;
        int profnum;
        int doubleprofnum;
        bool[] checks = new bool[4]; // sub 0 is advantage//sub 1 is disadavn// sub 2 is prof//sub 3 is doubeprof
        string text;

        string name;
        string skillname;
        int[] nums = new int[2]; // 2 to 8

        int plus;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Rollingforskills);
            // Create your application here
            text = Intent.GetStringExtra("MyData") ?? "D20"; // disable button
            name = Intent.GetStringExtra("charname") ?? "";
            nums = Intent.GetIntArrayExtra("charnums");
            skillname = Intent.GetStringExtra("skillname") ?? "";
            checks = Intent.GetBooleanArrayExtra("checks");

            if (nums[0] <= 1) { plus = -5 + nums[1]; }
            else if (nums[0] <= 3) { plus = -4; }
            else if (nums[0] <= 5) { plus = -3; }
            else if (nums[0] <= 7) { plus = -2; }
            else if (nums[0] <= 9) { plus = -1; }
            else if (nums[0] <= 11) { plus = 0; }
            else if (nums[0] <= 13) { plus = 1; }
            else if (nums[0] <= 15) { plus = 2; }
            else if (nums[0] <= 17) { plus = 3; }
            else if (nums[0] <= 19) { plus = 4; }
            else if (nums[0] <= 21) { plus = 5; }
            else if (nums[0] <= 23) { plus = 6; }
            else if (nums[0] <= 25) { plus = 7; }
            else if (nums[0] <= 27) { plus = 8; }
            else if (nums[0] <= 29) { plus = 9; }
            else if (nums[0] == 30) { plus = 10; }

            doubleprofnum = (nums[1] * 2);
            profnum = nums[1];

            // Create your application here
            setupbutton();
            setupbuttonclicks();
        }

        public void setupbutton()
        {
            buttons[0] = FindViewById<Button>(Resource.Id.Rollbutton);
            buttons[1] = FindViewById<Button>(Resource.Id.buttonDice);
            imbutton = FindViewById<ImageButton>(Resource.Id.imageButtonOption);
            textboxs[0] = FindViewById<TextView>(Resource.Id.textViewroll);
            textboxs[1] = FindViewById<TextView>(Resource.Id.textViewplus);
            namebutton = FindViewById<Button>(Resource.Id.buttonname);

        }
        public void setupbuttonclicks()
        {
            namebutton.Text = name + "\n" + skillname;
            buttons[0].Click += rollclicked;
            buttons[1].Text = text;
            imbutton.Click += optionopen;

            textboxs[0].SetTextColor(Color.Yellow);
            textboxs[1].SetTextColor(Color.Yellow);
        }

        private void rollclicked(object sender, EventArgs c)
        {
            int one = 0;
            int two = 0;
            if (text == "D4")
            {
                Random ran = new Random();
                one = ran.Next(1, 5);
                textboxs[0].Text = one.ToString();
                if (checks[0] == true || checks[1] == true)
                {
                    textboxs[0].Text += " and ";
                    two = ran.Next(1, 5);
                    textboxs[0].Text += two.ToString();
                }

            }
            else if (text == "D6")
            {
                Random ran = new Random();
                one = ran.Next(1, 7);
                textboxs[0].Text = one.ToString();
                if (checks[0] == true || checks[1] == true)
                {
                    textboxs[0].Text += " and ";
                    two = ran.Next(1, 7);
                    textboxs[0].Text += two.ToString();
                }
            }
            else if (text == "D8")
            {
                Random ran = new Random();
                one = ran.Next(1, 9);
                textboxs[0].Text = one.ToString();
                if (checks[0] == true || checks[1] == true)
                {
                    textboxs[0].Text += " and ";
                    two = ran.Next(1, 9);
                    textboxs[0].Text += two.ToString();
                }
            }
            else if (text == "D10")
            {
                Random ran = new Random();
                one = ran.Next(1, 11);
                textboxs[0].Text = one.ToString();
                if (checks[0] == true || checks[1] == true)
                {
                    textboxs[0].Text += " and ";
                    two = ran.Next(1, 11);
                    textboxs[0].Text += two.ToString();
                }
            }
            else if (text == "D12")
            {
                Random ran = new Random();
                one = ran.Next(1, 13);
                textboxs[0].Text = one.ToString();
                if (checks[0] == true || checks[1] == true)
                {
                    textboxs[0].Text += " and ";
                    two = ran.Next(1, 13);
                    textboxs[0].Text += two.ToString();
                }
            }
            else if (text == "D20")
            {
                Random ran = new Random();
                one = ran.Next(1, 21);
                textboxs[0].Text = one.ToString();
                if (checks[0] == true || checks[1] == true)
                {
                    textboxs[0].Text += " and ";
                    two = ran.Next(1, 21);
                    textboxs[0].Text += two.ToString();
                }
            }
            else if (text == "D30")
            {
                Random ran = new Random();
                one = ran.Next(1, 31);
                textboxs[0].Text = one.ToString();
                if (checks[0] == true || checks[1] == true)
                {
                    textboxs[0].Text += " and ";
                    two = ran.Next(1, 31);
                    textboxs[0].Text += two.ToString();
                }
            }
            else if (text == "D100")
            {
                Random ran = new Random();
                one = ran.Next(1, 101);
                textboxs[0].Text = one.ToString();
                if (checks[0] == true || checks[1] == true)
                {
                    textboxs[0].Text += " and ";
                    two = ran.Next(1, 101);
                    textboxs[0].Text += two.ToString();
                }
            }

            
            if (checks[0] == true) // advantage
            {
                if (one >= two)
                {
                    if (checks[2]) // prof
                    {
                        if (checks[3]) // double prof
                        {
                            one += doubleprofnum;
                        }
                        else
                        {
                            one += profnum;
                        }
                    }

                    one += plus;
                    textboxs[1].Text = "Your roll is: " + one.ToString();
                }
                else
                {
                    if (checks[2])
                    {
                        if (checks[3])
                        {
                            two += doubleprofnum;

                        }
                        else
                        {
                            two += profnum;
                        }
                    }

                    two += plus;
                    textboxs[1].Text = "Your roll is: " + two.ToString();
                }
            }
            else if (checks[1] == true)
            {
                if (one <= two)
                {
                    if (checks[2])
                    {
                        if (checks[3])
                        {
                            one += doubleprofnum;
                        }
                        else
                        {
                            one += profnum;
                        }
                    }

                    one += plus;
                    textboxs[1].Text = "Your roll is: " + one.ToString();
                }
                else
                {
                    if (checks[2])
                    {
                        if (checks[3])
                        {
                            two += doubleprofnum;
                        }
                        else
                        {
                            two += profnum;
                        }
                    }

                    two += plus;
                    textboxs[1].Text = "Your roll is: " + two.ToString();
                }
            }
            else
            {
                if (checks[2])
                {
                    if (checks[3])
                    {
                        one += doubleprofnum;
                    }
                    else
                    {
                        one += profnum;
                    }
                }
                one += plus;
                textboxs[1].Text = "Your roll is: " + one.ToString();
            }

            if(checks[0])
            {
                if (checks[3])
                    textboxs[1].Text = textboxs[1].Text + " with advantage\n and double proficiency";
                else if (checks[2])
                    textboxs[1].Text = textboxs[1].Text + " with advantage\n and proficiency";
                else
                    textboxs[1].Text = textboxs[1].Text + " with advantage";
            }
            else if (checks[1])
            {
                if (checks[3])
                    textboxs[1].Text = textboxs[1].Text + " with\ndisadvantage and double \n   proficiency";
                else if (checks[2])
                    textboxs[1].Text = textboxs[1].Text + " with\ndisadvantage and proficiency";
                else
                    textboxs[1].Text = textboxs[1].Text + " with disadvantage";
            }
            else
            {
                if (checks[3])
                    textboxs[1].Text = textboxs[1].Text + " with double proficiency";
                else if (checks[2])
                    textboxs[1].Text = textboxs[1].Text + " with proficiency";
                else
                    textboxs[1].Text = textboxs[1].Text + " with nothing";
            }


        }

        private void dicebuttonclicked(object sender, EventArgs c)
        {
            Bundle bun = new Bundle();
            bun.PutString("charname", name);
            bun.PutIntArray("charnums", nums);
            bun.PutInt("rolltype", 2);
            Intent activity2 = new Intent(this, typeof(DiceAct));
            activity2.PutExtras(bun);
            StartActivity((activity2));
            Finish();
        }
        private void optionopen(object sender, EventArgs c)
        {
            Bundle bun = new Bundle();
            bun.PutString("charname", name);
            bun.PutIntArray("charnums", nums);
            Intent activity2 = new Intent(this, typeof(OptionsAct));
            activity2.PutExtras(bun);
            StartActivity((activity2));
            //StartActivityForResult((activity2), 0);
        }
        protected void onActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                Finish();
            }
        }

    }
}