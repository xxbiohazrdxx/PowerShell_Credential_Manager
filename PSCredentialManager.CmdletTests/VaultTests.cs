using System;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSCredentialManager.Cmdlet.Extensions;
using PSCredentialManager.Common;
using Windows.Security.Credentials;
using System.Linq;

namespace PSCredentialManager.CmdletTests
{
	[TestClass()]
	public class VaultTests
	{
		[TestMethod()]
		public void VaultInitializationTest()
		{
			var Vault = new PasswordVault();

			Assert.IsNotNull(Vault);
		}

		[TestMethod()]
		public void VaultRetrievalTest()
		{
			var Vault = new PasswordVault();
			var Credentials = Vault.RetrieveAll();

			Assert.IsNotNull(Credentials);
		}

		[TestMethod()]
		public void VaultAddTest()
		{
			var Vault = new PasswordVault();

			var Credential = new PasswordCredential("PSCredentialManagerTest", "test-user", "Password1");
			Vault.Add(Credential);
		}

		[TestMethod()]
		public void VaultLongPasswordTest()
		{
			var Vault = new PasswordVault();

			var Credential = new PasswordCredential("PSCredentialManagerTest", "test-user", "?E(H+MbQeThWmZq4t7w9z$C&F)J@NcRfUjXn2r5u8x/A%D*G-KaPdSgVkYp3s6v9y$B&E(H+MbQeThWmZq4t7w!z%C*F-J@NcRfUjXn2r5u8x/A?D(G+KbPdSgVkYp3s");
			Vault.Add(Credential);
		}

		[TestMethod()]
		public void VaultRetrievalTest2()
		{
			var Vault = new PasswordVault();
			var Credentials = Vault.RetrieveAll().First();

			Assert.IsNotNull(Credentials);
		}
	}
}