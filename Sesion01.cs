//Interfaz: contrato que define que debe poder hacer un empleado
using System;

public interface IEmpleado
{
    string Nombre { get; }
    decimal CalcularSueldo();
}

//Clase: empleado con sueldo fijo
public class EmpleadoFijo : IEmpleado
{
    public string Nombre { get; }
    public decimal SueldoBase {  get; }

    public EmpleadoFijo(string nombre, decimal sueldoBase)
    {
        Nombre = nombre;
        SueldoBase = sueldoBase;
    }

    public decimal CalcularSueldo()
    {
        return SueldoBase;
    }
}

//Clase: empleado por horas
public class EmpleadoPorHoras : IEmpleado
{
    public string Nombre { get; }
    public decimal PrecioPorHora {  get; }
    public int HorasTrabajadas { get; }

    public EmpleadoPorHoras(string nombre, decimal precioPorHora, int horasTrabajadas)
    {
        Nombre = nombre;
        PrecioPorHora = precioPorHora;
        HorasTrabajadas = horasTrabajadas;
    }

    public decimal CalcularSueldo()
    {
        return PrecioPorHora * HorasTrabajadas;
    }
}

//Record: datos de un pago (solo lectura, no cambia)
public record PagoRecord (string NombreEmpleado, decimal Monto, DateTime Fecha);


