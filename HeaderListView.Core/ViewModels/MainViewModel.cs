using System;
using System.Collections.ObjectModel;
using CommonSample.Core.Data;
using MvvmCross.Core.ViewModels;

namespace HeaderListView.Core
{
	public class MainViewModel : MvxViewModel
	{
		public string Title
		{
			get
			{
				return OurResources.Title;
			}
		}

		public string ListHeaderTitle
		{
			get
			{
				return OurResources.HeaderListViewTitle;
			}
		}

		public ReadOnlyCollection<string> Items
		{
			get
			{
				return Collections.SmallStringCollection;
			}
		}
	}
}
