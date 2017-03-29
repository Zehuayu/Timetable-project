
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
	[Activity(Label = "ThursdayPage")]
	public class ThursdayPage : Activity
	{
		private List<Course> mIteam;
		private ListView mListView;
		//private List<Course> hIteam;


		protected override void OnCreate(Bundle savedInstanceState)
		{



			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ThursdayPage);
			mListView = FindViewById<ListView>(Resource.Id.mlistView);

			mIteam = new List<Course>();
			mIteam.Add(new Course { Time = "9:00",  Course_name = "Mobil(B)App", Teacher = "Demine", Room = "PF18" });
			mIteam.Add(new Course { Time = "10:00", Course_name = "Mobil(B)App", Teacher = "Demine", Room = "PF18" });
			mIteam.Add(new Course { Time = "11:00", Course_name = "Mobil(C)App", Teacher = "Demine", Room = "PF18" });
			mIteam.Add(new Course { Time = "12:00", Course_name = "Mobil(C)App", Teacher = "Demine", Room = "PF18" });
			mIteam.Add(new Course { Time = "13:00", Course_name = "null", Teacher = "    ", Room = "   " });
			mIteam.Add(new Course { Time = "14:00", Course_name = "Ser(A)side_Rad", Teacher = "Gerard", Room = "0436" });
			mIteam.Add(new Course { Time = "15:00", Course_name = "Ser(A)side_Rad", Teacher = "Gerard", Room = "0436" });
			mIteam.Add(new Course { Time = "16:00", Course_name = "data man", Teacher = "Patrick", Room = "0483" });
			mIteam.Add(new Course { Time = "17:00", Course_name = "null", Teacher = "    ", Room = "   "  });
			mIteam.Add(new Course { Time = "18:00", Course_name = "null", Teacher = "    ", Room = "   " });
			//hIteam = new List<Course>();
			//	hIteam.Add(new Course { Time = "9:00", Course_name = "null", Teacher = "    ", Room = "   " });


			CourseAdapter adapter = new CourseAdapter(this, Resource.Layout.row_Course, mIteam);


			mListView.Adapter = adapter;
		}
	}
}
