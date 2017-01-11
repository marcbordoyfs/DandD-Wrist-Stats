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
    [Activity(Label = "DiceRollingAct")]
    public class DiceRollingAct : Activity
    {
        Button[] buttons = new Button[4];
        TextView[] textboxs = new TextView[3];
        ImageButton imbutton;
        Button namebutton;

        bool disadvon = false;
        bool advon = false;
        string text;

        string name;
        int[] nums = new int[2];
        int plus;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DiceRolling);
            text = Intent.GetStringExtra("MyData") ?? "D20";
            name = Intent.GetStringExtra("charname") ?? "";
            nums = Intent.GetIntArrayExtra("charnums");

            if (nums[0]<=1) {plus = -5 + nums[1]; }
            else if (nums[0] <= 3) {plus = -4 + nums[1]; }
            else if (nums[0] <= 5) {plus = -3 + nums[1]; }
            else if (nums[0] <= 7) {plus = -2 + nums[1]; }
            else if (nums[0] <= 9) {plus = -1 + nums[1]; }
            else if (nums[0] <= 11) {plus = 0 + nums[1]; }
            else if (nums[0] <= 13) {plus = 1 + nums[1]; }
            else if (nums[0] <= 15) {plus = 2 + nums[1]; }
            else if (nums[0] <= 17) {plus = 3 + nums[1]; }
            else if (nums[0] <= 19) {plus = 4 + nums[1]; }
            else if (nums[0] <= 21) {plus = 5 + nums[1]; }
            else if (nums[0] <= 23) {plus = 6 + nums[1]; }
            else if (nums[0] <= 25) {plus = 7 + nums[1]; }
            else if (nums[0] <= 27) {plus = 8 + nums[1]; }
            else if (nums[0] <= 29) {plus = 9 + nums[1]; }
            else if (nums[0] == 30) {plus = 10 + nums[1]; }

            // Create your application here
            setupbutton();
            setupbuttonclicks();
        }

        public void setupbutton()
        {
            buttons[0] = FindViewById<Button>(Resource.Id.Rollbutton);
            buttons[1] = FindViewById<Button>(Resource.Id.Advantagebutton);
            buttons[2] = FindViewById<Button>(Resource.Id.Disadvantagebutton);
            buttons[3] = FindViewById<Button>(Resource.Id.buttonDice); 
            namebutton = FindViewById<Button>(Resource.Id.buttonname);
            imbutton = FindViewById<ImageButton>(Resource.Id.imageButtonOption);
            textboxs[0] = FindViewById<TextView>(Resource.Id.textViewroll);
            textboxs[1] = FindViewById<TextView>(Resource.Id.textViewplus);
        }
        public void setupbuttonclicks()
        {
            namebutton.Text = name;
            buttons[0].Click += rollclicked;
            buttons[1].Click += dis_advantageclicked;
            buttons[2].Click += dis_advantageclicked;
            buttons[3].Click += dicebuttonclicked;
            buttons[3].Text = text;
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
                if(advon == true || disadvon == true)
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
                if (advon == true || disadvon == true)
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
                if (advon == true || disadvon == true)
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
                if (advon == true || disadvon == true)
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
                if (advon == true || disadvon == true)
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
                if (advon == true || disadvon == true)
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
                if (advon == true || disadvon == true)
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
                if (advon == true || disadvon == true)
                {
                    textboxs[0].Text += " and ";
                    two = ran.Next(1, 101);
                    textboxs[0].Text += two.ToString();
                }
            }

            if (advon == true)
            {
                if (one >= two)
                {
                    one += plus;
                    textboxs[1].Text = "Your roll is: " + one.ToString() + " (with pluses)";
                }

                else
                {
                    two += plus;
                    textboxs[1].Text = "Your roll is: " + two.ToString() + " (with pluses)";
                }
            }
            else if (disadvon == true)
            {
                if (one <= two)
                {
                    one += plus;
                    textboxs[1].Text = "Your roll is: " + one.ToString() + " (with pluses)";
                }

                else
                {
                    two += plus;
                    textboxs[1].Text = "Your roll is: " + two.ToString() + " (with pluses)";
                }
            }
            else
            {
                one += plus;
                textboxs[1].Text = "Your roll is: " + one.ToString() + " (with pluses)";
            }

        }
        private void dis_advantageclicked(object sender, EventArgs c)
        {
            Button btn = (Button)sender;
            buttons[1].SetTextColor(Color.White);
            buttons[2].SetTextColor(Color.White);
            if (btn.Id == Resource.Id.Advantagebutton)
            {
                advon = !advon;
                if (advon == true)
                {
                    buttons[1].SetTextColor(Color.Yellow);
                    disadvon = false;
                    buttons[2].SetTextColor(Color.White);
                }
            }
            else if (btn.Id == Resource.Id.Disadvantagebutton)
            {
                disadvon = !disadvon;
                if (disadvon == true)
                {
                    buttons[2].SetTextColor(Color.Yellow);
                    advon = false;
                    buttons[1].SetTextColor(Color.White);
                }
            }

        }

        private void dicebuttonclicked(object sender, EventArgs c)
        {
            Bundle bun = new Bundle();
            bun.PutString("charname", name);
            bun.PutIntArray("charnums", nums);
            bun.PutInt("rolltype", 1);
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