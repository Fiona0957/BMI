using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SQLite;
using System.Text;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;



namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int BMI = 34;


        string dbPaths = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBMI.db3");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Button button = FindViewById<Button>(Resource.Id.Calculate);
            Button buttonSave = FindViewById<Button>(Resource.Id.Save);
            Button buttonView = FindViewById<Button>(Resource.Id.View);
            TextView TextBMI = FindViewById<TextView>(Resource.Id.TextBMI);
            EditText EditHeight = FindViewById<EditText>(Resource.Id.editHeight);
            EditText EditWeight = FindViewById<EditText>(Resource.Id.editWeight);
            TextView TextCat = FindViewById<TextView>(Resource.Id.TextCat);
            EditText EditAge = FindViewById<EditText>(Resource.Id.editAge);
            TextView TextDB = FindViewById<TextView>(Resource.Id.TextDB);
            

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
                    TextBMI.Text = string.Format("Your BMI is: ");
                    TextCat.Text = string.Format("You are: ");

                    Android.Widget.Toast.MakeText(this, "Please fill in all fields", ToastLength.Short).Show();
                }
            };

            buttonSave.Click += delegate
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
                    string adds;
                    adds = (add.ToString());
                    Android.Widget.Toast.MakeText(this, "Saved", ToastLength.Short).Show();
                    DateTime localDate = DateTime.Today;
                    string date;
                    date = (localDate.ToString("d"));
                    string category = "";
                    if (add <= 18.5)
                        category = "Underweight";
                    if (add > 18.5 && add <= 25)
                        category = "Healthy";
                    if (add > 25 && add <= 30)
                        category = "Overweight";
                    if (add > 30)
                        category = "Obese";


                    var db = new SQLiteConnection(dbPaths);

                    db.CreateTable<BMISave>();

                    BMISave mybmi = new BMISave(date, adds, category);

                    db.Insert(mybmi);
                   
                }
                else
                {
                    Android.Widget.Toast.MakeText(this, "Please fill in all fields", ToastLength.Short).Show();
                }

            };

            buttonView.Click += delegate
            {

                var db = new SQLiteConnection(dbPaths);

                db.CreateTable<BMISave>();
                StartActivity(typeof(ViewBMIActivity));
   
              
            };
        }
    }
 
}


