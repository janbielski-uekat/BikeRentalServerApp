namespace BikeRentalServerAppUI;

public static class RegisterServices
{
	public static void ConfigureServices(this WebApplicationBuilder builder)
	{
		builder.Services.AddRazorPages();
		builder.Services.AddServerSideBlazor();
		builder.Services.AddMemoryCache();

		builder.Services.AddSingleton<IDbConnection, DbConnection>();
		builder.Services.AddSingleton<ITypeData, MongoTypeData>();
		builder.Services.AddSingleton<IStationData, MongoStationData>();
		builder.Services.AddSingleton<IBookingData, MongoBookingData>();
		builder.Services.AddSingleton<IUserData, MongoUserData>();
	}
}
