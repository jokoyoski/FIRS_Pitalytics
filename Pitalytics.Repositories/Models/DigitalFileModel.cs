using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Repositories.Models 
{
   public class DigitalFileModel : IDigitalFile
    {
        /// <summary>
        /// Gets or sets the digital file identifier.
        /// </summary>
        /// <value>
        /// The digital file identifier.
        /// </value>
        public int? DigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the content of the file.
        /// </summary>
        /// <value>
        /// The content of the file.
        /// </value>
        public byte[] FileContent { get; set; }
        /// <summary>
        /// Gets or sets the digital type identifier.
        /// </summary>
        /// <value>
        /// The digital type identifier.
        /// </value>
        public int DigitalTypeId { get; set; }
        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string Filename { get; set; }
        /// <summary>
        /// Gets or sets the file extension.
        /// </summary>
        /// <value>
        /// The file extension.
        /// </value>
        public string FileExtension { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public Nullable<System.DateTime> DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public Nullable<bool> IsActive { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        public string ContentType { get; set; }
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file type identifier.
        /// </summary>
        /// <value>
        /// The file type identifier.
        /// </value>
        public int FileTypeId { get; set; } 
    }
}
