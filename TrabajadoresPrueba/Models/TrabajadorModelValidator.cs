using FluentValidation;

namespace TrabajadoresPrueba.Models
{
    public class TrabajadorModelValidator:AbstractValidator<TrabajadorModel>
    {
        public TrabajadorModelValidator()
        {
            RuleFor(x=>x.TipoDocumento).NotEmpty().WithMessage("El tipo de documento es requerido").NotNull().WithMessage("El tipo de documento no puede ser nulo");
            RuleFor(x=>x.NumeroDocumento).NotEmpty().WithMessage("El numero de documento es requerido").NotNull().WithMessage("El numero de documento no puede ser nulo").MaximumLength(50);
            RuleFor(x=>x.Nombres).NotEmpty().WithMessage("El nombres es requerido").NotNull().WithMessage("El nombres no puede ser nulo");
            RuleFor(x=>x.Sexo).NotEmpty().WithMessage("El genero es requerido").NotNull().WithMessage("El genero no puede ser nulo");
            RuleFor(x=>x.IdDepartamento).NotEmpty().WithMessage("El departamento es requerido").NotNull().WithMessage("El departamento no puede ser nulo");
            RuleFor(x=>x.IdProvincia).NotEmpty().WithMessage("La provincia es requerida").NotNull().WithMessage("La provincia no puede ser nulo");
            RuleFor(x=>x.IdDistrito).NotEmpty().WithMessage("El distrito es requerido").NotNull().WithMessage("El distrito no puede ser nulo");
        }
    }
}
