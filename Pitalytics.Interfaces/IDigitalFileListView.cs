using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
   public interface IDigitalFileListView
    {
        /// <summary>
        /// Gets or sets the selected digital file identifier.
        /// </summary>
        /// <value>
        /// The selected digital file identifier.
        /// </value>
        int SelectedDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected file.
        /// </summary>
        /// <value>
        /// The name of the selected file.
        /// </value>
        string SelectedFileName { get; set; }

        /// <summary>
        /// Gets or sets the digital file collection.
        /// </summary>
        /// <value>
        /// The digital file collection.
        /// </value>
        IList<IDigitalFileView> DigitalFileCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        int DigitalFileId { get; set; }
    }
}
