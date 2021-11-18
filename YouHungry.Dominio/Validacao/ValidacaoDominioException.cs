using System;

namespace YouHungry.Dominio.Validacao
{
    public class ValidacaoDominioException : Exception
    {
        public ValidacaoDominioException(string error) : base(error)
        { }

        public static void When(bool hasError, string error) {
            if (hasError) 
                throw new ValidacaoDominioException(error);
        }
    }
}
