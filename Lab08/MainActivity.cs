using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //var ViewGroup = (Android.Views.ViewGroup)
            //    Window.DecorView.FindViewById(Android.Resource.Id.Content);
            //var MainLayout = ViewGroup.GetChildAt(0) as LinearLayout;

            //var HeaderImage = new ImageView(this); 
            //    HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30); 
            //MainLayout.AddView(HeaderImage); 

            //var UserNameTextView = new TextView(this); 
            //    UserNameTextView.Text = GetString(Resource.String.userName); 
            //MainLayout.AddView(UserNameTextView); 

            ValidateJC();

        }


        private async void ValidateJC()
        {
            string StudentEmail = @"energycuenta@yahoo.com";
            string PasswordStudent = "******"; ///comentado 2018 
            string myDevice = Android.Provider.Settings.Secure.GetString(
                    ContentResolver,
                    Android.Provider.Settings.Secure.AndroidId);

            var userNameEdit = FindViewById<EditText>(Resource.Id.userNameEditText);
            var statusEdit = FindViewById<EditText>(Resource.Id.statusEditText);
            var tokenEdit = FindViewById<EditText>(Resource.Id.tokenEditText);

            var ServiceClient = new SALLab08.ServiceClient();
            var Result = await ServiceClient.ValidateAsync(StudentEmail, PasswordStudent, myDevice);

            userNameEdit.Text = $"{Result.Fullname}";
            statusEdit.Text = $"{Result.Status}";
            tokenEdit.Text = $"{Result.Token}";

        }
    }
}

