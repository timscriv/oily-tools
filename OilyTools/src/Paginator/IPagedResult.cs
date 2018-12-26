using System.Collections;
using System.Collections.Generic;

namespace Paginator
{
    public interface IPagingRequest<TRequest>
    {
        TRequest Value { get; }
    }

    public class PagingRequest<TRequest>: IPagingRequest<TRequest>
    {
        public TRequest Value { get; }

        public PagingRequest(TRequest value)
        {
            Value = value;
        }
    }

    public interface IPagingResult<T, TMetadata> : IReadOnlyList<T>
    {
        TMetadata Metadata { get; }
    }

    public class OffsetPagingRequest
    {
        public int Offset { get; }
        public int Limit { get; }

        public OffsetPagingRequest(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }
    }

    public class CursorPagingRequest
    {
        public string Cursor { get; }
        public int Limit { get; }

        public CursorPagingRequest(string cursor, int limit)
        {
            Cursor = cursor;
            Limit = limit;
        }
    }

    public class PagedResult<T, TMetadata> : IPagingResult<T, TMetadata>
    {
        private IReadOnlyList<T> Data { get; }
        public TMetadata Metadata { get; }

        public T this[int index] => Data[index];
        public int Count => Data.Count;

        public PagedResult(IReadOnlyList<T> data, TMetadata metadata)
        {
            Data = data;
            Metadata = metadata;
        }

        public IEnumerator<T> GetEnumerator() => Data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class OffsetPagingMetadata
    {
        public int Count { get; }
        public int Total { get; }
        public int Limit { get; }
        public int Offset { get; }

        public OffsetPagingMetadata(int count, int total, int limit, int offset)
        {
            Count = count;
            Total = total;
            Limit = limit;
            Offset = offset;
        }
    }

    public class CursorPagingMetadata
    {
        public int Count { get; }
        public int Total { get; }
        public int Limit { get; }
        public string NextCursor { get; }

        public CursorPagingMetadata(int count, int total, int limit, string nextCursor = null)
        {
            Count = count;
            Total = total;
            Limit = limit;
            NextCursor = nextCursor;
        }
    }
}
