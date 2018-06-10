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

namespace App1
{
    class BMISave
    {
        public string Date { get; set; }
        public string BMI { get; set; }
        public string Cat { get; set; }

        public BMISave(string date, string bmi, string category)
        {
            Date = date;
            BMI = bmi;
            Cat = category;
           
        }

        public BMISave()
        {

        }
        public override string ToString()
        {
            return Date + "     |||     " + BMI + "     |||     " + Cat;
        }

    }
}