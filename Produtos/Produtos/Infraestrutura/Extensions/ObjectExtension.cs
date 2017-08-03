using Produtos.Infraestrutura.SerializacaoJsonExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Infraestrutura.Extensions
{
    public static class ObjectExtension
    {
        public static T Clonar<T>(this T objetoParaClonar)
        {
            return objetoParaClonar.Clonar(1);
        }

        public static T ClonarProfundo<T>(this T objetoParaClonar, params string[] propriedadesParaIgnorar)
        {
            return Clonar<T>(objetoParaClonar, int.MaxValue, propriedadesParaIgnorar);
        }
        public static T ClonarProfundo<T>(this T objetoParaClonar)
        {
            return Clonar<T>(objetoParaClonar, int.MaxValue);
        }

        public static T Clonar<T>(this T objetoParaClonar, int profundidade, params string[] propriedadesParaIgnorar)
        {
            var json = ClonagemViaJsonSerializer.SerializeObject(objetoParaClonar, profundidade, propriedadesParaIgnorar);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        public static T Clonar<T>(this T objetoParaClonar, int profundidade)
        {
            return Clonar<T>(objetoParaClonar, profundidade, new string[] { });
        }
    }
}
