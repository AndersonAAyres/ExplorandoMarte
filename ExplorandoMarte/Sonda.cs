using System;

public class Sonda : Posicao
{
    private string _comando;
    private string _coordenada;
    public Sonda() { }
    public Sonda(string dadosdasonda)
    {
        this.DadosDaSonda = dadosdasonda;
    }
    public string DadosDaSonda { get; set; }
    public string MovimentaSonda(string comando, string coordenada)
    {
        _comando = comando;
        _coordenada = coordenada;

        base.Direcao = getDirecao(_coordenada);
        base.CoordenadaX = getCoordenada(_coordenada);
        base.CoordenadaY = getCoordenada(_coordenada, true);

        foreach (char c in _comando.ToCharArray())
        {
            if (Sonda.getComandosPossiveis.Contains(c))
                Run(c);
            else
                throw new Exception($"Comando inválido  ({c})!");
        }
        return $"{this.CoordenadaX.ToString()} {this.CoordenadaY.ToString()} {this.Direcao}";
    }
    private char getDirecao(string coordenadas)
    {
        char result = ' ';
        foreach (char c in coordenadas.Trim().ToCharArray())
        {
            if (!int.TryParse(c.ToString(), out int i) && Sonda.getDirecoesPossiveis.Contains(c))
            {
                result = c;
                break;
            }
        }
        return result;
    }
    private int getCoordenada(string coordenadas, bool segundo = false)
    {
        int result = -1;
        int count = 0;
        foreach (char c in coordenadas.Trim().ToCharArray())
        {
            if (int.TryParse(c.ToString(), out result))
            {
                count += 1;
                if (segundo && count > 1 || !segundo)
                    break;
            }
        }
        return result;
    }

    //private void getNovaPosicao()
    //{
    //    foreach (char c in _comando.ToCharArray())
    //    {
    //        if (_comandospossiveis.Contains(c))
    //            Run(c);
    //    }
    //    return _sonda;
    //}
    private void Run(char c)
    {
        try
        {
            if (char.ToUpper(c) != 'M')
                ProximaDirecao(c);
            else
            {
                ProximaCoordenadaX(this.Direcao);
                ProximaCoordenadaY(this.Direcao);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    private void ProximaDirecao(char comando)
    {
        int index = Sonda.getDirecoesPossiveis.IndexOf(this.Direcao);
        int size = Sonda.getDirecoesPossiveis.Length - 1;


        if (comando.ToString().ToUpper() == "L")
        {
            if (index == 0)
                index = size;
            else
                index -= 1;

        }
        else if (comando.ToString().ToUpper() == "R")
        {
            if (index == size)
                index = 0;
            else
                index += 1;
        }

        this.Direcao = Char.Parse(Sonda.getDirecoesPossiveis.Substring(index, 1));
    }
    private void ProximaCoordenadaX(char dir)
    {
        if ('E' == dir)
            this.CoordenadaX += 1;
        if ('W' == dir)
            this.CoordenadaX -= 1;

    }
    private void ProximaCoordenadaY(char dir)
    {
        if ('N' == dir)
            this.CoordenadaY += 1;
        if ('S' == dir)
            this.CoordenadaY -= 1;
    }
}
