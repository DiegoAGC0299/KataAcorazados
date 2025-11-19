namespace Acorazados.Test;

public class Barcos(TiposBarcos tipo, string nombre, int casillas, string simbolo, int cantidadPermitida)
{
    public string Nombre { get; } = nombre;
    public TiposBarcos Tipo { get; } = tipo;
    public int Casillas { get; } = casillas;
    public string Simbolo { get; } = simbolo;
    public static List<Coordenada> Coordenadas => [];
    public int CantidadPermitida { get; set; } = cantidadPermitida;

    public static Barcos Destructor => new(TiposBarcos.Destructor, "destructor", 3, "d", 2);
    public static Barcos Portaaviones => new(TiposBarcos.Portaaviones,  "portaaviones", 4, "c", 1);
    public static Barcos Canonero => new(TiposBarcos.Canonero,  "cañonero", 1, "g", 4);
}