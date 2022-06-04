using File = VirtualAcademy.Domain.Entities.File;

namespace VirtualAcademy.Domain.Entities
{
    public class Academy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDecription { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<File> Files { get; set; }
        public Guid? ImageId { get; set; }
        public File ImageFile { get; set; }
    }
}
