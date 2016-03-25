using Android.App;
using Android.OS;
using MvvmCross.Binding.Droid.Views;
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

			m_listView = FindViewById<MvxListView>(Resource.Id.list);
			m_listView.Scroll += OnScroll;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			m_listView.Scroll -= OnScroll;
		}

		private void OnScroll(object sender, Android.Widget.AbsListView.ScrollEventArgs e)
		{
			ViewModel.ScrollCommand.Execute(null);
		}

		MvxListView m_listView;
	}
}
