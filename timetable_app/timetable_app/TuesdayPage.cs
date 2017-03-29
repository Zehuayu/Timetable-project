
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
	[Activity(Label = "TuesdayPage")]
	public class TuesdayPage : Activity
	{

	private List<Course> mIteam;
	private ListView mListViewtu;
	//private List<Course> hIteam;


	protected override void OnCreate(Bundle Bundle)
	{



			base.OnCreate(Bundle);
		SetContentView(Resource.Layout.TuesdayPage);
		mListViewtu = FindViewById<ListView>(Resource.Id.mlistView);

		mIteam = new List<Course>();
		mIteam.Add(new Course { Time = "9:00",  Course_name = "Soft(C)test", Teacher = "Martin", Room = "0436" });
		mIteam.Add(new Course { Time = "10:00", Course_name = "Soft(C)test", Teacher = "Martin", Room = "0436" });
		mIteam.Add(new Course { Time = "11:00", Course_name = "Mobil(A)App", Teacher = "Damien", Room = "0470" });
		mIteam.Add(new Course { Time = "12:00", Course_name = "Mobil(A)App", Teacher = "Damien", Room = "0470"});
		mIteam.Add(new Course { Time = "13:00", Course_name = "null", Teacher = "    ", Room = "   "  });
		mIteam.Add(new Course { Time = "14:00", Course_name = "Soft(B)test", Teacher = "Martin", Room = "0436" });
		mIteam.Add(new Course { Time = "15:00", Course_name = "Soft(B)test", Teacher = "Martin", Room = "0436" });
		mIteam.Add(new Course { Time = "16:00", Course_name = "Ser(C)side_Rad", Teacher = "Gerard", Room = "0436" });
		mIteam.Add(new Course { Time = "17:00", Course_name = "Ser(C)side_Rad", Teacher = "Gerard", Room = "0436" });
        mIteam.Add(new Course { Time = "18:00", Course_name = "null", Teacher = "    ", Room = "   "  });

		//hIteam = new List<Course>();
		//	hIteam.Add(new Course { Time = "9:00", Course_name = "null", Teacher = "    ", Room = "   " });


		   CourseAdapter adapter = new CourseAdapter(this, Resource.Layout.row_Course, mIteam);
			mListViewtu.Adapter = adapter;
	}
	}
}
