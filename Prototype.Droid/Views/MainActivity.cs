using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Prototype.Core.ViewModels;

namespace Prototype.Droid.Views
{
	[Activity(Label = "Prototype.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : MvxActivity<MainViewModel>
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);
		}
	}
}
