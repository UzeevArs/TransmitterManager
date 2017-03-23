using ReportManager.Data.Database.DataSet1TableAdapters;
using ReportManager.Data.Database.NifudaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Core.Utility
{
    public static class IndexNOGenerator
    {
        public static int IndexNoLastNumber()
        {
            NifudaDataTableAdapter adapter = new  NifudaDataTableAdapter();
            int IndexNoGenerated = Convert.ToInt32(adapter.GetIndexNOMaxQuery()) + 1;
            return IndexNoGenerated;
        }
    }
}
