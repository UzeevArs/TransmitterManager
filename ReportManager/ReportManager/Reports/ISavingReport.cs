namespace ReportManager.Reports
{
    public interface ISavingReport
    {
        bool IsExistTemplateFile();
        string GetTemplateFileName();
    }
}
