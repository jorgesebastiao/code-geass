namespace CodeGeass.SharedKernel.Extensions
{
    /// <summary>
    ///  Classe estática que implementa extensões para manipulação de Guids
    /// </summary>
    public static class GuidExtensions
    {
        public static bool IsNullOrEmpty(this Guid? value) => value is null || value == Guid.Empty;
        public static bool IsMissing(this Guid? value) => value.IsNullOrEmpty();
        public static bool IsPresent(this Guid? value) => !value.IsNullOrEmpty();
        public static bool IsNullOrEmpty(this Guid value) => value.IsNullOrEmpty();
        public static bool IsMissing(this Guid value) => value.IsNullOrEmpty();
        public static bool IsPresent(this Guid value) => !value.IsNullOrEmpty();
    }
}
