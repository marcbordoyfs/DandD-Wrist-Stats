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
    [Activity(Label = "nameinput")]
    public class nameinput : Activity
    {
        Button[] letters = new Button[31];
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.letters);
            // Create your application here

            letters[0] = FindViewById<Button>(Resource.Id.buttonA);
            letters[1] = FindViewById<Button>(Resource.Id.buttonB);
            letters[2] = FindViewById<Button>(Resource.Id.buttonC);
            letters[3] = FindViewById<Button>(Resource.Id.buttonD);
            letters[4] = FindViewById<Button>(Resource.Id.buttonE);
            letters[5] = FindViewById<Button>(Resource.Id.buttonF);
            letters[6] = FindViewById<Button>(Resource.Id.buttonG);
            letters[7] = FindViewById<Button>(Resource.Id.buttonH);
            letters[8] = FindViewById<Button>(Resource.Id.buttonI);
            letters[9] = FindViewById<Button>(Resource.Id.buttonJ);
            letters[10] = FindViewById<Button>(Resource.Id.buttonK);
            letters[11] = FindViewById<Button>(Resource.Id.buttonL);
            letters[12] = FindViewById<Button>(Resource.Id.buttonM);
            letters[13] = FindViewById<Button>(Resource.Id.buttonN);
            letters[14] = FindViewById<Button>(Resource.Id.buttonO);
            letters[15] = FindViewById<Button>(Resource.Id.buttonP);
            letters[16] = FindViewById<Button>(Resource.Id.buttonQ);
            letters[17] = FindViewById<Button>(Resource.Id.buttonR);
            letters[18] = FindViewById<Button>(Resource.Id.buttonS);
            letters[19] = FindViewById<Button>(Resource.Id.buttonT);
            letters[20] = FindViewById<Button>(Resource.Id.buttonU);
            letters[21] = FindViewById<Button>(Resource.Id.buttonV);
            letters[22] = FindViewById<Button>(Resource.Id.buttonW);
            letters[23] = FindViewById<Button>(Resource.Id.buttonX);
            letters[24] = FindViewById<Button>(Resource.Id.buttonY);
            letters[25] = FindViewById<Button>(Resource.Id.buttonZ);
            letters[26] = FindViewById<Button>(Resource.Id.buttonback);
            letters[27] = FindViewById<Button>(Resource.Id.buttonspace);
            letters[28] = FindViewById<Button>(Resource.Id.buttonenter);
            letters[29] = FindViewById<Button>(Resource.Id.namebutton);

            letters[29].Text = "";

            for (int i = 0; i < 26; i++)
            {
                letters[i].Click += whenbuttonpressed;
            }
            letters[26].Click += backspace_Click;
            letters[27].Click += space_Click;
            letters[28].Click += Enter_Click;
        }
        private void whenbuttonpressed(object sender, EventArgs c)
        {
            Button btn = (Button)sender;
            letters[29].Text += btn.Text;
        }
        private void backspace_Click(object sender, EventArgs e)
        {
            if (letters[29].Text != "")
            {
                letters[29].Text = letters[29].Text.Remove(letters[29].Length() - 1);
            }
        }
        private void space_Click(object sender, EventArgs e)
        {
            if (letters[29].Text != "")
            {
                letters[29].Text += " ";
            }
        }
        private void Enter_Click(object sender, EventArgs e)
        {

            if (letters[29].Text != "")
            {
                Intent activity2 = new Intent(this, typeof(newCharAct));
                activity2.PutExtra("MyData", letters[29].Text);
                Finish();
                StartActivity((activity2));
            }
        }
    }
}