using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;

namespace MadJunior
{
    [Activity(Label = "Mad Junior", WindowSoftInputMode = SoftInput.StateHidden)]
    public class Login : Activity
    {
        private EditText etPlayerName;

        private Button btnStart;
        private Button btnSkip;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Remove ActionBar Title
            Window.RequestFeature(WindowFeatures.NoTitle);
            // Set view from the "Login" layout resource
            SetContentView(Resource.Layout.Login);

            etPlayerName = FindViewById<EditText>(Resource.Id.etPlayerName);
            btnStart = FindViewById<Button>(Resource.Id.btnStart);
            btnSkip = FindViewById<Button>(Resource.Id.btnSkip);

            // On Button Start click
            btnStart.Click += BtnStart_Click;

            // On Button Skip click
            btnSkip.Click += BtnSkip_Click;
            
        }

        // On Button Skip Clicked
        private void BtnSkip_Click(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(Board)));
            Finish();
        }

        // On Button Start Clicked
        private void BtnStart_Click(object sender, System.EventArgs e)
        {
            if (etPlayerName.Text.Length > 0)
            {
                Intent intent = new Intent(this, typeof(Board));
                StartActivity(intent);
                Finish();
            }
        }


        // When a User press back
        public override void OnBackPressed()
        {
            Intent intent = new Intent(this, typeof(Home));
            StartActivity(intent);
            Finish();
        }
    }
}

