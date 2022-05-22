using Microsoft.JSInterop;
using System.Reflection;
using RDK.Components.Notification;

namespace RDK.Data.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Add all services available in the Namespace specified and that ends with "Service" in the folder "Data.Services".
        /// </summary>
        /// <param name="namespace">The namespace to load the services.</param>
        public static void AddAllServicesAvailable(this IServiceCollection services, string @namespace)
        {
            List<Type> serviceClassList = Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsAbstract && t.IsClass && t.Namespace == @namespace + ".Data.Services" && t.Name.EndsWith("Service")).ToList();
            foreach (Type service in serviceClassList)
            {
                services.AddScoped(service);
            }
        }

        /// <summary>
        /// Inject RDK Notification system as a Service.
        /// </summary>
        public static void AddRDKNotification(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
        }

        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data) => js.InvokeAsync<object>(
           "saveAsFile",
           filename,
           Convert.ToBase64String(data));
    }
}
