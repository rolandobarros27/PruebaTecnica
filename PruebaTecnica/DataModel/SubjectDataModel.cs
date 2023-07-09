using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.DataModel
{
    public class SubjectDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime birthdate { get; set; }

    }
}
