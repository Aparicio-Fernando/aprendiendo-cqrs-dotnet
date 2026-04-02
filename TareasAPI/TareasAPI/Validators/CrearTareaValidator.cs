using FluentValidation;
using TareasAPI.Command.Tareas;

namespace TareasAPI.Validators
{
    public class CrearTareaValidator : AbstractValidator<CrearTareaCommand>
    {
        public CrearTareaValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título no puede estar vacío")
                .MaximumLength(200).WithMessage("El título no puede tener más de 200 caracteres");

            RuleFor(x => x.Descripcion)
            .NotEmpty().WithMessage("La descripción no puede estar vacía");

            RuleFor(x => x.Prioridad)
                .IsInEnum().WithMessage("La prioridad debe ser Baja (0), Media (1) o Alta (2)");

            RuleFor(x => x.FechaLimite)
                .GreaterThan(DateTime.Now)
                .WithMessage("La fecha límite debe ser mayor a la fecha actual");
        }
    }
}
