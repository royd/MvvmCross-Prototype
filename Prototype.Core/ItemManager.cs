using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommonSample.Core.Data;

namespace Prototype.Core
{
	public class ItemManager
	{
		public ItemManager()
		{
			m_items = Collections.SmallStringCollection.Select(x => new Item(x)).ToList();
		}

		public ReadOnlyCollection<Item> Items
		{
			get
			{
				return new ReadOnlyCollection<Item>(m_items.Where(x => !x.IsDeleted).ToList());
			}
		}

		public void DeleteItem(Item item)
		{
			Item collectionItem = GetItem(item);
			if (collectionItem != null)
				collectionItem.IsDeleted = true;
		}

		public void UndoDeleteItem(Item item)
		{
			Item collectionItem = GetItem(item);
			if (collectionItem != null)
				collectionItem.IsDeleted = false;
		}

		private Item GetItem(Item item)
		{
			return m_items.FirstOrDefault(x => x == item);
		}

		readonly List<Item> m_items;
	}
}
