using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using File = Google.Apis.Drive.v3.Data.File;
using System.DirectoryServices.AccountManagement;

namespace DriveQuickstart
{
    class Program
    {
        private static string[] Scopes = {  DriveService.Scope.Drive };
        private static string ApplicationName = "DriveQuickstart";
        private static string FolderId = "0BynCSNCYJoRtRUlpT2laLXB6SlE";
        private static string _fileName = "AccountsToIB";
        private static readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{_fileName}.txt");
        private static string _contentType = "text/plain";
        static void Main(string[] args)
        {
            Console.WriteLine("Create creds");
            UserCredential credential = GetUserCredential();

            Console.WriteLine("Get service");
            DriveService service = GetDriveService(credential);

            Console.WriteLine("Uploading File");
            UploadFileToDrive(service, _fileName, _filePath, _contentType);

            Console.WriteLine("End");
            Console.ReadLine();

        }

        private static UserCredential GetUserCredential()
        {
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string creadPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                creadPath = Path.Combine(creadPath, "driveApiCrentials", "drive-api-credentials.json");

                return GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes,
                    "Vova", CancellationToken.None, new FileDataStore(creadPath, true)).Result;
            }
        }

        private static DriveService GetDriveService(UserCredential credential)
        {
            return new DriveService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });
        }

        private static string UploadFileToDrive(DriveService service, string fileName, string filePath,
            string contentType)
        {
            var fileDrive = new File
            {
                Name = fileName,
                Parents = new List<string>{ FolderId }
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
