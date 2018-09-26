using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RBI.Annotations;
using RBI.Component;
using SQLite;

namespace RBI
{
    class PartViewModel: INotifyPropertyChanged

    {
        private ICommand _updateCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Object> Objects { get; } = new ObservableCollection<Object>();

        private Object _selectedObject;

        public Object SelectedObject
        {
            get { return _selectedObject; }
            set
            {
                this._selectedObject = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedObject)));
            }
        }

        public void LoadData()
        {
            Directory.CreateDirectory(App.FolderPath);
            List<Unit> units;
            List<Component.Component> components;

            // Read database table.
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Unit>();
                units = conn.Table<Unit>().ToList();
                conn.CreateTable<Component.Component>();
                components = conn.Table<Component.Component>().ToList();
            };

            if (units != null)
            {
                foreach (var unit in units)
                {
                    Objects.Add(unit);
                }
            }

            if (components != null)
            {
                foreach (var component in components)
                {
                    Objects.Add(component);
                }
            }
        }

        public ICommand UpdateCommand  // This command is not accessed by the button
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(
                        param => this.UpdateData(),
                        param => this.CanUpdate()
                    );
                }
                return _updateCommand;
            }
        }

        public void UpdateData()
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.Update(SelectedObject);
            };
        }

        private bool CanUpdate()
        {
            return true;
        }

        // Alternatively, to create an object and bind to the command of the button.
//        public ICommand UpdateObject => ReactiveCommand.CreateFromTask<Object>(UpdateDataAsync); // wrong return type

//        private async Task UpdateDataAsync()
//        {
//            using (var conn = new SQLiteConnection(App.DatabasePath))
//            {
//                conn.Update(SelectedObject);  // cannot use await here
//            };
//        }

    }
}
