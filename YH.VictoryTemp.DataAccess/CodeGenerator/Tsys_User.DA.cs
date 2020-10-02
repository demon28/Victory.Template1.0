using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Victory.Core.Extensions;
using Victory.Core.Models;
using YH.VictoryTemp.DataAccess;
using YH.VictoryTemp.Entity.CodeGenerator;
using YH.VictoryTemp.Entity.Enums;
using YH.VictoryTemp.Entity.Model;
using YH.VictoryTemp.Entity.Tool;

namespace YH.VictoryTemp.DataAccess.CodeGenerator
{

    /// <summary>
    ///  
    ///</summary>
    public class Tsys_User_Da : FreeSql.BaseRepository<Tsys_User>
    {

        public Tsys_User_Da() : base(DataAccess.DbContext.Db, null, null)
        {

        }


        public List<Tsys_User> ListByWhere(string keyword, ref PageModel page) 
        {
            var data =this.Select;
            List<Tsys_User> list;
            if(!string.IsNullOrEmpty(keyword))
            {
                data= data.Where(s => s.Name.Contains(keyword) || s.Workid.Contains(keyword) );
            }
            if (page.PageIndex == 0)
            {
                 list = data.OrderBy(s => s.Comedate)
                .ToList();

            }
            else
            { 
                page.TotalCount = data.Count().ToInt();
                list = data.Page(page.PageIndex, page.PageSize)
                .OrderBy(s => s.Comedate)
                .ToList();
            }
           
            return list;
        }

    }

}

