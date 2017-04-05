
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
	[Activity(Label = "NotePage")]
	public class NotePage : Activity
	{

		private SQLiteConnection sqliteConn;
		private const string TableName = "Note";
		private string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Note.db3");
		private Button save;
		private TextView tv_user;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			sqliteConn = new SQLiteConnection(dbPath);
			SetContentView(Resource.Layout.NotePage);
			tv_user = FindViewById<TextView>(Resource.Id.textView2);
			 
			 save = FindViewById<Button>(Resource.Id.btn_Save);


			save.Click += delegate {
				var text = FindViewById<EditText>(Resource.Id.editText1).Text;
				var time = DateTime.Now;
				MakeNote(text,time);
			};

		}


		private void MakeNote(string text,DateTime time)
		{
			if (!File.Exists(dbPath))
				sqliteConn = new SQLiteConnection(dbPath);
			
			var Note = sqliteConn.GetTableInfo("Note");

			if (Note.Count == 0)
			{
				sqliteConn.CreateTable<Note>();
			}

			Note model = new Note() { Id = 1, Details = text, Time =time};
			sqliteConn.Insert(model);
			Toast.MakeText(this, "Make a notes at below", ToastLength.Short).Show();

			ShowNote();
		}

		private void ShowNote()
		{
			   if (!File.Exists(dbPath))
			        sqliteConn = new SQLiteConnection(dbPath);
			
		   var noteTable = sqliteConn.Table<Note>();
		    StringBuilder sb = new StringBuilder();
		    foreach (var item in noteTable)
		    {
				sb.Append( item.Details +"\n"+ item.Time +"\n"+"-------------------------------------------------"+"\n");
		    }
		    tv_user.Text = sb.ToString();
		}

		//private void Delete() 
		//{
		//	if (!File.Exists(dbPath))  sqliteConn = new SQLiteConnection(dbPath);
		//	sqliteConn.Execute("drop table Note ");
		//}
	}





	[Table("Note")]
	public class Note
	{
		[PrimaryKey, AutoIncrement, Column("Id")]
		public int Id { get; set; }

		public string Details { get; set; }
	
		public DateTime Time { get; set;}
	}

}
