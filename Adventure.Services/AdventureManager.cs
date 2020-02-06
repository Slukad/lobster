using Adventure.Data.Context;
using Adventure.Models.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Adventure.Services
{
    public class AdventureManager : IDataRepository<Models.Custom.Adventure>
    {
        readonly ApplicationContext _applicationContext;
        public AdventureManager(ApplicationContext context)
        {
            _applicationContext = context;
        }

        readonly Expression<Func<Models.Custom.Adventure, Models.Custom.Adventure>> commonProjection = s => new Models.Custom.Adventure
        {
            Id = s.Id,
            StartTime = s.StartTime,
            EndTime = s.EndTime,
            Player = s.Player,
            SelectedChoices = s.SelectedChoices.Select(c => new Models.Custom.SelectedChoice()
            {
                Id = c.Id,
                ChoiceId = c.ChoiceId,
                DecisionId = c.DecisionId
            }).ToList()
        };

        public void Add(Models.Custom.Adventure entity)
        {
            _applicationContext.Adventure.Add(entity);
            _applicationContext.SaveChanges();
        }

        public void Delete(Models.Custom.Adventure entity)
        {
            _applicationContext.Adventure.Remove(entity);
            _applicationContext.SaveChanges();
        }

        public Models.Custom.Adventure Get(long id)
        {
            return _applicationContext.Adventure
                .Include(a => a.Player)
                .Include(a => a.SelectedChoices)
                .Select(commonProjection)
                .FirstOrDefault(a => a.Id == id);
        }

        public IQueryable<Models.Custom.Adventure> GetAll()
        {
            return _applicationContext.Adventure
                .Include(a => a.Player)
                .Include(a => a.SelectedChoices)
                .Select(commonProjection)
                .OrderByDescending(a => a.Id)
                .AsQueryable();
        }        

        public void Update(Models.Custom.Adventure dbEntity, Models.Custom.Adventure entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Custom.Adventure entity)
        {
            _applicationContext.Adventure.Update(entity);
            _applicationContext.SaveChanges();
        }
    }
}
