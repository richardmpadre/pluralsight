using Microsoft.AspNetCore.Components;

namespace BethanyPieShopHRSM.Components
{
    public partial class InboxCounter
    {
        private int MessageCount;
        [Inject]
        public ApplicationState ApplicationState { get; set; }

        protected override void OnInitialized()
        {
            MessageCount = ApplicationState.NumberOfMessages;
        }
    }
}
