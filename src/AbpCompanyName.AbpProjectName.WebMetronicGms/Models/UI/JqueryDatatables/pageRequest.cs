using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.WebMetronicGms.Models.UI.JqueryDatatables {
    public class PageRequest: IPagedResultRequest {

        public int Draw { get; set; }
        public IList<Column> Columns { get; set; }
        public IList<Order> Order { get; set; }

        public int Start { get; set; }
        public int Length { get; set; }

        public Search Search { get; set; }

        public int MaxResultCount { get { return this.Length; } set { Length = value; } }
        public int SkipCount { get { return this.Start*this.Length; } set { throw new ArgumentNullException("不能使用此方法"); } }
    }

    public class Column
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public Search Search { get; set; }
    }

    public class Search
    {
        public string Value { get; set; }
        public string Regex { get; set; }
    }

    public class Order
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }
}