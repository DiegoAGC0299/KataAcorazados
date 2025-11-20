using System.Text;

namespace Acorazados.Test;

public class Acorazados
{
    public EstadoJuego EstadoJuego { get; private set; } = EstadoJuego.NoIniciado;
    private const int CantidadMaximaJugadores = 2;
    private List<Jugador> Jugadores { get; } = [];
    private int _indiceJugadorOponente = 1;
    private int _indiceJugadorActual = 0;

    public void AgregarJugador(string nombre)
    {
        LanzarExcepcionSiExcedeCantidadMaximaDeJugadores();
        Jugadores.Add(new Jugador(nombre));
    }

    public Jugador ObtenerJugador(int indice) =>  Jugadores[indice];

    public void Iniciar()
    {
        LanzarExcepcionSiAlgunoDeLosDosJugadoresNoTieneBarcos();
        IniciarJuego();
    }

    public string Disparar(int x, int y)
    {
        LanzarExcepcionesSiElJuegoNoEstaEnCurso();
        var respuesta = ObtenerJugadorOponente().Tablero.RecibirDisparo(x, y);
        VerificarJuegoFinalizado(ObtenerJugadorOponente());
        
        return respuesta;
    }
    
    public string Imprimir()
    {
        var jugadorActual = ObtenerJugadorEnTurnoActual();
        return DibujarTableroJugador(jugadorActual);
    }
    
    private Jugador ObtenerJugadorOponente()
        => ObtenerJugador(_indiceJugadorOponente);

    private void CambiarTurno()
    {
        _indiceJugadorActual = 1 - _indiceJugadorActual;     
        _indiceJugadorOponente = 1 - _indiceJugadorOponente;
    }
    
    private void LanzarExcepcionSiExcedeCantidadMaximaDeJugadores()
    {
        if(Jugadores.Count == CantidadMaximaJugadores)
            throw new InvalidOperationException("No se pueden agregar más de dos jugadores");
    }
    private void LanzarExcepcionesSiElJuegoNoEstaEnCurso()
    {
        if (EstadoJuego == EstadoJuego.NoIniciado)
            throw new InvalidOperationException("Debe iniciar el juego para poder disparar");
        if (EstadoJuego == EstadoJuego.Finalizado) 
            throw new InvalidOperationException("Debe iniciar un juego nuevo");
    }
    
    private void LanzarExcepcionSiAlgunoDeLosDosJugadoresNoTieneBarcos()
    {
        if (Jugadores.Count(a => a.Tablero.ExistenBarcos()) != Jugadores.Count)
            throw new InvalidOperationException("Ambos jugadores deben tener barcos en el tablero");
    }

    private void VerificarJuegoFinalizado(Jugador jugadorOponente)
    {
        if(!jugadorOponente.Tablero.ExistenBarcos())
            FinalizarJuego();
        
        else
            CambiarTurno();
        
    }
    private void IniciarJuego() => EstadoJuego = EstadoJuego.EnCurso;
    private void FinalizarJuego() => EstadoJuego = EstadoJuego.Finalizado;

    private string DibujarTableroJugador(Jugador jugadorActual)
    {
        var tableroJugador = new StringBuilder();
        
        AgregarLineaJugador(jugadorActual, tableroJugador);
        AgregarDibujoTablero(jugadorActual, tableroJugador);
        
        return tableroJugador.ToString();
    }

    private static void AgregarLineaJugador(Jugador jugadorActual, StringBuilder tableroJugador) => tableroJugador.Append($"  Jugador: {jugadorActual.Nombre}\n");

    private static void AgregarDibujoTablero(Jugador jugadorActual, StringBuilder tableroJugador) => tableroJugador.Append(jugadorActual.Tablero.DibujarTablero());

    private Jugador ObtenerJugadorEnTurnoActual() => ObtenerJugador(_indiceJugadorActual);

    public string ImprimirReporte(Jugador jugadorSeleccionado)
    {
        LanzarExcepcionSiJuegoNoHaSidoFinalizado();
        return "Disparos totales: 1";
    }

    private void LanzarExcepcionSiJuegoNoHaSidoFinalizado()
    {
        if (EstadoJuego != EstadoJuego.Finalizado)
            throw new InvalidOperationException("El juego no se ha finalizado");
    }
}