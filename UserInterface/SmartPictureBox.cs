using System;
using System.Windows.Forms;

namespace UserInterface
{
    public class SmartPictureBox : PictureBox
    {
        public event Action CoronaSick;

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.Notify();
        }

        public void Notify()
        {
            if (CoronaSick != null)
            {
                CoronaSick.Invoke();
            }
        }
    }
}
