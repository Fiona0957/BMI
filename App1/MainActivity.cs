using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int BMI = 0;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBMI.db3");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Button button = FindViewById<Button>(Resource.Id.Calculate);
            Button buttonSave = FindViewById<Button>(Resource.Id.Save);
            TextView TextBMI = FindViewById<TextView>(Resource.Id.TextBMI);
            EditText EditHeight = FindViewById<EditText>(Resource.Id.editHeight);
            EditText EditWeight = FindViewById<EditText>(Resource.Id.editWeight);
            TextView TextCat = FindViewById<TextView>(Resource.Id.TextCat);
            EditText EditAge = FindViewById<EditText>(Resource.Id.editAge);
            
            BMI = BMI + 1;

            button.Click += delegate
            {
                double numHeight;
                double numWeight;
                int numAge;
                bool parsedH = Double.TryParse(EditHeight.Text, out numHeight);
                bool parsedW = Double.TryParse(EditWeight.Text, out numWeight);
                bool parsedA = int.TryParse(EditAge.Text, out numAge);
                if (parsedH && parsedW && parsedA)
                {
                    numHeight = numHeight / 100;
                    double add = numWeight / (numHeight * numHeight);
                    add = Math.Round(add, 2);
                    TextBMI.Text = string.Format("Your BMI is: " + add);
                    if (add <= 18.5)
                        TextCat.Text = string.Format("You are: Underweight");
                    if (add > 18.5 && add <= 25)
                        TextCat.Text = string.Format("You are: Healthy");
                    if (add > 25 && add <= 30)
                        TextCat.Text = string.Format("You are: Overweight");
                    if (add > 30)
                        TextCat.Text = string.Format("You are: Obese");
                }
                else
                {
                    TextBMI.Text = string.Format("Your BMI is: " + "error");
                    TextCat.Text = string.Format("Please fill in all fields");
                }
            };

            buttonSave.Click += delegate
            {

            };




        }
    }
}

