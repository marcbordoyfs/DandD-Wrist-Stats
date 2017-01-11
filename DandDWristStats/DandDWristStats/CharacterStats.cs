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

namespace DandDWristStats
{
    class CharacterStats
    {
        public string name;

        public int strength;
        public int intelligence;
        public int dexterity;
        public int wisdom;
        public int constitution;
        public int charisma;
        public int prof;  

        public int slot;
        short[] skillz = new short[18];
        public CharacterStats()
        {
            name ="";
            strength = 0;
            intelligence = 0;
            dexterity = 0;
            wisdom = 0;
            constitution = 0;
            charisma = 0;
            prof = 0;
            slot = 0;
            for (int i = 0; i < 18; i++)
            {
                skillz[i] = 0;
            }
        }

    }

}