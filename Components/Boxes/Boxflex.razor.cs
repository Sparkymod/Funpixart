using Microsoft.AspNetCore.Components;

namespace RDK.Components.Boxes
{
    public partial class Boxflex
    {
        [Parameter]
        public int BoxFlexId { get; set; }

        [Parameter]
        public string Header { get; set; } = "";

        [Parameter]
        public string TopHead { get; set; } = "";

        [Parameter]
        public RenderFragment? Content { get; set; } = null!;

        [Parameter]
        public RenderFragment? Footer { get; set; } = null!;

        [Parameter]
        public string ContentStyle { get; set; } = "";

        [Parameter]
        public string ContentClass { get; set; } = "";

        [Parameter]
        public bool IsFullContent { get; set; }
    }
}
