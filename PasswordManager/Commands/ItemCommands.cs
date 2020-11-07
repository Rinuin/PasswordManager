using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Lab3.Commands
{
    public class ItemCommands
    {
        public static RoutedUICommand Exit = new RoutedUICommand("ExitApplication command", "Exit", typeof(ItemCommands));
        public static RoutedUICommand New = new RoutedUICommand("New command", "New", typeof(ItemCommands));
        public static RoutedUICommand Load = new RoutedUICommand("Load command", "Load", typeof(ItemCommands));
        public static RoutedUICommand Save = new RoutedUICommand("Save command", "Save", typeof(ItemCommands));
        public static RoutedUICommand About = new RoutedUICommand("About command", "About", typeof(ItemCommands));

    }

    public class ButtonCommands
    {
        public static RoutedUICommand Login = new RoutedUICommand("Login command", "Login", typeof(ButtonCommands));
    }
}
