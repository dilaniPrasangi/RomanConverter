using System.ComponentModel.DataAnnotations;

namespace XPS.RomanConverter.Models
{
    public class ConverterModel
    {
        [Required(ErrorMessage = "Please Enter a Number.")]
        [Range(0,2000, ErrorMessage = "Please enter non negative number below 2000.")]
        public int Number { get; set; }

        [Display(Name = "Roman Number")]
        public string RomanNumber { get; set; }

    }
}
