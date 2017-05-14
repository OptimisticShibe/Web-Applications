using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWebsite.Repository
{
    public interface IClassOfferingsRepository
    {
        ClassOfferingsModel[] Classes { get; }
        ClassOfferingsModel ClassOffering(int classId);
        ClassOfferingsModel GetClass(int classId);

    }

    public class ClassOfferingsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ClassOfferingsRepository : IClassOfferingsRepository
    {
        public ClassOfferingsModel[] Classes
        {
            get
            {
                return DatabaseAccessor.Instance.Classes
                    .Select(x => new ClassOfferingsModel { Id = x.ClassId, Name = x.ClassName })
                    .ToArray();
            }
        }

        public ClassOfferingsModel ClassOffering(int classId)
        {
            var classOffering = DatabaseAccessor.Instance.Classes
                .Where(x => x.ClassId == classId)
                .Select(x => new ClassOfferingsModel { Id = x.ClassId, Name = x.ClassName })
                .First();
            return classOffering;
        }

        public ClassOfferingsModel GetClass(int classId)
        {
            return DatabaseAccessor.Instance.Classes
                        .Where(t => t.ClassId == classId)
                        .Select(t => new ClassOfferingsModel
                        {
                            Id = t.ClassId
                        })
                        .First();


        }
    }
}
