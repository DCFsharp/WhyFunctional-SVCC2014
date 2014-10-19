using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMisc
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFunctional { get; set; }
        public int YearsOfExperience { get; set; }
    }

    public class GoodSeniorDeveloper
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class HOF
    {
        public void GetDeveloperImp(List<Developer> developers)
        {
            var goodSeniorDevelopers = new List<GoodSeniorDeveloper>();

            foreach (Developer d in developers)
            {
                if (d.YearsOfExperience >= 5 && d.IsFunctional)
                {
                    goodSeniorDevelopers.Add(new GoodSeniorDeveloper
                    {
                        FirstName = d.FirstName,
                        LastName = d.LastName
                    });
                }
            }
        }

        public void GetDeveloperImp2(List<Developer> developers)
        {
            IEnumerable<GoodSeniorDeveloper> goodSeniorDevelopers =
                developers.Where(d => d.IsFunctional && d.YearsOfExperience >= 5)
                .Select(d => new GoodSeniorDeveloper
                    {
                        FirstName = d.FirstName,
                        LastName = d.LastName
                    });

        }

        public void GetPersonImpHOF(List<Developer> developers)
        {
            Func<Developer, GoodSeniorDeveloper> convertToGSD = d => new GoodSeniorDeveloper
            {
                FirstName = d.FirstName,
                LastName = d.LastName
            };

            Func<Developer, bool> isGSD = d => d.YearsOfExperience >= 5 && d.IsFunctional;

            IEnumerable<GoodSeniorDeveloper> goodSeniorDevelopers =
                          developers.Where(isGSD)
                                    .Select(convertToGSD);

            IEnumerable<GoodSeniorDeveloper> goodSeniorDevelopers2 =
                            Map(Filter(developers, isGSD), convertToGSD);

        }

        public IEnumerable<R>  Map<T, R>(IEnumerable<T> list, Func<T, R> converter)
        {
            foreach (var item in list)
                yield return converter(item);
        }

        public IEnumerable<T> Filter<T>(IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
                if (predicate(item))
                    yield return item;
        }

    }
}
