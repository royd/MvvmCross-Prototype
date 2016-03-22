using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using Prototype.Core;

namespace Prototype.Droid
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

		protected override IEnumerable<Assembly> GetViewModelAssemblies()
		{
			List<Assembly> assemblies = base.GetViewModelAssemblies().ToList();
			assemblies.Add(typeof(HeaderListViewViewModel).Assembly);

			return assemblies;
		}
	}
}
