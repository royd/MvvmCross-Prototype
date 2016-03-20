using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;

namespace HeaderListView.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext)
			: base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override IEnumerable<Assembly> AndroidViewAssemblies
		{
			get
			{
				List<Assembly> assemblies = base.AndroidViewAssemblies.ToList();
				assemblies.Add(typeof(Common.Droid.Views.HeaderListView).Assembly);

				return assemblies;
			}
		}
	}
}
