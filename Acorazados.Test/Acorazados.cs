namespace Acorazados.Test;

public class Acorazados
{
    public List<Jugador> Jugadores { get; } = [];

    public void AgregarJugador(string nombre)
    {
        if(Jugadores.Count == 2)
            throw new InvalidOperationException("No se pueden agregar más de dos jugadores");
        
        Jugadores.Add(new Jugador(nombre));
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
