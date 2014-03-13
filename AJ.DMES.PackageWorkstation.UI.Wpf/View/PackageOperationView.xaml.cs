using AJ.DMES.PackageWorkstation.Domain;
using AJ.DMES.PackageWorkstation.Manager;
using AJ.DMES.PackageWorkstation.UI.Wpf.Helpers;
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

namespace AJ.DMES.PackageWorkstation.UI.Wpf.View
{
    /// <summary>
    /// PackageOperationView.xaml 的交互逻辑
    /// </summary>
    public partial class PackageOperationView : UserControl
    {
        //界面缓存的对象
        private int stepNo = 0;//步骤号，1.扫描DPN 2.扫描SN 3.扫描Qty 4.反复扫描CPN 5.封箱
        private Model currentModel;
        private Container currentContainer;//当前工作的包装箱
        private int currentQty = 0;//当前包装的数量

        //使用的Manager
        private IList<ModelInstance> modelInstanceList;
        private IModelManager modelManager;
        private IContainerManager containerManager;

        public PackageOperationView()
        {
            InitializeComponent();
            try
            {
                modelManager = (IModelManager)SpringContext.GetObject("ModelManager");
                containerManager = (IContainerManager)SpringContext.GetObject("ContainerManager");
            }
            catch (Exception ex)
            { 
            
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtScanBox.Focus();
                stepNo = 1;
                SetStepLabel();
                //显示等待扫描信息
                UpdateMessage("Waiting Scan");
            }
            catch (Exception ex)
            { 
            
            }
        }

        /// <summary>
        /// 步骤提示标签设置
        /// </summary>
        private void SetStepLabel()
        {
            //所有标签初始化
            lblStep1.Foreground = lblStep2.Foreground = lblStep3.Foreground
                = lblStep4.Foreground = lblStep5.Foreground = Brushes.White;
            lblStep1.FontSize = lblStep2.FontSize = lblStep3.FontSize
                = lblStep4.FontSize = lblStep5.FontSize = 12;
            lblStep1.FontStyle = lblStep2.FontStyle = lblStep3.FontStyle
                = lblStep4.FontStyle = lblStep5.FontStyle = FontStyles.Normal;

            //设置获取标签引用的对象
            Label lbl = new Label();
            //根据步骤号设置标签样式
            switch (stepNo)
            { 
                case 1:
                    lbl = lblStep1;
                    break;
                case 2:
                    lbl = lblStep2;
                    break;
                case 3:
                    lbl = lblStep3;
                    break;
                case 4:
                    lbl = lblStep4;
                    break;
                case 5:
                    lbl = lblStep5;
                    break;  
                default:
                    return;
            }
            //修改标签样式
            lbl.FontSize = 16;
            lbl.FontStyle = FontStyles.Italic;
            lbl.Foreground = Brushes.Yellow;
        }

        /// <summary>
        /// 扫描动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScanBox_KeyDown(object sender, KeyEventArgs e)
        {
            //不是回车键，则不做任何处理
            if (e.Key != Key.Enter) return;

            //操作结果
            bool result = false;

            switch (stepNo)
            { 
                case 1:
                    result = ScanDPN(txtScanBox.Text);
                    break;
                case 2:
                    result = ScanSN(txtScanBox.Text);
                    break;
                case 3:
                    result = ScanQty(txtScanBox.Text);
                    break;
                case 4:
                    result = ScanCPN(txtScanBox.Text);
                    break;
                case 5:
                    result = CloseContainer(txtScanBox.Text);
                    break;
            }

            //清空扫描栏
            txtScanBox.Text = "";
            txtScanBox.Focus();

            SetStepLabel();
        }

        /// <summary>
        /// 创建包装箱
        /// </summary>
        private void CreateContainer(string sn)
        {
            currentContainer = new Container();
            currentContainer.CreatedDateTime = DateTime.Now;
            currentContainer.ContainerPN = currentModel.ModelName;
            currentContainer.ContainerSN = sn;
            currentContainer.CustomerPN = currentModel.CPN;
        }

        /// <summary>
        ///Step1. 扫描DPN的操作
        /// </summary>
        private bool ScanDPN(string barcode)
        {
            //条码标识的前缀，后面需要从配置信息中读取
            string prefix = "1p";

            //1.判断条码是否是合法的dpn条码
            //2.解析条码，获得dpn号
            string dpn = FilterPrefix(barcode, prefix);

            if (string.IsNullOrEmpty(dpn)) return false;//如果字符串为空，则返回false
            //3.通过dpn号，获得当前的model对象
            currentModel = modelManager.Get(dpn);
            //4.填充界面
            UpdateModelInfo();
            //5.切换步骤号
            stepNo = 2;

            UpdateMessage("Scan container SN");
            return true;
        }

        /// <summary>
        /// Step2.扫描序列号
        /// </summary>
        /// <returns></returns>
        private bool ScanSN(string barcode)
        {
            string prefix = "3s";//序列号的前缀，后面需要从配置信息中读取
            //1.获得序列号
            string sn = FilterPrefix(barcode, prefix);
            if (string.IsNullOrEmpty(sn))
            {
                return false;
            }
            //2.根据sn获得包装箱
            currentContainer = containerManager.Get(sn);
            if (currentContainer == null) CreateContainer(sn);//如果没有新建一个包装箱
            else
            {
                //有的话判断是否已经封箱
                if (currentContainer.ContainerStatus == (int)EContainerStatus.Closed)
                {
                    //警告用户包装箱已经封箱

                }
                else
                {
                    //表示前面包装箱没有完成，继续工作

                }
            }
            //3.填充界面包装箱部分
            UpdateContainerInfo();

            //4.递进步骤号
            stepNo = 3;

            UpdateMessage("Scan container quatity");
            return true;
        }

        /// <summary>
        /// Step3.扫描qty条码操作
        /// </summary>
        /// <param name="barcode"></param>
        private bool ScanQty(string barcode)
        {
            try
            {
                string prefix = "q";//数量条码的前缀，后面需要从配置信息中读取
                int qty = int.Parse(FilterPrefix(barcode, prefix));
                lblContainerQty.Content = qty;
                currentContainer.ContainerSize = qty;
                currentQty = 0;
                UpdateQtyInfo();
                stepNo = 4;
                UpdateMessage("Scan custoemr CPN");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Step4.扫描产品2D条码
        /// </summary>
        /// <param name="barcode"></param>
        private bool ScanCPN(string barcode)
        { 
            //1.切分2维条码，将其填入ModelInstance实体中
            ModelInstance mInstance = new ModelInstance();
            mInstance.Model = currentModel;
            mInstance.Container = currentContainer;
            mInstance.ProductCode = barcode;
            //2.填充到集合中
            if (modelInstanceList == null) modelInstanceList = new List<ModelInstance>();
            modelInstanceList.Add(mInstance);
            currentQty++;
            UpdateQtyInfo();

            //3.填充包装列表
            UpdatePackedList();

            //4.判断是否已经满箱
            if (currentQty == currentContainer.ContainerSize)
            {
                stepNo = 5;//如果已经满箱，则转到封箱操作
                UpdateMessage("Rescan DPN");
            }

            return true;
        }

        /// <summary>
        /// 封箱操作
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        private bool CloseContainer(string barcode)
        {
            string prefix = "1p";
            string dpn = FilterPrefix(barcode, prefix);

            try
            {
                //1.对比此次输入的dpn与箱号是否一致
                if (!currentContainer.ContainerPN.Equals(dpn)) return false;
                //2.如果一样，表示是同一个外箱，进行封箱操作（保存外箱信息，并将记录外箱与ModelInstance的关系）
                currentContainer.ContainerStatus = (int)EContainerStatus.Closed;
                containerManager.Save(currentContainer);
                //3.清空界面与缓存的对象
                ClearForm();
            }
            catch (Exception ex)
            { 
            
            }

            return true;
        }

        /// <summary>
        /// 把条码中的前缀去掉
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        private string FilterPrefix(string barcode,string prefix)
        {
            int indexOfPrefix = barcode.ToLower().IndexOf(prefix);
            if (indexOfPrefix < 0) return "";
            return barcode.Substring(prefix.Length);
        }

        /// <summary>
        /// 填充Model信息
        /// </summary>
        private void UpdateModelInfo()
        {
            if (currentModel == null)
                return;
            txtDelphiPN.Text = currentModel.ModelName;
            txtDescription.Text = currentModel.Description;
            txtCPN.Text = currentModel.CPN;
        }

        /// <summary>
        /// 填充包装箱信息
        /// </summary>
        private void UpdateContainerInfo()
        {
            if (currentContainer == null) return;
            
            lblContianerSN.Content = currentContainer.ContainerSN;
            lblCustomerPN.Content = currentContainer.CustomerPN;
        }

        /// <summary>
        /// 更新当前包装的数量
        /// </summary>
        private void UpdateQtyInfo()
        {
            lblPackedQty.Content = currentQty;
        }

        /// <summary>
        /// 更新Packed List
        /// </summary>
        private void UpdatePackedList()
        {
            lsPackedProduct.ItemsSource = null;
            lsPackedProduct.ItemsSource = modelInstanceList;
            lsPackedProduct.DisplayMember = "ProductCode";
        }

        /// <summary>
        /// 操作提示信息更新
        /// </summary>
        private void UpdateMessage(string msg)
        {
            lblMessage.Content = msg;
        }

        private void UpdateContainerStatus(int status)
        { 
            
        }

        /// <summary>
        /// 清理界面及缓存
        /// </summary>
        private void ClearForm()
        {
            currentContainer = null;
            currentModel = null;
            currentQty = 0;
            modelInstanceList = null;
            stepNo = 1;

            lblPackedQty.Content = "-";
            lblContainerQty.Content = "-";
            lblContianerSN.Content = "-";
            lblCustomerPN.Content = "-";
            txtCPN.Text = "";
            txtDelphiPN.Text = "";
            txtDescription.Text = "";
            lsPackedProduct.ItemsSource = null;
        }
    }
}
