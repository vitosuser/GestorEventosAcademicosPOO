namespace GestorEventosAcademicosPOO.Modelos;

public class Seminario : EventoAcademico
{
    private int duracionMaxima;
    private decimal costo;
    private int horasAcademicas;

    public Seminario(string codigo, string titulo, DateTime fecha, string organizador, string lugar, int capacidadMaxima, int duracion, decimal Costo, int HorasAcademicas) : base(codigo, titulo, fecha, organizador, lugar, capacidadMaxima, duracion, Participantes)
    {
        costo = Costo;
        horasAcademicas = HorasAcademicas;
        duracionMaxima = 8;
    }
}