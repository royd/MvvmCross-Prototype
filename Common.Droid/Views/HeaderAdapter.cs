using Android.Content;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace Common.Droid.Views
{
	public class HeaderAdapter : MvxAdapter
	{
		public HeaderAdapter(Context context)
			: this(context, MvxAndroidBindingContextHelpers.Current())
		{
		}

		public HeaderAdapter(Context context, IMvxAndroidBindingContext bindingContext)
			: base(context, bindingContext)
		{
			m_bindingContext = bindingContext;
		}

		public int HeaderTemplateId
		{
			get; set;
		}

		public override int Count
		{
			get
			{
				return HeaderTemplateId == 0 ? base.Count : base.Count + 1;
			}
		}

		protected override View GetView(int position, View convertView, ViewGroup parent, int templateId)
		{
			if (m_headerView != null && m_headerView == convertView)
				convertView = null;
			
			View view;
			if (HeaderTemplateId == 0)
				view = base.GetView(position, convertView, parent, templateId);
			else if (position == 0)
				view = m_headerView ?? (m_headerView = m_bindingContext.BindingInflate(HeaderTemplateId, null));
			else
				view = base.GetView(position - 1, convertView, parent, templateId);

			return view;
		}
			
		readonly IMvxAndroidBindingContext m_bindingContext;
		View m_headerView;
	}
}
