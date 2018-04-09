using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRProg
{
    class MessageErrorBox
    {
        string dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg";
        private string _details;
        private string _message;


        public MessageErrorBox(string details, string message)
        {
            _details = details;
            _message = message;
        }

        public bool ShowErrorMessageForm()
        {
            Type dialogType = typeof(Form).Assembly.GetType(dialogTypeName);
            var dialog = (Form)Activator.CreateInstance(dialogType, new PropertyGrid());

            // Populate relevant properties on the dialog instance.
            dialog.Text = "Ошибка";
            dialogType.GetProperty("Details").SetValue(dialog, _details, null);
            dialogType.GetProperty("Message").SetValue(dialog, _message, null);

            // Display dialog.
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                dialog.Close();
                return true;

            }
            else
            {
                dialog.Close();
                return false;
            }
        }
    }
}
