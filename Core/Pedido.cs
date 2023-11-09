namespace Core
{
    public class Pedido
    {
        public Pedido(int id, Usuario usuario)
        {
            Id = id;
            Usuario = usuario;
        }

        public override string ToString()
            => $@"Pedido Id {Id}, 
                  Usuario {Usuario.Nome}, 
                  Data de criação: {DataCriacao:dd/MM/yyyyy}";

        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
    
}
