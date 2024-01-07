﻿namespace ClubMembershipApplication.FieldValidators;

public delegate bool FieldValidatorDel(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage);
public interface IFieldValidator
{
    void InitializeValidatorDelegate();
    string[] FieldArray { get; }
    FieldValidatorDel ValidatorDel { get; }
}
