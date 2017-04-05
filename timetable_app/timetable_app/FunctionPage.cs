
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

namespace timetable_app
{
	[Activity(Label = "FunctionPage")]
	public class FunctionPage : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
             base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.FunctionPage);

			var bt_watchtable = FindViewById<Button>(Resource.Id.btn_LookTimetable);
			var bt_note = FindViewById<Button>(Resource.Id.btn_Note);
			var bt_update = FindViewById<Button>(Resource.Id.btn_Update);

			var bt_back = FindViewById<Button>(Resource.Id.btn_Back);

			bt_back.Click+=delegate {
				Intent nextpage = new Intent(this, typeof(MainActivity));
				StartActivity(nextpage);

			};






			bt_update.Click+=delegate {

				Intent nextpage = new Intent(this, typeof(UpdagePage));
				StartActivity(nextpage);


			};

			bt_note.Click +=delegate {
				
			
				Intent nextpage = new Intent(this, typeof(NotePage));
				StartActivity(nextpage);

			
			};







			bt_watchtable.Click +=delegate {


				if (DateTime.Now.DayOfWeek.ToString() == "Monday")
				{


					Intent nextpage = new Intent(this, typeof(MondayPage));
					StartActivity(nextpage);
				}
				else if (DateTime.Now.DayOfWeek.ToString() == "Tuesday")
				{
					
					Intent nextpage = new Intent(this, typeof(TuesdayPage));
					StartActivity(nextpage);

				}
				else if (DateTime.Now.DayOfWeek.ToString() == "Wednesday")
				{


					Intent nextpage = new Intent(this, typeof(WednesdayPage));
					StartActivity(nextpage);

				}
				else if (DateTime.Now.DayOfWeek.ToString() == "Thursday")
				{


					Intent nextpage = new Intent(this, typeof(ThursdayPage));
					StartActivity(nextpage);
				}
				else if (DateTime.Now.DayOfWeek.ToString() == "Friday")
				{
					
					Intent nextpage = new Intent(this, typeof(FridayPage));
					StartActivity(nextpage);
				}
				else if (DateTime.Now.DayOfWeek.ToString() == "Saturday" || DateTime.Now.DayOfWeek.ToString() == "Sunday")
				{
					Toast.MakeText(this, "Successful Login, but there are not any class today ", ToastLength.Short).Show();
				}
			};




		}
	}
}
