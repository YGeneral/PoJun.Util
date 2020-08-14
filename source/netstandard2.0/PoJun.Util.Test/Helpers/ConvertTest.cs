﻿using System;
using PoJun.Util.Tests.Samples;
using Xunit;

namespace PoJun.Util.Tests.Helpers {
    /// <summary>
    /// 类型转换测试
    /// </summary>
    public class ConvertTest {
        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, 0 )]
        [InlineData( "", 0 )]
        [InlineData( "1A", 0 )]
        [InlineData( "0", 0 )]
        [InlineData( "1", 1 )]
        [InlineData( "1778019.78", 1778020 )]
        [InlineData( "1778019.7801684", 1778020 )]
        public void TestToInt( object input, int result ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToInt( input ) );
        }

        /// <summary>
        /// 转换为可空整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, null )]
        [InlineData( "", null )]
        [InlineData( "1A", null )]
        [InlineData( "0", 0 )]
        [InlineData( "1", 1 )]
        [InlineData( "1778019.78", 1778020 )]
        [InlineData( "1778019.7801684", 1778020 )]
        public void TestToIntOrNull( object input, int? result ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToIntOrNull( input ) );
        }

        /// <summary>
        /// 转换为64位整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, 0 )]
        [InlineData( "", 0 )]
        [InlineData( "1A", 0 )]
        [InlineData( "0", 0 )]
        [InlineData( "1", 1 )]
        [InlineData( "1778019.7801684", 1778020 )]
        [InlineData( "177801978016841234", 177801978016841234 )]
        public void TestToLong( object input, long result ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToLong( input ) );
        }

        /// <summary>
        /// 转换为64位可空整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, null )]
        [InlineData( "", null )]
        [InlineData( "1A", null )]
        [InlineData( "0", 0L )]
        [InlineData( "1", 1L )]
        [InlineData( "1778019.7801684", 1778020L )]
        [InlineData( "177801978016841234", 177801978016841234L )]
        public void TestToLongOrNull( object input, long? result ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToLongOrNull( input ) );
        }

        /// <summary>
        /// 转换为32位浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, 0, null )]
        [InlineData( "", 0, null )]
        [InlineData( "1A", 0, null )]
        [InlineData( "0", 0, null )]
        [InlineData( "1", 1, null )]
        [InlineData( "1.2", 1.2, null )]
        [InlineData( "12.346", 12.35, 2 )]
        public void TestToFloat( object input, float result, int? digits ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToFloat( input, digits ) );
        }

        /// <summary>
        /// 转换为32位可空浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, null, null )]
        [InlineData( "", null, null )]
        [InlineData( "1A", null, null )]
        [InlineData( "0", 0f, null )]
        [InlineData( "1", 1f, null )]
        [InlineData( "1.2", 1.2f, null )]
        [InlineData( "12.346", 12.35f, 2 )]
        public void TestToFloatOrNull( object input, float? result, int? digits ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToFloatOrNull( input, digits ) );
        }

        /// <summary>
        /// 转换为64位浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, 0, null )]
        [InlineData( "", 0, null )]
        [InlineData( "1A", 0, null )]
        [InlineData( "0", 0, null )]
        [InlineData( "1", 1, null )]
        [InlineData( "1.2", 1.2, null )]
        [InlineData( "12.235", 12.24, 2 )]
        [InlineData( "12.345", 12.34, 2 )]
        [InlineData( "12.3451", 12.35, 2 )]
        [InlineData( "12.346", 12.35, 2 )]
        public void TestToDouble( object input, double result, int? digits ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToDouble( input, digits ) );
        }

        /// <summary>
        /// 转换为64位可空浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, null, null )]
        [InlineData( "", null, null )]
        [InlineData( "1A", null, null )]
        [InlineData( "0", 0d, null )]
        [InlineData( "1", 1d, null )]
        [InlineData( "1.2", 1.2, null )]
        [InlineData( "12.355", 12.36, 2 )]
        public void TestToDoubleOrNull( object input, double? result, int? digits ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToDoubleOrNull( input, digits ) );
        }

        /// <summary>
        /// 转换为128位浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, 0, null )]
        [InlineData( "", 0, null )]
        [InlineData( "1A", 0, null )]
        [InlineData( "0", 0, null )]
        [InlineData( "1", 1, null )]
        [InlineData( "1.2", 1.2, null )]
        [InlineData( "12.235", 12.24, 2 )]
        [InlineData( "12.345", 12.34, 2 )]
        [InlineData( "12.3451", 12.35, 2 )]
        [InlineData( "12.346", 12.35, 2 )]
        public void TestToDecimal( object input, decimal result, int? digits ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToDecimal( input, digits ) );
        }

        /// <summary>
        /// 转换为128位可空浮点型，验证
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, null, null )]
        [InlineData( "", null, null )]
        [InlineData( "1A", null, null )]
        [InlineData( "1A", null, 2 )]
        public void TestToDecimalOrNull_Validate( object input, decimal? result, int? digits ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToDecimalOrNull( input, digits ) );
        }

        /// <summary>
        /// 转换为128位可空浮点型，输入值为"0"
        /// </summary>
        [Fact]
        public void TestToDecimalOrNull() {
            Assert.Equal( 0M, PoJun.Util.Helpers.Convert.ToDecimalOrNull( "0" ) );
            Assert.Equal( 1.2M, PoJun.Util.Helpers.Convert.ToDecimalOrNull( "1.2" ) );
            Assert.Equal( 23.46M, PoJun.Util.Helpers.Convert.ToDecimalOrNull( "23.456", 2 ) );
        }

        /// <summary>
        /// 转换为布尔型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, false )]
        [InlineData( "", false )]
        [InlineData( "1A", false )]
        [InlineData( "0", false )]
        [InlineData( "否", false )]
        [InlineData( "不", false )]
        [InlineData( "no", false )]
        [InlineData( "No", false )]
        [InlineData( "false", false )]
        [InlineData( "fail", false )]
        [InlineData( "1", true )]
        [InlineData( "是", true )]
        [InlineData( "yes", true )]
        [InlineData( "true", true )]
        [InlineData( "ok", true )]
        public void TestToBool( object input, bool result ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToBool( input ) );
        }

        /// <summary>
        /// 转换为可空布尔型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, null )]
        [InlineData( "", null )]
        [InlineData( "1A", null )]
        [InlineData( "0", false )]
        [InlineData( "否", false )]
        [InlineData( "不", false )]
        [InlineData( "no", false )]
        [InlineData( "No", false )]
        [InlineData( "false", false )]
        [InlineData( "fail", false )]
        [InlineData( "1", true )]
        [InlineData( "是", true )]
        [InlineData( "yes", true )]
        [InlineData( "true", true )]
        [InlineData( "ok", true )]
        public void TestToBoolOrNull( object input, bool? result ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToBoolOrNull( input ) );
        }

        /// <summary>
        /// 转换为日期，验证
        /// </summary>
        [Fact]
        public void TestToDate_Validate() {
            Assert.Equal( DateTime.MinValue, PoJun.Util.Helpers.Convert.ToDate( null ) );
            Assert.Equal( DateTime.MinValue, PoJun.Util.Helpers.Convert.ToDate( "" ) );
            Assert.Equal( DateTime.MinValue, PoJun.Util.Helpers.Convert.ToDate( "1A" ) );
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        [Fact]
        public void TestToDate() {
            Assert.Equal( new DateTime( 2000, 1, 1 ), PoJun.Util.Helpers.Convert.ToDate( "2000-1-1" ) );
        }

        /// <summary>
        /// 转换为可空日期，验证
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, null )]
        [InlineData( "", null )]
        [InlineData( "1A", null )]
        public void TestToDateOrNull_Validate( object input, DateTime? result ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToDateOrNull( input ) );
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        [Fact]
        public void TestToDateOrNull() {
            Assert.Equal( new DateTime( 2000, 1, 1 ), PoJun.Util.Helpers.Convert.ToDateOrNull( "2000-1-1" ) );
        }

        /// <summary>
        /// 转换为Guid，验证
        /// </summary>
        [Fact]
        public void TestToGuid_Validate() {
            Assert.Equal( Guid.Empty, PoJun.Util.Helpers.Convert.ToGuid( null ) );
            Assert.Equal( Guid.Empty, PoJun.Util.Helpers.Convert.ToGuid( "" ) );
            Assert.Equal( Guid.Empty, PoJun.Util.Helpers.Convert.ToGuid( "1A" ) );
        }

        /// <summary>
        /// 转换为Guid
        /// </summary>
        [Fact]
        public void TestToGuid() {
            Assert.Equal( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ), PoJun.Util.Helpers.Convert.ToGuid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
        }

        /// <summary>
        /// 转换为可空Guid，验证
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, null )]
        [InlineData( "", null )]
        [InlineData( "1A", null )]
        public void TestToGuidOrNull_Validate( object input, Guid? result ) {
            Assert.Equal( result, PoJun.Util.Helpers.Convert.ToGuidOrNull( input ) );
        }

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        [Fact]
        public void TestToGuidOrNull() {
            Assert.Equal( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ), PoJun.Util.Helpers.Convert.ToGuidOrNull( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        [Fact]
        public void TestToGuidList() {
            //Assert.Equal( 0, PoJun.Util.Helpers.Convert.ToGuidList( null ).Count );
            //Assert.Equal( 0, PoJun.Util.Helpers.Convert.ToGuidList( "" ).Count );

            const string guid = "83B0233C-A24F-49FD-8083-1337209EBC9A";
            //Assert.Equal( 1, PoJun.Util.Helpers.Convert.ToGuidList( guid ).Count );
            Assert.Equal( new Guid( guid ), PoJun.Util.Helpers.Convert.ToGuidList( guid )[0] );

            const string guid2 = "83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A";
            Assert.Equal( 2, PoJun.Util.Helpers.Convert.ToGuidList( guid2 ).Count );
            Assert.Equal( new Guid( "83B0233C-A24F-49FD-8083-1337209EBC9A" ), PoJun.Util.Helpers.Convert.ToGuidList( guid2 )[0] );
            Assert.Equal( new Guid( "EAB523C6-2FE7-47BE-89D5-C6D440C3033A" ), PoJun.Util.Helpers.Convert.ToGuidList( guid2 )[1] );
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        [Fact]
        public void TestToGuidList_2() {
            const string guid = "83B0233C-A24F-49FD-8083-1337209EBC9A,,EAB523C6-2FE7-47BE-89D5-C6D440C3033A,";
            Assert.Equal( 2, PoJun.Util.Helpers.Convert.ToGuidList( guid ).Count );
            Assert.Equal( new Guid( "83B0233C-A24F-49FD-8083-1337209EBC9A" ), PoJun.Util.Helpers.Convert.ToGuidList( guid )[0] );
            Assert.Equal( new Guid( "EAB523C6-2FE7-47BE-89D5-C6D440C3033A" ), PoJun.Util.Helpers.Convert.ToGuidList( guid )[1] );
        }

        /// <summary>
        /// 泛型集合转换
        /// </summary>
        [Fact]
        public void TestToList() {
            Assert.Empty( PoJun.Util.Helpers.Convert.ToList<string>( null ));
            Assert.Single( PoJun.Util.Helpers.Convert.ToList<string>( "1" ));
            Assert.Equal( 2, PoJun.Util.Helpers.Convert.ToList<string>( "1,2" ).Count );
            Assert.Equal( 2, PoJun.Util.Helpers.Convert.ToList<int>( "1,2" )[1] );
        }

        /// <summary>
        /// 通用泛型转换
        /// </summary>
        [Fact]
        public void TestTo() {
            Assert.Null( PoJun.Util.Helpers.Convert.To<string>( "" ) );
            Assert.Equal( "1A", PoJun.Util.Helpers.Convert.To<string>( "1A" ) );
            Assert.Equal( 0, PoJun.Util.Helpers.Convert.To<int>( null ) );
            Assert.Equal( 0, PoJun.Util.Helpers.Convert.To<int>( "" ) );
            Assert.Equal( 0, PoJun.Util.Helpers.Convert.To<int>( "2A" ) );
            Assert.Equal( 1, PoJun.Util.Helpers.Convert.To<int>( "1" ) );
            Assert.Null( PoJun.Util.Helpers.Convert.To<int?>( null ) );
            Assert.Null( PoJun.Util.Helpers.Convert.To<int?>( "" ) );
            Assert.Null( PoJun.Util.Helpers.Convert.To<int?>( "3A" ) );
            Assert.Equal( Guid.Empty, PoJun.Util.Helpers.Convert.To<Guid>( "" ) );
            Assert.Equal( Guid.Empty, PoJun.Util.Helpers.Convert.To<Guid>( "4A" ) );
            Assert.Equal( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ), PoJun.Util.Helpers.Convert.To<Guid>( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
            Assert.Equal( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ), PoJun.Util.Helpers.Convert.To<Guid?>( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
            Assert.Equal( 12.5, PoJun.Util.Helpers.Convert.To<double>( "12.5" ) );
            Assert.Equal( 12.5, PoJun.Util.Helpers.Convert.To<double?>( "12.5" ) );
            Assert.Equal( 12.5M, PoJun.Util.Helpers.Convert.To<decimal>( "12.5" ) );
            Assert.True( PoJun.Util.Helpers.Convert.To<bool>( "true" ) );
            Assert.Equal( new DateTime( 2000, 1, 1 ), PoJun.Util.Helpers.Convert.To<DateTime>( "2000-1-1" ) );
            Assert.Equal( new DateTime( 2000, 1, 1 ), PoJun.Util.Helpers.Convert.To<DateTime?>( "2000-1-1" ) );
            var guid = Guid.NewGuid();
            Assert.Equal( guid.ToString(), PoJun.Util.Helpers.Convert.To<string>( guid ) );
            Assert.Equal( EnumSample.C, PoJun.Util.Helpers.Convert.To<EnumSample>( "c" ) );
        }

        /// <summary>
        /// 枚举转字典集合
        /// </summary>
        [Fact]
        public void TestEnumToDic()
        {
            var dic = PoJun.Util.Helpers.Convert.EnumToDic<EnumSample>(null);
        }        
    }
}