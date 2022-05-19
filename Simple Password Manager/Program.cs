using SimplePM.Forms;
using SimplePM.Library.Diagnostics;
using SimplePM.Library.Networking;
using System;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace SimplePM
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += (sender, e) => OnApplicationExit();
            Application.ThreadException += new ThreadExceptionEventHandler(OnThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);
            if (Properties.Settings.Default.IsFirstRun)
            {
                if (ConnectivityManager.IsAnyNetworkAvailable())
                {
                    Properties.Settings.Default.IsFirstRun = false;
                    Properties.Settings.Default.Save();
                    Application.Run(new FirstStartupForm(nameof(Program)));
                }
                else
                {
                    MessageBox.Show("No available network connections detected. Proceeding in standalone mode", "Connectivity Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Run(new StartupForm());
                }
            }
            else
            {
                Application.Run(new StartupForm());
            }
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windows Forms Error", e.Exception);
                Logger.CreateExceptionEntry(e.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    if (MainForm.processor != null)
                    {
                        MainForm.processor.SaveChanges();
                    }
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                Logger.CreateExceptionEntry(ex);
                if (MainForm.processor != null)
                {
                    MainForm.processor.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
                        "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private static async void OnApplicationExit()
        {
            try
            {
                if (MainForm.processor != null)
                {
                    if (Properties.Settings.Default.IsSignedIn)
                    {
                        await MainForm.processor.SynchronizeAsync(Properties.Settings.Default.AccountID);
                    }
                    MainForm.processor.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    Logger.CreateExceptionEntry(ex);
                    if (MainForm.processor != null)
                    {
                        MainForm.processor.SaveChanges();
                    }
                }
                catch (Exception exc)
                {
                    try
                    {
                        MessageBox.Show("Fatal Non-UI Error",
                            "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                            + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    finally
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. Please contact the adminstrator " +
                "with the following information:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }
    }
}
