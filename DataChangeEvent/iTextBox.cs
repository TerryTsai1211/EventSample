using System;
using System.Windows.Forms;

namespace DataChangeEvent
{
    internal class iTextBox : TextBox
    {
        private string _oldValue;

        public iTextBox()
        {
            // 註冊 KeyPress Event
            KeyPress += iTextBox_KeyPress;
        }

        // Step3-1：宣告 DataChange Event 
        public event DataChangeEventHandler DataChange;

        #region Step3-2 使用 Action Event 寫法

        // public event Action<object , DataChangeEventArgs> DataChange;

        #endregion

        // Step4：建立 OnDataChange() 來觸發 DataChange Event
        protected virtual void OnDataChange(DataChangeEventArgs e)
        {
            if (DataChange != null)
                DataChange(this, e);
        }

        private void iTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
                return;

            // 值沒有變化情況下，就不需要觸發 DataChange Event
            if (_oldValue == Text)
                return;

            // 紀錄新舊值
            DataChangeEventArgs args = new DataChangeEventArgs(_oldValue, Text);

            // 紀錄先舊值後，把新值設定為舊值
            _oldValue = Text;

            // 呼叫 Method 來觸發是事件
            OnDataChange(args);

            #region 直接觸發事件

            // DataChange?.Invoke(this, args);

            #endregion

        }
    }

    // Step2：建立 DataChangeEventHandler Delegate 或是直接在 Step3 使用 Action
    public delegate void DataChangeEventHandler(object sender, DataChangeEventArgs e);

    // Step1：建立 DataChangeEventArgs EventArgs，並宣告兩個 Property
    public class DataChangeEventArgs : EventArgs
    {
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public DataChangeEventArgs(string oldValue, string newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
