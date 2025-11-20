namespace Acorazados.Test;

public class Acorazados
{
    private List<Jugador> _jugadores { get; } = [];
    public EstadoJuego Estado { get; private set; } = EstadoJuego.NoIniciado;
    private int _jugadorAtacado = 1;

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
        
        Estado = EstadoJuego.EnCurso;
    }

    public string Disparar(int i, int i1)
    {
        if (Estado == EstadoJuego.NoIniciado)
            throw new InvalidOperationException("Debe iniciar el juego para poder disparar");

        if (Estado == EstadoJuego.Finalizado)
            throw new InvalidOperationException("Debe iniciar un juego nuevo");

        var jugadorOponente = ObtenerJugador(_jugadorAtacado);
        var respuesta = jugadorOponente.Tablero.RecibirDisparo(i, i1);
        
        VerificarJuegoFinalizado(jugadorOponente);
        
        _jugadorAtacado = _jugadorAtacado == 1 ?  0 : _jugadorAtacado + 1;
        return respuesta;
    }

    private void lanzarExcepcionesSiElJuegoNoEstaEnCurso()
    {
        if (Estado == EstadoJuego.NoIniciado)
            throw new InvalidOperationException("Debe iniciar el juego para poder disparar");

        if (Estado == EstadoJuego.Finalizado)
            throw new InvalidOperationException("Debe iniciar un juego nuevo");
    }

    private void VerificarJuegoFinalizado(Jugador jugadorOponente)
    {
        if(!jugadorOponente.Tablero.ExistenBarcos())
            Estado = EstadoJuego.Finalizado;
    }

    private void LanzarExcepcionSiElJuegoNoseHaIniciado()
    {
        if (Estado == EstadoJuego.NoIniciado)
            throw new InvalidOperationException("Debe iniciar el juego para poder disparar");
    }
}

public class Jugador(string nombre)
{
    public Tablero Tablero { get; set; } = new();
    public string Nombre { get; set; } = nombre;
}

public enum EstadoJuego
{
    NoIniciado,
    EnCurso,
    Finalizado
}
