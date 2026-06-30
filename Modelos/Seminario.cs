namespace GestorEventosAcademicosPOO.Modelos;

public class Seminario : EventoAcademico
{
    private const int duracionMaxima = 8;
    private decimal costo;
    private int horasAcademicas;

    public Seminario(string codigo, string titulo, DateTime fecha, string organizador, string lugar, int capacidadMaxima, int duracion, decimal Costo, int HorasAcademicas) : base(codigo, titulo, fecha, organizador, lugar, capacidadMaxima, duracion)
    {
        costo = Costo;
        horasAcademicas = HorasAcademicas;
        
        if (duracion > duracionMaxima)
        {
            throw new Exception($"Error: la duracion maxima de un seminario es {duracionMaxima} hs");
        }
        //duracionMaxima = 8;
    }
}