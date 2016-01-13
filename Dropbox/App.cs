using System;
using Xamarin.Forms;

namespace DropboxXamAuth
{
	public class App : Application
	{
		public static bool IsAuthenticated 
		{
			get 
			{ 
				return !string.IsNullOrWhiteSpace(Token); 
			}
		}

		public static string Token { get; set; }

		//https://www.dropbox.com/developers/apps
		public static OAuthSettings OAuthSettings = new OAuthSettings (
			clientId: "",  	
			scope: "",  		
			authorizeUrl: "https://www.dropbox.com/1/oauth2/authorize",  	
			redirectUrl: "http://localhost/redirect");  

		public App ()
		{
			this.MainPage =  new NavigationPage(new SuccessPage());
		}

		public static void SaveToken(string token)
		{
			Token = token;

			// broadcast a message that authentication was successful
			MessagingCenter.Send<App> (App.Current as App, "Authenticated");
		}

		public static Action SuccessfulLoginAction
		{
			get 
			{
				return new Action (() => App.Current.MainPage.Navigation.PopModalAsync ());
			}
		}
	}
}

