using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class MongodbHelper
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName">连接名</param>
        /// <returns></returns>
        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            //连接服务器
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            //指定数据库
            var database = client.GetDatabase("Monitor");
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName);
            return collection;
        }

        #region 查询方法

        /// <summary>
        ///     获取单个对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="id">objectId</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public T Get<T>(string id, string collectionName)
        {
            return GetAsync<T>(id, collectionName).Result;
        }

        /// <summary>
        ///     获取单个对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public T Get<T>(Expression<Func<T, bool>> expression, string collectionName)
        {
            return GetAsync(expression, collectionName).Result;
        }

        /// <summary>
        ///     获取单个对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public T Get<T>(FilterDefinition<T> filter, string collectionName)
        {
            return GetAsync(filter, collectionName).Result;
        }

        /// <summary>
        ///     获取单个对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public TNewProjection Get<T, TNewProjection>(Expression<Func<T, bool>> expression,
            Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            return GetAsync(expression, projection, collectionName).Result;
        }

        /// <summary>
        ///     获取单个对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">表名</param>
        /// <returns></returns>
        public TNewProjection Get<T, TNewProjection>(FilterDefinition<T> filter,
            Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            return GetAsync(filter, projection, collectionName).Result;
        }

        /// <summary>
        ///     异步获取单个对象
        /// </summary>
        /// <param name="id">objectId</param>
        /// <param name="collectionName">表名</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string id, string collectionName)
        {
            return await GetAsync<T>(new BsonDocument("_id", id), collectionName).ConfigureAwait(false);
        }

        /// <summary>
        ///     异步获取单个对象
        /// </summary>
        /// <param name="expression">筛选条件</param>
        /// <param name="collectionName">表名</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> expression, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.Find(expression).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     异步获取单个对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">表名称</param>
        /// <returns></returns>
        public async Task<TNewProjection> GetAsync<T, TNewProjection>(Expression<Func<T, bool>> expression,
            Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.Find(expression).Project(projection).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     异步获取单个对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">表名</param>
        /// <returns></returns>
        public async Task<TNewProjection> GetAsync<T, TNewProjection>(FilterDefinition<T> filter,
            Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.Find(filter).Project(projection).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<T> GetAsync<T>(FilterDefinition<T> filter, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     获取集合
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll<T>(string collectionName)
        {
            return GetAllAsync<T>(collectionName).Result;
        }

        /// <summary>
        ///     异步获取集合
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync<T>(string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.Find(new BsonDocument()).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     查询
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public List<T> Find<T>(Expression<Func<T, bool>> expression, string collectionName)
        {
            return FindAsync(expression, collectionName).Result;
        }

        /// <summary>
        ///     查询
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public List<TNewProjection> Find<T, TNewProjection>(Expression<Func<T, bool>> expression,
            Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            return FindAsync(expression, projection, collectionName).Result;
        }

        /// <summary>
        ///     查询
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public List<T> Find<T>(FilterDefinition<T> filter, string collectionName)
        {
            return FindAsync(filter, collectionName).Result;
        }

        /// <summary>
        ///     查询
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public List<TNewProjection> Find<T, TNewProjection>(FilterDefinition<T> filter,
            Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            return FindAsync(filter, projection, collectionName).Result;
        }

        /// <summary>
        ///     获取记录数
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public long Count<T>(string collectionName)
        {
            return CountAsync<T>(new BsonDocument(), collectionName).Result;
        }

        /// <summary>
        ///     获取记录数
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public long Count<T>(Expression<Func<T, bool>> expression, string collectionName)
        {
            return CountAsync(expression, collectionName).Result;
        }

        /// <summary>
        ///     获取记录数
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public long Count<T>(FilterDefinition<T> filter, string collectionName)
        {
            return CountAsync(filter, collectionName).Result;
        }

        /// <summary>
        ///     异步获取记录数
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<long> CountAsync<T>(Expression<Func<T, bool>> expression, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.CountAsync(expression).ConfigureAwait(false);
        }

        /// <summary>
        ///     异步获取记录数
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<long> CountAsync<T>(FilterDefinition<T> filter, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.CountAsync(filter).ConfigureAwait(false);
        }

        /// <summary>
        ///     获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public List<T> PageList<T>(int pageIndex, int pageSize, string collectionName)
        {
            return PageListAsync<T>(pageIndex, pageSize, collectionName).Result;
        }

        /// <summary>
        ///     获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public List<TNewProjection> PageList<T, TNewProjection>(int pageIndex, int pageSize,
            Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            return PageListAsync(pageIndex, pageSize, projection, collectionName).Result;
        }

        /// <summary>
        ///     获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="where">筛选条件</param>
        /// <param name="sort">排序条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public List<T> PageList<T>(int pageIndex, int pageSize, Expression<Func<T, bool>> where,
            SortDefinition<T> sort, string collectionName)
        {
            return PageListAsync(pageIndex, pageSize, where, sort, collectionName).Result;
        }

        /// <summary>
        ///     获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="where">筛选条件</param>
        /// <param name="sort">排序条件</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public List<TNewProjection> PageList<T, TNewProjection>(int pageIndex, int pageSize,
            Expression<Func<T, bool>> where, SortDefinition<T> sort, Expression<Func<T, TNewProjection>> projection,
            string collectionName)
        {
            return PageListAsync(pageIndex, pageSize, where, sort, projection, collectionName).Result;
        }

        /// <summary>
        ///     获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="filter">筛选条件</param>
        /// <param name="sort">排序条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public List<T> PageList<T>(int pageIndex, int pageSize, FilterDefinition<T> filter,
            SortDefinition<T> sort, string collectionName)
        {
            return PageListAsync(pageIndex, pageSize, filter, sort, collectionName).Result;
        }

        /// <summary>
        ///     获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="filter">过滤器</param>
        /// <param name="sort">排序条件</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public List<TNewProjection> PageList<T, TNewProjection>(int pageIndex, int pageSize,
            FilterDefinition<T> filter,
            SortDefinition<T> sort, Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            return PageListAsync(pageIndex, pageSize, filter, sort, projection, collectionName).Result;
        }

        /// <summary>
        ///     异步获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<List<T>> PageListAsync<T>(int pageIndex, int pageSize, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return
                await
                    collection.Find(new BsonDocument())
                        .Skip((pageIndex - 1) * pageSize)
                        .Limit(pageSize)
                        .ToListAsync()
                        .ConfigureAwait(false);
        }

        /// <summary>
        ///     异步获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<List<TNewProjection>> PageListAsync<T, TNewProjection>(int pageIndex, int pageSize,
            Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return
                await
                    collection.Find(new BsonDocument())
                        .Project(projection)
                        .Skip((pageIndex - 1) * pageSize)
                        .Limit(pageSize)
                        .ToListAsync()
                        .ConfigureAwait(false);
        }

        public async Task<List<T>> PageListAsync<T>(int pageIndex, int pageSize, FilterDefinition<T> filter,
            SortDefinition<T> sort, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return
                await
                    collection.Find(filter)
                        .Sort(sort)
                        .Skip((pageIndex - 1) * pageSize)
                        .Limit(pageSize)
                        .ToListAsync()
                        .ConfigureAwait(false);
        }

        /// <summary>
        ///     异步获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="filter">过滤器</param>
        /// <param name="sort">排序条件</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<List<TNewProjection>> PageListAsync<T, TNewProjection>(int pageIndex, int pageSize,
            FilterDefinition<T> filter, SortDefinition<T> sort, Expression<Func<T, TNewProjection>> projection,
            string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return
                await
                    collection.Find(filter)
                        .Project(projection)
                        .Sort(sort)
                        .Skip((pageIndex - 1) * pageSize)
                        .Limit(pageSize)
                        .ToListAsync()
                        .ConfigureAwait(false);
        }

        /// <summary>
        ///     异步获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="where">筛选条件</param>
        /// <param name="sort">排序条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<List<T>> PageListAsync<T>(int pageIndex, int pageSize, Expression<Func<T, bool>> where,
            SortDefinition<T> sort, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return
                await
                    collection.Find(where)
                        .Sort(sort)
                        .Skip((pageIndex - 1) * pageSize)
                        .Limit(pageSize)
                        .ToListAsync()
                        .ConfigureAwait(false);
        }

        /// <summary>
        ///     异步获取分页数据
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="pageIndex">页次</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="where">筛选条件</param>
        /// <param name="sort">排序条件</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<List<TNewProjection>> PageListAsync<T, TNewProjection>(int pageIndex, int pageSize,
            Expression<Func<T, bool>> where, SortDefinition<T> sort, Expression<Func<T, TNewProjection>> projection,
            string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return
                await
                    collection.Find(where)
                        .Project(projection)
                        .Sort(sort)
                        .Skip((pageIndex - 1) * pageSize)
                        .Limit(pageSize)
                        .ToListAsync()
                        .ConfigureAwait(false);
        }

        /// <summary>
        ///     异步查询
        /// </summary>
        /// <param name="expression">筛选条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<List<T>> FindAsync<T>(Expression<Func<T, bool>> expression,
            string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.Find(expression).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     异步查询
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="expression">查询条件</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<List<TNewProjection>> FindAsync<T, TNewProjection>(
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.Find(expression).Project(projection).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     异步查询
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<List<T>> FindAsync<T>(FilterDefinition<T> filter, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.Find(filter).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     异步查询
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <typeparam name="TNewProjection">新实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="projection">新实体映射</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<List<TNewProjection>> FindAsync<T, TNewProjection>(FilterDefinition<T> filter,
            Expression<Func<T, TNewProjection>> projection, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.Find(filter).Project(projection).ToListAsync().ConfigureAwait(false);
        }

        #endregion

        #region 插入方法

        /// <summary>
        ///     插入
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="value">对象</param>
        /// <param name="collectionName">集合名称</param>
        public void Insert<T>(T value, string collectionName)
        {
            InsertAsync(value, collectionName).Wait();
        }

        /// <summary>
        ///     异步插入
        /// </summary>
        /// <param name="value">对象</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task InsertAsync<T>(T value, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            await collection.InsertOneAsync(value).ConfigureAwait(false);
        }

        /// <summary>
        ///     批量插入
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="values">对象集合</param>
        /// <param name="collectionName">集合名称</param>
        public void BatchInsert<T>(IEnumerable<T> values, string collectionName)
        {
            BatchInsertAsync(values, collectionName).Wait();
        }

        /// <summary>
        ///     异步批量插入
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="values">对象集合</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task BatchInsertAsync<T>(IEnumerable<T> values, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            await collection.InsertManyAsync(values).ConfigureAwait(false);
        }

        #endregion

        #region 更新方法

        /// <summary>
        ///     覆盖更新
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="value">对象</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public ReplaceOneResult Update<T>(T value, string collectionName)
        {
            return UpdateAsync(value, collectionName).Result;
        }

        /// <summary>
        ///     局部更新
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="id">记录ID</param>
        /// <param name="update">更新条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public UpdateResult Update<T>(ObjectId id, UpdateDefinition<T> update, string collectionName)
        {
            return UpdateAsync(new BsonDocument("_id", id), update, collectionName).Result;
        }

        /// <summary>
        ///     局部更新
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="update">更新条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public UpdateResult Update<T>(Expression<Func<T, bool>> expression, UpdateDefinition<T> update,
            string collectionName)
        {
            return UpdateAsync(expression, update, collectionName).Result;
        }
        /// <summary>
        ///     局部更新
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="update">更新条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public UpdateResult UpdateMany<T>(Expression<Func<T, bool>> expression, UpdateDefinition<T> update,
            string collectionName)
        {
            return UpdateManyAsync(expression, update, collectionName).Result;
        }

        public UpdateResult Update<T>(FilterDefinition<T> expression, UpdateDefinition<T> update,
            string collectionName)
        {
            return UpdateAsync(expression, update, collectionName).Result;
        }

        /// <summary>
        ///     异步局部更新（仅更新一条记录）
        ///     <para><![CDATA[expression 参数示例：x => x.Id == 1 && x.Age > 18 && x.Gender == 0]]></para>
        ///     <para><![CDATA[entity 参数示例：y => new T{ RealName = "Ray", Gender = 1}]]></para>
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="entity">更新条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public UpdateResult Update<T>(Expression<Func<T, bool>> expression, Expression<Action<T>> entity,
            string collectionName)
        {
            return UpdateAsync(expression, entity, collectionName).Result;
        }

        /// <summary>
        ///     异步局部更新（仅更新一条记录）
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="update">更新条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<UpdateResult> UpdateAsync<T>(FilterDefinition<T> filter, UpdateDefinition<T> update,
            string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.UpdateOneAsync(filter, update).ConfigureAwait(false);
        }

        /// <summary>
        ///     异步局部更新（仅更新一条记录）
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="update">更新条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<UpdateResult> UpdateAsync<T>(Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.UpdateOneAsync(expression, update).ConfigureAwait(false);
        }
        /// <summary>
        /// 异步局部更新（仅更新多条记录）
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="update">更新条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<UpdateResult> UpdateManyAsync<T>(Expression<Func<T, bool>> expression,
            UpdateDefinition<T> update, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.UpdateManyAsync(expression, update).ConfigureAwait(false);
        }

        /// <summary>
        ///     异步局部更新（仅更新一条记录）
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="entity">更新条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<UpdateResult> UpdateAsync<T>(Expression<Func<T, bool>> expression,
            Expression<Action<T>> entity, string collectionName)
        {
            var fieldList = new List<UpdateDefinition<T>>();

            var param = entity.Body as MemberInitExpression;
            if (param != null)
            {
                foreach (var item in param.Bindings)
                {
                    var propertyName = item.Member.Name;
                    object propertyValue = null;
                    var memberAssignment = item as MemberAssignment;
                    if (memberAssignment == null) continue;
                    if (memberAssignment.Expression.NodeType == ExpressionType.Constant)
                    {
                        var constantExpression = memberAssignment.Expression as ConstantExpression;
                        if (constantExpression != null)
                            propertyValue = constantExpression.Value;
                    }
                    else
                    {
                        propertyValue = Expression.Lambda(memberAssignment.Expression, null).Compile().DynamicInvoke();
                    }

                    if (propertyName != "_id") //实体键_id不允许更新
                    {
                        fieldList.Add(Builders<T>.Update.Set(propertyName, propertyValue));
                    }
                }
            }
            var collection = GetCollection<T>(collectionName);
            return
                await collection.UpdateOneAsync(expression, Builders<T>.Update.Combine(fieldList)).ConfigureAwait(false);
        }



        /// <summary>
        ///     异步覆盖更新
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="value">对象</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<ReplaceOneResult> UpdateAsync<T>(T value, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await
                collection.ReplaceOneAsync(
                    new BsonDocument("_id", new ObjectId(typeof(T).GetProperty("Id").GetValue(value).ToString())),
                    value).ConfigureAwait(false);
        }

        #endregion

        #region 删除方法

        /// <summary>
        ///     删除指定对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="id">对象Id</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public DeleteResult Delete<T>(ObjectId id, string collectionName)
        {
            return DeleteAsync<T>(id, collectionName).Result;
        }

        /// <summary>
        ///     删除指定对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">查询条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public DeleteResult Delete<T>(Expression<Func<T, bool>> expression, string collectionName)
        {
            return DeleteAsync(expression, collectionName).Result;
        }

        /// <summary>
        ///     异步删除指定对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="id">对象Id</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<DeleteResult> DeleteAsync<T>(ObjectId id, string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.DeleteOneAsync(new BsonDocument("_id", id)).ConfigureAwait(false);
        }

        /// <summary>
        ///     异步删除指定对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">查询条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<DeleteResult> DeleteAsync<T>(Expression<Func<T, bool>> expression,
            string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.DeleteOneAsync(expression).ConfigureAwait(false);
        }

        /// <summary>
        ///     批量删除对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="ids">ID集合</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public DeleteResult BatchDelete<T>(IEnumerable<ObjectId> ids, string collectionName)
        {
            return BatchDeleteAsync<T>(ids, collectionName).Result;
        }

        /// <summary>
        ///     批量删除对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public DeleteResult BatchDelete<T>(FilterDefinition<T> filter, string collectionName)
        {
            return BatchDeleteAsync(filter, collectionName).Result;
        }

        /// <summary>
        ///     批量删除对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public DeleteResult BatchDelete<T>(Expression<Func<T, bool>> expression, string collectionName)
        {
            return BatchDeleteAsync(expression, collectionName).Result;
        }

        /// <summary>
        ///     异步批量删除对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="ids">ID集合</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<DeleteResult> BatchDeleteAsync<T>(IEnumerable<ObjectId> ids,
            string collectionName)
        {
            var filter = Builders<T>.Filter.In("_id", ids);
            var collection = GetCollection<T>(collectionName);
            return await collection.DeleteManyAsync(filter).ConfigureAwait(false);
        }

        /// <summary>
        ///     异步批量删除对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="filter">过滤器</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<DeleteResult> BatchDeleteAsync<T>(FilterDefinition<T> filter,
            string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.DeleteManyAsync(filter).ConfigureAwait(false);
        }

        /// <summary>
        ///     异步批量删除对象
        /// </summary>
        /// <typeparam name="T">数据库实体类型</typeparam>
        /// <param name="expression">筛选条件</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public async Task<DeleteResult> BatchDeleteAsync<T>(Expression<Func<T, bool>> expression,
            string collectionName)
        {
            var collection = GetCollection<T>(collectionName);
            return await collection.DeleteManyAsync(expression).ConfigureAwait(false);
        }

        #endregion

    }
}
