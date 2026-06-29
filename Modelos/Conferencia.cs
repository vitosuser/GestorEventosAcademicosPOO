namespace GestorEventosAcademicosPOO.Modelos;

public class Conferencia : EventoAcademico
{
    private int duracionMaxima;

    public Conferencia(string codigo, string titulo, DateTime fecha, string organizador, string lugar, int capacidadMaxima, int duracion) : base (codigo,  titulo, fecha, organizador,  lugar,  capacidadMaxima,  duracion, Participantes)
    {
        
        duracionMaxima = 3;
    }
}