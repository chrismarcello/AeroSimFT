using AeroSimFT.Services;
using AeroSimFT.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroSimFT.Pages
{
    public partial class FlownFlights
    {
        IQueryable<FlightsFlown>? Items;
        PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
        protected override async Task OnInitializedAsync()
        {
            AppState.FlownFlights = this;

            Items = (await XplaneServices.GetFlownFlightsAsync()).AsQueryable();
        }
    }
}
