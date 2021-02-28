using EasyFeedback.Core.UI;

namespace EasyFeedback
{
    public class PriorityDropdown : FormElement
    {
        private IDropdown priorityDropdown;

        public override void Awake()
        {
            base.Awake();
            priorityDropdown = UIInterop.GetDropdown(gameObject);

            // add options
            priorityDropdown.ClearOptions();
            for (var i = 0; i < Form.Config.Board.Labels.Length; i++)
                priorityDropdown.AddOption(Form.Config.Board.Labels[i].name);

            priorityDropdown.Value = 0;
            priorityDropdown.RefreshShownValue();
        }

        public override void FormClosed()
        {
        }

        public override void FormOpened()
        {
        }

        public override void FormSubmitted()
        {
            // add the selected label to the report
            Form.CurrentReport.AddLabel(
                Form.Config.Board.Labels[priorityDropdown.Value]
            );
        }
    }
}