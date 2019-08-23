﻿using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Sardin4
{
  partial class AboutDialog : Form
  {
    #region Constructors

    public AboutDialog()
    {
      InitializeComponent();
     // this.Text = String.Format("About {0}", AssemblyTitle);
      //this.labelProductName.Text = AssemblyProduct;
      //this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
      //this.labelCopyright.Text = AssemblyCopyright;
      //this.labelCompanyName.Text = AssemblyCompany;
      //this.textBoxDescription.Text = AssemblyDescription;
    }

    #endregion

    #region Overridden Members

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      this.Activate();
    }

    #endregion

    #region Properties

    public string AssemblyCompany
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        if (attributes.Length == 0)
          return "";
        return ((AssemblyCompanyAttribute)attributes[0]).Company;
      }
    }

    public string AssemblyCopyright
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        if (attributes.Length == 0)
          return "";
        return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
      }
    }

    public string AssemblyDescription
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        if (attributes.Length == 0)
          return "";
        return ((AssemblyDescriptionAttribute)attributes[0]).Description;
      }
    }

    public string AssemblyProduct
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        if (attributes.Length == 0)
          return "";
        return ((AssemblyProductAttribute)attributes[0]).Product;
      }
    }

    public string AssemblyTitle
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if (attributes.Length > 0)
        {
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if (titleAttribute.Title != "")
            return titleAttribute.Title;
        }
        return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    public string AssemblyVersion
    {
      get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
    }

    #endregion
  }
}
