
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
    public static class GetUserDropdown
    {
        internal static IList<SelectListItem> UserListItems(IList<IUserRegistration> userRegistrations,
                 int selectedUserId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectUser,
                    Value = "-1",
                    Selected = false
                }
            };

            if (userRegistrations.Any())
            {
                list.AddRange(userRegistrations.Select(t => new SelectListItem
                {
                    Text = t.Email,
                    Value = t.UserRegistrationId.ToString(),
                    Selected = selectedUserId.Equals(t.UserRegistrationId)
                }));
            }

            return list;
        }
    }
}
