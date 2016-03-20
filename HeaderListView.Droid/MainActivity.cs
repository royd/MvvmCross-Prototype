using Android.App;
using Android.OS;
using HeaderListView.Core;
using MvvmCross.Droid.Views;

namespace HeaderListView.Droid
{
	[Activity(Label = "MvvmCross-Prototype", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : MvxActivity<MainViewModel>
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
		}
	}
}
