using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Prototype.Core.ViewModels
{
	public class MainViewModel : MvxViewModel
	{
		public ReadOnlyCollection<MainFeatureViewModel> Features
		{
			get
			{
				return s_features;
			}
		}

		public ICommand ShowFeatureCommand
		{
			get
			{
				return m_showFeatureCommand ?? (m_showFeatureCommand = new MvxCommand<MainFeatureViewModel>(ShowFeature));
			}
		}

		private void ShowFeature(MainFeatureViewModel featureViewModel)
		{
			ShowViewModel(featureViewModel.ViewModelType);
		}

		static readonly ReadOnlyCollection<MainFeatureViewModel> s_features = new ReadOnlyCollection<MainFeatureViewModel>(new List<MainFeatureViewModel>
		{
			new MainFeatureViewModel(OurResources.HeaderListViewFeatureTitle, typeof(HeaderListViewViewModel)),
			new MainFeatureViewModel(OurResources.SwipeFrameLayoutFeatureTitle, typeof(SwipeFrameLayoutViewModel))
		});

		ICommand m_showFeatureCommand;
	}
}
