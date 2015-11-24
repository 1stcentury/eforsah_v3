using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Reflection;
namespace eforsah_v1
{
	public class RestService
	{
		//public enum httpRequest { POST, GET, PUT , DELETE };
		private string mobilereseturl = "http://m.eforsah.com/api/{0}";
		public string MobileRestURL {
			get{ return mobilereseturl; }
			set { mobilereseturl =   value; }
		}
		HttpClient client;
		public RestService ()
		{
			client = new HttpClient ();
			client.MaxResponseContentBufferSize = 256000;
		}
		/// <summary>
		/// Serializes the content.
		/// </summary>
		/// <returns>The content.</returns>
		/// <param name="objectToSerialize">Object to serialize.</param>
		public string SerializeContent(Object objectToSerialize) 
		{
		return JsonConvert.SerializeObject(objectToSerialize);
		}
//		public async Task<Type> DeSerializeContent(String Content, Type Ts) 
//		{
//			return  JsonConvert.DeserializeObject <Ts>(Content);
//		}
		/// <summary>
		/// Refreshs the data async.
		/// </summary>
		/// <returns>The data async.</returns>
		/// <param name="RestUrl">Rest URL.</param>
		/// <param name="APIName">Method name.</param>
		public async Task<string> GetDataAsync (string RestUrl, string APIName)
		{
			var uri = new Uri (string.Format (RestUrl, APIName));
			var response = await client.GetAsync (uri);
			if (response.IsSuccessStatusCode) {
				var content = await response.Content.ReadAsStringAsync ();
				return content;
			}
		 return string.Empty;
		}
		/*
		/// <summary>
		/// Posts the data async.
		/// </summary>
		/// <returns>The data async.</returns>
		/// <param name="SerializedPostData">Serialized post data.</param>
		/// <param name="RestUrl">Rest URL.</param>
		/// <param name="APIName">Method name.</param>
		public async Task<string> PostDataAsync (string SerializedPostData, string RestUrl, string MethodName = "")
		{
			//var serializedContent = new StringContent (SerializeContent (json), Encoding.UTF8, "application/json");
			var uri = new Uri (string.Format (RestUrl, MethodName));
			HttpResponseMessage responsepost = null;
			responsepost = await client.PostAsync (uri, SerializedPostData);
			var contentpost = await responsepost.Content.ReadAsStringAsync ();
			if (responsepost.IsSuccessStatusCode) {
				return contentpost;
		}
			return string.Empty;
		}*/
		/// <summary>
		/// Posts the data async.
		/// </summary>
		/// <returns>The data async.</returns>
		/// <param name="SerializedPostData">Serialized Post Data</param>
		/// <param name="RestUrl">Rest URL.</param>
		/// <param name="APIName">Method name.</param>
		public async Task<string> PostDataAsync (string SerializedPostData, string RestUrl, string APIName)
		{
			string result = string.Empty;
			try {
				WebClient webclient = new WebClient();
				var uri = new Uri (string.Format (RestUrl, APIName));
				webclient.Headers [HttpRequestHeader.ContentType] = "application/json";
				result = await webclient.UploadStringTaskAsync (uri, SerializedPostData);
				return result;
			} catch (System.Exception sysExc) {
				Console.WriteLine ("Exception: {0}", sysExc);
				//throw;
			}
			return result;
		}
	}
}
 