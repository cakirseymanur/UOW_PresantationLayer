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
    public class ProcessDetailManager : IProcessDetailService
    {
        private readonly IProcessDetailDal _processDetail;
        private readonly IUowDal _uowDal;

        public ProcessDetailManager(IProcessDetailDal processDetail, IUowDal uowDal)
        {
            _processDetail = processDetail;
            _uowDal = uowDal;
        }

        public void TDelete(ProcessDetail t)
        {
            _processDetail.Delete(t);
            _uowDal.Save();
        }

        public ProcessDetail TGetById(int id)
        {
            return _processDetail.GetById(id);
        }

        public List<ProcessDetail> TGetList()
        {
            return _processDetail.GetList();
        }

        public void TInsert(ProcessDetail t)
        {
            _processDetail.Insert(t);
            _uowDal.Save();
        }

        public void TMultiUpdate(List<ProcessDetail> t)
        {
            _processDetail.MultiUpdate(t);
            _uowDal.Save();
        }

        public void TUpdate(ProcessDetail t)
        {
            _processDetail.Update(t);
            _uowDal.Save();
        }
    }
}
