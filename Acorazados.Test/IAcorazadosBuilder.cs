namespace Acorazados.Test;

public interface IAcorazadosBuilder
{
    IAcorazadosBuilder ConstruirJugadorUno(string nombre, Action<Tablero> configurarBarcos);
    IAcorazadosBuilder ConstruirJugadorDos(string nombre, Action<Tablero> configurarBarcos);
    Acorazados Construir();
}