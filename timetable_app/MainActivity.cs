using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;
using System.IO;
using System.Text;
using Android.Content;

namespace XamarinSqlite_Demo
{
    [Activity(Label = "XamarinSqlite_Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
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
			SetContentView(Resource.Layout.register);

            sqliteConn = new SQLiteConnection(dbPath);

            btnLogin = FindViewById<Button>(Resource.Id.btn_login);
            btnRegister = FindViewById<Button>(Resource.Id.btn_register);
           // tv_user = FindViewById<TextView>(Resource.Id.tv_user);

           

			btnLogin.Click += delegate {
                var userName = FindViewById<EditText>(Resource.Id.userName).Text;
                var pwd = FindViewById<EditText>(Resource.Id.pwd).Text;

				Login(userName, pwd);
            };



            btnRegister.Click += delegate
            {
                var userName = FindViewById<EditText>(Resource.Id.userName).Text;
                var pwd = FindViewById<EditText>(Resource.Id.pwd).Text;
				Register(userName, pwd );
            };
        }



        private void Login(string  userName,string  pwd)
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
                Toast.MakeText(this, "account or password is incorrect", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "successful log in", ToastLength.Short).Show();
				Intent nextpage = new Intent(this, typeof(mondayActivity));
				StartActivity(nextpage);

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



		private void Register(string  userName,string pwd)
        {
            if(!File.Exists(dbPath))
                sqliteConn = new SQLiteConnection(dbPath);
			var userInfos = sqliteConn.Table<UserInfo>();
            var userInfo = userInfos.Where(p => p.Pwd == pwd && p.UserName == userName).FirstOrDefault();
	

            var userInfoTable = sqliteConn.GetTableInfo(TableName);
			if (userInfoTable.Count == 0 )
            {
                sqliteConn.CreateTable<UserInfo>();
            }
			//if (userInfo.UserName == userName) 
			//{
			//	Toast.MakeText(this, "The accound used", ToastLength.Short).Show();
			//}
			UserInfo model = new UserInfo() {Id=1, UserName=userName,Pwd=pwd};
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
        [PrimaryKey,AutoIncrement,Column("Id")]
          public int Id { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
    }

	[Table("Student")]
	public class student
	{
		[PrimaryKey, AutoIncrement, Column("studentID")]

		   public string studentID { get; set; }

			public string major { get; set; }
					
	}

}


