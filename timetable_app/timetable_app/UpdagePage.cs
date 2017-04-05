
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace timetable_app
{
	[Activity(Label = "UpdagePage")]
	public class UpdagePage : Activity
	{
		private SQLiteConnection sqliteConn;
		private const string TableName = "UserInfo";
		private string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "UserInfo.db3");

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.UpdatePage);
			var bt_save = FindViewById<Button>(Resource.Id.up_save);
			sqliteConn = new SQLiteConnection(dbPath);

			bt_save.Click += delegate
			{

				string password1 = FindViewById<EditText>(Resource.Id.up_pwd1).Text;
				string password2 = FindViewById<EditText>(Resource.Id.up_pwd).Text;

				if (password1.Equals(password2))
				{
					Save(password1);
				}
				else
				{
					Toast.MakeText(this, "two password is not the same! ", ToastLength.Short).Show();
				}
			};
		}
		private void Save(string password)
		{
			string user = FindViewById<EditText>(Resource.Id.up_username).Text;
			string password1 = FindViewById<EditText>(Resource.Id.up_pwd1).Text;

			if (!File.Exists(dbPath))
				sqliteConn = new SQLiteConnection(dbPath);
			sqliteConn.Execute("update UserInfo set Pwd = ? where UserName = ?", password1, user);

			Toast.MakeText(this, "successfully modify password! ", ToastLength.Short).Show();

			Intent nextpage = new Intent(this, typeof(MainActivity));
			StartActivity(nextpage);

		}
	}

}
