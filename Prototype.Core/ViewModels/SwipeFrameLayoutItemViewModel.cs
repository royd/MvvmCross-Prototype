using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Platform.WeakSubscription;

namespace Prototype.Core
{
	public class SwipeFrameLayoutItemViewModel : MvxViewModel
	{
		public SwipeFrameLayoutItemViewModel(Item item)
		{
			m_item = item;
			DeleteText = OurResources.Delete;
		}

		public Item Item
		{
			get
			{
				return m_item;
			}
		}

		public string DeleteText
		{
			get
			{
				return m_deleteText;
			}
			private set
			{
				SetProperty(ref m_deleteText, value);
			}
		}

		public string UndoButtonText
		{
			get
			{
				return OurResources.UndoButtonText;
			}
		}

		public ICommand DeleteCommand
		{
			get
			{
				return m_deleteCommand ?? (m_deleteCommand = new MvxCommand(DeleteItem));
			}
		}

		public ICommand UndoDeleteCommand
		{
			get
			{
				return m_undoDeleteCommand ?? (m_undoDeleteCommand = new MvxCommand(UndoDeleteItem));
			}
		}

		private void DeleteItem()
		{
			DeleteText = OurResources.Deleted;

			Mvx.Resolve<IMvxMessenger>().Publish(new ItemStatusChangeMessage(this, Item, ItemStatus.Deleted));
		}

		private void UndoDeleteItem()
		{
			DeleteText = OurResources.Delete;

			Mvx.Resolve<IMvxMessenger>().Publish(new ItemStatusChangeMessage(this, Item, ItemStatus.UnDeleted));
		}

		readonly Item m_item;
		string m_deleteText;
		ICommand m_deleteCommand;
		ICommand m_undoDeleteCommand;
	}
}
