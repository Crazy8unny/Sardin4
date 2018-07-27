using System;
using System.Windows.Forms;

namespace ApplicationContextExample
{
  internal static class Program
  {
    #region Class Members

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new CustomApplicationContext());
    }

    #endregion
  }
}
