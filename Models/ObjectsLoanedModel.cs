using ObjectsLoaneds.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ObjectsLoaneds.Models
{
    public class ObjectsLoanedModel 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectId { get; set; }
        
        [Required(ErrorMessage = "Insira o nome da pessoa para quem você emprestou")]
        public string NamePeopleLoaned { get; set; }
        [Required(ErrorMessage = "Insira o nome do objeto que você emprestou")]
        public string NameObjectLoaned { get; set; }
        [DataType(DataType.Date)]        
        public DateTime DateLoanedObject { get; set; }
        [DataType(DataType.Date)]        
        public DateTime LimitDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

    }

  

}
