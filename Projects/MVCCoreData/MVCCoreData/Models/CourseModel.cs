using System;
using System.ComponentModel.DataAnnotations;

namespace MVCCoreData.Models
{
    public class CourseModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome do Curso"), 
            Required(ErrorMessage = "Nome do curso é obrigatório"),            
            MaxLength(100, ErrorMessage = "Nome do curso não pode superar 100 caracteres"),
            MinLength(5, ErrorMessage = "Nome do curso não pode ser menor que 5 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Valor"),
            Range(1.0, 500.0),
            Required(ErrorMessage = "Valor é obrigatório")]
        public decimal Price { get; set; }

        [Display(Name = "Gratuito")]
        public bool Free { get; set; }

        [Display(Name = "Descrição"),
            Required(ErrorMessage = "Descrição é obrigatório"),
            MaxLength(1000, ErrorMessage = "Descrição não pode superar 1000 caracteres")]
        public string Description { get; set; }

        [Display(Name = "Data incial"),
            Required(ErrorMessage = "Data incial é obrigatório")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Data final"),
            Required(ErrorMessage = "Data final é obrigatório")]
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
