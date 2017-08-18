using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace  Wjw1.Infrastructure
{

    /// <summary>
    /// 企业数据查询类型
    /// </summary>
    public enum EnterpriseDataType
    {
        /// <summary>
        /// 查看本公司及下级子公司数据，超级管理员能查看所有数据
        /// </summary>
        CurrentAndSubs = 100,
        /// <summary>
        /// 只能查看本级公司数据
        /// </summary>
        CurrentOnly = 200,
        /// <summary>
        /// 查看所属总公司的所有数据 ，前六位编码一致
        /// </summary>
        All = 300
    }
    /// <summary>
    /// 删除数据查询类型
    /// </summary>
    public enum DeletedDataType
    {
        /// <summary>
        /// 未删除的数据
        /// </summary>
        UnDeletedOnly = 100,
        /// <summary>
        /// 已删除的数据
        /// </summary>
        DeletedOnly = 200,
        /// <summary>
        /// 全部数据
        /// </summary>
        All = 300
    }
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Save(object id, T entity);

        /// <summary>
        /// 按照单主键删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="remove">物理删除标记 默认false</param>
        void Delete(object id, bool remove = false);

        /// <summary>
        /// 按照单个实体删除数据
        /// </summary>
        /// <param name="item"></param>
        /// <param name="remove">物理删除标记 默认false</param>
        void Delete(T item, bool remove = false);

        /// <summary>
        /// 按照条件批量删除数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="remove">物理删除标记 默认false</param>
        void Delete(Expression<Func<T, bool>> where, bool remove = false);

        /// <summary>
        /// 跟住单个主键获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);


        /// <summary>
        /// 获取指定范围的所有数据
        /// </summary>
        /// <param name="deletedDataType">删除数据范围</param>
        /// <param name="enterpriseDataType">企业数据范围</param>
        /// <returns></returns>
        IQueryable<T> GetAll(DeletedDataType deletedDataType = DeletedDataType.UnDeletedOnly, EnterpriseDataType enterpriseDataType = EnterpriseDataType.CurrentAndSubs);

        /// <summary>
        /// 获取指定条件的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="deletedDataType">删除数据范围</param>
        /// <param name="enterpriseDataType">企业数据范围</param>
        /// <returns></returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> where, DeletedDataType deletedDataType = DeletedDataType.UnDeletedOnly, EnterpriseDataType enterpriseDataType = EnterpriseDataType.CurrentAndSubs);

        Task<int> CommitAsync();

    }


    //public interface IUnitOfWork
    //{
    //    Task<int> CommitAsync();
    //}
}
