namespace Application.Features.RestaurantTables.Constants;

public static class RestaurantTablesBusinessMessages
{
    public const string SectionName = "RestaurantTable";

    public const string RestaurantTableNotExists = "RestaurantTableNotExists";

    public const string TableCapacityMustBeGreaterThanZero = "Masa kapasitesi 1'den küçük olamaz.";

    public const string TableNumberMustBeUniqueInRestaurant = "Ayný restoran içinde bu masa numarasý zaten tanýmlanmýþ.";

    public const string InvalidTableLocation =  "Geçersiz masa konumu.Geçerli konumlar: Ýç Mekan, Dýþ Mekan, Balkon, Bahçe.";
}