namespace Acorazados.Test;

public class Acorazados
{
    
    public Acorazados()
    {
        
    }

    public void AgregarJugador(string david)
    {
        
    }

    public Jugador ObtenerJugador(int i)
    {
        return new Jugador();
    }
}

public class Jugador
{
    public Tablero Tablero { get; set; } = new();
}
