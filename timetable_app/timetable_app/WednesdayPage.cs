
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
	[Activity(Label = "WednesdayPage")]
	public class WednesdayPage : Activity
	{
		
		private List<Course> mIteam;
		private ListView mListView;
		//private List<Course> hIteam;


		protected override void OnCreate(Bundle savedInstanceState)
		{



			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.WednesdayPage);
			mListView = FindViewById<ListView>(Resource.Id.mlistView);

			mIteam = new List<Course>();
			mIteam.Add(new Course { Time = "9:00", Course_name = "null", Teacher = "    ", Room = "   " });
			mIteam.Add(new Course { Time = "10:00", Course_name = "Graph Theory", Teacher = "Ian", Room = "0938" });
			mIteam.Add(new Course { Time = "11:00", Course_name = "Pro practice", Teacher = "Bian", Room = "0208" });
			mIteam.Add(new Course { Time = "12:00", Course_name = "NUll", Teacher = "   ", Room = "    " });
			mIteam.Add(new Course { Time = "13:00", Course_name = "Server Rad", Teacher = "Grader", Room = "0997" });
			mIteam.Add(new Course { Time = "14:00", Course_name = "null", Teacher = "    ", Room = "   " });
			mIteam.Add(new Course { Time = "15:00", Course_name = "Soft test", Teacher = "Martin", Room = "0994" });
			mIteam.Add(new Course { Time = "16:00", Course_name = "data man", Teacher = "pr", Room = "0995" });


			//hIteam = new List<Course>();
			//	hIteam.Add(new Course { Time = "9:00", Course_name = "null", Teacher = "    ", Room = "   " });


			CourseAdapter adapter = new CourseAdapter(this, Resource.Layout.row_Course, mIteam);


			mListView.Adapter = adapter;
		}

		}
	}

