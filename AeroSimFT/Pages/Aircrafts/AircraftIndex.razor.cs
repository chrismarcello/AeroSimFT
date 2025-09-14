using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using AeroSimFT.Services;
using AeroSimFT.EFModels;

namespace AeroSimFT.Pages.Aircrafts
{
    public partial class AircraftIndex
    {
        FluentDataGrid<XpAircraft>? grid;
        PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
        IQueryable<XpAircraft>? items;
        protected override async Task OnInitializedAsync()
        {
            AppState.AircraftIndex = this;
            
            items = (await AircraftServices.GetXpAircraftsAsync()).AsQueryable();

        }
        private void GoToEdit(XpAircraft obj)
        {
            navigationManager.NavigateTo($"/aircraftedit/{obj.AcId}");
        }
    }
}
