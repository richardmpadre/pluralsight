using Microsoft.AspNetCore.Components;

namespace BethanyPieShopHRSM.Pages
{
    public partial class Index
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
