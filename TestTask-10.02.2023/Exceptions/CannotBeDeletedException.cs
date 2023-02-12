namespace TestTask_10._02._2023.Exceptions
{
    public class CannotBeDeletedAggregateException : AggregateException
    {
        public CannotBeDeletedAggregateException(IEnumerable<Exception> exceptions) : base(innerExceptions: exceptions)
        {
        }
    }

    public class CannotBeDeletedException : Exception
    {
        public CannotBeDeletedException(string message) : base(message)
        {
        }
    }
}
