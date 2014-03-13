using AJ.DMES.PackageWorkstation.Domain;
using AJ.DMES.PackageWorkstation.Manager;
using AJ.DMES.PackageWorkstation.UI.Wpf.Helpers;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace AJ.DMES.PackageWorkstation.UI.Wpf.View
{
    /// <summary>
    /// ModelView.xaml 的交互逻辑
    /// </summary>
    public partial class ModelView : UserControl
    {
        ICustomerManager m_customerManager = (ICustomerManager)SpringContext.GetObject("CustomerManager");
        IModelManager m_modelManager = (IModelManager)SpringContext.GetObject("ModelManager");
        private string m_command = "";//Add Edit Query 
        private List<Customer> m_lstCustomer = null;

        public ModelView()
        {
            InitializeComponent();
            InitPageInfo();
        
        }

        private void InitPageInfo()
        {
            m_lstCustomer = (List<Customer>)m_customerManager.Find("from Customer ");
            lookupedit_Customers.ItemsSource = m_lstCustomer; 
           lookupedit_Customers.DisplayMember = "CustomerName";
           lookupedit_Customers.ValueMember = "Id";
           colCustomerId.ItemsSource = m_lstCustomer;
           RefreshGridControlData(); 
         
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Model model = null;
            Customer customer = null;
            Guid customerId = Guid.NewGuid();
            switch(m_command)
            {
                case "Add":
                      model = new Model();
                      model.CPN = txtCPN.Text;
                      model.Description = txtDescription.Text;
                      model.ModelName = txtModelName.Text;
                      customerId = Guid.Parse(lookupedit_Customers.EditValue.ToString());
                      customer = m_lstCustomer.Find(p => p.Id == customerId);
                      model.Customer = customer;
                      try
                      {
                          m_modelManager.Save(model);
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show("Model name must be unique !");
                      }
                     RefreshGridControlData();
                    break;
                case "Edit":
                    model = (Model)gridModelDetail.DataContext;
                       customerId = Guid.Parse(lookupedit_Customers.EditValue.ToString());
                      customer = m_customerManager.Get(customerId);
                      model.Customer = m_lstCustomer.Find(p => p.Id == customerId);
                      try
                      {
                          m_modelManager.SaveOrUpdate(model);
                      }
                    catch(Exception ex)
                      {
                          MessageBox.Show("Model name must be unique !");
                    }
                     RefreshGridControlData();
                    break;
                case "Query":
                       model = (Model)gridModelDetail.DataContext;
                      customerId = Guid.Parse(lookupedit_Customers.EditValue.ToString());
                      customer = m_lstCustomer.Find(p =>  p.Id == customerId);
                      model.Customer = customer;
                      gridContro_Models.ItemsSource = m_modelManager.QuerySomeModel(model);
                    
                    break;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearData();

        }

        private void btnAdd_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            m_command = "Add";
            ClearData();
            btnSave.Content = "Add";
           
        }

        private void btnDelete_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
          if(gridContro_Models.SelectedItem!=null)
          {
              Model model =(Model) gridContro_Models.SelectedItem;
             MessageBoxResult result= MessageBox.Show("Are you sure delete this Model?", "Delete Info",MessageBoxButton.OKCancel);
              if(result==MessageBoxResult.OK)
              {
                  m_modelManager.Delete(model);
                  RefreshGridControlData();
              }
          }
        }
        private void btnEdit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            m_command = "Edit";
  
            btnSave.Content = "Edit";
        }

        private void btnQuery_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            m_command = "Query";
            btnSave.Content = "Query";
        }

        private void RefreshGridControlData()
        {
            List<Model> lst = (List<Model>)m_modelManager.GetAllModels();
         
          
            gridContro_Models.ItemsSource = lst;
        }


        private void ClearData()
        {
            Model model = (Model)gridModelDetail.DataContext;
            if (model != null && model.Id != null)
            {
                gridModelDetail.DataContext = new Model();
            }
            else
            {
                gridModelDetail.DataContext = new Model();
            }
        }


    }
}
