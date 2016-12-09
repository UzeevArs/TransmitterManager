namespace ReportManager.Reports
{
    internal interface ISavingReport
    {
        bool IsExistTemplateFile();
        string GetTemplateFileName();
    }
}
