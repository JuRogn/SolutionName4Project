namespace  Wjw1.Infrastructure
{
    /// <summary>
    /// 数据字典接口
    /// </summary>
    public interface IUserDictionary
    {
        string Id { get; set; }
        string Name { get; set; }
        string SystemId { get; set; }
        bool Enable { get; set; }
        bool Selected { get; set; }
    }
}
