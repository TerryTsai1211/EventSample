using System;
using System.Windows.Forms;

namespace DataChangeEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 註冊 DataChange Event
            iTextBox1.DataChange += iTextBox1_DataChange;
        }

        void iTextBox1_DataChange(object sender, DataChangeEventArgs e)
        {
            string oldValue = string.IsNullOrWhiteSpace(e.OldValue) ? "空值" : e.OldValue;
            string info = $"觸發時間：{DateTime.Now} - OldValue：{oldValue} - NewValue：{e.NewValue}";
            listBox1.Items.Add(info);
        }
    }
}
