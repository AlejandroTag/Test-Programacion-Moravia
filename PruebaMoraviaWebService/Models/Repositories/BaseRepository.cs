using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PruebaMoraviaWebService.Models.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {

        public List<T> GetAll()
        {
            using (AppDbContext context = new AppDbContext())
            {
                return (List<T>)context.Set<T>().ToList();
            }
        }

        public List<T> GetAll(List<Expression<Func<T, object>>> includes)
        {
            List<string> includelist = new List<string>();

            foreach (var item in includes)
            {
                MemberExpression body = item.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("The body must be a member expression");

                includelist.Add(body.Member.Name);
            }

            using (AppDbContext context = new AppDbContext())
            {
                DbQuery<T> query = context.Set<T>();

                includelist.ForEach(x => query = query.Include(x));

                return (List<T>)query.ToList();
            }

        }


        public T Single(Expression<Func<T, bool>> predicate)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<T>().FirstOrDefault(predicate);
            }
        }

        public T Single(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes)
        {
            List<string> includelist = new List<string>();

            foreach (var item in includes)
            {
                MemberExpression body = item.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("The body must be a member expression");

                includelist.Add(body.Member.Name);
            }

            using (AppDbContext context = new AppDbContext())
            {
                DbQuery<T> query = context.Set<T>();

                includelist.ForEach(x => query = query.Include(x));

                return query.FirstOrDefault(predicate);
            }
        }


        public List<T> Filter(Expression<Func<T, bool>> predicate)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return (List<T>)context.Set<T>().Where(predicate).ToList();
            }
        }

        public List<T> Filter(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes)
        {
            List<string> includelist = new List<string>();

            foreach (var item in includes)
            {
                MemberExpression body = item.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("The body must be a member expression");

                includelist.Add(body.Member.Name);
            }

            using (AppDbContext context = new AppDbContext())
            {
                DbQuery<T> query = context.Set<T>();

                includelist.ForEach(x => query = query.Include(x));

                return (List<T>)query.Where(predicate).ToList();
            }
        }


        public void Create(T entity)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var entities = context.Set<T>().Where(predicate).ToList();
                entities.ForEach(x => context.Entry(x).State = EntityState.Deleted);
                context.SaveChanges();
            }
        }

    }
}