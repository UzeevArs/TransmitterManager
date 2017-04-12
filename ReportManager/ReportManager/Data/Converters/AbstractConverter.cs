using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Data.Converters
{
    internal interface IAbstractConverter<T>
    {
        IEnumerable<T> Convert(IEnumerable<T> data);
        
    }
    static class ConverterExtentions
    {
        public static IEnumerable<T> Convert<D, T>(this IEnumerable<T> data) where D: IAbstractConverter<T>, new()
        {
            return new D().Convert(data);
        }
    }
}
