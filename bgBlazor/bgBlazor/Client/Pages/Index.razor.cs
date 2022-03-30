using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using bgBlazor.Client;
using bgBlazor.Client.Shared;

namespace bgBlazor.Client.Pages
{
    public partial class Index
    {

        private RenderFragment? DynamicContent { get; set; }

        public int SimpleParam1 { get; set; }
        public int AdvancedParam1 { get; set; }

        protected override void OnInitialized()
        {

            SimpleParam1 = 0;
            AdvancedParam1 = 2;

            // ShowSimpleCoding();

            ShowCoding();
            base.OnInitialized();
        }

        private void ShowCoding(string? type = null)
        {
            if (type == "Advanced")
            {
                ShowAdvancedCoding();
            }
            else
            {
                ShowSimpleCoding();
            }
        }

        private void ShowSimpleCoding()
        {
            DynamicContent = builder =>
            {
                builder.OpenComponent(0, typeof(SimpleCoding));
                builder.AddAttribute(1, "PageParam1", SimpleParam1);
                builder.CloseComponent();
            };
        }
        private void ShowLongSimple()
        {
            SimpleParam1 = 1;
        }

        private void ShowAdvancedCoding()
        {
            DynamicContent = builder =>
            {
                builder.OpenComponent(0, typeof(AdvancedCoding));
                builder.AddAttribute(1, "PageParam1", AdvancedParam1);
                builder.CloseComponent();
            };
        }

        private void ShowLongAdvanced()
        {
            AdvancedParam1 = 3;
        }

    }
}