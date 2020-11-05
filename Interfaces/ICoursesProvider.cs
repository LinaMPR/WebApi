using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursos.Models;

namespace WebApiCursos.Interfaces
{
    public interface ICoursesProvider
    {
        Task<ICollection<Course>> GetAllasAsync();
        Task<ICollection<Course>> SearchAsync(string search);
        Task<Course> GetAsync(int Id);
        Task<bool> UpdateAsync(int id, Course course);
        Task<(bool IsSuccess, int? Id)> AddAsync(Course course);
    }
}
