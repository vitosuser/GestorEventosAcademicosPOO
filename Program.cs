using GestorEventosAcademicosPOO.Modelos;
using GestorEventosAcademicosPOO.Servicios;


namespace GestionEventos;

class Program
{
    static readonly CentroEventos Centro = new();

    static void Main(string[] args)
    {
        Centro.AgregarEvento(new Conferencia(
            "CONF-001", "Inteligencia Artificial en la Educación",
            DateTime.Today.AddDays(45), "Facultad de Ingeniería", "Auditorio Principal", 100, 2));

        Centro.AgregarEvento(new Seminario(
            "SEM-001", "Metodologías Ágiles",
            DateTime.Today.AddDays(60), "Departamento de Sistemas", "Sala 3B", 30, 6, 15000m, 6));

        MostrarMenu();
    }

    static void MostrarMenu()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n--- GESTIÓN DE EVENTOS ---");
            Console.WriteLine("1. Listar eventos");
            Console.WriteLine("2. Registrar conferencia");
            Console.WriteLine("3. Registrar seminario");
            Console.WriteLine("4. Inscribir participante");
            Console.WriteLine("5. Procesar pago");
            Console.WriteLine("6. Verificar cupos");
            Console.WriteLine("7. Ver inscripciones");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1": ListarEventos(); break;
                case "2": RegistrarConferencia(); break;
                case "3": RegistrarSeminario(); break;
                case "4": InscribirParticipante(); break;
                case "5": ProcesarPago(); break;
                case "6": VerificarCupos(); break;
                case "7": VerInscripciones(); break;
                case "0": continuar = false; break;
            }
        }
    }

    static void ListarEventos()
    {
        foreach (string evento in Centro.ListarEventos())
            Console.WriteLine(evento);
    }

    static void RegistrarConferencia()
    {
        Console.Write("Código: "); var codigo = Console.ReadLine()!;
        Console.Write("Título: "); var titulo = Console.ReadLine()!;
        Console.Write("Fecha (dd/MM/yyyy): "); var fecha = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Organizador: "); var organizador = Console.ReadLine()!;
        Console.Write("Lugar: "); var lugar = Console.ReadLine()!;
        Console.Write("Capacidad: "); var capacidad = int.Parse(Console.ReadLine()!);
        Console.Write("Duración (horas): "); var duracion = int.Parse(Console.ReadLine()!);

        Centro.AgregarEvento(new Conferencia(codigo, titulo, fecha, organizador, lugar, capacidad, duracion));
        Console.WriteLine("Conferencia registrada.");
    }

    static void RegistrarSeminario()
    {
        Console.Write("Código: "); var codigo = Console.ReadLine()!;
        Console.Write("Título: "); var titulo = Console.ReadLine()!;
        Console.Write("Fecha (dd/MM/yyyy): "); var fecha = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Organizador: "); var organizador = Console.ReadLine()!;
        Console.Write("Lugar: "); var lugar = Console.ReadLine()!;
        Console.Write("Capacidad: "); var capacidad = int.Parse(Console.ReadLine()!);
        Console.Write("Duración (horas): "); var duracion = int.Parse(Console.ReadLine()!);
        Console.Write("Costo: "); var costo = decimal.Parse(Console.ReadLine()!);
        Console.Write("Horas académicas: "); var horas = int.Parse(Console.ReadLine()!);

        Centro.AgregarEvento(new Seminario(codigo, titulo, fecha, organizador, lugar, capacidad, duracion, costo, horas));
        Console.WriteLine("Seminario registrado.");
    }

    static void InscribirParticipante()
    {
        Console.Write("Código del evento: "); var codigo = Console.ReadLine()!;
        Console.Write("Documento: "); var documento = Console.ReadLine()!;
        Console.Write("Nombre: "); var nombre = Console.ReadLine()!;
        Console.Write("Email: "); var email = Console.ReadLine()!;
        Console.Write("¿Es estudiante? (s/n): "); var esEstudiante = Console.ReadLine()!.ToLower() == "s";

        try
        {
            Centro.InscribirParticipante(codigo, new Participante(documento, nombre, email, esEstudiante));
            Console.WriteLine("Inscripción realizada.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ProcesarPago()
    {
        Console.Write("Código del evento: "); var codigo = Console.ReadLine()!;
        Console.Write("Documento: "); var documento = Console.ReadLine()!;

        try
        {
            Centro.ProcesarPago(codigo, documento);
            Console.WriteLine("Pago procesado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void VerificarCupos()
    {
        Console.Write("Código del evento: "); var codigo = Console.ReadLine()!;
        var evento = Centro.BuscarEvento(codigo);
        Console.WriteLine($"Cupos disponibles: {Centro.VerificarCupos(codigo)} / {evento!.CapacidadMaxima}");
    }

    static void VerInscripciones()
    {
        Console.Write("Código del evento: "); var codigo = Console.ReadLine()!;
        var evento = Centro.BuscarEvento(codigo)!;

        foreach (var i in evento.ObtenerInscripciones())
            Console.WriteLine($"{i.Participante} - Pago: {(i.PagoRealizado ? "Sí" : "No")}");
    }
}