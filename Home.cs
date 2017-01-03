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

namespace MadJunior
{
    [Activity(Label = "Mad Junior", MainLauncher = true, Icon = "@drawable/icons")]
    public class Home : Activity
    {

        private Button btnNewChallenge;
        private Button btnLeaderBoard;
        private Button btnGlobal;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Remove ActionBar Title
            Window.RequestFeature(WindowFeatures.NoTitle);
            // Set view from the "Home" layout resource
            SetContentView(Resource.Layout.Home);

            btnNewChallenge = FindViewById<Button>(Resource.Id.btnNewChallenge);
            btnLeaderBoard = FindViewById<Button>(Resource.Id.btnLeaderBoard);
            btnGlobal = FindViewById<Button>(Resource.Id.btnGlobal);

            // On Button NewChallenge click
            btnNewChallenge.Click += BtnNewChallenge_Click; 

        }

        private void BtnNewChallenge_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Login));
            StartActivity(intent);
            Finish();

        }


        // When a User press back 
        public override void OnBackPressed()
        {
            var alert = new AlertDialog.Builder(this);
            alert.SetTitle("Œ—ÊÃ „‰ «··⁄»…");
            alert.SetPositiveButton("‰⁄„", delegate {
                Finish();
            });
            alert.SetNegativeButton("·«", delegate {  });
            alert.Create();
            alert.Show();
        }
    }
}