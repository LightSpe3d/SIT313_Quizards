
using Android.App;
using Android.Widget;
using Android.OS;


namespace Project313
{
    [Activity(Label = "Quizards", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity,IDialogInterfaceonClickListener, IDialogInterfaceonMultiChoiceClickListener
    {
        static string[] choices =
        {
            "Answer 1","Answer 2", "Answer 3","Answer 4"

        };
        bool[] itemsChecked = new bool[choices.Length];
        ProgressDialog progressDialog;

        public void OnClick(IDialogInterface dialog, int which)
        {
            if (which < 0) // "OK" button
                Toast.MakeText(this, "OK button clicked", ToastLength.Short).Show();
            else if (which > 0) //"Cancel' button
                Toast.MakeText(this, "Cancel  button clicked", ToastLength.Short).Show();
        }

        public void OnClick(IDialogInterface dialog, int which, bool isChecked)
        {
            Toast.MakeText(this, choices[which] + (isChecked?"checked":"unchecked"), ToastLength.Short).Show();
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //get out button from the layout resource
            //attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                ShowDialog(0);
            };

        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case 0:
                    {
                        return new AlertDialog.Builder(this)
                            .SetIcon(Resource.Drawable.Icon) //setting the icon for the dialog
                            .SetTitle("Multi Choices Dialog") //setting the title for the dialog
                            .SetPositiveButton("OK", this) //Need implement IDialoagInterface.OnClick
                            .SetNegativeButton("Cancel", this) //Same as above
                            .SetMultiChoiceItems(choices, itemsChecked, this)
                            .Create();

                    }
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}

