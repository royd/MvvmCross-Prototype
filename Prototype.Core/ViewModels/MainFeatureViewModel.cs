using System;

namespace Prototype.Core
{
	public class MainFeatureViewModel
	{
		public MainFeatureViewModel(string title, Type viewModelType)
		{
			if (title == null)
				throw new ArgumentNullException("title");
			if (viewModelType == null)
				throw new ArgumentNullException("viewModelType");
			
			m_title = title;
			m_viewModelType = viewModelType;
		}

		public string Title
		{
			get
			{
				return m_title;
			}
		}

		public Type  ViewModelType
		{
			get
			{
				return m_viewModelType;
			}
		}

		readonly string m_title;
		readonly Type m_viewModelType;
	}
}
