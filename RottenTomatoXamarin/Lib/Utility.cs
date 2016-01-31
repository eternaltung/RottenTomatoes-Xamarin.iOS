using System;
using System.Threading.Tasks;
using UIKit;
using System.Net.Http;
using Foundation;

namespace RottenTomatoXamarin
{
	public class Utility
	{
		public Utility ()
		{
		}

		/// <summary>
		/// Loads the image.
		/// </summary>
		/// <returns>The image.</returns>
		/// <param name="imageUrl">Image URL.</param>
		public static async Task<UIImage> LoadImage (string imageUrl)
		{
			var httpClient = new HttpClient();
			var contents = await httpClient.GetByteArrayAsync (imageUrl);
			return UIImage.LoadFromData (NSData.FromArray (contents));
		}
	}
}

