using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

namespace WebApiCursos.Provides
{
    public class FakeCoursesProvider : ICoursesProvider
    {
        private readonly List <Course> repo = new List<Course>();
        public FakeCoursesProvider ()
        {
            repo.Add(new Course()
            {
                Id = 1,
                Name = "Azure DevOps y VSTS esencial",
                Author = "Rodrigo Díaz Concha",
                Description = "Conoce los principios, herramientas y técnicas de Azure DevOps y " +
                "Visual Studio .NET. Amplia y mejora tus conocimientos sobre Azure Repos, " +
                "Azure Pipelines, Azure Boards, Azure Test Plans y Azure Artifacts. Consigue " +
                "entregar software de mejor calidad en menos tiempo y asegura un desarrollo" +
                " exitoso en proyectos de cualquier tipo de tamaño.",
                Uri = "https://www.linkedin.com/learning/azure-devops-y-vsts-esencial/el-universo-de-azure-devops-y-vsts?u=60693444",

            }) ;
            repo.Add(new Course()
            {
                Id = 2,
                Name = ".Net Core Esencial",
                Author = "Rodrigo Díaz Concha",
                Description = "Domina .NET Core como plataforma de desarrollo. Aprende con este curso " +
                "qué es, sus características y herramientas más importantes, su historia, entornos y " +
                "lenguajes soportados, cuáles son los tipos de aplicaciones que puedes construir con " +
                "esta plataforma, y echa un vistazo al futuro que le espera. Entiende por qué .NET Core " +
                "es definitivamente una plataforma clave y por qué deberías dedicarle tiempo y esfuerzo.",
                Uri = "https://www.linkedin.com/learning/dot-net-core-esencial/la-plataforma-de-desarrollo-dot-net-core?u=60693444",
            });
            repo.Add(new Course()
            {
                Id = 3,
                Name = ".Net Core Avanzado",
                Author = "Rodrigo Díaz Concha",
                Description = "Lleva tu potencial de desarrollo a un nuevo nivel gracias a las " +
                "funcionalidades avanzadas disponibles en .NET Core 3.0. Incrementa tus conocimientos " +
                "sobre la plataforma conociendo su funcionamiento interno, conceptos clave como los " +
                "modelos de servicios gRPC, características poderosas en WPF o cómo se mejora la " +
                "seguridad con ASP.NET Core Identity.",
                Uri = "https://www.linkedin.com/learning/dot-net-core-avanzado/bienvenido-a-dot-net-core-avanzado?u=60693444"
            });
        }

        public Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
        {
            course.Id = repo.Max(c => c.Id) + 1;
            repo.Add(course);
            return Task.FromResult((true, (int?) course.Id));
        }

        public Task<ICollection<Course>> GetAllasAsync()
        {
            return Task.FromResult((ICollection<Course>)repo.ToList());
        }

        public Task<Course> GetAsync(int Id)
        {
            return Task.FromResult(repo.FirstOrDefault(c => c.Id == Id));
        }

        public Task<ICollection<Course>> SearchAsync(string search)
        {
            return Task.FromResult((ICollection<Course>)repo.Where(c=>c.Name.ToLowerInvariant().Contains(search.ToLowerInvariant())).ToList());
        }

        public Task<bool> UpdateAsync(int id, Course course)
        {
            var courseToUpdate = repo.FirstOrDefault(c=>c.Id==id);
            if (courseToUpdate != null)
            {
                courseToUpdate.Name = course.Name;
                courseToUpdate.Author = course.Author;
                courseToUpdate.Description = course.Description;
                courseToUpdate.Uri = course.Uri;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
