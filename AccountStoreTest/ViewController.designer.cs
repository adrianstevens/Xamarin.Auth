// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AuthStoreTest
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnLoad { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSave { get; set; }

		[Action ("BtnLoad_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnLoad_TouchUpInside (UIButton sender);

		[Action ("BtnSave_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnSave_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnLoad != null) {
				btnLoad.Dispose ();
				btnLoad = null;
			}
			if (btnSave != null) {
				btnSave.Dispose ();
				btnSave = null;
			}
		}
	}
}
