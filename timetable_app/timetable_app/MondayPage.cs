
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
	[Activity(Label = "MondayPage")]
	public class MondayPage : Activity
	{
		
		private List<Course> mIteam;
		private ListView mListView;
		//private List<Course> hIteam;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			

	
			base.OnCreate(savedInstanceState);	
			SetContentView(Resource.Layout.MondayPage);
			mListView = FindViewById<ListView>(Resource.Id.mlistView);

			mIteam = new List<Course>();
			mIteam.Add(new Course { Time = "9:00" , Course_name = "Graph(A)Theory", Teacher = "Ian", Room = "0145" });
			mIteam.Add(new Course { Time = "10:00", Course_name = "Data man", Teacher = "Deirdre", Room = "0994" });
			mIteam.Add(new Course { Time = "11:00", Course_name = "null", Teacher = "   ", Room = "    " });
			mIteam.Add(new Course { Time = "12:00", Course_name = "mobile app", Teacher = "Damien", Room = "0470" });
			mIteam.Add(new Course { Time = "13:00", Course_name = "null", Teacher = "    ", Room = "   " });
			mIteam.Add(new Course { Time = "14:00", Course_name = "null", Teacher = "    ", Room = "   " });
			mIteam.Add(new Course { Time = "15:00", Course_name = "null", Teacher = "    ", Room = "   "  });
			mIteam.Add(new Course { Time = "16:00", Course_name = "Soft(A)test", Teacher = "Martin", Room = "0481" });
			mIteam.Add(new Course { Time = "16:00", Course_name = "Ser(C)side_Rad", Teacher = "Gerard", Room = "0436" });
			mIteam.Add(new Course { Time = "17:00",Course_name = "Soft(A)test", Teacher = "Martin", Room = "0481" });
			mIteam.Add(new Course { Time = "17:00", Course_name = "Ser(C)side_Rad", Teacher = "Gerard", Room = "0436"  });


			//hIteam = new List<Course>();
		//	hIteam.Add(new Course { Time = "9:00", Course_name = "null", Teacher = "    ", Room = "   " });


			CourseAdapter adapter = new CourseAdapter(this, Resource.Layout.row_Course,mIteam);
			mListView.Adapter = adapter;


		}
	}


	public class Course
	{
		public string Time { get; set; }
		public string Course_name { get; set; }
		public string Teacher { get; set; }
		public string Room { get; set; }
	}
}
