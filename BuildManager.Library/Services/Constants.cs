using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Buildmanager.Library.Services
{
    internal class Constants
    {        
        private static HttpClient client = new HttpClient();
        public static HttpClient GetClient()
        {
            return client;
        }
        public static string RestUrl = "http://localhost:5096/api/";

		public static string SetListUrl = string.Concat(RestUrl,"SetLists");
		public static string SetUsableItemSlotsUrl = string.Concat(RestUrl,"SetUsableItemSlotss");
	}
}