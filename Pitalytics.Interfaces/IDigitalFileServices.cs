using System.Web;

namespace Pitalytics.Interfaces 
{
    public interface IDigitalFileServices
    {
        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        string SaveFile(int digitalFileTypeId, HttpPostedFileBase profilePicture, IDigitalFileView digitalFileView);


       
    }
}
