namespace ReportManager.Core.Utility
{
    internal static class SerialGenerator
    {
    //    public static Tuple<string> Generate(NifudaDataSet.NifudaDataTableRow row)
    //    {

    //        //var serial = "Y2";
    //        //serial += GetYearCode();
    //        //serial += GetMonthCode();
    //        //serial += GenerateUniqueNumber(new UniqueSerialNumberDataTableAdapter().GetData());

    //        var barCode = GenerateUniqueNumber(new UniqueSerialNumberDataTableAdapter().GetData());

    //        return new Tuple<string>(barCode);
    //    }

    //    private static char GetYearCode()
    //    {
    //        int year = DateTime.Now.Year;
    //        switch (year)
    //        {
    //            case 2016: return 'S';
    //            case 2017: return 'T';
    //            case 2018: return 'U';
    //            case 2019: return 'V';
    //            case 2020: return 'W';
    //            case 2021: return 'X';
    //            case 2022: return 'Y';
    //            case 2023: return 'Z';
    //            case 2024: return '1';
    //            case 2025: return '2';
    //            case 2026: return '3';
    //            case 2027: return '4';
    //            case 2028: return '5';
    //            case 2029: return '6';
    //            case 2030: return '7';
    //            case 2031: return '8';
    //            case 2032: return '9';
    //            case 2033: return 'A';
    //            case 2034: return 'B';
    //            case 2035: return 'C';
    //            case 2036: return 'D';
    //            case 2037: return 'E';
    //            case 2038: return 'F';
    //            case 2039: return 'J';
    //            case 2040: return 'H';
    //            case 2041: return 'J';
    //            case 2042: return 'K';
    //            case 2043: return 'L';
    //            case 2044: return 'M';
    //            case 2045: return 'N';
    //            case 2046: return 'P';
    //            case 2047: return 'Q';
    //            default: return ' ';
    //        }
    //    }

    //    private static char GetMonthCode()
    //    {
    //        if (DateTime.Now.Month < 10)
    //        {
    //            return Convert.ToChar(DateTime.Now.Month.ToString());
    //        }
    //        else if (DateTime.Now.Month == 10)
    //        {
    //            return 'A';
    //        }
    //        else if (DateTime.Now.Month == 11)
    //        {
    //            return 'B';
    //        }
    //        else
    //        {
    //            return 'C';
    //        }
    //    }

    //    private static string GenerateUniqueNumber(NifudaDataSet.UniqueSerialNumberDataTableDataTable dataTable)
    //    {
    //        return (dataTable.Select(element =>
    //            Convert.ToInt32(new string(element[0].ToString().ToArray()))).Max() + 1).ToString();
    //    }
    }
}
