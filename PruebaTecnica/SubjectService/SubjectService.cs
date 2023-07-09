using PruebaTecnica.Models;

namespace PruebaTecnica.SubjectService
{
    public class SubjectService
    {
        public SubjectService() { }

        // Method to validate the document
        private bool ValidateDocument(string document)
        {
            if (document.Length > 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method to validate the email
        private bool ValidateEmail(string email)
        {
            if (email.Contains("@"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to validate the phone
        private bool ValidatePhone(string phone)
        {
            if (phone.Length == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Method to validate the name
        private bool ValidateName(string name)
        {
            if (name.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Method to validate the lastname
        private bool ValidateLastname(string lastname)
        {
            if (lastname.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method to validate the birthdate
        private bool ValidateBirthday(DateTime birthday)
        {
            DateTime actualDate = DateTime.Today;

            if (birthday > actualDate)
            {
                return false;
            }

            int age = actualDate.Year - birthday.Year;

            if (birthday > actualDate.AddYears(-age))
            {
                age--;
            }

          
            if (age < 0)
            {
                return false;
            }
            return true;
        }

        // Method to validate the subject
        public String ValidateSubject(SubjectModel subject)
        {
            if (!ValidateName(subject.Name))
            {
                return "El nombre es invalido, revise nuevamente";
            }
            if (!ValidateLastname(subject.Lastname))
            {
                return "El apellido es invalido, revise nuevamente";
            }
            if (!ValidateDocument(subject.Document))
            {
                return "El documento es invalido, revise nuevamente";
            }
            if (!ValidateEmail(subject.Email))
            {
                return "El correo es invalido, revise nuevamente";
            }
            if (!ValidatePhone(subject.Phone))
            {
                return "El telefono es invalido, revise nuevamente";
            }
            if (!ValidateBirthday(subject.birthdate))
            {
                return "La fecha de nacimiento es invalida, revise nuevamente";
            }

            return "Ok";
        }

    }
}
