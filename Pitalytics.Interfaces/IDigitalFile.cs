using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IDigitalFile
    {

        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        int? DigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the content of the file.
        /// </summary>
        /// <value>
        /// The content of the file.
        /// </value>
        byte[] FileContent { get; set; }
        /// <summary>
        /// Gets or sets the digital type identifier.
        /// </summary>
        /// <value>
        /// The digital type identifier.
        /// </value>
        int DigitalTypeId { get; set; }
        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        string Filename { get; set; }
        /// <summary>
        /// Gets or sets the file extension.
        /// </summary>
        /// <value>
        /// The file extension.
        /// </value>
       string FileExtension { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        Nullable<System.DateTime> DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        Nullable<bool> IsActive { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        string ContentType { get; set; }
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file type identifier.
        /// </summary>
        /// <value>
        /// The file type identifier.
        /// </value>
        int FileTypeId { get; set; }
    }
}
