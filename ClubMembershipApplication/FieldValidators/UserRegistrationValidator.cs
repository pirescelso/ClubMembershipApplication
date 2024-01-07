using FieldValidatorAPI;
using static ClubMembershipApplication.FieldValidators.FieldConstants;

namespace ClubMembershipApplication.FieldValidators;

public class UserRegistrationValidator : IFieldValidator
{
    const int FirstNameMinLength = 2;
    const int FirstNameMaxLength = 100;
    const int LastNameMinLength = 2;
    const int LastNameMaxLength = 100;

    delegate bool EmailExistsDel(string EmailAddress);

    FieldValidatorDel _fieldValidatorDel = null;

    RequiredValidDel _requiredValidDel = null;
    StringLengthValidDel _stringLengthValidDel = null;
    DateValidDel _dateValidDel = null;
    PatternMatchValidDel _patternMatchValidDel = null;
    CompareFieldsValidDel _compareFieldsValidDel = null;

    EmailExistsDel _emailExistsDel = null;

    string[] _fieldArray = null;

    public string[] FieldArray
    {
        get
        {
            if (_fieldArray == null)
                _fieldArray = new string[
                    Enum.GetValues(
                        typeof(UserRegistrationField)
                    ).Length
                ];
            return _fieldArray;
        }
    }

    public FieldValidatorDel ValidatorDel => _fieldValidatorDel;

    public UserRegistrationValidator()
    {
        InitializeValidatorDelegate();
    }

    public void InitializeValidatorDelegate()
    {
        _fieldValidatorDel = new FieldValidatorDel(ValidField);

        _requiredValidDel = CommonFieldValidatorFunctions.RequiredFieldValidDel;
        _stringLengthValidDel = CommonFieldValidatorFunctions.StringLengthFieldValidDel;
        _dateValidDel = CommonFieldValidatorFunctions.DateFieldValidDel;
        _patternMatchValidDel = CommonFieldValidatorFunctions.PatternMatchValidDel;
        _compareFieldsValidDel = CommonFieldValidatorFunctions.FieldsCompareValidDel;
    }

    private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
    {
        fieldInvalidMessage = string.Empty;

        UserRegistrationField userRegistrationField = (UserRegistrationField)fieldIndex;
        switch (userRegistrationField)
        {
            case UserRegistrationField.EmailAddress:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty
                    && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Email_Address_RegEx_Pattern))
                    ? $"You must enter a valid email address{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;

            case UserRegistrationField.FirstName:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty
                    && !_stringLengthValidDel(fieldValue, FirstNameMinLength, FirstNameMaxLength))
                    ? $"The length for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)} must be between {FirstNameMinLength} and {FirstNameMaxLength}{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;

            case UserRegistrationField.LastName:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty
                    && !_stringLengthValidDel(fieldValue, LastNameMinLength, LastNameMaxLength))
                    ? $"The length for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)} must be between {LastNameMinLength} and {LastNameMaxLength}{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;

            case UserRegistrationField.Password:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty
                    && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Strong_Password_RegEx_Pattern))
                    ? $"Your password must contain at leat 1 small-case letter, 1 capital letter, 1 special character and the length should be between 6-10 characters{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;

            case UserRegistrationField.PasswordCompare:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty
                    && !_compareFieldsValidDel(fieldValue, fieldArray[(int)UserRegistrationField.Password]))
                    ? $"Your entry did not match your password{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;

            case UserRegistrationField.DateOfBirth:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty
                    && !_dateValidDel(fieldValue, out DateTime validDateTime))
                    ? $"You did not enter a valid date{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;

            case UserRegistrationField.PhoneNumber:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty
                    && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Uk_PhoneNumber_RegEx_Pattern))
                    ? $"You did not enter a valid phone number{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;

            case UserRegistrationField.AddressFirstLine:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                break;

            case UserRegistrationField.AddressSecondLine:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                break;

            case UserRegistrationField.AddressCity:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                break;

            case UserRegistrationField.PostCode:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))
                    ? $"You must enter a value for field {Enum.GetName(typeof(UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : string.Empty;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty
                    && !_patternMatchValidDel(fieldValue, CommonRegularExpressionValidationPatterns.Uk_Post_Code_RegEx_Pattern))
                    ? $"You did not enter a valid post code{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;
            default:
                throw new ArgumentException("This field does not exist");
        }

        return fieldInvalidMessage == string.Empty;
    }
}
