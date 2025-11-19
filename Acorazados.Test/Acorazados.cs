namespace Acorazados.Test;

public class Acorazados
{
    private const string MarcaTiroAlAgua = "o";
    private const string MarcaTiroExitoso = "x";
    private const string MarcaBarcoHundido = "X";
    private const string MensajeBarcoHundido = "Barco hundido";
    private const string MensajeTiroExitoso = "Tiro exitoso";
    private const string MensajeTiroAlAgua = "Agua";
    private string[,] Tablero { get; }
    private readonly List<Barcos> _listaBarcos = [];

    public Acorazados()
    {
        Tablero = new string[10, 10];
    }

    public void AgregarBarco(Barcos barco, int x, int y, Orientacion orientacion = Orientacion.Horizontal)
    {
        if (Tablero[x, y] != null)
            throw new InvalidOperationException("Ya se encuentra un barco ubicado en la coordenada 1,1");
            
        LanzarExcepcionSiNumeroPermitidoDeBarcosSuperaLimite(barco);
        PosicionarBarcoEnCasillas(barco, x, y, orientacion);
    }

    public string ConsultarValorPorCoordenada(int x, int y) => Tablero[x, y];

    public string RecibirDisparo(int x, int y)
    {
        if (EsTiroExitoso(x, y))
        {
            var barco = ConsultarBarcoPorCoordenada(x, y);
            
            if (SeDebeHundirBarco(x, y, barco))
                return HundirBarco(barco);
            
            return TiroExitoso(x, y);
        }

        return TiroAlAgua(x, y);
    }

    private bool EsTiroExitoso(int x, int y) => Tablero[x, y] != null;

    private bool SeDebeHundirBarco(int x, int y, Barcos? barco) => ObtenerCasillasAtacadas(x, y, barco) == barco.Casillas;

    private Barcos? ConsultarBarcoPorCoordenada(int x, int y) =>
        _listaBarcos
            .FirstOrDefault(b =>
                b.Coordenadas.Any(c => c.X == x && c.Y == y));

    private string HundirBarco(Barcos barco)
    {
        foreach (var coordenadaBarco in barco.Coordenadas) Tablero[coordenadaBarco.X, coordenadaBarco.Y] = MarcaBarcoHundido;
        return MensajeBarcoHundido;
    }

    private int ObtenerCasillasAtacadas(int x, int y, Barcos? barco)
    {
        var casillasAtacadas = 0;

        foreach (var coordenadaBarco in barco.Coordenadas)
        {
            if((coordenadaBarco.X == x && coordenadaBarco.Y == y) || Tablero[coordenadaBarco.X, coordenadaBarco.Y] == MarcaTiroExitoso)
                casillasAtacadas++;
        }
        
        return casillasAtacadas;
    }

    private string TiroExitoso(int x, int y)
    {
        Tablero[x, y] = MarcaTiroExitoso;
        return MensajeTiroExitoso;
    }

    private string TiroAlAgua(int x, int y)
    {
        Tablero[x, y] = MarcaTiroAlAgua;
        return MensajeTiroAlAgua;
    }

    private void PosicionarBarcoEnCasillas(Barcos barco, int x, int y, Orientacion orientacion)
    {
        Tablero[x, y] = barco.Simbolo;
        barco.Coordenadas.Add(new Coordenada(x, y));
        
        for (var i = 1; i < barco.Casillas; i++)
        {
            if (orientacion == Orientacion.Vertical) y++;

            if (orientacion == Orientacion.Horizontal) x++;
            Tablero[x, y] = barco.Simbolo;
            
            barco.Coordenadas.Add(new Coordenada(x,y));
        }
        
        _listaBarcos.Add(barco);
    }

    private void LanzarExcepcionSiNumeroPermitidoDeBarcosSuperaLimite(Barcos barco)
    {
        if (_listaBarcos.Count(x => x.Tipo == barco.Tipo) == barco.CantidadPermitida)
            throw new InvalidOperationException($"No se puede adicionar otro {barco.Nombre}");
    }
}

public class Coordenada(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
}