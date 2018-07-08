﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VRChat_Stalker
{
    public class EntryPoint
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            
            LoadTheme();
            
            app.Run();
        }

        private static void LoadTheme()
        {
            var option = new ProgramOption();
            option.Load();


            if (option.Theme == "Light")
            {
                RemoveResource(path => path.Contains("Theme") && !path.Contains("Defaults"));
                RemoveResource(path => path.Contains("Primary"));


                var themeDir = new ResourceDictionary()
                {
                    Source = new Uri($"/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.{option.Theme}.xaml", UriKind.Relative),
                };

                Application.Current.Resources.MergedDictionaries.Add(themeDir);


                var primaryDir = new ResourceDictionary()
                {
                    Source = new Uri("/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.BlueGrey.xaml", UriKind.Relative),
                };

                Application.Current.Resources.MergedDictionaries.Add(primaryDir);
            }
        }

        private static bool RemoveResource(Predicate<string> predicate)
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;

            int index = 0;
            foreach (var dir in dictionaries)
            {
                string path = dir.Source.ToString();
                if (predicate(path))
                {
                    break;
                }

                ++index;
            }

            if (index < dictionaries.Count)
            {
                dictionaries.RemoveAt(index);

                return true;
            }

            return false;
        }
    }
}