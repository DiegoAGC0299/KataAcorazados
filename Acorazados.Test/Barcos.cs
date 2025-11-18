namespace Acorazados.Test;

public record Barcos
{
    public TiposBarcos Barco { get; set; }
    public int Casillas{ get; set; }
    public string Simbolo { get; set; }
    
    public static Barcos Destructor =>  new Barcos(TiposBarcos.Destructor, 3, "d");
    public static Barcos Portaaviones =>  new Barcos(TiposBarcos.Portaaviones, 4, "c");
    public static Barcos Canonero =>  new Barcos(TiposBarcos.Canonero, 1, "g");
    

    public Barcos(TiposBarcos tipoBarco, int casillas, string simbolo)
    {
        Barco = tipoBarco;
        Casillas = casillas;
        Simbolo = simbolo;
    }
}