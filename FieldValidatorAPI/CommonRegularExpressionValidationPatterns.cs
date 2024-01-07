namespace FieldValidatorAPI;

public static class CommonRegularExpressionValidationPatterns
{
    public const string Email_Address_RegEx_Pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
    public const string Uk_PhoneNumber_RegEx_Pattern = @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$";
    public const string Uk_Post_Code_RegEx_Pattern = @"^(([A-PR-UWYZ][A-HK-Y]?[0-9][0-9]?)|([A-PR-UWYZ][A-HK-Y][0-9][ABEHMNPRVWXY]?)";
    public const string Strong_Password_RegEx_Pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$";
}
