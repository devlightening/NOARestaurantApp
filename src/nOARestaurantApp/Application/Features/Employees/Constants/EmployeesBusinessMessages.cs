namespace Application.Features.Employees.Constants;

public static class EmployeesBusinessMessages
{
    public const string SectionName = "Employee";

    public const string EmployeeNotExists = "EmployeeNotExists";


    public const string EmployeeNameMustBeUnique = "Ýsim benzersiz olmalýdýr .";

    public const string EmployeeSurnameMustBeUnique = "Soyisim benzersiz olmalýdýr .";

    public const string EmployeePhoneNumberMustBeUnique = "Telefon numarasý benzersiz olmalýdýr .";

    public const string EmployeeEmailMustBeUnique = "E-posta adresi benzersiz olmalýdýr .";

    public const string EmployeeCannotBeAssignedToMultipleRestaurants = "Çalýþan zaten bir restorana atanmýþ .";

    public const string EmployeeMustBeAtLeast18YearsOld = "Çalýþan en az 18 yaþýnda olmalýdýr .";
}