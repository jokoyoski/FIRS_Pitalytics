using Pitalytics.Domain.Resources;
using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Domain.Utilities
{
    public class GetDropdownIncomeTypeList
    {
        internal static IList<SelectListItem> GetIncomeType(IList<IIncomeType> incomeTypes,
          int selectedIncomeTypeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectIncome,
                    Value = "-1",
                    Selected = false
                }
            };

            if (incomeTypes.Any())
            {
                list.AddRange(incomeTypes.Select(t => new SelectListItem
                {
                    Text = t.IncomeTypeName,
                    Value = t.IncomeTypeId.ToString(),
                    Selected = selectedIncomeTypeId.Equals(t.IncomeTypeId)
                }));
            }

            return list;
        }

    }
}

