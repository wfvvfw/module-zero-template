using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.WebMetronicGms.Models.UI.JqueryDatatables {
    public class DataResult<T> {

        public DataResult(IReadOnlyList<T> result, PageRequest request)
        {
            Draw = request.Draw;
            RecordsTotal = result.Count();
            RecordsFiltered = request.SkipCount;

            Data = result;
            TotalCount = result.Count;
        }

        public int Draw { get; private set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }


        public IReadOnlyList<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}