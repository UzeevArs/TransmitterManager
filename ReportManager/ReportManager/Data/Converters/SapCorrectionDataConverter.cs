using ReportManager.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Data.Converters
{
    class SapCorrectionDataConverter : IAbstractConverter<InputData>
    {
        public IEnumerable<InputData> Convert(IEnumerable<InputData> data)
        {
            foreach(var inputData in data)
            {
                string ProdNo = inputData.ORDER_NO;
                inputData.ORDER_NO = inputData.PROD_NO;
                inputData.PROD_NO = ProdNo;
                inputData.ITEM_NO = inputData.LINE_NO;
                
                yield return inputData;
            }
        }
    }
     
}
