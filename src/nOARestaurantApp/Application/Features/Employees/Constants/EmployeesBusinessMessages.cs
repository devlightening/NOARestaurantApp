namespace Application.Features.Employees.Constants;

public static class EmployeesBusinessMessages
{
    public const string SectionName = "Employee";

    public const string EmployeeNotExists = "EmployeeNotExists";


    public const string EmployeeNameMustBeUnique = "�sim benzersiz olmal�d�r .";

    public const string EmployeeSurnameMustBeUnique = "Soyisim benzersiz olmal�d�r .";

    public const string EmployeePhoneNumberMustBeUnique = "Telefon numaras� benzersiz olmal�d�r .";

    public const string EmployeeEmailMustBeUnique = "E-posta adresi benzersiz olmal�d�r .";

    public const string EmployeeCannotBeAssignedToMultipleRestaurants = "�al��an zaten bir restorana atanm�� .";

    public const string EmployeeMustBeAtLeast18YearsOld = "�al��an en az 18 ya��nda olmal�d�r .";
}