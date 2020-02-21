using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatmapHelperImpl
{
	public static void CreatePNG(Texture2D texture1, string path)
	{
		if (path.Length != 0)
		{

			var texture = Object.Instantiate(texture1) as Texture2D;
			var textureColors = texture.GetPixels();
			for (int i = 0; i < textureColors.Length; i++)
			{
				textureColors[i].a = 1;
			}

			texture.SetPixels(textureColors);
			texture.Apply();

			if (texture.format != TextureFormat.ARGB32 && texture.format != TextureFormat.RGB24)
			{
				var newTexture = new Texture2D(texture.width, texture.height);
				Color[] origin = texture.GetPixels(0);
				Color[] works = new Color[origin.Length];
				for (int width = 0; width < texture.width; ++width)
				{
					for (int height = 0; height < texture.height; ++height)
					{
						works[width + texture.width * height] = texture.GetPixel(height, width);
					}
				}
				newTexture.SetPixels(works, 0);
				texture = newTexture;
			}

			var bytes = texture.EncodeToPNG();
			System.IO.File.WriteAllBytes(path, bytes);
		}
	}

	public static void Fix(Texture2D texture1, string path)
	{
		Texture2D texture2 = Object.Instantiate(texture1) as Texture2D;

		if (texture2.format != TextureFormat.ARGB32 && texture1.format != TextureFormat.RGB24)
		{
			var newTexture = new Texture2D(texture2.width, texture2.height);
			newTexture.SetPixels(texture2.GetPixels(0), 0);
			texture2 = newTexture;
			texture2.Apply();
		}

		Color[] textureColors = texture2.GetPixels();

		for (int i = 0; i < textureColors.Length; i++)
		{
			textureColors[i].a = 1.0f - (textureColors[i].r + textureColors[i].g + textureColors[i].b); //Your [B]a[/B] components will be set to whatever is leftover from the other components, when summed)
		}

		texture2.SetPixels(textureColors);
		texture2.Apply();

		if (path.Length != 0)
		{
			var bytes = texture2.EncodeToPNG();
			System.IO.File.WriteAllBytes(path, bytes);
		}
		else
		{

		}

		//  Original version - not used, as it requires the original to be marked read/write and people might not expect the original to be overwritten anyway.
		//	If you want to modify this to save into your original file by default instead of asking, you'll have to pull some stuff from lines #121-124 and modify a litttle.
		//	Debug.Log("Writing to " + AssetDatabase.GetAssetPath(texture1));
		// 	File.WriteAllBytes(AssetDatabase.GetAssetPath(texture1), bytes); 
	}
}
