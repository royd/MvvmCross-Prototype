using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace Prototype.Core
{
	public class SwipeFrameLayoutViewModel : MvxViewModel
	{
		public SwipeFrameLayoutViewModel()
		{
			m_items = new ObservableCollection<SwipeFrameLayoutItemViewModel>();
			m_readOnlyItems = new ReadOnlyObservableCollection<SwipeFrameLayoutItemViewModel>(m_items);
			m_deletedItems = new HashSet<Item>();

			m_itemStatusChangeSubscription = Mvx.Resolve<IMvxMessenger>().SubscribeOnMainThread<ItemStatusChangeMessage>(OnItemStatusChanged);
		}

		public string Title
		{
			get
			{
				return string.Format(OurResources.FeatureTitleFormat, OurResources.SwipeFrameLayoutFeatureTitle);
			}
		}

		public ReadOnlyObservableCollection<SwipeFrameLayoutItemViewModel> Items
		{
			get
			{
				return m_readOnlyItems;
			}
		}

		public ICommand ScrollCommand
		{
			get
			{
				return m_scrollCommand ?? (m_scrollCommand = new MvxCommand<EventArgs>(OnScroll));
			}
		}

		public override void Start()
		{
			Load();
		}

		protected override void SaveStateToBundle(IMvxBundle bundle)
		{
			base.SaveStateToBundle(bundle);

			DeletePending();
		}

		private void Load()
		{
			var items = Mvx.Resolve<ItemManager>().Items.Select(x => new SwipeFrameLayoutItemViewModel(x));

			m_items.Clear();

			foreach (var item in items)
				m_items.Add(item);
		}

		private void OnItemStatusChanged(ItemStatusChangeMessage message)
		{
			if (message.Status == ItemStatus.Deleted)
			{
				m_deletedItems.Add(message.Item);

				var itemViewModel = m_items.FirstOrDefault(x => x.Item == message.Item);
				if (itemViewModel != null)
					m_items.Remove(itemViewModel);
			}
			else if (message.Status == ItemStatus.UnDeleted)
			{
				m_deletedItems.Remove(message.Item);
			}
		}

		private void OnScroll(EventArgs e)
		{
			DeletePending();
		}

		private void DeletePending()
		{
			if (m_deletedItems.Count != 0)
			{
				var itemManager = Mvx.Resolve<ItemManager>();

				foreach(var item in m_deletedItems)
					itemManager.DeleteItem(item);

				m_deletedItems.Clear();
			}
		}

		readonly ObservableCollection<SwipeFrameLayoutItemViewModel> m_items;
		readonly ReadOnlyObservableCollection<SwipeFrameLayoutItemViewModel> m_readOnlyItems;
		readonly MvxSubscriptionToken m_itemStatusChangeSubscription;
		readonly ISet<Item> m_deletedItems;
		ICommand m_scrollCommand;
	}
}
