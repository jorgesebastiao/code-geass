using CodeGeass.SharedKernel.Result;

namespace CodeGeass.Application.Common
{
    public class Output
    {
        public CodeGeassResult Result { get; private set; }

        public Output()
        {
        }

        public void AddResult<TOutput>(CodeGeassResult<TOutput> result)
        {
            Result = result;
        }

        public void AddResult(CodeGeassResult result)
        {
            Result = result;
        }

        public void AddFailure(CodeGeassResult failure)
        {
            Result = failure;
        }
    }
}