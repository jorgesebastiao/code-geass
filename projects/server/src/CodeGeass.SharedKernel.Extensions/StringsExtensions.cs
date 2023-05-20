
namespace CodeGeass.SharedKernel.Extensions
{
    /// <summary>
    ///  Classe de extensão para manipulação de strings
    /// </summary>
    public static class StringsExtensions
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        public static bool IsMissing(this string value) => string.IsNullOrEmpty(value);

        public static bool IsPresent(this string value) => !string.IsNullOrWhiteSpace(value);
    }
}
