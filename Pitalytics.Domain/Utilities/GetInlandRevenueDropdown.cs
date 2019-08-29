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
  public  class GetInlandRevenueDropdown
    {
        internal static IList<SelectListItem> GetInlandRevnue(IList<IInlandRevenue>inlandRevenues,
             int selectedInlandRevenueId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectInland,
                    Value = "-1",
                    Selected = false
                }
            };

            if (inlandRevenues.Any())
            {
                list.AddRange(inlandRevenues.Select(t => new SelectListItem
                {
                    Text = t.InlandRevenueName,
                    Value = t.InlandRevenueId.ToString(),
                    Selected = selectedInlandRevenueId.Equals(t.InlandRevenueId)
                }));
            }

            return list;
        }

    }
}
