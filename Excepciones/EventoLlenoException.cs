namespace GestorEventosAcademicosPOO.Excepciones;
using System;
public class EventoLlenoException : Exception
{
    public EventoLlenoException(string mensaje) : base(mensaje)
    {
     
    }
}