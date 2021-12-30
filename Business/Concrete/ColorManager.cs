using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _ColorDal;

        private readonly IMapper _mapper;
        public ColorManager(IColorDal colorDal,IMapper mapper)
        {
            _ColorDal = colorDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);
            _ColorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(int id)
        {
            _ColorDal.Delete(GetByColorId(id).Data);
            return new SuccessResult(Messages.ColorDeleted);
        }
        public IResult Update(UpdateColorModel model)
        {
            var mappedColor = _mapper.Map<Color>(model);
            _ColorDal.Update(mappedColor);
            return new SuccessResult(Messages.ColorUpdated);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _ColorDal.GetAll(),Messages.ColorsListed);

        }

        public  IDataResult<Color> GetByColorId(int colorId)
        {
            return new SuccessDataResult<Color>( _ColorDal.Get(c=>c.Id==colorId),Messages.ColorListed);

        }

        
    }
}
