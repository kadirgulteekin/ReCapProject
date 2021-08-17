using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarContext context = new CarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarContext context = new CarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (CarContext context = new CarContext())
            {
                return context.Set<Color>().SingleOrDefault(filter); //Benim Product tablomu döndürecek.
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList() //Filtre null ise bu çalışır
                    : context.Set<Color>().Where(filter).ToList(); //Filtre varsa bu çalışır.
            }
        }

        public void Update(Color entity)
        {
            using (CarContext context = new CarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }        
    }   
}
