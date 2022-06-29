using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Models
{
    public class ListaTarefas
    {
        [Key]
        public int Id { get; set; }
        public string Tarefa { get; set; }

        public string Criacao { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        [RangeAttribute(0, 1)]

        [Display(Name = "Status")]
        public int status { get; set; }

    }
}
