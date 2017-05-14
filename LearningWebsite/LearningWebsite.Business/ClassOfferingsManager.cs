using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningWebsite.Repository;

namespace LearningWebsite.Business
{
    public interface IClassOfferingsManager
    {
        ClassOfferingsModel[] Classes { get; }
        ClassOfferingsModel ClassOffering(int classId);
        //ClassOfferingsModel GetClass(int classId);
    }

    public class ClassOfferingsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ClassOfferingsModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class ClassOfferingsManager : IClassOfferingsManager
    {
        private readonly IClassOfferingsRepository classOfferingsRepository;

        public ClassOfferingsManager(IClassOfferingsRepository classOfferingsRepository)
        {
            this.classOfferingsRepository = classOfferingsRepository;
        }

        public ClassOfferingsModel[] Classes
        {
            get
            {
                return classOfferingsRepository.Classes
                    .Select(x => new ClassOfferingsModel(x.Id, x.Name))
                    .ToArray();
            }
        }

        public ClassOfferingsModel ClassOffering(int classId)
        {
            var classOfferingsModel = classOfferingsRepository.ClassOffering(classId);
            return new ClassOfferingsModel(classOfferingsModel.Id, classOfferingsModel.Name);
        }

        //public ClassOfferingsModel GetClass(int classId)
        //{
        //    var classes = classOfferingsRepository.GetClass(classId);

        //    return new ClassOfferingsModel
        //    {
        //        Id = classes.Id,
        //        Name = classes.Name
        //    );
        //}
    }
}
