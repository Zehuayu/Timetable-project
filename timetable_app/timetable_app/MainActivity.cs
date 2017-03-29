using Android.App;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;
using Android.Content;
using System;

namespace timetable_app
{
	[Activity(Label = "timetable_app", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
					
			private SQLiteConnection sqliteConn;
			private const string TableName = "UserInfo";
			private const string tableName = "Student";
			private string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "userinfo.db3");
			private Button btnLogin;
			private Button btnRegister;
	     	
		   
		  





			protected override void OnCreate(Bundle bundle)
			{
				base.OnCreate(bundle);

				// Set our view from the "main" layout resource
			     SetContentView(Resource.Layout.Main);

				sqliteConn = new SQLiteConnection(dbPath);

				btnLogin = FindViewById<Button>(Resource.Id.btn_login);
				btnRegister = FindViewById<Button>(Resource.Id.btn_register);
				// tv_user = FindViewById<TextView>(Resource.Id.tv_user);



				btnLogin.Click += delegate
				{
					var userName = FindViewById<EditText>(Resource.Id.userName).Text;
					var pwd = FindViewById<EditText>(Resource.Id.pwd).Text;

					Login(userName, pwd);
				};



				btnRegister.Click += delegate
				{
					var userName = FindViewById<EditText>(Resource.Id.userName).Text;
					var pwd = FindViewById<EditText>(Resource.Id.pwd).Text;
					Register(userName, pwd);
				};
			}



			private void Login(string userName, string pwd)
			{
				if (!File.Exists(dbPath))
				{
					sqliteConn = new SQLiteConnection(dbPath);
				}
				var userInfoTable = sqliteConn.GetTableInfo(TableName);
				if (userInfoTable.Count == 0)
				{
					sqliteConn.CreateTable<UserInfo>();
				}
				var userInfos = sqliteConn.Table<UserInfo>();
				var userInfo = userInfos.Where(p => p.Pwd == pwd && p.UserName == userName).FirstOrDefault();
				if (userInfo == null)
				{
					Toast.MakeText(this, "Bad guys,you can't play me without correct account and password!", ToastLength.Short).Show();
				}
				
				
				 else if (DateTime.Now.DayOfWeek.ToString() == "Monday")
				{

				Toast.MakeText(this, "successful log in", ToastLength.Short).Show();
					Intent nextpage = new Intent(this, typeof(MondayPage));
					StartActivity(nextpage);
				}
				else if (DateTime.Now.DayOfWeek.ToString() == "Tuesday")
				{
				Toast.MakeText(this, "successful log in", ToastLength.Short).Show();
					Intent nextpage = new Intent(this, typeof(TuesdayPage));
					StartActivity(nextpage);

				}
				else if (DateTime.Now.DayOfWeek.ToString() == "Wednesday")
				{

				Toast.MakeText(this, "successful log in", ToastLength.Short).Show();
					Intent nextpage = new Intent(this, typeof(WednesdayPage));
					StartActivity(nextpage);

				}
				else if (DateTime.Now.DayOfWeek.ToString() == "Thursday")
				{

				Toast.MakeText(this, "successful log in", ToastLength.Short).Show();
					Intent nextpage = new Intent(this, typeof(ThursdayPage));
					StartActivity(nextpage);
				}
				else if (DateTime.Now.DayOfWeek.ToString() == "Friday")
				{
				Toast.MakeText(this, "successful log in", ToastLength.Short).Show();
					Intent nextpage = new Intent(this, typeof(FridayPage));
					StartActivity(nextpage);
				}
				else if (DateTime.Now.DayOfWeek.ToString() == "Saturday" || DateTime.Now.DayOfWeek.ToString() == "Sunday")
				{ 
					Toast.MakeText(this, "Successful Login, but there are not any class today ", ToastLength.Short).Show();
				}
			    

			}



			//private void ShowUser()
			//{
			//    if (!File.Exists(dbPath))
			//        sqliteConn = new SQLiteConnection(dbPath);

			//    var userInfoTable = sqliteConn.Table<UserInfo>();
			//    StringBuilder sb = new StringBuilder();
			//    foreach (var item in userInfoTable)
			//    {
			//         sb.Append("username:" + item.UserName + "pwd:" + item.Pwd + "\n");
			//    }
			//    tv_user.Text = sb.ToString();
			//}



			private void Register(string userName, string pwd)
			{
				if (!File.Exists(dbPath))
					sqliteConn = new SQLiteConnection(dbPath);		     	
				var userInfoTable = sqliteConn.GetTableInfo(TableName);
				if (userInfoTable.Count == 0)
				{
					sqliteConn.CreateTable<UserInfo>();
				}
				
				UserInfo model = new UserInfo() { Id = 1, UserName = userName, Pwd = pwd };
				sqliteConn.Insert(model);
				Toast.MakeText(this, "successful sign up", ToastLength.Short).Show();

				//ShowUser();
			}



		}
		public class Studenttable
		{

		}

		[Table("UserInfo")]
		public class UserInfo
		{
			[PrimaryKey, AutoIncrement, Column("Id")]
			public int Id { get; set; }
			public string UserName { get; set; }
			public string Pwd { get; set; }
		}

		
}

