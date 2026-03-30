
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoApi;

public class Cliente{

    public int Id {get; set;}

    [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(100, MinimumLength =3,
            ErrorMessage ="O nome deve ter entre 3 e 100 caracteres")]
    public string Nome {get;set;} = string.Empty;


    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    public DateTime DataNascimento { get; set; }
    [NotMapped]
    public bool EhMaiorDeIdade => DataNascimento <= DateTime.Today.AddYears(-18);


    [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
    public string Email { get; set; } = string.Empty;


}

