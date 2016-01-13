using System;
using Xamarin.Forms;
using DropboxXamAuth;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using Android.App;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]

namespace DropboxXamAuth
{
	public class LoginPageRenderer : PageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			// this is a ViewGroup - so should be able to load an AXML file and FindView<>
			var activity = this.Context as Activity;

			var auth = new OAuth2Authenticator (
				clientId: App.OAuthSettings.ClientId, // your OAuth2 client id
				scope: App.OAuthSettings.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
				authorizeUrl: new Uri (App.OAuthSettings.AuthorizeUrl), // the auth URL for the service
				redirectUrl: new Uri (App.OAuthSettings.RedirectUrl)); // the redirect URL for the service

			auth.Completed += (sender, eventArgs) => {
				if (eventArgs.IsAuthenticated) {
					App.SuccessfulLoginAction.Invoke();
					// Use eventArgs.Account to do wonderful things
					App.SaveToken(eventArgs.Account.Properties["access_token"]);
				} else {
					// The user cancelled
				}
			};

			activity.StartActivity (auth.GetUI(activity));
		}
	}
}