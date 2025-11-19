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
    private int _indiceXMaximo;
    private int _indiceYMaximo;

    public Acorazados()
    {
        Tablero = new string[10, 10];
        CalcularIndicesMaximos();
    }

  

    public void AgregarBarco(Barcos barco, int x, int y, Orientacion orientacion = Orientacion.Horizontal)
    {
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
        for (var i = 1; i <= barco.Casillas; i++)
        {
            if (i > 1)
            {
                if (orientacion == Orientacion.Vertical) y++;
                if (orientacion == Orientacion.Horizontal) x++;
            }
            
            LanzarExcepcionSiCasillaEstaFueraDeLimiteDelTablero(x, y);

            LanzarExcepcionSiSeSobreponeUnBarco(x, y);
            
            Tablero[x, y] = barco.Simbolo;
            barco.Coordenadas.Add(new Coordenada(x,y));
        }
        
        _listaBarcos.Add(barco);
    }

    private void LanzarExcepcionSiCasillaEstaFueraDeLimiteDelTablero(int x, int y)
    {
        if (x > _indiceXMaximo || y > _indiceYMaximo)
            throw new InvalidOperationException("Excede el limite del tablero");
    }

    private void LanzarExcepcionSiSeSobreponeUnBarco(int x, int y)
    {
        if (Tablero[x, y] != null)
            throw new InvalidOperationException($"Ya se encuentra un barco ubicado en la coordenada {x},{y}");
    }

    private void LanzarExcepcionSiNumeroPermitidoDeBarcosSuperaLimite(Barcos barco)
    {
        if (_listaBarcos.Count(x => x.Tipo == barco.Tipo) == barco.CantidadPermitida)
            throw new InvalidOperationException($"No se puede adicionar otro {barco.Nombre}");
    }
    
    private void CalcularIndicesMaximos()
    {
        _indiceXMaximo = Tablero.GetLength(0) - 1;
        _indiceYMaximo = Tablero.GetLength(1) - 1;
    }
}

public class Coordenada(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
}

