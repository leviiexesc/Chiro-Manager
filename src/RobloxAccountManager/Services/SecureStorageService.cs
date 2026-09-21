using System.Security.Cryptography;
using System.Text;

namespace RobloxAccountManager.Services;

/// <summary>Protects optional local secrets with Windows DPAPI. Session cookies and tokens are never accepted.</summary>
public sealed class SecureStorageService
{
    public byte[] Protect(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return ProtectedData.Protect(Encoding.UTF8.GetBytes(value), null, DataProtectionScope.CurrentUser);
    }

    public string Unprotect(byte[] protectedValue)
    {
        ArgumentNullException.ThrowIfNull(protectedValue);
        return Encoding.UTF8.GetString(ProtectedData.Unprotect(protectedValue, null, DataProtectionScope.CurrentUser));
    }
}
