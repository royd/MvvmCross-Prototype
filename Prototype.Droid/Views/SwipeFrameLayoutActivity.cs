using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Prototype.Core;

namespace Prototype.Droid
{
	[Activity(Label = "SwipeFrameLayoutActivity")]			
	public class SwipeFrameLayoutActivity : MvxActivity<SwipeFrameLayoutViewModel>
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.SwipeFrameLayoutView);

			Title = ViewModel.Title;
		}
	}
}
