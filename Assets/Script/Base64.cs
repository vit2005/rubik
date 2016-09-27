using System;
using System.Text;

namespace Assets.Scripts.Common
{
	/// <summary>
	/// Simple and fast Base64 XOR encoding with dynamic key (generated on each app run). Use for data protection in RAM. Do NOT use for data storing outside RAM. Do NOT use for secure data encryption.
	/// </summary>
	 
	 
public class Base64
{
		static public string Encode(string toEncode)
		{
			byte[] toEncodeAsBytes
				= System.Text.UTF8Encoding.UTF8.GetBytes(toEncode);
			string returnValue
				= System.Convert.ToBase64String(toEncodeAsBytes);
			return returnValue;
		}

		static public string Decode(string encodedData)
		{
			byte[] encodedDataAsBytes
				= System.Convert.FromBase64String(encodedData);
			string returnValue =
				System.Text.UTF8Encoding.UTF8.GetString(encodedDataAsBytes);
			return returnValue;
		}
}

}