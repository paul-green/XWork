using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Layout.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

using DevExpress.Xpf.Editors;
using DXWPFApplication2.Panels;


namespace DXWPFApplication2
{
    public partial class MainWindow : DXRibbonWindow
    {
        public static RoutedCommand CustomRoutedCommand = new RoutedCommand();
        public static RoutedCommand CreatePanelCommand = new RoutedCommand();



        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataSource();

            CommandBinding customCommandBinding = new CommandBinding(CustomRoutedCommand, ExecutedCustomCommand, CanExecuteCustomCommand);
            CommandBinding createPanelBinding = new CommandBinding(CreatePanelCommand, CreatePanelCommandExecute, CanExecuteCreatePanelCommand);

            // attach CommandBinding to root window 
            this.CommandBindings.Add(customCommandBinding);
            this.CommandBindings.Add(createPanelBinding);

            bNewTopWindow.Command = CustomRoutedCommand;

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);

            //AddLayout("Advices", "Advices");
            //AddLayout("Client", "Client");
            //AddLayout("Discretions", "Discretions");

//            dockLayoutManager.DockController.Dock(new LayoutPanel() { Caption = "Eggs" });
  //          dockLayoutManager.DockController.Dock(new LayoutPanel() { Caption = "Eggs" });
    //        dockLayoutManager.DockController.Dock(new LayoutPanel() { Caption = "Eggs" });
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            themeComboBox.ItemsSource = Theme.Themes;
            comboBoxEditSettings1.ItemsSource = Theme.Themes;
            bbgPanelBrowser.NavigateToString("<html><body style=\"margin:0; padding:0\"><iframe width=\"100%\" height=\"100%\" src=\"http://www.youtube.com/embed/CUS0ktfCYBI?autoplay=1&loop=1\" frameborder=\"1\" allowfullscreen></iframe></body></html>");
            
            

            ch9News.NavigateToString("<html><body style=\"margin:0; padding:0\"><iframe border:0px  width=\"100%\" height=\"100%\" src=\"http://www.youtube.com/embed/EyB145-Ip6c?autoplay=1\" frameborder=\"1\" allowfullscreen></iframe></body></html>");
            
            yahooNews.NavigateToString("<html><body style=\"margin:0; padding:0\"><iframe width=\"100%\" height=\"100%\" src=\"http://www.youtube.com/embed/7c9oMMp5OuI?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe></body></html>");
            CNNNews.NavigateToString("<html><body style=\"margin:0; padding:0\"><iframe width=\"100%\" height=\"100%\" src=\"http://www.youtube.com/embed/n35PNNxY-oU?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe></body></html>");
        }

        private void CreatePanelCommandExecuteBBG(object sender, ExecutedRoutedEventArgs e)
        {
            //layoutPanel2.Visibility = System.Windows.Visibility.Visible;
            bbgPanelBrowser.NavigateToString("<html><body><iframe width=\"560\" height=\"315\" src=\"http://www.youtube.com/embed/CUS0ktfCYBI?autoplay=1&loop=1\" frameborder=\"0\" allowfullscreen></iframe></body></html>");

            ch9News.NavigateToString("<html><body><iframe width=\"560\" height=\"315\" src=\"http://www.youtube.com/embed/7c9oMMp5OuI?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe></body></html>");

            
        }

        private void CanExecuteCreatePanelCommandBBG(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CreatePanelCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            //dockLayoutManager.DockController.Dock(new LayoutPanel() { Caption = "Eggs2" });
         //   LayoutPanel panel = new LayoutPanel();
           // BarButtonItemLinkControl link = (BarButtonItemLinkControl)e.OriginalSource;
            
           // panel.Caption = link.ActualContent + " " +  DateTime.Now.TimeOfDay.Seconds;
           // dockLayoutManager.LayoutRoot.Add(panel);
        }

        private void CanExecuteCreatePanelCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecutedCustomCommand(object sender,    ExecutedRoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }



        private void CanExecuteCustomCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void AddLayout(string layoutID, string layoutCaption)
        {
            return;
            BarButtonItem bbi = new BarButtonItem();
            bbi.Name = layoutID;
            bbi.Content = layoutCaption;
            bbi.Command = CreatePanelCommand;
            
            barManager.Items.Add(bbi);

            BarButtonItemLink link = new BarButtonItemLink();
            link.BarItemName = bbi.Name;
            link.RibbonStyle = RibbonItemStyles.SmallWithText;

            OpenViews.ItemLinks.Add(link);
        }

        //IShellServices
        public void RegisterView(string viewType, ICommand command)
        {
            BarButtonItem bbi = new BarButtonItem();
            bbi.Name = viewType;
            bbi.Content = viewType;
            bbi.Command = command;
            bbi.CommandParameter = this;

            barManager.Items.Add(bbi);

            BarButtonItemLink link = new BarButtonItemLink();
            link.BarItemName = bbi.Name;
            link.RibbonStyle = RibbonItemStyles.SmallWithText;

            OpenViews.ItemLinks.Add(link);
        }

        public void ShowView(string name, FrameworkElement element)
        {
            LayoutPanel newpanel2 = new LayoutPanel();
            newpanel2.Caption = name;
            newpanel2.Name = name;
            newpanel2.Content = element;
            dockLayoutManager.DockController.Dock(newpanel2);
        }

        private void themeComboBox_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            ThemeManager.ApplicationThemeName = (string)((ComboBoxEdit)sender).EditValue;
        }

        private void themeCombo_EditValueChanged(object sender, RoutedEventArgs e)
        {
            
            ThemeManager.ApplicationThemeName = (string)((BarEditItem)sender).EditValue;
        }

        private void fontSize_EditValueChanged(object sender, RoutedEventArgs e)
        {
            decimal value = (decimal)((BarEditItem)sender).EditValue;
            dockLayoutManager.FontSize = (double)value;
            //Application.Current.MainWindow.FontSize = (double)value;
        }

        private void barEditItem1_EditValueChanged(object sender, RoutedEventArgs e)
        {
            dockLayoutManager.FontSize = (double)barEditItem1.EditValue;
        }

    }



    public class TestData
    {
        public string Text { get; set; }
        public int Number { get; set; }
    }

    public class TestDataViewModel : INotifyPropertyChanged
    {
        TestData data;
        public TestDataViewModel()
        {
            data = new TestData() { Text = string.Empty, Number = 0 };
        }
        public string Text
        {
            get { return Data.Text; }
            set
            {
                if (Data.Text == value)
                    return;
                Data.Text = value;
                RaisePropertyChanged("Text");
            }
        }
        public int Number
        {
            get { return Data.Number; }
            set
            {
                if (Data.Number == value)
                    return;
                Data.Number = value;
                RaisePropertyChanged("Number");
            }
        }
        protected TestData Data
        {
            get { return data; }
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class DataSource
    {
        ObservableCollection<TestDataViewModel> source;
        public DataSource()
        {
            source = CreateDataSource();
        }



        protected ObservableCollection<TestDataViewModel> CreateDataSource()
        {
            ObservableCollection<TestDataViewModel> res = new ObservableCollection<TestDataViewModel>();
            res.Add(new TestDataViewModel() { Text = "Row0", Number = 0 });
            res.Add(new TestDataViewModel() { Text = "Row1", Number = 1 });
            res.Add(new TestDataViewModel() { Text = "Row2", Number = 2 });
            res.Add(new TestDataViewModel() { Text = "Row3", Number = 3 });
            res.Add(new TestDataViewModel() { Text = "Row4", Number = 4 });
            res.Add(new TestDataViewModel() { Text = "Row5", Number = 5 });
            res.Add(new TestDataViewModel() { Text = "Row6", Number = 6 });
            res.Add(new TestDataViewModel() { Text = "Row7", Number = 7 });
            res.Add(new TestDataViewModel() { Text = "Row8", Number = 8 });
            res.Add(new TestDataViewModel() { Text = "Row9", Number = 9 });
            return res;
        }
        public ObservableCollection<TestDataViewModel> Data { get { return source; } }
    }

 


}

