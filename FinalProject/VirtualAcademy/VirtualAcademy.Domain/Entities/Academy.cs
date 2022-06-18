using VirtualAcademy.Domain.Common;
using File = VirtualAcademy.Domain.Entities.File;

namespace VirtualAcademy.Domain.Entities
{
    public class Academy : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDecription { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }
        public virtual IEnumerable<Department> Departments { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }
        public virtual IEnumerable<File> Files { get; set; }
        public Guid? ImageId { get; set; }
        public virtual File ImageFile { get; set; }
    }
}
