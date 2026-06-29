namespace GestorEventosAcademicosPOO.Modelos;

public class Participante
{
    private string documento;
    private string nombre;
    private string email;
    private bool estudiante;
    
    public string Documento { get => documento; }

    public Participante(string Documento, string Nombre, string Email, bool Estudiante)
    {
        documento = Documento;
        nombre = Nombre;
        email = Email;  
        estudiante = Estudiante;
    }
}