namespace Acorazados.Test;

public class Acorazados
{
    
    public Acorazados()
    {
        
    }

    public void AgregarJugador(string nombre)
    {
        
    }

    public Jugador ObtenerJugador(int indice)
    {
        return new Jugador("David");
    }
}

public class Jugador(string nombre)
{
    public Tablero Tablero { get; set; } = new();
    public string Nombre { get; set; } = nombre;
}
