using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        private int hour = 04;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<Color>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), ColorMessages.ColorsListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<Color>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id), ColorMessages.ColorsListed);
        }

        public IResult AddService(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult(ColorMessages.ColorAdded);
        }

        public IResult UpdateService(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(ColorMessages.ColorUpdated);
        }

        public IResult DeleteService(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult(ColorMessages.ColorDeleted);
        }
    }
}
