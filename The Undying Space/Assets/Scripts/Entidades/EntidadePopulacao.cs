namespace Assets.Scripts.Entidades
{
    public class EntidadePopulacao
    {
        public string Nome { get; private set; }
        public float Populacao { get; private set; }

        public EntidadePopulacao(string nome, float populacao)
        {
            this.Nome = nome;
            this.Populacao = populacao;
        }

        public void AumentarPop(float quantidade)
        {
            Populacao += quantidade;
        }

        /// <summary>
        /// Retorna verdadeiro caso a população tenha zerado.
        /// </summary>
        /// <param name="quantidade"></param>
        /// <returns>true</returns>
        public bool RemoverPop(float quantidade)
        {
            Populacao -= quantidade;
            if (Populacao <= 0)
                return true;
            return false;
        }
    }
}
