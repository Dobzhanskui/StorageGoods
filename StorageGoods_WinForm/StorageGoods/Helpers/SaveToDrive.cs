using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using File = Google.Apis.Drive.v3.Data.File;

namespace StorageGoods.Helpers
{
    public class SaveToDrive
    {
        private string[] Scopes = { DriveService.Scope.Drive };
        private string ApplicationName = "********";
        private string FolderId = "*************";

        public UserCredential GetUserCredential()
        {
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string creadPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                creadPath = Path.Combine(creadPath, "driveApiCrentials", "drive-api-credentials.json");

                return GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes,
                    "**********", CancellationToken.None, new FileDataStore(creadPath, true)).Result;
            }
        }

        public DriveService GetDriveService(UserCredential credential)
        {
            return new DriveService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });
        }

        public string UploadFileToDrive(DriveService service, string fileName, string filePath, string contentType)
        {
            var fileDrive = new File
            {
                Name = fileName,
                Parents = new List<string> { FolderId }
            };

            FilesResource.CreateMediaUpload request;

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                request = service.Files.Create(fileDrive, stream, contentType);
                request.Upload();
            }

            return request.ResponseBody.Id;
        }
    }
}
