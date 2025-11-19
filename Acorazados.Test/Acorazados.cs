namespace Acorazados.Test;

public class Acorazados
{
    private List<Jugador> _jugadores { get; } = [];

    public void AgregarJugador(string nombre)
    {
        if(_jugadores.Count == 2)
            throw new InvalidOperationException("No se pueden agregar más de dos jugadores");
        
        _jugadores.Add(new Jugador(nombre));
    }

    public Jugador ObtenerJugador(int indice)
        =>  _jugadores[indice];

    public void Start()
    {
        if (_jugadores.Count(a => a.Tablero.ExistenBarcos()) != _jugadores.Count)
            throw new InvalidOperationException("Ambos jugadores deben tener barcos en el tablero");
    }
}

public class Jugador(string nombre)
{
    public Tablero Tablero { get; set; } = new();
    public string Nombre { get; set; } = nombre;
}
