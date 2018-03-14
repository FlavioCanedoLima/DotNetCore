using System;
using System.ComponentModel.DataAnnotations;

namespace MVCCore.Models
{
    public class CursoModel
    {
        public int Id { get; set; }
        [Display(Name = "Nome"), 
            MaxLength(100, ErrorMessage = "Nome não pode ser maior que 100 caracteres."),
            MinLength(5, ErrorMessage = "Nome não pode ser menor que 5 caracteres.")]
        public string Name { get; set; }
        [Display(Name = "Preço")]
        public decimal Price { get; set; }
        [Display(Name = "Gratuito")]
        public bool Free { get; set; }
        [Display(Name = "CEP")]
        public int ZipCode { get; set; }
        [Display(Name = "Detalhe")]
        public string Description { get; set; }
        [Display(Name = "Data Inicial")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Data Final")]
        public DateTime EndDate { get; set; }
    }
}
