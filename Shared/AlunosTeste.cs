using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    [Table("TblTeste")]
    public class AlunosTeste
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "O primeiro nome do aluno é muito longo.")]
        public string Nome { get; set; } = string.Empty;
        
        [Required]
        [StringLength(15, ErrorMessage = "O sobrenome é muito longo.")]
        public string Sobrenome { get; set; } = string.Empty;

        [Required]
        [Range(6, 80, ErrorMessage = "O valor deve ser entre 6 e 80")]
        public int Idade { get; set; }

        [NotMapped]
        public bool IsRowExpanded { get; set; }
    }
}