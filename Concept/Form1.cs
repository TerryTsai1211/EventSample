using System;
using System.Text;
using System.Windows.Forms;

namespace Concept
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += (sender, e) =>
            {
                // 直接呼叫 method
                button2_Click(sender, e);

                // 按 F12 看 MS source code
                // button2.PerformClick();
            };

            button2.Click += button2_Click;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((sender is Button btn) == false)
                return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(nameof(button2_Click));
            sb.AppendLine(btn.Name);
            MessageBox.Show(sb.ToString());
        }

        #region 直接觸發事件討論
        public event Action<object, EventArgs> DemoEvent;

        private void button3_Click(object sender, EventArgs e)
        {
            // why：為什麼不能直接 Invoke button2.Click 事件，但是 DemoEvent 可以

            //button2.Click?.Invoke(this , new EventArgs());

            DemoEvent?.Invoke(this, new EventArgs());
        } 
        #endregion

    }
}
