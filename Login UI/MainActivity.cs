using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Java.Lang;
using Android.Views;

namespace com.gmit.TimetableApp
{
	[Activity(Label = "com.gmit.TimetableApp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		private Button mbtsignup;
		private Button mbtsignin;
		private ProgressBar mprogressbar;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);


			SetContentView(Resource.Layout.MainPage);

			mbtsignin = FindViewById<Button>(Resource.Id.btSignIn);
			mbtsignup = FindViewById<Button>(Resource.Id.btSignUp);
			mprogressbar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

			mbtsignup.Click += (object sender, System.EventArgs e) =>
			{
				//pull up to dilog
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				dialog_SignUp dsignup = new dialog_SignUp();
				dsignup.Show(transaction, "dialogsignup_fragment");

				dsignup.mOnSignUpComplete += dsignup_mOnSignUpComplete;

			};





			mbtsignin.Click += (object sender, System.EventArgs e) =>
			{
				//login individual
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				dialog_SignIn dsignin = new dialog_SignIn();
				dsignin.Show(transaction, "dialogsignin_fragment");
			};


		}

		void dsignup_mOnSignUpComplete(object sender, onSignUpEventArgs e)
		{
			mprogressbar.Visibility = ViewStates.Visible;
			Thread thread = new Thread(ActLikeRequest);
			thread.Start();
		}

		private void ActLikeRequest()
		{
			Thread.Sleep(3000);
			RunOnUiThread(() => { mprogressbar.Visibility = ViewStates.Invisible; });
		}
	}
}

