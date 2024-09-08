// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace DataView_UMS.Data
{
    /// <summary>
    ///
    /// </summary>
    public class Ros
    {
        // 列头信息支持 Display DisplayName 两种标签

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "主键")]
        [AutoGenerateColumn(Ignore = true)]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "{0}不能为空")]
        [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = true)]
        [Display(Name = "操作台ID")]
        public int RosID { get; set; }
        /// <summary>
        ///
        /// </summary>
        [Required(ErrorMessage = "{0}不能为空")]
        [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = true)]
        [Display(Name = "操作台名称")]
        public string RosName { get; set; }
        [Required(ErrorMessage = "{0}不能为空")]
        [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = true)]
        [Display(Name = "操作台类型")]
        public string RosTypeName { get; set; }
        

        ///// <summary>
        /////
        ///// </summary>
        //[Required(ErrorMessage = "请选择一种{0}")]
        //[Display(Name = "爱好")]
        //[AutoGenerateColumn(Order = 70)]
         public IEnumerable<string> Hobby { get; set; } = new List<string>();

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localizer"></param>
        /// <returns></returns>
        public static Ros Generate(IStringLocalizer<Foo> localizer) => new()
        {
            //Id = 1,
            //Name = localizer["Foo.Name", "1000"],
            //DateTime = DateTime.Now,
            //Address = localizer["Foo.Address", $"{random.Next(1000, 2000)}"],
            //Count = random.Next(1, 100),
            //Complete = random.Next(1, 100) > 50,
            //Education = random.Next(1, 100) > 50 ? EnumEducation.Primary : EnumEducation.Middel
        };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Ros> GenerateRos(IStringLocalizer<Foo> localizer, int count = 80) => Enumerable.Range(1, count).Select(i => new Ros()
        {
            Id = i,
        }).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectedItem> GenerateHobbys(IStringLocalizer<Foo> localizer) => localizer["Hobbys"].Value.Split(",").Select(i => new SelectedItem(i, i)).ToList();
    }

    /// <summary>
    ///
    /// </summary>
    //public enum EnumEducation
    //{
    //    /// <summary>
    //    ///
    //    /// </summary>
    //    [Display(Name = "小学")]
    //    Primary,

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    [Display(Name = "中学")]
    //    Middel
    //}
}
