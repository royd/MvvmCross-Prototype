using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CommonSample.Core.Data
{
	public static class Collections
	{
		public static ReadOnlyCollection<string> SmallStringCollection
		{
			get
			{
				return s_smallStringCollection ?? (s_smallStringCollection = new ReadOnlyCollection<string>(s_baconIpsum.Split(' ').ToList()));
			}
		}

		static readonly string s_baconIpsum = "bacon ipsum dolor amet meatball tip salami shoulder boudin sirloin drumstick tail turducken bacon kielbasa filet mignon sausage drumstick turkey chicken hamburger flank tenderloin swine meatloaf tip flank prosciutto ham hock hamburger pastrami salami tenderloin picanha turducken shoulder pancetta frankfurter salami pancetta beef flank sirloin turkey";
		static ReadOnlyCollection<string> s_smallStringCollection;
	}
}
