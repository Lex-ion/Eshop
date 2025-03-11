using System.Configuration;

namespace Eshop.Helpers
{
	public class IntegrityHelper
	{
		static IConfiguration? _configuration;
		static IWebHostEnvironment? _webHostEnvironment;
		public static string[] AllowedDirectories => _configuration?.GetSection("AllowedImgDirs").Get<string[]>()
					 ?? throw new KeyNotFoundException();

		public static string CombineImageFolderPath(string directoryName, int entityId) => _webHostEnvironment!.WebRootPath + "/Imgs/" + directoryName + "/" + entityId;

		public static void Start(IConfiguration configuration,IWebHostEnvironment webHostEnvironment)
		{
			_configuration = configuration;
			_webHostEnvironment = webHostEnvironment;
		}


		public static bool DirectoryExists(string directoryName,int entityId)
		{
			if(_configuration is null || _webHostEnvironment is null) throw new NullReferenceException();

			if(!DirectoryIsValid(directoryName) )
				return false;
			string path = _webHostEnvironment.WebRootPath + "/Imgs/" + directoryName+"/" + entityId;

			return Directory.Exists(path);
			

		}

		public static FileInfo[] GetImages(string type, int entityId)
		{
			if (_configuration is null || _webHostEnvironment is null) throw new NullReferenceException();

			
			string path = _webHostEnvironment.WebRootPath + "/Imgs/" + type +"/"+ entityId;
			return new DirectoryInfo(path).GetFiles();
		}

		public static bool DirectoryIsValid(string directoryName)=>AllowedDirectories.Contains(directoryName);
	}
}
