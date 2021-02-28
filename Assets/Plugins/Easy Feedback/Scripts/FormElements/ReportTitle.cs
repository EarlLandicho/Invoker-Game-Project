using EasyFeedback.Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace EasyFeedback
{
    public class ReportTitle : FormElement
    {
        public override void FormClosed()
        {
        }

        public override void FormOpened()
        {
        }

        public override void FormSubmitted()
        {
            Form.CurrentReport.Title = UIInterop.GetInputField(gameObject).Text;
        }
    }

}