using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inception.Application.Interfaces;
using Inception.Application.ViewModels;
using Inception.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Inception.Web.Controllers
{
    public class InceptionsController : BaseController<InceptionsController>
    {
        private readonly IInceptionsAppService _inceptionsAppService;

        public InceptionsController(IInceptionsAppService inceptionsAppService, ILogger<InceptionsController> logger) : base(logger)
        {
            this._inceptionsAppService = inceptionsAppService;
        }

        [HttpGet]
        public IActionResult NovaInception()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovaInception(InceptionsViewModel inceptionsViewModel)
        {
            if (ModelState.IsValid)
            {
                await _inceptionsAppService.InsertedInceptionsAsync(inceptionsViewModel);
            }

            return RedirectToAction("Resumo", inceptionsViewModel.Id);
        }

        [HttpGet]
        [Route("Inceptions/Resumo/{id}")]
        public async Task<IActionResult> Resumo(long id)
        {
            var inceptionsViewModel = await _inceptionsAppService.GetInception(id);
            return View(inceptionsViewModel);
        }
    }
}