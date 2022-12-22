using Microsoft.AspNetCore.Components;

namespace BethanyPieShopHRSM.Components
{
    public partial class ProfilePicture
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
