using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningWebsite.Repository;
using LearningWebsite.Business;

namespace LearningWebsite.Business
{
    public interface IClassScheduleManager
    {
        ClassScheduleModelUser Add(int userId);
        //ClassScheduleModelUser[] GetAll(int userId);
    }

    public class ClassScheduleModelUser
    {
        public int UserId { get; set; }
    }

    public class ClassScheduleManager : IClassScheduleManager
    {
        private readonly IClassScheduleUserRepository classScheduleUserRepository;

        public ClassScheduleManager(IClassScheduleUserRepository classScheduleUserRepository)
        {
            this.classScheduleUserRepository = classScheduleUserRepository;
        }

        public ClassScheduleModelUser Add(int userId)
        {
            var user = classScheduleUserRepository.Add(userId);

            return new ClassScheduleModelUser { UserId = user.UserId };
        }

        //public ClassScheduleModelUser[] GetAll(int userId)
        //{
        //    var user = classScheduleUserRepository.GetAll(int userId)
        //        .Select(x => new ClassScheduleModelUser { UserId = x.UserId })
        //        .ToArray();
        //}

        
    }
}
