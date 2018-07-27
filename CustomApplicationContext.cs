using System;
using System.Drawing;
using System.Windows.Forms;
using ApplicationContextExample.Properties;
using Cyotek;

namespace ApplicationContextExample
{
  internal class CustomApplicationContext : TrayIconApplicationContext
  {
    #region Instance Fields

    private AboutDialog _aboutDialog;

    private SettingsDialog _settingsDialog;

    #endregion

    #region Constructors

    public CustomApplicationContext()
    {
      this.TrayIcon.Icon = Resources.SmallIcon;

      this.ContextMenu.Items.Add("&סרדין ארבע", null, this.SettingsContextMenuClickHandler).Font = new Font(this.ContextMenu.Font, FontStyle.Bold);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("&אודות", null, this.AboutContextMenuClickHandler);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("&יציאה", null, this.ExitContextMenuClickHandler);
    }

    #endregion

    #region Overridden Members

    protected override void OnTrayIconDoubleClick(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
        this.ShowSettings();

      base.OnTrayIconDoubleClick(e);
    }

    #endregion

    #region Members

    private void AboutContextMenuClickHandler(object sender, EventArgs eventArgs)
    {

      if (_aboutDialog == null)
      {
        using (_aboutDialog = new AboutDialog())
          _aboutDialog.ShowDialog();
        _aboutDialog = null;
      }
      else
        _aboutDialog.Activate();
    }

    private void ExitContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      this.ExitThread();
    }


    private void SettingsContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      this.ShowSettings();
    }

    private void ShowSettings()
    {
      if (_settingsDialog == null)
      {
        using (_settingsDialog = new SettingsDialog())
          _settingsDialog.ShowDialog();
        _settingsDialog = null;
      }
      else
        _settingsDialog.Activate();
    }

    #endregion
  }
}
