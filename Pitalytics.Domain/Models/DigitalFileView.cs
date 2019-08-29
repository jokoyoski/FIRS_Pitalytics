using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pitalytics.Domain.Models
{
    public class DigitalFileView : IDigitalFileView
    {
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
       public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the file type list.
        /// </summary>
        /// <value>
        /// The file type list.
        /// </value>
        public IList<SelectListItem> FileTypeList { get; set; }
        /// <summary>
        /// Gets or sets the file type identifier.
        /// </summary>
        /// <value>
        /// The file type identifier.
        /// </value>
        public int FileTypeId { get; set; }
    }
}
