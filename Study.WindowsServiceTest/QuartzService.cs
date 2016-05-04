using Common.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Study.WindowsServiceTest
{
    public partial class QuartzService : ServiceBase
    {
        private readonly ILog logger;
        private IScheduler scheduler;

        public QuartzService()
        {
            InitializeComponent();
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();           
            //scheduler = StdSchedulerFactory.GetDefaultScheduler(); // schedulerFactory.GetDefaultScheduler();        
        }

        protected override void OnStart(string[] args)
        {
            scheduler.Start();
             logger.Info("Quartz服务成功启动");
        }

        protected override void OnStop()
        {
            scheduler.Shutdown(false);
            logger.Info("Quartz服务成功终止");
        }

        protected override void OnPause()
        {
            scheduler.PauseAll();
        }

        protected override void OnContinue()
        {
            scheduler.ResumeAll();
        }

        private void AddTextLine(string line)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\TeamWorldServiceLog.txt", FileMode.OpenOrCreate, FileAccess.Write);

                StreamWriter m_streamWriter = new StreamWriter(fs);

                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);

                m_streamWriter.WriteLine(line + "\r\n");

                m_streamWriter.Flush();

                m_streamWriter.Close();

                fs.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
