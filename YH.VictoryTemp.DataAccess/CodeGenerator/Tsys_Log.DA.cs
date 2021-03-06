using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Victory.Core.Extensions;
using Victory.Core.Models;
using YH.VictoryTemp.DataAccess;
using YH.VictoryTemp.Entity.CodeGenerator;
using YH.VictoryTemp.Entity.Enums;

namespace YH.VictoryTemp.DataAccess.CodeGenerator
{

    /// <summary>
    ///  系统日志表
    ///</summary>
    public class Tsys_Log_Da : FreeSql.BaseRepository<Tsys_Log>
    {
        public Tsys_Log_Da() : base(DbContext.Db, null, null)
        {


        }


        public List<Tsys_Log> ListByWhere(string keyword, SysLogType type,ref PageModel page)
        {

            var data = this.Select;

            if (!string.IsNullOrEmpty(keyword))
            {
                data= data.Where(s => s.Content.Contains(keyword));
            }

            if (type!= SysLogType.全部)
            {
                data = data.Where(s => s.Type== type.ToInt64());
            }

            page.TotalCount = data.Count().ToInt();

            var list = data.Page(page.PageIndex, page.PageSize)
                .OrderBy(s => s.Createtime)
                .ToList();

            return list;
        }

    }

}

