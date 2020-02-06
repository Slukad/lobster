using Adventure.Data.Context;
using Adventure.Models.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Adventure.Services
{
    public class DecisionManager : IDataRepository<Models.Custom.Decision>
    {
        readonly ApplicationContext _applicationContext;
        public DecisionManager(ApplicationContext context)
        {
            _applicationContext = context;
        }

        public void Add(Models.Custom.Decision entity)
        {
            _applicationContext.Decision.Add(entity);
            _applicationContext.SaveChanges();
        }

        public void Delete(Models.Custom.Decision entity)
        {
            _applicationContext.Decision.Remove(entity);
            _applicationContext.SaveChanges();
        }

        public Models.Custom.Decision Get(long id)
        {
            return _applicationContext.Decision.FirstOrDefault(a => a.Id == id);
        }

        public IQueryable<Models.Custom.Decision> GetAll()
        {
            var decisions = _applicationContext.Decision
                .Include(a => a.Choices)
                .Include(a => a.NextDecisionChoices)
                .OrderBy(a => a.Id)
                .Select(s => new Models.Custom.Decision() 
                { 
                    Id = s.Id,
                    Text = s.Text,
                    Level = s.Level,
                    Order = s.Order,
                    Choices = s.Choices.Select(c => new Models.Custom.Choice() 
                    { 
                        Id = c.Id,
                        Text = c.Text,
                        NextDecision = new Models.Custom.Decision() { Id = c.NextDecision.Id}
                    }).ToList()
                });

            return decisions;
        }

        public void Update(Models.Custom.Decision dbEntity, Models.Custom.Decision entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Custom.Decision entity)
        {
            _applicationContext.Decision.Update(entity);
            _applicationContext.SaveChanges();
        }
    }
}
