namespace GestorEventosAcademicosPOO.Modelos;

public class Participante
{
    private string documento;
    private string nombre;
    private string email;
    private bool estudiante;
    private bool pagoRealizado;
    
    public string Documento { get => documento; }
    public string Nombre { get => nombre; }
    public bool  PagoRealizado { get => pagoRealizado; set => pagoRealizado = value; }

    public Participante(string Documento, string Nombre, string Email, bool Estudiante)
    {
        documento = Documento;
        nombre = Nombre;
        email = Email;  
        estudiante = Estudiante;
        pagoRealizado = false;
    }
}