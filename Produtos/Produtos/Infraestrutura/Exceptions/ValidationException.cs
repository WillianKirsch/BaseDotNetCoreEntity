using System;

namespace Produtos.Infraestrutura.Exceptions
{
    public class ValidationException : Exception
    {   
        public ValidationException(params string[] mensagem)
            : base(string.Concat(string.Join(";", mensagem)))
        {}
    }
}
