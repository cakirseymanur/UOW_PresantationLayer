using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW_BusinessLayer.Abstract;
using UOW_DataAccessLayer.Abstract;
using UOW_DataAccessLayer.UnitOfWork;
using UOW_EntityLayer.Concrete;

namespace UOW_BusinessLayer.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUowDal _uowDal;

        public AccountManager(IAccountDal accountDal, IUowDal uowDal)
        {
            _accountDal = accountDal;
            _uowDal = uowDal;
        }

        public void TDelete(Account t)
        {
            _accountDal.Delete(t);
            _uowDal.Save();
        }

        public Account TGetById(int id)
        {
            return _accountDal.GetById(id);
        }

        public List<Account> TGetList()
        {
            return _accountDal.GetList();
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _uowDal.Save();
            
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _uowDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _uowDal.Save();
        }
    }
}
