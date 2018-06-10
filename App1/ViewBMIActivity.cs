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
using System.Text;
using Android.Content;
using Android.Runtime;
using Android.Views;

namespace App1
{
    [Activity(Label = "ViewBMIActivity")]

    public class ViewBMIActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.View);
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbBMI.db3");
                       Button buttonClear = FindViewById<Button>(Resource.Id.Clear);
            TextView TextDB = FindViewById<TextView>(Resource.Id.TextDB);

            var db = new SQLiteConnection(dbPath);

            var table = db.Table<BMISave>();

            foreach (var item in table)
            {
                BMISave myBMI = new BMISave(item.Date, item.BMI, item.Cat);
                TextDB.Text += myBMI + "\n";

            }

            buttonClear.Click += delegate
            {
                DeleteDatabase(dbPath);
                TextDB.Text = "";
                
            };
                
                
            }
  
        }
    }
