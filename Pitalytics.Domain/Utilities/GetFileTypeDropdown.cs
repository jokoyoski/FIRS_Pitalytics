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
   public static class GetFileTypeDropdown
    {
        /// <summary>
        /// Gets the file types.
        /// </summary>
        /// <param name="fileTypes">The file types.</param>
        /// <param name="selectedFileTypeId">The selected file type identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> GetFileTypes(IList<IFileType> fileTypes,
           int selectedFileTypeId) 
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectFileType, 
                    Value = "-1",
                    Selected = false
                }
            };

            if (fileTypes.Any())
            {
                list.AddRange(fileTypes.Select(t => new SelectListItem
                {
                    Text = t.FileName,
                    Value = t.FileTypeId.ToString(),
                    Selected = selectedFileTypeId.Equals(t.FileTypeId)
                }));
            }

            return list;
        }


    }
}
