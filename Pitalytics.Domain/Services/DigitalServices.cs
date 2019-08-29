using Pitalytics.Domain.Extensions;
using Pitalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pitalytics.Domain.Services
{
    public class DigitalServices : IDigitalFileServices
    {
     
        private readonly IDigitalFileRepository digitalFileRepository;

      
        public DigitalServices(IDigitalFileRepository digitalFileRepository)
        {
            this.digitalFileRepository = digitalFileRepository;
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <returns></returns>
        public string SaveFile(int digitalFileTypeId, HttpPostedFileBase profilePicture, IDigitalFileView digitalFileView)
        {
            

            var processingMessage = string.Empty;

            if ((profilePicture == null) || (profilePicture.ContentLength < 1))
            {
                return processingMessage;
            }

            byte[] theContent;
            using (Stream inputStream = profilePicture.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                
                theContent = memoryStream.ToArray();
            }

            var fileName = profilePicture.FileName;
            var contentType = profilePicture.ContentType;
            var fileExtension = fileName.FileExtension();

            processingMessage = this.digitalFileRepository.SaveDigitalFile(digitalFileTypeId, fileName, fileExtension,
                contentType, theContent, digitalFileView);

            return processingMessage;
        }

      
    }
}
