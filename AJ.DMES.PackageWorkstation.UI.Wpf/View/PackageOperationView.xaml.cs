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
        private int stepNo = 0;//步骤号，1.扫描DPN 2.扫描SN 3.扫描Qty 4.反复扫描CPN 5.封箱

        private Model currentModel;

        private IModelManager modelManager;

        private Container currentContainer;//当前工作的包装箱

        public PackageOperationView()
        {
            InitializeComponent();
            modelManager = (IModelManager)SpringContext.GetObject("ModelManager");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtScanBox.Focus();
                stepNo = 1;
                SetStepLabel();
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
            switch (stepNo)
            { 
                case 1:
                    ScanDPN(txtScanBox.Text);
                    break;
            }
        }

        /// <summary>
        /// 创建包装箱
        /// </summary>
        private void CreateContainer()
        {
            currentContainer = new Container();
            currentContainer.CreatedDateTime = DateTime.Now;
        }

        /// <summary>
        /// 扫描DPN的操作
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
            UpdateModelInfo();
            //4.切换步骤号
            stepNo = 2;
            return true;
        }

        /// <summary>
        /// 扫描序列号
        /// </summary>
        /// <returns></returns>
        private bool ScanSN(string barcode)
        {
            string prefix = "3s";//序列号的前缀，后面需要从配置信息中读取
            //1.获得序列号
            string sn = FilterPrefix(barcode,prefix);
            //2.判断需要号是否存在


            //3.填充序列号界面
            lblCustomerSN.Content = sn;



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
            return barcode.Substring(indexOfPrefix);
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
    }
}
