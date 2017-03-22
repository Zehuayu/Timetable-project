
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime; 
using Android.Util;
using Android.Views;
using Android.Widget;

namespace com.gmit.TimetableApp
{
	public class onSignUpEventArgs : EventArgs

	{
		private string Nufirstname;// new user details
		private string Nupassword;
		private string Nuemail;

		public string FirstName
		{ 
			get { return Nufirstname;}
			set { Nufirstname = value;}
		}

		public string Password
		{
			get { return Nupassword;}
			set { Nupassword = value;}
		}

		public string Email
		{
			get { return Nuemail;}
			set { Nuemail = value;}
		}

		public onSignUpEventArgs(string firstname, string password, string email) : base()
		{
			FirstName = firstname;
			Password = password;
			Email = email;
		}
	}
	public class dialog_SignUp : DialogFragment
	{

		private EditText mtextfirstname;
		private EditText mtextpassword;
		private EditText mtextemail;
		private Button mbtsignup;


		public event EventHandler<onSignUpEventArgs> mOnSignUpComplete;//let value can be inputed in databases.

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);


			// Create your fragment here
		}



		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			

		    base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.dialog_signup, container, false);

	
			mtextfirstname = view.FindViewById<EditText>(Resource.Id.suFirstNametext);
			mtextpassword = view.FindViewById<EditText>(Resource.Id.suPasswordtext);
			mtextemail = view.FindViewById<EditText>(Resource.Id.suemailaddress);
			mbtsignup = view.FindViewById<Button>(Resource.Id.btsignupdialog);


			mbtsignup.Click += mbtsignup_Click;


			return view;
		}
		void mbtsignup_Click(object sender, EventArgs e) {

			mOnSignUpComplete.Invoke(this, new onSignUpEventArgs(mtextfirstname.Text, mtextpassword.Text, 
			                                                     mtextemail.Text));
			this.Dismiss();
		}

	}
}
