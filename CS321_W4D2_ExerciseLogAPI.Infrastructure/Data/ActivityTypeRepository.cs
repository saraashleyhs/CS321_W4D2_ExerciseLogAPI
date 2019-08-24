using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly AppDbContext _dbContext;
        public ActivityTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActivityType Add(ActivityType newType)
        {
   _dbContext.ActivityTypes.Add(newType);
            _dbContext.SaveChanges();
            return newType;
        }

        public ActivityType Get(int id)
        {
            return _dbContext.ActivityTypes
                .Include(type => type.Id).SingleOrDefault(Type => Type.Id == id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _dbContext.ActivityTypes
                .ToList();
        }

        public void Remove(ActivityType type)
        {
            _dbContext.ActivityTypes.Remove(type);
            _dbContext.SaveChanges();
        }

        public ActivityType Update(ActivityType type)
        {
            var currentType = _dbContext.ActivityTypes.FirstOrDefault(x => x.Id == type.Id);

            if (currentType == null) return null;

            _dbContext.Entry(currentType)
                .CurrentValues
                .SetValues(type);

            _dbContext.Update(currentType);
            _dbContext.SaveChanges();
            return currentType;
        }
    }
}
