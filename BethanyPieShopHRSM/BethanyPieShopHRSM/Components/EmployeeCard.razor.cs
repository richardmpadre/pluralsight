using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanyPieShopHRSM.Components
{
    public partial class EmployeeCard
    {
        [Parameter]
        public Employee Employee { get; set; } = default!;
        [Parameter]
        public EventCallback<Employee> EmployeeQuickViewClicked { get; set; }
    }
}
