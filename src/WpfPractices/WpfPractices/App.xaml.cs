﻿using System.Windows;
using Prism.Ioc;
using Prism.Modularity;

namespace WpfPractices
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell() => Container.Resolve<MainWindow>();
        protected override void RegisterTypes(IContainerRegistry containerRegistry) { }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MainModule>();
        }
    }
}
