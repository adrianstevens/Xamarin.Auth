using System;

namespace DropboxXamAuth
{
	public class OAuthSettings
	{
		public string ClientId { get; private set; }
		public string Scope { get; private set;}
		public string AuthorizeUrl { get; private set; }
		public string RedirectUrl { get; private set; }

		public OAuthSettings(string clientId, string scope, string authorizeUrl, string redirectUrl)
		{
			this.ClientId 		= clientId;
			this.Scope	 		= scope;
			this.AuthorizeUrl 	= authorizeUrl;
			this.RedirectUrl 	= redirectUrl;
		}
	}
}