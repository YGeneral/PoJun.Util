using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PoJun.Util.Helpers;
using PoJun.Util.Maps;
using PoJun.Util.Test;
using PoJun.Util.Tests.Samples;
using Xunit;

namespace PoJun.Util.Tests.Maps
{
    /// <summary>
    /// 对象映射测试
    /// </summary>
    public class MapTest
    {

        /// <summary>
        /// 测试映射
        /// </summary>
        [Fact]
        public void TestMapTo2()
        {
            var param = new PublishBigBackstageConfigParam();
            param.UniqueId = Guid.NewGuid().ToString("N");
            param.ProjectId = Guid.NewGuid().ToString("N");
            param.RoleId = Guid.NewGuid().ToString("N");
            param.ReleaseTime = DateTime.Now;
            param.Visits = new System.Collections.Generic.List<VisitEntity>();
            param.Visits.Add(new VisitEntity() { Id = Guid.NewGuid().ToString("N"), Name = "访视名称", Sort = 1, Type = 2, TypeName = "随意", Modules = new System.Collections.Generic.List<ModuleEntity>() { new ModuleEntity() { Id = Guid.NewGuid().ToString("N"), HtmlJson = Newtonsoft.Json.JsonConvert.SerializeObject(new PublishBigBackstageConfigParam() { ProjectId = Guid.NewGuid().ToString("N") }), ResultJson = Newtonsoft.Json.JsonConvert.SerializeObject(new PublishBigBackstageConfigParam() { ProjectId = Guid.NewGuid().ToString("N") }), Sort = 1, Name = "这是啥", SpecialJson = Newtonsoft.Json.JsonConvert.SerializeObject(new PublishBigBackstageConfigParam() { ProjectId = Guid.NewGuid().ToString("N") }) } } });
            param.Visits.Add(new VisitEntity() { Id = Guid.NewGuid().ToString("N"), Name = "访视名称", Sort = 1, Type = 2, TypeName = "随意", Modules = new System.Collections.Generic.List<ModuleEntity>() { new ModuleEntity() { Id = Guid.NewGuid().ToString("N"), HtmlJson = Newtonsoft.Json.JsonConvert.SerializeObject(new PublishBigBackstageConfigParam() { ProjectId = Guid.NewGuid().ToString("N") }), ResultJson = Newtonsoft.Json.JsonConvert.SerializeObject(new PublishBigBackstageConfigParam() { ProjectId = Guid.NewGuid().ToString("N") }), Sort = 1, Name = "这是啥", SpecialJson = Newtonsoft.Json.JsonConvert.SerializeObject(new PublishBigBackstageConfigParam() { ProjectId = Guid.NewGuid().ToString("N") }) } } });

            var entity = param.MapTo<BigBackstageConfig>();


            //var config = new MapperConfiguration(cfg => cfg.CreateMap<PublishBigBackstageConfigParam, BigBackstageConfig>());
            //var mapper = config.CreateMapper();
            //var userDTO = mapper.Map<BigBackstageConfig>(param);



            Sample2 sample2 = new Sample2 { StringValue = "a" };
            var sample = sample2.MapTo<Sample>();
            Assert.Equal("a", sample.StringValue);
        }

        /// <summary>
        /// 测试映射
        /// </summary>
        [Fact]
        public void TestMapTo()
        {
            Sample2 sample2 = new Sample2 { StringValue = "a" };
            var sample = sample2.MapTo<Sample>();
            Assert.Equal("a", sample.StringValue);
        }

        /// <summary>
        /// 测试映射
        /// </summary>
        [Fact]
        public void TestMapTo_2()
        {
            Sample sample = new Sample { StringValue = "a" };
            Sample2 sample2 = sample.MapTo<Sample2>();
            Assert.Equal("a", sample2.StringValue);
        }

        /// <summary>
        /// 测试映射集合
        /// </summary>
        [Fact]
        public void TestMapTo_List()
        {
            List<Sample> sampleList = new List<Sample> { new Sample { StringValue = "a" }, new Sample { StringValue = "b" } };
            var sample2List = sampleList.MapTo<List<Sample2>>();
            Assert.Equal(2, sample2List.Count);
            Assert.Equal("a", sample2List[0].StringValue);
        }

        /// <summary>
        /// 测试映射集合
        /// </summary>
        [Fact]
        public void TestMapTo_List_2()
        {
            List<Sample> sampleList = new List<Sample> { new Sample { StringValue = "a" }, new Sample { StringValue = "b" } };
            List<Sample2> sample2List = sampleList.MapTo<List<Sample2>>();
            Assert.Equal(2, sample2List.Count);
            Assert.Equal("a", sample2List[0].StringValue);
        }

        /// <summary>
        /// 测试映射集合
        /// </summary>
        [Fact]
        public void TestMapToList()
        {
            List<Sample> sampleList = new List<Sample> { new Sample { StringValue = "a" }, new Sample { StringValue = "b" } };
            List<Sample2> sample2List = sampleList.MapToList<Sample2>();
            Assert.Equal(2, sample2List.Count);
            Assert.Equal("a", sample2List[0].StringValue);
        }

        /// <summary>
        /// 映射集合 - 测试空集合
        /// </summary>
        [Fact]
        public void TestMapToList_Empty()
        {
            List<Sample> sampleList = new List<Sample>();
            List<Sample2> sample2List = sampleList.MapToList<Sample2>();
            Assert.Empty(sample2List);
        }

        /// <summary>
        /// 映射集合 - 测试数组
        /// </summary>
        [Fact]
        public void TestMapToList_Array()
        {
            Sample[] sampleList = new Sample[] { new Sample { StringValue = "a" }, new Sample { StringValue = "b" } };
            List<Sample2> sample2List = sampleList.MapToList<Sample2>();
            Assert.Equal(2, sample2List.Count);
            Assert.Equal("a", sample2List[0].StringValue);
        }

        /// <summary>
        /// 并发测试
        /// </summary>
        [Fact]
        public void TestMapTo_MultipleThread()
        {
            Thread.WaitAll(() =>
            {
                var sample = new Sample { StringValue = "a" };
                var sample2 = sample.MapTo<Sample2>();
                Assert.Equal("a", sample2.StringValue);
            }
            //,() => {
            //    var sample = new DtoSample { Name = "a" };
            //    var sample2 = sample.MapTo<EntitySample>();
            //    Assert.Equal( "a", sample2.Name );}
            , () =>
            {
                var sample = new Sample2 { StringValue = "a" };
                var sample2 = sample.MapTo<Sample>();
                Assert.Equal("a", sample2.StringValue);
            }
            //, () => {
            //    var sample = new EntitySample{ Name = "a" };
            //    var sample2 = sample.MapTo<DtoSample>();
            //    Assert.Equal( "a", sample2.Name );
            //} 
            );
        }
    }
}
