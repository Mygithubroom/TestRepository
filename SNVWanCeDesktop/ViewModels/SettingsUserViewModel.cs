using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WanCeDesktopApp.Models;

namespace WanCeDesktopApp.ViewModels
{
    public class SettingsUserViewModel : BindableBase
    {
        public List<UserInfo> listui;//保存数据库中读取的数据

        //权限信息
        public bool unit = false;
        public bool setting = false;
        public bool calibration = false;
        public bool verification = false;
        public bool lineCorrection = false;
        public bool keyboardSpeed = false;
        public bool gBiso = false;
        public bool dataRounding = false;
        public bool accountManagement = false;
        public bool previewReport = false;
        public bool testMethod = false;
        public bool editReportTemplate = false;
        public bool dataManagerment = false;
        public bool curveAnalysis = false;
        public bool printReport = false;
        public bool languageManagement = false;

        //public bool Test { get => test; set { test = value; RaisePropertyChanged(); } }//试验 
        //public bool Method { get => method; set { method = value; RaisePropertyChanged(); } }//编辑方法
        public bool Unit { get => unit; set { unit = value; RaisePropertyChanged(); } }//系统管理
        public bool Setting { get => setting; set { setting = value; RaisePropertyChanged(); } }//系统管理
        public bool Calibration { get => calibration; set { calibration = value; RaisePropertyChanged(); } }//校准
        public bool Verification { get => verification; set { verification = value; RaisePropertyChanged(); } }//检定
        public bool LinearCorrection { get => lineCorrection; set { lineCorrection = value; RaisePropertyChanged(); } }//线性修正
        public bool KeyboardSpeed { get => keyboardSpeed; set { keyboardSpeed = value; RaisePropertyChanged(); } }//键盘速度
        public bool GBiso { get => gBiso; set { gBiso = value; RaisePropertyChanged(); } }//标准
        public bool DataRounding { get => dataRounding; set { dataRounding = value; RaisePropertyChanged(); } }//数据对比
        public bool AccountManagement { get => accountManagement; set { accountManagement = value; RaisePropertyChanged(); } }//帐户管理
        public bool PreviewReport { get => previewReport; set { previewReport = value; RaisePropertyChanged(); } }//预览报告
        public bool TestMethod { get => testMethod; set { testMethod = value; RaisePropertyChanged(); } }//试验方法
        public bool EditReportTemplate { get => editReportTemplate; set { editReportTemplate = value; RaisePropertyChanged(); } }//编辑报告模版
        public bool DataManagement { get => dataManagerment; set { dataManagerment = value; RaisePropertyChanged(); } }//数据管理
        public bool CurveAnalysis { get => curveAnalysis; set { curveAnalysis = value; RaisePropertyChanged(); } }//曲线分析
        public bool PrintReport { get => printReport; set { printReport = value; RaisePropertyChanged(); } }//打印报告
        public bool LanguageManagement { get => languageManagement; set { languageManagement = value; RaisePropertyChanged(); } }//管理管理

        //用户信息
        public string id;
        public string password;
        public string level;
        public string userName;
        public string userPhone;

        public string UserID { get => id; set { id = value; RaisePropertyChanged(); } }//用户ID
        public string Password { get => password; set { password = value; RaisePropertyChanged(); } }//用户ID
        public string Level { get => level; set { level = value; RaisePropertyChanged(); } }//用户ID
        public string UserName { get => userName; set { userName = value; RaisePropertyChanged(); } }//用户ID
        public string UserPhone { get => userPhone; set { userPhone = value; RaisePropertyChanged(); } }//用户ID


        public DelegateCommand<UserInfo> CurrentCellChanged { get; private set; }
        public DelegateCommand OKcommand { get; private set; }

        public DelegateCommand UpDateUserInfo { get; private set; }
        public DelegateCommand AddUserInfo { get; private set; }
        public DelegateCommand OkUserInfo { get; private set; }



        /// <summary>
        /// 存储所有账号信息的列表
        /// </summary>
        private List<UserInfo> lstUserModelsData = new List<UserInfo>();
        public List<UserInfo> LstUserModelsData
        {
            get { return lstUserModelsData; }
            set { lstUserModelsData = value; RaisePropertyChanged(); }
        }
        public SettingsUserViewModel()
        {
            InitData();
            AddUserInfo = new DelegateCommand(AddUserToDB);
            UpDateUserInfo = new DelegateCommand(UpDateUserTODB);
            OKcommand = new DelegateCommand(OKInsertDB);

            CurrentCellChanged = new DelegateCommand<UserInfo>(CurrentCellSelectCommand);
        }
        public void AddUserToDB()
        {
            UserID = "";
            Password = "";
            Level = "";
            UserName = "";
            UserPhone = "";

            Unit = false;
            Setting = false;
            Calibration = false;
            Verification = false;
            LinearCorrection = false;
            KeyboardSpeed = false;
            GBiso = false;
            DataRounding = false;
            AccountManagement = false;
            PreviewReport = false;
            TestMethod = false;
            EditReportTemplate = false;
            DataManagement = false;
            CurveAnalysis = false;
            PrintReport = false;
            LanguageManagement = false;
        }
        public void UpDateUserTODB()
        {
            SQLiteHelper dbTable = new SQLiteHelper("UserInfoInfoDataBase");
            StringBuilder strCmd = new StringBuilder();
            //添加变量的有效判断，然后再执行写入数据库操作
            strCmd.Append("UPDATE UserInfoTable SET ");
            strCmd.Append(" UserID=");
            strCmd.Append(UserID); 
            strCmd.Append(",");
            strCmd.Append(" Password=");
            strCmd.Append("\"");
            strCmd.Append(Password);
            strCmd.Append("\"");
            strCmd.Append(",");
            strCmd.Append(" Level=");
            strCmd.Append(Level);
            strCmd.Append(",");
            strCmd.Append(" UserName=");
            strCmd.Append("\"");
            strCmd.Append(UserName);
            strCmd.Append("\"");
            strCmd.Append(",");
            strCmd.Append(" Phone=");
            strCmd.Append(UserPhone);
            if (UserID == null || 
                Password == null || 
                Level == null || 
                UserName == null || 
                UserPhone == null)
            {
                return;
            }
            string sqlStrCommande = strCmd.ToString();
            DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);

            strCmd.Clear();
            dt.Clear();
            sqlStrCommande = "";
            //插入权限表数据
            //添加变量的有效判断，然后再执行写入数据库操作
            strCmd.Append("UPDATE PermissionInfoTable SET ");
            if (Unit)
            {
                strCmd.Append("Unit=1,");
            }
            else
            {
                strCmd.Append("Unit=0,");
            }
            if (Calibration)
            {
                strCmd.Append("Calibration=1,");
            }
            else
            {
                strCmd.Append("Calibration=0,");
            }
            if (Verification)
            {
                strCmd.Append("Verification=1,");
            }
            else
            {
                strCmd.Append("Verification=0,");
            }
            if (LinearCorrection)
            {
                strCmd.Append("LinearCorrection=1,");
            }
            else
            {
                strCmd.Append("LinearCorrection=0,");
            }
            if (KeyboardSpeed)
            {
                strCmd.Append("KeyboardSpeed=1,");
            }
            else
            {
                strCmd.Append("KeyboardSpeed=0,");
            }
            if (GBiso)
            {
                strCmd.Append("GBiso=1,");
            }
            else
            {
                strCmd.Append("GBiso=0,");
            }

            if (DataRounding)
            {
                strCmd.Append("Rounding=1,");
            }
            else
            {
                strCmd.Append("Rounding=0,");
            }

            if (AccountManagement)
            {
                strCmd.Append("AccountManage=1,");
            }
            else
            {
                strCmd.Append("AccountManage=0,");
            }

            if (PreviewReport)
            {
                strCmd.Append("ReadReport=1,");
            }
            else
            {
                strCmd.Append("ReadReport=0,");
            }

            if (TestMethod)
            {
                strCmd.Append("TestMethod=1,");
            }
            else
            {
                strCmd.Append("TestMethod=0,");
            }

            if (EditReportTemplate)
            {
                strCmd.Append("EditReportTmp=1,");
            }
            else
            {
                strCmd.Append("EditReportTmp=0,");
            }

            if (DataManagement)
            {
                strCmd.Append("DataManage=1,");
            }
            else
            {
                strCmd.Append("DataManage=0,");
            }

            if (CurveAnalysis)
            {
                strCmd.Append("CurvilinearAnalysis=1,");
            }
            else
            {
                strCmd.Append("CurvilinearAnalysis=0,");
            }

            if (PrintReport)
            {
                strCmd.Append("PrintReport=1,");
            }
            else
            {
                strCmd.Append("PrintReport=0,");
            }

            if (LanguageManagement)
            {
                strCmd.Append("LanguageManage=1");
            }
            else
            {
                strCmd.Append("LanguageManage=0");
            }

            sqlStrCommande = strCmd.ToString();
            dt = dbTable.ExecuteDataTable(sqlStrCommande);
        }

        public void OKInsertDB()
        {
            SQLiteHelper dbTable = new SQLiteHelper("UserInfoInfoDataBase");
            StringBuilder strCmd = new StringBuilder();
            //添加变量的有效判断，然后再执行写入数据库操作
            strCmd.Append("INSERT INTO UserInfoTable(UserID, Password, Level,UserName, Phone) VALUES ");
            strCmd.Append("(");
            strCmd.Append(UserID);
            strCmd.Append(", ");
            strCmd.Append("\"");
            strCmd.Append(Password);
            strCmd.Append("\"");
            strCmd.Append(", ");
            strCmd.Append(Level);
            strCmd.Append(", ");
            strCmd.Append("\"");
            strCmd.Append(UserName);
            strCmd.Append("\"");
            strCmd.Append(", ");
            strCmd.Append(UserPhone);
            strCmd.Append(");");
            if (UserID == null ||
                Password == null ||
                Level == null ||
                UserName == null ||
                UserPhone == null)
            {
                return;
            }
            string sqlStrCommande = strCmd.ToString();
            DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);

            strCmd.Clear();
            dt.Clear();
            sqlStrCommande = "";
            //插入权限表数据
            //添加变量的有效判断，然后再执行写入数据库操作
            strCmd.Append("INSERT INTO PermissionInfoTable(Unit,Calibration,Verification," +
                "LinearCorrection,KeyboardSpeed,GBiso," +
                "Rounding,AccountManage,ReadReport," +
                "TestMethod,EditReportTmp,DataManage," +
                "CurvilinearAnalysis,PrintReport,LanguageManage) VALUES ");
            strCmd.Append("(");
            if (Unit)
            {
                strCmd.Append("1,");
            } 
            else {
                strCmd.Append("0,");
            }
            if (Calibration)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }
            if (Verification)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }
            if (LinearCorrection)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }
           if (KeyboardSpeed)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }
            if (GBiso)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }

            if(DataRounding)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }

            if (AccountManagement)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }

            if (PreviewReport)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }

            if(TestMethod)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }

            if(EditReportTemplate)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }

            if(DataManagement)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }

            if (CurveAnalysis)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }

            if(PrintReport)
            {
                strCmd.Append("1,");
            }
            else
            {
                strCmd.Append("0,");
            }

            if(LanguageManagement)
            {
                strCmd.Append("1");
            }
            else
            {
                strCmd.Append("0");
            }
            strCmd.Append(");");
            sqlStrCommande = strCmd.ToString();
            dt = dbTable.ExecuteDataTable(sqlStrCommande);
        }


        private void CurrentCellSelectCommand(UserInfo ui)
        {
            UserID = ui.UserID;
            Password = ui.Password;
            Level = ui.Level;
            UserName = ui.UserName;
            UserPhone = ui.Phone;
            if (string.Equals(ui.UserAutonority.unit, "1"))
            {
                Unit = true;
            }
            else
            {
                unit = false;
            }

            if (string.Equals(ui.UserAutonority.calibration, "1"))
            {
                Calibration = true;
            }
            else
            {
                Calibration = false;
            }

            if (string.Equals(ui.UserAutonority.verification, "1"))
            {
                Verification = true;
            }
            else
            {
                Verification = false;
            }

            if (string.Equals(ui.UserAutonority.lineCorrection, "1"))
            {
                LinearCorrection = true;
            }
            else
            {
                LinearCorrection = false;
            }

            if (string.Equals(ui.UserAutonority.keyboardSpeed, "1"))
            {
                KeyboardSpeed = true;
            }
            else
            {
                KeyboardSpeed = false;
            }

            if (string.Equals(ui.UserAutonority.gBiso, "1"))
            {
                GBiso = true;
            }
            else
            {
                GBiso = false;
            }

            if (string.Equals(ui.UserAutonority.dataRounding, "1"))
            {
                DataRounding = true;
            }
            else
            {
                DataRounding = false;
            }

            if (string.Equals(ui.UserAutonority.accountManagement, "1"))
            {
                AccountManagement = true;
            }
            else
            {
                AccountManagement = false;
            }

            if (string.Equals(ui.UserAutonority.previewReport, "1"))
            {
                PreviewReport = true;
            }
            else
            {
                PreviewReport = false;
            }

            if (string.Equals(ui.UserAutonority.testMethod, "1"))
            {
                TestMethod = true;
            }
            else
            {
                TestMethod = false;
            }

            if (string.Equals(ui.UserAutonority.editReportTemplate, "1"))
            {
                EditReportTemplate = true;
            }
            else
            {
                EditReportTemplate = false;
            }

            if (string.Equals(ui.UserAutonority.dataManagerment, "1"))
            {
                DataManagement = true;
            }
            else
            {
                DataManagement = false;
            }

            if (string.Equals(ui.UserAutonority.curveAnalysis, "1"))
            {
                CurveAnalysis = true;
            }
            else
            {
                CurveAnalysis = false;
            }

            if (string.Equals(ui.UserAutonority.printReport, "1"))
            {
                PrintReport = true;
            }
            else
            {
                PrintReport = false;
            }

            if (string.Equals(ui.UserAutonority.languageManagement, "1"))
            {
                LanguageManagement = true;
            }
            else
            {
                LanguageManagement = false;


            }
        }
        private void InitData()//表格初始化的数据源来自数据库表
        {
            lstUserModelsData.Clear();
            string cmdstr1 = "SELECT * FROM UserInfoTable;";
            ReadDataBase(cmdstr1);
            lstUserModelsData = listui;       
        }
        /// <summary>
        /// 读取数据库用户信息表中的内容
        ///UserID//用户ID
        ///Password//用户密码
        ///MethodID//方法ID
        ///Name//姓名
        ///RegDate//注册日期
        ///Phone//电话
        ///PermissionID//权限
        /// </summary>
        private void ReadDataBase(string sqlStrCommande)
        {
            try
            {
                SQLiteHelper dbTable = new SQLiteHelper("UserInfoInfoDataBase");
                DataTable dt = dbTable.ExecuteDataTable(sqlStrCommande);
                UserInfo ui;
                listui = new List<UserInfo>();
                if (dt != null)
                {                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ui = new UserInfo();
                        ui.UserID = dt.Rows[i]["UserID"].ToString();
                        ui.UserName = dt.Rows[i]["UserName"].ToString();
                        ui.MethodID = dt.Rows[i]["MethodID"].ToString();
                        ui.Password = dt.Rows[i]["Password"].ToString();
                        ui.Phone = dt.Rows[i]["Phone"].ToString();
                        ui.Level = dt.Rows[i]["Level"].ToString();
                        ui.PermissionID = dt.Rows[i]["PermissionID"].ToString();                        
                        listui.Add(ui);
                        
                    }
                }
                dt.Clear();
                string cmdstr = "SELECT * FROM PermissionInfoTable;";
                dt = dbTable.ExecuteDataTable(cmdstr);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ui = new UserInfo();
                        listui.ElementAt(i).UserAutonority.unit = dt.Rows[i]["Unit"].ToString();
                        if (string.Equals(ui.UserAutonority.unit, "1"))
                        {
                            unit = true;
                        }
                        else
                        {
                            unit = false;
                        }

                        listui.ElementAt(i).UserAutonority.calibration = dt.Rows[i]["Calibration"].ToString();
                        if (string.Equals(ui.UserAutonority.calibration, "1"))
                        {
                            Calibration = true;
                        }
                        else
                        {
                            Calibration = false;
                        }

                        listui.ElementAt(i).UserAutonority.verification = dt.Rows[i]["Verification"].ToString();
                        if (string.Equals(ui.UserAutonority.verification, "1"))
                        {
                            Verification = true;
                        }
                        else
                        {
                            Verification = false;
                        }

                        listui.ElementAt(i).UserAutonority.lineCorrection = dt.Rows[i]["LinearCorrection"].ToString();
                        if (string.Equals(ui.UserAutonority.lineCorrection, "1"))
                        {
                            LinearCorrection = true;
                        }
                        else
                        {
                            LinearCorrection = false;
                        }

                        listui.ElementAt(i).UserAutonority.keyboardSpeed = dt.Rows[i]["KeyboardSpeed"].ToString();
                        if (string.Equals(ui.UserAutonority.keyboardSpeed, "1"))
                        {
                            KeyboardSpeed = true;
                        }
                        else
                        {
                            KeyboardSpeed = false;
                        }

                        listui.ElementAt(i).UserAutonority.gBiso = dt.Rows[i]["GBiso"].ToString();
                        if (string.Equals(ui.UserAutonority.gBiso, "1"))
                        {
                            GBiso = true;
                        }
                        else
                        {
                            GBiso = false;
                        }

                        listui.ElementAt(i).UserAutonority.dataRounding = dt.Rows[i]["Rounding"].ToString();
                        if (string.Equals(ui.UserAutonority.dataRounding, "1"))
                        {
                            DataRounding = true;
                        }
                        else
                        {
                            DataRounding = false;
                        }

                        listui.ElementAt(i).UserAutonority.accountManagement = dt.Rows[i]["AccountManage"].ToString();
                        if (string.Equals(ui.UserAutonority.accountManagement, "1"))
                        {
                            AccountManagement = true;
                        }
                        else
                        {
                            AccountManagement = false;
                        }

                        listui.ElementAt(i).UserAutonority.previewReport = dt.Rows[i]["ReadReport"].ToString();
                        if (string.Equals(ui.UserAutonority.previewReport, "1"))
                        {
                            PreviewReport = true;
                        }
                        else
                        {
                            PreviewReport = false;
                        }

                        listui.ElementAt(i).UserAutonority.testMethod = dt.Rows[i]["TestMethod"].ToString();
                        if (string.Equals(ui.UserAutonority.testMethod, "1"))
                        {
                            TestMethod = true;
                        }
                        else
                        {
                            TestMethod = false;
                        }

                        listui.ElementAt(i).UserAutonority.editReportTemplate = dt.Rows[i]["EditReportTmp"].ToString();
                        if (string.Equals(ui.UserAutonority.editReportTemplate, "1"))
                        {
                            EditReportTemplate = true;
                        }
                        else
                        {
                            EditReportTemplate = false;
                        }

                        listui.ElementAt(i).UserAutonority.dataManagerment = dt.Rows[i]["DataManage"].ToString();
                        if (string.Equals(ui.UserAutonority.dataManagerment, "1"))
                        {
                            DataManagement = true;
                        }
                        else
                        {
                            DataManagement = false;
                        }

                        listui.ElementAt(i).UserAutonority.curveAnalysis = dt.Rows[i]["CurvilinearAnalysis"].ToString();
                        if (string.Equals(ui.UserAutonority.curveAnalysis, "1"))
                        {
                            CurveAnalysis = true;
                        }
                        else
                        {
                            CurveAnalysis = false;
                        }

                        listui.ElementAt(i).UserAutonority.printReport = dt.Rows[i]["PrintReport"].ToString();
                        if (string.Equals(ui.UserAutonority.printReport, "1"))
                        {
                            PrintReport = true;
                        }
                        else
                        {
                            PrintReport = false;
                        }

                        listui.ElementAt(i).UserAutonority.languageManagement = dt.Rows[i]["LanguageManage"].ToString();
                        if (string.Equals(ui.UserAutonority.languageManagement, "1"))
                        {
                            LanguageManagement = true;
                        }
                        else
                        {
                            LanguageManagement = false;
                        }
                    }

                }
            }
            catch(Exception ex )
            {
                throw ex;
            }
        }


        /// <summary>
        /// 更新当前用户信息
        /// </summary>
        private void InsertUserinfo(string sqlStrCommange)
        {
            try
            {
                SQLiteHelper dbTable = new SQLiteHelper("UserInfoInfoDataBase");
                int val = dbTable.ExecuteNonQuery(sqlStrCommange);//false return 0
                if (val < 1)
                {
                    return;//log位
                }
            }
            catch(Exception ex )
            {
                throw ex;
            }
            
        }


    }
}
