namespace CodeGeass.SharedKernel.Result
{
    using static Helpers;

    public static partial class CodeGeassResultExtension
    {

        public static CodeGeassResult<TSuccess> Run<TSuccess>(this Func<TSuccess> func)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public async static Task<CodeGeassResult<TSuccess>> Run<TSuccess>(this Func<Task<TSuccess>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static CodeGeassResult<Unit> Run(this Action action) => ToFunc(action).Run();
        public static CodeGeassResult<TSuccess> Run<TSuccess>(this Exception ex) => ex;
        public static CodeGeassResult<IQueryable<TSuccess>> AsResult<TSuccess>(this IEnumerable<TSuccess> source) => Run(() => source.AsQueryable());
    }
}
