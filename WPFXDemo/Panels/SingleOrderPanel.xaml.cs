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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFXilix.Panels
{
    /// <summary>
    /// Interaction logic for SingleOrderPanel.xaml
    /// </summary>
    public partial class SingleOrderPanel : UserControl
    {
        public SingleOrderPanel()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            layoutControl1.IsCustomization = !layoutControl1.IsCustomization;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            algoargs.Visibility = System.Windows.Visibility.Visible;
            algochoice.Visibility = System.Windows.Visibility.Visible;
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            algoargs.Visibility = System.Windows.Visibility.Collapsed;
            algochoice.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            algoargs.Visibility = System.Windows.Visibility.Collapsed;
            algochoice.Visibility = System.Windows.Visibility.Collapsed;

        }
    }
}
