namespace Acorazados.Test;

public class Jugador(string nombre)
{
    public Tablero Tablero { get; } = new();
    public string Nombre { get; } = nombre;
}