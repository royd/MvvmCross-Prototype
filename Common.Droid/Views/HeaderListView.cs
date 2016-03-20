using System;
using Android.Content;
using Android.Util;
using MvvmCross.Binding.Droid.Views;

namespace Common.Droid.Views
{
	public class HeaderListView : MvxListView
	{
		public HeaderListView(Context context)
			: this(context, null)
		{
		}

		public HeaderListView(Context context, IAttributeSet attrs)
			: this(context, attrs, new HeaderAdapter(context))
		{
		}

		public HeaderListView(Context context, IAttributeSet attrs, HeaderAdapter adapter)
			: base(context, attrs, adapter)
		{
			if (attrs != null)
				HeaderTemplateId = MvxAttributeHelpers.ReadAttributeValue(context, attrs, Resource.Styleable.HeaderListView, Resource.Styleable.HeaderListView_HeaderTemplate);
		}

		public int HeaderTemplateId
		{
			get
			{
				return Adapter.HeaderTemplateId;
			}
			set
			{
				Adapter.HeaderTemplateId = value;
			}
		}

		public new HeaderAdapter Adapter
		{
			get
			{
				return (HeaderAdapter) base.Adapter;
			}
			set
			{
				base.Adapter = value;
			}
		}
	}
}
	