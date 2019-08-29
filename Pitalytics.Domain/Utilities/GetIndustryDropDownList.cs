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
    public class GetIndustryDropDownList
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="industries"></param>
    /// <param name="selectedIndustryId"></param>
    /// <returns></returns>
        internal static IList<SelectListItem> GetIndustry(IList<IIndustry> industries,
               int selectedIndustryId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectIndustry,
                    Value = "-1",
                    Selected = false
                }
            };

            if (industries.Any())
            {
                list.AddRange(industries.Select(t => new SelectListItem
                {
                    Text = t.IndustryName,
                    Value = t.IndustryId.ToString(),
                    Selected = selectedIndustryId.Equals(t.IndustryId)
                }));
            }

            return list;
        }
    }
}
