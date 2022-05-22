using Microsoft.AspNetCore.Components;

namespace RDK.Components.Boxes
{
    public partial class BoxStatus
    {
        /// <summary>
        /// 0 = success, 1 = alert, 2 = warning, 3 = danger; otherwise none
        /// </summary>
        [Parameter]
        public int Status { get; set; } = 0;

        [Parameter]
        public string StatusName { get; set; } = "name";

        /// <summary>
        /// Number to display for results.
        /// </summary>
        [Parameter]
        public int ResultNumber { get; set; }

        [Parameter]
        public string InfoUrl { get; set; } = "/";

        private string GetStatus()
        {
            return Status switch
            {
                0 => "green",
                1 => "alert",
                2 => "warning",
                3 => "danger",
                _ => "none"
            };
        }
    }
}
