using System;

namespace CastExtensions.OldExtensions
{
    public static class GenericExtensions
    {
        public static TOut MapToType<TIn, TOut>(this TIn @object, Func<TIn, TOut> mappingFunc)
        {
            return mappingFunc(@object);
        }
    }
}
