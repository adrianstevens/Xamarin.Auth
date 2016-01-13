using System;
using Xamarin.Auth;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using DropboxXamAuth;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]

namespace DropboxXamAuth
{
	public class LoginPageRenderer : PageRenderer
	{

		bool visible;

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			// url : http://stackoverflow.com/questions/24105390/how-to-login-to-facebook-in-xamarin-forms
			if(	visible == false )
			{
				visible = true;

				var auth = new OAuth2Authenticator (
					clientId: App.OAuthSettings.ClientId, // your OAuth2 client id
					scope: App.OAuthSettings.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
					authorizeUrl: new Uri (App.OAuthSettings.AuthorizeUrl), // the auth URL for the service
					redirectUrl: new Uri (App.OAuthSettings.RedirectUrl)); // the redirect URL for the service

				auth.Completed += (sender, eventArgs) => {
					App.SuccessfulLoginAction.Invoke();

					if (eventArgs.IsAuthenticated)
					{
						App.SaveToken(eventArgs.Account.Properties["access_token"]);
					} 
					else 
					{
						// The user cancelled
					}
				};

				PresentViewController (auth.GetUI (), true, null);
			}
		}
	}
}

