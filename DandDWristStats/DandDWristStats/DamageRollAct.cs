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
using Android.Graphics;

namespace DandDWristStats
{
    [Activity(Label = "DamageRollAct")]
    public class DamageRollAct : Activity
    {
        Button[] buttons = new Button[4];
        TextView[] textboxs = new TextView[2];
        ImageButton imbutton;
        Button namebutton;

        string text;
        int Damage;
        long TotalDamage;

        string name;
        int[] nums = new int[2];
        int plus;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DamageRolls);
            text = Intent.GetStringExtra("MyData") ?? "D4";
            TotalDamage = Intent.GetLongExtra("TOTAL", 0);

            name = Intent.GetStringExtra("charname") ?? "";
            nums = Intent.GetIntArrayExtra("charnums");

            if (nums[0] <= 1) { plus = -5 + nums[1]; }
            else if (nums[0] <= 3) { plus = -4 + nums[1]; }
            else if (nums[0] <= 5) { plus = -3 + nums[1]; }
            else if (nums[0] <= 7) { plus = -2 + nums[1]; }
            else if (nums[0] <= 9) { plus = -1 + nums[1]; }
            else if (nums[0] <= 11) { plus = 0 + nums[1]; }
            else if (nums[0] <= 13) { plus = 1 + nums[1]; }
            else if (nums[0] <= 15) { plus = 2 + nums[1]; }
            else if (nums[0] <= 17) { plus = 3 + nums[1]; }
            else if (nums[0] <= 19) { plus = 4 + nums[1]; }
            else if (nums[0] <= 21) { plus = 5 + nums[1]; }
            else if (nums[0] <= 23) { plus = 6 + nums[1]; }
            else if (nums[0] <= 25) { plus = 7 + nums[1]; }
            else if (nums[0] <= 27) { plus = 8 + nums[1]; }
            else if (nums[0] <= 29) { plus = 9 + nums[1]; }
            else if (nums[0] == 30) { plus = 10 + nums[1]; }

            // Create your application here
            setupbutton();
            setupbuttonclicks();

        }
        public void setupbutton()
        {
            buttons[0] = FindViewById<Button>(Resource.Id.RollbuttonDamage);
            buttons[1] = FindViewById<Button>(Resource.Id.AddRollbutton);
            buttons[2] = FindViewById<Button>(Resource.Id.buttonDiceDamage);
            namebutton = FindViewById<Button>(Resource.Id.tittlename);

            imbutton = FindViewById<ImageButton>(Resource.Id.imageButtonOptionDamage);

            textboxs[0] = FindViewById<TextView>(Resource.Id.textViewroll);
            textboxs[1] = FindViewById<TextView>(Resource.Id.textViewtotal);
        }
        public void setupbuttonclicks()
        {
            buttons[0].Click += rollclicked;
            buttons[1].Click += addclicked;
            buttons[2].Click += dicebuttonclicked;

            namebutton.Text = name;
            textboxs[1].Text = TotalDamage.ToString();
            textboxs[0].SetTextColor(Color.Yellow);
            textboxs[1].SetTextColor(Color.Yellow);

            buttons[2].Text = text;
            imbutton.Click += optionopen;

        }
        private void rollclicked(object sender, EventArgs c)
        {
            
            if (text == "D4")
            {
                Random ran = new Random();
                Damage = ran.Next(1, 5);
                textboxs[0].Text = Damage.ToString();
            }
            else if (text == "D6")
            {
                Random ran = new Random();
                Damage = ran.Next(1, 7);
                textboxs[0].Text = Damage.ToString();
            }
            else if (text == "D8")
            {
                Random ran = new Random();
                Damage = ran.Next(1, 9);
                textboxs[0].Text = Damage.ToString();
            }
            else if (text == "D10")
            {
                Random ran = new Random();
                Damage = ran.Next(1, 11);
                textboxs[0].Text = Damage.ToString();
            }
            else if (text == "D12")
            {
                Random ran = new Random();
                Damage = ran.Next(1, 13);
                textboxs[0].Text = Damage.ToString();
            }
            else if (text == "D20")
            {
                Random ran = new Random();
                Damage = ran.Next(1, 21);
                textboxs[0].Text = Damage.ToString();
            }
            else if (text == "D30")
            {
                Random ran = new Random();
                Damage = ran.Next(1, 31);
                textboxs[0].Text = Damage.ToString();
            }
            else if (text == "D100")
            {
                Random ran = new Random();
                Damage = ran.Next(1, 101);
                textboxs[0].Text = Damage.ToString();
            }

        }


        private void addclicked(object sender, EventArgs c)
        {
            TotalDamage += Damage;
            int withplus = (int)TotalDamage + plus;
            textboxs[1].Text = TotalDamage.ToString() + " : " + withplus.ToString() + " with pluses";
        }
        private void dicebuttonclicked(object sender, EventArgs c)
        {
            Bundle bun = new Bundle();
            bun.PutLong("DamageTotal", TotalDamage);
            bun.PutString("charname", name);
            bun.PutIntArray("charnums", nums);
            Intent activity2 = new Intent(this, typeof(DamageDiceAct));
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