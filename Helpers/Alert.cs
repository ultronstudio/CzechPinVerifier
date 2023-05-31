using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CzechPinVerifier.Helpers.Alert;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CzechPinVerifier.Helpers
{
    public class Alert
    {
        private AlertType _type;
        private string _text, _caption;
        private MessageBoxButtons _buttons;

        /// <summary>
        /// Initializes a new instance of the Alert class with the specified parameters.
        /// </summary>
        /// <param name="type">The type of alert. Possible values: <see cref="AlertType.error"/>, <see cref="AlertType.info"/></param>
        /// <param name="text">The text to be displayed in the alert.</param>
        /// <param name="caption">The caption or title of the alert.</param>
        /// <param name="buttons">The buttons to be displayed in the alert.</param>
        public Alert(AlertType type, string text, string caption, MessageBoxButtons buttons)
        {
            _type = type;
            _text = text;
            _caption = caption;
            _buttons = buttons;

            ShowAlert();
        }

        public void ShowAlert()
        {
            switch (_type)
            {
                case AlertType.info:
                    SystemSounds.Asterisk.Play();
                    Alert_Info(_text, _caption, _buttons);
                    break;
                case AlertType.error:
                    SystemSounds.Exclamation.Play();
                    Alert_Error(_text, _caption, _buttons);
                    break;
            }
        }

        private void Alert_Info(string text, string caption, MessageBoxButtons buttons)
        {
            MessageBox.Show(text, caption, buttons, MessageBoxIcon.Information);
        }

        private void Alert_Error(string text, string caption, MessageBoxButtons buttons)
        {
            MessageBox.Show(text, caption, buttons, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Represent an type of alert
        /// </summary>
        public enum AlertType
        {
            info,
            error
        }
    }
}
