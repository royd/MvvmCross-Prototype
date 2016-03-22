using System;
using System.Collections.ObjectModel;
using CommonSample.Core.Data;
using MvvmCross.Core.ViewModels;

namespace Prototype.Core
{
	public class SwipeFrameLayoutViewModel : MvxViewModel
	{
		public string Title
		{
			get
			{
				return string.Format(OurResources.FeatureTitleFormat, OurResources.SwipeFrameLayoutFeatureTitle);
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
