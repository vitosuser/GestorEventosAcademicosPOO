namespace GestorEventosAcademicosPOO.Modelos;

public class Conferencia : EventoAcademico
{
    private const int duracionMaxima = 3;

    public Conferencia(string codigo, string titulo, DateTime fecha, string organizador, string lugar, int capacidadMaxima, int duracion) : base (codigo,  titulo, fecha, organizador,  lugar,  capacidadMaxima,  duracion)
    {
        if (duracion > duracionMaxima)
        {
            throw new Exception($"Error: la duracion maxima de una conferencia es {duracionMaxima} hs");
        }
    }
}