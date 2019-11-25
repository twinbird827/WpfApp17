using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp17
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ViewModel VM { get; } = new ViewModel();
        //public ViewModel VM => new ViewModel();
        public ViewModel VM { get => _VM = _VM ?? new ViewModel(); }
        private ViewModel _VM;
        //public ViewModel VM => _VM = _VM ?? new ViewModel();
        //private ViewModel _VM;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = VM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VM.SelectedItem = null;
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Items = new ObservableCollection<ComboboxItemModel>(
                Enumerable.Range(1, 10)
                    .Select(i => new ComboboxItemModel(i, $"{i} 個目"))
            );
            SelectedItem = Items.First();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(storage, value))
            {
                storage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<ComboboxItemModel> Items
        {
            get => _Items;
            set => SetProperty(ref _Items, value);
        }
        private ObservableCollection<ComboboxItemModel> _Items;

        public ComboboxItemModel SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }
        private ComboboxItemModel _SelectedItem;
    }
}
