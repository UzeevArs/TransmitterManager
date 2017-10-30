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
                inputData.ORDER_NO = inputData.PROD_NO;
                inputData.PROD_NO = "";
                inputData.ITEM_NO = inputData.LINE_NO;
                inputData.FACTOR_500 = inputData.FATOR_500;

                yield return inputData;
            }
        }
    }
     
}
