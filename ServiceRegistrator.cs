using System.Reflection;
using FluentValidation;
using TicketingSample.Services;

namespace TicketingSample;

public static class ServiceRegistrator
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(typeof(ServiceRegistrator));
        services.AddHttpContextAccessor();
        
        services.AddScoped(typeof(IStorageService<>), typeof(CacheStorageService<>));
        services.AddScoped(typeof(ICookieService<>), typeof(CookieService<>));

        services.AddHttpClient<IApiService, ApiService>(x => {
            x.BaseAddress = new Uri("https://www.ticketportal.sk");
        });

        services.AddScoped<Features.Events.GetList.IEventApiService, Features.Events.GetList.EventApiService>();


        services.AddScoped<IValidator<Features.Events.Create.CreateCommand>, Features.Events.Create.CreateCommandValidator>();

        services.AddScoped<IValidator<Features.Events.Update.UpdateCommand>, Features.Events.Update.UpdateCommandValidator>();

        services.AddScoped<Features.Basket.Reservation.IEventBasketService, Features.Basket.Reservation.EventBasketService>();
        services.AddScoped<IValidator<Features.Basket.Reservation.ReservationCommand>, Features.Basket.Reservation.ReservationCommandValidator>();
    }
}