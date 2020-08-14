using System;
using System.Collections.Generic;
using System.Text;

namespace PoJun.Util.Test
{
    /// <summary>
    /// 发布大后台配置[参数]
    /// 创建人：杨江军
    /// 创建时间：2020/5/26 17:38:56
    /// </summary>
    public class PublishBigBackstageConfigParam
    {
        /// <summary>
        /// 大后台每次推送消息队列的唯一ID
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 访视信息集合
        /// </summary>
        public List<VisitEntity> Visits { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime ReleaseTime { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public PublishBigBackstageConfigParam()
        {
           Visits = new List<VisitEntity>();
        }
    }

    /// <summary>
    /// 访视信息
    /// 创建人：杨江军
    /// 创建时间：2020/6/1 14:54:47
    /// </summary>
    public class VisitEntity
    {
        /// <summary>
        /// 访视Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 访视名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 访视类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 访视类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 模块信息集合
        /// </summary>
        public List<ModuleEntity> Modules { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public VisitEntity()
        {
            Modules = new List<ModuleEntity>();
        }
    }

    /// <summary>
	/// 模块信息
	/// 创建人：杨江军
	/// 创建时间：2020/6/1 14:55:33
	/// </summary>
	public class ModuleEntity
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 页面渲染JSON
        /// </summary>
  
        public string HtmlJson { get; set; }

        /// <summary>
        /// 特殊配置JSON
        /// </summary>

        public string SpecialJson { get; set; }

        /// <summary>
        /// 保存提交数据结构的JSON
        /// </summary>

        public string ResultJson { get; set; }
    }


    /// <summary>
    /// 发布大后台配置[参数]
    /// 创建人：杨江军
    /// 创建时间：2020/5/26 17:38:56
    /// </summary>
    public class BigBackstageConfig
    {
        /// <summary>
        /// 大后台每次推送消息队列的唯一ID
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 访视信息集合
        /// </summary>
        public List<Visit> Visits { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime ReleaseTime { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public BigBackstageConfig()
        {
            //Visits = new List<Visit>();
        }
    }

    /// <summary>
    /// 访视信息
    /// 创建人：杨江军
    /// 创建时间：2020/6/1 14:54:47
    /// </summary>
    public class Visit
    {
        /// <summary>
        /// 访视Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 访视名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 访视类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 访视类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 模块信息集合
        /// </summary>
        public List<Module> Modules { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Visit()
        {
            //Modules = new List<Module>();
        }
    }

    /// <summary>
	/// 模块信息
	/// 创建人：杨江军
	/// 创建时间：2020/6/1 14:55:33
	/// </summary>
	public class Module
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 页面渲染JSON
        /// </summary>

        public string HtmlJson { get; set; }

        /// <summary>
        /// 特殊配置JSON
        /// </summary>

        public string SpecialJson { get; set; }

        /// <summary>
        /// 保存提交数据结构的JSON
        /// </summary>

        public string ResultJson { get; set; }
    }
}
