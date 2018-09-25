using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using RBI;
using SQLite;

namespace RBI
{

    public partial class App : Application
    {

        #region Database Location

        private static string databaseName = "Components.db";
        private static string folderName = "Database";
        private static string currentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        public static string FolderPath = Path.Combine(currentPath, folderName);
        public static string DatabasePath = Path.Combine(FolderPath, databaseName);

        #endregion
    }
}
