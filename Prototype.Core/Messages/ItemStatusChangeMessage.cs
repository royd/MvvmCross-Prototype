using System;
using MvvmCross.Plugins.Messenger;

namespace Prototype.Core
{
	public class ItemStatusChangeMessage : MvxMessage
	{
		public ItemStatusChangeMessage(object sender, Item item, ItemStatus status)
			: base(sender)
		{
			m_item = item;
			m_status = status;
		}

		public Item Item
		{
			get
			{
				return m_item;
			}
		}

		public ItemStatus Status
		{
			get
			{
				return m_status;
			}
		}

		readonly Item m_item;
		readonly ItemStatus m_status;
	}
}
