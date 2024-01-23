using BuildManager.Library.DataBaseModels;
using Newtonsoft.Json;
using System.Text;
using Attribute = BuildManager.Library.DataBaseModels;

namespace Buildmanager.Library.Services
{
	public partial class ApiService
	{
		public static async Task<HttpResponseMessage> CreateSetList(SetList setList)
		{
			string jsonChore = JsonConvert.SerializeObject(setList);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.SetListUrl,httpContent);
			return result;
		}

		public static async Task<SetList> GetSetList(short id)
		{
			var url = Constants.SetListUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<SetList>(result);
			return deserializedResult;
		}

		public static async Task<List<SetList>> GetAllSetLists()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.SetListUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<SetList>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateSetList(SetList setList)
		{
			var url = Constants.SetListUrl + setList.SetId.ToString();
			string jsonChore = JsonConvert.SerializeObject(setList);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteSetList(SetList setList)
		{
			 var url = Constants.SetListUrl + setList.SetId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateSetUsableItemSlots(SetUsableItemSlots setUsableItemSlots)
		{
			string jsonChore = JsonConvert.SerializeObject(setUsableItemSlots);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.SetUsableItemSlotsUrl,httpContent);
			return result;
		}

		public static async Task<SetUsableItemSlots> GetSetUsableItemSlots(int id)
		{
			var url = Constants.SetUsableItemSlotsUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<SetUsableItemSlots>(result);
			return deserializedResult;
		}

		public static async Task<List<SetUsableItemSlots>> GetAllSetUsableItemSlotss()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.SetUsableItemSlotsUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<SetUsableItemSlots>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateSetUsableItemSlots(SetUsableItemSlots setUsableItemSlots)
		{
			var url = Constants.SetUsableItemSlotsUrl + setUsableItemSlots.SetUsableItemSlotsId.ToString();
			string jsonChore = JsonConvert.SerializeObject(setUsableItemSlots);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteSetUsableItemSlots(SetUsableItemSlots setUsableItemSlots)
		{
			 var url = Constants.SetUsableItemSlotsUrl + setUsableItemSlots.SetUsableItemSlotsId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

	}
}