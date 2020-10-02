
using System;
using System.Collections.Generic;
using System.Linq;
using YH.VictoryTemp.Entity.CodeGenerator;
using FreeSql;
using YH.VictoryTemp.Entity.Model;

namespace YH.VictoryTemp.DataAccess.CodeGenerator
{

    /// <summary>
    ///  权限表
    ///</summary>
    public class Tright_Power_Da : FreeSql.BaseRepository<Tright_Power>
    {
        public Tright_Power_Da():base(DataAccess.DbContext.Db,null,null) { 
        
            
        }


        public List<Tright_Power> ListByOder() {

            return Select.ToTreeList();
        }
    }

}

