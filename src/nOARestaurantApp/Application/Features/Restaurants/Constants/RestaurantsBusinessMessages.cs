namespace Application.Features.Restaurants.Constants;

public static class RestaurantsBusinessMessages
{
    public const string SectionName = "Restaurant";

    public const string RestaurantNotExists = "RestaurantNotExists";

    public const string DuplicatePhoneNumber = "Bu telefon numaras� zaten bir restoran taraf�ndan kullan�l�yor.";
    public const string MustBeClosedOnMonday = "Restoran pazartesi g�nleri kapal� olmal�d�r.";

    public const string DuplicateRestaurantInSameLocation = "Ayn� lokasyonda ayn� isimle bir restoran zaten mevcut.";

    public const string LocationCannotBeEmpty = "Lokasyon alan� bo� b�rak�lamaz.";
}