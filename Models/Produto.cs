
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TrabalhoApi;

public class Produto{
    public int Id {get; set;}

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(120, MinimumLength = 3, 
        ErrorMessage = "O nome deve ter entre 3 e 120 caracteres")]
    public string Nome { get; set; } = string.Empty;


    [Range(typeof(decimal), "0,01", "99999999999,99", 
    ErrorMessage = "O preço deve ser maior que 0")]
    public decimal Preco { get; set; }


    [Range(0, int.MaxValue, 
    ErrorMessage = "Estoque não pode ser negativo.")]
    public int Estoque { get; set; }
}


