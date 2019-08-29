using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Domain.Models
{
   public class DigitalFileListView : IDigitalFileListView
    {
        /// <summary>
        /// Gets or sets the selected digital file identifier.
        /// </summary>
        /// <value>
        /// The selected digital file identifier.
        /// </value>
        public int SelectedDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected file.
        /// </summary>
        /// <value>
        /// The name of the selected file.
        /// </value>
        public string SelectedFileName { get; set; }

      
        public IList<IDigitalFileView> DigitalFileCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        public int DigitalFileId { get; set; }
    }
}
