namespace Application.Features.RestaurantTables.Constants;

public static class RestaurantTablesBusinessMessages
{
    public const string SectionName = "RestaurantTable";

    public const string RestaurantTableNotExists = "RestaurantTableNotExists";

    public const string TableCapacityMustBeGreaterThanZero = "Masa kapasitesi 1'den k���k olamaz.";

    public const string TableNumberMustBeUniqueInRestaurant = "Ayn� restoran i�inde bu masa numaras� zaten tan�mlanm��.";

    public const string InvalidTableLocation =  "Ge�ersiz masa konumu.Ge�erli konumlar: �� Mekan, D�� Mekan, Balkon, Bah�e.";
}