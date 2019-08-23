using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Sardin4
{
    public partial class SettingsDialog : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        #region Constructors

        public SettingsDialog()
        {
            InitializeComponent();

            int id = 0;     // The id of the hotkey. 
            RegisterHotKey(this.Handle, id, (int)KeyModifier.Shift, Keys.F3.GetHashCode());       // Register Shift + F3 as global hotkey. 
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                if (id == 0)
                {
                    Clipboard.SetText(Uglify(Clipboard.GetText(), trackBar1.Value));
                    // do something
                }
            }
        }

        private void ExampleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           UnregisterHotKey(this.Handle, 0);       // Unregister hotkey with id 0 before closing the form. You might want to call this more than once with different id values if you are planning to register more than one hotkey.
        }

        #endregion

        #region Overridden Members

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Activate();
        }

        #endregion

        #region MyTry

        private void SettingsDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.F3)
            {
                this.Hide();
            }
        }

            private void button1_Click(object sender, EventArgs e)
        {
            String toUgly = textBox1.Text;
            int precent = trackBar1.Value;  
            String t2 = Uglify(toUgly, precent);
            textBox2.Text = t2;
            Clipboard.SetText(t2);
        }

        #endregion

        private String Uglify(String text, int precent)
        {
            Random randomizer = new Random();
            if (text != "") //תריץ רק במקרה שבו יש טקסט
            {
                char[] a = text.ToCharArray();
                String t2 = "";
                bool d2 = true;
                int bar = precent;
                for (int i = 0; i < a.Length - 1; i++)
                {
                    int randomNumber = randomizer.Next(0, 100);
                    if (randomNumber <= bar) //הסיכויים לבצע שגיאת כתיב
                    {
                        if (a[i + 1] == ' ') //השיט עם הרווח הזה
                        {
                            if (a[i] == 'ק')
                                t2 += 'ך';
                            else if (a[i] == 'א')
                                t2 += 'ו';
                            else if (a[i] == 'ע')
                            {
                                t2 += 'א';
                                t2 += 'ה';
                            }
                            else if (a[i] == 'י' && a[i + 1] == 'י')
                            {
                                t2 += 'א';
                                t2 += 'י';
                                i++;
                            }
                            else if (a[i] == 'ו' && a[i + 1] == 'ו')
                            {
                                t2 += 'ב';
                                i++;
                            }
                            else if (a[i] == 'א')
                            {
                                t2 += 'ה';
                            }
                            else if (a[i] == 'ע')
                            {
                                t2 += 'ה';
                            }
                            else if (a[i] == 'ה')
                            {
                                if (d2 == true)
                                {
                                    t2 += 'א';
                                    d2 = false;
                                }
                                else
                                {
                                    d2 = true;
                                    t2 += 'ה';
                                }
                            }
                            else if (a[i] == 'ט')
                            {
                                t2 += 'ת';
                            }
                            else if (a[i] == 'ת')
                            {
                                t2 += 'ט';
                            }
                            else if (a[i] == 'ך')
                            {
                                t2 += 'כ';
                                t2 += 'ה';
                            }
                            /*                            else if (a[i] == 'ז')
                                                        {
                                                            t2 += 'ץ';
                                                        }
                                                        else if (a[i] == 'ץ')
                                                        {
                                                            t2 += 'ז';
                                                        } */
                            else
                                t2 += a[i];

                        }




                        else if (a[i] == 'י' && a[i + 1] == 'י')
                        {
                            t2 += 'א';
                            t2 += 'י';
                            i++;
                        }
                        else if (a[i] == 'ו' && a[i + 1] == 'ו')
                        {
                            t2 += 'ב';
                            i++;
                        }
                        else if (a[i] == 'א')
                        {
                            t2 += 'ה';
                        }
                        else if (a[i] == 'ע')
                        {
                            t2 += 'ה';
                        }
                        else if (a[i] == 'ה')
                        {
                            if (d2 == true)
                            {
                                t2 += 'א';
                                d2 = false;
                            }
                            else
                            {
                                d2 = true;
                                t2 += 'ה';
                            }
                        }
                        else if (a[i] == 'ט')
                        {
                            t2 += 'ת';
                        }
                        else if (a[i] == 'ת')
                        {
                            t2 += 'ט';
                        }
                        else if (a[i] == 'ח')
                        {
                            t2 += 'כ';
                        }
                        else if (a[i] == 'ך')
                        {
                            t2 += 'כ';
                            t2 += 'ה';
                        }
                        else if (a[i] == 'ק')
                        {
                            t2 += 'כ';
                        }
                        /*                        else if (a[i] == 'ז')
                                                {
                                                    t2 += 'צ';
                                                }
                                                else if (a[i] == 'צ')
                                                {
                                                    t2 += 'ז';
                                                }   */
                        else
                            t2 += a[i];
                    }
                    else
                        t2 += a[i];
                }
                t2 += a[a.Length - 1];
                return t2;
            }
            return text;
        }
    }

}


