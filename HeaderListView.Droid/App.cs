using System;
using HeaderListView.Core;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace HeaderListView.Droid
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			RegisterAppStart<MainViewModel>();
		}
	}
}
