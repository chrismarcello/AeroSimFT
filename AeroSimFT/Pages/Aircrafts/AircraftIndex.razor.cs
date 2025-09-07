using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using AeroSimFT.Services;
using AeroSimFT.EFModels;

namespace AeroSimFT.Pages.Aircrafts
{
    public partial class AircraftIndex
    {
        protected override async Task OnInitializedAsync()
        {
            AppState.AircraftIndex = this;
            await Task.Delay(0);

        }
    }
}
