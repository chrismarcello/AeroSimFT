using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using AeroSimFT.Services;
using AeroSimFT.EFModels;

namespace AeroSimFT.Pages.Airports
{
    public partial class AirportIndex
    {
        string searchTerm = string.Empty;
        FluentDataGrid<Airport>? resultGrid;
        IQueryable<Airport>? searchResults;
        protected override async Task OnInitializedAsync()
        {
            AppState.AirportIndex = this;
            await Task.Delay(0);

        }
        private async Task OnSearchInput(ChangeEventArgs e)
        {
            if (e.Value is not null)
            {
                resultGrid?.SetLoadingState(true);
                searchTerm = e.Value.ToString() ?? string.Empty;

                if (searchTerm.Length >= 3)
                {
                    searchResults = (await AirportServices.FindAirportsAsync(searchTerm)).AsQueryable();
                    resultGrid?.SetLoadingState(false);
                }
            }
        }
        private void HandleClear()
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return;
            searchTerm = string.Empty;
            searchResults = null;
            StateHasChanged();
        }
        private void GoToDetails(Airport obj)
        {
            navigationManager.NavigateTo($"/airportdetails/{obj.AirportId}");

        }
    }
}
