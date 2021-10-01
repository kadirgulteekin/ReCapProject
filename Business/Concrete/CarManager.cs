using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;  //Veritabanı bağımlılığımı azaltmak için Constructur Injection ile yapıyorum.
        //IBrandDal _brandDal;

        //public CarManager(IBrandDal brandDal)
        //{
        //    _brandDal = brandDal; //Ben CarManager olarak veri erişim katmanına bağlımlıyım ama biraz az bağımlılığım var.
        //    //Ben Interface üzerinden bağımlıyım o yüzden sen DataAccess katmanında istediğini yapabilirsin.
            
        //}

        //IColorDal _colorDal;

        //public CarManager(IColorDal colorDal)
        //{
        //    _colorDal = colorDal;
        //}

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
                _carDal.Add(car);
            else
                Console.WriteLine("Araba ismi en az 2 karakter olmalıdır ve günlük fiyat 0'dan büyük olmalıdır");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByUnitPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
