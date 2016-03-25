using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Prototype.Core;
using Prototype.Core.ViewModels;

namespace Prototype.Droid
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

			Mvx.RegisterSingleton<ItemManager>(new ItemManager());
		}
	}
}
