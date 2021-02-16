using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _ColorDal;
        public ColorManager(IColorDal colorDal)
        {
            _ColorDal = colorDal;
        }
        public void Add(Color color)
        {
            _ColorDal.Add(color);
        }

        public void Delete(Color color)
        {
            _ColorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _ColorDal.GetAll();
        }

        public Color GetByColorId(int colorId)
        {
            return _ColorDal.Get(c=>c.Id==colorId);
        }

        public void Update(Color color)
        {
            _ColorDal.Update(color);
        }
    }
}
