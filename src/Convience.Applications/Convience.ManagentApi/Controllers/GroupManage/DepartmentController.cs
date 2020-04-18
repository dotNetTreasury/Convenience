﻿using Convience.Fluentvalidation;
using Convience.ManagentApi.Infrastructure.Authorization;
using Convience.Model.Models.GroupManage;
using Convience.Service.GroupManage;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Convience.ManagentApi.Controllers.GroupManage
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Permission("departmentList")]
        public IActionResult Get()
        {
            return Ok(_departmentService.GetAllDepartment());
        }

        [HttpDelete]
        [Permission("departmentDelete")]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _departmentService.DeleteDepartmentAsync(id);
            if (!isSuccess)
            {
                return this.BadRequestResult("删除失败!");
            }
            return Ok();
        }

        [HttpPost]
        [Permission("departmentAdd")]
        public async Task<IActionResult> Add(DepartmentViewModel viewModel)
        {
            var isSuccess = await _departmentService.AddDepartmentAsync(viewModel);
            if (!isSuccess)
            {
                return this.BadRequestResult("添加失败!");
            }
            return Ok();
        }

        [HttpPatch]
        [Permission("departmentUpdate")]
        public async Task<IActionResult> Update(DepartmentViewModel viewModel)
        {
            var isSuccess = await _departmentService.UpdateDepartmentAsync(viewModel);
            if (!isSuccess)
            {
                return this.BadRequestResult("更新失败!");
            }
            return Ok();
        }
    }
}