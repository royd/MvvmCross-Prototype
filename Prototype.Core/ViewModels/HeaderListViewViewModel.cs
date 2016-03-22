using System;
using System.Collections.ObjectModel;
using CommonSample.Core.Data;
using MvvmCross.Core.ViewModels;

namespace Prototype.Core
{
	public class HeaderListViewViewModel : MvxViewModel
	{
		public string Title
		{
			get
			{
				return string.Format(OurResources.FeatureTitleFormat, OurResources.HeaderListViewFeatureTitle);
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
