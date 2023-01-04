using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UOW_BusinessLayer.Abstract;
using UOW_EntityLayer.Concrete;
using UOW_PresantationLayer.Models;

namespace UOW_PresantationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IProcessDetailService _processDetailService;

        public AccountController(IAccountService accountService, IProcessDetailService processDetailService)
        {
            _accountService = accountService;
            _processDetailService = processDetailService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.accountList = _accountService.TGetList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            ViewBag.accountList = _accountService.TGetList();

            var value1 = _accountService.TGetById(model.SenderID);
            var value2 = _accountService.TGetById(model.ReceiverID);

            value1.AccountBalance -= model.Amount;
            value2.AccountBalance += model.Amount;

            List<Account> modifiedAccounts = new List<Account>()
            {
                value1,
                value2
            };

            ProcessDetail processDetail = new ProcessDetail();

            processDetail.SenderName = value1.AccountName;
            processDetail.RecieverName = value2.AccountName;
            processDetail.Amount = model.Amount;
            processDetail.ProcessDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            _processDetailService.TInsert(processDetail);

            _accountService.TMultiUpdate(modifiedAccounts);

            return RedirectToAction("ProcessDetailIndex");
        }
        public IActionResult ProcessDetailIndex()
        {
            var values = _processDetailService.TGetList();
            return View(values);
        }
    }
}
