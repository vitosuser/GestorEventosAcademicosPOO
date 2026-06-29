namespace GestorEventosAcademicosPOO.Modelos;

public abstract class EventoAcademico
{
    private string codigo;
    private string titulo;
    private DateTime fecha;
    private string organizador;
    private string lugar;
    private int capacidadMaxima;
    private int duracion;
    private static List<Participante> participantes;
    
    public string Codigo { get => codigo; set => codigo = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
    public string Organizador { get => organizador; set => organizador = value; }
    public string Lugar { get => lugar; set => lugar = value; }
    public int CapacidadMaxima { get => capacidadMaxima; set => capacidadMaxima = value; }
    public int Duracion { get => duracion; set => duracion = value; }
    public static List<Participante> Participantes { get => participantes; set => participantes = value; }

    public EventoAcademico(string codigo, string titulo, DateTime fecha, string organizador, string lugar, int capacidadMaxima, int Duracion, List<Participante> participantes)
    {
        Codigo = codigo;
        Titulo = titulo;
        Fecha = fecha;
        Organizador = organizador;
        Lugar = lugar;
        CapacidadMaxima = capacidadMaxima;
        Duracion = duracion;
        participantes = null;
    }

    public void AgregarParticipante(Participante participante)
    {
        participantes.Add(participante);
    }

    public List<Participante> ConsultarListaParticipantes()
    {
        return participantes;
    }

    public static void EditarPagoPendiente(string documento)
    {
        Participante participante = Participantes.FirstOrDefault(p=> p.Documento == documento);

        if (participante == null)
        {
            throw new Exception("Error: Participante no encontrado.");
        }
        participante.PagoRealizado = true;
    }
}