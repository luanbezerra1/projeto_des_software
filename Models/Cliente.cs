

using System.ComponentModel.DataAnnotations;

namespace ProdutosApi;

public class Cliente{
    [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(100, MinimumLength =3,
            ErrorMessage ="O nome deve ter entre 3 e 100 caracteres")]
    public string Nome {get;set;} = string.Empty;


    [Required]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
    public bool EhMaiorDeIdade =>
    DataNascimento <= DateTime.Today.AddYears(-18);


    [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
    public string Email { get; set; } = string.Empty;


}

