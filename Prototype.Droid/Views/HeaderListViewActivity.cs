using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Prototype.Core;

namespace Prototype.Droid
{
	[Activity(Label="HeaderListViewActivity")]			
	public class HeaderListViewActivity : MvxActivity<HeaderListViewViewModel>
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.HeaderListView);

			Title = ViewModel.Title;
		}
	}
}
