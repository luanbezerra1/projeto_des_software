
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProdutosApi;

public class Produto{

[Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(80, MinimumLength = 3, 
        ErrorMessage = "O nome deve ter entre 3 e 80 caracteres")]
    public string Nome { get; set; } = string.Empty;


    [Range(typeof(decimal), "0.01", "99999999999.99", 
    ErrorMessage = "O preço deve ser maior que 0")]
    public decimal Preco { get; set; }


    [Range(0, int.MaxValue, 
    ErrorMessage = "O estoque deve ser maior ou igual a 0")]
    public int Estoque { get; set; }
}


