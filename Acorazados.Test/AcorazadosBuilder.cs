namespace Acorazados.Test;

public class AcorazadosBuilder : IAcorazadosBuilder
{
    private readonly Acorazados _acorazados = new();

    public IAcorazadosBuilder ConstruirJugadorUno(string nombre, Action<Tablero> configurarBarcos) => ConstruirJugador(nombre, configurarBarcos, 0);

    public IAcorazadosBuilder ConstruirJugadorDos(string nombre, Action<Tablero> configurarBarcos) => ConstruirJugador(nombre, configurarBarcos, 1);

    public Acorazados Construir()
        => _acorazados;

    private IAcorazadosBuilder ConstruirJugador(string nombre, Action<Tablero> configurarBarcos, int indice)
    {
        _acorazados.AgregarJugador(nombre);
        var jugador = _acorazados.ObtenerJugador(indice);
        configurarBarcos(jugador.Tablero);
        return this;
    }
}