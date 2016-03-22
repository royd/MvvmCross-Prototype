using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
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
		}
	}
}
