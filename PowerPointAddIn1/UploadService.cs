using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GoogleDriveService
{
    public class UploadService
    {
        static String mmType = "Presentaion/pptx";
        //String mmType2 = "Presentaion/pptx";
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "PresentationPlus";
        DriveService service;
       // string target = "";

        public void uploadToDrive(string fullPath, string pathInDriver)
        {
            UserCredential credential;
            credential = GetCredentials();
            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            var folderId = "";
            List<string[]> filesList = ListFiles();
            foreach (var IdAndName in filesList)
            {
                if (IdAndName[1].Equals(returnLastDirectory(fullPath)))
                    DeleteFile(service, IdAndName[0]);
                if (IdAndName[1].Equals(returnLastDirectory(pathInDriver)))
                    folderId = IdAndName[0];
            }
            
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = returnLastDirectory(fullPath),
                Parents = new List<string>
                {
                    folderId
                }
            };
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(fullPath,
                System.IO.FileMode.Open))
            {
                request = service.Files.Create(
                    fileMetadata, stream, mmType);
                request.Fields = "id";
                request.Upload();
            }
           /* var file = request.ResponseBody;
            Console.WriteLine("File ID: " + file.Id);*/
        }
        public List<string[]> ListFiles()
        {
            UserCredential credential;
            credential = GetCredentials();
            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 20;
            listRequest.Fields = "nextPageToken, files(id, name)";
            List<string[]> filesList = new List<string[]>();
            System.Collections.Generic.IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
           // Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                   // if (file.Name.Equals("spl"))
                   //     target = file.Id;
                    string[] toAdd = { file.Id, file.Name };
                    filesList.Add(toAdd);
                    //Console.WriteLine("{0} ({1})", file.Name, file.Id);
                    //Console.WriteLine("{0}", file.Name);
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            return filesList;
        }

        private UserCredential GetCredentials()
        {
            UserCredential credential;
            using (var stream = new FileStream("c:\\client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                // Console.WriteLine("Credential file saved to: " + credPath);
            }
            return credential;
        }

        static public string returnLastDirectory(String Path)
        {
            string[] words = Path.Split('\\');
            if (words.Length < 2)
                return Path;

            return words[words.Length - 1];
        }

        public static void DeleteFile(DriveService service, String fileId)
        {
            try
            {
                service.Files.Delete(fileId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

    }
}
