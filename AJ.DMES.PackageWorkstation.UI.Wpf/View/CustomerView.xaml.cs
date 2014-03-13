using AJ.DMES.PackageWorkstation.Domain;
using AJ.DMES.PackageWorkstation.Manager;
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

namespace AJ.DMES.PackageWorkstation.UI.Wpf.View
{
    /// <summary>
    /// CustomerView.xaml 的交互逻辑
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }
        ICustomerManager m_CustomerManager = (ICustomerManager)Helpers.SpringContext.GetObject("CustomerManager");
        private void PageAdornerControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataGridBinding();
        }

        private void DataGridBinding()
        {
            gridControl.ItemsSource = m_CustomerManager.Find("FROM Customer");
        }

        private void gridControl_SelectedItemChanged(object sender, DevExpress.Xpf.Grid.SelectedItemChangedEventArgs e)
        {
            SelectedChangedOperation();
        }

        private void SelectedChangedOperation()
        {
            CustomerDetail.DataContext = gridControl.SelectedItem;
            btnSave.Content = FindResource("str_Save");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (btnSave.Content.ToString() == FindResource("str_Add").ToString())
            {
                Customer p_Customer = CustomerDetail.DataContext as Customer;
                m_CustomerManager.Save(p_Customer);
                DataGridBinding();
            }
            else if (btnSave.Content.ToString() == FindResource("str_Save").ToString())
            {
                if (MessageBox.Show("Are you sure you want to modify this record?",
                    "Message", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Customer p_Customer = CustomerDetail.DataContext as Customer;
                    m_CustomerManager.Update(p_Customer);
                    DataGridBinding();
                }
            }
            else
            {
                gridControl.ItemsSource = m_CustomerManager.FuzzySearch((Customer)CustomerDetail.DataContext);
                btnSave.Content = FindResource("str_Query");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DataGridBinding();
        }

        private void BarButtonItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var ButtonItem = sender as DevExpress.Xpf.Bars.BarButtonItem;
            switch (ButtonItem.Name.ToString())
            {
                case "btnAdd":
                    CustomerDetail.DataContext = new Customer();
                    btnSave.Content = FindResource("str_Add");
                    break;
                case "btnEdit":
                    CustomerDetail.DataContext = gridControl.SelectedItem;
                    btnSave.Content = FindResource("str_Save");
                    break;
                case "btnDelete":
                    try
                    {
                        if (gridControl.View.FocusedRowHandle < 0)
                        {
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure you want to delete this record?",
                                "Message", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                m_CustomerManager.Delete((Customer)gridControl.SelectedItem);
                                DataGridBinding();
                            }
                        }
                    }
                    catch(Exception ee)
                    {
                        MessageBox.Show(ee.Message,"Message");
                    }
                    break;
                case "btnQuery":
                    CustomerDetail.DataContext = new Customer();
                    btnSave.Content = FindResource("str_Query");
                    break;
            }
        }
    }
}
