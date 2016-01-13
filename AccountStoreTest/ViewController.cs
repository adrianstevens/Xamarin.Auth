using System;

using UIKit;
using System.Text;
using Xamarin.Auth;
using System.Linq;
using System.Diagnostics;

namespace AuthStoreTest
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		partial void BtnSave_TouchUpInside (UIButton sender)
		{
			StoreData();
		}

		partial void BtnLoad_TouchUpInside (UIButton sender)
		{
			LoadData ();
		}

		void StoreData ()
		{
			var store = AccountStore.Create();
			var account = new Account ("Test");
			var data = GetData ();
			account.Properties.Add ("key", ByteArrayToString (data));

			store.Save (account, "ServiceID");

			DebugOutput ("StoreData", data);
		}

		void LoadData ()
		{
			var store = AccountStore.Create();
			var account = store.FindAccountsForService ("ServiceID").FirstOrDefault ();

			if (account == null)
				return;

			string dataText;
			account.Properties.TryGetValue ("key", out dataText);

			var data = StringToByteArray (dataText);
			DebugOutput ("LoadData", data);

			var res = CheckData (data);

			if (res == false)
				Debug.WriteLine ("corrupted");
		}

		byte [] GetData ()
		{
			var newArray = new byte[256];

			for (int i = 0; i < 256; i++)
				newArray [i] = (byte)i;

			return newArray;
		}

		bool CheckData (byte[] data)
		{
			for (byte i = 0; i < 255; i++)
			{
				if (data [i] != i) {
					Debug.WriteLine ("Failed at {0}", i);
					return false;
				}
			}
			return true;
		}

		public string ByteArrayToString (byte[] data)
		{
			return Convert.ToBase64String (data);
		}

		public byte[] StringToByteArray (string text)
		{
			return Convert.FromBase64String (text);
		}

		void DebugOutput (string msg, byte[] data)
		{
			Debug.WriteLine (msg + " " + BitConverter.ToString (data));
		}
	}
}