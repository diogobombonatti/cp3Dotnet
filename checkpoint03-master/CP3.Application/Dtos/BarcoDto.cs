using CP3.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP3.Application.Dtos
{
    public class BarcoDto : IBarcoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public double Tamanho { get; set; }

        public void Validate()
        {
            
            new BarcoDtoValidation().ValidateAndThrow(this);
        }
    }

    internal class BarcoDtoValidation : AbstractValidator<BarcoDto>
    {
        public BarcoDtoValidation()
        {
            RuleFor(barco => barco.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.");

            RuleFor(barco => barco.Modelo)
                .NotEmpty().WithMessage("O campo Modelo é obrigatório.");

            RuleFor(barco => barco.Ano)
                .GreaterThan(0).WithMessage("O Ano deve ser maior que zero.");

            RuleFor(barco => barco.Tamanho)
                .GreaterThan(0).WithMessage("O Tamanho deve ser maior que zero.");
        }
    }
}
