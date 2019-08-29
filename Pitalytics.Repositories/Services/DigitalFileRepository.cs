using Pitalytics.Interfaces;
using Pitalytics.Repositories.DataAccess;
using Pitalytics.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitalytics.Repositories.Services
{
    public class DigitalFileRepository : IDigitalFileRepository
    {/// <summary>
     /// Initializes a new instance of the <see cref="DigitalFileRepository"/> class.
     /// </summary>
     /// <param name="dbContextFactory">The database context factory.</param>

        private readonly IDbContextFactory dbContextFactory;

        public DigitalFileRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }




        #region Digital File Setup




        /// <summary>
        /// Saves the digital file.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileExtension">The file extension.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="theContent">The content.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        public string SaveDigitalFile(int digitalFileTypeId, string fileName, string fileExtension, string contentType, byte[] theContent, IDigitalFileView digitalFileView)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (string.IsNullOrEmpty(contentType))
            {
                throw new ArgumentNullException(nameof(contentType));
            }

            if (theContent == null)
            {
                throw new ArgumentNullException(nameof(theContent));
            }

            var result = string.Empty;


            var newRecord = new DigitalFile
            {
                FileTypeId = digitalFileView.FileTypeId,
                FileContent = theContent,
                FileExtension = fileExtension,
                FileName = fileName,
                ContentType = contentType,
                DigitalTypeId = digitalFileTypeId,
                IsActive = true,
                DateCreated = DateTime.Now
            };

            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var fileInfo = dbContext.DigitalFiles.SingleOrDefault(x => x.FileTypeId == newRecord.FileTypeId && x.IsActive == true);
                    if(fileInfo!=null)
                    {
                        fileInfo.IsActive = false;
                    }
                    dbContext.DigitalFiles.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveDigitalFile - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the digital file detail.
        /// </summary>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDigitalFileDetail</exception>
        public IDigitalFile GetDigitalFileDetail(int digitalFileId)
        {
            try
            {
                using (
                    var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = LookupQueries.GetDigitalFileDetail(dbContext, digitalFileId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDigitalFileDetail", e);
            }
        }

        /// <summary>
        /// Gets the tax report file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDigitalFileType</exception>
        public IDigitalFile GetTaxReportFile() 

        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.GetTaxReportFile(dbContext);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTaxReportFile", e);
            }
        }

        /// <summary>
        /// Gets the tax return file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDigitalFileType</exception>
        public IDigitalFile GetTaxReturnFile() 

        {
            try
            {
                using (var dbContext = (PitalyticsEntities)this.dbContextFactory.GetDbContext())
                {
                    var list = LookupQueries.GetTaxReturnFile(dbContext);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTaxReturnFile", e);
            }
        }
        #endregion
    }

}
  
