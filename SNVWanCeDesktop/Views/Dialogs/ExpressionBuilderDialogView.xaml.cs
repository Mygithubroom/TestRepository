using DocumentFormat.OpenXml.EMMA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.ViewModels.DialogModels;

namespace WanCeDesktopApp.Views.Dialogs
{
    /// <summary>
    /// ExpressionBuilderDialogView.xaml 的交互逻辑
    /// </summary>
    public partial class ExpressionBuilderDialogView : UserControl
    {
        ExpressionBuilderDialogViewModel viewModel;
        public ExpressionBuilderDialogView()
        {
            InitializeComponent();
            this.Loaded += ExpressionBuilderDialogView_Loaded;
        }

        private void ExpressionBuilderDialogView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (ExpressionBuilderDialogViewModel)this.DataContext;
            if (viewModel == null)
            {
                MessageBox.Show("DataContext is Not ExpressionBuilderDialogViewModel!");
                return;
            }
            //viewModel.Expression = ShowText(viewModel.ArrList);
        }
        //输入框光标位置缓存
        private int cacheIndex = 0;

        Stack<int> InputSteps = new Stack<int>();
        //点击Clean数据回退 ，申明一个栈存储 操作符和位置。
        private void Clean_Button(object sender, RoutedEventArgs e)
        {
            if (isError)  //点击clean，回复按钮可用性
            {
                viewModel.Expression = "";
                viewModel.ArrList.Clear();
                cacheIndex = 0;
                isError = false;
                return;
            }
            Thread.Sleep(200);       //睡眠0.2s
            if (this.Input.Text != "")  //首先清空输入框
            {
                viewModel.Expression = "";
                viewModel.ArrList.Clear();
                cacheIndex = 0;
                return;
            }
        }
        //Cos⁻¹
        //数字
        private void Number_Button(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            string num = (string)button.Content;
            AddInputText(num);
        }
        string number = "";
        //运算符
        private void Operator_Button(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(number))
            {
                viewModel.ArrList.Add(number);
            }
            string operation = "";   //操作符
            bool isSquare = false;  //判断是否为开方或次方运算
            string index = "";         //保存指数
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            switch (button.Content)
            {
                case "+":
                case "-":
                case "^":
                case "e":
                case "π":
                case "(":
                case ")":
                case "%":
                    operation = (string)button.Content;
                    break;
                case "×":
                    operation = "*";
                    break;
                case "÷":
                    operation = "/";
                    break;
                case "x²":
                    isSquare = true;
                    index = "2";
                    break;
                case "x³":
                    isSquare = true;
                    index = "3";
                    break;
                case "√x":
                    isSquare = true;
                    index = "0.5";
                    break;
                case "1/x":
                    isSquare = true;
                    index = "-1";
                    break;
                    //case "xʸ":
                    //    //if (num != "")
                    //    //{
                    //    //    viewModel.ArrList.Add(num);
                    //    //    //viewModel.Expression = viewModel.Expression + num;
                    //    //}
                    //    viewModel.ArrList.Add("^");
                    //    viewModel.ArrList.Add("(");
                    //    //viewModel.Expression = viewModel.Expression + "^" + "(";
                    //    this.Input.Text = "";
                    //    return;
                    //case "y√x":
                    //    //if (num != "")
                    //    //{
                    //    //    viewModel.ArrList.Add(num);
                    //    //    //viewModel.Expression = viewModel.Expression + num;
                    //    //}
                    //    viewModel.ArrList.Add("^");
                    //    viewModel.ArrList.Add("(");
                    //    viewModel.ArrList.Add("1");
                    //    viewModel.ArrList.Add("/");
                    //    //viewModel.Expression = viewModel.Expression + "^(1/";
                    //    //this.Input.Text = "";
                    return;
            }

            if (isSquare)  //为开方或者次方运算
            {
                //if (num != "")
                //{
                //    //viewModel.Expression = viewModel.Expression + num;
                //    viewModel.ArrList.Add(num);
                //    //this.Input.Text = "";
                //}
                //viewModel.ArrList.Add("^");
                //viewModel.ArrList.Add(index);
                AddInputText("^" + index);
                return;
            }
            if (string.IsNullOrEmpty(operation))
            {
                return;
            }
            AddInputText(operation);
        }

        //退出程序
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        //小数点
        private void Dot_Button(object sender, RoutedEventArgs e)
        {
            AddInputText(".");
        }

        //等于
        private bool isError = false;

        //左括号、右括号
        private void Bracket_Button(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string value = button==null?"" :(string)button.Content;
            AddInputText(value);
        }

        //三角函数
        private void Triangle_Button(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) { return; }
            AddInputText(button.Content + "(");
        }
        //2022/11/12胡建国舍弃
        /// <summary>
        /// 解析表达式，同名处理后展示
        /// </summary>
        /// <param name="arrayList"></param>
        /// <returns></returns>
        //public string ShowText(ArrayList arrayList)
        //{
        //    string result = "";
        //    int i = 0;
        //    while (i < arrayList.Count)
        //    {
        //        object? value = arrayList[i];
        //        if (value is GaugeItemInfo info)         //数字
        //        {
        //            if (info == null)
        //            {
        //                return "";
        //            }
        //            string content = info.Title + info.Tag;
        //            //查看其他集合是否存在相同名称
        //            foreach (var item in viewModel.AvailableParametersArr)
        //            {
        //                GaugeItemInfo? gauge = item as GaugeItemInfo;
        //                if (gauge == null)
        //                {
        //                    return "";
        //                }
        //                foreach (var child in gauge.AvailableParametersItemsArr)
        //                {
        //                    GaugeItemInfo? gaugeItem = child as GaugeItemInfo;
        //                    if (gaugeItem == null)
        //                    {
        //                        return "";
        //                    }
        //                    string otherContent = gaugeItem.Title + gaugeItem.Tag;
        //                    //不是同一个对象，但名字相同了
        //                    if (info.HashCodeCache != child.HashCodeCache && content == otherContent)
        //                    {
        //                        content = content + "@" + gauge.Title;
        //                    }
        //                }
        //            }
                    
        //            //content = "\"" + content + "\"";
        //            result += content;
        //        }
        //        else
        //        {
        //            result += value;
        //        }
        //        i++;
        //    }
        //    return result;
        //}

        private void TreeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GaugeItemInfo? info = treeView.SelectedItem as GaugeItemInfo;
            if (info is not null)
            {
                if (info.IsParent == true)
                {
                    return;
                }
                string content = info.Title + info.Tag;
                //查看其他集合是否存在相同名称
                foreach (var item in viewModel.AvailableParametersArr)
                {
                    GaugeItemInfo? gauge = item as GaugeItemInfo;
                    if (gauge == null)
                    {
                        return;
                    }
                    foreach (var child in gauge.AvailableParametersItemsArr)
                    {
                        GaugeItemInfo? gaugeItem = child as GaugeItemInfo;
                        if (gaugeItem == null)
                        {
                            return;
                        }
                        string otherContent = gaugeItem.Title + gaugeItem.Tag;
                        //不是同一个对象，但名字相同了
                        if (info.HashCodeCache != child.HashCodeCache && content == otherContent)
                        {
                            content = content + "@" + gauge.Title;
                        }
                    }
                    AddInputText(content);
                    //int index = Tools.GetArrListIndexByStrIndex(viewModel.ArrList, cacheIndex);
                    //if (string.IsNullOrEmpty(info.HashCodeCache))
                    //{
                    //    info.HashCodeCache = DateTime.Now.Ticks + "";//生成唯一标识
                    //}
                    //if (index == -1)//表示末尾添加
                    //{
                    //    viewModel.ArrList.Add(info);
                    //    viewModel.Expression = ShowText(viewModel.ArrList);
                    //}
                    //else
                    //{
                    //    //中间添加
                    //    viewModel.ArrList.Insert(index, info);
                    //    viewModel.Expression = ShowText(viewModel.ArrList);
                    //}
                    //cacheIndex += info.Title.Length;
                }
            }
        }
        //2022/11/12胡建国更新
        /// <summary>
        /// 添加表达式内容
        /// </summary>
        /// <param name="content"></param>
        public void AddInputText(string content)
        {
            unitsPopup.IsOpen = false;
            int index = -1;
            if (cacheIndex != Input.Text.Length)
            {
                index=cacheIndex;
                //可以插入的位置
                //index = Tools.GetArrListIndexByStrIndex(viewModel.ArrList, cacheIndex);
                //if (index == -1)
                //{
                //    return;
                //}
            }
            if (index == -1)//表示可以直接添加到最后面
            {
                //viewModel.ArrList.Add(content);
                viewModel.Expression += content;// = ShowText(viewModel.ArrList);
            }
            else
            {
                //中间添加
                //viewModel.ArrList.Insert(index, content);
                viewModel.Expression = viewModel.Expression.Insert(index, content); //= ShowText(viewModel.ArrList);
            }
            cacheIndex += content.Length;

        }
        private void Input_GotFocus(object sender, RoutedEventArgs e)
        {
            cacheIndex = Input.SelectionStart;
        }

        private void Input_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            cacheIndex = Input.SelectionStart;
            unitsPopup.IsOpen = false;
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void Units_Click(object sender, RoutedEventArgs e)
        {
            unitsPopup.IsOpen = true;
        }

        private void UnitsTree_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InputInfo? info = UnitsTree.SelectedItem as InputInfo;
            if (info != null)
            {
                if (info.IsParent == false)
                {
                    string str = "_[" + info.Title + "]";
                    AddInputText(str);
                    //单位源 ，单位，确认的时候返回给计算结果对象
                    //coding

                }
            }
            else
            {
                unitsPopup.IsOpen = false;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            unitsPopup.IsOpen = false;
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate_Button(object sender, RoutedEventArgs e)
        {
            double number;
            //临时代码，计算表达式
            if (Tools.TryCalculate(viewModel.ArrList, out number))
            {
                MessageBox.Show(number + "");
            }
            else
            {
                MessageBox.Show("解析错误！");

            }
        }
        private bool isChange=false;
        /// <summary>
        /// 切换第二套按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondSet_Button(object sender, RoutedEventArgs e)
        {
            isChange = isChange == false;
            if (isChange)  //按键名字变换
            {
                Sin.Content = "asin";
                Cos.Content = "acos";
                Tan.Content = "atan";
            }
            else
            {
                Sin.Content = "sin";
                Cos.Content = "cos";
                Tan.Content = "tan";
            }
        }
    }
}
