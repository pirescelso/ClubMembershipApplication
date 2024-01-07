﻿using System.Text.RegularExpressions;

namespace FieldValidatorAPI;
public delegate bool RequiredValidDel(string fieldVal);
public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);

public class CommonFieldValidatorFunctions
{
    private static RequiredValidDel _requiredValidDel = null;
    private static StringLengthValidDel _stringLengthValidDel = null;
    private static DateValidDel _dateValidDel = null;
    private static PatternMatchValidDel _patternMatchValidDel = null;
    private static CompareFieldsValidDel _compareFieldsValidDel = null;

    public static RequiredValidDel RequiredFieldValidDel
    {
        get
        {
            if (_requiredValidDel == null)
                _requiredValidDel = new RequiredValidDel(RequiredFieldValid);

            return _requiredValidDel;
        }
    }

    public static StringLengthValidDel StringLengthFieldValidDel
    {
        get
        {
            if (_stringLengthValidDel == null)
                _stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);

            return _stringLengthValidDel;
        }
    }

    public static DateValidDel DateFieldValidDel
    {
        get
        {
            if (_dateValidDel == null)
                _dateValidDel = new DateValidDel(DateFieldValid);

            return _dateValidDel;
        }
    }

    public static PatternMatchValidDel PatternMatchValidDel
    {
        get
        {
            if (_patternMatchValidDel == null)
                _patternMatchValidDel = new PatternMatchValidDel(FieldPatternhValid);

            return _patternMatchValidDel;
        }
    }

    public static CompareFieldsValidDel FieldsCompareValidDel
    {
        get
        {
            if (_compareFieldsValidDel == null)
                _compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);

            return _compareFieldsValidDel;
        }
    }
    private static bool RequiredFieldValid(string fieldVal)
    {
        return !string.IsNullOrEmpty(fieldVal);
    }
    private static bool StringFieldLengthValid(string fieldVal, int min, int max)
    {
        return fieldVal.Length >= min && fieldVal.Length <= max;
    }
    private static bool DateFieldValid(string fieldVal, out DateTime validDateTime)
    {
        return DateTime.TryParse(fieldVal, out validDateTime);
    }
    private static bool FieldPatternhValid(string fieldVal, string pattern)
    {
        return Regex.IsMatch(fieldVal, pattern);
    }
    private static bool FieldComparisonValid(string fieldVal, string fieldValCompare)
    {
        return fieldVal == fieldValCompare;
    }


}
