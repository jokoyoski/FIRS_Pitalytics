using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Interfaces
{
    public interface IDigitalFileRepository
    {

        /// <summary>
        /// Saves the digital file.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileExtension">The file extension.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="theContent">The content.</param>
        /// <returns></returns>
        string SaveDigitalFile(int digitalFileTypeId, string fileName, string fileExtension, string contentType, byte[] theContent, IDigitalFileView digitalFileView);

        /// <summary>
        /// Gets the digital file detail.
        /// </summary>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        IDigitalFile GetDigitalFileDetail(int digitalFileId);
        /// <summary>
        /// Gets the tax return file.
        /// </summary>
        /// <returns></returns>
        IDigitalFile GetTaxReturnFile();
        /// <summary>
        /// Gets the tax report file.
        /// </summary>
        /// <returns></returns>
        IDigitalFile GetTaxReportFile();
    }
}
