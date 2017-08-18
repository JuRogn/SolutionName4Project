using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace  Wjw1.Infrastructure
{
    /// <summary>
    /// 数据库操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class Repository<T> :IRepository<T> where T : class 
    {
        private readonly ApplicationDbContext _dataContext;
        private readonly DbSet<T> _dbset;
        private readonly IUserInfo _userInfo;
        
        public Repository(ApplicationDbContext dbContext, IUserInfo userInfo)
        {
            _dataContext = dbContext;
            _userInfo = userInfo;
            _dbset = _dataContext.Set<T>();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体对象</param>
        public virtual void Add(T entity)
        {
            var dbSetBase = entity as IDbSetBase;

            if (dbSetBase != null)
            {
                dbSetBase.CreatedBy = _userInfo.UserId;
                dbSetBase.CreatedDate = DateTime.Now.ToDateString();
                dbSetBase.CreatedTime = DateTime.Now.ToTimeString();

                entity = dbSetBase as T;
            }

            var ienterprise = entity as IEnterprise;

            if (ienterprise != null)
            {
                ienterprise.EnterpriseId = _userInfo.EnterpriseId;
                entity = ienterprise as T;
            }
            if (entity != null) _dbset.Add(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体对象</param>
        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);

            var dbSetBase = entity as IDbSetBase;

            if (dbSetBase != null)
            {
                var databaseValues = _dataContext.Entry(dbSetBase).GetDatabaseValues();

                dbSetBase.CreatedBy = databaseValues.GetValue<string>("CreatedBy");
                dbSetBase.CreatedDate = databaseValues.GetValue<string>("CreatedDate");
                dbSetBase.CreatedTime = databaseValues.GetValue<string>("CreatedTime");

                dbSetBase.UpdatedDate = DateTime.Now.ToDateTimeString();
                dbSetBase.UpdatedBy = _userInfo.UserId;

                entity = dbSetBase as T;
            }

            var ienterprise = entity as IEnterprise;

            if (ienterprise != null)
            {
                var databaseValues = _dataContext.Entry(ienterprise).GetDatabaseValues();

                var entId = databaseValues.GetValue<string>("EnterpriseId");

                if (!string.IsNullOrEmpty(entId))
                {
                    if (entId == _userInfo.EnterpriseId)
                    {
                        ienterprise.EnterpriseId = entId;
                    }
                    else
                    {
                        throw new Exception();
                    }

                    entity = ienterprise as T;
                }
            }

            if (entity != null) _dataContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 添加或者更新
        /// </summary>
        /// <param name="id">实体主键ID</param>
        /// <param name="entity">实体</param>
        public virtual void Save(object id, T entity)
        {
            if (id != null)
            {
                Update(entity);
            }
            else
            {
                Add(entity);
            }
        }

        /// <summary>
        ///  删除
        /// </summary>
        /// <param name="id">实体对象Id</param>
        /// <param name="remove">物理删除标记 默认false</param>
        public virtual void Delete(object id, bool remove = false)
        {
            var item = GetById(id);
            Delete(item, remove);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="item">删除实体对象</param>
        /// <param name="remove">物理删除标记 默认false</param>
        public virtual void Delete(T item, bool remove = false)
        {
            var dbSetBase = item as IDbSetBase;

            var iEnterprise = item as IEnterprise;

            if (iEnterprise?.EnterpriseId == _userInfo.EnterpriseId || iEnterprise == null)//有权操作
            {
                if (!remove && dbSetBase != null)//标记删除
                    dbSetBase.Deleted = true;
                else
                    _dbset.Remove(item);
            }

        }

        /// <summary>
        ///  删除
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="remove">物理删除标记 默认false</param>
        public virtual void Delete(Expression<Func<T, bool>> where, bool remove = false)
        {
            foreach (var item in GetAll(where))
            {
                Delete(item, remove);
            }
        }

        /// <summary>
        /// 获取单个记录 默认可获取下级子公司数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(object id)
        {
            if (id == null) return null;

            var item = _dbset.FindAsync(id).Result;

            // var item = _dbset.Find(id);

            var iEnterprise = item as IEnterprise;

            if (iEnterprise != null && !iEnterprise.EnterpriseId.StartsWith(_userInfo.EnterpriseId)) return null;

            return item;
        }

        /// <summary>
        /// 获取指定条件的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="deletedDataType">删除数据范围</param>
        /// <param name="enterpriseDataType">企业数据范围</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> where, DeletedDataType deletedDataType = DeletedDataType.UnDeletedOnly, EnterpriseDataType enterpriseDataType = EnterpriseDataType.CurrentAndSubs)
        {
            return GetAll(deletedDataType,enterpriseDataType).Where(where);
        }

        /// <summary>
        /// 获取指定范围的所有数据
        /// </summary>
        /// <param name="deletedDataType">删除数据范围</param>
        /// <param name="enterpriseDataType">企业数据范围</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(DeletedDataType deletedDataType = DeletedDataType.UnDeletedOnly, EnterpriseDataType enterpriseDataType = EnterpriseDataType.CurrentAndSubs)
        {
            var model = _dbset as IQueryable<T>;

            if (typeof(IEnterprise).IsAssignableFrom(typeof(T)))
            {
                switch (enterpriseDataType) {
                    case EnterpriseDataType.CurrentOnly:
                        model = model.Where("EnterpriseId=\"" + _userInfo.EnterpriseId + "\"");
                        break;
                    case EnterpriseDataType.CurrentAndSubs:
                        model = model.Where("EnterpriseId.StartsWith(\"" + _userInfo.EnterpriseId + "\")");
                        break;
                    default:
                        model = model.Where("EnterpriseId.StartsWith(\"100\")");
                        break;
                }
            }

            if (typeof(IDbSetBase).IsAssignableFrom(typeof(T)))
            {
                switch (deletedDataType)
                {
                    case DeletedDataType.UnDeletedOnly:
                        model = model.Where("Deleted=false");
                        break;
                    case DeletedDataType.DeletedOnly:
                        model = model.Where("Deleted=true");
                        break;
                    default:
                        break;
                }

                model = model.OrderBy("CreatedDate desc, CreatedTime desc");
            }

            if (typeof(IUserDictionary).IsAssignableFrom(typeof(T)))
            {
                model = model.OrderBy("SystemId");
            }

            return model;
        }

        /// <summary>
        /// 提交修改
        /// </summary>
        /// <returns></returns>
        public Task<int> CommitAsync()
        {
            return _dataContext.CommitAsync();
        }
    }
}
