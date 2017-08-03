using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Infraestrutura.SerializacaoJsonExtension
{
    public class ClonagemViaJsonSerializer
    {
        public static string SerializeObject(object objetoParaClonar, int profundidade, string[] propriedadesParaIgnorar)
        {

            using (var stringWriter = new StringWriter())
            {
                using (var jsonWriter = new ClonagemViaJsonWriter(stringWriter))
                {
                    Func<bool> includeFunction = () => jsonWriter.Profundidade <= profundidade;
                    Func<string, bool> funcaoDeValidacaoDePropriedade = (propriedade) => !propriedadesParaIgnorar.Contains(propriedade);
                    var resolver = new ClonagemViaJsonContractResolver(includeFunction, funcaoDeValidacaoDePropriedade);
                    var serializer = new Newtonsoft.Json.JsonSerializer() { ContractResolver = resolver, ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
                    serializer.Serialize(jsonWriter, objetoParaClonar);
                }
                return stringWriter.ToString();
            }
        }
    }
}
