﻿using System;
using System.Text;
using Util.Datas.Queries;
using Util.Datas.Queries.Criterias;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Datas.Queries.Criterias {
    /// <summary>
    /// 测试日期范围过滤条件 - 包含时间
    /// </summary>
    public class DateTimeSegmentCriteriaTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public DateTimeSegmentCriteriaTest() {
            _min = DateTime.Parse( "2000-1-1 10:10:10" );
            _max = DateTime.Parse( "2000-1-2 10:10:10" );
        }

        /// <summary>
        /// 最小日期
        /// </summary>
        private readonly DateTime? _min;
        /// <summary>
        /// 最大日期
        /// </summary>
        private readonly DateTime? _max;

        /// <summary>
        /// 测试获取查询条件
        /// </summary>
        [Fact]
        public void TestGetPredicate() {
            var result = new StringBuilder();
            result.AppendFormat( "t => ((t.DateValue >= {0})", DateTime.Parse( "2000/1/1 10:10:10" ) );
            result.AppendFormat( " AndAlso (t.DateValue <= {0}))", DateTime.Parse( "2000/1/2 10:10:10" ) );
            var criteria = new DateTimeSegmentCriteria<AggregateRootSample, DateTime>( t => t.DateValue, _min, _max );
            Assert.Equal( result.ToString(), criteria.GetPredicate().ToString() );

            result = new StringBuilder();
            result.AppendFormat( "t => ((t.NullableDateValue >= {0})", DateTime.Parse( "2000/1/1 10:10:10" ) );
            result.AppendFormat( " AndAlso (t.NullableDateValue <= {0}))", DateTime.Parse( "2000/1/2 10:10:10" ) );
            var criteria2 = new DateTimeSegmentCriteria<AggregateRootSample, DateTime?>( t => t.NullableDateValue, _min, _max );
            Assert.Equal( result.ToString(), criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 设置边界
        /// </summary>
        [Fact]
        public void TestGetPredicate_Boundary() {
            var result = new StringBuilder();
            result.AppendFormat( "t => ((t.DateValue > {0})", DateTime.Parse( "2000/1/1 10:10:10" ) );
            result.AppendFormat( " AndAlso (t.DateValue < {0}))", DateTime.Parse( "2000/1/2 10:10:10" ) );
            var criteria = new DateTimeSegmentCriteria<AggregateRootSample, DateTime>( t => t.DateValue, _min, _max, Boundary.Neither );
            Assert.Equal( result.ToString(), criteria.GetPredicate().ToString() );

            result = new StringBuilder();
            result.AppendFormat( "t => ((t.DateValue >= {0})", DateTime.Parse( "2000/1/1 10:10:10" ) );
            result.AppendFormat( " AndAlso (t.DateValue < {0}))", DateTime.Parse( "2000/1/2 10:10:10" ) );
            criteria = new DateTimeSegmentCriteria<AggregateRootSample, DateTime>( t => t.DateValue, _min, _max, Boundary.Left );
            Assert.Equal( result.ToString(), criteria.GetPredicate().ToString() );

            result = new StringBuilder();
            result.AppendFormat( "t => ((t.NullableDateValue > {0})", DateTime.Parse( "2000/1/1 10:10:10" ) );
            result.AppendFormat( " AndAlso (t.NullableDateValue <= {0}))", DateTime.Parse( "2000/1/2 10:10:10" ) );
            var criteria2 = new DateTimeSegmentCriteria<AggregateRootSample, DateTime?>( t => t.NullableDateValue, _min, _max,Boundary.Right );
            Assert.Equal( result.ToString(), criteria2.GetPredicate().ToString() );

            result = new StringBuilder();
            result.AppendFormat( "t => ((t.NullableDateValue >= {0})", DateTime.Parse( "2000/1/1 10:10:10" ) );
            result.AppendFormat( " AndAlso (t.NullableDateValue <= {0}))", DateTime.Parse( "2000/1/2 10:10:10" ) );
            criteria2 = new DateTimeSegmentCriteria<AggregateRootSample, DateTime?>( t => t.NullableDateValue, _min, _max, Boundary.Both );
            Assert.Equal( result.ToString(), criteria2.GetPredicate().ToString() );
        }
    }
}
