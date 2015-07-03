using Windows.Security.Cryptography.Core;

namespace WinPhone.MyShows.Helpers
{
    using Windows.Security.Cryptography;

    public static class MD5Helper
    {
        /// <summary>
        /// Gets MD5 hash.
        /// </summary>
        /// <param name="str">
        /// The string.
        /// </param>
        /// <returns>
        /// The hash.
        /// </returns>
        static public string GetMd5Hash(string str)
        {
            var hashProvider = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            var hash = hashProvider.HashData(CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8));
            return CryptographicBuffer.EncodeToHexString(hash);
        }
    }
}
