﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Victory.Core.Controller;
using Victory.Core.Models;
using YH.VictoryTemp.DataAccess.CodeGenerator;
using YH.VictoryTemp.Entity.Enums;
using YH.VictoryTemp.WebApp.Attribute;

namespace YH.VictoryTemp.WebApp.Controllers
{
    [Authorize]
    public class SysLogController : TopControllerBase
    {
        [Right(PowerName = "系统日志")]
        public IActionResult Index()
        {
            return View();
        }




        [Right(PowerName = "查询")]
        [HttpPost]
        public IActionResult List(string keyword,int keytype, int pageIndex, int pageSize)
        {

            PageModel page = new PageModel();
            page.PageIndex = pageIndex;
            page.PageSize = pageSize;


            Tsys_Log_Da da = new Tsys_Log_Da();
            var list = da.ListByWhere(keyword, (SysLogType)keytype, ref page);


            return SuccessResultList(list, page);



        }


    }
}
