using System;
using System.Threading.Tasks;
using UIKit;
using System.Net.Http;
using Foundation;
using System.Collections.Generic;
using RottenTomatoXamarin.Model;
using Newtonsoft.Json;

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
			try 
			{
				var httpClient = new HttpClient();
				var contents = await httpClient.GetByteArrayAsync (imageUrl);
				return UIImage.LoadFromData (NSData.FromArray (contents));
			} 
			catch (Exception) 
			{
				return null;
			}
		}

		/// <summary>
		/// Gets the movie data.
		/// </summary>
		/// <returns>The movie data.</returns>
		public static async Task<List<Movie>> GetMovieData(string url)
		{
			HttpClient client = new HttpClient();
			try 
			{
				string json = await client.GetStringAsync(new Uri(url, UriKind.Absolute));
				MovieModel model = JsonConvert.DeserializeObject<MovieModel>(json);
				return model.movies;
			} 
			catch (Exception) 
			{
				return new List<Movie> ();
			}

		}
	}
}

