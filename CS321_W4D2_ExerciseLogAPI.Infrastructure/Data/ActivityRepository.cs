using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository :IActivityRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Activity Add(Activity newActivity)
        {
            _dbContext.Activities.Add(newActivity);
            _dbContext.SaveChanges();
            return newActivity;
        }

        public Activity Get(int id)
        {
            return _dbContext.Activities
                .Include(activity => Activity.)
                .SingleOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users
                .Include(user => user.Activities)
                .ToList();
        }

        public void Remove(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public User Update(User updatedUser)
        {
            var currentUser = _dbContext.Users.FirstOrDefault(x => x.Id == updatedUser.Id);

            if (currentUser == null) return null;

            _dbContext.Entry(currentUser)
                .CurrentValues
                .SetValues(updatedUser);

            _dbContext.Update(currentUser);
            _dbContext.SaveChanges();
            return currentUser;
        }
        public IEnumerable<User> GetActivitiesforUser(int userId)
        {
            return _dbContext.Users
                .Include(user => user.Activities)
                .Where(u => u.Id == userId).ToList();
        }
    }
}
