using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.DatabaseContext;
using PruebaTecnica.DataModel;
using PruebaTecnica.Models;
using PruebaTecnica.SubjectService;
using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace PruebaTecnica.Controllers
{
    public class SubjectController : Controller
    {
        private readonly MyDatabaseContext _dbcontext;
        private SubjectService.SubjectService _subjectService;

        public SubjectController(MyDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
            _subjectService = new SubjectService.SubjectService();
        }

        [HttpGet]
        [Route("GetSubjectList")]
        public async Task<IActionResult> GetSubjectList()
        {
            try
            {
                return Ok(_dbcontext.Subjects.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddSubject")]
        public async Task<IActionResult> AddSubject([FromBody] SubjectModel obj)
        {
            try
            {
                var document = _dbcontext.Subjects.FirstOrDefault(x => x.Document == obj.Document);
                String result = _subjectService.ValidateSubject(obj);
                if (result != "Ok")
                {
                    return BadRequest(result);
                }
                if(document != null)
                {
                    return BadRequest("El documento ya existe");
                }

                SubjectDataModel subject = new SubjectDataModel();
                subject.Id = Guid.NewGuid();
                subject.Name = obj.Name;
                subject.Lastname = obj.Lastname;
                subject.Document = obj.Document;
                subject.Email = obj.Email;
                subject.Phone = obj.Phone;
                subject.birthdate = obj.birthdate;
                _dbcontext.Subjects.Add(subject);
                _dbcontext.SaveChanges();
                return Ok(subject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteSubject/{document}")]
        public async Task<IActionResult> DeleteSubject(string document)
        {
            try
            {
                var subject = _dbcontext.Subjects.FirstOrDefault(x => x.Document == document);
                if (subject != null)
                {
                    _dbcontext.Subjects.Remove(subject);
                    _dbcontext.SaveChanges();
                }
                return Ok("Persona eliminada satisfactoriamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateSubject/{document}")]
        public async Task<IActionResult> UpdateSubject([FromBody] SubjectModel obj)
        {
            try
            {
                var subject = _dbcontext.Subjects.FirstOrDefault(x => x.Document == obj.Document);
                String result = _subjectService.ValidateSubject(obj);
                if (subject != null && result != "Ok")
                {
                    return BadRequest(result);
                }
      
                subject.Name = obj.Name;
                subject.Lastname = obj.Lastname;
                subject.Email = obj.Email;
                subject.Phone = obj.Phone;
                subject.birthdate = obj.birthdate;
                _dbcontext.SaveChanges();
                
                return Ok(subject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
