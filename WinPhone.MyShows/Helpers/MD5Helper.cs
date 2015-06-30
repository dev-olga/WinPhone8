using Windows.Security.Cryptography.Core;

namespace WinPhone.MyShows.Helpers
{
    using Windows.Security.Cryptography;

    internal static class MD5Helper
    {
        static string GetMd5Hash(string str)
        {
            var hashProvider = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            var hash = hashProvider.HashData(CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8));
            return hash.ToString();
        }
    }
}
