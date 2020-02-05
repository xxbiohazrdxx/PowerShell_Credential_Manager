using System;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSCredentialManager.Cmdlet.Extensions;
using PSCredentialManager.Common;
using Windows.Security.Credentials;

namespace PSCredentialManager.CmdletTests.Extensions
{
	[TestClass()]
	public class CredentialExtensionsTests
	{
		[TestMethod()]
		public void ToPSCredentialTest()
		{
			var Credential = new PasswordCredential()
			{
				UserName = "test-user",
				Password = "Password1"
			};

			var psCredential = Credential.ToPsCredential();

			Assert.IsNotNull(psCredential);
			Assert.IsInstanceOfType(psCredential, typeof(PSCredential));
		}

		[TestMethod()]
		[ExpectedException(typeof(Exception))]
		public void ToPSCredentialTest1()
		{
			var Credential = new PasswordCredential()
			{
				UserName = "test-user",
			};

			Credential.ToPsCredential();
		}
	}
}