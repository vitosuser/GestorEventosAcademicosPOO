using GestorEventosAcademicosPOO.Modelos;
using GestorEventosAcademicosPOO.Excepciones;

namespace GestorEventosAcademicosPOO.Servicios;

public class CentroEventos
{
    private List<EventoAcademico> listaEventos;
    
    public CentroEventos()
    {
        listaEventos = new List<EventoAcademico>();
    }

    public EventoAcademico BuscarEvento(string codigo)
    {
        return listaEventos.FirstOrDefault(e => e.Codigo == codigo);
    }

    public void AgregarEvento(EventoAcademico evento)
    {
        listaEventos?.Add(evento);
    }

    public List<string> ListarEventos()
    {
        return listaEventos.Select(e=> $"{e.Codigo} - {e.Titulo}").ToList();
    }

    public void InscribirParticipante(string codigo,  Participante participante)
    {
        EventoAcademico ?evento = BuscarEvento(codigo);
        
        if (evento == null)
        {
            throw new  Exception("No se encontro el evento");
        }
        
        int cuposDisponibles = VerificarCupos(codigo);

        if (cuposDisponibles <= 0)
        {
            throw new EventoLlenoException("El evento ingresado no tiene cupos disponibles");
        }
        
        
        evento.AgregarParticipante(participante);
    }

    public void ProcesarPago(string codigo, string documento)
    {
        EventoAcademico ?evento = BuscarEvento(codigo);
        
        if (evento == null)
        {
            throw new  Exception("No se encontro el evento");
        }

        EventoAcademico.EditarPagoPendiente(documento);

    }

    public int VerificarCupos(string codigo)
    {
        EventoAcademico ?evento = BuscarEvento(codigo);
        
        if (evento == null)
        {
            throw new  Exception("No se encontro el evento");
        }

        var listaParticipantes = evento.ConsultarListaParticipantes();
        int cuposDisponibles = evento.CapacidadMaxima - listaParticipantes.Count();
        
        return cuposDisponibles;
    }
    
}