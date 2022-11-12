using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Wordprocessing;
using Logic;
using MachineControlModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TupacAmaru.Yacep;
using TupacAmaru.Yacep.Exceptions;
using TupacAmaru.Yacep.Extensions;
using WanCeDesktopApp.Common;
using WanCeDesktopApp.Common.DAO;
using WanCeDesktopApp.Common.Enum;
using WPFLocalizeExtension.Engine;

namespace WanCeDesktopApp
{
    public class DictionaryExt
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }

    public static class Tools
    {
        /// <summary>
        /// 将OBJ转换为string
        /// </summary>
        /// <param name="o"></param>
        /// <param name="sDefault">默认的值，默认为""</param>
        /// <returns></returns>
        public static string ToString(object? o, string sDefault = "")
        {
            if (o == null)
                return sDefault;
            return o.ToString()!;
        }

        /// <summary>
        /// 将OBJ转换为int
        /// </summary>
        /// <param name="o"></param>
        /// <param name="iDefault">默认的值，默认为0</param>
        /// <returns></returns>
        public static int ToInt32(object o, int iDefault = 0)
        {
            if (o == null)
                return iDefault;
            if (!int.TryParse(ToString(o), out iDefault))
                return iDefault;
            return int.Parse(ToString(o));
        }

        public static string[] ToList(string sContents, string split = ";")
        {
            string[] result = Array.Empty<string>();
            if (ToString(sContents) == "")
                return result;
            return sContents.Split(split).Where(x => !string.IsNullOrEmpty(x)).ToArray();
        }
        //获取枚举集合
        public static List<DictionaryExt> EnumTypeToList(Type type)
        {
            List<DictionaryExt> list = new List<DictionaryExt>();
            foreach (object o in Enum.GetValues(type))
            {
                list.Add(new DictionaryExt() { Key = ToString(o), Value = LocalizationProviderWrapper.GetLocalizedStr(o.ToString()) });
            }
            return list;
        }

        /// <summary>
        /// 根据控件名字查找第一个父控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="child"></param>
        /// <param name="parentName"></param>
        /// <returns></returns>
        public static T FindVisualParent<T>(DependencyObject? child, string parentName) where T : DependencyObject
        {
            if (child is null) { return null; };
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) { return null; };
            T parent = parentObject as T;
            FrameworkElement parentControl = parent as FrameworkElement;
            if (parent != null && parentControl?.Name == parentName)
            {
                return parent;
            }
            else
            {
                return FindVisualParent<T>(parentObject, parentName);
            }
        }
        /// <summary>
        /// 查找第一个符合条件的父控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="child"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T FindVisualParent<T>(DependencyObject? child, Func<T, bool> predicate) where T : DependencyObject
        {
            if (child is null) { return null; };
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) { return null; };
            T parent = parentObject as T;
            FrameworkElement parentControl = parent as FrameworkElement;
            if (parent != null && predicate(parent))
            {
                return parent;
            }
            else
            {
                return FindVisualParent<T>(parentObject, predicate);
            }
        }
        /// <summary>
        /// 查找到第一个符合条件的子控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T FindVisualChild<T>(DependencyObject parent, Func<T, bool> predicate) where T : Visual
        {
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                DependencyObject v = (DependencyObject)VisualTreeHelper.GetChild(parent, i);
                T child = v as T;
                if (child == null)
                {
                    child = FindVisualChild<T>(v, predicate);
                    if (child != null)
                    {
                        return child;
                    }
                }
                else
                {
                    if (predicate(child))
                    {
                        return child;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 输入查询语句返回影响的行数
        /// </summary>
        /// <param name="sContent"></param>
        /// <returns></returns>
        public static int GetEffectRowForSQLite(string sContent, string DatabasePath)
        {
            if (DatabasePath == "")
                DatabasePath = @"DataSource = Resources\SQLiteTest.db";
            SQLiteConnection connection = new SQLiteConnection(DatabasePath);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(sContent, connection);
            int c = ToInt32(command.ExecuteNonQuery());
            connection.Close();
            return c;
        }

        /// <summary>
        /// 输入查询语句，返回数据表
        /// </summary>
        /// <param name="sContent"></param>
        /// <returns></returns>
        public static DataTable GetDataTableForSQLite(string sContent, string DatabasePath)
        {
            if (DatabasePath == "")
                DatabasePath = @"DataSource = Resources\SQLiteTest.db";
            SQLiteConnection connection = new SQLiteConnection(DatabasePath);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(sContent, connection);
            SQLiteDataReader sQLiteDataReader = command.ExecuteReader();
            DataTable dataTable = Tools.ConvertDataReaderToDataTable(sQLiteDataReader);
            sQLiteDataReader.Close();
            connection.Close();
            return dataTable;
        }

        /// <summary>
        /// 将SQLiteDataReader转换为DataTable
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DataTable ConvertDataReaderToDataTable(SQLiteDataReader dataReader)
        {
            ///定义DataTable
            DataTable datatable = new DataTable();
            try
            {    ///动态添加表的数据列
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    DataColumn myDataColumn = new DataColumn();
                    myDataColumn.DataType = dataReader.GetFieldType(i);
                    myDataColumn.ColumnName = dataReader.GetName(i);
                    datatable.Columns.Add(myDataColumn);
                }
                ///添加表的数据
                while (dataReader.Read())
                {
                    DataRow? myDataRow = datatable.NewRow();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        myDataRow[i] = dataReader[i].ToString();
                    }
                    datatable.Rows.Add(myDataRow);
                    myDataRow = null;
                }
                ///关闭数据读取器
                dataReader.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                ///抛出类型转换错误
                //SystemError.CreateErrorLog(ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 将DataTable转换为List<T>对象
        /// </summary>
        /// <param name="dt">DataTable 对象</param>
        /// <returns>List<T>集合</returns>
        public static List<T> DataTableToList<T>(this DataTable dt) where T : class
        {
            List<T> _list = new List<T>();
            if (dt == null) return _list;
            T model;
            foreach (DataRow dr in dt.Rows)
            //进行循环dataTable行数据
            {
                model = Activator.CreateInstance<T>();
                //获取泛型类型的新实例
                foreach (DataColumn dc in dr.Table.Columns)
                //循环该行的列
                {
                    object drValue = dr[dc.ColumnName];
                    //根据列名获取行数据
                    PropertyInfo pi = model.GetType().GetProperty(dc.ColumnName);
                    //model.GetType()表示获取model的类型，GetProperty()获取指定名称的公共属性,
                    //其中需要引用using System.Reflection;
                    if (pi != null && pi.CanWrite && (drValue != null && !Convert.IsDBNull(drValue)))
                    {
                        if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(int?))
                        //注：如果未加此判断，则会出现 类型“System.Int64”
                        //的对象无法转换为类型“System.Int32”。的错误
                        {
                            drValue = Convert.ToInt32(drValue);
                        }
                        pi.SetValue(model, drValue, null);
                    }
                }

                _list.Add(model);

            }
            return _list;
        }
        /// <summary>
        /// 给实时展示更新数据
        /// </summary>
        /// <param name="token"></param>
        /// <param name="frequency"></param>
        /// <param name="isUseSimulateData">是否启用模拟数据</param>
        /// <returns></returns>
        public async static Task SimulateLiveDisplayData(CancellationToken token, int frequency)
        {
            int starttime = System.Environment.TickCount;
            double num = 0.0;
            Task myTask = new Task(async () =>
            {
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    foreach (var item in Collections.LiveDisplayGaugeItemInfos)
                    {
                        //不同数值的模拟规则
                        if (!item.IsAbsoluteValue)//不是绝对值
                        {
                            Random random = new Random();
                            if (item.UnitSetName == "Force")
                            {
                                double num = random.Next(0, 99) / 10.0;
                                item.DisplayValue = string.Format("{0:f" + item.DecimalPlaces + "}", num);
                            }
                            else if (item.UnitSetName == "Time")
                            {
                                int endtime = System.Environment.TickCount;
                                TimeSpan timeSpan = TimeSpan.FromMilliseconds(endtime - starttime);

                                if (item.Unit == "s")
                                {
                                    num = timeSpan.TotalSeconds;
                                }
                                if (item.Unit == "min")
                                {
                                    num = timeSpan.TotalMinutes;
                                }
                                if (item.Unit == "h")
                                {
                                    num = timeSpan.TotalHours;
                                }
                                item.DisplayValue = string.Format("{0:f" + item.DecimalPlaces + "}", num);
                            }
                            else
                            {
                                double num = random.Next(0, 99) / 10000.0;
                                item.DisplayValue = string.Format("{0:f" + item.DecimalPlaces + "}", num);
                            }
                        }
                    }
                    await Task.Delay(frequency > 0 ? frequency : 50);
                }
            }, token);
            myTask.Start();
        }
        #region 2022/11/12胡建国添加

        /// <summary>
        /// 注册计算表达式中的字段
        /// </summary>
        /// <param name="type">all:所有集合</param>
        /// <returns></returns>
        public static List<DictionaryExt> GetExpressionParams(string type)
        {
            var list = new List<DictionaryExt>();
            var items = GetVariableSet(type);
            //参数的类型
            for (int i = 0; i < items.Count; i++)
            {
                //每个具体参数
                foreach (var item in items[i].AvailableParametersItemsArr)
                {
                    DictionaryExt dictionaryExt = new DictionaryExt();
                    string content = item.Title + item.Tag;
                    //其他参数类型中是否存在相同名字的参数
                    if (items.FindAll(filter => filter.AvailableParametersItemsArr.
                    Any(match => match.Title == item.Title && match.Tag == item.Tag)).Count > 1)
                    {
                        content += "_" + items[i].Title;//用参数类型区分
                        dictionaryExt.Key = content;
                        dictionaryExt.Value = item.HashCodeCache;
                    }
                    else
                    {
                        dictionaryExt.Key = content;
                        dictionaryExt.Value = item.HashCodeCache;
                    }
                    list.Add(dictionaryExt);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取表达式编辑器的可选参数
        /// </summary>
        /// <param name="type">all:所有集合</param>
        /// <returns></returns>
        public static List<GaugeItemInfo> GetVariableSet(string type = "")
        {
            type = type.ToLower();
            List<GaugeItemInfo> VariableSet = new List<GaugeItemInfo>();
            GaugeItemInfo itemInfo = new GaugeItemInfo();
            switch (type)
            {
                case "all":
                    //实物测量
                    //虚拟测量

                    break;
                case "normal":
                    //函数
                    //结果参数
                    //itemInfo.Id = 0;
                    //itemInfo.IsParent = true;
                    //itemInfo.DefaultTitleKey = "扩展类型";
                    //itemInfo.AvailableParametersItemsArr.AddRange(Collections.Sample.NumberInputs);
                    //VariableSet.Add(itemInfo);
                    break;
            }
            //应变 判断实验类型，拉伸
            //样品数字输入
            itemInfo.Id = 1;
            itemInfo.IsParent = true;
            itemInfo.DefaultTitleKey = "SampleNumberInput";
            itemInfo.AvailableParametersItemsArr.AddRange(CheckVariableSet(Collections.Sample.NumberInputs.ToList()));
            VariableSet.Add(itemInfo);
            //试样数字输入
            itemInfo = new GaugeItemInfo();
            itemInfo.Id = 2;
            itemInfo.IsParent = true;
            itemInfo.DefaultTitleKey = "SpecimenNumberInput";
            itemInfo.AvailableParametersItemsArr.AddRange(CheckVariableSet(Collections.Specimen.NumberInputs.ToList()));
            VariableSet.Add(itemInfo);
            //试样属性
            itemInfo = new GaugeItemInfo();
            itemInfo.Id = 3;
            itemInfo.IsParent = true;
            itemInfo.DefaultTitleKey = "SpecimenProperties";
            itemInfo.AvailableParametersItemsArr.AddRange(CheckVariableSet(Collections.Specimen.Properties.GetProperties()));
            VariableSet.Add(itemInfo);
            return VariableSet;
        }
        public static List<GaugeItemInfo> CheckVariableSet(List<GaugeItemInfo> infos)
        {
            List<GaugeItemInfo> VariableSet = new List<GaugeItemInfo>();
            if (infos.Count > 0)
            {
                //2022/11/12胡建国修改
                //Dictionary<string, string> map = new Dictionary<string, string>();//减少后续判断
                foreach (var item in infos.FindAll(fild => fild.IsChecked == true))
                {
                    var set2 = infos.FindAll(fild => fild.Title == item.Title);
                    //if (set2.Count > 1 && !map.ContainsKey(item.Title))//存在重复，并且之前没处理过
                    if (set2.Count > 1)
                    {
                        foreach (var item2 in set2)
                        {
                            item2.Tag = (item2.Index + 1) + "";//区分同组重名
                        }
                        //map.Add(item.Title, item.Description);
                    }
                    if (string.IsNullOrEmpty(item.HashCodeCache))
                    {
                        item.HashCodeCache = DateTime.Now.Ticks + "";//生成唯一标识
                    }
                    VariableSet.Add(item);
                }
            }
            return VariableSet;
        }
        //2022/11/12胡建国舍弃
        /// <summary>
        /// 第一次加载重新引用到对应对象
        /// </summary>
        /// <param name="arrayList"></param>
        //public static void UpDateArrayList(ArrayList arrayList)
        //{
        //    if (arrayList == null || arrayList.Count == 0)
        //    {
        //        return;
        //    }
        //    List<GaugeItemInfo> VariableSet = GetVariableSet("all");
        //    for (int i = 0; i < arrayList.Count; i++)
        //    {
        //        var value = arrayList[i];
        //        if (value is GaugeItemInfo itemInfo)
        //        {
        //            foreach (var item in VariableSet)
        //            {
        //                var Info = item.AvailableParametersItemsArr.ToList().Find(filter => filter.HashCodeCache == itemInfo.HashCodeCache);
        //                if (Info != null && Info != itemInfo)
        //                {
        //                    arrayList[i] = (GaugeItemInfo)Info;
        //                    return;
        //                }
        //                else if (Info != null)
        //                {
        //                    //表示已经是同一个对象了
        //                    return;
        //                }
        //            }
        //        }
        //    }
        //}
        //2022/11/12胡建国添加
        /// <summary>
        /// 计算表达式
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="type">编辑表达式中可选参数集合展示类型：all，normal等</param>
        /// <param name="number">计算结果</param>
        /// <returns></returns>
        public static bool TryCalculated(string expression, string type, out double number)
        {
            number = 0.0;
            try
            {
                var parseOption = ParseOption.CreateOption();
                List<DictionaryExt> list = GetExpressionParams(type);
                foreach (var item in list)
                {
                    var obj = GetGaugeItemInfoByCode(item.Value);
                    if (obj != null)
                    {
                        parseOption.AddLiteralValue(item.Key, obj.DisplayValue);
                    }
                }
                var option = parseOption.AsReadOnly();
                number = expression.Compile(option).EvaluateAs<double>();
                return true;
            }
            catch (UnsupportedOperationException ex)
            {
                MessageBox.Show("有不支持的操作：" + ex.Message);
                return false;
            }
            catch (ParseException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        } 
        #endregion
        /// <summary>
        /// 第一次加载重新引用到对应对象
        /// </summary>
        /// <param name="arrayList"></param>
        public static GaugeItemInfo? GetGaugeItemInfoByCode(string hashcode)
        {
            if (string.IsNullOrEmpty(hashcode))
            {
                return null;
            }
            List<GaugeItemInfo> VariableSet = GetVariableSet("all");
            foreach (var item in VariableSet)
            {
                var Info = item.AvailableParametersItemsArr.ToList().Find(filter => filter.HashCodeCache == hashcode);
                if (Info != null)
                {
                    return (GaugeItemInfo)Info;
                }
            }
            return null;
        }
        /// <summary>
        /// 计算表达式
        /// </summary>
        /// <param name="arrayList">表达式</param>
        /// <param name="number">结果值</param>
        /// <returns>是否成功</returns>
        public static bool TryCalculate(ArrayList arrayList, out double number)
        {
            number = 0.0;
            if (arrayList == null || arrayList.Count == 0)
            {
                return false;
            }
            ArrayList arrList = new ArrayList();
            try
            {
                //《集合名，对象名》
                int i = 0;
                //连续插入的数字
                string numStr = "";
                int lastNumIndex = -1;
                for (; i < arrayList.Count; i++)       //遍历
                {

                    object? value = arrayList[i];
                    //拼数字
                    if ((isNumberic(value.ToString()) || (numStr.Length > 0 && ".".Equals(value)))
                        && (lastNumIndex == -1 || lastNumIndex == i - 1))
                    {
                        if (numStr.Contains('.') && ".".Equals(value) || numStr.Contains("e") || numStr.Contains("π"))
                        {
                            return false;
                        }
                        numStr += value.ToString();
                        lastNumIndex = i;
                        if (lastNumIndex == arrayList.Count - 1)
                        {
                            //最后的数字
                            arrList.Add(numStr);
                            lastNumIndex = -1;
                            numStr = "";
                        }
                        continue;
                    }
                    else if (value is GaugeItemInfo info)         //数字
                    {
                        if (i > 1 && i < arrayList.Count - 1)
                        {
                            if (isNumberic(arrayList[i - 1].ToString()) || isNumberic(arrayList[i + 1].ToString()))
                            {
                                return false;
                            }
                        }

                        //重新在集合中查找不能直接存对象，因为保存再加载就会出问题。
                        //所属父类的Key，拼接的字符串 obj(2) @ Titl
                        //判断是否修约计算
                        arrList.Add(info.DisplayValue);
                        continue;
                        //arrayList[i] = info.Value;不修约
                    }
                    if (value.ToString().Contains('_'))
                    {
                        continue;
                    }
                    //是否有拼接数字
                    if (isNumberic(numStr))
                    {
                        arrList.Add(numStr);
                        lastNumIndex = -1;
                        numStr = "";
                    }
                    arrList.Add(value);
                }
                //解析计算
                Logical logical = new Logical();
                string str = logical.Analysis(arrList);
                if (string.IsNullOrEmpty(str))
                {
                    return false;
                }
                else
                {
                    number = Convert.ToDouble(str);
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrayList"></param>
        /// <param name="insertPreIndex">光标位置</param>
        /// <returns></returns>
        public static int GetArrListIndexByStrIndex(ArrayList arrayList, int insertPreIndex)
        {
            if (insertPreIndex < 0)
            {
                return -1;//越界
            }
            if (insertPreIndex == 0 || arrayList.Count == 0)
            {
                return 0;
            }
            int length = 0;
            for (int i = 0; i < arrayList.Count; i++)
            {
                int temp = length;
                int strLength = arrayList[i].ToString().Length;
                length += strLength;
                if (insertPreIndex <= length)
                {

                    if (insertPreIndex - temp <= strLength / 2)
                    {
                        return i;
                    }
                    else
                    {
                        return i + 1;
                    }
                }
            }
            return arrayList.Count;
        }
        private static bool isNumberic(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            if (value == "e" || value == "π")  //圆周率
                return true;
            for (int i = 0; i < value.Length; i++)
            {
                if (i == 0)
                {
                    if (!isNumber(value[i]))
                    {
                        if ((value[i] == '+' || value[i] == '-') && value.Length != 1)
                            continue;
                        else
                            return false;
                    }
                }
                else
                {
                    if (!isNumber(value[i]))
                        return false;
                }
            }

            return true;
        }
        private static bool isNumber(char value)
        {
            if ('0' <= value && value <= '9' || value == '.')
                return true;
            return false;
        }

    }
    public class MyVisitor : ExpressionVisitor
    {
        [return: NotNullIfNotNull("node")]
        public override System.Linq.Expressions.Expression? Visit(System.Linq.Expressions.Expression? node)
        {
            return base.Visit(node);
        }
        //public Expression GetExpression()
        //{
        //    base.VisitUnary();
        //    return this;
        //}
    }
}
