
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace timetable_app
{
	
	 class CourseAdapter : BaseAdapter<Course>
	{
		private Context mContext;
		private int mRowLayout;
		private List<Course> Course;
		private int[] mAlternatingColors;


		public CourseAdapter(Context context, int rowLayout, List<Course> course)
		{
			mContext = context;
			mRowLayout = rowLayout;
			Course = course;
			mAlternatingColors = new int[] { 0xF2F2F2, 0x009900 };
		}

		public override int Count
		{
			get { return Course.Count; }
		}


		public override Course this[int position]
		{
			get
			{
				return Course[position]; 
			}
		}

			public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row = convertView;

			if (row == null)
			{
				row = LayoutInflater.From(mContext).Inflate(mRowLayout, parent, false);
			}

			row.SetBackgroundColor(GetColorFromInteger(mAlternatingColors[position % mAlternatingColors.Length]));

			TextView time = row.FindViewById<TextView>(Resource.Id.txtTime);
			time.Text = Course[position].Time;

			TextView course_name  = row.FindViewById<TextView>(Resource.Id.txtCourse);
			course_name.Text = Course[position].Course_name;

			TextView teacher = row.FindViewById<TextView>(Resource.Id.txtTeacher);
			teacher.Text = Course[position].Teacher;

			TextView room = row.FindViewById<TextView>(Resource.Id.txtRoom);
			room.Text = Course[position].Room;

			return row;

		}



		private Color GetColorFromInteger(int color)
		{
			return Color.Rgb(Color.GetRedComponent(color), Color.GetGreenComponent(color), Color.GetBlueComponent(color));
		}
	}
}
