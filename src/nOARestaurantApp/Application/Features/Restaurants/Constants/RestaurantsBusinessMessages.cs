namespace Application.Features.Restaurants.Constants;

public static class RestaurantsBusinessMessages
{
    public const string SectionName = "Restaurant";

    public const string RestaurantNotExists = "RestaurantNotExists";

    public const string DuplicatePhoneNumber = "Bu telefon numarasý zaten bir restoran tarafýndan kullanýlýyor.";
    public const string MustBeClosedOnMonday = "Restoran pazartesi günleri kapalý olmalýdýr.";

    public const string DuplicateRestaurantInSameLocation = "Ayný lokasyonda ayný isimle bir restoran zaten mevcut.";

    public const string LocationCannotBeEmpty = "Lokasyon alaný boþ býrakýlamaz.";
}