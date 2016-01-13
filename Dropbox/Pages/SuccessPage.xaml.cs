using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DropboxXamAuth
{
	public partial class SuccessPage : ContentPage
	{
		public SuccessPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (App.IsAuthenticated == false)
			{
				Navigation.PushModalAsync(new LoginPage());
			}
		}
	}
}

