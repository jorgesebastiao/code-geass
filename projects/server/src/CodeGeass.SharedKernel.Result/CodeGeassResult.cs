namespace CodeGeass.SharedKernel.Result
{
    using static Helpers;

    /// <see cref="https://achraf-chennan.medium.com/using-the-result-class-in-c-519da90351f0"/>
    /// <see cref="https://enterprisecraftsmanship.com/posts/functional-c-handling-failures-input-errors/"/>
    /// <see cref="https://elemarjr.com/arquivo/exceptions-are-too-intrusive/"/>
    /// <see cref="https://elemarjr.com/arquivo/when-null-is-not-good-enough/"/>
    /// <see cref="https://achraf-chennan.medium.com/using-the-result-class-in-c-519da90351f0"/>
    public class CodeGeassResult
    {
        public Exception Failure { get; protected set; }

        public bool IsSuccess => Failure is null;

        public bool IsFailure => Failure is not null;

        protected CodeGeassResult() { }


        protected CodeGeassResult(Exception failure)
        {
            Failure = failure;
        }

        public static CodeGeassResult Ok()
        {
            return new CodeGeassResult();
        }
        public static CodeGeassResult<TSuccess> Ok<TSuccess>(TSuccess result)
        {
            return new CodeGeassResult<TSuccess>(result);
        }

        public static CodeGeassResult Fail(Exception failure)
        {
            return new CodeGeassResult(failure);
        }

        public static CodeGeassResult<TSuccess> Fail<TSuccess>(Exception failure)
        {
            return new CodeGeassResult<TSuccess>(failure);
        }
    }

    public class CodeGeassResult<TSuccess> : CodeGeassResult
    {
        public TSuccess Success { get; protected set; }

        protected internal CodeGeassResult(TSuccess success)
        {
            Success = success;
        }

        protected internal CodeGeassResult(Exception failure)
        {
            Failure = failure;
        }

        public TResult Match<TResult>(
        Func<Exception, TResult> failure,
        Func<TSuccess, TResult> success) => IsFailure ? failure(Failure) : success(Success);

        public Unit Match(
                Action<Exception> failure,
                Action<TSuccess> success) => Match(ToFunc(failure), ToFunc(success));

        public static implicit operator CodeGeassResult<TSuccess>(TSuccess success) => new CodeGeassResult<TSuccess>(success);

        public static implicit operator CodeGeassResult<TSuccess>(Exception failure) => new CodeGeassResult<TSuccess>(failure);

        public static CodeGeassResult<TSuccess> Of(TSuccess obj) => obj;

        public static CodeGeassResult<TSuccess> Of(Exception obj) => obj;

    }

    public struct Unit
    {
        public static Unit Successful { get { return new Unit(); } }
    }

    public static partial class Helpers
    {
        private static readonly Unit unit = new Unit();

        public static Unit Unit() => unit;

        public static Func<T, Unit> ToFunc<T>(Action<T> action) => o =>
        {
            action(o);
            return Unit();
        };

        public static Func<Unit> ToFunc(Action action) => () =>
        {
            action();
            return Unit();
        };
    }
}
