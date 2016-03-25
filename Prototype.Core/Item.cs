using System;

namespace Prototype.Core
{
	public class Item
	{
		public Item(string value)
		{
			m_value = value;
		}

		public string Value
		{
			get
			{
				return m_value;
			}
		}

		public bool IsDeleted { get; set; }

		readonly string m_value;
	}
}
