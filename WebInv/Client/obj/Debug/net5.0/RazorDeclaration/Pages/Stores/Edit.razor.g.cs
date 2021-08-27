// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WebInv.Client.Pages.Stores
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using WebInv.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using WebInv.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Abel\GitHub\Inventory20\WebInv\Client\_Imports.razor"
using WebDBSchema.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Abel\GitHub\Inventory20\WebInv\Client\Pages\Stores\Edit.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Abel\GitHub\Inventory20\WebInv\Client\Pages\Stores\Edit.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Abel\GitHub\Inventory20\WebInv\Client\Pages\Stores\Edit.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/StoreEdit/{id:int}")]
    public partial class Edit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "C:\Abel\GitHub\Inventory20\WebInv\Client\Pages\Stores\Edit.razor"
       
    [Parameter]
    public int id { get; set; }

    private InvStore currentStore;
    public string storename;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            currentStore = await Http.GetFromJsonAsync<InvStore>("api/InvStores/" + this.id);
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }
    }


    protected async Task SubmitButtonClicked()
    {
        HttpResponseMessage res;
        res = await Http.PutAsJsonAsync("api/InvStores/" + this.id, currentStore);

        Console.WriteLine("Submit Code:" + res.StatusCode);

        if (res.IsSuccessStatusCode)
            NavHelper.NavigateTo("/StoreList");

        return;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavHelper { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
