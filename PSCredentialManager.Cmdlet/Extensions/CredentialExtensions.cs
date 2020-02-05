using PSCredentialManager.Common;
using PSCredentialManager.Common.Exceptions;
using System;
using System.Management.Automation;
using Windows.Security.Credentials;

namespace PSCredentialManager.Cmdlet.Extensions
{
	public static class CredentialExtensions
	{
		public static PSCredential ToPsCredential(this PasswordCredential Credential)
		{
			try
			{
				Credential.RetrievePassword();

				if (Credential.UserName == null || Credential.Password == null)
				{
					throw new IncompatibleCredentialException("PSCredentialManager.Cmdlet.Utility.PSCredentialUtility.ConvertToPSCredential Unable to convert credential objects with no username");
				}

				return new PSCredential(Credential.UserName, Credential.Password.ToSecureString());
			}
			catch (Exception ex)
			{
				throw new Exception("PSCredentialManager.Cmdlet.Utility.PSCredentialUtility.ConvertToPSCredential Unable to convert credential object", ex);
			}
		}
	}
}
