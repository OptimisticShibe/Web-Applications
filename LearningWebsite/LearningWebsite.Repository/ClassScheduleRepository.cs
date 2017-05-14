using LearningWebsite.UserDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWebsite.Repository
{
    public interface IClassScheduleUserRepository
    {
        ClassScheduleModelUser Add(int userId);

        //In shopping cart model, we had the removal bool here
        //ClassScheduleModel[] GetAll(int ClassId);
    }

    //public interface IClassScheduleRepository
    //{
    //    ClassScheduleModel Add(int classId);
    //}

    public class ClassScheduleModelUser
    {
        public int UserId { get; set; }
    }

    //public class ClassScheduleModel
    //{
    //    public int ClassId { get; set; }
    //}

    public class ClassScheduleUserRepository : IClassScheduleUserRepository
    {
        public ClassScheduleModelUser Add(int userId)
        {
            var user = DatabaseAccessor.Instance.Users.Add(
                new UserDatabase.User { UserId = userId });

            DatabaseAccessor.Instance.SaveChanges();

            return new ClassScheduleModelUser { UserId = user.UserId };
        }
    } 
    //public class ClassScheduleRepository : IClassScheduleRepository
    //{
    //    public ClassScheduleModel Add(int classId)
    //    {
    //        var user = DatabaseAccessor.Instance.Classes.Add(
    //            new UserDatabase.Class { ClassId = classId });

    //        DatabaseAccessor.Instance.SaveChanges();

    //        return new ClassScheduleModel { ClassId = classId };
    //    }

    //    public ClassScheduleModel[] GetAll (int classId)
    //    {
    //        var classes = DatabaseAccessor.Instance.Classes
    //            .Where(x=>x.Users)
    //    }
    //}

    //public ClassScheduleModel[] GetAll(int classId)
    //{
    //    var classOfferings = DatabaseAccessor.Instance.Classes
    //            .Where(x => x.ClassId == classId)
    //            .Select(x => new ClassScheduleModel { ClassId = x.ClassId })
    //            .ToArray();
    //    return classOfferings;
    //}
}


