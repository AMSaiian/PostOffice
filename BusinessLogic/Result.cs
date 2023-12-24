namespace BusinessLogic
{
    public class Result<TResult> where TResult : class
    {
        public bool IsSuccess { get; set; } = true;

        public TResult? Value { get; set; }

        public List<string> Errors { get; set; } = new();
    }
}
