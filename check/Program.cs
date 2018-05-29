using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace check
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);//捕获系统所产生的异常。
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            Program.CheckInstance();//检查程序是否运行多实例

            if (frmLogincs.Login())
            {
                // if (Program.CheckAndDownloadNewVersion() == false)
                {
                    Program.MainForm.Show();
                    Application.Run();
                }
                //else
                //    Application.Exit();
            }
            else//登录失败,退出程序
                Application.Exit();
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Msg.ShowException(e.Exception);//处理系统异常
        }

        private static frmMain _mainForm = null;

        /// <summary>
        /// MDI主窗体
        /// </summary>        
        public static frmMain MainForm { get { return _mainForm; } set { _mainForm = value; } }

        /// <summary>
        ///检查程序是否运行多实例
        /// </summary>
        public static void CheckInstance()
        {
            Boolean createdNew; //返回是否赋予了使用线程的互斥体初始所属权
            Mutex instance = new Mutex(true, "ANNTO-WORKBENCH", out createdNew); //同步基元变量
            if (createdNew) //首次使用互斥体
            {
                instance.ReleaseMutex();
            }
            else
            {

                Msg.Warning("已经启动了一个程序，请先退出！");
                Application.Exit();
                return;
            }
        }
    }
}
