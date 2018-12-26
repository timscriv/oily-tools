using Paginator.Exceptions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Paginator.Cursors
{
    public interface ICursor<T, TMetadata, TOptions> where TOptions : ICursorOptions
    {
        IPagingResult<T, TMetadata> ApplyCursor(IQueryable<T> query, TOptions options);
    }

    public interface ICursorOptions
    {
        int Limit { get; }
    }

    public class KeyCursorOptions<TEntity, TKey> : ICursorOptions
    {
        public int Limit { get; } = 100;

        public Func<TEntity, TKey> KeySelector { get; }

        public Expression<Func<TEntity, bool>> KeyEvaluator { get; }

        public KeyCursorOptions(
            Expression<Func<TEntity, bool>> keyEvaluator,
            Func<TEntity, TKey> keySelector,
            int limit = 100)
        {
            if (keyEvaluator == null || keySelector == null) throw new ArgumentException("KeyEvaluator and KeySelector must be set.");

            Limit = limit;
            KeySelector = keySelector;
            KeyEvaluator = keyEvaluator;
        }
    }

    public class OffsetCursorOptions : ICursorOptions
    {
        public int Limit => 100;
    }

    public class KeyCursor<TEntity, TKey> : ICursor<TEntity, CursorPagingMetadata, KeyCursorOptions<TEntity, TKey>>
    {
        private const string CursorType = "key";

        public TKey Key { get; set; }

        public KeyCursor(string encodedCursor)
        {
            if (string.IsNullOrEmpty(encodedCursor)) return;

            var decodedBytes = Convert.FromBase64String(encodedCursor);
            var cursorString = Encoding.UTF8.GetString(decodedBytes);

            if (!cursorString.Contains($"{CursorType}:")) return;

            var cursorParts = cursorString.Split(':');
            try
            {
                Key = (TKey)Convert.ChangeType(cursorParts.Last(), typeof(TKey));
            }
            catch (Exception)
            {
                throw new InvalidCursorException();
            }
        }

        public KeyCursor(TKey key)
        {
            Key = key;
        }

        public IPagingResult<TEntity, CursorPagingMetadata> ApplyCursor(
            IQueryable<TEntity> query,
             KeyCursorOptions<TEntity, TKey> options)
        {
            var data = query
                .Where(options.KeyEvaluator)
                .Take(options.Limit)
                .ToList()
                .AsReadOnly();

            Key = options.KeySelector(data.LastOrDefault());
            //TODO: implement totalCount
            var metadata = new CursorPagingMetadata(data.Count, 0, options.Limit, this.Stringify());

            return new PagedResult<TEntity, CursorPagingMetadata>(data, metadata);
        }

        public string Stringify()
        {
            if (Key == null) return "";

            var bytes = Encoding.UTF8.GetBytes($"{CursorType}:{Key}");
            return Convert.ToBase64String(bytes);
        }
    }

    public class OffsetCursor<TEntity> : ICursor<TEntity, CursorPagingMetadata, OffsetCursorOptions>
    {
        private const string CursorType = "offset";
        public int Offset { get; set; }

        public OffsetCursor(string encodedCursor)
        {
            if (string.IsNullOrEmpty(encodedCursor)) return;

            var decodedBytes = Convert.FromBase64String(encodedCursor);
            var cursorString = Encoding.UTF8.GetString(decodedBytes);

            if (!cursorString.Contains($"{CursorType}:")) return;

            var cursorParts = cursorString.Split(':');

            if (!int.TryParse(cursorParts.Last(), out int offset)) return;

            Offset = offset;
        }

        public OffsetCursor(int offset)
        {
            Offset = offset;
        }

        public IPagingResult<TEntity, CursorPagingMetadata> ApplyCursor(IQueryable<TEntity> query, OffsetCursorOptions options)
        {
            var data = query
                .Skip(Offset)
                .Take(options.Limit)
                .ToList()
                .AsReadOnly();

            var nextCursor = new OffsetCursor<TEntity>(Offset + data.Count);

            //TODO: implement totalCount
            var metadata = new CursorPagingMetadata(data.Count, 0, options.Limit, nextCursor.Stringify());

            return new PagedResult<TEntity, CursorPagingMetadata>(data, metadata);
        }

        public string Stringify()
        {
            var bytes = Encoding.UTF8.GetBytes($"{CursorType}:{Offset}");
            return Convert.ToBase64String(bytes);
        }
    }
}
