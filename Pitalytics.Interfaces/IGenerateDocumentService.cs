using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
   public interface IGenerateDocumentService
    {

        /// <summary>
        /// Generates the excel.
        /// </summary>
        /// <param name="taxReturnCollection">The tax return collection.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        byte[] GenerateExcel(IEnumerable<ITaxReturnView> taxReturnCollection, string title);

        /// <summary>
        /// Generates the excel.
        /// </summary>
        /// <param name="taxReportCollection">The tax report collection.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        byte[] GenerateExcel(IEnumerable<ITaxReportView> taxReportCollection, string title);

    }
}
