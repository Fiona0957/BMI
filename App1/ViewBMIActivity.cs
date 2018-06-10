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
    [Activity(Label = "ViewBMIActivity")]

    public class ViewBMIActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var localBMI = Application.Context.GetSharedPreferences("MyBMI", FileCreationMode.Private);
            string date = localBMI.GetString("Date", null);
            string adds = localBMI.GetString("BMI", null);
            string category = localBMI.GetString("Category", null);

            BMISave myBMI = new BMISave(date, adds, category);

            BMISave[] BMIList = {myBMI};

            ListAdapter = new ArrayAdapter<BMISave>(this, Android.Resource.Layout.SimpleListItem1, BMIList);
        }
    }    

}